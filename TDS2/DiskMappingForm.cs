using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TDS2
{
    public partial class DiskMappingForm : Form
    {
        public DiskMappingForm()
        {
            InitializeComponent();
            try// 图标
            {
                Icon = new Icon(Path.Combine(Application.StartupPath, @"Image\DiskMapping.ico"));
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

            LoadListView();
            MappingStart();
            mappingTimer.Start();
        }

        /// <summary>
        /// 重新载入列表
        /// </summary>
        private void LoadListView()
        {
            if (diskListView.Items.Count > 0) diskListView.Items.Clear();
            foreach (Disk disk in DiskList.Get())// 遍历磁盘列表到ListView
            {
                ListViewItem item = new ListViewItem();
                item.Text = disk.Name;
                item.SubItems.Add(disk.NetPath);
                item.SubItems.Add(disk.LocalPath);
                item.SubItems.Add(disk.AutoMapping);
                item.SubItems.Add(disk.WindowsAccount);
                item.SubItems.Add(disk.Forever);
                item.SubItems.Add(disk.AutoCheck);
                item.SubItems.Add("");
                item.SubItems.Add(disk.UserName);
                item.SubItems.Add(disk.Password);
                diskListView.Items.Add(item);
            }
        }

        private void mappingBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            mappingBackgroundWorker.ReportProgress(1, "磁盘映射中...");// 进度传出

            DataTable dataTable = e.Argument as DataTable;
            string[] logs = new string[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (mappingBackgroundWorker.CancellationPending)// 取消检测
                {
                    e.Cancel = true;
                    return;
                }
                
                mappingBackgroundWorker.ReportProgress(Percents.Get(1, dataTable.Rows.Count), "正在映射：" + dataTable.Rows[i][0].ToString());// 进度传出

                string autoMapping = dataTable.Rows[i][3].ToString();
                if (autoMapping == "否")
                {
                    logs[i] = "未启用自动映射 - " + DateTime.Now.ToString();
                    continue;
                }

                string autoCheck = dataTable.Rows[i][6].ToString();
                if (autoCheck == "否")
                {
                    logs[i] = "未启用断开检测 - " + DateTime.Now.ToString();
                    continue;
                }

                string localPath = dataTable.Rows[i][2].ToString();
                if (Directory.Exists(localPath))
                {
                    logs[i] = "盘符已存在，跳过映射 - " + DateTime.Now.ToString();
                    continue;
                }

                string netPath = dataTable.Rows[i][1].ToString();
                if (!Directory.Exists(netPath))
                {
                    logs[i] = "网络位置无法访问，跳过映射 - " + DateTime.Now.ToString();
                    continue;
                }

                string userName = dataTable.Rows[i][8].ToString();
                string password = dataTable.Rows[i][9].ToString();
                uint constflags = userName == "" ? (uint)0 : (uint)0;
                logs[i] = Mapping(localPath, netPath, userName, password, constflags);// 映射
            }

            e.Result = logs;
        }

        private void mappingBackgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            diskProgressBar.Value = (e.ProgressPercentage < 101) ? e.ProgressPercentage : diskProgressBar.Value;
            diskProgressLabel.Text = diskProgressBar.Value.ToString() + "% " + e.UserState as string;
        }

        private void mappingBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            mappingButton.Enabled = breakButton.Enabled = true;

            if (e.Error != null)
            {
                MessageBox.Show("后台映射错误如下\r\n\r\n" + e.Error.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                diskProgressBar.Value = 0;
                return;
            }

            if (e.Cancelled)
            {
                diskProgressLabel.Text = "已取消映射";
                diskProgressBar.Value = 0;
                return;
            }

            string[] log = (string[])e.Result;
            for (int i = 0; i < log.Length; i++) diskListView.Items[i].SubItems[7].Text = log[i];// 把日志遍历到ListView

            diskProgressLabel.Text = "映射完成";
            diskProgressBar.Value = 100;
        }
        
        /// <summary>
        /// 映射按钮
        /// </summary>
        private void mappingButton_Click(object sender, EventArgs e)
        {
            MappingStart();
        }
        
        //foreach (string str in SyetemDiskList.GetFree())
        //{
        //    zFileComboBox.Items.Add(str);
        //}


        /// <summary>
        /// 映射API
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public class NETRESOURCE
        {
            public int dwScope;
            public int dwType;
            public int dwDisplayType;
            public int dwUsage;
            public string LocalName;
            public string RemoteName;
            public string Comment;
            public string Provider;
        }
        [DllImport("Mpr.dll", EntryPoint = "WNetAddConnection2")]
        public static extern uint WNetAddConnection2([In] NETRESOURCE lpNetResource, string lpPassword, string lpUsername, uint dwFlags);
        [DllImport("Mpr.dll")]
        public static extern uint WNetCancelConnection2(string lpName, uint dwFlags, bool fForce);

        /// <summary>
        /// 磁盘映射
        /// </summary>
        /// <param name="localPath">盘符</param>
        /// <param name="netPath">网格位置</param>
        /// <param name="userName">连接用户名</param>
        /// <param name="password">连接密码</param>
        /// <param name="forever">映射性质</param>
        private string Mapping(string localPath, string netPath, string userName, string password, uint constflags)
        {
            try
            {
                if (userName == "") userName = password = null;
                NETRESOURCE NetRESOURCE = new NETRESOURCE();
                NetRESOURCE.dwScope = 2;
                NetRESOURCE.dwType = 1;
                NetRESOURCE.dwDisplayType = 3;
                NetRESOURCE.dwUsage = 1;
                NetRESOURCE.LocalName = localPath;
                NetRESOURCE.RemoteName = netPath;
                NetRESOURCE.Provider = null;
                uint mapping = WNetAddConnection2(NetRESOURCE, password, userName, constflags);// 映射
                if (mapping == constflags) return "映射完成 - " + DateTime.Now.ToString();
                else return "映射失败 - " + DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                return "映射出错 - " + DateTime.Now.ToString() + " - " + ex.ToString();
            }
        }

        /// <summary>
        /// 断开网络磁盘
        /// </summary>
        /// <param name="diskName">盘符</param>
        /// <returns></returns>
        private string Disconnect(string diskName)
        {
            try
            {
                uint cancel = WNetCancelConnection2(diskName, 1, true);//断开
                return "已断开 - " + DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                return "断开失败 - " + DateTime.Now.ToString() + " - " + ex.ToString();
            }
        }

        /// <summary>
        /// 重写关窗函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiskMappingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            StartPosition = FormStartPosition.Manual;
        }

        /// <summary>
        /// 后台断开工作
        /// </summary>
        private void breakBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            breakBackgroundWorker.ReportProgress(1, "磁盘断开中...");// 进度传出

            DataTable dataTable = e.Argument as DataTable;
            string[] logs = new string[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (breakBackgroundWorker.CancellationPending)// 取消检测
                {
                    e.Cancel = true;
                    return;
                }

                breakBackgroundWorker.ReportProgress(Percents.Get(1, dataTable.Rows.Count), "正在断开：" + dataTable.Rows[i][0].ToString());// 进度传出

                string localPath = dataTable.Rows[i][2].ToString();
                
                if (!Directory.Exists(localPath))
                {
                    logs[i] = "盘符不存在，跳过断开 - " + DateTime.Now.ToString();
                    continue;
                }

                logs[i] = Disconnect(localPath);// 断开
            }

            e.Result = logs;
        }

        /// <summary>
        /// 后台断开进度
        /// </summary>
        private void breakBackgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            diskProgressBar.Value = (e.ProgressPercentage < 101) ? e.ProgressPercentage : diskProgressBar.Value;
            diskProgressLabel.Text = diskProgressBar.Value.ToString() + "% " + e.UserState as string;
        }

        /// <summary>
        /// 后台断开完成
        /// </summary>
        private void breakBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            mappingButton.Enabled = breakButton.Enabled = true;

            if (e.Error != null)
            {
                MessageBox.Show("后台断开映射错误如下\r\n\r\n" + e.Error.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                diskProgressBar.Value = 0;
                return;
            }

            if (e.Cancelled)
            {
                diskProgressLabel.Text = "已取消断开映射";
                diskProgressBar.Value = 0;
                return;
            }

            string[] log = (string[])e.Result;
            for (int i = 0; i < log.Length; i++) diskListView.Items[i].SubItems[7].Text = log[i];// 把日志遍历到ListView

            diskProgressLabel.Text = "断开映射完成";
            diskProgressBar.Value = 100;

        }

        /// <summary>
        /// 断开按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void breakButton_Click(object sender, EventArgs e)
        {
            if (breakBackgroundWorker.IsBusy) return;
            DataTable dataTable = ToTable(diskListView);// 类型转换，ListView是引用类型，不能跨进程访问
            breakBackgroundWorker.RunWorkerAsync(dataTable);
            mappingButton.Enabled = breakButton.Enabled = false;
        }

        /// <summary>
        /// ListView转TataTable
        /// </summary>
        /// <param name="ListView">传入的ListView</param>
        /// <param name="datatable">传出的TataTable</param>
        private DataTable ToTable(ListView listView)
        {
            try
            {
                if (listView == null || listView.Items.Count == 0)
                {
                    MessageBox.Show("ListView无数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                DataTable dataTable = new DataTable();
                ListViewItem columnsName = listView.Items[0];// 取第一项目获取表头，因为隐藏了2列，直接在ListView上无法获取正确列数
                foreach (ListViewItem.ListViewSubItem subItems in columnsName.SubItems) dataTable.Columns.Add(subItems.Name.Trim(), typeof(string));
                DataRow datarow;
                foreach (ListViewItem item in listView.Items)
                {
                    datarow = dataTable.NewRow();
                    for (int i = 0; i < item.SubItems.Count; i++) datarow[i] = item.SubItems[i].Text.Trim();
                    dataTable.Rows.Add(datarow);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据转换错误\r\n\r\n" + ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// 定时映射
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mappingTimer_Tick(object sender, EventArgs e)
        {
            MappingStart();
        }

        /// <summary>
        /// 执行后台映射
        /// </summary>
        private void MappingStart()
        {
            if (mappingBackgroundWorker.IsBusy) return;
            mappingBackgroundWorker.RunWorkerAsync(ToTable(diskListView));// 类型转换，ListView是引用类型，不能跨进程访问
            mappingButton.Enabled = breakButton.Enabled = false;
        }

        /// <summary>
        /// 断开检测调整时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown.Value == 0) numericUpDown.Value = 1;
            mappingTimer.Interval = (int)numericUpDown.Value * 1000 * 60;
        }

        /// <summary>
        /// 窗口快捷键
        /// </summary>
        private void DiskMappingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && e.Control) Hide();
        }

        /// <summary>
        /// 修改按钮
        /// </summary>
        private void ModifyButton_Click(object sender, EventArgs e)
        {
            if (Selected())
            {
                ListViewItem sitem = diskListView.SelectedItems[0];
                DiskModifyForm diskModifyForm = new DiskModifyForm(sitem.SubItems[0].Text, sitem.SubItems[1].Text, sitem.SubItems[2].Text, sitem.SubItems[3].Text, sitem.SubItems[4].Text, sitem.SubItems[5].Text, sitem.SubItems[6].Text, sitem.SubItems[8].Text, sitem.SubItems[9].Text);
                diskModifyForm.ShowDialog();
                if (diskModifyForm.DialogResult == DialogResult.OK) LoadListView();
            }
            else MessageBox.Show("请选中项目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 是否选中项目
        /// </summary>
        /// <returns></returns>
        private bool Selected()
        {
            if (diskListView == null) return false;
            if (diskListView.Items.Count == 0) return false;
            if (diskListView.SelectedItems.Count == 0) return false;
            if (diskListView.SelectedItems.Count > 0) return true;
            return false;
        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("删除后将无法恢复，是否继续？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;
            if (!Selected()) MessageBox.Show("请选中项目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ListViewItem sitem = diskListView.SelectedItems[0];
            DiskList.Delete(sitem.SubItems[0].Text);
            LoadListView();
        }

        /// <summary>
        /// 新建按钮
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            DiskAddForm diskAddForm = new DiskAddForm();
            diskAddForm.ShowDialog();
            if (diskAddForm.DialogResult == DialogResult.OK) LoadListView();
        }
    }
}
