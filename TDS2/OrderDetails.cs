using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TDS2
{
    public partial class OrderDetails : Form
    {
        public OrderDetails(DataRow orderRow)
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

            Text = "订单 - " + orderRow["订单号"] + " - 的详细信息";

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

            orderListView.Columns.Add("::");
            orderListView.Columns.Add("::");
            orderListView.Columns[0].Width = 90;

            ListViewItem OrderCustomer = new ListViewItem();// 订单
            OrderCustomer.Text = "客户";
            OrderCustomer.SubItems.Add(orderRow["客户"].ToString());
            orderListView.Items.Add(OrderCustomer);

            ListViewItem OrderInTime = new ListViewItem();// 业务接单时间
            OrderInTime.Text = "接单时间";
            OrderInTime.SubItems.Add(orderRow["接单时间"].ToString());
            orderListView.Items.Add(OrderInTime);

            ListViewItem OrderClass = new ListViewItem();// 订单类型
            OrderClass.Text = "订单类型";
            OrderClass.SubItems.Add(orderRow["订单类型"].ToString());
            orderListView.Items.Add(OrderClass);

            ListViewItem OrderUrgency = new ListViewItem();// 度急度
            OrderUrgency.Text = "紧急类别";
            OrderUrgency.SubItems.Add(orderRow["紧急类别"].ToString());
            orderListView.Items.Add(OrderUrgency);

            ListViewItem OrderLatestReturnTime = new ListViewItem();// 此时间内返回
            OrderLatestReturnTime.Text = "最迟返回时间";
            OrderLatestReturnTime.SubItems.Add(orderRow["最迟返回时间"].ToString());
            orderListView.Items.Add(OrderLatestReturnTime);

            ListViewItem OrderLastModiTime = new ListViewItem();// 订单修改时间
            OrderLastModiTime.Text = "订单修改时间";
            OrderLastModiTime.SubItems.Add(orderRow["订单修改时间"].ToString());
            orderListView.Items.Add(OrderLastModiTime);

            ListViewItem OrderComputer = new ListViewItem();// 订单电脑
            OrderComputer.Text = "订单电脑";
            OrderComputer.SubItems.Add(orderRow["订单电脑"].ToString());
            orderListView.Items.Add(OrderComputer);

            ListViewItem NrInQC = new ListViewItem();// 接带人
            NrInQC.Text = "接带人";
            NrInQC.SubItems.Add(orderRow["接带人"].ToString());
            orderListView.Items.Add(NrInQC);

            ListViewItem NrInShift = new ListViewItem();// 接带班次
            NrInShift.Text = "接带班次";
            NrInShift.SubItems.Add(orderRow["接带班次"].ToString());
            orderListView.Items.Add(NrInShift);

            ListViewItem NrInComputer = new ListViewItem();// 接带计算机
            NrInComputer.Text = "接带计算机";
            NrInComputer.SubItems.Add(orderRow["接带计算机"].ToString());
            orderListView.Items.Add(NrInComputer);

            ListViewItem NrInTime = new ListViewItem();// 接带时间
            NrInTime.Text = "接带时间";
            NrInTime.SubItems.Add(orderRow["接带时间"].ToString());
            orderListView.Items.Add(NrInTime);

            ListViewItem EmbManager = new ListViewItem();// 分带人员
            EmbManager.Text = "分带人";
            EmbManager.SubItems.Add(orderRow["分带人"].ToString());
            orderListView.Items.Add(EmbManager);

            ListViewItem EmbClass = new ListViewItem();// 图案风格
            EmbClass.Text = "图案风格";
            EmbClass.SubItems.Add(orderRow["图案风格"].ToString());
            orderListView.Items.Add(EmbClass);

            ListViewItem OrderQuantity = new ListViewItem();// 订单含版带数
            OrderQuantity.Text = "订单含版带数";
            OrderQuantity.SubItems.Add(orderRow["订单含版带数"].ToString());
            orderListView.Items.Add(OrderQuantity);

            ListViewItem OrderReturnFormat = new ListViewItem();// 返回文件格式
            OrderReturnFormat.Text = "返回文件格式";
            OrderReturnFormat.SubItems.Add(orderRow["返回文件格式"].ToString());
            orderListView.Items.Add(OrderReturnFormat);
            
            ListViewItem OrderDifficulty = new ListViewItem();// 打版难度
            OrderDifficulty.Text = "打版难度";
            OrderDifficulty.SubItems.Add(orderRow["打版难度"].ToString());
            orderListView.Items.Add(OrderDifficulty);
            
            ListViewItem OrderQuoteName = new ListViewItem();// 估针编号
            OrderQuoteName.Text = "估针编号";
            OrderQuoteName.SubItems.Add(orderRow["估针编号"].ToString());
            orderListView.Items.Add(OrderQuoteName);

            ListViewItem OrderQuoteCount = new ListViewItem();// 估针针数
            OrderQuoteCount.Text = "估针针数";
            OrderQuoteCount.SubItems.Add(orderRow["估针针数始"].ToString()+"-"+ orderRow["估针针数终"].ToString());
            orderListView.Items.Add(OrderQuoteCount);

            ListViewItem OrderQuoteZ = new ListViewItem();// 估针打版师
            OrderQuoteZ.Text = "估针打版师";
            OrderQuoteZ.SubItems.Add(orderRow["估针打版师"].ToString());
            orderListView.Items.Add(OrderQuoteZ);

            ListViewItem EmbWidth = new ListViewItem();// 版带宽
            EmbWidth.Text = "版带宽";
            EmbWidth.SubItems.Add(orderRow["版带宽"].ToString());
            orderListView.Items.Add(EmbWidth);

            ListViewItem EmbHeight = new ListViewItem();// 版带高
            EmbHeight.Text = "版带高";
            EmbHeight.SubItems.Add(orderRow["版带高"].ToString());
            orderListView.Items.Add(EmbHeight);

            ListViewItem EmbPosition = new ListViewItem();// 面料或位置
            EmbPosition.Text = "面料或位置";
            EmbPosition.SubItems.Add(orderRow["面料或位置"].ToString());
            orderListView.Items.Add(EmbPosition);
            
            ListViewItem EmbOriginalZ = new ListViewItem();// 原打版师
            EmbOriginalZ.Text = "原版打版师";
            EmbOriginalZ.SubItems.Add(orderRow["原版打版师"].ToString());
            orderListView.Items.Add(EmbOriginalZ);

            ListViewItem EmbZ = new ListViewItem();// 打版师
            EmbZ.Text = "打版师";
            EmbZ.SubItems.Add(orderRow["打版师"].ToString());
            orderListView.Items.Add(EmbZ);

            ListViewItem EmbZShift = new ListViewItem();// 打版班次
            EmbZShift.Text = "打版班次";
            EmbZShift.SubItems.Add(orderRow["打版班次"].ToString());
            orderListView.Items.Add(EmbZShift);

            ListViewItem EmbZStartTime = new ListViewItem();// 打版开始时间
            EmbZStartTime.Text = "打版开始时间";
            EmbZStartTime.SubItems.Add(orderRow["打版开始时间"].ToString());
            orderListView.Items.Add(EmbZStartTime);

            ListViewItem EmbZEndTime = new ListViewItem();// 打版完成时间
            EmbZEndTime.Text = "打版完成时间";
            EmbZEndTime.SubItems.Add(orderRow["打版完成时间"].ToString());
            orderListView.Items.Add(EmbZEndTime);

            ListViewItem EmbZCount = new ListViewItem();// 打版师针数
            EmbZCount.Text = "打版师针数";
            EmbZCount.SubItems.Add(orderRow["打版师针数"].ToString());
            orderListView.Items.Add(EmbZCount);

            ListViewItem EmbCount = new ListViewItem();// 总针数
            EmbCount.Text = "总针数";
            EmbCount.SubItems.Add(orderRow["总针数"].ToString());
            orderListView.Items.Add(EmbCount);

            ListViewItem EmbChargesCount = new ListViewItem();// 收费针数
            EmbChargesCount.Text = "收费针数";
            EmbChargesCount.SubItems.Add(orderRow["收费针数"].ToString());
            orderListView.Items.Add(EmbChargesCount);

            ListViewItem EmbSewout = new ListViewItem();// 是否车版
            EmbSewout.Text = "是否车版";
            EmbSewout.SubItems.Add(orderRow["是否车版"].ToString());
            orderListView.Items.Add(EmbSewout);

            ListViewItem EmbE = new ListViewItem();// 车版师
            EmbE.Text = "车版师";
            EmbE.SubItems.Add(orderRow["车版师"].ToString());
            orderListView.Items.Add(EmbE);

            ListViewItem EmbEEndTime = new ListViewItem();// 车版完成时间
            EmbEEndTime.Text = "车版完成时间";
            EmbEEndTime.SubItems.Add(orderRow["车版完成时间"].ToString());
            orderListView.Items.Add(EmbEEndTime);

            ListViewItem EmbSewingMachine = new ListViewItem();// 车版机器编号
            EmbSewingMachine.Text = "车版机器编号";
            EmbSewingMachine.SubItems.Add(orderRow["车版机器编号"].ToString());
            orderListView.Items.Add(EmbSewingMachine);

            ListViewItem EmbReSewoutCount = new ListViewItem();// 重新车版次数
            EmbReSewoutCount.Text = "重新车版次数";
            EmbReSewoutCount.SubItems.Add(orderRow["重新车版次数"].ToString());
            orderListView.Items.Add(EmbReSewoutCount);

            ListViewItem EmbQi = new ListViewItem();// 质检人
            EmbQi.Text = "质检员";
            EmbQi.SubItems.Add(orderRow["质检员"].ToString());
            orderListView.Items.Add(EmbQi);

            ListViewItem EmbQualityLevel = new ListViewItem();// 质量问题等级
            EmbQualityLevel.Text = "质量问题等级";
            EmbQualityLevel.SubItems.Add(orderRow["质量问题等级"].ToString());
            orderListView.Items.Add(EmbQualityLevel);

            ListViewItem EmbScaner = new ListViewItem();// 扫描人
            EmbScaner.Text = "扫描人";
            EmbScaner.SubItems.Add(orderRow["扫描人"].ToString());
            orderListView.Items.Add(EmbScaner);

            ListViewItem EmbScanerTime = new ListViewItem();// 扫描完成时间
            EmbScanerTime.Text = "扫描完成时间";
            EmbScanerTime.SubItems.Add(orderRow["扫描完成时间"].ToString());
            orderListView.Items.Add(EmbScanerTime);

            ListViewItem NrOutQc = new ListViewItem();// 发带人
            NrOutQc.Text = "发带人";
            NrOutQc.SubItems.Add(orderRow["发带人"].ToString());
            orderListView.Items.Add(NrOutQc);

            ListViewItem NrOutShift = new ListViewItem();// 发带班次
            NrOutShift.Text = "发带班次";
            NrOutShift.SubItems.Add(orderRow["发带班次"].ToString());
            orderListView.Items.Add(NrOutShift);

            ListViewItem NrOutTime = new ListViewItem();// 发带时间
            NrOutTime.Text = "发带时间";
            NrOutTime.SubItems.Add(orderRow["发带时间"].ToString());
            orderListView.Items.Add(NrOutTime);

            orderListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);

            ///

            otherListView.Columns.Add("::");
            otherListView.Columns.Add("::");
            otherListView.Columns[0].Width = 100;

            ListViewItem OrderDescription = new ListViewItem();// 打带说明
            OrderDescription.Text = "打带说明";
            OrderDescription.SubItems.Add(orderRow["打带说明"].ToString());
            otherListView.Items.Add(OrderDescription);
            
            ListViewItem zDescription = new ListViewItem();// 打版师
            zDescription.Text = "打版师注意事项";
            zDescription.SubItems.Add(orderRow["打版师注意事项"].ToString());
            otherListView.Items.Add(zDescription);

            ListViewItem eDescription = new ListViewItem();// 车版师
            eDescription.Text = "车版师注意事项";
            eDescription.SubItems.Add(orderRow["车版师注意事项"].ToString());
            otherListView.Items.Add(eDescription);

            ListViewItem otherSuggest = new ListViewItem();// 车版师
            otherSuggest.Text = "建议及其他";
            otherSuggest.SubItems.Add(orderRow["建议及其他"].ToString());
            otherListView.Items.Add(otherSuggest);

            otherListView.Columns[1].Width = Width - 390;

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

        /// <summary>
        /// 窗口快捷键
        /// </summary>
        private void OrderDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Close();
            if (e.KeyCode == Keys.Escape) Close();
            if (e.KeyCode == Keys.Space) Close();
        }

        private void OrderDetails_Resize(object sender, EventArgs e)
        {
            otherListView.Columns[1].Width = Width - 390;
        }

        ///


    }
}
