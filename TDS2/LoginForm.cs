using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TDS2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            try
            {
                userPictureBox.ImageLocation = @"Image\Icon.png";
                Icon = new Icon(Path.Combine(Application.StartupPath, @"Image\Icon.ico"));
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
            ///
            int nowMinute = DateTime.Now.Minute + DateTime.Now.Hour * 60;// 分钟数判断班次
            if (nowMinute >= 1435 || nowMinute < 475) eRadioButton.Checked = true;// 晚班
            if (nowMinute >= 475 && nowMinute < 955) mRadioButton.Checked = true;// 早班
            if (nowMinute >= 955 && nowMinute < 1435) aRadioButton.Checked = true;// 中班
        }

        /// <summary>
        /// 用户
        /// </summary>
        public DataTable loginTable;

        /// <summary>
        /// 登陆按钮
        /// </summary>
        private void loginButton_Click(object sender, EventArgs e)
        {
            Login();
        }

        /// <summary>
        /// 登陆
        /// </summary>
        private void Login()
        {
            ///
            if (userNameTextBox.Text == "")
            {
                MessageBox.Show("请输入用户名");
                userNameTextBox.Focus();
                return;
            }
            if (userPasswordTextBox.Text == "")
            {
                MessageBox.Show("请输入密码");
                userPasswordTextBox.Focus();
                return;
            }
            ///
            loginTable = SqlFunction.Select("SELECT * FROM UserTable WHERE username='" + userNameTextBox.Text + "'");
            ///
            if (loginTable == null) return;
            ///
            if (loginTable.Rows.Count < 1)
            {
                MessageBox.Show("用户不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                userNameTextBox.Focus();
                userNameTextBox.SelectAll();
                return;
            }
            ///
            if (loginTable.Rows.Count == 1)
            {
                if (loginTable.Rows[0]["pwd"].ToString() == userPasswordTextBox.Text) DialogResult = DialogResult.OK;
                else
                {
                    MessageBox.Show("密码错误");
                    userPasswordTextBox.Focus();
                    userPasswordTextBox.SelectAll();
                    return;
                }
            }
            ///
            if (loginTable.Rows.Count > 1)
            {
                MessageBox.Show("系统存在多个同名用户，请通知技术人员处理");
                return;
            }
            ///
            if (eRadioButton.Checked) loginTable.Rows[0]["Shift"] = "E";
            else if (mRadioButton.Checked) loginTable.Rows[0]["Shift"] = "M";
            else if (aRadioButton.Checked) loginTable.Rows[0]["Shift"] = "A";
        }

        /// <summary>
        /// 按键检测
        /// </summary>
        private void userNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Login();
            if (e.KeyCode == Keys.Escape) Close();
        }

        /// <summary>
        /// 按键检测
        /// </summary>
        private void userPasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)Login();
            if (e.KeyCode == Keys.Escape) Close();
        }
        
        /// <summary>
        /// 按键检测
        /// </summary>
        private void mRadioButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Login();
            if (e.KeyCode == Keys.Escape) Close();
        }
        
        /// <summary>
        /// 按键检测
        /// </summary>
        private void aRadioButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Login();
            if (e.KeyCode == Keys.Escape) Close();
        }
        
        /// <summary>
        /// 按键检测
        /// </summary>
        private void eRadioButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Login();
            if (e.KeyCode == Keys.Escape) Close();
        }

        /// <summary>
        /// 按键检测
        /// </summary>
        private void scanerCheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Login();
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
