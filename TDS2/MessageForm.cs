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
                Icon = new Icon(Path.Combine(Application.StartupPath, @"Image\Skin\Message.ico"));
                addPictureBox.Image=Image.FromFile(@"Image\Message\AddPicture.png");
                zooz2PictureBox.Image = Image.FromFile(@"Image\Message\TextZooz-.png");
                zooz1PictureBox.Image = Image.FromFile(@"Image\Message\TextZooz+.png");
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
        
        /// <summary>
        /// 定时查询
        /// </summary>
        private void getMessageTimer_Tick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 发送按钮
        /// </summary>
        private void sendButton_Click(object sender, EventArgs e)
        {
            messageRichTextBox.Text += sendTextBox.Text;
        }
        private void sendButton_MouseMove(object sender, MouseEventArgs e)
        {
            sendButton.BackColor = Color.Green;
            sendButton.FlatAppearance.BorderColor= Color.Green;
            sendButton.ForeColor = Color.White; 
        }
        private void sendButton_MouseLeave(object sender, EventArgs e)
        {
            sendButton.BackColor = Color.WhiteSmoke;
            sendButton.FlatAppearance.BorderColor = SystemColors.ScrollBar;
            sendButton.ForeColor = Color.Black;
            sendTextBox.Focus();
        }

        /// <summary>
        /// 后台异步获取信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getMessageBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        /// <summary>
        /// 添加图片按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addPictureBox_Click(object sender, EventArgs e)
        {
            MessagePictureForm messagePictureForm = new MessagePictureForm();
            messagePictureForm.ShowDialog();
        }

        private void addPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            addPictureBox.Image = Image.FromFile(@"Image\Message\AddPictureOn.png");
        }

        private void addPictureBox_MouseLeave(object sender, EventArgs e)
        {
            addPictureBox.Image = Image.FromFile(@"Image\Message\AddPicture.png");
        }

        private void zooz1PictureBox_Click(object sender, EventArgs e)
        {
            if (sendTextBox.Font.Size < 30) sendTextBox.Font = new Font(sendTextBox.Font.Name, sendTextBox.Font.Size + 1);
        }

        private void zooz1PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            zooz1PictureBox.Image = Image.FromFile(@"Image\Message\TextZoozOn+.png");
        }

        private void zooz1PictureBox_MouseLeave(object sender, EventArgs e)
        {
            zooz1PictureBox.Image = Image.FromFile(@"Image\Message\TextZooz+.png");
        }

        private void zooz2PictureBox_Click(object sender, EventArgs e)
        {
            if (sendTextBox.Font.Size > 7) sendTextBox.Font = new Font(sendTextBox.Font.Name, sendTextBox.Font.Size - 1);
        }

        private void zooz2PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            zooz2PictureBox.Image = Image.FromFile(@"Image\Message\TextZoozOn-.png");
        }

        private void zooz2PictureBox_MouseLeave(object sender, EventArgs e)
        {
            zooz2PictureBox.Image = Image.FromFile(@"Image\Message\TextZooz-.png");
        }
    }
}
