using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TDS2
{
    public partial class MessageForm : Form
    {
        #region 窗口动作

        public MessageForm(User inUser)
        {
            InitializeComponent();
            try// 图标
            {
                Icon = new Icon(Path.Combine(Application.StartupPath, @"Image\Skin\Message.ico"));
                addPictureBox.Image = Image.FromFile(@"Image\Message\AddPicture.png");
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
            user = inUser;// 获取用户资料表
            GetUserList();
            getMessageTimer.Start();// 开启自动获取消息
        }
        


        好友头像的类型加载出错


        /// <summary>
        /// 获取好友列表
        /// </summary>
        private void GetUserList()
        {
            if (uesrListView != null) uesrListView.Items.Clear();
            if (userImageList != null) userImageList.Images.Clear();
            DataTable deptTable = SqlFunction.Select("SELECT dept FROM UserTable");// 先加载部门好友
            for (int i = 0; i < deptTable.Rows.Count; i++)
            {
                string name = deptTable.Rows[i][0].ToString().ToUpper();
                if (DeptRepeat(name)) continue;
                ListViewItem listViewItem = new ListViewItem();// 定义单个项目
                listViewItem.ImageIndex = i;
                listViewItem.Text = name;
                uesrListView.Items.Add(listViewItem);
                ///
                Bitmap bmp = new Bitmap(@"Image\Message\DeptOn.png");
                userImageList.Images.Add(ImageZoom.Zoom(bmp, 48, 48));
                bmp.Dispose();
            }

            DataTable dataTable = SqlFunction.Select("SELECT username FROM UserTable");// 再加载个人好友
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string name = dataTable.Rows[i][0].ToString().ToUpper();
                ListViewItem listViewItem = new ListViewItem();// 定义单个项目
                listViewItem.ImageIndex = i;
                listViewItem.Text = name;
                uesrListView.Items.Add(listViewItem);
                ///
                Bitmap bmp = new Bitmap(@"Image\Message\UserOn.png");
                userImageList.Images.Add(ImageZoom.Zoom(bmp, 48, 48));
                bmp.Dispose();
            }

            uesrListView.SmallImageList = userImageList;
        }

        /// <summary>
        /// 部门重复检测
        /// </summary>
        /// <returns></returns>
        private bool DeptRepeat(string name)
        {
            foreach (ListViewItem item in uesrListView.Items)if (item.Text == name) return true;
            return false;
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

        #endregion 窗口动作




        #region 全局变量

        /// <summary>
        /// 用户
        /// </summary>
        private User user;

        /// <summary>
        /// 消息DataTable表
        /// </summary>
        private DataTable messageTable = new DataTable();

        /// <summary>
        /// 消息集
        /// </summary>
        private List<MessageNotes> messagesList = new List<MessageNotes>();

        #endregion 全局变量




        #region 后台

        /// <summary>
        /// 定时后台查询
        /// </summary>
        private void getMessageTimer_Tick(object sender, EventArgs e)
        {
            Get();
        }

        /// <summary>
        /// 准备后台查询
        /// </summary>
        private void Get()
        {
            if (getMessageBackgroundWorker.IsBusy) return;// 后台是否进行中
            if (messageTable != null) messageTable.Clear();// 清空消息表
            getMessageBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// 后台异步获取消息
        /// </summary>
        private void getMessageBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //string sql = "SELECT * FROM MessageNotes WHERE ReceiveUser='" + user.UserName + "' OR ReceiveDepartment='" + user.Dept + "'";
            //messageTable = SqlFunction.Select(sql);
        }

        /// <summary>
        /// 后台进度
        /// </summary>
        private void getMessageBackgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            messageProgressBar.Value = (e.ProgressPercentage < 101) ? e.ProgressPercentage : messageProgressBar.Value;
            messageLabel.Text = messageProgressBar.Value.ToString() + "% " + e.UserState as string;
        }

        /// <summary>
        /// 后台获取消息完成
        /// </summary>
        private void getMessageBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)// 异步出错
            {
                MessageBox.Show("后台获取消息错误如下\r\n\r\n" + e.Error.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                messageProgressBar.Value = 0;
                messageLabel.Text = "后台获取消息出错";
                return;
            }

            ///

            if (e.Cancelled)// 异步取消
            {
                messageProgressBar.Value = 0;
                messageLabel.Text = "已取消后台获取消息";
                return;
            }

            ///

            if (messageTable==null||messageTable.Rows.Count==0) {

                messageProgressBar.Value = 100;
                messageLabel.Text = "无任何消息：" + DateTime.Now.ToString();
                return;
            }

            for(int i = 0; i < messageTable.Rows.Count; i++)
            {
                MessageNotes messageNotes = new MessageNotes();
                messagesList.Add(messageNotes);
            }

            messageProgressBar.Value = 100;
            messageLabel.Text = "消息刷新时间：" + DateTime.Now.ToString();
        }

        #endregion 后台




        #region 按钮

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
            sendButton.FlatAppearance.BorderColor = Color.Green;
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

        /// <summary>
        /// 文件放大按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 文件缩小按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #endregion 按钮
    }
}
