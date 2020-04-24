using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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
        /// 订单集
        /// </summary>
        private List<Order> orders = new List<Order>();

        /// <summary>
        /// 选中的订单
        /// </summary>
        private Order selectedOrder;

        /// <summary>
        /// 网盘集
        /// </summary>
        private DiskList disks = new DiskList();

        /// <summary>
        /// 订单列表原图容器
        /// </summary>
        private List<Image> images = new List<Image>();

        /// <summary>
        /// 打版师集
        /// </summary>
        private EditorList editorList = new EditorList();

        #endregion 全局变量

        #region 窗口动作

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
            OptionInitialization(user.Dept);// 带子进度按钮、订单类型按钮、订单紧急度按钮 - 根据部门初始化
            ThemeInitialization();// 主题初始化
            ToolsPermission(user.Dept);// 程序工具栏按钮和程序菜单启停分配
            orderProgressComboBox.SelectedIndexChanged += new EventHandler(orderProgressComboBox_SelectedIndexChanged);// 带子进度 添加选择事件
            orderClassComboBox.SelectedIndexChanged += new EventHandler(orderClassComboBox_SelectedIndexChanged);// 带子分类 添加选择事件
            orderEndComboBox.SelectedIndexChanged += new EventHandler(orderEndComboBox_SelectedIndexChanged);// 紧急度 添加选择事件
            thumbnailComboBox.SelectedIndexChanged += new EventHandler(thumbnailComboBox_SelectedIndexChanged);// 缩略图 添加选择事件
        }

        /// <summary>
        /// 窗口显示时
        /// </summary>
        private void HomeForm_Shown(object sender, EventArgs e)
        {
            OrderSearch("Load");// 查询一次
        }

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
                sqlUpDataButton.Image = Image.FromFile(@"Image\Data.png");
                filesSortButton.Image = Image.FromFile(@"Image\Sort.png");
                diskMappingButton.Image = Image.FromFile(@"Image\Disk.png");
                appSettingsButton.Image = Image.FromFile(@"Image\Settings.png");
                appHelpButton.Image = Image.FromFile(@"Image\Help.png");
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
            sqlUpDataButton.Enabled = dept == "OA";// 程序工具栏按钮 数据更新
            filesSortButton.Enabled = dept == "OA";// 程序工具栏按钮 文件整理
            filesSortMenuItem.Enabled = dept == "OA";// 程序菜单 文件整理
            userManageMenuItem.Enabled = dept == "S" || dept == "A" || dept == "IT";// 程序菜单 用户管理
        }

        #endregion 窗口动作

        #region 列表操作

        /// <summary>
        /// 订单菜单和按钮启停分配
        /// </summary>
        /// <param name="dept">部门</param>
        private void MenuPermission(string dept)
        {
            bool noSearch = !searchBackgroundWorker.IsBusy;// 后台没有在查询
            bool isSelected = selectedOrder != null;// 选中了项目
            ///

            orderStartDateTimePicker.Enabled = noSearch;// 列表按钮 开始时间
            orderEndDateTimePicker.Enabled = noSearch;// 列表按钮 结束时间
            orderProgressComboBox.Enabled = noSearch;// 列表按钮 带子进度
            orderClassComboBox.Enabled = noSearch;// 列表按钮 带子类型
            orderEndComboBox.Enabled = noSearch;// 列表按钮 带子紧急度

            ///

            thumbnailComboBox.Enabled = noSearch;// 列表按钮 列表显示方式
            orderListTrackBar.Enabled = noSearch;// 列表按钮 调整缩略图大小
            orderRefreshButton.Text = noSearch ? "重新载入 (F5)" : "停止载入 (Esc)";// 列表按钮 刷新
            searchTextBox.Enabled = noSearch;// 列表搜索框
            orderSesrchButton.Enabled = noSearch;// 列表按钮 搜索

            ///

            orderAddButton.Enabled = noSearch && isSelected && dept == "OA" && selectedOrder.OrderClass != "等回复" && selectedOrder.OrderClass != "矢量新图" && selectedOrder.OrderClass != "矢量报价";// 列表按钮 接带
            orderDeliverButton.Enabled = noSearch && isSelected && (dept == "OA" || dept == "A");// 列表按钮 分带
            orderZButton.Enabled = noSearch && isSelected && dept == "Z";// 列表按钮 打版
            orderEButton.Enabled = noSearch && isSelected && dept == "E";// 列表按钮 车版
            orderCheckButton.Enabled = noSearch && isSelected && (dept == "OA" || dept == "QI" || dept == "E");// 列表按钮 检查
            orderReturnButton.Enabled = noSearch && isSelected && dept == "OA";// 列表按钮 发带

            ///

            orderRefreshMenuItem.Text = noSearch ? "重新载入 (F5)" : "停止载入 (Esc)";// 列表菜单 刷新
            
            ///

            orderDeliverMenuItem.Enabled = noSearch && isSelected && (dept == "OA" || dept == "A") && selectedOrder.OrderClass != "等回复" && selectedOrder.OrderClass != "矢量新图" && selectedOrder.OrderClass != "矢量报价";// 列表菜单 分带
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

            orderCheckMenuItem.Enabled = noSearch && isSelected && (dept == "OA" || dept == "QI" || dept == "E");// 列表菜单 检查
            orderReturnMenuItem.Enabled = noSearch && isSelected && dept == "OA";// 列表菜单 发带
            orderModifyMenuItem.Enabled = noSearch && isSelected && dept == "OA";// 列表菜单 修改订单
            orderCancelMenuItem.Enabled = noSearch && isSelected && dept == "OA";// 列表菜单 取消订单
            orderDeleteMenuItem.Enabled = noSearch && isSelected && dept == "S";// 列表菜单 删除订单

            ///

            orderFilesMenuItem.Enabled = noSearch && isSelected;// 列表菜单 订单文件
            if (isSelected)// 如果选中项目，动态生成 {订单文件} 的子菜单
            {
                if (orderFilesMenuItem.DropDownItems.Count > 0) orderFilesMenuItem.DropDownItems.Clear();// 清空 {订单文件} 的子菜单
                List<string> orderFiles = selectedOrder.FilesPath;// 获取订单关联文件的列表
                if (orderFiles.Count > 0)
                {
                    foreach (string fileName in orderFiles)
                    {
                        ToolStripMenuItem files = new ToolStripMenuItem();// 在 {订单文件} 菜单下，每个文件生成一个以文件命名的子菜单
                        files.Name = fileName;
                        files.Text = Path.GetFileName(fileName);
                        orderFilesMenuItem.DropDownItems.Add(files);
                        ///
                        ToolStripMenuItem open = new ToolStripMenuItem();// 在每个文件命名的菜单下生成一个 {打开} 的子菜单
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
                        ToolStripMenuItem copyFile = new ToolStripMenuItem();// 在每个文件命名的菜单下生成一个 {复制} 的子菜单
                        copyFile.Name = fileName;
                        copyFile.Text = "复制 - 到剪贴板";
                        copyFile.Click += new EventHandler(CopyOrderFile_ItemClick);
                        files.DropDownItems.Add(copyFile);
                        ///
                        ToolStripMenuItem copy2Folder = new ToolStripMenuItem();// 在每个文件命名的菜单下生成一个 {复制} 的子菜单
                        copy2Folder.Name = fileName;
                        copy2Folder.Text = "复制 - 到选择的位置";
                        copy2Folder.Click += new EventHandler(Copy2Folder_ItemClick);
                        files.DropDownItems.Add(copy2Folder);
                        ///
                        ToolStripMenuItem copy2Editor = new ToolStripMenuItem();// 在 {复制} 菜单下生成 {到打版师} 的子菜单
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
                            ToolStripMenuItem jpgFolder = new ToolStripMenuItem();// 为每个 {版师} 菜单生成一个 {图片文件夹}子菜单
                            jpgFolder.Name = fileName;
                            jpgFolder.Text = "图片文件夹";
                            jpgFolder.Click += new EventHandler(Copy2EditorJpg_ItemClick);
                            editor.DropDownItems.Add(jpgFolder);
                            ///
                            ToolStripMenuItem embFolder = new ToolStripMenuItem();// 为每个 {版师} 菜单生成一个 {内部格式文件夹}子菜单
                            embFolder.Name = fileName;
                            embFolder.Text = "内部格式文件夹";
                            embFolder.Click += new EventHandler(Copy2EditorEmb_ItemClick);
                            editor.DropDownItems.Add(embFolder);
                        }
                    }
                }
                else// 文件数=0时
                {
                    orderFilesMenuItem.Enabled = false;// 关闭 {订单文件} 菜单
                    orderCheckMenuItem.Enabled = false;// 关闭 {检查} 菜单
                }
            }
            orderCopyMenuItem.Enabled = noSearch && isSelected;// 列表菜单 复制订单号
            orderAddMenuItem.Enabled = noSearch && dept == "OA";// 列表菜单 接带

            ///

            orderDetailsMenuItem.Enabled = noSearch && isSelected;// 列表菜单 订单详细信息
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
                orderListView.Columns.Add("带号");
                orderListView.Columns.Add("类型");
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
        /// 列表双击
        /// </summary>
        private void orderListView_DoubleClick(object sender, EventArgs e)
        {
            OpenOrderDetails();
        }

        /// <summary>
        /// 列表快捷键
        /// </summary>
        private void orderListView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Space:
                    {
                        if (e.Control) { if (selectedOrder != null) OrderCheck(); }
                        else OpenOrderDetails();
                        break;
                    }
                case Keys.F5:
                    {
                        OrderSearch("Load");
                        break;
                    }
                case Keys.Escape:
                    {
                        if (searchBackgroundWorker.IsBusy) searchBackgroundWorker.CancelAsync();
                        break;
                    }
                case Keys.C:
                    {
                        if (e.Control) Clipboard.SetText(selectedOrder.OrderName);
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// 检查功能
        /// </summary>
        private void OrderCheck()
        {
            if (selectedOrder.FilesPath.Count == 0)
            {
                MessageBox.Show("该订单不包含任何文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OrderCheckForm orderCheckForm = new OrderCheckForm(selectedOrder);
            orderCheckForm.ShowDialog();
        }

        /// <summary>
        /// 打开订单详情
        /// </summary>
        private void OpenOrderDetails()
        {
            if (orderListView.SelectedItems.Count > 0)
            {
                OrderDetails orderDetails = new OrderDetails(selectedOrder);
                orderDetails.ShowDialog();
            }
        }

        /// <summary>
        /// 列表选择项目改变时
        /// </summary>
        private void orderListView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 鼠标滑过子项时快速预览
        /// </summary>
        private void orderListView_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            // 加入快速预览功能
            //e.Item.Selected = true;
        }

        /// <summary>
        /// 鼠标滑过时获取焦点，用于鼠标滑过子项时选中显示简要
        /// </summary>
        private void orderListView_MouseHover(object sender, EventArgs e)
        {
            if (!orderListView.Focused) orderListView.Focus();
        }
        
        /// <summary>
        /// 失去焦点时
        /// </summary>
        private void orderListView_Leave(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 选中项目变更时
        /// </summary>
        private void orderListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (orderListView.SelectedItems.Count == 0) selectedOrder = null;// 如果没有选中
            else selectedOrder = orders[orderListView.SelectedItems[0].Index];
        }

        #endregion 列表操作

        #region 列表菜单 

        /// <summary>
        /// {打开} 菜单事件
        /// </summary>
        private void OpenOrderFile_ItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;// 获取传过来的子菜单
            System.Diagnostics.Process.Start("explorer.exe", item.Name);// 添加事件
        }

        /// <summary>
        /// {打开文件夹} 菜单事件
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
        /// {复制} 菜单事件
        /// </summary>
        private void CopyOrderFile_ItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;// 获取传过来的子菜单
            StringCollection strcoll = new StringCollection();// 系统剪贴板集合，用于未知类型的文件的操作
            strcoll.Add(item.Name);
            Clipboard.SetFileDropList(strcoll);// 文件集合传入剪贴板
        }

        /// <summary>
        /// {复制到选择的位置}事件
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
        /// {复制}{到打版师}{图片文件夹}事件
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
        /// {复制}{到打版师}{内部格式文件夹}事件
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
        private void orderContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            MenuPermission(user.Dept);// 订单菜单和按钮启停分配
        }

        /// <summary>
        /// 刷新菜单
        /// </summary>
        private void orderRefreshMenuItem_Click(object sender, EventArgs e)
        {
            if (searchBackgroundWorker.IsBusy) searchBackgroundWorker.CancelAsync();
            else OrderSearch("Load");
        }

        /// <summary>
        /// 复制订单号菜单
        /// </summary>
        private void orderCopyNameMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(selectedOrder.OrderName);
        }

        /// <summary>
        /// 复制客户编号菜单
        /// </summary>
        private void orderCopyCustomerMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(selectedOrder.OrderCustomer);
        }

        /// <summary>
        /// 接带菜单
        /// </summary>
        private void orderAddMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 检查菜单
        /// </summary>
        private void orderCheckMenuItem_Click(object sender, EventArgs e)
        {
            OrderCheck();
        }

        /// <summary>
        /// 分带菜单
        /// </summary>
        private void orderDeliverMenuItem_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 发带菜单
        /// </summary>
        private void orderReturnMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 修改订单菜单
        /// </summary>
        private void orderModifyMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 取消订单菜单
        /// </summary>
        private void orderCancelMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 删除订单菜单
        /// </summary>
        private void orderDeleteMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 订单详情菜单
        /// </summary>
        private void orderDetailsMenuItem_Click(object sender, EventArgs e)
        {
            OpenOrderDetails();
        }

        #endregion 列表菜单

        #region 列表按钮

        /// <summary>
        /// 查询时间初始化
        /// </summary>
        private void SearchTimeInitialization()
        {
            orderStartDateTimePicker.Value = DateTime.Now.AddDays(-1);// 昨天
        }

        /// <summary>
        /// 开始时间选择时
        /// </summary>
        private void orderStartDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            OrderSearch("Load");// 后台查询
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        private void orderEndDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            OrderSearch("Load");// 后台查询
        }

        /// <summary>
        /// 带子进度按钮、订单类型按钮、订单紧急度按钮 - 根据部门初始化
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
                            orderProgressComboBox.Text = "待发带";
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
                        orderProgressComboBox.Text = "待发带";
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
        /// 带子进度按钮
        /// </summary>
        private void orderProgressComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderSearch("Load");
        }

        /// <summary>
        /// 订单类型按钮
        /// </summary>
        private void orderClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderSearch("Load");
        }

        /// <summary>
        /// 订单紧急度按钮
        /// </summary>
        private void orderEndComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderSearch("Load");
        }

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
            }
            else if (thumbnailComboBox.Text == "表格" && orderListView.View != View.Details)
            {
                orderListView.View = View.Details;
                orderListColumnsInitialization();// 初始化表头和列宽
                orderListTrackBar.Enabled = false;// 关闭滑动调节按钮
            }
        }

        /// <summary>
        /// 缩略图大小滑块
        /// </summary>
        private void orderListTrackBar_Scroll(object sender, EventArgs e)
        {
            orderListReIcons();// 配置缩略图
        }

        /// <summary>
        /// 重新载入或停止载入按钮
        /// </summary>
        private void orderRefreshButton_Click(object sender, EventArgs e)
        {
            if (searchBackgroundWorker.IsBusy) searchBackgroundWorker.CancelAsync();
            else OrderSearch("Load");
        }

        /// <summary>
        /// 搜索按钮
        /// </summary>
        private void orderSesrchButton_Click(object sender, EventArgs e)
        {
            if (searchTextBox.Text == "" || searchTextBox.Text == "在此输入带号")
            {
                searchTextBox.Text = "在此输入带号";
                searchTextBox.Focus();
                searchTextBox.SelectAll();
                return;
            }
            OrderSearch("Select");
        }

        /// <summary>
        /// 回车开始搜索
        /// </summary>
        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) OrderSearch("Select");
        }

        /// <summary>
        /// 接带按钮
        /// </summary>
        private void orderAddButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 分带按钮
        /// </summary>
        private void orderDeliverButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 打版按钮
        /// </summary>
        private void orderZButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 车版按钮
        /// </summary>
        private void orderEButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 检查按钮
        /// </summary>
        private void orderCheckButton_Click(object sender, EventArgs e)
        {
            OrderCheck();
        }

        /// <summary>
        /// 发带按钮
        /// </summary>
        private void orderReturnButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        #endregion 列表按钮

        #region 导步查询

        /// <summary>
        /// 订单列表数据查询
        /// </summary>
        private void OrderSearch(string mode)
        {
            if (orderListView != null) orderListView.Clear();// 清空旧数据
            ///
            string sql = "SELECT * FROM TDS WHERE";
            if (mode == "Select") sql += " sTape='" + searchTextBox.Text + "'";// 以带号查询
            else if (mode == "Load")// 按条件查询
            {
                sql += " Record_in_time>='" + orderStartDateTimePicker.Value + "' and Record_in_time<='" + orderEndDateTimePicker.Value + "'";// 接带时间

                ///

                switch (orderProgressComboBox.Text)
                {
                    case "已发带":
                        {
                            sql += " AND OutQC IS NOT NULL";// 带子进度 已发带
                            break;
                        }
                    case "已取消":
                        {
                            sql += " AND Mode='C'";// 带子进度 已取消
                            break;
                        }
                    case "待分带":
                        {
                            sql += " AND (Mode='O' OR Mode='E' OR Mode='F' OR Mode='Q' OR Mode='T' OR Mode='W') AND Manager IS NULL";// 带子进度 待分带
                            break;
                        }
                    case "待打版":
                        {
                            sql += " AND (Mode='O' OR Mode='E' OR Mode='F' OR Mode='Q' OR Mode='T') AND Manager IS NOT NULL AND OutQC IS NULL";// 带子进度 待打版
                            break;
                        }
                    case "待做图":
                        {
                            sql += " AND (Mode='AO' OR Mode='AQ') AND OutQC IS NULL";// 带子进度 待做图
                            break;
                        }
                    case "待车版":
                        {
                            sql += " AND (Mode='O' OR Mode='E' OR Mode='F' OR Mode='T') AND Manager IS NOT NULL AND Sewout='yes' AND E IS NULL AND OutQC IS NULL";// 带子进度 待车版
                            break;
                        }
                    case "待扫描":
                        {
                            sql += " AND (Mode='O' OR Mode='E' OR Mode='F' OR Mode='T') AND QI IS NOT NULL AND OutQC IS NULL";// 带子进度 待扫描
                            break;
                        }
                    case "待发带":
                        {
                            sql += " AND Mode!='C' AND Mode!='W' AND OutQC IS NULL";// 带子进度 待发带
                            break;
                        }
                    default:
                        break;
                }

                ///

                switch (orderClassComboBox.Text)
                {
                    case "新带":// 带子分类 新带
                        {
                            sql += " AND Mode='O'";
                            break;
                        }
                    case "收费改带":// 带子分类 收费改带
                        {
                            sql += " AND Mode='E'";
                            break;
                        }
                    case "免费改带":// 带子分类 免费改带
                        {
                            sql += " AND Mode='F'";
                            break;
                        }
                    case "估针":// 带子分类 估针
                        {
                            sql += " AND Mode='Q'";
                            break;
                        }
                    case "试打版":// 带子分类 试打版
                        {
                            sql += " AND Mode='T'";
                            break;
                        }
                    case "等回复":// 带子分类 等回复
                        {
                            sql += " AND Mode='W'";
                            break;
                        }
                    case "矢量新图":// 带子分类 矢量图
                        {
                            sql += " AND Mode='AO'";
                            break;
                        }
                    case "矢量报价":// 带子分类 矢量报价
                        {
                            sql += " AND Mode='AQ'";
                            break;
                        }
                    default:
                        break;
                }

                ///

                switch (orderEndComboBox.Text)
                {
                    case "急改 - 30分钟内":// 紧急度 急改
                        {
                            sql += " AND Urgency='Rush Editing'";
                            break;
                        }
                    case "改带 - 1小时内":// 紧急度 改带break;
                        {
                            sql += " AND Urgency='Editing'";
                            break;
                        }
                    case "估针 - 1小时内":// 紧急度 估针
                        {
                            sql += " AND Urgency='Quote'";
                            break;
                        }
                    case "特急 - 1小时内":// 紧急度 特急
                        {
                            sql += " AND Urgency='Super Rush'";
                            break;
                        }
                    case "紧急 - 5小时内":// 紧急度 紧急
                        {
                            sql += " AND Urgency='Rush'";
                            break;
                        }
                    case "一般 - 17:00前":// 紧急度 一般
                        {
                            sql += " AND Urgency='5PM'";
                            break;
                        }
                    case "正常 - 24小时内":// 紧急度 正常
                        {
                            sql += " AND Urgency='24 hours'";
                            break;
                        }
                    case "长时 - 2至3天":// 紧急度 长时
                        {
                            sql += " AND Urgency='2-3 days'";
                            break;
                        }
                    case "超长时 - 4至6天":// 紧急度 超长时
                        {
                            sql += " AND Urgency='4-6 days'";
                            break;
                        }
                    default:
                        break;
                }
            }

            ///

            if (user.Dept == "Z") sql += " AND Z='" + user.UserName + "'";// 打版师只能查询自己的带子

            ///

            if (orders != null) orders.Clear();// 清空订单表
            if (images != null) images.Clear();// 清空图片仓库
            if (imageList != null) imageList.Images.Clear();// 清空图片链
            if (orderListView != null) orderListView.Clear();// 清空列表
            MenuPermission(user.Dept);// 订单菜单和按钮启停分配

            ///

            if (!searchBackgroundWorker.IsBusy)// 后台是否进行中
            {
                searchBackgroundWorker.RunWorkerAsync(sql);
                MenuPermission(user.Dept);// 订单菜单和按钮启停分配
            }

        }

        /// <summary>
        /// 异步查询工作
        /// </summary>
        private void searchBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            searchBackgroundWorker.ReportProgress(1, "查找中...");// 进度传出
            DataTable sqlDataTable = SqlFunction.Select(e.Argument as string);
            if (sqlDataTable == null || sqlDataTable.Rows.Count == 0) return;
            ///
            for (int i = 0; i < sqlDataTable.Rows.Count; i++)// 遍历订单列表到订单库
            {
                if (searchBackgroundWorker.CancellationPending) { e.Cancel = true; return; }// 取消检测
                orders.Add(OrderFunction.Row2Order(sqlDataTable.Rows[i]));// 数据转换
                searchBackgroundWorker.ReportProgress(Percents.Get(i, sqlDataTable.Rows.Count), "数据处理中...");// 进度传出
            }
            ///
            for (int i = 0; i < orders.Count; i++)// 遍历订单库
            {
                #region 取消检测
                if (searchBackgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                #endregion 取消检测

                #region 加载缩略图
                string searchPath = null;// 搜索路径
                string orderName = orders[i].OrderName.ToUpper();// 订单号，转换大写用于比对
                string orderClass = orders[i].OrderClass.ToUpper();// 订单类型
                string orderComputer = orders[i].OrderComputer;// 订单电脑
                ///
                if (orderClass != "矢量新图" && orderClass != "矢量报价")// 只要不是矢量图 先在Emb和Ds的绝对位置检测
                {
                    foreach (string dst in disks.Datas)// 3个Data文件夹共12个子文件夹列表// Dst文件路径 和Emb分开遍历，是避免Dst和Emb不储存在同一个Data当中
                    {
                        string dstPath = Path.Combine(dst, OrderNameParser.GetFilePath(orderName, "Dst"));
                        if (File.Exists(dstPath))
                        {
                            orders[i].FilesPath.Add(dstPath);
                            searchPath = Path.GetDirectoryName(dstPath);
                            break;
                        }
                    }
                    foreach (string emb in disks.Datas)// Emb文件路径 和Dst分开遍历，是避免Dst和Emb不储存在同一个Data当中
                    {
                        string embPath = Path.Combine(emb, OrderNameParser.GetFilePath(orderName, "Emb"));
                        if (File.Exists(embPath))
                        {
                            orders[i].FilesPath.Add(embPath);
                            break;
                        }
                    }
                    if (searchPath != null)// 如果Data in_out文件夹中发现了Dst，将继续搜索in_out文件夹就否有其他格式相关文件
                    {
                        FileInfo[] fileInfos = new DirectoryInfo(searchPath).GetFiles(orderName + "*.*");
                        foreach (FileInfo fileInfo in fileInfos) if (fileInfo.Extension.ToLower() != ".dst") orders[i].FilesPath.Add(fileInfo.FullName);// 排除Dst格式
                    }

                    /// 在 myAttachIn 中查找图片
                    FileInfo[] myAttachIn = new DirectoryInfo(Path.Combine(disks.MyAttach.LocalPath, "Attach_In")).GetFiles(orderName + "*.*");
                    foreach (FileInfo fileInfo in myAttachIn) orders[i].FilesPath.Add(fileInfo.FullName);

                    /// 在 myAttachOut 中查找图片
                    FileInfo[] myAttachOut = new DirectoryInfo(Path.Combine(disks.MyAttach.LocalPath, "Attach_Out")).GetFiles(orderName + "*.*");
                    foreach (FileInfo fileInfo in myAttachOut) orders[i].FilesPath.Add(fileInfo.FullName);
                }

                /// O，E，F，Q，T，打版中
                if ((orderClass == "新带" || orderClass == "收费改带" || orderClass == "免费改带" || orderClass == "估针" || orderClass == "试打版") && orders[i].NrOutQc == "" && orders[i].EmbZ != "")
                {
                    /// 在 打版师文件夹 中查找图片
                    string zFlie = Path.Combine(disks.ZFlie.LocalPath, orders[i].EmbZ, "Jpg_Dst");// 在打版师文件夹中查找图片
                    if (Directory.Exists(zFlie))
                    {
                        FileInfo[] fileInfos = new DirectoryInfo(zFlie).GetFiles(orderName + "*.*");
                        foreach (FileInfo fileInfo in fileInfos) orders[i].FilesPath.Add(fileInfo.FullName);
                    }
                }

                /// AQ，AO，W
                if (orderClass == "矢量新图" || orderClass == "矢量报价" || orderClass == "等回复")// 等回复的带子是没有图片的，但有可能做过效果图，尝试查找IT做图文件夹
                {
                    searchPath = Path.Combine(disks.Vector.LocalPath, "Today");// Vector\Today中查找
                    FileInfo[] today = new DirectoryInfo(searchPath).GetFiles(orderName + "*.*");
                    foreach (FileInfo fileInfo in today) orders[i].FilesPath.Add(fileInfo.FullName);
                    ///
                    searchPath = Path.Combine(disks.Vector.LocalPath, OrderNameParser.GetFilePath(orderName, "Vector"));// Vector\VcetorData中查找
                    if (Directory.Exists(searchPath))
                    {
                        FileInfo[] vcetorData = new DirectoryInfo(searchPath).GetFiles(orderName + "*.*");
                        foreach (FileInfo fileInfo in vcetorData) orders[i].FilesPath.Add(fileInfo.FullName);
                    }
                }
                ///
                bool unImage = true;// 是否搜索到图片
                orders[i].FilesPath.Reverse();// 文件列表倒序，遍历时从新到旧
                foreach (string str in orders[i].FilesPath)// 加载缩略图
                {
                    string extension = Path.GetExtension(str).ToLower();
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".bmp" || extension == ".gif")
                    {
                        images.Add(ImageZoom.Zoom(Image.FromFile(str), 256, 256));
                        unImage = false;
                        break;
                    }
                }
                if (unImage) images.Add(ImageZoom.Zoom(Image.FromFile(@"Image\UnImage.jpg"), 256, 256));// 如果没有匹配到图片，加载缺失图片
                #endregion 加载缩略图

                searchBackgroundWorker.ReportProgress(Percents.Get(i, orders.Count), "缩略图载入中...");// 进度传出
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
                if (orders == null || orders.Count < 1)// 如果没有结果
                {
                    homeProgressBar.Value = 100;
                    homeStatusLabel.Text = "没有符合查找条件的结果";
                }
                else
                {
                    for (int i = 0; i < orders.Count; i++)// 把项目名遍历到ListView
                    {
                        ListViewItem listViewItem = new ListViewItem();// 定义单个项目
                        listViewItem.ImageIndex = i;
                        listViewItem.Text = orders[i].OrderName;
                        listViewItem.SubItems.Add(orders[i].OrderClass);
                        listViewItem.SubItems.Add(orders[i].OrderUrgency);
                        listViewItem.SubItems.Add(Convert.ToString(orders[i].OrderLatestReturnTime));
                        listViewItem.SubItems.Add(orders[i].NrInQC);
                        listViewItem.SubItems.Add(Convert.ToString(orders[i].NrInTime));
                        listViewItem.SubItems.Add(orders[i].EmbManager);
                        listViewItem.SubItems.Add(orders[i].EmbZ);
                        listViewItem.SubItems.Add(orders[i].EmbE);
                        listViewItem.SubItems.Add(orders[i].EmbQi);
                        listViewItem.SubItems.Add(orders[i].EmbScaner.ToUpper());
                        listViewItem.SubItems.Add(orders[i].NrOutQc);
                        listViewItem.SubItems.Add(Convert.ToString(orders[i].NrOutTime));
                        orderListView.Items.Add(listViewItem);
                    }
                    orderListReIcons();// 配置缩略图
                    orderListColumnsInitialization();// 初始化表头和列宽
                    homeProgressBar.Value = 100;
                    homeStatusLabel.Text = "查找到" + orders.Count + "条结果";
                }
            }

            ///

            MenuPermission(user.Dept);// 订单菜单和按钮启停分配
        }
        #endregion 异步查询

        #region 程序菜单
        /// <summary>
        /// 选项菜单
        /// </summary>
        private void appSettingsMenuItem_Click(object sender, EventArgs e)
        {
            AppSettingsForm settingForm = new AppSettingsForm();
            settingForm.ShowDialog();
        }

        /// <summary>
        /// 个人资料
        /// </summary>
        private void userProfileMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 退出菜单
        /// </summary>
        private void appExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 磁盘映射
        /// </summary>
        private void diskMappingMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 文件整理
        /// </summary>
        private void filesSortMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 用户管理
        /// </summary>
        private void userManageMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 帮助
        /// </summary>
        private void appViewHelpMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 技术支持
        /// </summary>
        private void developerMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NRI7\r\nJinzhenting@aliyun.com", "技术支持", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 升级
        /// </summary>
        private void appUpMenuItem_Click(object sender, EventArgs e)
        {
            AppSettings aAppSettings = new AppSettings();
            aAppSettings.GoUpdata(true);// 程序升级
        }

        /// <summary>
        /// 关于
        /// </summary>
        private void appAboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TDS2\r\n当前版本：" + Application.ProductVersion + "\r\n版权所有：清远市卓华电子商务有限公司", "关于", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        #endregion 程序菜单

        #region 程序工具栏

        /// <summary>
        /// 更新数据
        /// </summary>
        private void sqlUpDataButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 文件整理
        /// </summary>
        private void filesSortButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 磁盘映射
        /// </summary>
        private void diskMappingButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 选项
        /// </summary>
        private void appSettingsButton_Click(object sender, EventArgs e)
        {
            AppSettingsForm settingForm = new AppSettingsForm();
            settingForm.ShowDialog();
        }

        /// <summary>
        /// 帮助
        /// </summary>
        private void appHelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 消息窗口按钮
        /// </summary>
        private void messageFormButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        #endregion 程序工具栏
    }
}
