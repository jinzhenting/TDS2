using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TDS2
{
    public partial class DiskModifyForm : Form
    {
        public DiskModifyForm(string diskName, string netPath, string localPath, string autoMapping, string windowsAccount, string forever, string autoCheck, string userName, string password)
        {
            InitializeComponent();
            try// 图标
            {
                Icon = new Icon(Path.Combine(Application.StartupPath, @"Image\Skin\DiskMapping.ico"));
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
            
            nameLabel.Text = diskName;
            netPathTextBox.Text = netPath;
            foreach (string freeDisk in SyetemDiskList.GetFree()) localPathComboBox.Items.Add(freeDisk);
            localPathComboBox.Items.Add(localPath);
            localPathComboBox.Text = localPath;
            autoMappingComboBox.Text = autoMapping;
            windowsAccountComboBox.Text = windowsAccount;
            foreverComboBox.Text = forever;
            autoCheckComboBox.Text = autoCheck;
            userNameTextBox.Text = userName;
            passwordTextBox.Text = password;
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        private void cencelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 窗口按键检测
        /// </summary>
        private void DiskModifyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Save();
            if (e.KeyCode == Keys.Escape) Close();
        }

        /// <summary>
        /// 保存功能
        /// </summary>
        private void Save()
        {
            if (netPathTextBox.Text=="")
            {
                MessageBox.Show("网络位置未选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(netPathTextBox.Text))
            {
                MessageBox.Show("网络位置无效", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (windowsAccountComboBox.Text == "用户名与密码")
            {
                if (userNameTextBox.Text == "" || passwordTextBox.Text == "")
                {
                    MessageBox.Show("用户名或密码未填写", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else userNameTextBox.Text = passwordTextBox.Text = "";// 清空

            DiskList.Modify(nameLabel.Text, netPathTextBox.Text, localPathComboBox.Text, autoMappingComboBox.Text, windowsAccountComboBox.Text, foreverComboBox.Text, autoCheckComboBox.Text, userNameTextBox.Text, passwordTextBox.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        /// <summary>
        /// 网络认证方式选择时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void windowsAccountComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (windowsAccountComboBox.Text == "用户名与密码") userNameLabel.Visible = userNameTextBox.Visible = passwordLabel.Visible = passwordTextBox.Visible = true;// 显示
            else
            {
                userNameLabel.Visible = userNameTextBox.Visible = passwordLabel.Visible = passwordTextBox.Visible = false;// 隐藏
                userNameTextBox.Text = passwordTextBox.Text = "";// 清空
            }
        }

        /// <summary>
        /// 浏览网络位置按钮
        /// </summary>
        private void netPathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) netPathTextBox.Text = folderBrowserDialog.SelectedPath;
        }
    }
}
