namespace TDS2
{
    partial class DiskModifyForm
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.netPathTextBox = new System.Windows.Forms.TextBox();
            this.netPathLabel = new System.Windows.Forms.Label();
            this.netPathButton = new System.Windows.Forms.Button();
            this.localPathLabel = new System.Windows.Forms.Label();
            this.localPathComboBox = new System.Windows.Forms.ComboBox();
            this.autoMappingLabel = new System.Windows.Forms.Label();
            this.autoMappingComboBox = new System.Windows.Forms.ComboBox();
            this.foreverComboBox = new System.Windows.Forms.ComboBox();
            this.foreverLabel = new System.Windows.Forms.Label();
            this.windowsAccountLabel = new System.Windows.Forms.Label();
            this.windowsAccountComboBox = new System.Windows.Forms.ComboBox();
            this.autoCheckComboBox = new System.Windows.Forms.ComboBox();
            this.autoCheckLabel = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cencelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(7, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(32, 17);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "名称";
            // 
            // netPathTextBox
            // 
            this.netPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.netPathTextBox.Location = new System.Drawing.Point(70, 7);
            this.netPathTextBox.Name = "netPathTextBox";
            this.netPathTextBox.Size = new System.Drawing.Size(227, 23);
            this.netPathTextBox.TabIndex = 3;
            // 
            // netPathLabel
            // 
            this.netPathLabel.AutoSize = true;
            this.netPathLabel.Location = new System.Drawing.Point(8, 10);
            this.netPathLabel.Name = "netPathLabel";
            this.netPathLabel.Size = new System.Drawing.Size(56, 17);
            this.netPathLabel.TabIndex = 2;
            this.netPathLabel.Text = "网络位置";
            // 
            // netPathButton
            // 
            this.netPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.netPathButton.Location = new System.Drawing.Point(303, 7);
            this.netPathButton.Name = "netPathButton";
            this.netPathButton.Size = new System.Drawing.Size(75, 23);
            this.netPathButton.TabIndex = 4;
            this.netPathButton.Text = "浏览";
            this.netPathButton.UseVisualStyleBackColor = true;
            this.netPathButton.Click += new System.EventHandler(this.netPathButton_Click);
            // 
            // localPathLabel
            // 
            this.localPathLabel.AutoSize = true;
            this.localPathLabel.Location = new System.Drawing.Point(8, 40);
            this.localPathLabel.Name = "localPathLabel";
            this.localPathLabel.Size = new System.Drawing.Size(32, 17);
            this.localPathLabel.TabIndex = 5;
            this.localPathLabel.Text = "盘符";
            // 
            // localPathComboBox
            // 
            this.localPathComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.localPathComboBox.FormattingEnabled = true;
            this.localPathComboBox.Location = new System.Drawing.Point(46, 36);
            this.localPathComboBox.Name = "localPathComboBox";
            this.localPathComboBox.Size = new System.Drawing.Size(50, 25);
            this.localPathComboBox.TabIndex = 6;
            // 
            // autoMappingLabel
            // 
            this.autoMappingLabel.AutoSize = true;
            this.autoMappingLabel.Location = new System.Drawing.Point(8, 71);
            this.autoMappingLabel.Name = "autoMappingLabel";
            this.autoMappingLabel.Size = new System.Drawing.Size(56, 17);
            this.autoMappingLabel.TabIndex = 7;
            this.autoMappingLabel.Text = "自动映射";
            // 
            // autoMappingComboBox
            // 
            this.autoMappingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.autoMappingComboBox.FormattingEnabled = true;
            this.autoMappingComboBox.Items.AddRange(new object[] {
            "是",
            "否"});
            this.autoMappingComboBox.Location = new System.Drawing.Point(70, 67);
            this.autoMappingComboBox.Name = "autoMappingComboBox";
            this.autoMappingComboBox.Size = new System.Drawing.Size(72, 25);
            this.autoMappingComboBox.TabIndex = 8;
            // 
            // foreverComboBox
            // 
            this.foreverComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.foreverComboBox.FormattingEnabled = true;
            this.foreverComboBox.Items.AddRange(new object[] {
            "临时",
            "固定"});
            this.foreverComboBox.Location = new System.Drawing.Point(70, 98);
            this.foreverComboBox.Name = "foreverComboBox";
            this.foreverComboBox.Size = new System.Drawing.Size(72, 25);
            this.foreverComboBox.TabIndex = 10;
            // 
            // foreverLabel
            // 
            this.foreverLabel.AutoSize = true;
            this.foreverLabel.Location = new System.Drawing.Point(8, 102);
            this.foreverLabel.Name = "foreverLabel";
            this.foreverLabel.Size = new System.Drawing.Size(56, 17);
            this.foreverLabel.TabIndex = 9;
            this.foreverLabel.Text = "映射性质";
            // 
            // windowsAccountLabel
            // 
            this.windowsAccountLabel.AutoSize = true;
            this.windowsAccountLabel.Location = new System.Drawing.Point(7, 164);
            this.windowsAccountLabel.Name = "windowsAccountLabel";
            this.windowsAccountLabel.Size = new System.Drawing.Size(80, 17);
            this.windowsAccountLabel.TabIndex = 11;
            this.windowsAccountLabel.Text = "网络认证方式";
            // 
            // windowsAccountComboBox
            // 
            this.windowsAccountComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.windowsAccountComboBox.FormattingEnabled = true;
            this.windowsAccountComboBox.Items.AddRange(new object[] {
            "Windows凭据",
            "用户名与密码"});
            this.windowsAccountComboBox.Location = new System.Drawing.Point(93, 160);
            this.windowsAccountComboBox.Name = "windowsAccountComboBox";
            this.windowsAccountComboBox.Size = new System.Drawing.Size(115, 25);
            this.windowsAccountComboBox.TabIndex = 12;
            this.windowsAccountComboBox.SelectedIndexChanged += new System.EventHandler(this.windowsAccountComboBox_SelectedIndexChanged);
            // 
            // autoCheckComboBox
            // 
            this.autoCheckComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.autoCheckComboBox.FormattingEnabled = true;
            this.autoCheckComboBox.Items.AddRange(new object[] {
            "是",
            "否"});
            this.autoCheckComboBox.Location = new System.Drawing.Point(70, 129);
            this.autoCheckComboBox.Name = "autoCheckComboBox";
            this.autoCheckComboBox.Size = new System.Drawing.Size(72, 25);
            this.autoCheckComboBox.TabIndex = 14;
            // 
            // autoCheckLabel
            // 
            this.autoCheckLabel.AutoSize = true;
            this.autoCheckLabel.Location = new System.Drawing.Point(8, 133);
            this.autoCheckLabel.Name = "autoCheckLabel";
            this.autoCheckLabel.Size = new System.Drawing.Size(56, 17);
            this.autoCheckLabel.TabIndex = 13;
            this.autoCheckLabel.Text = "断开检测";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(58, 191);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(112, 23);
            this.userNameTextBox.TabIndex = 16;
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(8, 194);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(44, 17);
            this.userNameLabel.TabIndex = 15;
            this.userNameLabel.Text = "用户名";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(214, 191);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(112, 23);
            this.passwordTextBox.TabIndex = 18;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(176, 194);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(32, 17);
            this.passwordLabel.TabIndex = 17;
            this.passwordLabel.Text = "密码";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.netPathLabel);
            this.panel1.Controls.Add(this.passwordTextBox);
            this.panel1.Controls.Add(this.netPathTextBox);
            this.panel1.Controls.Add(this.passwordLabel);
            this.panel1.Controls.Add(this.netPathButton);
            this.panel1.Controls.Add(this.userNameTextBox);
            this.panel1.Controls.Add(this.localPathLabel);
            this.panel1.Controls.Add(this.userNameLabel);
            this.panel1.Controls.Add(this.localPathComboBox);
            this.panel1.Controls.Add(this.autoCheckComboBox);
            this.panel1.Controls.Add(this.autoMappingLabel);
            this.panel1.Controls.Add(this.autoCheckLabel);
            this.panel1.Controls.Add(this.autoMappingComboBox);
            this.panel1.Controls.Add(this.windowsAccountComboBox);
            this.panel1.Controls.Add(this.foreverLabel);
            this.panel1.Controls.Add(this.windowsAccountLabel);
            this.panel1.Controls.Add(this.foreverComboBox);
            this.panel1.Location = new System.Drawing.Point(-2, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 222);
            this.panel1.TabIndex = 19;
            // 
            // cencelButton
            // 
            this.cencelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cencelButton.Location = new System.Drawing.Point(302, 261);
            this.cencelButton.Name = "cencelButton";
            this.cencelButton.Size = new System.Drawing.Size(75, 23);
            this.cencelButton.TabIndex = 19;
            this.cencelButton.Text = "取消";
            this.cencelButton.UseVisualStyleBackColor = true;
            this.cencelButton.Click += new System.EventHandler(this.cencelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(221, 261);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 20;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // DiskModifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 291);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cencelButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.nameLabel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 330);
            this.MinimumSize = new System.Drawing.Size(400, 330);
            this.Name = "DiskModifyForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改网络磁盘配置";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DiskModifyForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox netPathTextBox;
        private System.Windows.Forms.Label netPathLabel;
        private System.Windows.Forms.Button netPathButton;
        private System.Windows.Forms.Label localPathLabel;
        private System.Windows.Forms.ComboBox localPathComboBox;
        private System.Windows.Forms.Label autoMappingLabel;
        private System.Windows.Forms.ComboBox autoMappingComboBox;
        private System.Windows.Forms.ComboBox foreverComboBox;
        private System.Windows.Forms.Label foreverLabel;
        private System.Windows.Forms.Label windowsAccountLabel;
        private System.Windows.Forms.ComboBox windowsAccountComboBox;
        private System.Windows.Forms.ComboBox autoCheckComboBox;
        private System.Windows.Forms.Label autoCheckLabel;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cencelButton;
        private System.Windows.Forms.Button saveButton;
    }
}