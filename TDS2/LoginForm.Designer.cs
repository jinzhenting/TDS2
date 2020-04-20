namespace TDS2
{
    partial class LoginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.userPasswordTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.userPictureBox = new System.Windows.Forms.PictureBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userPasswordLabel = new System.Windows.Forms.Label();
            this.mRadioButton = new System.Windows.Forms.RadioButton();
            this.aRadioButton = new System.Windows.Forms.RadioButton();
            this.eRadioButton = new System.Windows.Forms.RadioButton();
            this.scanerCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(43, 10);
            this.userNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(80, 23);
            this.userNameTextBox.TabIndex = 1;
            this.userNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userNameTextBox_KeyDown);
            // 
            // userPasswordTextBox
            // 
            this.userPasswordTextBox.Location = new System.Drawing.Point(163, 10);
            this.userPasswordTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userPasswordTextBox.Name = "userPasswordTextBox";
            this.userPasswordTextBox.Size = new System.Drawing.Size(110, 23);
            this.userPasswordTextBox.TabIndex = 3;
            this.userPasswordTextBox.UseSystemPasswordChar = true;
            this.userPasswordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userPasswordTextBox_KeyDown);
            // 
            // loginButton
            // 
            this.loginButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loginButton.Location = new System.Drawing.Point(196, 228);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(80, 25);
            this.loginButton.TabIndex = 1;
            this.loginButton.Text = "登陆";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // userPictureBox
            // 
            this.userPictureBox.Location = new System.Drawing.Point(83, 10);
            this.userPictureBox.Name = "userPictureBox";
            this.userPictureBox.Size = new System.Drawing.Size(128, 128);
            this.userPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userPictureBox.TabIndex = 6;
            this.userPictureBox.TabStop = false;
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(9, 13);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(32, 17);
            this.userNameLabel.TabIndex = 0;
            this.userNameLabel.Text = "用户";
            // 
            // userPasswordLabel
            // 
            this.userPasswordLabel.AutoSize = true;
            this.userPasswordLabel.Location = new System.Drawing.Point(129, 13);
            this.userPasswordLabel.Name = "userPasswordLabel";
            this.userPasswordLabel.Size = new System.Drawing.Size(32, 17);
            this.userPasswordLabel.TabIndex = 2;
            this.userPasswordLabel.Text = "密码";
            // 
            // mRadioButton
            // 
            this.mRadioButton.AutoSize = true;
            this.mRadioButton.Location = new System.Drawing.Point(12, 41);
            this.mRadioButton.Name = "mRadioButton";
            this.mRadioButton.Size = new System.Drawing.Size(50, 21);
            this.mRadioButton.TabIndex = 4;
            this.mRadioButton.TabStop = true;
            this.mRadioButton.Text = "早班";
            this.mRadioButton.UseVisualStyleBackColor = true;
            this.mRadioButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mRadioButton_KeyDown);
            // 
            // aRadioButton
            // 
            this.aRadioButton.AutoSize = true;
            this.aRadioButton.Location = new System.Drawing.Point(68, 41);
            this.aRadioButton.Name = "aRadioButton";
            this.aRadioButton.Size = new System.Drawing.Size(50, 21);
            this.aRadioButton.TabIndex = 5;
            this.aRadioButton.TabStop = true;
            this.aRadioButton.Text = "中班";
            this.aRadioButton.UseVisualStyleBackColor = true;
            this.aRadioButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.aRadioButton_KeyDown);
            // 
            // eRadioButton
            // 
            this.eRadioButton.AutoSize = true;
            this.eRadioButton.Location = new System.Drawing.Point(124, 41);
            this.eRadioButton.Name = "eRadioButton";
            this.eRadioButton.Size = new System.Drawing.Size(50, 21);
            this.eRadioButton.TabIndex = 6;
            this.eRadioButton.TabStop = true;
            this.eRadioButton.Text = "晚班";
            this.eRadioButton.UseVisualStyleBackColor = true;
            this.eRadioButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.eRadioButton_KeyDown);
            // 
            // scanerCheckBox
            // 
            this.scanerCheckBox.AutoSize = true;
            this.scanerCheckBox.Location = new System.Drawing.Point(12, 231);
            this.scanerCheckBox.Name = "scanerCheckBox";
            this.scanerCheckBox.Size = new System.Drawing.Size(75, 21);
            this.scanerCheckBox.TabIndex = 7;
            this.scanerCheckBox.Text = "扫描电脑";
            this.scanerCheckBox.UseVisualStyleBackColor = true;
            this.scanerCheckBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.scanerCheckBox_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.userNameTextBox);
            this.panel1.Controls.Add(this.userNameLabel);
            this.panel1.Controls.Add(this.eRadioButton);
            this.panel1.Controls.Add(this.userPasswordLabel);
            this.panel1.Controls.Add(this.aRadioButton);
            this.panel1.Controls.Add(this.mRadioButton);
            this.panel1.Controls.Add(this.userPasswordTextBox);
            this.panel1.Location = new System.Drawing.Point(0, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 72);
            this.panel1.TabIndex = 0;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.scanerCheckBox);
            this.Controls.Add(this.userPictureBox);
            this.Controls.Add(this.loginButton);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "欢迎登陆TDS2系统";
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.TextBox userPasswordTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.PictureBox userPictureBox;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label userPasswordLabel;
        private System.Windows.Forms.RadioButton mRadioButton;
        private System.Windows.Forms.RadioButton aRadioButton;
        private System.Windows.Forms.RadioButton eRadioButton;
        private System.Windows.Forms.CheckBox scanerCheckBox;
        private System.Windows.Forms.Panel panel1;
    }
}

