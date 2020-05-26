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
    public partial class DiskAddForm : Form
    {
        public DiskAddForm()
        {
            InitializeComponent();
            try// 图标
            {
                Icon = new Icon(Path.Combine(Application.StartupPath, @"Image\DiskMapping.ico"));
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

            foreach (string freeDisk in SyetemDiskList.GetFree()) localPathComboBox.Items.Add(freeDisk);

        }

        private void DiskAddForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Save();
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void cencelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 保存功能
        /// </summary>
        private void Save()
        {
            if (nameTextBox.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("请输入磁盘名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (netPathTextBox.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("请选择网络位置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(netPathTextBox.Text))
            {
                MessageBox.Show("网络位置无效", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (localPathComboBox.Text == "")
            {
                MessageBox.Show("请选择盘符", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (autoMappingComboBox.Text == "")
            {
                MessageBox.Show("请选择是否自动映射", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (foreverComboBox.Text == "")
            {
                MessageBox.Show("请选择映射性质", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (autoCheckComboBox.Text == "")
            {
                MessageBox.Show("请选择是否自动检测", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (windowsAccountComboBox.Text == "")
            {
                MessageBox.Show("请选择是否网络认证方式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (windowsAccountComboBox.Text == "用户名与密码")
            {
                if (userNameTextBox.Text.Replace(" ", "") == "" || passwordTextBox.Text.Replace(" ", "") == "")
                {
                    MessageBox.Show("请填写用户名和密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else userNameTextBox.Text = passwordTextBox.Text = "";// 清空

            DiskList.Add(nameTextBox.Text, netPathTextBox.Text, localPathComboBox.Text, autoMappingComboBox.Text, windowsAccountComboBox.Text, foreverComboBox.Text, autoCheckComboBox.Text, userNameTextBox.Text, passwordTextBox.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void windowsAccountComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (windowsAccountComboBox.Text == "用户名与密码") userNameLabel.Visible = userNameTextBox.Visible = passwordLabel.Visible = passwordTextBox.Visible = true;// 显示
            else
            {
                userNameLabel.Visible = userNameTextBox.Visible = passwordLabel.Visible = passwordTextBox.Visible = false;// 隐藏
                userNameTextBox.Text = passwordTextBox.Text = "";// 清空
            }
        }

        private void netPathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) netPathTextBox.Text = folderBrowserDialog.SelectedPath;
        }
    }
}
