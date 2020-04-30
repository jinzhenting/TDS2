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
        public OrderDetails(DataRow orderRow, DiskList diskList)
        {
            InitializeComponent();

            ///

            try// 图标
            {
                Icon = new Icon(Path.Combine(Application.StartupPath, @"Image\OrderDetails.ico"));
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
            
            List<string> files = OrderFiles.Get(orderRow, diskList);
            bool unImage = true;// 是否搜索到图片
            foreach (string str in files)// 加载缩略图
            {
                string extension = Path.GetExtension(str).ToLower();
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".bmp" || extension == ".gif")
                {
                    Bitmap bmp = new Bitmap(str);
                    picturePanel.BackColor = bmp.GetPixel(bmp.Width - 1, bmp.Height - 1);
                    orderPictureBox.Image = bmp;
                    unImage = false;
                    break;
                }
            }
            if (unImage) orderPictureBox.Image = Image.FromFile(@"Image\UnImage.png");// 如果没有匹配到图片，加载缺失图片

            ///

            //orderListView.Columns.Add("::");
            //orderListView.Columns.Add("::");
            //orderListView.Columns[0].Width = 90;

            //ListViewItem OrderCustomer = new ListViewItem();// 订单
            //OrderCustomer.Text = "客户";
            //OrderCustomer.SubItems.Add(orderRow.OrderCustomer);
            //orderListView.Items.Add(OrderCustomer);

            //ListViewItem OrderInTime = new ListViewItem();// 业务接单时间
            //OrderInTime.Text = "业务接单时间";
            //OrderInTime.SubItems.Add(Convert.ToString(orderRow.OrderInTime));
            //orderListView.Items.Add(OrderInTime);

            //ListViewItem OrderClass = new ListViewItem();// 订单类型
            //OrderClass.Text = "订单类型";
            //OrderClass.SubItems.Add(orderRow.OrderClass);
            //orderListView.Items.Add(OrderClass);

            //ListViewItem OrderUrgency = new ListViewItem();// 度急度
            //OrderUrgency.Text = "度急度";
            //OrderUrgency.SubItems.Add(orderRow.OrderUrgency);
            //orderListView.Items.Add(OrderUrgency);

            //ListViewItem OrderLatestReturnTime = new ListViewItem();// 此时间内返回
            //OrderLatestReturnTime.Text = "此时间内返回";
            //OrderLatestReturnTime.SubItems.Add(Convert.ToString(orderRow.OrderLatestReturnTime));
            //orderListView.Items.Add(OrderLatestReturnTime);

            //ListViewItem OrderLastModiTime = new ListViewItem();// 订单修改时间
            //OrderLastModiTime.Text = "订单修改时间";
            //OrderLastModiTime.SubItems.Add(Convert.ToString(orderRow.OrderLastModiTime));
            //orderListView.Items.Add(OrderLastModiTime);

            //ListViewItem OrderComputer = new ListViewItem();// 订单电脑
            //OrderComputer.Text = "订单电脑";
            //OrderComputer.SubItems.Add(orderRow.OrderComputer);
            //orderListView.Items.Add(OrderComputer);

            //ListViewItem NrInQC = new ListViewItem();// 接带人
            //NrInQC.Text = "接带人";
            //NrInQC.SubItems.Add(orderRow.NrInQC);
            //orderListView.Items.Add(NrInQC);

            //ListViewItem NrInShift = new ListViewItem();// 接带班次
            //NrInShift.Text = "接带班次";
            //NrInShift.SubItems.Add(orderRow.NrInShift);
            //orderListView.Items.Add(NrInShift);

            //ListViewItem NrInComputer = new ListViewItem();// 接带计算机
            //NrInComputer.Text = "接带计算机";
            //NrInComputer.SubItems.Add(orderRow.NrInComputer);
            //orderListView.Items.Add(NrInComputer);

            //ListViewItem NrInTime = new ListViewItem();// 接带时间
            //NrInTime.Text = "接带时间";
            //NrInTime.SubItems.Add(Convert.ToString(orderRow.NrInTime));
            //orderListView.Items.Add(NrInTime);

            //ListViewItem EmbManager = new ListViewItem();// 分带人员
            //EmbManager.Text = "分带人员";
            //EmbManager.SubItems.Add(orderRow.EmbManager);
            //orderListView.Items.Add(EmbManager);

            //ListViewItem OrderDifficulty = new ListViewItem();// 打版难度
            //OrderDifficulty.Text = "打版难度";
            //OrderDifficulty.SubItems.Add(orderRow.OrderDifficulty);
            //orderListView.Items.Add(OrderDifficulty);

            //ListViewItem EmbClass = new ListViewItem();// 图案风格
            //EmbClass.Text = "图案风格";
            //EmbClass.SubItems.Add(orderRow.EmbClass);
            //orderListView.Items.Add(EmbClass);

            //ListViewItem OrderQuantity = new ListViewItem();// 订单含版带数
            //OrderQuantity.Text = "订单含版带数";
            //OrderQuantity.SubItems.Add(Convert.ToString(orderRow.OrderQuantity));
            //orderListView.Items.Add(OrderQuantity);

            //ListViewItem OrderReturnFormat = new ListViewItem();// 返回文件格式
            //OrderReturnFormat.Text = "返回文件格式";
            //OrderReturnFormat.SubItems.Add(orderRow.OrderReturnFormat);
            //orderListView.Items.Add(OrderReturnFormat);


            //#region 未有字段
            //ListViewItem EmbWidth = new ListViewItem();// 版带宽
            //EmbWidth.Text = "版带宽";
            //EmbWidth.SubItems.Add("数据库无此字段");
            //orderListView.Items.Add(EmbWidth);

            //ListViewItem EmbHeight = new ListViewItem();// 版带高
            //EmbHeight.Text = "版带高";
            //EmbHeight.SubItems.Add("数据库无此字段");
            //orderListView.Items.Add(EmbHeight);

            //ListViewItem EmbPosition = new ListViewItem();// 面料或位置
            //EmbPosition.Text = "面料或位置";
            //EmbPosition.SubItems.Add("数据库无此字段");
            //orderListView.Items.Add(EmbPosition);

            //ListViewItem OrderQuoteName = new ListViewItem();// 估针编号
            //OrderQuoteName.Text = "估针编号";
            //OrderQuoteName.SubItems.Add("数据库无此字段");
            //orderListView.Items.Add(OrderQuoteName);

            //ListViewItem OrderQuoteCount = new ListViewItem();// 估针针数
            //OrderQuoteCount.Text = "估针针数";
            //OrderQuoteCount.SubItems.Add("数据库无此字段");
            //orderListView.Items.Add(OrderQuoteCount);

            //ListViewItem OrderQuoteZ = new ListViewItem();// 估针打版师
            //OrderQuoteZ.Text = "估针打版师";
            //OrderQuoteZ.SubItems.Add("数据库无此字段");
            //orderListView.Items.Add(OrderQuoteZ);
            //#endregion 未有字段

            //ListViewItem EmbOriginalZ = new ListViewItem();// 原打版师
            //EmbOriginalZ.Text = "原版打版师";
            //EmbOriginalZ.SubItems.Add(orderRow.EmbOriginalZ);
            //orderListView.Items.Add(EmbOriginalZ);

            //ListViewItem EmbZ = new ListViewItem();// 打版师
            //EmbZ.Text = "打版师";
            //EmbZ.SubItems.Add(orderRow.EmbZ);
            //orderListView.Items.Add(EmbZ);

            //ListViewItem EmbZShift = new ListViewItem();// 打版班次
            //EmbZShift.Text = "打版班次";
            //EmbZShift.SubItems.Add(orderRow.EmbZShift);
            //orderListView.Items.Add(EmbZShift);

            //ListViewItem EmbZStartTime = new ListViewItem();// 打版开始时间
            //EmbZStartTime.Text = "打版开始时间";
            //EmbZStartTime.SubItems.Add(Convert.ToString(orderRow.EmbZStartTime));
            //orderListView.Items.Add(EmbZStartTime);

            //ListViewItem EmbZEndTime = new ListViewItem();// 打版完成时间
            //EmbZEndTime.Text = "打版完成时间";
            //EmbZEndTime.SubItems.Add(Convert.ToString(orderRow.EmbZEndTime));
            //orderListView.Items.Add(EmbZEndTime);

            //ListViewItem EmbZCount = new ListViewItem();// 打版师针数
            //EmbZCount.Text = "打版师针数";
            //EmbZCount.SubItems.Add(Convert.ToString(orderRow.EmbZCount));
            //orderListView.Items.Add(EmbZCount);

            //ListViewItem EmbCount = new ListViewItem();// 总针数
            //EmbCount.Text = "总针数";
            //EmbCount.SubItems.Add(Convert.ToString(orderRow.EmbCount));
            //orderListView.Items.Add(EmbCount);

            //ListViewItem EmbChargesCount = new ListViewItem();// 收费针数
            //EmbChargesCount.Text = "收费针数";
            //EmbChargesCount.SubItems.Add(Convert.ToString(orderRow.EmbChargesCount));
            //orderListView.Items.Add(EmbChargesCount);

            //ListViewItem EmbSewout = new ListViewItem();// 是否车版
            //EmbSewout.Text = "是否车版";
            //if (orderRow.EmbSewout) EmbSewout.SubItems.Add("是"); else EmbSewout.SubItems.Add("否");
            //orderListView.Items.Add(EmbSewout);

            //ListViewItem EmbE = new ListViewItem();// 车版师
            //EmbE.Text = "车版师";
            //EmbE.SubItems.Add(orderRow.EmbE);
            //orderListView.Items.Add(EmbE);

            //ListViewItem EmbEEndTime = new ListViewItem();// 车版完成时间
            //EmbEEndTime.Text = "车版完成时间";
            //EmbEEndTime.SubItems.Add(Convert.ToString(orderRow.EmbEEndTime));
            //orderListView.Items.Add(EmbEEndTime);

            //ListViewItem EmbSewingMachine = new ListViewItem();// 车版机器编号
            //EmbSewingMachine.Text = "车版机器编号";
            //EmbSewingMachine.SubItems.Add(orderRow.EmbSewingMachine);
            //orderListView.Items.Add(EmbSewingMachine);

            //ListViewItem EmbReSewoutCount = new ListViewItem();// 重新车版次数
            //EmbReSewoutCount.Text = "重新车版次数";
            //EmbReSewoutCount.SubItems.Add(Convert.ToString(orderRow.EmbReSewoutCount));
            //orderListView.Items.Add(EmbReSewoutCount);

            //ListViewItem EmbQi = new ListViewItem();// 质检人
            //EmbQi.Text = "质检人";
            //EmbQi.SubItems.Add(orderRow.EmbQi);
            //orderListView.Items.Add(EmbQi);

            //ListViewItem EmbQualityLevel = new ListViewItem();// 质量问题等级
            //EmbQualityLevel.Text = "质量问题等级";
            //EmbQualityLevel.SubItems.Add(orderRow.EmbQualityLevel);
            //orderListView.Items.Add(EmbQualityLevel);
            
            //ListViewItem EmbScaner = new ListViewItem();// 扫描人
            //EmbScaner.Text = "扫描人";
            //EmbScaner.SubItems.Add(orderRow.EmbScaner);
            //orderListView.Items.Add(EmbScaner);

            //ListViewItem EmbScanerTime = new ListViewItem();// 扫描完成时间
            //EmbScanerTime.Text = "扫描完成时间";
            //EmbScanerTime.SubItems.Add(Convert.ToString(orderRow.EmbScanerTime));
            //orderListView.Items.Add(EmbScanerTime);

            //ListViewItem NrOutQc = new ListViewItem();// 发带人
            //NrOutQc.Text = "发带人";
            //NrOutQc.SubItems.Add(orderRow.NrOutQc);
            //orderListView.Items.Add(NrOutQc);

            //ListViewItem NrOutShift = new ListViewItem();// 发带班次
            //NrOutShift.Text = "发带班次";
            //NrOutShift.SubItems.Add(orderRow.NrOutShift);
            //orderListView.Items.Add(NrOutShift);

            //ListViewItem NrOutTime = new ListViewItem();// 发带时间
            //NrOutTime.Text = "发带时间";
            //NrOutTime.SubItems.Add(Convert.ToString(orderRow.NrOutTime));
            //orderListView.Items.Add(NrOutTime);

            //orderListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            /////

            //otherListView.Columns.Add("::");
            //otherListView.Columns.Add("::");
            //otherListView.Columns[0].Width = 100;

            //ListViewItem OrderDescription = new ListViewItem();// 订单说明
            //OrderDescription.Text = "订单说明";
            //OrderDescription.SubItems.Add(orderRow.OrderDescription);
            //otherListView.Items.Add(OrderDescription);

            //#region 未有字段
            //ListViewItem zDescription = new ListViewItem();// 打版师
            //zDescription.Text = "打版师注意事项";
            //zDescription.SubItems.Add("数据库无此字段");
            //otherListView.Items.Add(zDescription);

            //ListViewItem eDescription = new ListViewItem();// 车版师
            //eDescription.Text = "车版师注意事项";
            //eDescription.SubItems.Add("数据库无此字段");
            //otherListView.Items.Add(eDescription);
            //#endregion 未有字段

            //otherListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
