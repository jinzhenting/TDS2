namespace TDS2
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.orderContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.orderRefreshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderFilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderCopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.orderAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderDeliverMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderCheckMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderReturnMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.orderModifyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderCancelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderDetailsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homeStatusStrip = new System.Windows.Forms.StatusStrip();
            this.homeProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.homeStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.homeMenuStrip = new System.Windows.Forms.MenuStrip();
            this.userMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userProfileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diskMappingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesSortMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appHelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appViewHelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.developerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appUpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appAboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderListView = new System.Windows.Forms.ListView();
            this.homeTabControl = new System.Windows.Forms.TabControl();
            this.orderTabPage = new System.Windows.Forms.TabPage();
            this.orderZButton = new System.Windows.Forms.Button();
            this.orderEButton = new System.Windows.Forms.Button();
            this.orderListTrackBar = new System.Windows.Forms.TrackBar();
            this.thumbnailComboBox = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.orderClassComboBox = new System.Windows.Forms.ComboBox();
            this.orderProgressComboBox = new System.Windows.Forms.ComboBox();
            this.orderStartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.orderEndComboBox = new System.Windows.Forms.ComboBox();
            this.orderEndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.orderTimeLabel2 = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.orderSesrchButton = new System.Windows.Forms.Button();
            this.orderEndLabel = new System.Windows.Forms.Label();
            this.orderTimeLabel1 = new System.Windows.Forms.Label();
            this.orderClassLabel = new System.Windows.Forms.Label();
            this.orderTimeLabel = new System.Windows.Forms.Label();
            this.orderAddButton = new System.Windows.Forms.Button();
            this.orderRefreshButton = new System.Windows.Forms.Button();
            this.orderDeliverButton = new System.Windows.Forms.Button();
            this.orderReturnButton = new System.Windows.Forms.Button();
            this.orderCheckButton = new System.Windows.Forms.Button();
            this.searchTabPage = new System.Windows.Forms.TabPage();
            this.appHelpButton = new System.Windows.Forms.Button();
            this.homeMenuPanel = new System.Windows.Forms.Panel();
            this.sqlUpDataButton = new System.Windows.Forms.Button();
            this.appSettingsButton = new System.Windows.Forms.Button();
            this.diskMappingButton = new System.Windows.Forms.Button();
            this.filesSortButton = new System.Windows.Forms.Button();
            this.messageFormButton = new System.Windows.Forms.Button();
            this.searchBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.orderContextMenuStrip.SuspendLayout();
            this.homeStatusStrip.SuspendLayout();
            this.homeMenuStrip.SuspendLayout();
            this.homeTabControl.SuspendLayout();
            this.orderTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderListTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // orderContextMenuStrip
            // 
            this.orderContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderRefreshMenuItem,
            this.orderCopyMenuItem,
            this.toolStripSeparator2,
            this.orderAddMenuItem,
            this.orderDeliverMenuItem,
            this.orderCheckMenuItem,
            this.orderReturnMenuItem,
            this.toolStripSeparator3,
            this.orderModifyMenuItem,
            this.orderCancelMenuItem,
            this.orderDeleteMenuItem,
            this.toolStripSeparator1,
            this.orderFilesMenuItem,
            this.orderDetailsMenuItem});
            this.orderContextMenuStrip.Name = "orderContextMenuStrip";
            this.orderContextMenuStrip.Size = new System.Drawing.Size(191, 286);
            this.orderContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.orderContextMenuStrip_Opening);
            // 
            // orderRefreshMenuItem
            // 
            this.orderRefreshMenuItem.Name = "orderRefreshMenuItem";
            this.orderRefreshMenuItem.Size = new System.Drawing.Size(190, 22);
            this.orderRefreshMenuItem.Text = "刷新列表 (F5)";
            this.orderRefreshMenuItem.Click += new System.EventHandler(this.orderRefreshMenuItem_Click);
            // 
            // orderFilesMenuItem
            // 
            this.orderFilesMenuItem.Name = "orderFilesMenuItem";
            this.orderFilesMenuItem.Size = new System.Drawing.Size(190, 22);
            this.orderFilesMenuItem.Text = "订单文件";
            // 
            // orderCopyMenuItem
            // 
            this.orderCopyMenuItem.Name = "orderCopyMenuItem";
            this.orderCopyMenuItem.Size = new System.Drawing.Size(190, 22);
            this.orderCopyMenuItem.Text = "复制";
            this.orderCopyMenuItem.Click += new System.EventHandler(this.orderCopyMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(187, 6);
            // 
            // orderAddMenuItem
            // 
            this.orderAddMenuItem.Name = "orderAddMenuItem";
            this.orderAddMenuItem.Size = new System.Drawing.Size(190, 22);
            this.orderAddMenuItem.Text = "接带";
            this.orderAddMenuItem.Click += new System.EventHandler(this.orderAddMenuItem_Click);
            // 
            // orderDeliverMenuItem
            // 
            this.orderDeliverMenuItem.Name = "orderDeliverMenuItem";
            this.orderDeliverMenuItem.Size = new System.Drawing.Size(190, 22);
            this.orderDeliverMenuItem.Text = "分带";
            this.orderDeliverMenuItem.Click += new System.EventHandler(this.orderDeliverMenuItem_Click);
            // 
            // orderCheckMenuItem
            // 
            this.orderCheckMenuItem.Name = "orderCheckMenuItem";
            this.orderCheckMenuItem.Size = new System.Drawing.Size(190, 22);
            this.orderCheckMenuItem.Text = "检查 (Ctrl+Enter)";
            this.orderCheckMenuItem.Click += new System.EventHandler(this.orderCheckMenuItem_Click);
            // 
            // orderReturnMenuItem
            // 
            this.orderReturnMenuItem.Name = "orderReturnMenuItem";
            this.orderReturnMenuItem.Size = new System.Drawing.Size(190, 22);
            this.orderReturnMenuItem.Text = "发带";
            this.orderReturnMenuItem.Click += new System.EventHandler(this.orderReturnMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(187, 6);
            // 
            // orderModifyMenuItem
            // 
            this.orderModifyMenuItem.Name = "orderModifyMenuItem";
            this.orderModifyMenuItem.Size = new System.Drawing.Size(190, 22);
            this.orderModifyMenuItem.Text = "修改订单";
            this.orderModifyMenuItem.Click += new System.EventHandler(this.orderModifyMenuItem_Click);
            // 
            // orderCancelMenuItem
            // 
            this.orderCancelMenuItem.Name = "orderCancelMenuItem";
            this.orderCancelMenuItem.Size = new System.Drawing.Size(190, 22);
            this.orderCancelMenuItem.Text = "取消订单";
            this.orderCancelMenuItem.Click += new System.EventHandler(this.orderCancelMenuItem_Click);
            // 
            // orderDeleteMenuItem
            // 
            this.orderDeleteMenuItem.Name = "orderDeleteMenuItem";
            this.orderDeleteMenuItem.Size = new System.Drawing.Size(190, 22);
            this.orderDeleteMenuItem.Text = "删除订单";
            this.orderDeleteMenuItem.Click += new System.EventHandler(this.orderDeleteMenuItem_Click);
            // 
            // orderDetailsMenuItem
            // 
            this.orderDetailsMenuItem.Name = "orderDetailsMenuItem";
            this.orderDetailsMenuItem.Size = new System.Drawing.Size(190, 22);
            this.orderDetailsMenuItem.Text = "订单详细信息 (Enter)";
            this.orderDetailsMenuItem.Click += new System.EventHandler(this.orderDetailsMenuItem_Click);
            // 
            // homeStatusStrip
            // 
            this.homeStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeProgressBar,
            this.homeStatusLabel});
            this.homeStatusStrip.Location = new System.Drawing.Point(0, 739);
            this.homeStatusStrip.Name = "homeStatusStrip";
            this.homeStatusStrip.Size = new System.Drawing.Size(1184, 22);
            this.homeStatusStrip.TabIndex = 1;
            this.homeStatusStrip.Text = "homeStatusStrip";
            // 
            // homeProgressBar
            // 
            this.homeProgressBar.Name = "homeProgressBar";
            this.homeProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // homeStatusLabel
            // 
            this.homeStatusLabel.Name = "homeStatusLabel";
            this.homeStatusLabel.Size = new System.Drawing.Size(80, 17);
            this.homeStatusLabel.Text = "等待用户操作";
            // 
            // homeMenuStrip
            // 
            this.homeMenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.homeMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userMenuItem,
            this.toolsMenuItem,
            this.appHelpMenuItem});
            this.homeMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.homeMenuStrip.Name = "homeMenuStrip";
            this.homeMenuStrip.Size = new System.Drawing.Size(1184, 25);
            this.homeMenuStrip.TabIndex = 2;
            this.homeMenuStrip.Text = "homeMenuStrip";
            // 
            // userMenuItem
            // 
            this.userMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userProfileMenuItem,
            this.appExitMenuItem});
            this.userMenuItem.Name = "userMenuItem";
            this.userMenuItem.Size = new System.Drawing.Size(61, 21);
            this.userMenuItem.Text = "用户(U)";
            // 
            // userProfileMenuItem
            // 
            this.userProfileMenuItem.Name = "userProfileMenuItem";
            this.userProfileMenuItem.Size = new System.Drawing.Size(139, 22);
            this.userProfileMenuItem.Text = "个人资料(P)";
            this.userProfileMenuItem.Click += new System.EventHandler(this.userProfileMenuItem_Click);
            // 
            // appExitMenuItem
            // 
            this.appExitMenuItem.Name = "appExitMenuItem";
            this.appExitMenuItem.Size = new System.Drawing.Size(139, 22);
            this.appExitMenuItem.Text = "退出(E)";
            this.appExitMenuItem.Click += new System.EventHandler(this.appExitMenuItem_Click);
            // 
            // toolsMenuItem
            // 
            this.toolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diskMappingMenuItem,
            this.filesSortMenuItem,
            this.userManageMenuItem,
            this.appSettingsMenuItem});
            this.toolsMenuItem.Name = "toolsMenuItem";
            this.toolsMenuItem.Size = new System.Drawing.Size(59, 21);
            this.toolsMenuItem.Text = "工具(T)";
            // 
            // diskMappingMenuItem
            // 
            this.diskMappingMenuItem.Name = "diskMappingMenuItem";
            this.diskMappingMenuItem.Size = new System.Drawing.Size(148, 22);
            this.diskMappingMenuItem.Text = "磁盘映射助手";
            this.diskMappingMenuItem.Click += new System.EventHandler(this.diskMappingMenuItem_Click);
            // 
            // filesSortMenuItem
            // 
            this.filesSortMenuItem.Name = "filesSortMenuItem";
            this.filesSortMenuItem.Size = new System.Drawing.Size(148, 22);
            this.filesSortMenuItem.Text = "文件整理(F)";
            this.filesSortMenuItem.Click += new System.EventHandler(this.filesSortMenuItem_Click);
            // 
            // userManageMenuItem
            // 
            this.userManageMenuItem.Name = "userManageMenuItem";
            this.userManageMenuItem.Size = new System.Drawing.Size(148, 22);
            this.userManageMenuItem.Text = "用户管理(U)";
            this.userManageMenuItem.Click += new System.EventHandler(this.userManageMenuItem_Click);
            // 
            // appSettingsMenuItem
            // 
            this.appSettingsMenuItem.Name = "appSettingsMenuItem";
            this.appSettingsMenuItem.Size = new System.Drawing.Size(148, 22);
            this.appSettingsMenuItem.Text = "选项(S)";
            this.appSettingsMenuItem.Click += new System.EventHandler(this.appSettingsMenuItem_Click);
            // 
            // appHelpMenuItem
            // 
            this.appHelpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appViewHelpMenuItem,
            this.developerMenuItem,
            this.appUpMenuItem,
            this.appAboutMenuItem});
            this.appHelpMenuItem.Name = "appHelpMenuItem";
            this.appHelpMenuItem.Size = new System.Drawing.Size(61, 21);
            this.appHelpMenuItem.Text = "帮助(H)";
            // 
            // appViewHelpMenuItem
            // 
            this.appViewHelpMenuItem.Name = "appViewHelpMenuItem";
            this.appViewHelpMenuItem.Size = new System.Drawing.Size(153, 22);
            this.appViewHelpMenuItem.Text = "查看帮助(V)";
            this.appViewHelpMenuItem.Click += new System.EventHandler(this.appViewHelpMenuItem_Click);
            // 
            // developerMenuItem
            // 
            this.developerMenuItem.Name = "developerMenuItem";
            this.developerMenuItem.Size = new System.Drawing.Size(153, 22);
            this.developerMenuItem.Text = "技术支持(T)";
            this.developerMenuItem.Click += new System.EventHandler(this.developerMenuItem_Click);
            // 
            // appUpMenuItem
            // 
            this.appUpMenuItem.Name = "appUpMenuItem";
            this.appUpMenuItem.Size = new System.Drawing.Size(153, 22);
            this.appUpMenuItem.Text = "获取新版本(U)";
            this.appUpMenuItem.Click += new System.EventHandler(this.appUpMenuItem_Click);
            // 
            // appAboutMenuItem
            // 
            this.appAboutMenuItem.Name = "appAboutMenuItem";
            this.appAboutMenuItem.Size = new System.Drawing.Size(153, 22);
            this.appAboutMenuItem.Text = "关于TDS2(A)";
            this.appAboutMenuItem.Click += new System.EventHandler(this.appAboutMenuItem_Click);
            // 
            // orderListView
            // 
            this.orderListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderListView.ContextMenuStrip = this.orderContextMenuStrip;
            this.orderListView.FullRowSelect = true;
            this.orderListView.GridLines = true;
            this.orderListView.Location = new System.Drawing.Point(-4, 35);
            this.orderListView.MultiSelect = false;
            this.orderListView.Name = "orderListView";
            this.orderListView.Size = new System.Drawing.Size(1186, 543);
            this.orderListView.TabIndex = 4;
            this.orderListView.UseCompatibleStateImageBehavior = false;
            this.orderListView.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.orderListView_ItemMouseHover);
            this.orderListView.SelectedIndexChanged += new System.EventHandler(this.orderListView_SelectedIndexChanged);
            this.orderListView.DoubleClick += new System.EventHandler(this.orderListView_DoubleClick);
            this.orderListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.orderListView_KeyDown);
            this.orderListView.MouseHover += new System.EventHandler(this.orderListView_MouseHover);
            // 
            // homeTabControl
            // 
            this.homeTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.homeTabControl.Controls.Add(this.orderTabPage);
            this.homeTabControl.Controls.Add(this.searchTabPage);
            this.homeTabControl.Location = new System.Drawing.Point(-1, 97);
            this.homeTabControl.Name = "homeTabControl";
            this.homeTabControl.SelectedIndex = 0;
            this.homeTabControl.Size = new System.Drawing.Size(1187, 644);
            this.homeTabControl.TabIndex = 5;
            // 
            // orderTabPage
            // 
            this.orderTabPage.Controls.Add(this.orderZButton);
            this.orderTabPage.Controls.Add(this.orderEButton);
            this.orderTabPage.Controls.Add(this.orderListTrackBar);
            this.orderTabPage.Controls.Add(this.thumbnailComboBox);
            this.orderTabPage.Controls.Add(this.panel3);
            this.orderTabPage.Controls.Add(this.panel2);
            this.orderTabPage.Controls.Add(this.panel1);
            this.orderTabPage.Controls.Add(this.orderClassComboBox);
            this.orderTabPage.Controls.Add(this.orderProgressComboBox);
            this.orderTabPage.Controls.Add(this.orderStartDateTimePicker);
            this.orderTabPage.Controls.Add(this.orderEndComboBox);
            this.orderTabPage.Controls.Add(this.orderEndDateTimePicker);
            this.orderTabPage.Controls.Add(this.orderTimeLabel2);
            this.orderTabPage.Controls.Add(this.searchTextBox);
            this.orderTabPage.Controls.Add(this.orderSesrchButton);
            this.orderTabPage.Controls.Add(this.orderEndLabel);
            this.orderTabPage.Controls.Add(this.orderTimeLabel1);
            this.orderTabPage.Controls.Add(this.orderClassLabel);
            this.orderTabPage.Controls.Add(this.orderTimeLabel);
            this.orderTabPage.Controls.Add(this.orderAddButton);
            this.orderTabPage.Controls.Add(this.orderRefreshButton);
            this.orderTabPage.Controls.Add(this.orderListView);
            this.orderTabPage.Controls.Add(this.orderDeliverButton);
            this.orderTabPage.Controls.Add(this.orderReturnButton);
            this.orderTabPage.Controls.Add(this.orderCheckButton);
            this.orderTabPage.Location = new System.Drawing.Point(4, 26);
            this.orderTabPage.Name = "orderTabPage";
            this.orderTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.orderTabPage.Size = new System.Drawing.Size(1179, 614);
            this.orderTabPage.TabIndex = 0;
            this.orderTabPage.Text = " 订单页  ";
            this.orderTabPage.UseVisualStyleBackColor = true;
            // 
            // orderZButton
            // 
            this.orderZButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.orderZButton.Location = new System.Drawing.Point(911, 584);
            this.orderZButton.Name = "orderZButton";
            this.orderZButton.Size = new System.Drawing.Size(60, 23);
            this.orderZButton.TabIndex = 53;
            this.orderZButton.Text = "打版";
            this.orderZButton.UseVisualStyleBackColor = true;
            this.orderZButton.Click += new System.EventHandler(this.orderZButton_Click);
            // 
            // orderEButton
            // 
            this.orderEButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.orderEButton.Location = new System.Drawing.Point(977, 584);
            this.orderEButton.Name = "orderEButton";
            this.orderEButton.Size = new System.Drawing.Size(60, 23);
            this.orderEButton.TabIndex = 52;
            this.orderEButton.Text = "车版";
            this.orderEButton.UseVisualStyleBackColor = true;
            this.orderEButton.Click += new System.EventHandler(this.orderEButton_Click);
            // 
            // orderListTrackBar
            // 
            this.orderListTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.orderListTrackBar.BackColor = System.Drawing.SystemColors.Window;
            this.orderListTrackBar.Location = new System.Drawing.Point(89, 584);
            this.orderListTrackBar.Maximum = 7;
            this.orderListTrackBar.Name = "orderListTrackBar";
            this.orderListTrackBar.Size = new System.Drawing.Size(104, 45);
            this.orderListTrackBar.TabIndex = 36;
            this.orderListTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.orderListTrackBar.Value = 2;
            this.orderListTrackBar.Scroll += new System.EventHandler(this.orderListTrackBar_Scroll);
            // 
            // thumbnailComboBox
            // 
            this.thumbnailComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.thumbnailComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thumbnailComboBox.FormattingEnabled = true;
            this.thumbnailComboBox.Items.AddRange(new object[] {
            "缩略图",
            "表格"});
            this.thumbnailComboBox.Location = new System.Drawing.Point(6, 583);
            this.thumbnailComboBox.Name = "thumbnailComboBox";
            this.thumbnailComboBox.Size = new System.Drawing.Size(80, 25);
            this.thumbnailComboBox.TabIndex = 51;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Location = new System.Drawing.Point(719, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 23);
            this.panel3.TabIndex = 50;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(537, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 23);
            this.panel2.TabIndex = 49;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(375, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 23);
            this.panel1.TabIndex = 48;
            // 
            // orderClassComboBox
            // 
            this.orderClassComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orderClassComboBox.FormattingEnabled = true;
            this.orderClassComboBox.Items.AddRange(new object[] {
            "全部",
            "新带",
            "收费改带",
            "免费改带",
            "估针",
            "试打版",
            "等回复",
            "矢量新图",
            "矢量报价"});
            this.orderClassComboBox.Location = new System.Drawing.Point(606, 5);
            this.orderClassComboBox.Name = "orderClassComboBox";
            this.orderClassComboBox.Size = new System.Drawing.Size(100, 25);
            this.orderClassComboBox.TabIndex = 47;
            // 
            // orderProgressComboBox
            // 
            this.orderProgressComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orderProgressComboBox.FormattingEnabled = true;
            this.orderProgressComboBox.Items.AddRange(new object[] {
            "全部",
            "已发带",
            "已取消",
            "待分带",
            "待打版",
            "待做图",
            "待车版",
            "待扫描",
            "待发带"});
            this.orderProgressComboBox.Location = new System.Drawing.Point(444, 5);
            this.orderProgressComboBox.Name = "orderProgressComboBox";
            this.orderProgressComboBox.Size = new System.Drawing.Size(80, 25);
            this.orderProgressComboBox.TabIndex = 46;
            // 
            // orderStartDateTimePicker
            // 
            this.orderStartDateTimePicker.Location = new System.Drawing.Point(63, 6);
            this.orderStartDateTimePicker.Name = "orderStartDateTimePicker";
            this.orderStartDateTimePicker.Size = new System.Drawing.Size(135, 23);
            this.orderStartDateTimePicker.TabIndex = 11;
            this.orderStartDateTimePicker.CloseUp += new System.EventHandler(this.orderStartDateTimePicker_CloseUp);
            // 
            // orderEndComboBox
            // 
            this.orderEndComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orderEndComboBox.FormattingEnabled = true;
            this.orderEndComboBox.Items.AddRange(new object[] {
            "全部",
            "急改 - 30分钟内",
            "估针 - 1小时内",
            "改带 - 1小时内",
            "特急 - 1小时内",
            "紧急 - 5小时内",
            "一般 - 17:00前",
            "正常 - 24小时内",
            "长时 - 2至3天",
            "超长时 - 4至6天"});
            this.orderEndComboBox.Location = new System.Drawing.Point(775, 5);
            this.orderEndComboBox.Name = "orderEndComboBox";
            this.orderEndComboBox.Size = new System.Drawing.Size(120, 25);
            this.orderEndComboBox.TabIndex = 45;
            // 
            // orderEndDateTimePicker
            // 
            this.orderEndDateTimePicker.Checked = false;
            this.orderEndDateTimePicker.Location = new System.Drawing.Point(226, 6);
            this.orderEndDateTimePicker.Name = "orderEndDateTimePicker";
            this.orderEndDateTimePicker.Size = new System.Drawing.Size(135, 23);
            this.orderEndDateTimePicker.TabIndex = 12;
            this.orderEndDateTimePicker.CloseUp += new System.EventHandler(this.orderEndDateTimePicker_CloseUp);
            // 
            // orderTimeLabel2
            // 
            this.orderTimeLabel2.AutoSize = true;
            this.orderTimeLabel2.Location = new System.Drawing.Point(202, 9);
            this.orderTimeLabel2.Name = "orderTimeLabel2";
            this.orderTimeLabel2.Size = new System.Drawing.Size(20, 17);
            this.orderTimeLabel2.TabIndex = 14;
            this.orderTimeLabel2.Text = "到";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchTextBox.Location = new System.Drawing.Point(304, 584);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(120, 23);
            this.searchTextBox.TabIndex = 16;
            this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyDown);
            // 
            // orderSesrchButton
            // 
            this.orderSesrchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.orderSesrchButton.Location = new System.Drawing.Point(430, 585);
            this.orderSesrchButton.Name = "orderSesrchButton";
            this.orderSesrchButton.Size = new System.Drawing.Size(60, 23);
            this.orderSesrchButton.TabIndex = 15;
            this.orderSesrchButton.Text = "搜索";
            this.orderSesrchButton.UseVisualStyleBackColor = true;
            this.orderSesrchButton.Click += new System.EventHandler(this.orderSesrchButton_Click);
            // 
            // orderEndLabel
            // 
            this.orderEndLabel.AutoSize = true;
            this.orderEndLabel.Location = new System.Drawing.Point(728, 9);
            this.orderEndLabel.Name = "orderEndLabel";
            this.orderEndLabel.Size = new System.Drawing.Size(44, 17);
            this.orderEndLabel.TabIndex = 26;
            this.orderEndLabel.Text = "紧急度";
            // 
            // orderTimeLabel1
            // 
            this.orderTimeLabel1.AutoSize = true;
            this.orderTimeLabel1.Location = new System.Drawing.Point(4, 9);
            this.orderTimeLabel1.Name = "orderTimeLabel1";
            this.orderTimeLabel1.Size = new System.Drawing.Size(56, 17);
            this.orderTimeLabel1.TabIndex = 13;
            this.orderTimeLabel1.Text = "接带时间";
            // 
            // orderClassLabel
            // 
            this.orderClassLabel.AutoSize = true;
            this.orderClassLabel.Location = new System.Drawing.Point(547, 9);
            this.orderClassLabel.Name = "orderClassLabel";
            this.orderClassLabel.Size = new System.Drawing.Size(56, 17);
            this.orderClassLabel.TabIndex = 26;
            this.orderClassLabel.Text = "带子分类";
            // 
            // orderTimeLabel
            // 
            this.orderTimeLabel.AutoSize = true;
            this.orderTimeLabel.Location = new System.Drawing.Point(385, 9);
            this.orderTimeLabel.Name = "orderTimeLabel";
            this.orderTimeLabel.Size = new System.Drawing.Size(56, 17);
            this.orderTimeLabel.TabIndex = 36;
            this.orderTimeLabel.Text = "带子进度";
            // 
            // orderAddButton
            // 
            this.orderAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.orderAddButton.Location = new System.Drawing.Point(779, 584);
            this.orderAddButton.Name = "orderAddButton";
            this.orderAddButton.Size = new System.Drawing.Size(60, 23);
            this.orderAddButton.TabIndex = 31;
            this.orderAddButton.Text = "接带";
            this.orderAddButton.UseVisualStyleBackColor = true;
            this.orderAddButton.Click += new System.EventHandler(this.orderAddButton_Click);
            // 
            // orderRefreshButton
            // 
            this.orderRefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.orderRefreshButton.Location = new System.Drawing.Point(198, 584);
            this.orderRefreshButton.Name = "orderRefreshButton";
            this.orderRefreshButton.Size = new System.Drawing.Size(100, 23);
            this.orderRefreshButton.TabIndex = 30;
            this.orderRefreshButton.Text = "刷新列表 (F5)";
            this.orderRefreshButton.UseVisualStyleBackColor = true;
            this.orderRefreshButton.Click += new System.EventHandler(this.orderRefreshButton_Click);
            // 
            // orderDeliverButton
            // 
            this.orderDeliverButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.orderDeliverButton.Location = new System.Drawing.Point(845, 584);
            this.orderDeliverButton.Name = "orderDeliverButton";
            this.orderDeliverButton.Size = new System.Drawing.Size(60, 23);
            this.orderDeliverButton.TabIndex = 21;
            this.orderDeliverButton.Text = "分带";
            this.orderDeliverButton.UseVisualStyleBackColor = true;
            this.orderDeliverButton.Click += new System.EventHandler(this.orderDeliverButton_Click);
            // 
            // orderReturnButton
            // 
            this.orderReturnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.orderReturnButton.Location = new System.Drawing.Point(1109, 584);
            this.orderReturnButton.Name = "orderReturnButton";
            this.orderReturnButton.Size = new System.Drawing.Size(60, 23);
            this.orderReturnButton.TabIndex = 22;
            this.orderReturnButton.Text = "发带";
            this.orderReturnButton.UseVisualStyleBackColor = true;
            this.orderReturnButton.Click += new System.EventHandler(this.orderReturnButton_Click);
            // 
            // orderCheckButton
            // 
            this.orderCheckButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.orderCheckButton.Location = new System.Drawing.Point(1043, 584);
            this.orderCheckButton.Name = "orderCheckButton";
            this.orderCheckButton.Size = new System.Drawing.Size(60, 23);
            this.orderCheckButton.TabIndex = 23;
            this.orderCheckButton.Text = "检查";
            this.orderCheckButton.UseVisualStyleBackColor = true;
            this.orderCheckButton.Click += new System.EventHandler(this.orderCheckButton_Click);
            // 
            // searchTabPage
            // 
            this.searchTabPage.Location = new System.Drawing.Point(4, 26);
            this.searchTabPage.Name = "searchTabPage";
            this.searchTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.searchTabPage.Size = new System.Drawing.Size(1179, 614);
            this.searchTabPage.TabIndex = 1;
            this.searchTabPage.Text = " 高级搜索   ";
            this.searchTabPage.UseVisualStyleBackColor = true;
            // 
            // appHelpButton
            // 
            this.appHelpButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.appHelpButton.Location = new System.Drawing.Point(297, 31);
            this.appHelpButton.Name = "appHelpButton";
            this.appHelpButton.Size = new System.Drawing.Size(60, 60);
            this.appHelpButton.TabIndex = 25;
            this.appHelpButton.Text = "帮助";
            this.appHelpButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.appHelpButton.UseVisualStyleBackColor = true;
            this.appHelpButton.Click += new System.EventHandler(this.appHelpButton_Click);
            // 
            // homeMenuPanel
            // 
            this.homeMenuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.homeMenuPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.homeMenuPanel.Location = new System.Drawing.Point(-5, 24);
            this.homeMenuPanel.Name = "homeMenuPanel";
            this.homeMenuPanel.Size = new System.Drawing.Size(1200, 1);
            this.homeMenuPanel.TabIndex = 25;
            // 
            // sqlUpDataButton
            // 
            this.sqlUpDataButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.sqlUpDataButton.Location = new System.Drawing.Point(7, 31);
            this.sqlUpDataButton.Name = "sqlUpDataButton";
            this.sqlUpDataButton.Size = new System.Drawing.Size(70, 60);
            this.sqlUpDataButton.TabIndex = 26;
            this.sqlUpDataButton.Text = "更新数据";
            this.sqlUpDataButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sqlUpDataButton.UseVisualStyleBackColor = true;
            this.sqlUpDataButton.Click += new System.EventHandler(this.sqlUpDataButton_Click);
            // 
            // appSettingsButton
            // 
            this.appSettingsButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.appSettingsButton.Location = new System.Drawing.Point(232, 31);
            this.appSettingsButton.Name = "appSettingsButton";
            this.appSettingsButton.Size = new System.Drawing.Size(60, 60);
            this.appSettingsButton.TabIndex = 34;
            this.appSettingsButton.Text = "选项";
            this.appSettingsButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.appSettingsButton.UseVisualStyleBackColor = true;
            this.appSettingsButton.Click += new System.EventHandler(this.appSettingsButton_Click);
            // 
            // diskMappingButton
            // 
            this.diskMappingButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.diskMappingButton.Location = new System.Drawing.Point(157, 31);
            this.diskMappingButton.Name = "diskMappingButton";
            this.diskMappingButton.Size = new System.Drawing.Size(70, 60);
            this.diskMappingButton.TabIndex = 33;
            this.diskMappingButton.Text = "磁盘映射";
            this.diskMappingButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.diskMappingButton.UseVisualStyleBackColor = true;
            this.diskMappingButton.Click += new System.EventHandler(this.diskMappingButton_Click);
            // 
            // filesSortButton
            // 
            this.filesSortButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.filesSortButton.Location = new System.Drawing.Point(82, 31);
            this.filesSortButton.Name = "filesSortButton";
            this.filesSortButton.Size = new System.Drawing.Size(70, 60);
            this.filesSortButton.TabIndex = 32;
            this.filesSortButton.Text = "文件整理";
            this.filesSortButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.filesSortButton.UseVisualStyleBackColor = true;
            this.filesSortButton.Click += new System.EventHandler(this.filesSortButton_Click);
            // 
            // messageFormButton
            // 
            this.messageFormButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.messageFormButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.messageFormButton.Location = new System.Drawing.Point(1118, 31);
            this.messageFormButton.Name = "messageFormButton";
            this.messageFormButton.Size = new System.Drawing.Size(60, 60);
            this.messageFormButton.TabIndex = 35;
            this.messageFormButton.Text = "消息";
            this.messageFormButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.messageFormButton.UseVisualStyleBackColor = true;
            this.messageFormButton.Click += new System.EventHandler(this.messageFormButton_Click);
            // 
            // searchBackgroundWorker
            // 
            this.searchBackgroundWorker.WorkerReportsProgress = true;
            this.searchBackgroundWorker.WorkerSupportsCancellation = true;
            this.searchBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.searchBackgroundWorker_DoWork);
            this.searchBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.searchBackgroundWorker_ProgressChanged);
            this.searchBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.searchBackgroundWorker_RunWorkerCompleted);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.messageFormButton);
            this.Controls.Add(this.appSettingsButton);
            this.Controls.Add(this.diskMappingButton);
            this.Controls.Add(this.filesSortButton);
            this.Controls.Add(this.sqlUpDataButton);
            this.Controls.Add(this.homeMenuPanel);
            this.Controls.Add(this.homeStatusStrip);
            this.Controls.Add(this.appHelpButton);
            this.Controls.Add(this.homeTabControl);
            this.Controls.Add(this.homeMenuStrip);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.homeMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1080, 768);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HomeForm_FormClosing);
            this.Shown += new System.EventHandler(this.HomeForm_Shown);
            this.orderContextMenuStrip.ResumeLayout(false);
            this.homeStatusStrip.ResumeLayout(false);
            this.homeStatusStrip.PerformLayout();
            this.homeMenuStrip.ResumeLayout(false);
            this.homeMenuStrip.PerformLayout();
            this.homeTabControl.ResumeLayout(false);
            this.orderTabPage.ResumeLayout(false);
            this.orderTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderListTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip orderContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem orderRefreshMenuItem;
        private System.Windows.Forms.StatusStrip homeStatusStrip;
        private System.Windows.Forms.ListView orderListView;
        private System.Windows.Forms.TabControl homeTabControl;
        private System.Windows.Forms.TabPage orderTabPage;
        private System.Windows.Forms.ToolStripMenuItem userMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userProfileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filesSortMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appSettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appHelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appViewHelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem developerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appAboutMenuItem;
        private System.Windows.Forms.ToolStripProgressBar homeProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel homeStatusLabel;
        private System.Windows.Forms.DateTimePicker orderStartDateTimePicker;
        private System.Windows.Forms.Label orderTimeLabel2;
        private System.Windows.Forms.Label orderTimeLabel1;
        private System.Windows.Forms.DateTimePicker orderEndDateTimePicker;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button orderSesrchButton;
        private System.Windows.Forms.Button appHelpButton;
        private System.Windows.Forms.Button orderCheckButton;
        private System.Windows.Forms.Button orderReturnButton;
        private System.Windows.Forms.Button orderDeliverButton;
        private System.Windows.Forms.ToolStripMenuItem diskMappingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appUpMenuItem;
        private System.Windows.Forms.Label orderClassLabel;
        private System.Windows.Forms.Panel homeMenuPanel;
        private System.Windows.Forms.Button sqlUpDataButton;
        private System.Windows.Forms.Button orderRefreshButton;
        private System.Windows.Forms.Button appSettingsButton;
        private System.Windows.Forms.Button orderAddButton;
        private System.Windows.Forms.Button diskMappingButton;
        private System.Windows.Forms.Button filesSortButton;
        private System.Windows.Forms.Button messageFormButton;
        private System.Windows.Forms.ToolStripMenuItem orderFilesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderDeleteMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem orderAddMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderCheckMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderDeliverMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderReturnMenuItem;
        private System.Windows.Forms.Label orderTimeLabel;
        private System.Windows.Forms.ToolStripMenuItem orderDetailsMenuItem;
        private System.Windows.Forms.TabPage searchTabPage;
        private System.Windows.Forms.ToolStripMenuItem orderModifyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderCancelMenuItem;
        private System.ComponentModel.BackgroundWorker searchBackgroundWorker;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label orderEndLabel;
        private System.Windows.Forms.ComboBox orderClassComboBox;
        private System.Windows.Forms.ComboBox orderProgressComboBox;
        private System.Windows.Forms.ComboBox orderEndComboBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox thumbnailComboBox;
        private System.Windows.Forms.TrackBar orderListTrackBar;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.MenuStrip homeMenuStrip;
        private System.Windows.Forms.Button orderEButton;
        private System.Windows.Forms.Button orderZButton;
        private System.Windows.Forms.ToolStripMenuItem orderCopyMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}