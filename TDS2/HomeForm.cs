using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

/*
 * 
 * 
 * 
*/

namespace TDS2
{
    public partial class HomeForm : Form
    {

        #region 全局变量

        /// <summary>
        /// 用户
        /// </summary>
        private User user;

        /// <summary>
        /// 订单表
        /// </summary>
        private DataTable orderTable = new DataTable();

        /// <summary>
        /// 选中的订单索引
        /// </summary>
        private int selectedItemIndex;

        /// <summary>
        /// 是否选中订单
        /// </summary>
        private bool selectedItem;

        /// <summary>
        /// 订单文件列表集
        /// </summary>
        private List<List<string>> filesList = new List<List<string>>();
        
        /// <summary>
        /// 订单列表原图容器
        /// </summary>
        private List<Image> images = new List<Image>();

        /// <summary>
        /// 打版师集
        /// </summary>
        private EditorList editorList = new EditorList();

        /// <summary>
        /// 磁盘映射窗口
        /// </summary>
        DiskMappingForm diskMappingForm = new DiskMappingForm();

        #endregion 全局变量





        #region 窗口动作
    
        /// <summary>
        /// 窗口按键检测
        /// </summary>
        private void HomeForm_KeyDown(object sender, KeyEventArgs e)
        {
            /// 有部分快捷键在程序菜单中实现
            /// 有部分快捷键在列表按键检测中实现
            switch (e.KeyCode)
            {
                case Keys.F5:
                    {
                        OrderSearch();
                        break;
                    }
                case Keys.Escape:
                    {
                        if (searchBackgroundWorker.IsBusy) searchBackgroundWorker.CancelAsync();
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// 窗口初始化配置
        /// </summary>
        /// <param name="dataRaw">用户信息</param>
        public HomeForm(User inUser)
        {
            InitializeComponent();
            AppSettings aAppSettings = new AppSettings();
            aAppSettings.GoUpdata(false);// 程序升级
            user = inUser;// 获取用户资料表
            SearchTimeInitialization();// 查询时间初始化
            OptionInitialization(user.Dept);// 带子进度按钮、订单类型按钮、订单紧急类别按钮 - 根据部门初始化
            ThemeInitialization();// 主题初始化
            ToolsPermission(user.Dept);// 程序工具栏按钮和程序菜单启停分配
            sqlComboBox.Text = "新数据";// 数据选择
            orderProgressComboBox.SelectedIndexChanged += new EventHandler(orderProgressComboBox_SelectedIndexChanged);// 带子进度 添加选择事件
            orderClassComboBox.SelectedIndexChanged += new EventHandler(orderClassComboBox_SelectedIndexChanged);// 带子分类 添加选择事件
            orderEndComboBox.SelectedIndexChanged += new EventHandler(orderEndComboBox_SelectedIndexChanged);// 紧急类别 添加选择事件
            thumbnailComboBox.SelectedIndexChanged += new EventHandler(thumbnailComboBox_SelectedIndexChanged);// 缩略图 添加选择事件
            sqlComboBox.SelectedIndexChanged += new EventHandler(sqlComboBox_SelectedIndexChanged);// 新旧数据 添加选择事件
        }

        /// <summary>
        /// 窗口显示时
        /// </summary>
        private void HomeForm_Shown(object sender, EventArgs e) { OrderSearch(); }

        /// <summary>
        /// 重写关窗函数
        /// </summary>
        private void HomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            //do { searchBackgroundWorker.CancelAsync(); } while (searchBackgroundWorker.IsBusy);// 取消后台
            Environment.Exit(0);
        }

        /// <summary>
        /// 主题初始化
        /// </summary>
        private void ThemeInitialization()
        {
            if (user.LogShift == "E") Text = "欢迎使用TDS2系统  |  用户：" + user.UserName.ToUpper() + "  |  班次：晚班";//标题
            else if (user.LogShift == "A") Text = "欢迎使用TDS2系统  |  用户：" + user.UserName.ToUpper() + "  |  班次：中班";
            else if (user.LogShift == "M") Text = "欢迎使用TDS2系统  |  用户：" + user.UserName.ToUpper() + "  |  班次：早班";
            orderListView.View = View.LargeIcon; thumbnailComboBox.Text = "缩略图";// 订单列表显示样式
            try// 图标
            {
                Icon = new Icon(Path.Combine(Application.StartupPath, @"Image\Icon.ico"));
                ///
                sqlUpDataButton.Image = Image.FromFile(@"Image\UpData.png");
                filesSortButton.Image = Image.FromFile(@"Image\FilesSort.png");
                diskMappingButton.Image = Image.FromFile(@"Image\DiskMapping.png");
                appSettingsButton.Image = Image.FromFile(@"Image\AppSettings.png");
                userProfileButton.Image = Image.FromFile(@"Image\User.png");
                appHelpButton.Image = Image.FromFile(@"Image\AppHelp.png");
                messageFormButton.Image = Image.FromFile(@"Image\Message.png");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("无权限加载窗口图标图标文件，请尝试使用管理员权限重新运行本程序", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("窗口图标图标文件不存在，程序将自动退出", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载窗口图标图标时发生如下错误，程序将自动退出，描述如下\r\n\r\n" + ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return;
            }
        }

        /// <summary>
        /// 程序工具栏按钮和程序菜单启停分配
        /// </summary>
        /// <param name="dept">部门</param>
        private void ToolsPermission(string dept)
        {
            sqlUpDataButton.Enabled = sqlUpDataMenuItem.Enabled = dept == "OA";// 程序工具栏按钮 数据更新
            filesSortButton.Enabled = dept == "OA";// 程序工具栏按钮 文件整理
            filesSortMenuItem.Enabled = dept == "OA";// 程序菜单 文件整理
            userManageMenuItem.Enabled = dept == "S" || dept == "A" || dept == "IT";// 程序菜单 用户管理
        }

        #endregion 窗口动作





        #region 列表操作

        /// <summary>
        /// 列表双击
        /// </summary>
        private void orderListView_DoubleClick(object sender, EventArgs e) { OpenOrderDetails(); }
        
        /// <summary>
        /// 列表选择项目改变时
        /// </summary>
        private void orderListView_SelectedIndexChanged(object sender, EventArgs e) { }

        /// <summary>
        /// 鼠标滑过子项时快速预览
        /// </summary>
        private void orderListView_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e) { }//e.Item.Selected = true;// 加入快速预览功能

        /// <summary>
        /// 鼠标滑过时获取焦点，用于鼠标滑过子项时选中显示简要
        /// </summary>
        private void orderListView_MouseHover(object sender, EventArgs e) { if (!orderListView.Focused) orderListView.Focus(); }

        /// <summary>
        /// 失去焦点时
        /// </summary>
        private void orderListView_Leave(object sender, EventArgs e) { }

        /// <summary>
        /// 选中项目变更时
        /// </summary>
        private void orderListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) { MenuPermission(); }

        #endregion 列表操作





        #region 列表菜单 

        /// <summary>
        /// 动态生成{打开} 菜单事件
        /// </summary>
        private void OpenOrderFile_ItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;// 获取传过来的子菜单
            System.Diagnostics.Process.Start("explorer.exe", item.Name);// 添加事件
        }

        /// <summary>
        /// 动态生成{打开文件夹} 菜单事件
        /// </summary>
        private void OpenOrderFolder_ItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;// 获取传过来的子菜单
            try
            {
                System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
                processStartInfo.Arguments = "/e,/select," + item.Name;// 选中文件
                System.Diagnostics.Process.Start(processStartInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开文件夹时出现错误，描述如下：\r\n\r\n" + ex, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                return;
            }
        }

        /// <summary>
        /// 动态生成{复制} 菜单事件
        /// </summary>
        private void CopyOrderFile_ItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;// 获取传过来的子菜单
            StringCollection strcoll = new StringCollection();// 系统剪贴板集合，用于未知类型的文件的操作
            strcoll.Add(item.Name);
            Clipboard.SetFileDropList(strcoll);// 文件集合传入剪贴板
        }

        /// <summary>
        /// 动态生成{复制到选择的位置}事件
        /// </summary>
        private void Copy2Folder_ItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;// 获取传过来的子菜单
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = Path.GetFileName(item.Name);// 默认文件名
            saveFileDialog.DefaultExt = Path.GetExtension(item.Name);// 默认格式
            saveFileDialog.AddExtension = true;// 自动添加扩展名
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            try
            {
                File.Copy(item.Name, saveFileDialog.FileName, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("复制文件出现错误，描述如下：\r\n\r\n" + ex, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                return;
            }
        }

        /// <summary>
        /// 动态生成{复制}{到打版师}{图片文件夹}事件
        /// </summary>
        private void Copy2EditorJpg_ItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;// 获取传过来的子菜单
            string newFiles = Path.Combine(EditorList.GetJpgFolder(item.OwnerItem.Text), Path.GetFileName(item.Name));// 新位置
            if (File.Exists(newFiles)) if (MessageBox.Show("目标文件已存在，是否覆盖？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;// 选择窗口
            try
            {
                File.Copy(item.Name, newFiles, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("复制文件出现错误，描述如下：\r\n\r\n" + ex, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                return;
            }
        }

        /// <summary>
        /// 动态生成{复制}{到打版师}{内部格式文件夹}事件
        /// </summary>
        private void Copy2EditorEmb_ItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;// 获取传过来的子菜单
            string newFiles = Path.Combine(EditorList.GetEmbFolder(item.OwnerItem.Text), Path.GetFileName(item.Name));// 新位置
            if (File.Exists(newFiles)) if (MessageBox.Show("目标文件已存在，是否覆盖？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;// 选择窗口
            try
            {
                File.Copy(item.Name, newFiles, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("复制文件出现错误，描述如下：\r\n\r\n" + ex, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                return;
            }
        }

        /// <summary>
        /// 打开列表菜单时
        /// </summary>
        private void orderContextMenuStrip_Opening(object sender, CancelEventArgs e) { MenuPermission(); }

        /// <summary>
        /// 刷新菜单
        /// </summary>
        private void orderRefreshMenuItem_Click(object sender, EventArgs e) { RefreshorSotp(); }

        /// <summary>
        /// 复制订单号菜单
        /// </summary>
        private void orderCopyNameMenuItem_Click(object sender, EventArgs e) { Clipboard.SetText(orderTable.Rows[selectedItemIndex]["订单号"].ToString()); }

        /// <summary>
        /// 复制客户编号菜单
        /// </summary>
        private void orderCopyCustomerMenuItem_Click(object sender, EventArgs e) { Clipboard.SetText(orderTable.Rows[selectedItemIndex]["客户"].ToString()); }

        /// <summary>
        /// 接带菜单
        /// </summary>
        private void orderAddMenuItem_Click(object sender, EventArgs e) { OrderAdd(); }

        /// <summary>
        /// 检查菜单
        /// </summary>
        private void orderCheckMenuItem_Click(object sender, EventArgs e) { OrderCheck(); }

        /// <summary>
        /// 分带菜单
        /// </summary>
        private void orderDeliverMenuItem_Click(object sender, EventArgs e) { OrderDeliver(); }

        /// <summary>
        /// 发带菜单
        /// </summary>
        private void orderReturnMenuItem_Click(object sender, EventArgs e) { OrderDeliver(); }

        /// <summary>
        /// 打版菜单
        /// </summary>
        private void orderZMenuItem_Click(object sender, EventArgs e) { OrderZ(); }

        /// <summary>
        /// 车版菜单
        /// </summary>
        private void orderEMenuItem_Click(object sender, EventArgs e) { OrderE(); }

        /// <summary>
        /// 修改订单菜单
        /// </summary>
        private void orderModifyMenuItem_Click(object sender, EventArgs e) { OrderModify(); }
        /// <summary>
        /// 取消订单菜单
        /// </summary>
        private void orderCancelMenuItem_Click(object sender, EventArgs e) { OrderCancel(); }

        /// <summary>
        /// 删除订单菜单
        /// </summary>
        private void orderDeleteMenuItem_Click(object sender, EventArgs e) { OrderDelete(); }

        /// <summary>
        /// 订单详情菜单
        /// </summary>
        private void orderDetailsMenuItem_Click(object sender, EventArgs e) { OpenOrderDetails(); }

        #endregion 列表菜单





        #region 列表按钮

        /// <summary>
        /// 查询时间初始化
        /// </summary>
        private void SearchTimeInitialization() { orderStartDateTimePicker.Value = DateTime.Now.AddDays(-1); }// 昨天 

        /// <summary>
        /// 开始时间选择时
        /// </summary>
        private void orderStartDateTimePicker_CloseUp(object sender, EventArgs e) { OrderSearch(); }

        /// <summary>
        /// 结束时间
        /// </summary>
        private void orderEndDateTimePicker_CloseUp(object sender, EventArgs e) { OrderSearch(); }

        /// <summary>
        /// 带子进度按钮
        /// </summary>
        private void orderProgressComboBox_SelectedIndexChanged(object sender, EventArgs e) { OrderSearch(); }

        /// <summary>
        /// 订单类型按钮
        /// </summary>
        private void orderClassComboBox_SelectedIndexChanged(object sender, EventArgs e) { OrderSearch(); }

        /// <summary>
        /// 订单紧急类别按钮
        /// </summary>
        private void orderEndComboBox_SelectedIndexChanged(object sender, EventArgs e) { OrderSearch(); }

        /// <summary>
        /// 列表显示方式选择时
        /// </summary>
        private void thumbnailComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (thumbnailComboBox.Text == "缩略图" && orderListView.View != View.LargeIcon)
            {
                orderListView.View = View.LargeIcon;
                orderListReIcons();// 配置缩略图
                orderListTrackBar.Enabled = true;// 开放滑动调节按钮
                OrderSearch();
            }
            else if (thumbnailComboBox.Text == "表格" && orderListView.View != View.Details)
            {
                orderListView.View = View.Details;
                orderListColumnsInitialization();// 初始化表头和列宽
                orderListTrackBar.Enabled = false;// 关闭滑动调节按钮
                OrderSearch();
            }
        }

        /// <summary>
        /// 数据选择按钮
        /// </summary>
        private void sqlComboBox_SelectedIndexChanged(object sender, EventArgs e) { OrderSearch(); }

        /// <summary>
        /// 缩略图大小滑块
        /// </summary>
        private void orderListTrackBar_Scroll(object sender, EventArgs e) { orderListReIcons(); }

        /// <summary>
        /// 重新载入或停止载入按钮
        /// </summary>
        private void orderRefreshButton_Click(object sender, EventArgs e) { RefreshorSotp(); }

        /// <summary>
        /// 带号搜索按钮
        /// </summary>
        private void orderSesrchButton_Click(object sender, EventArgs e)
        {
            if (searchTextBox.Text.Replace(" ", "") == "" || searchTextBox.Text == "在此输入带号")
            {
                searchTextBox.Text = "在此输入带号";
                searchTextBox.Focus();
                searchTextBox.SelectAll();
                return;
            }
            TapeSelect();
        }

        /// <summary>
        /// 回车带号搜索
        /// </summary>
        private void searchTextBox_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) TapeSelect(); }

        /// <summary>
        /// 接带按钮
        /// </summary>
        private void orderAddButton_Click(object sender, EventArgs e) { OrderAdd(); }

        /// <summary>
        /// 分带按钮
        /// </summary>
        private void orderDeliverButton_Click(object sender, EventArgs e) { OrderDeliver(); }

        /// <summary>
        /// 打版按钮
        /// </summary>
        private void orderZButton_Click(object sender, EventArgs e) { OrderZ(); }

        /// <summary>
        /// 车版按钮
        /// </summary>
        private void orderEButton_Click(object sender, EventArgs e) { OrderE(); }

        /// <summary>
        /// 检查按钮
        /// </summary>
        private void orderCheckButton_Click(object sender, EventArgs e) { OrderCheck(); }

        /// <summary>
        /// 发带按钮
        /// </summary>
        private void orderReturnButton_Click(object sender, EventArgs e) { OrderReturn(); }

        #endregion 列表按钮





        #region 列表功能

        /// <summary>
        /// 带子进度按钮、订单类型按钮、订单紧急类别按钮 - 根据部门初始化
        /// </summary>
        private void OptionInitialization(string dept)
        {
            switch (dept)
            {
                case "OA":// OA
                case "HQ":
                    {
                        if (user.Scaner == "y")// 扫描OA
                        {
                            orderProgressComboBox.Text = "待扫描";
                            orderClassComboBox.Text = "全部";
                            orderEndComboBox.Text = "全部";
                        }
                        else// 接带OA
                        {
                            orderProgressComboBox.Text = "未发带";
                            orderClassComboBox.Text = "全部";
                            orderEndComboBox.Text = "全部";
                        }
                        break;
                    }
                case "IT":// IT
                    {
                        orderProgressComboBox.Text = "待做图";
                        orderClassComboBox.Text = "全部";
                        orderEndComboBox.Text = "全部";
                        break;
                    }
                case "Z":// 打版师
                    {
                        orderProgressComboBox.Text = "待打版";
                        orderClassComboBox.Text = "全部";
                        orderEndComboBox.Text = "全部";
                        break;
                    }
                case "E":
                case "QI":// 车版师，质检
                    {
                        orderProgressComboBox.Text = "待车版";
                        orderClassComboBox.Text = "全部";
                        orderEndComboBox.Text = "全部";
                        break;
                    }
                case "S":// 超级管理员
                    {
                        orderProgressComboBox.Text = "未发带";
                        orderClassComboBox.Text = "全部";
                        orderEndComboBox.Text = "全部";
                        break;
                    }
                default:
                    {
                        MessageBox.Show("不能识别值为“" + user.Dept + "”的用户权限，请联系技术人员处理\r\n\r\n程序将自动退出", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                        break;
                    }
            }
        }

        /// <summary>
        /// 订单菜单和按钮启停分配
        /// </summary>
        /// <param name="dept">部门</param>
        private void MenuPermission()
        {
            selectedItem = orderListView.SelectedItems.Count > 0;// 选中了项目
            bool noBackWork = !searchBackgroundWorker.IsBusy;// 后台没有在查询
            string progress;// 带子进度
            bool noSearchAndSelected = noBackWork && selectedItem;

            ///

            orderFilesMenuItem.Enabled = noSearchAndSelected;// {订单文件} 菜单
            orderCheckButton.Enabled = orderCheckMenuItem.Enabled = noSearchAndSelected && (user.Dept == "OA" || user.Dept == "QI" || user.Dept == "E");// {检查} 菜单
            if (selectedItem)// 如果选中
            {
                selectedItemIndex = orderListView.SelectedItems[0].Index;
                progress = OrderProgress.Get(orderTable.Rows[selectedItemIndex]);// 获取带子进度

                ///

                #region 动态生成 {订单文件} 的子菜单
                if (orderFilesMenuItem.DropDownItems.Count > 0) orderFilesMenuItem.DropDownItems.Clear();// 清空 {订单文件} 的菜单
                if (filesList[selectedItemIndex].Count > 0)// 如果选中的订单文件列表数量大于0，获取订单关联文件的列表
                {
                    foreach (string fileName in filesList[selectedItemIndex])
                    {
                        ToolStripMenuItem files = new ToolStripMenuItem();// 在 {订单文件} 菜单下，每个文件生成一个以文件命名的子菜单
                        files.Name = fileName;
                        files.Text = Path.GetFileName(fileName);
                        orderFilesMenuItem.DropDownItems.Add(files);
                        ///
                        ToolStripMenuItem open = new ToolStripMenuItem();// 在每个文件命名的菜单下生成一个 {打开} 子菜单
                        open.Name = fileName;
                        open.Text = "打开 - 在默认程序中";
                        open.Click += new EventHandler(OpenOrderFile_ItemClick);
                        files.DropDownItems.Add(open);
                        ///
                        ToolStripMenuItem openFolder = new ToolStripMenuItem();// 在 {打开} 菜单下生成版师列表的子菜单
                        openFolder.Name = fileName;
                        openFolder.Text = "打开 - 所在文件夹";
                        openFolder.Click += new EventHandler(OpenOrderFolder_ItemClick);
                        files.DropDownItems.Add(openFolder);
                        ///
                        ToolStripMenuItem copyFile = new ToolStripMenuItem();// 在每个文件命名的菜单下生成一个 {复制} 子菜单
                        copyFile.Name = fileName;
                        copyFile.Text = "复制 - 到剪贴板";
                        copyFile.Click += new EventHandler(CopyOrderFile_ItemClick);
                        files.DropDownItems.Add(copyFile);
                        ///
                        ToolStripMenuItem copy2Folder = new ToolStripMenuItem();// 在每个文件命名的菜单下生成一个 {复制} 子菜单
                        copy2Folder.Name = fileName;
                        copy2Folder.Text = "复制 - 到选择的位置";
                        copy2Folder.Click += new EventHandler(Copy2Folder_ItemClick);
                        files.DropDownItems.Add(copy2Folder);
                        ///
                        ToolStripMenuItem copy2Editor = new ToolStripMenuItem();// 在 {复制} 菜单下生成 {到打版师} 子菜单
                        copy2Editor.Name = fileName;
                        copy2Editor.Text = "复制 - 到打版师";
                        files.DropDownItems.Add(copy2Editor);
                        ///
                        foreach (Editor editors in editorList.Editors)
                        {
                            ToolStripMenuItem editor = new ToolStripMenuItem();// 在 {到打版师} 菜单下生成版师列表的子菜单
                            editor.Name = fileName;
                            editor.Text = editors.Name;
                            copy2Editor.DropDownItems.Add(editor);
                            ///
                            ToolStripMenuItem jpgFolder = new ToolStripMenuItem();// 为每个 {版师} 菜单生成一个 {图片文件夹} 子菜单
                            jpgFolder.Name = fileName;
                            jpgFolder.Text = "图片文件夹";
                            jpgFolder.Click += new EventHandler(Copy2EditorJpg_ItemClick);
                            editor.DropDownItems.Add(jpgFolder);
                            ///
                            ToolStripMenuItem embFolder = new ToolStripMenuItem();// 为每个 {版师} 菜单生成一个 {内部格式文件夹} 子菜单
                            embFolder.Name = fileName;
                            embFolder.Text = "内部格式文件夹";
                            embFolder.Click += new EventHandler(Copy2EditorEmb_ItemClick);
                            editor.DropDownItems.Add(embFolder);
                        }
                    }
                }
                else orderFilesMenuItem.Enabled = orderCheckMenuItem.Enabled = orderCheckButton.Enabled = false;// 订单相关文件为0时 // 关闭 {订单文件} 菜单 // 关闭 {检查} 菜单
                #endregion  动态生成 {订单文件} 的子菜单

            }
            else
            {
                selectedItemIndex = -1;
                progress = "";
            }

            ///

            orderStartDateTimePicker.Enabled = noBackWork;// 开始时间
            orderEndDateTimePicker.Enabled = noBackWork;// 结束时间
            orderProgressComboBox.Enabled = noBackWork;// 带子进度
            orderClassComboBox.Enabled = noBackWork;// 带子类型
            orderEndComboBox.Enabled = noBackWork;// 带子紧急类别
            thumbnailComboBox.Enabled = noBackWork;// 列表显示方式
            orderListTrackBar.Enabled = noBackWork;// 调整缩略图大小
            searchTextBox.Enabled = noBackWork;// 搜索框
            orderSesrchButton.Enabled = noBackWork;// 搜索

            ///

            orderRefreshButton.Text = orderRefreshMenuItem.Text = noBackWork ? "重新载入 (F5)" : "停止载入 (Esc)";// 刷新

            ///

            orderAddButton.Enabled = orderAddMenuItem.Enabled = noSearchAndSelected && user.Dept == "OA";// 接带

            ///

            orderDeliverButton.Enabled = orderDeliverMenuItem.Enabled = noSearchAndSelected && (user.Dept == "OA" || user.Dept == "A") && progress == "待分带";// 分带
            if (orderDeliverMenuItem.DropDownItems.Count == 0)
            {
                ToolStripMenuItem distribution2Editors = new ToolStripMenuItem();// 在 {分带} 菜单下生成一个 {到打版师} 的子菜单
                distribution2Editors.Name = "distribution2Editors";
                distribution2Editors.Text = "到打版师";
                orderDeliverMenuItem.DropDownItems.Add(distribution2Editors);
                foreach (Editor editors in editorList.Editors)
                {
                    ToolStripMenuItem editor = new ToolStripMenuItem();// 为每个 {版师} 菜单生成一个 {内部格式文件夹}子菜单
                    editor.Name = editors.Name;
                    editor.Text = editors.Name;
                    //editor.Click += new EventHandler(Copy2EditorEmb_ItemClick);
                    distribution2Editors.DropDownItems.Add(editor);
                }
            }

            ///

            orderZButton.Enabled = orderZMenuItem.Enabled = noSearchAndSelected && user.Dept == "Z" && progress == "待打版";// 打版

            ///

            orderEButton.Enabled = orderEMenuItem.Enabled = noSearchAndSelected && user.Dept == "E" && progress == "待车版";// 车版

            ///

            orderReturnButton.Enabled = orderReturnMenuItem.Enabled = noSearchAndSelected && user.Dept == "OA" && (progress == "待分带" || progress == "待打版" || progress == "待做图" || progress == "待车版" || progress == "待扫描");// 发带

            ///

            orderModifyMenuItem.Enabled = noSearchAndSelected && user.Dept == "OA";// 修改订单
            orderCancelMenuItem.Enabled = noSearchAndSelected && user.Dept == "OA";// 取消订单
            orderDeleteMenuItem.Enabled = noSearchAndSelected && user.Dept == "S";// 删除订单

            ///

            orderCopyMenuItem.Enabled = noSearchAndSelected;// 复制

            ///

            orderDetailsMenuItem.Enabled = noSearchAndSelected;// 订单详细信息
        }

        /// <summary>
        /// 配置缩略图
        /// </summary>
        private void orderListReIcons()
        {
            if (orderListView.View == View.LargeIcon)
            {
                if (imageList != null) imageList.Images.Clear();
                imageList.ImageSize = new Size(orderListTrackBar.Value * 32 + 32, orderListTrackBar.Value * 32 + 32);
                foreach (Image image in images) imageList.Images.Add(image);
                orderListView.LargeImageList = imageList;
            }
        }

        /// <summary>
        /// 初始化表头和列宽
        /// </summary>
        private void orderListColumnsInitialization()
        {
            if (orderListView.Columns.Count < 1 && orderListView.View == View.Details)// 如果列数是否大于1，即此前已经初始化，不再执行
            {
                orderListView.Columns.Add("订单号");
                orderListView.Columns.Add("订单类型");
                orderListView.Columns.Add("紧急类别");
                orderListView.Columns.Add("最迟返回时间");
                orderListView.Columns.Add("接带人");
                orderListView.Columns.Add("接带时间");
                orderListView.Columns.Add("分带人");
                orderListView.Columns.Add("打版师");
                orderListView.Columns.Add("车版师");
                orderListView.Columns.Add("质检员");
                orderListView.Columns.Add("扫描人");
                orderListView.Columns.Add("发带人");
                orderListView.Columns.Add("发带时间");
                orderListView.Columns[0].Width = 120;
                orderListView.Columns[1].Width = 70;
                orderListView.Columns[2].Width = 110;
                orderListView.Columns[3].Width = 130;
                orderListView.Columns[4].Width = 60;
                orderListView.Columns[5].Width = 130;
                orderListView.Columns[6].Width = 60;
                orderListView.Columns[7].Width = 60;
                orderListView.Columns[8].Width = 60;
                orderListView.Columns[9].Width = 60;
                orderListView.Columns[10].Width = 60;
                orderListView.Columns[11].Width = 60;
                orderListView.Columns[12].Width = 130;
            }
        }

        /// <summary>
        /// 刷新列表或停止载入列表
        /// </summary>
        private void RefreshorSotp()
        {
            if (searchBackgroundWorker.IsBusy) searchBackgroundWorker.CancelAsync();
            else OrderSearch();
        }

        /// <summary>
        /// 车版
        /// </summary>
        private void OrderE()
        {
            OrderEForm orderEForm = new OrderEForm();
            orderEForm.ShowDialog();
        }

        /// <summary>
        /// 接带
        /// </summary>
        private void OrderAdd()
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 分带
        /// </summary>
        private void OrderDeliver()
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 打版
        /// </summary>
        private void OrderZ()
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 发带
        /// </summary>
        private void OrderReturn()
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        private void OrderModify()
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        private void OrderCancel()
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        private void OrderDelete()
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 打开订单详情
        /// </summary>
        private void OpenOrderDetails()
        {
            if (orderListView.SelectedItems.Count > 0)
            {
                OrderDetails orderDetails = new OrderDetails(orderTable.Rows[selectedItemIndex]);
                orderDetails.ShowDialog();
            }
        }

        /// <summary>
        /// 检查功能
        /// </summary>
        private void OrderCheck()
        {
            if (filesList[selectedItemIndex].Count == 0)
            {
                MessageBox.Show("该订单不包含任何文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OrderCheckForm orderCheckForm = new OrderCheckForm(orderTable.Rows[selectedItemIndex]);
            orderCheckForm.ShowDialog();
        }

        /// <summary>
        /// 列表快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderListView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Space:
                    {
                        if (e.Control)
                        {
                            if (selectedItemIndex != -1) OrderCheck();
                        }
                        else OpenOrderDetails();
                        break;
                    }
                case Keys.C:
                    {
                        if (e.Control)
                        {
                            if (selectedItem) Clipboard.SetText((string)orderTable.Rows[selectedItemIndex]["订单号"]);
                        }
                        break;
                    }
                default:
                    break;
            }

        }
        #endregion 列表功能





        #region 导步查询

        /// <summary>
        /// 带号搜索
        /// </summary>
        private void TapeSelect()
        {
            if (searchBackgroundWorker.IsBusy) return;// 后台是否进行中

            ///

            string sql = SqlFunction.TapeSelect(user, searchTextBox.Text, sqlComboBox.Text);

            ///

            if (orderTable != null) orderTable.Clear();// 清空订单表
            if (images != null) images.Clear();// 清空图片仓库
            if (imageList != null) imageList.Images.Clear();// 清空图片链
            if (orderListView != null) orderListView.Clear();// 清空列表
            if (filesList != null) filesList.Clear();// 清空订单文件列表集

            ///

            searchBackgroundWorker.RunWorkerAsync(sql);
            MenuPermission();// 菜单和按钮启停分配
        }

        /// <summary>
        /// 订单列表数据查询
        /// </summary>
        private void OrderSearch()
        {
            if (searchBackgroundWorker.IsBusy) return;// 后台是否进行中

            ///

            string sql = SqlFunction.ListSelect(user, orderStartDateTimePicker.Value.ToString(), orderEndDateTimePicker.Value.ToString(), orderProgressComboBox.Text, orderClassComboBox.Text, orderEndComboBox.Text, sqlComboBox.Text);

            ///

            if (orderTable != null) orderTable.Clear();// 清空订单表
            if (images != null) images.Clear();// 清空图片仓库
            if (imageList != null) imageList.Images.Clear();// 清空图片链
            if (orderListView != null) orderListView.Clear();// 清空列表
            if (filesList != null) filesList.Clear();// 清空订单文件列表集

            ///

            searchBackgroundWorker.RunWorkerAsync(sql);
            MenuPermission();// 菜单和按钮启停分配
        }

        /// <summary>
        /// 异步查询工作
        /// </summary>
        private void searchBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            searchBackgroundWorker.ReportProgress(1, "查找中...");// 进度传出
            orderTable = SqlFunction.Select(e.Argument as string);
            if (orderTable == null || orderTable.Rows.Count == 0) return;
            searchBackgroundWorker.ReportProgress(Percents.Get(1, orderTable.Rows.Count), "数据处理中...");// 进度传出
            SqlFunction.Table2Standard(orderTable);// 数据转换到规范模式
            Image UnImage = ImageZoom.Zoom(Image.FromFile(@"Image\UnImage.png"), 256, 256);
            ///
            for (int i = 0; i < orderTable.Rows.Count; i++)// 遍历订单库
            {
                #region 取消检测
                if (searchBackgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                #endregion 取消检测
                #region 加载缩略图
                if (orderListView.View == View.LargeIcon)
                {

                    List<string> files = OrderFiles.Get(orderTable.Rows[i]);// 把订单行传送到方法，获取该订单相关的文件列表 //只在缩略图模式时搜索文件
                    filesList.Add(files);// 订单文件列表装入到集合

                    bool unImage = true;// 是否搜索到图片
                    foreach (string str in files)// 加载缩略图
                    {
                        string extension = Path.GetExtension(str).ToLower();
                        if (File.Exists(str) && (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".bmp" || extension == ".gif"))// 不是图片格式时静默跳过
                        {
                            try
                            {
                                Bitmap bmp = new Bitmap(str);
                                images.Add(ImageZoom.Zoom(bmp, 256, 256));
                                unImage = false;
                                bmp.Dispose();
                                break;
                            }
                            catch// 图片加载出错时，可能是编码有问题，静默跳过，遍历下一个
                            {
                                break;
                            }
                        }
                    }
                    if (unImage) images.Add(UnImage);// 如果没有匹配到图片，加载缺失图片
                }
                #endregion 加载缩略图

                searchBackgroundWorker.ReportProgress(Percents.Get(i, orderTable.Rows.Count), "数据载入中...");// 进度传出
            }
        }

        /// <summary>
        /// 异步查询进度
        /// </summary>
        private void searchBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            homeProgressBar.Value = (e.ProgressPercentage < 101) ? e.ProgressPercentage : homeProgressBar.Value;
            homeStatusLabel.Text = homeProgressBar.Value.ToString() + "% " + e.UserState as string;
        }

        /// <summary>
        /// 导步查询完成
        /// </summary>
        private void searchBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)// 异步出错
            {
                MessageBox.Show("列表载入错误如下\r\n\r\n" + e.Error.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                homeProgressBar.Value = 0;
                homeStatusLabel.Text = "查找出错";
            }

            ///

            else if (e.Cancelled)// 异步取消
            {
                homeProgressBar.Value = 0;
                homeStatusLabel.Text = "已取消查找";
            }

            ///

            else// 异步完成
            {
                if (orderTable == null || orderTable.Rows.Count == 0)// 如果没有结果
                {
                    homeProgressBar.Value = 100;
                    homeStatusLabel.Text = "没有符合查找条件的结果";
                }
                else
                {
                    orderListView.Visible = false;
                    for (int i = 0; i < orderTable.Rows.Count; i++)// 把项目名遍历到ListView
                    {
                        ListViewItem listViewItem = new ListViewItem();// 定义单个项目
                        listViewItem.ImageIndex = i;
                        listViewItem.Text = orderTable.Rows[i]["订单号"].ToString();
                        listViewItem.SubItems.Add(orderTable.Rows[i]["订单类型"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["紧急类别"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["最迟返回时间"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["接带人"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["接带时间"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["分带人"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["打版师"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["车版师"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["质检员"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["扫描人"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["发带人"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["发带时间"].ToString());
                        orderListView.Items.Add(listViewItem);
                    }
                    orderListReIcons();// 配置缩略图
                    orderListColumnsInitialization();// 初始化表头和列宽
                    homeProgressBar.Value = 100;
                    orderListView.Visible = true;
                    homeStatusLabel.Text = "查找到" + orderTable.Rows.Count + "条结果";
                }
            }

            ///

            MenuPermission();// 订单菜单和按钮启停分配
        }
        #endregion 异步查询





        #region 程序菜单
        
        /// <summary>
        /// 选项菜单
        /// </summary>
        private void appSettingsMenuItem_Click(object sender, EventArgs e) { AappSettings(); }

        /// <summary>
        /// 个人资料菜单
        /// </summary>
        private void userProfileMenuItem_Click(object sender, EventArgs e) { UserProfile(); }

        /// <summary>
        /// 退出菜单
        /// </summary>
        private void appExitMenuItem_Click(object sender, EventArgs e) { Close(); }

        /// <summary>
        /// 磁盘映射菜单
        /// </summary>
        private void diskMappingMenuItem_Click(object sender, EventArgs e) { DiskMapping(); }

        /// <summary>
        /// 数据更新菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sqlUpDataMenuItem_Click(object sender, EventArgs e) { SqlUpData(); }

        /// <summary>
        /// 文件整理
        /// </summary>
        private void filesSortMenuItem_Click(object sender, EventArgs e) { FilesSort(); }

        /// <summary>
        /// 用户管理菜单
        /// </summary>
        private void userManageMenuItem_Click(object sender, EventArgs e) { UserManage(); }

        /// <summary>
        /// 帮助菜单
        /// </summary>
        private void appViewHelpMenuItem_Click(object sender, EventArgs e) { AppViewHelp(); }

        /// <summary>
        /// 技术支持
        /// </summary>
        private void developerMenuItem_Click(object sender, EventArgs e) { MessageBox.Show("NRI7\r\nJinzhenting@aliyun.com", "技术支持", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }

        /// <summary>
        /// 升级菜单
        /// </summary>
        private void appUpMenuItem_Click(object sender, EventArgs e) { AppUp(true); }

        /// <summary>
        /// 关于
        /// </summary>
        private void appAboutMenuItem_Click(object sender, EventArgs e) { MessageBox.Show("TDS2\r\n当前版本：" + Application.ProductVersion + "\r\n版权所有：清远市卓华电子商务有限公司", "关于", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }

        #endregion 程序菜单





        #region 程序工具栏

        /// <summary>
        /// 更新数据
        /// </summary>
        private void sqlUpDataButton_Click(object sender, EventArgs e) { SqlUpData(); }

        /// <summary>
        /// 文件整理
        /// </summary>
        private void filesSortButton_Click(object sender, EventArgs e) { FilesSort(); }

        /// <summary>
        /// 磁盘映射
        /// </summary>
        private void diskMappingButton_Click(object sender, EventArgs e) { DiskMapping(); }

        /// <summary>
        /// 选项
        /// </summary>
        private void appSettingsButton_Click(object sender, EventArgs e) { AappSettings(); }

        /// <summary>
        /// 用户资料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userProfileButton_Click(object sender, EventArgs e) { UserProfile(); }

        /// <summary>
        /// 帮助
        /// </summary>
        private void appHelpButton_Click(object sender, EventArgs e) { AppViewHelp(); }

        /// <summary>
        /// 消息窗口按钮
        /// </summary>
        private void messageFormButton_Click(object sender, EventArgs e) { Message(); }

        #endregion 程序工具栏





        #region 程序操作功能

        /// <summary>
        /// 程序升级
        /// </summary>
        /// <param name="bo">就否弹窗</param>
        private void AppUp(bool bo)
        {
            AppSettings aAppSettings = new AppSettings();
            aAppSettings.GoUpdata(bo);// 
        }

        /// <summary>
        /// 选项
        /// </summary>
        private void AappSettings()
        {
            AppSettingsForm settingForm = new AppSettingsForm();
            settingForm.ShowDialog();
        }

        /// <summary>
        /// 个人资料
        /// </summary>
        private void UserProfile()
        {
            UserProfileForm userProfileForm = new UserProfileForm();
            userProfileForm.ShowDialog();
        }

        /// <summary>
        /// 磁盘映射
        /// </summary>
        private void DiskMapping()
        {
            diskMappingForm.ShowDialog();
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        private void SqlUpData()
        {
            UpDataForm upDataForm = new UpDataForm();
            upDataForm.ShowDialog();
        }

        /// <summary>
        /// 文件整理
        /// </summary>
        private void FilesSort()
        {
            FilesSortForm filesSortForm = new FilesSortForm();
            filesSortForm.ShowDialog();
        }

        /// <summary>
        /// 用户管理
        /// </summary>
        private void UserManage()
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 帮助
        /// </summary>
        private void AppViewHelp()
        {
            AppHelpForm appHelpForm = new AppHelpForm();
            appHelpForm.ShowDialog();
        }

        private void Message()
        {
            MessageForm messageForm = new MessageForm();
            messageForm.ShowDialog();
        }

        #endregion 程序操作功能
    }
}
