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

            DiskList disks = new DiskList();// 获取文件系统

            ListViewItem zFile = new ListViewItem();// ZFlie
            zFile.Text = disks.ZFlie.Name;
            zFile.SubItems.Add(disks.ZFlie.NetPath);
            zFile.SubItems.Add(disks.ZFlie.LocalPath);
            zFile.SubItems.Add(disks.ZFlie.AutoMapping);
            zFile.SubItems.Add(disks.ZFlie.WindowsAccount);
            zFile.SubItems.Add(disks.ZFlie.Forever);
            zFile.SubItems.Add(disks.ZFlie.AutoCheck);
            zFile.SubItems.Add("");
            zFile.SubItems.Add(disks.ZFlie.UserName);
            zFile.SubItems.Add(disks.ZFlie.Password);
            diskListView.Items.Add(zFile);

            ListViewItem newData = new ListViewItem();// 
            newData.Text = disks.NewData.Name;
            newData.SubItems.Add(disks.NewData.NetPath);
            newData.SubItems.Add(disks.NewData.LocalPath);
            newData.SubItems.Add(disks.NewData.AutoMapping);
            newData.SubItems.Add(disks.NewData.WindowsAccount);
            newData.SubItems.Add(disks.NewData.Forever);
            newData.SubItems.Add(disks.NewData.AutoCheck);
            newData.SubItems.Add("");
            newData.SubItems.Add(disks.NewData.UserName);
            newData.SubItems.Add(disks.NewData.Password);
            diskListView.Items.Add(newData);

            ListViewItem historyData = new ListViewItem();// 
            historyData.Text = disks.HistoryData.Name;
            historyData.SubItems.Add(disks.HistoryData.NetPath);
            historyData.SubItems.Add(disks.HistoryData.LocalPath);
            historyData.SubItems.Add(disks.HistoryData.AutoMapping);
            historyData.SubItems.Add(disks.HistoryData.WindowsAccount);
            historyData.SubItems.Add(disks.HistoryData.Forever);
            historyData.SubItems.Add(disks.HistoryData.AutoCheck);
            historyData.SubItems.Add("");
            historyData.SubItems.Add(disks.HistoryData.UserName);
            historyData.SubItems.Add(disks.HistoryData.Password);
            diskListView.Items.Add(historyData);

            ListViewItem oldData = new ListViewItem();// 
            oldData.Text = disks.OldData.Name;
            oldData.SubItems.Add(disks.OldData.NetPath);
            oldData.SubItems.Add(disks.OldData.LocalPath);
            oldData.SubItems.Add(disks.OldData.AutoMapping);
            oldData.SubItems.Add(disks.OldData.WindowsAccount);
            oldData.SubItems.Add(disks.OldData.Forever);
            oldData.SubItems.Add(disks.OldData.AutoCheck);
            oldData.SubItems.Add("");
            oldData.SubItems.Add(disks.OldData.UserName);
            oldData.SubItems.Add(disks.OldData.Password);
            diskListView.Items.Add(oldData);

            ListViewItem myAttach = new ListViewItem();// 
            myAttach.Text = disks.MyAttach.Name;
            myAttach.SubItems.Add(disks.MyAttach.NetPath);
            myAttach.SubItems.Add(disks.MyAttach.LocalPath);
            myAttach.SubItems.Add(disks.MyAttach.AutoMapping);
            myAttach.SubItems.Add(disks.MyAttach.WindowsAccount);
            myAttach.SubItems.Add(disks.MyAttach.Forever);
            myAttach.SubItems.Add(disks.MyAttach.AutoCheck);
            myAttach.SubItems.Add("");
            myAttach.SubItems.Add(disks.MyAttach.UserName);
            myAttach.SubItems.Add(disks.MyAttach.Password);
            diskListView.Items.Add(myAttach);

            ListViewItem dst = new ListViewItem();// 
            dst.Text = disks.DST.Name;
            dst.SubItems.Add(disks.DST.NetPath);
            dst.SubItems.Add(disks.DST.LocalPath);
            dst.SubItems.Add(disks.DST.AutoMapping);
            dst.SubItems.Add(disks.DST.WindowsAccount);
            dst.SubItems.Add(disks.DST.Forever);
            dst.SubItems.Add(disks.DST.AutoCheck);
            dst.SubItems.Add("");
            dst.SubItems.Add(disks.DST.UserName);
            dst.SubItems.Add(disks.DST.Password);
            diskListView.Items.Add(dst);

            ListViewItem ta = new ListViewItem();// 
            ta.Text = disks.Ta.Name;
            ta.SubItems.Add(disks.Ta.NetPath);
            ta.SubItems.Add(disks.Ta.LocalPath);
            ta.SubItems.Add(disks.Ta.AutoMapping);
            ta.SubItems.Add(disks.Ta.WindowsAccount);
            ta.SubItems.Add(disks.Ta.Forever);
            ta.SubItems.Add(disks.Ta.AutoCheck);
            ta.SubItems.Add("");
            ta.SubItems.Add(disks.Ta.UserName);
            ta.SubItems.Add(disks.Ta.Password);
            diskListView.Items.Add(ta);

            ListViewItem temp = new ListViewItem();// 
            temp.Text = disks.Temp.Name;
            temp.SubItems.Add(disks.Temp.NetPath);
            temp.SubItems.Add(disks.Temp.LocalPath);
            temp.SubItems.Add(disks.Temp.AutoMapping);
            temp.SubItems.Add(disks.Temp.WindowsAccount);
            temp.SubItems.Add(disks.Temp.Forever);
            temp.SubItems.Add(disks.Temp.AutoCheck);
            temp.SubItems.Add("");
            temp.SubItems.Add(disks.Temp.UserName);
            temp.SubItems.Add(disks.Temp.Password);
            diskListView.Items.Add(temp);

            ListViewItem vector = new ListViewItem();// 
            vector.Text = disks.Vector.Name;
            vector.SubItems.Add(disks.Vector.NetPath);
            vector.SubItems.Add(disks.Vector.LocalPath);
            vector.SubItems.Add(disks.Vector.AutoMapping);
            vector.SubItems.Add(disks.Vector.WindowsAccount);
            vector.SubItems.Add(disks.Vector.Forever);
            vector.SubItems.Add(disks.Vector.AutoCheck);
            vector.SubItems.Add("");
            vector.SubItems.Add(disks.Vector.UserName);
            vector.SubItems.Add(disks.Vector.Password);
            diskListView.Items.Add(vector);

            ///

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

                string localPath = dataTable.Rows[i][2].ToString();
                string netPath = dataTable.Rows[i][1].ToString();
                string userName = dataTable.Rows[i][8].ToString();
                string password = dataTable.Rows[i][9].ToString();
                uint constflags = userName == "" ? (uint)0 : (uint)0;

                if (Directory.Exists(localPath))
                {
                    logs[i] = "盘符已存在，跳过映射 - " + DateTime.Now.ToString();
                    continue;
                }

                if (!Directory.Exists(netPath))
                {
                    logs[i] =  "网络位置无法访问，跳过映射 - "+ DateTime.Now.ToString();
                    continue;
                }
                
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
        /// 全选按钮
        /// </summary>
        private void selectAllButton_Click(object sender, EventArgs e)
        {
            if (diskListView != null && diskListView.Items.Count > 0) foreach (ListViewItem item in diskListView.Items) item.Checked = true;
        }

        /// <summary>
        /// 反选按钮
        /// </summary>
        private void reSelectButton_Click(object sender, EventArgs e)
        {
            if (diskListView != null && diskListView.Items.Count > 0) foreach (ListViewItem item in diskListView.Items) item.Checked = !item.Checked;
        }

        /// <summary>
        /// 映射按钮
        /// </summary>
        private void mappingButton_Click(object sender, EventArgs e)
        {
            if (!mappingBackgroundWorker.IsBusy)
            {
                DataTable dataTable= ToTable(diskListView);// 类型转换，ListView是引用类型，不能在异进程中访问
                mappingBackgroundWorker.RunWorkerAsync(dataTable);
                mappingButton.Enabled = breakButton.Enabled = false;
            }
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
                if (mapping == constflags) return  "映射完成 - "+ DateTime.Now.ToString();
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
            if (!breakBackgroundWorker.IsBusy)
            {
                DataTable dataTable = ToTable(diskListView);// 类型转换，ListView是引用类型，不能在异进程中访问
                breakBackgroundWorker.RunWorkerAsync(dataTable);
                mappingButton.Enabled = breakButton.Enabled = false;
            }
        }
        
        /// <summary>
        /// ListView转TataTable
        /// </summary>
        /// <param name="ListView">传入的ListView</param>
        /// <param name="datatable">传出的TataTable</param>
        public static DataTable ToTable(ListView ListView)
        {
            try
            {
                if (ListView == null || ListView.Items.Count == 0)
                {
                    MessageBox.Show("ListView无数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                DataTable dataTable = new DataTable();
                int x, y;
                // 表头
                for (x = 0; x < ListView.Items[0].SubItems.Count; x++)
                {
                    dataTable.Columns.Add(ListView.Items[0].SubItems[x].Name.Trim(), typeof(string));
                }

                // 行
                DataRow datarow;
                for (x = 0; x < ListView.Items.Count; x++)
                {
                    datarow = dataTable.NewRow();
                    for (y = 0; y < ListView.Items[x].SubItems.Count; y++)
                    {
                        datarow[y] = ListView.Items[x].SubItems[y].Text.Trim();
                    }
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
    }
}
