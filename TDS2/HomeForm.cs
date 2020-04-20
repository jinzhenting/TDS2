using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace TDS2
{
    public partial class HomeForm : Form
    {
        /**  打开和复制文件菜单按列表生成，加载不出其他格式
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
        **/




        /// <summary>
        /// 用户
        /// </summary>
        private User user;

        /// <summary>
        /// 订单集
        /// </summary>
        private List<Order> orders = new List<Order>();

        /// <summary>
        /// 文件夹配置
        /// </summary>
        private Disks disks = new Disks();

        /// <summary>
        /// 订单列表原图容器
        /// </summary>
        private List<Image> images = new List<Image>();

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="dataRaw">用户信息</param>
        public HomeForm(User inUser)
        {
            InitializeComponent();
            AppUpdata.GoUpdata(false);// 程序升级
            user = inUser;// 获取用户资料表
            SearchTimeInitialization();// 查询时间初始化
            OptionInitialization();// 选项初始化
            ThemeInitialization();// 主题初始化
            MenuPermission(user.Dept);// 菜单分配
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
        /// 查询时间初始化
        /// </summary>
        private void SearchTimeInitialization()
        {
            orderDateTimePicker1.Value = DateTime.Now.AddDays(-1);// 改变时间
        }

        /// <summary>
        /// 选项初始化
        /// </summary>
        private void OptionInitialization()
        {
            if (user.Dept == "OA" || user.Dept == "HQ")// OA
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
            }
            else if (user.Dept == "IT")// IT
            {
                orderProgressComboBox.Text = "待做图";
                orderClassComboBox.Text = "全部";
                orderEndComboBox.Text = "全部";
            }
            else if (user.Dept == "Z")// 打版师
            {
                orderProgressComboBox.Text = "待打版";
                orderClassComboBox.Text = "全部";
                orderEndComboBox.Text = "全部";
            }
            else if (user.Dept == "E" || user.Dept == "QI")// 车版师，质检
            {
                orderProgressComboBox.Text = "待车版";
                orderClassComboBox.Text = "全部";
                orderEndComboBox.Text = "全部";
            }
            else if (user.Dept == "A")// 管理层
            {
                orderProgressComboBox.Text = "待分带";
                orderClassComboBox.Text = "全部";
                orderEndComboBox.Text = "全部";
            }
            else if (user.Dept == "S")// 超级管理员
            {
                orderProgressComboBox.Text = "待发带";
                orderClassComboBox.Text = "全部";
                orderEndComboBox.Text = "全部";
            }
            else
            {
                MessageBox.Show("不能识别值为“" + user.Dept + "”的用户权限，请联系技术人员处理\r\n\r\n程序将自动退出", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// 菜单打开动态生成事件
        /// </summary>
        private void Open_ItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            System.Diagnostics.Process.Start("explorer.exe", item.Name);
        }

        /// <summary>
        /// 菜单复制动态生成事件
        /// </summary>
        private void Copy_ItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            System.Collections.Specialized.StringCollection strcoll = new System.Collections.Specialized.StringCollection();
            strcoll.Add(item.Name);
            Clipboard.SetFileDropList(strcoll);
        }

        /// <summary>
        /// 菜单分配
        /// </summary>
        /// <param name="dept">部门</param>
        private void MenuPermission(string dept)
        {
            if (homeBackgroundWorker.IsBusy)// 后台查询时关闭功能
            {
                orderDateTimePicker1.Enabled = false;
                orderDateTimePicker2.Enabled = false;
                orderProgressComboBox.Enabled = false;
                orderClassComboBox.Enabled = false;
                orderEndComboBox.Enabled = false;
                thumbnailComboBox.Enabled = false;
                searchTextBox.Enabled = false;
                orderSesrchButton.Enabled = false;
            }
            else// 后台查询完成时开放功能
            {
                orderDateTimePicker1.Enabled = true;
                orderDateTimePicker2.Enabled = true;
                orderProgressComboBox.Enabled = true;
                orderClassComboBox.Enabled = true;
                orderEndComboBox.Enabled = true;
                thumbnailComboBox.Enabled = true;
                searchTextBox.Enabled = true;
                orderSesrchButton.Enabled = true;
            }
            if (orderListView.SelectedItems.Count < 1)// 列表无项目时
            {
                for (int i = 0; i < orderContextMenuStrip.Items.Count; i++) orderContextMenuStrip.Items[i].Enabled = false;
                orderRefreshMenuItem.Enabled = true;// 列表菜单 刷新
                orderAddMenuItem.Enabled = true;// 列表菜单 接带
                orderCheckButton.Enabled = false;// 列表按钮 检查
                orderDeliverButton.Enabled = false;// 列表按钮 分带
                orderReturnButton.Enabled = false;// 列表按钮 发带
                orderOpenMenuItem.DropDownItems.Clear();// 打开子项目
                orderCopyMenuItem.DropDownItems.Clear();
            }
            else// 选中项目时
            {
                for (int i = 0; i < orderContextMenuStrip.Items.Count; i++) orderContextMenuStrip.Items[i].Enabled = true;
                orderAddButton.Enabled = true;// 列表按钮 接带
                orderCheckButton.Enabled = true;// 列表按钮 检查
                orderDeliverButton.Enabled = true;// 列表按钮 分带
                orderReturnButton.Enabled = true;// 列表按钮 发带
                ///
                List<string> items = orders[orderListView.SelectedItems[0].Index].FilesPath;
                if (items.Count > 0)
                {
                    orderOpenMenuItem.DropDownItems.Clear();// 打开子项目
                    orderCopyMenuItem.DropDownItems.Clear();
                    orderOpenMenuItem.Enabled = true;// 打开子项目
                    orderCopyMenuItem.Enabled = true;
                    foreach (string files in items)// 遍历搜索到的相关文件，动态生成菜单
                    {
                        ToolStripMenuItem itemOpen = new ToolStripMenuItem();
                        itemOpen.Name = files;
                        itemOpen.Text = Path.GetFileName(files);
                        itemOpen.Click += new EventHandler(Open_ItemClick);
                        orderOpenMenuItem.DropDownItems.Add(itemOpen);
                        ToolStripMenuItem itemCopy = new ToolStripMenuItem();
                        itemCopy.Name = files;
                        itemCopy.Text = Path.GetFileName(files);
                        itemCopy.Click += new EventHandler(Copy_ItemClick);
                        orderCopyMenuItem.DropDownItems.Add(itemCopy);
                    }
                }
                else
                {
                    orderOpenMenuItem.Enabled = false;// 打开子项目
                    orderCopyMenuItem.Enabled = false;
                }
            }
            ///
            if (dept == "Z")
            {
                sqlUpDataButton.Enabled = false;// 工具栏按钮 数据更新
                filesSortButton.Enabled = false;// 工具栏按钮 文件整理
                filesSortMenuItem.Enabled = false;// APP菜单 文件整理
                userManageMenuItem.Enabled = false;// APP菜单 用户管理
                orderAddButton.Enabled = false;// 列表按钮 接带
                orderCheckButton.Enabled = false;// 列表按钮 检查
                orderDeliverButton.Enabled = false;// 列表按钮 分带
                orderReturnButton.Enabled = false;// 列表按钮 发带
                searchTextBox.Enabled = false;// 列表 搜索框
                orderSesrchButton.Enabled = false;// 列表按钮 搜索
                toolStripSeparator2.Enabled = false;// 列表菜单 线条
                orderAddMenuItem.Enabled = false;// 列表菜单 接带
                orderDeliverMenuItem.Enabled = false;// 列表菜单 分带
                orderCheckMenuItem.Enabled = false;// 列表菜单 检查
                orderReturnMenuItem.Enabled = false;// 列表菜单 发带
                orderModifyMenuItem.Enabled = false;// 列表菜单 修改订单
                orderCancelMenuItem.Enabled = false;// 列表菜单 取消订单
                orderDeleteMenuItem.Enabled = false;// 列表菜单 删除订单
            }
            else if (dept == "IT")
            {
                sqlUpDataButton.Enabled = false;// 工具栏按钮 数据更新
                filesSortButton.Enabled = false;// 工具栏按钮 文件整理
                filesSortMenuItem.Enabled = false;// APP菜单 文件整理
                userManageMenuItem.Enabled = false;// APP菜单 用户管理
                orderAddButton.Enabled = false;// 列表按钮 接带
                orderCheckButton.Enabled = false;// 列表按钮 检查
                orderDeliverButton.Enabled = false;// 列表按钮 分带
                orderReturnButton.Enabled = false;// 列表按钮 发带
                toolStripSeparator2.Enabled = false;// 列表菜单 线条
                orderAddMenuItem.Enabled = false;// 列表菜单 接带
                orderDeliverMenuItem.Enabled = false;// 列表菜单 分带
                orderCheckMenuItem.Enabled = false;// 列表菜单 检查
                orderReturnMenuItem.Enabled = false;// 列表菜单 发带
                orderModifyMenuItem.Enabled = false;// 列表菜单 修改订单
                orderCancelMenuItem.Enabled = false;// 列表菜单 取消订单
                orderDeleteMenuItem.Enabled = false;// 列表菜单 删除订单
            }
            else if (dept == "OA" || dept == "HQ")
            {
                userManageMenuItem.Enabled = false;// APP菜单 用户管理
            }
            else if (dept == "E" || dept == "QI")
            {
                userManageMenuItem.Enabled = false;// APP菜单 用户管理
                sqlUpDataButton.Enabled = false;// 工具栏按钮 数据更新
                filesSortButton.Enabled = false;// 工具栏按钮 文件整理
                filesSortMenuItem.Enabled = false;// APP菜单 文件整理
                userManageMenuItem.Enabled = false;// APP菜单 用户管理
                orderAddButton.Enabled = false;// 列表按钮 接带
                orderDeliverButton.Enabled = false;// 列表按钮 分带
                orderReturnButton.Enabled = false;// 列表按钮 发带
                searchTextBox.Enabled = false;// 列表 搜索框
                orderSesrchButton.Enabled = false;// 列表按钮 搜索
                toolStripSeparator2.Enabled = false;// 列表菜单 线条
                orderAddMenuItem.Enabled = false;// 列表菜单 接带
                orderDeliverMenuItem.Enabled = false;// 列表菜单 分带
                orderCheckMenuItem.Enabled = false;// 列表菜单 检查
                orderReturnMenuItem.Enabled = false;// 列表菜单 发带
                orderModifyMenuItem.Enabled = false;// 列表菜单 修改订单
                orderCancelMenuItem.Enabled = false;// 列表菜单 取消订单
                orderDeleteMenuItem.Enabled = false;// 列表菜单 删除订单
            }
        }

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
                sql += " Record_in_time>='" + orderDateTimePicker1.Value + "' and Record_in_time<='" + orderDateTimePicker2.Value + "'";// 接带时间
                ///
                if (orderProgressComboBox.Text == "已发带") sql += " AND OutQC IS NOT NULL";// 带子进度 已发带
                else if (orderProgressComboBox.Text == "已取消") sql += " AND Mode='C'";// 带子进度 已取消
                else if (orderProgressComboBox.Text == "待分带") sql += " AND (Mode='O' OR Mode='E' OR Mode='F' OR Mode='Q' OR Mode='T' OR Mode='W') AND Manager IS NULL";// 带子进度 待分带
                else if (orderProgressComboBox.Text == "待打版") sql += " AND (Mode='O' OR Mode='E' OR Mode='F' OR Mode='Q' OR Mode='T') AND Manager IS NOT NULL AND OutQC IS NULL";// 带子进度 待打版
                else if (orderProgressComboBox.Text == "待做图") sql += " AND (Mode='AO' OR Mode='AQ') AND OutQC IS NULL";// 带子进度 待做图
                else if (orderProgressComboBox.Text == "待车版") sql += " AND (Mode='O' OR Mode='E' OR Mode='F' OR Mode='T') AND Manager IS NOT NULL AND Sewout='yes' AND E IS NULL AND OutQC IS NULL";// 带子进度 待车版
                else if (orderProgressComboBox.Text == "待扫描") sql += " AND (Mode='O' OR Mode='E' OR Mode='F' OR Mode='T') AND QI IS NOT NULL AND OutQC IS NULL";// 带子进度 待扫描
                else if (orderProgressComboBox.Text == "待发带") sql += " AND Mode!='C' AND OutQC IS NULL";// 带子进度 待发带
                ///
                if (orderClassComboBox.Text == "新带") sql += " AND Mode='O'";// 带子分类 新带
                else if (orderClassComboBox.Text == "收费改带") sql += " AND Mode='E'";// 带子分类 收费改带
                else if (orderClassComboBox.Text == "免费改带") sql += " AND Mode='F'";// 带子分类 免费改带
                else if (orderClassComboBox.Text == "估针") sql += " AND Mode='Q'";// 带子分类 估针
                else if (orderClassComboBox.Text == "试打版") sql += " AND Mode='T'";// 带子分类 试打版
                else if (orderClassComboBox.Text == "等回复") sql += " AND Mode='W'";// 带子分类 等回复
                else if (orderClassComboBox.Text == "矢量新图") sql += " AND Mode='AO'";// 带子分类 矢量图
                else if (orderClassComboBox.Text == "矢量报价") sql += " AND Mode='AQ'";// 带子分类 矢量报价
                ///
                if (orderEndComboBox.Text == "急改带 - 0.5小时内") sql += " AND Urgency='Rush Editing'";// 紧急度 急改带
                else if (orderEndComboBox.Text == "改带 - 1小时内") sql += " AND Urgency='Editing'";// 紧急度 改带
                else if (orderEndComboBox.Text == "估针 - 1小时内") sql += " AND Urgency='Quote'";// 紧急度 估针
                else if (orderEndComboBox.Text == "特急 - 1小时内") sql += " AND Urgency='Super Rush'";// 紧急度 特急
                else if (orderEndComboBox.Text == "紧急 - 5小时内") sql += " AND Urgency='Rush'";// 紧急度 紧急
                else if (orderEndComboBox.Text == "一般 - 17:00前") sql += " AND Urgency='5PM'";// 紧急度 一般
                else if (orderEndComboBox.Text == "正常 - 24小时内") sql += " AND Urgency='24 hours'";// 紧急度 正常
            }
            ///
            if (orders != null) orders.Clear();// 清空订单表
            if (images != null) images.Clear();// 清空图片仓库
            if (imageList != null) imageList.Images.Clear();// 清空图片链
            if (orderListView != null) orderListView.Clear();// 清空列表
            ///
            if (!homeBackgroundWorker.IsBusy) homeBackgroundWorker.RunWorkerAsync(sql);
            orderRefreshButton.Text = "停止载入 (Esc)";
            orderRefreshMenuItem.Text = "停止载入 (Esc)";
            MenuPermission(user.Dept);// 菜单分配
        }

        #region 导步查询

        /// <summary>
        /// 异步查询工作
        /// </summary>
        private void homeBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            homeBackgroundWorker.ReportProgress(1, "查找中...");// 进度传出
            DataTable sqlDataTable = SqlFunction.Select(e.Argument as string);
            if (sqlDataTable == null || sqlDataTable.Rows.Count == 0) return;
            ///
            for (int i = 0; i < sqlDataTable.Rows.Count; i++)// 遍历订单列表到订单库
            {
                if (homeBackgroundWorker.CancellationPending) { e.Cancel = true; return; }// 取消检测
                orders.Add(OrderFunction.Row2Order(sqlDataTable.Rows[i]));// 数据转换
                homeBackgroundWorker.ReportProgress(Percents.Get(i, sqlDataTable.Rows.Count), "数据处理中...");// 进度传出
            }
            ///
            for (int i = 0; i < orders.Count; i++)// 遍历订单库
            {
                #region 取消检测
                if (homeBackgroundWorker.CancellationPending)
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
                }

                /// O，E，F，Q，T，W，未分带时 // 在 myAttach 中查找图片
                if ((orderClass == "新带" || orderClass == "收费改带" || orderClass == "免费改带" || orderClass == "估针" || orderClass == "试打版" || orderClass == "等回复") && orders[i].EmbManager == "" && orders[i].NrOutQc == "")
                {
                    FileInfo[] fileInfos = new DirectoryInfo(Path.Combine(disks.MyAttach.NetPath, "Attach_in")).GetFiles(orderName + "*.*");
                    foreach (FileInfo fileInfo in fileInfos) orders[i].FilesPath.Add(fileInfo.FullName);
                }

                /// O，E，F，Q，T，打版中
                if ((orderClass == "新带" || orderClass == "收费改带" || orderClass == "免费改带" || orderClass == "估针" || orderClass == "试打版") && orders[i].NrOutQc == "" && orders[i].EmbZ != "")
                {
                    string zFlie = Path.Combine(disks.ZFlie.NetPath, orders[i].EmbZ, "Jpg_Dst");// 在打版师文件夹中查找图片
                    if (Directory.Exists(zFlie))
                    {
                        FileInfo[] fileInfos = new DirectoryInfo(zFlie).GetFiles(orderName + "*.*");
                        foreach (FileInfo fileInfo in fileInfos) orders[i].FilesPath.Add(fileInfo.FullName);
                    }
                }

                /// AQ，AO，W
                if (orderClass == "矢量新图" || orderClass == "矢量报价" || orderClass == "等回复")// 等回复的带子是没有图片的，但有可能做过效果图，尝试查找IT做图文件夹
                {
                    searchPath = Path.Combine(disks.Vector.NetPath, "Today");// Vector\Today中查找
                    FileInfo[] today = new DirectoryInfo(searchPath).GetFiles(orderName + "*.*");
                    foreach (FileInfo fileInfo in today) orders[i].FilesPath.Add(fileInfo.FullName);
                    ///
                    searchPath = Path.Combine(disks.Vector.NetPath, OrderNameParser.GetFilePath(orderName, "Vector"));// Vector\VcetorData中查找
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
                if (unImage) images.Add(Image.FromFile(@"Image\UnImage.jpg"));// 如果没有匹配到图片，加载缺失图片
                #endregion 加载缩略图

                homeBackgroundWorker.ReportProgress(Percents.Get(i, orders.Count), "缩略图载入中...");// 进度传出
            }
        }

        /// <summary>
        /// 异步查询进度
        /// </summary>
        private void homeBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            homeProgressBar.Value = (e.ProgressPercentage < 101) ? e.ProgressPercentage : homeProgressBar.Value;
            homeStatusLabel.Text = homeProgressBar.Value.ToString() + "% " + e.UserState as string;
        }

        /// <summary>
        /// 导步查询完成
        /// </summary>
        private void homeBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ///
            if (e.Error != null)
            {
                MessageBox.Show("列表载入错误如下\r\n\r\n" + e.Error.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                homeProgressBar.Value = 0;
                homeStatusLabel.Text = "查找出错";
                orderRefreshButton.Text = "刷新列表 (F5)";
                orderRefreshMenuItem.Text = "刷新列表 (F5)";
                return;
            }
            ///
            if (e.Cancelled)
            {
                homeProgressBar.Value = 0;
                homeStatusLabel.Text = "已取消查找";
                orderRefreshButton.Text = "刷新列表 (F5)";
                orderRefreshMenuItem.Text = "刷新列表 (F5)";
                return;
            }
            ///
            if (orders.Count < 1 || orders == null)
            {
                homeProgressBar.Value = 100;
                homeStatusLabel.Text = "没有符合查找条件的结果";
                orderRefreshButton.Text = "刷新列表 (F5)";
                orderRefreshMenuItem.Text = "刷新列表 (F5)";
                return;
            }
            ///
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
            ///
            orderListReIcons();// 重置缩略图
            orderListColumnsInitialization();// 重置列表显示
            MenuPermission(user.Dept);// 菜单分配
            ///
            homeProgressBar.Value = 100;
            homeStatusLabel.Text = "查找到" + orders.Count + "条结果";
            orderRefreshButton.Text = "刷新列表 (F5)";
            orderRefreshMenuItem.Text = "刷新列表 (F5)";
        }
        #endregion 异步查询

        #region APP菜单
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

        }

        /// <summary>
        /// 文件整理
        /// </summary>
        private void filesSortMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 用户管理
        /// </summary>
        private void userManageMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 帮助
        /// </summary>
        private void appViewHelpMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 技术支持
        /// </summary>
        private void developerMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 升级
        /// </summary>
        private void appUpMenuItem_Click(object sender, EventArgs e)
        {
            AppUpdata.GoUpdata( true);// 程序升级
        }

        /// <summary>
        /// 关于
        /// </summary>
        private void appAboutMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion APP菜单


        #region 工具栏
        /// <summary>
        /// 更新数据
        /// </summary>
        private void sqlUpDataButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 文件整理
        /// </summary>
        private void filesSortButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 磁盘映射
        /// </summary>
        private void diskMappingButton_Click(object sender, EventArgs e)
        {

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

        }

        /// <summary>
        /// 消息窗口按钮
        /// </summary>
        private void messageFormButton_Click(object sender, EventArgs e)
        {
        }
        #endregion 工具栏


        #region 时间选择
        /// <summary>
        /// 时间1
        /// </summary>
        private void orderDateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            OrderSearch("Load");
        }

        /// <summary>
        /// 时间2
        /// </summary>
        private void orderDateTimePicker2_CloseUp(object sender, EventArgs e)
        {
            OrderSearch("Load");
        }
        #endregion 时间选择


        #region 列表右键菜单
        /// <summary>
        /// 刷新菜单
        /// </summary>
        private void orderRefreshMenuItem_Click(object sender, EventArgs e)
        {
            if (homeBackgroundWorker.IsBusy) homeBackgroundWorker.CancelAsync();
            else OrderSearch("Load");
        }

        /// <summary>
        /// 接带
        /// </summary>
        private void orderAddMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 检查
        /// </summary>
        private void orderCheckMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 分带
        /// </summary>
        private void orderDeliverMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 发带
        /// </summary>
        private void orderReturnMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 修改订单
        /// </summary>
        private void orderModifyMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 取消订单
        /// </summary>
        private void orderCancelMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 删除订单
        /// </summary>
        private void orderDeleteMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 订单详情
        /// </summary>
        private void orderDetailsMenuItem_Click(object sender, EventArgs e)
        {
            OpenOrderDetails();
        }

        /// <summary>
        /// 打开订单详情
        /// </summary>
        private void OpenOrderDetails()
        {
            if (orderListView.SelectedItems.Count > 0)
            {
                OrderDetails orderDetails = new OrderDetails(orders[orderListView.SelectedItems[0].Index]);
                orderDetails.ShowDialog();
            }
        }
        #endregion 列表右键菜单


        #region 列表快捷按钮

        /// <summary>
        /// 刷新或停止按钮
        /// </summary>
        private void orderRefreshButton_Click(object sender, EventArgs e)
        {
            if (homeBackgroundWorker.IsBusy) homeBackgroundWorker.CancelAsync();
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
        /// 接带
        /// </summary>
        private void orderAddButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 检查
        /// </summary>
        private void orderCheckButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 分带
        /// </summary>
        private void orderDeliverButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 发带
        /// </summary>
        private void orderReturnButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 订单完成时间
        /// </summary>
        private void orderEndComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderSearch("Load");
        }

        /// <summary>
        /// 订单类型
        /// </summary>
        private void orderClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderSearch("Load");
        }

        /// <summary>
        /// 带子进度
        /// </summary>
        private void orderProgressComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderSearch("Load");
        }

        /// <summary>
        /// 列表显示方式
        /// </summary>
        private void thumbnailComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (thumbnailComboBox.Text == "缩略图" && orderListView.View != View.LargeIcon)
            {
                orderListView.View = View.LargeIcon;
                orderListReIcons();// 刷新缩略图
                orderListTrackBar.Enabled = true;
            }
            else if (thumbnailComboBox.Text == "表格" && orderListView.View != View.Details)
            {
                orderListView.View = View.Details;
                orderListColumnsInitialization();// 重置表头
                orderListTrackBar.Enabled = false;
            }
        }

        /// <summary>
        /// 缩略图大小滑块
        /// </summary>
        private void orderListTrackBar_Scroll(object sender, EventArgs e)
        {
            orderListReIcons();
        }

        /// <summary>
        /// 重置缩略图
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
        /// 重置表头和列宽
        /// </summary>
        private void orderListColumnsInitialization()
        {
            if (orderListView.Columns.Count < 1 && orderListView.View == View.Details)
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
                orderListView.Columns[2].Width = 70;
                orderListView.Columns[3].Width = 125;
                orderListView.Columns[4].Width = 55;
                orderListView.Columns[5].Width = 125;
                orderListView.Columns[6].Width = 55;
                orderListView.Columns[7].Width = 55;
                orderListView.Columns[8].Width = 55;
                orderListView.Columns[9].Width = 55;
                orderListView.Columns[10].Width = 55;
                orderListView.Columns[11].Width = 55;
                orderListView.Columns[12].Width = 125;
            }
        }

        #endregion 列表快捷按钮

        /// <summary>
        /// 重写关窗函数
        /// </summary>
        private void HomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            //do { homeBackgroundWorker.CancelAsync(); } while (homeBackgroundWorker.IsBusy);// 取消后台
            Environment.Exit(0);
        }

        /// <summary>
        /// 打开列表菜单时
        /// </summary>
        private void orderContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            MenuPermission(user.Dept);
        }

        /// <summary>
        /// 列表双击
        /// </summary>
        private void orderListView_DoubleClick(object sender, EventArgs e)
        {
            OpenDetails();
        }

        /// <summary>
        /// 列表选择项目改变时
        /// </summary>
        private void orderListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            MenuPermission(user.Dept);
        }

        /// <summary>
        /// 鼠标滑过子项时选中显示简要
        /// </summary>
        private void orderListView_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            //e.Item.Selected = true;
        }

        /// <summary>
        /// 鼠标滑过时获取tab，用于鼠标滑过子项时选中显示简要
        /// </summary>
        private void orderListView_MouseMove(object sender, MouseEventArgs e)
        {
            orderListView.Focus();
        }

        /// <summary>
        /// 列表回车查看订单详细
        /// </summary>
        private void orderListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) OpenDetails();
            if (e.KeyCode == Keys.F5) OrderSearch("Load");
            if (e.KeyCode == Keys.Escape) if (homeBackgroundWorker.IsBusy) homeBackgroundWorker.CancelAsync();
        }

        /// <summary>
        /// 查看订单详情
        /// </summary>
        private void OpenDetails()
        {
            if (orderListView.SelectedItems.Count > 0)
            {
                OrderDetails orderDetails = new OrderDetails(orders[orderListView.SelectedItems[0].Index]);
                orderDetails.ShowDialog();
            }
        }

        ///
    }
}
