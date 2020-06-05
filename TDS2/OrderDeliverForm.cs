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
    public partial class OrderDeliverForm : Form
    {
        public OrderDeliverForm(DataRow orderRow)
        {
            InitializeComponent();


            ///

            try// 图标
            {
                Icon = new Icon(Path.Combine(Application.StartupPath, @"Image\Skin\OrderDetails.ico"));
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

            Text = "分发订单 - " + orderRow["订单号"];

            ///

            List<string> files = OrderFiles.Get(orderRow);// 重新查找文件是因为主页是列表模式时没有搜索过文件
            bool unImage = true;// 是否搜索到图片
            foreach (string str in files)// 加载缩略图
            {
                string extension = Path.GetExtension(str).ToLower();
                if (File.Exists(str) && (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".bmp" || extension == ".gif"))// 不是图片格式时静默跳过
                {
                    Bitmap bmp = new Bitmap(str);
                    picturePanel.BackColor = bmp.GetPixel(bmp.Width - 1, bmp.Height - 1);
                    orderPictureBox.Image = bmp;
                    unImage = false;
                    break;
                }
            }
            if (unImage) orderPictureBox.Image = Image.FromFile(@"Image\Extension\UnImage.png");// 如果没有匹配到图片，加载缺失图片

            ///

            filesListView.Columns.Add("::");
            filesListView.Columns[0].Width = 600;
            for (int i = 0; i < files.Count; i++)
            {
                Image icon;
                string extension = Path.GetExtension(files[i]).ToLower();
                switch (extension)
                {
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                    case ".gif":
                    case ".bmp":
                    case ".tif":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(files[i]), 64, 64);
                            break;
                        }
                    case ".ai":
                    case ".eps":
                    case ".svg":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\ai.png"), 64, 64);
                            break;
                        }
                    case ".psd":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\psd.png"), 64, 64);
                            break;
                        }
                    case ".cdr":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\cdr.png"), 64, 64);
                            break;
                        }
                    case ".doc":
                    case ".docx":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\doc.png"), 64, 64);
                            break;
                        }
                    case ".ppt":
                    case ".pptx":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\ppt.png"), 64, 64);
                            break;
                        }
                    case ".xls":
                    case ".xlsx":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\xls.png"), 64, 64);
                            break;
                        }
                    case ".pdf":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\pdf.png"), 64, 64);
                            break;
                        }
                    case ".dst":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\dst.png"), 64, 64);
                            break;
                        }
                    case ".emb":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\emb.png"), 64, 64);
                            break;
                        }
                    case ".omf":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\omf.png"), 64, 64);
                            break;
                        }
                    case ".psf":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\psf.png"), 64, 64);
                            break;
                        }
                    case ".pxf":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\pxf.png"), 64, 64);
                            break;
                        }
                    default:
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\UnImage.png"), 64, 64);
                            break;
                        }
                }
                filesIconImageList.Images.Add(icon);
                ListViewItem listViewItem = new ListViewItem();// 定义单个项目
                listViewItem.ImageIndex = i;
                listViewItem.Text = files[i];
                filesListView.Items.Add(listViewItem);
            }
            filesListView.SmallImageList = filesIconImageList;
            filesListView.LargeImageList = filesIconImageList;

            ///

            messageListView.Columns.Add("::");
            messageListView.Columns[0].Width = 100;
            messageListView.Columns.Add("::");
            messageListView.Columns[1].Width = 150;
            
            ListViewItem OrderQuoteName = new ListViewItem();// 估针编号
            OrderQuoteName.Text = "估针编号";
            OrderQuoteName.SubItems.Add(orderRow["估针编号"].ToString());
            messageListView.Items.Add(OrderQuoteName);

            ListViewItem OrderQuoteCount = new ListViewItem();// 估针针数
            OrderQuoteCount.Text = "估针针数";
            OrderQuoteCount.SubItems.Add(orderRow["估针针数始"].ToString() + "-" + orderRow["估针针数终"].ToString());
            messageListView.Items.Add(OrderQuoteCount);

            ListViewItem OrderQuoteZ = new ListViewItem();// 估针打版师
            OrderQuoteZ.Text = "估针打版师";
            OrderQuoteZ.SubItems.Add(orderRow["估针打版师"].ToString());
            messageListView.Items.Add(OrderQuoteZ);

            ListViewItem EmbWidth = new ListViewItem();// 版带宽
            EmbWidth.Text = "版带宽";
            EmbWidth.SubItems.Add(orderRow["版带宽"].ToString());
            messageListView.Items.Add(EmbWidth);

            ListViewItem EmbHeight = new ListViewItem();// 版带高
            EmbHeight.Text = "版带高";
            EmbHeight.SubItems.Add(orderRow["版带高"].ToString());
            messageListView.Items.Add(EmbHeight);

            ListViewItem EmbPosition = new ListViewItem();// 面料或位置
            EmbPosition.Text = "面料或位置";
            EmbPosition.SubItems.Add(orderRow["面料或位置"].ToString());
            messageListView.Items.Add(EmbPosition);

            ListViewItem EmbOriginalZ = new ListViewItem();// 原打版师
            EmbOriginalZ.Text = "原版打版师";
            EmbOriginalZ.SubItems.Add(orderRow["原版打版师"].ToString());
            messageListView.Items.Add(EmbOriginalZ);

            ///

            otherListView.Columns.Add("::");
            otherListView.Columns[0].Width = 120;
            otherListView.Columns.Add("::");
            otherListView.Columns[1].Width = Width - 420;

            ListViewItem OrderDescription = new ListViewItem();// 订单说明
            OrderDescription.Text = "订单说明";
            OrderDescription.SubItems.Add(orderRow["订单说明"].ToString());
            otherListView.Items.Add(OrderDescription);

            ListViewItem zDescription = new ListViewItem();// 打版师
            zDescription.Text = "打版师注意事项";
            zDescription.SubItems.Add(orderRow["打版师注意事项"].ToString());
            otherListView.Items.Add(zDescription);

            ListViewItem eDescription = new ListViewItem();// 车版师
            eDescription.Text = "车版师注意事项";
            eDescription.SubItems.Add(orderRow["车版师注意事项"].ToString());
            otherListView.Items.Add(eDescription);

            ///

            GetZList();
            
        }

        /// <summary>
        /// 获取好友列表
        /// </summary>
        private void GetZList()
        {
            if (zListView != null) zListView.Items.Clear();
            if (zImageList != null) zImageList.Images.Clear();

            DataTable dataTable = SqlFunction.Select("SELECT username FROM UserTable WHERE dept='Z' ORDER BY CAST(REPLACE(UPPER(username), 'Z','100') AS INT)");// 再加载个人好友// 查询时直接排序
            if (dataTable != null) for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string name = dataTable.Rows[i][0].ToString().ToUpper();
                    ListViewItem listViewItem = new ListViewItem();// 定义单个项目
                    listViewItem.ImageIndex = i;
                    listViewItem.Text = name;
                    zListView.Items.Add(listViewItem);
                    ///
                    Bitmap bmp = new Bitmap(@"Image\Message\UserOn.png");
                    zImageList.Images.Add(ImageZoom.Zoom(bmp, 32, 32));
                    bmp.Dispose();
                }

            zListView.LargeImageList = zImageList;
        }

        /// <summary>
        /// 选择项目时
        /// </summary>
        private void filesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filesListView.SelectedItems.Count > 0)
            {
                string extension = Path.GetExtension(filesListView.SelectedItems[0].Text).ToLower();
                switch (extension)
                {
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                    case ".gif":
                    case ".bmp":
                    case ".tif":
                        {
                            orderPictureBox.Image = Image.FromFile(filesListView.SelectedItems[0].Text);
                            Bitmap bmp = new Bitmap(filesListView.SelectedItems[0].Text);
                            picturePanel.BackColor = bmp.GetPixel(bmp.Width - 1, bmp.Height - 1);
                            break;
                        }
                    default:
                        {
                            orderPictureBox.Image = Image.FromFile(@"Image\Extension\UnImage.png");
                            Bitmap bmp = new Bitmap(@"Image\Extension\UnImage.png");
                            picturePanel.BackColor = bmp.GetPixel(bmp.Width - 1, bmp.Height - 1);
                            break;
                        }
                }
            }
        }

        private void OrderDeliverForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3) Close();
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void OrderDeliverForm_Resize(object sender, EventArgs e)
        {
            otherListView.Columns[1].Width = Width - 420;
        }
    }
}
