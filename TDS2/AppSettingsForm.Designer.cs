namespace TDS2
{
    partial class AppSettingsForm
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
            this.appUpTabPage = new System.Windows.Forms.TabPage();
            this.appUpTextBox = new System.Windows.Forms.TextBox();
            this.appUpPathLabel = new System.Windows.Forms.Label();
            this.appUpButton = new System.Windows.Forms.Button();
            this.appAutoUpCheckBox = new System.Windows.Forms.CheckBox();
            this.filesOpenTabPage = new System.Windows.Forms.TabPage();
            this.aiFileCheckBox = new System.Windows.Forms.CheckBox();
            this.jpgFileCheckBox = new System.Windows.Forms.CheckBox();
            this.embFileCheckBox = new System.Windows.Forms.CheckBox();
            this.dstFileCheckBox = new System.Windows.Forms.CheckBox();
            this.aiFileButton = new System.Windows.Forms.Button();
            this.aiFileLabel = new System.Windows.Forms.Label();
            this.aiFileTextBox = new System.Windows.Forms.TextBox();
            this.jpgFileButton = new System.Windows.Forms.Button();
            this.embFileButton = new System.Windows.Forms.Button();
            this.dstFileButton = new System.Windows.Forms.Button();
            this.jpgFileLabel = new System.Windows.Forms.Label();
            this.dstFileTextBox = new System.Windows.Forms.TextBox();
            this.jpgFileTextBox = new System.Windows.Forms.TextBox();
            this.embFileTextBox = new System.Windows.Forms.TextBox();
            this.dstFileLabel = new System.Windows.Forms.Label();
            this.embFileLabel = new System.Windows.Forms.Label();
            this.settingsTabControl = new System.Windows.Forms.TabControl();
            this.sqlTabPage = new System.Windows.Forms.TabPage();
            this.sqlServerIPTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.sqlDataNameTextBox = new System.Windows.Forms.TextBox();
            this.sqlUserIDTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.sqlPasswordTextBox = new System.Windows.Forms.TextBox();
            this.autoTabPage = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.disksCancelButton = new System.Windows.Forms.Button();
            this.disksSaveButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.appUpTabPage.SuspendLayout();
            this.filesOpenTabPage.SuspendLayout();
            this.settingsTabControl.SuspendLayout();
            this.sqlTabPage.SuspendLayout();
            this.autoTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // appUpTabPage
            // 
            this.appUpTabPage.Controls.Add(this.appUpTextBox);
            this.appUpTabPage.Controls.Add(this.appUpPathLabel);
            this.appUpTabPage.Controls.Add(this.appUpButton);
            this.appUpTabPage.Controls.Add(this.appAutoUpCheckBox);
            this.appUpTabPage.Location = new System.Drawing.Point(4, 26);
            this.appUpTabPage.Name = "appUpTabPage";
            this.appUpTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.appUpTabPage.Size = new System.Drawing.Size(638, 291);
            this.appUpTabPage.TabIndex = 2;
            this.appUpTabPage.Text = " 程序更新 ";
            this.appUpTabPage.UseVisualStyleBackColor = true;
            // 
            // appUpTextBox
            // 
            this.appUpTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appUpTextBox.Location = new System.Drawing.Point(70, 9);
            this.appUpTextBox.Name = "appUpTextBox";
            this.appUpTextBox.Size = new System.Drawing.Size(492, 23);
            this.appUpTextBox.TabIndex = 3;
            // 
            // appUpPathLabel
            // 
            this.appUpPathLabel.AutoSize = true;
            this.appUpPathLabel.Location = new System.Drawing.Point(8, 12);
            this.appUpPathLabel.Name = "appUpPathLabel";
            this.appUpPathLabel.Size = new System.Drawing.Size(56, 17);
            this.appUpPathLabel.TabIndex = 2;
            this.appUpPathLabel.Text = "更新地址";
            // 
            // appUpButton
            // 
            this.appUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.appUpButton.Location = new System.Drawing.Point(568, 9);
            this.appUpButton.Name = "appUpButton";
            this.appUpButton.Size = new System.Drawing.Size(60, 23);
            this.appUpButton.TabIndex = 1;
            this.appUpButton.Text = "浏览";
            this.appUpButton.UseVisualStyleBackColor = true;
            this.appUpButton.Click += new System.EventHandler(this.appUpButton_Click);
            // 
            // appAutoUpCheckBox
            // 
            this.appAutoUpCheckBox.AutoSize = true;
            this.appAutoUpCheckBox.Checked = true;
            this.appAutoUpCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.appAutoUpCheckBox.Location = new System.Drawing.Point(11, 38);
            this.appAutoUpCheckBox.Name = "appAutoUpCheckBox";
            this.appAutoUpCheckBox.Size = new System.Drawing.Size(111, 21);
            this.appAutoUpCheckBox.TabIndex = 0;
            this.appAutoUpCheckBox.Text = "登陆时检查更新";
            this.appAutoUpCheckBox.UseVisualStyleBackColor = true;
            // 
            // filesOpenTabPage
            // 
            this.filesOpenTabPage.Controls.Add(this.aiFileCheckBox);
            this.filesOpenTabPage.Controls.Add(this.jpgFileCheckBox);
            this.filesOpenTabPage.Controls.Add(this.embFileCheckBox);
            this.filesOpenTabPage.Controls.Add(this.dstFileCheckBox);
            this.filesOpenTabPage.Controls.Add(this.aiFileButton);
            this.filesOpenTabPage.Controls.Add(this.aiFileLabel);
            this.filesOpenTabPage.Controls.Add(this.aiFileTextBox);
            this.filesOpenTabPage.Controls.Add(this.jpgFileButton);
            this.filesOpenTabPage.Controls.Add(this.embFileButton);
            this.filesOpenTabPage.Controls.Add(this.dstFileButton);
            this.filesOpenTabPage.Controls.Add(this.jpgFileLabel);
            this.filesOpenTabPage.Controls.Add(this.dstFileTextBox);
            this.filesOpenTabPage.Controls.Add(this.jpgFileTextBox);
            this.filesOpenTabPage.Controls.Add(this.embFileTextBox);
            this.filesOpenTabPage.Controls.Add(this.dstFileLabel);
            this.filesOpenTabPage.Controls.Add(this.embFileLabel);
            this.filesOpenTabPage.Location = new System.Drawing.Point(4, 26);
            this.filesOpenTabPage.Name = "filesOpenTabPage";
            this.filesOpenTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.filesOpenTabPage.Size = new System.Drawing.Size(638, 291);
            this.filesOpenTabPage.TabIndex = 1;
            this.filesOpenTabPage.Text = " 文件类型关联程序";
            this.filesOpenTabPage.UseVisualStyleBackColor = true;
            // 
            // aiFileCheckBox
            // 
            this.aiFileCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aiFileCheckBox.AutoSize = true;
            this.aiFileCheckBox.Location = new System.Drawing.Point(557, 103);
            this.aiFileCheckBox.Name = "aiFileCheckBox";
            this.aiFileCheckBox.Size = new System.Drawing.Size(75, 21);
            this.aiFileCheckBox.TabIndex = 25;
            this.aiFileCheckBox.Text = "是否关联";
            this.aiFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // jpgFileCheckBox
            // 
            this.jpgFileCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jpgFileCheckBox.AutoSize = true;
            this.jpgFileCheckBox.Location = new System.Drawing.Point(557, 72);
            this.jpgFileCheckBox.Name = "jpgFileCheckBox";
            this.jpgFileCheckBox.Size = new System.Drawing.Size(75, 21);
            this.jpgFileCheckBox.TabIndex = 24;
            this.jpgFileCheckBox.Text = "是否关联";
            this.jpgFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // embFileCheckBox
            // 
            this.embFileCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.embFileCheckBox.AutoSize = true;
            this.embFileCheckBox.Location = new System.Drawing.Point(557, 41);
            this.embFileCheckBox.Name = "embFileCheckBox";
            this.embFileCheckBox.Size = new System.Drawing.Size(75, 21);
            this.embFileCheckBox.TabIndex = 23;
            this.embFileCheckBox.Text = "是否关联";
            this.embFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // dstFileCheckBox
            // 
            this.dstFileCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dstFileCheckBox.AutoSize = true;
            this.dstFileCheckBox.Location = new System.Drawing.Point(557, 10);
            this.dstFileCheckBox.Name = "dstFileCheckBox";
            this.dstFileCheckBox.Size = new System.Drawing.Size(75, 21);
            this.dstFileCheckBox.TabIndex = 22;
            this.dstFileCheckBox.Text = "是否关联";
            this.dstFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // aiFileButton
            // 
            this.aiFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aiFileButton.Location = new System.Drawing.Point(491, 102);
            this.aiFileButton.Name = "aiFileButton";
            this.aiFileButton.Size = new System.Drawing.Size(60, 23);
            this.aiFileButton.TabIndex = 21;
            this.aiFileButton.Text = "浏览";
            this.aiFileButton.UseVisualStyleBackColor = true;
            this.aiFileButton.Click += new System.EventHandler(this.aiFileButton_Click);
            // 
            // aiFileLabel
            // 
            this.aiFileLabel.AutoSize = true;
            this.aiFileLabel.Location = new System.Drawing.Point(28, 105);
            this.aiFileLabel.Name = "aiFileLabel";
            this.aiFileLabel.Size = new System.Drawing.Size(127, 17);
            this.aiFileLabel.TabIndex = 20;
            this.aiFileLabel.Text = "文件类型 *ai 程序路径";
            this.aiFileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // aiFileTextBox
            // 
            this.aiFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aiFileTextBox.Location = new System.Drawing.Point(161, 102);
            this.aiFileTextBox.Name = "aiFileTextBox";
            this.aiFileTextBox.Size = new System.Drawing.Size(324, 23);
            this.aiFileTextBox.TabIndex = 19;
            // 
            // jpgFileButton
            // 
            this.jpgFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jpgFileButton.Location = new System.Drawing.Point(491, 71);
            this.jpgFileButton.Name = "jpgFileButton";
            this.jpgFileButton.Size = new System.Drawing.Size(60, 23);
            this.jpgFileButton.TabIndex = 18;
            this.jpgFileButton.Text = "浏览";
            this.jpgFileButton.UseVisualStyleBackColor = true;
            this.jpgFileButton.Click += new System.EventHandler(this.jpgFileButton_Click);
            // 
            // embFileButton
            // 
            this.embFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.embFileButton.Location = new System.Drawing.Point(491, 40);
            this.embFileButton.Name = "embFileButton";
            this.embFileButton.Size = new System.Drawing.Size(60, 23);
            this.embFileButton.TabIndex = 17;
            this.embFileButton.Text = "浏览";
            this.embFileButton.UseVisualStyleBackColor = true;
            this.embFileButton.Click += new System.EventHandler(this.embFileButton_Click);
            // 
            // dstFileButton
            // 
            this.dstFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dstFileButton.Location = new System.Drawing.Point(491, 9);
            this.dstFileButton.Name = "dstFileButton";
            this.dstFileButton.Size = new System.Drawing.Size(60, 23);
            this.dstFileButton.TabIndex = 16;
            this.dstFileButton.Text = "浏览";
            this.dstFileButton.UseVisualStyleBackColor = true;
            this.dstFileButton.Click += new System.EventHandler(this.dstFileButton_Click);
            // 
            // jpgFileLabel
            // 
            this.jpgFileLabel.AutoSize = true;
            this.jpgFileLabel.Location = new System.Drawing.Point(19, 74);
            this.jpgFileLabel.Name = "jpgFileLabel";
            this.jpgFileLabel.Size = new System.Drawing.Size(136, 17);
            this.jpgFileLabel.TabIndex = 5;
            this.jpgFileLabel.Text = "文件类型 *jpg 程序路径";
            this.jpgFileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dstFileTextBox
            // 
            this.dstFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dstFileTextBox.Location = new System.Drawing.Point(161, 9);
            this.dstFileTextBox.Name = "dstFileTextBox";
            this.dstFileTextBox.Size = new System.Drawing.Size(324, 23);
            this.dstFileTextBox.TabIndex = 0;
            // 
            // jpgFileTextBox
            // 
            this.jpgFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jpgFileTextBox.Location = new System.Drawing.Point(161, 71);
            this.jpgFileTextBox.Name = "jpgFileTextBox";
            this.jpgFileTextBox.Size = new System.Drawing.Size(324, 23);
            this.jpgFileTextBox.TabIndex = 4;
            // 
            // embFileTextBox
            // 
            this.embFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.embFileTextBox.Location = new System.Drawing.Point(161, 40);
            this.embFileTextBox.Name = "embFileTextBox";
            this.embFileTextBox.Size = new System.Drawing.Size(324, 23);
            this.embFileTextBox.TabIndex = 2;
            // 
            // dstFileLabel
            // 
            this.dstFileLabel.AutoSize = true;
            this.dstFileLabel.Location = new System.Drawing.Point(20, 12);
            this.dstFileLabel.Name = "dstFileLabel";
            this.dstFileLabel.Size = new System.Drawing.Size(135, 17);
            this.dstFileLabel.TabIndex = 1;
            this.dstFileLabel.Text = "文件类型 *dst 程序路径";
            this.dstFileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // embFileLabel
            // 
            this.embFileLabel.AutoSize = true;
            this.embFileLabel.Location = new System.Drawing.Point(12, 43);
            this.embFileLabel.Name = "embFileLabel";
            this.embFileLabel.Size = new System.Drawing.Size(143, 17);
            this.embFileLabel.TabIndex = 3;
            this.embFileLabel.Text = "文件类型 *emb 程序路径";
            this.embFileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // settingsTabControl
            // 
            this.settingsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsTabControl.Controls.Add(this.filesOpenTabPage);
            this.settingsTabControl.Controls.Add(this.appUpTabPage);
            this.settingsTabControl.Controls.Add(this.sqlTabPage);
            this.settingsTabControl.Controls.Add(this.autoTabPage);
            this.settingsTabControl.Location = new System.Drawing.Point(-1, 5);
            this.settingsTabControl.Multiline = true;
            this.settingsTabControl.Name = "settingsTabControl";
            this.settingsTabControl.SelectedIndex = 0;
            this.settingsTabControl.Size = new System.Drawing.Size(646, 321);
            this.settingsTabControl.TabIndex = 0;
            // 
            // sqlTabPage
            // 
            this.sqlTabPage.Controls.Add(this.sqlServerIPTextBox);
            this.sqlTabPage.Controls.Add(this.label9);
            this.sqlTabPage.Controls.Add(this.sqlDataNameTextBox);
            this.sqlTabPage.Controls.Add(this.sqlUserIDTextBox);
            this.sqlTabPage.Controls.Add(this.label10);
            this.sqlTabPage.Controls.Add(this.label14);
            this.sqlTabPage.Controls.Add(this.label13);
            this.sqlTabPage.Controls.Add(this.sqlPasswordTextBox);
            this.sqlTabPage.Location = new System.Drawing.Point(4, 26);
            this.sqlTabPage.Name = "sqlTabPage";
            this.sqlTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.sqlTabPage.Size = new System.Drawing.Size(638, 291);
            this.sqlTabPage.TabIndex = 3;
            this.sqlTabPage.Text = "数据库";
            this.sqlTabPage.UseVisualStyleBackColor = true;
            // 
            // sqlServerIPTextBox
            // 
            this.sqlServerIPTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sqlServerIPTextBox.Location = new System.Drawing.Point(56, 9);
            this.sqlServerIPTextBox.Name = "sqlServerIPTextBox";
            this.sqlServerIPTextBox.Size = new System.Drawing.Size(572, 23);
            this.sqlServerIPTextBox.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "地址";
            // 
            // sqlDataNameTextBox
            // 
            this.sqlDataNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sqlDataNameTextBox.Location = new System.Drawing.Point(56, 40);
            this.sqlDataNameTextBox.Name = "sqlDataNameTextBox";
            this.sqlDataNameTextBox.Size = new System.Drawing.Size(572, 23);
            this.sqlDataNameTextBox.TabIndex = 3;
            // 
            // sqlUserIDTextBox
            // 
            this.sqlUserIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sqlUserIDTextBox.Location = new System.Drawing.Point(56, 71);
            this.sqlUserIDTextBox.Name = "sqlUserIDTextBox";
            this.sqlUserIDTextBox.Size = new System.Drawing.Size(572, 23);
            this.sqlUserIDTextBox.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "数据库";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 17);
            this.label14.TabIndex = 6;
            this.label14.Text = "用户";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 105);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 17);
            this.label13.TabIndex = 8;
            this.label13.Text = "密码";
            // 
            // sqlPasswordTextBox
            // 
            this.sqlPasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sqlPasswordTextBox.Location = new System.Drawing.Point(56, 102);
            this.sqlPasswordTextBox.Name = "sqlPasswordTextBox";
            this.sqlPasswordTextBox.Size = new System.Drawing.Size(572, 23);
            this.sqlPasswordTextBox.TabIndex = 9;
            this.sqlPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // autoTabPage
            // 
            this.autoTabPage.Controls.Add(this.label8);
            this.autoTabPage.Controls.Add(this.label7);
            this.autoTabPage.Controls.Add(this.label6);
            this.autoTabPage.Controls.Add(this.label5);
            this.autoTabPage.Controls.Add(this.label4);
            this.autoTabPage.Controls.Add(this.label3);
            this.autoTabPage.Controls.Add(this.label2);
            this.autoTabPage.Controls.Add(this.label1);
            this.autoTabPage.Location = new System.Drawing.Point(4, 26);
            this.autoTabPage.Name = "autoTabPage";
            this.autoTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.autoTabPage.Size = new System.Drawing.Size(638, 291);
            this.autoTabPage.TabIndex = 4;
            this.autoTabPage.Text = "后台自动化";
            this.autoTabPage.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "* 定时把Today中的矢量图归类到VcetorData";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(212, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "* 定时把扫描到的图片移动到Attach_in";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "* 定时把扫描到的图片移动到Attach_in";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "* 定时把TB发来的收费针数更新到数据库";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "后台自动化：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(322, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "* 定时按不同的查询条件导出数据到Excel或其他格式的表格";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(597, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "* 定时将Attach_in的订单文件（Pdf、Word、Png、Bmp、Psd、Cdr、Ai、Eps、Svg等）自动转换为Jpg格式";
            // 
            // disksCancelButton
            // 
            this.disksCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.disksCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.disksCancelButton.Location = new System.Drawing.Point(555, 331);
            this.disksCancelButton.Name = "disksCancelButton";
            this.disksCancelButton.Size = new System.Drawing.Size(80, 23);
            this.disksCancelButton.TabIndex = 24;
            this.disksCancelButton.Text = "取消";
            this.disksCancelButton.UseVisualStyleBackColor = true;
            this.disksCancelButton.Click += new System.EventHandler(this.disksCancelButton_Click);
            // 
            // disksSaveButton
            // 
            this.disksSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.disksSaveButton.Location = new System.Drawing.Point(469, 331);
            this.disksSaveButton.Name = "disksSaveButton";
            this.disksSaveButton.Size = new System.Drawing.Size(80, 23);
            this.disksSaveButton.TabIndex = 25;
            this.disksSaveButton.Text = "保存";
            this.disksSaveButton.UseVisualStyleBackColor = true;
            this.disksSaveButton.Click += new System.EventHandler(this.disksSaveButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "应用程序|*.exe";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(283, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "* 定时清理Attach_Users大于多少天的消息历史文件";
            // 
            // AppSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.disksCancelButton;
            this.ClientSize = new System.Drawing.Size(643, 361);
            this.Controls.Add(this.disksSaveButton);
            this.Controls.Add(this.settingsTabControl);
            this.Controls.Add(this.disksCancelButton);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "AppSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选项";
            this.Load += new System.EventHandler(this.AppSettingsForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AppSettingsForm_KeyDown);
            this.appUpTabPage.ResumeLayout(false);
            this.appUpTabPage.PerformLayout();
            this.filesOpenTabPage.ResumeLayout(false);
            this.filesOpenTabPage.PerformLayout();
            this.settingsTabControl.ResumeLayout(false);
            this.sqlTabPage.ResumeLayout(false);
            this.sqlTabPage.PerformLayout();
            this.autoTabPage.ResumeLayout(false);
            this.autoTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage appUpTabPage;
        private System.Windows.Forms.TabPage filesOpenTabPage;
        private System.Windows.Forms.Button jpgFileButton;
        private System.Windows.Forms.Button embFileButton;
        private System.Windows.Forms.Button dstFileButton;
        private System.Windows.Forms.Label jpgFileLabel;
        private System.Windows.Forms.TextBox dstFileTextBox;
        private System.Windows.Forms.TextBox jpgFileTextBox;
        private System.Windows.Forms.TextBox embFileTextBox;
        private System.Windows.Forms.Label dstFileLabel;
        private System.Windows.Forms.Label embFileLabel;
        private System.Windows.Forms.TabControl settingsTabControl;
        private System.Windows.Forms.TabPage sqlTabPage;
        private System.Windows.Forms.TabPage autoTabPage;
        private System.Windows.Forms.TextBox appUpTextBox;
        private System.Windows.Forms.Label appUpPathLabel;
        private System.Windows.Forms.Button appUpButton;
        private System.Windows.Forms.CheckBox appAutoUpCheckBox;
        private System.Windows.Forms.Button disksSaveButton;
        private System.Windows.Forms.Button disksCancelButton;
        private System.Windows.Forms.TextBox sqlServerIPTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox sqlDataNameTextBox;
        private System.Windows.Forms.TextBox sqlUserIDTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox sqlPasswordTextBox;
        private System.Windows.Forms.Button aiFileButton;
        private System.Windows.Forms.Label aiFileLabel;
        private System.Windows.Forms.TextBox aiFileTextBox;
        private System.Windows.Forms.CheckBox aiFileCheckBox;
        private System.Windows.Forms.CheckBox jpgFileCheckBox;
        private System.Windows.Forms.CheckBox embFileCheckBox;
        private System.Windows.Forms.CheckBox dstFileCheckBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}