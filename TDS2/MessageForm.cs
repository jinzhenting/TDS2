
/*
 * 进度
 * 
 * 好友列表和聊天列表分开设计，节省资源
 * 开发一个聊天记录容器，每个聊天中的好友生成一个独立的容器显示内容，支持文本和图片功能，不同类型的信息用标签标识，发送和接收时分开处理
 * 记录保存在本地，登陆系统时加载记录
 * 记录最后一条信息的发送人的发送时间，查询新信息时只查询此时间后的，节省资源，点聊天记录时才查询更多记录
 * 
*/


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
            try
            {
                Icon = new Icon(Path.Combine(Application.StartupPath, @"Image\Skin\Message.ico"));// 图标
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
        
        /// <summary>
        /// 获取好友列表
        /// </summary>
        private void GetUserList()
        {
            if (uesrListView != null) uesrListView.Items.Clear();
            if (userImageList != null) userImageList.Images.Clear();

            int count = 0;// 好友计数

            DataTable deptTable = SqlFunction.Select("SELECT dept FROM UserTable ORDER BY dept");// 先加载部门好友
            if (deptTable != null) for (int i = 0; i < deptTable.Rows.Count; i++)
                {
                    string name = deptTable.Rows[i][0].ToString().ToUpper();
                    if (DeptRepeat(name)) continue;
                    ListViewItem listViewItem = new ListViewItem();// 定义单个项目
                    listViewItem.ImageIndex = count;
                    listViewItem.Text = name;
                    listViewItem.SubItems.Add("群聊");
                    uesrListView.Items.Add(listViewItem);
                    count++;
                    ///
                    Bitmap bmp = new Bitmap(@"Image\Message\DeptOn.png");
                    userImageList.Images.Add(ImageZoom.Zoom(bmp, 48, 48));
                    bmp.Dispose();
                }

            DataTable dataTable = SqlFunction.Select("SELECT username FROM UserTable ORDER BY CAST(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(UPPER(username), 'OA','1') , 'Z','200'), 'E','30000'), 'NRIT','4000000'), 'NRI','4000000'), 'A','5000000') AS INT)");// 再加载个人好友// 查询时直接排序
            if (dataTable != null) for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string name = dataTable.Rows[i][0].ToString().ToUpper();
                    ListViewItem listViewItem = new ListViewItem();// 定义单个项目
                    listViewItem.ImageIndex = count;
                    listViewItem.Text = name;
                    listViewItem.SubItems.Add("");
                    uesrListView.Items.Add(listViewItem);
                    count++;
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
        /// 订单号
        /// </summary>
        private string orderTape;

        /// <summary>
        /// 基本后接收时间
        /// </summary>
        private DateTime lastGetTime;
        
        /// <summary>
        /// 消息集
        /// </summary>
        private List<MessageNote> messagesNotes = new List<MessageNote>();

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
            getMessageBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// 后台异步获取消息
        /// </summary>
        private void getMessageBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //string sql;
            //if (lastGetTime != null) sql = @"SELECT * FROM MessageNotes WHERE ReceiveUser='" + user.UserName + "' OR ReceiveDepartment='" + user.Dept + " WHERE SendTime>" + lastGetTime + "'";
            //else sql = @"SELECT * FROM MessageNotes WHERE ReceiveUser='" + user.UserName + "' OR ReceiveDepartment='" + user.Dept + "'";

            DataTable messageTable1 = SqlFunction.Select(@"SELECT * FROM MessageNotes WHERE ReceiveUser='" + user.UserName + "' OR ReceiveDepartment='" + user.Dept + "'");

            ///

            if (messageTable1.Rows.Count == 0)
            {
                getMessageBackgroundWorker.ReportProgress(100, "无任何消息：" + DateTime.Now.ToString());// 进度传出
                return;
            }

            for (int i = 0; i < messageTable1.Rows.Count; i++)// 拆解消息
            {
                MessageNote messageNote = new MessageNote();
                messageNote.SendUser = messageTable1.Rows[i]["SendUser"].ToString();
                messageNote.SendTime = messageTable1.Rows[i]["SendTime"].ToString();
                messageNote.SendComputer = messageTable1.Rows[i]["SendComputer"].ToString();
                messageNote.ReceiveUser = messageTable1.Rows[i]["ReceiveUser"].ToString();
                messageNote.ReceiveDepartment = messageTable1.Rows[i]["ReceiveDepartment"].ToString();
                messageNote.OrderTape = messageTable1.Rows[i]["OrderTape"].ToString();
                string[] content = messageTable1.Rows[i]["MessageContent"].ToString().Split(';');
                foreach (string str in content) messageNote.MessageContent.Add(str);
                messageNote.Reading = Convert.ToBoolean(messageTable1.Rows[i]["Reading"]);
                messageNote.ReadTime = messageTable1.Rows[i]["ReadTime"].ToString();
                messageNote.Complete = Convert.ToBoolean(messageTable1.Rows[i]["Complete"]);
                messageNote.CompleteTime = messageTable1.Rows[i]["CompleteTime"].ToString();
                messagesNotes.Add(messageNote);
            }
            
            getMessageBackgroundWorker.ReportProgress(100, "消息刷新时间：" + DateTime.Now.ToString());// 进度传出
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
        }

        #endregion 后台




        #region 按钮

        /// <summary>
        /// 发送按钮
        /// </summary>
        private void sendButton_Click(object sender, EventArgs e)
        {
            string sendUser = user.UserName;
            string sendTime = DateTime.Now.ToString();
            string sendComputer = Environment.MachineName;
            string receiveUser = null;
            string receiveDepartment = null;
            if (uesrListView.SelectedItems[0].SubItems[1].Text == "") receiveUser = uesrListView.SelectedItems[0].Text;
            else receiveDepartment = uesrListView.SelectedItems[0].Text;
            string tape = null;
            if (orderTape != null) tape = orderTape;
            string messageContent = sendTextBox.Text;
            int reading = 0;
            int complete = 0;

            SqlFunction.Insert(@"INSERT INTO MessageNotes(SendUser, SendTime, SendComputer, ReceiveUser, ReceiveDepartment, OrderTape, MessageContent, Reading, Complete) VALUES('" + sendUser + "', '" + sendTime + "', '" + sendComputer + "', '" + receiveUser + "', '" + receiveDepartment + "', '" + tape + "', '" + messageContent + "', '" + reading + "', '" + complete + "')");
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

        /// <summary>
        /// 选择好友时
        /// </summary>
        private void uesrListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uesrListView.SelectedItems.Count == 0) return;

            string g = uesrListView.SelectedItems[0].SubItems[1].Text;
            string userName = uesrListView.SelectedItems[0].Text;

            foreach (MessageNote messageNote in messagesNotes)
            {
                if (g == "群聊")
                {
                    if (messageNote.ReceiveDepartment == userName)
                    {
                        foreach (string msg in messageNote.MessageContent) { messageRichTextBox.Text = msg + System.Environment.NewLine; }
                    }
                }
                else
                {
                    if (messageNote.ReceiveUser == userName)
                    {
                        foreach (string msg in messageNote.MessageContent) { messageRichTextBox.Text = msg + System.Environment.NewLine; }
                    }
                }
            }
        }

        ///



    }
}
