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
    public partial class OrderZStatisticsForm : Form
    {
        public OrderZStatisticsForm()
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
        }
        
        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 窗口快捷键
        /// </summary>
        private void OrderZStatisticsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
            if (e.KeyCode == Keys.F5) Get();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Get();
        }

        #region 数据查询

        private void Get()
        {
            if (statisticsBackgroundWorker.IsBusy) return;// 后台是否进行中
            if (zListView.Items.Count >0) zListView.Items.Clear();// 清空
            string sql = SqlFunction.StatisticsSelect(orderStartDateTimePicker.Value.ToString(), orderEndDateTimePicker.Value.ToString(), "新数据");
            statisticsBackgroundWorker.RunWorkerAsync(sql);
        }

        #endregion 数据查询

        DataTable orderTable;
        private void statisticsBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            statisticsBackgroundWorker.ReportProgress(1, "查找中...");// 进度传出
            orderTable = SqlFunction.Select(e.Argument as string);
            if (orderTable == null || orderTable.Rows.Count == 0) return;
            statisticsBackgroundWorker.ReportProgress(Percents.Get(1, orderTable.Rows.Count), "数据处理中...");// 进度传出





            储存过程




        }

        private void statisticsBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statisticsProgressBar.Value = (e.ProgressPercentage < 101) ? e.ProgressPercentage : statisticsProgressBar.Value;
            statisticsLabel.Text = statisticsProgressBar.Value.ToString() + "% " + e.UserState as string;
        }

        private void statisticsBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)// 异步出错
            {
                MessageBox.Show("列表载入错误如下\r\n\r\n" + e.Error.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statisticsProgressBar.Value = 0;
                statisticsLabel.Text = "载入出错";
            }

            ///

            else if (e.Cancelled)// 异步取消
            {
                statisticsProgressBar.Value = 0;
                statisticsLabel.Text = "已取消载入";
            }

            ///

            else// 异步完成
            {
                if (orderTable == null || orderTable.Rows.Count == 0)// 如果没有结果
                {
                    statisticsProgressBar.Value = 100;
                    statisticsLabel.Text = "没有符合条件的结果";
                }
                else
                {
                    zListView.Visible = false;
                    for (int i = 0; i < orderTable.Rows.Count; i++)// 把项目名遍历到ListView
                    {
                        ListViewItem listViewItem = new ListViewItem();// 定义单个项目
                        listViewItem.ImageIndex = i;
                        listViewItem.Text = orderTable.Rows[i]["订单号"].ToString();
                        listViewItem.SubItems.Add(orderTable.Rows[i]["订单类型"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["紧急类别"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["最迟返回时间"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["接带人"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["接带时间"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["分带人"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["打版师"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["车版师"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["质检员"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["扫描人"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["发带人"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["发带时间"].ToString());
                        zListView.Items.Add(listViewItem);
                    }
                    statisticsProgressBar.Value = 100;
                    zListView.Visible = true;
                    statisticsLabel.Text = "查找到" + orderTable.Rows.Count + "条结果";
                }
            }

            ///

        }
    }
}
