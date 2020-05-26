using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TDS2
{
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
            try// 图标
            {
                Icon = new Icon(Path.Combine(Application.StartupPath, @"Image\Message.ico"));
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
        /// 窗口快捷键
        /// </summary>
        private void MessagesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) Hide();
        }

        /// <summary>
        /// 重写关窗
        /// </summary>
        private void MessagesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            StartPosition = FormStartPosition.Manual;
        }
    }
}
