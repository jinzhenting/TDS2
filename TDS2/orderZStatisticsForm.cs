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
            orderStartDateTimePicker.Value = DateTime.Now.AddDays(-1);
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

            Get();
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
            if (zListView.Items.Count > 0) zListView.Items.Clear();// 清空
            if (typeListView.Items.Count > 0) zListView.Items.Clear();// 清空
            
            string sql = SqlFunction.StatisticsSelect(orderStartDateTimePicker.Value.ToString(), orderEndDateTimePicker.Value.ToString());
            statisticsBackgroundWorker.RunWorkerAsync(sql);
        }

        #endregion 数据查询

        /// <summary>
        /// 
        /// </summary>
        private void statisticsBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            statisticsBackgroundWorker.ReportProgress(1, "查找中...");// 进度传出
            DataTable sqlTable = SqlFunction.Select(e.Argument as string);
            if (sqlTable == null || sqlTable.Rows.Count == 0) return;// 无结果
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("打版师");
            dataTable.Columns.Add("已分带子数");
            dataTable.Columns.Add("完成带子数");
            dataTable.Columns.Add("已分针数");
            dataTable.Columns.Add("完成针数");
            dataTable.Columns.Add("完成针数");
            dataTable.Columns.Add("预计完成时间");
            dataTable.Columns.Add("历史效率");
            dataTable.Columns.Add("当天效率");
            dataTable.Columns.Add("历史出错率");

            ///

            bool existZ;
            for (int i = 0; i < sqlTable.Rows.Count; i++)
            {
                statisticsBackgroundWorker.ReportProgress(Percents.Get(i, sqlTable.Rows.Count), "数据处理中...");// 进度传出

                existZ = false;
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["打版师"].ToString().ToUpper() == sqlTable.Rows[i]["打版师"].ToString().ToUpper())// 已有此打版师数据行
                    {
                        row["已分带子数"] = Convert.ToInt32(row["已分带子数"]) + 1;
                        int statr = sqlTable.Rows[i]["估针数始"].ToString() == "" ? 0 : Convert.ToInt32(sqlTable.Rows[i]["估针数始"]);
                        int end = sqlTable.Rows[i]["估针数终"].ToString() == "" ? 0 : Convert.ToInt32(sqlTable.Rows[i]["估针数终"]);
                        row["已分针数"] = Convert.ToInt32(row["已分针数"]) + (statr + end) / 2;
                        existZ = true;
                        break;
                    }
                }
                
                if (!existZ)/// 没有此打版师数据行
                {
                    DataRow rows = dataTable.NewRow();
                    rows["打版师"] = sqlTable.Rows[i]["打版师"].ToString().ToUpper();
                    rows["已分带子数"] = 1;

                    做到这里



                    rows["完成带子数"] = "未设定";
                    int statr = sqlTable.Rows[i]["估针数始"].ToString() == "" ? 0 : Convert.ToInt32(sqlTable.Rows[i]["估针数始"]);
                    int end = sqlTable.Rows[i]["估针数终"].ToString() == "" ? 0 : Convert.ToInt32(sqlTable.Rows[i]["估针数终"]);
                    rows["已分针数"] = (statr + end) / 2;
                    rows["完成针数"] = "未设定";
                    rows["预计完成时间"] = "未设定";
                    rows["历史效率"] = "未设定";
                    rows["当天效率"] = "未设定";
                    rows["历史出错率"] = "未设定";
                    dataTable.Rows.Add(rows);
                }
            }

            ///

            e.Result = dataTable;
        }

        /// <summary>
        /// 
        /// </summary>
        private void statisticsBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statisticsProgressBar.Value = (e.ProgressPercentage < 101) ? e.ProgressPercentage : statisticsProgressBar.Value;
            statisticsLabel.Text = statisticsProgressBar.Value.ToString() + "% " + e.UserState as string;
        }

        /// <summary>
        /// 
        /// </summary>
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
                DataTable orderTable = e.Result as DataTable;
                if (orderTable == null || orderTable.Rows.Count == 0)// 如果没有结果
                {
                    statisticsProgressBar.Value = 100;
                    statisticsLabel.Text = "没有打版师在线";
                }
                else
                {
                    zListView.Visible = false;
                    for (int i = 0; i < orderTable.Rows.Count; i++)// 把项目名遍历到ListView
                    {
                        ListViewItem listViewItem = new ListViewItem();// 定义单个项目
                        listViewItem.ImageIndex = i;
                        listViewItem.Text = orderTable.Rows[i]["打版师"].ToString();
                        listViewItem.SubItems.Add(orderTable.Rows[i]["已分带子数"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["已分针数"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["预计完成时间"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["历史效率"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["当天效率"].ToString());
                        listViewItem.SubItems.Add(orderTable.Rows[i]["历史出错率"].ToString());
                        zListView.Items.Add(listViewItem);
                    }
                    statisticsProgressBar.Value = 100;
                    zListView.Visible = true;
                    statisticsLabel.Text = "共" + orderTable.Rows.Count + "个打版在线";
                }
            }

            ///

        }
    }
}
