using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TDS2
{
    public partial class AppSettingsForm : Form
    {
        public AppSettingsForm()
        {
            InitializeComponent();

            ///

            ExtensionList extensions = new ExtensionList();
            dstFileTextBox.Text = extensions.Dst.App;
            dstFileCheckBox.Checked = extensions.Dst.Relation;
            embFileTextBox.Text = extensions.Emb.App;
            embFileCheckBox.Checked = extensions.Emb.Relation;
            jpgFileTextBox.Text = extensions.Jpg.App;
            jpgFileCheckBox.Checked = extensions.Jpg.Relation;
            aiFileTextBox.Text = extensions.Ai.App;
            aiFileCheckBox.Checked = extensions.Ai.Relation;

            ///

            AppSettings AppSettings = new AppSettings();
            appUpTextBox.Text = AppSettings.UpdataUrl;
            appAutoUpCheckBox.Checked = AppSettings.UpdataAuto;

            ///

            SqlConnection sql = new SqlConnection();
            sqlServerIPTextBox.Text = sql.ServerIP;
            sqlDataNameTextBox.Text = sql.DataName;
            sqlUserIDTextBox.Text = sql.UserID;
            sqlPasswordTextBox.Text = sql.Password;
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        private void disksSaveButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        private void disksCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 浏览程序更新地址
        /// </summary>
        private void appUpButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) appUpTextBox.Text = folderBrowserDialog.SelectedPath;
        }

        /// <summary>
        /// 窗口载入时
        /// </summary>
        private void AppSettingsForm_Load(object sender, EventArgs e)
        {
            try// 图标
            {
                Icon = new Icon(Path.Combine(Application.StartupPath, @"Image\Skin\AppSettings.ico"));
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

        ///
        
        private void dstFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK) dstFileTextBox.Text = openFileDialog.FileName;
        }

        private void embFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK) embFileTextBox.Text = openFileDialog.FileName;
        }

        private void jpgFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK) jpgFileTextBox.Text = openFileDialog.FileName;
        }

        private void aiFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK) aiFileTextBox.Text = openFileDialog.FileName;
        }

        private void AppSettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.O:
                    {
                        if (e.Control) Close();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        ///



    }
}
