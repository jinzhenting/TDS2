using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TDS2
{
    public static class FileSystem
    {
        /// <summary>
        /// 3个Data文件夹共12个子文件夹
        /// </summary>
        /// <returns></returns>
        public static string[] Data12()
        {
            string[] datas = new string[12];
            foreach (Disk disk in DiskList.Get())
            {
                if (disk.Name == "NewData")
                {
                    datas[0] = Path.Combine(disk.NetPath, "Pc_A_Data");
                    datas[1] = Path.Combine(disk.NetPath, "Pc_B_Data");
                    datas[2] = Path.Combine(disk.NetPath, "Pc_C_Data");
                    datas[3] = Path.Combine(disk.NetPath, "Pc_O_Data");
                    continue;
                }
                if (disk.Name == "OldData")
                {
                    datas[4] = Path.Combine(disk.NetPath, "Pc_A_Data");
                    datas[5] = Path.Combine(disk.NetPath, "Pc_B_Data");
                    datas[6] = Path.Combine(disk.NetPath, "Pc_C_Data");
                    datas[7] = Path.Combine(disk.NetPath, "Pc_O_Data");
                    continue;
                }
                if (disk.Name == "HistoryData")
                {
                    datas[8] = Path.Combine(disk.NetPath, "Pc_A_Data");
                    datas[9] = Path.Combine(disk.NetPath, "Pc_B_Data");
                    datas[10] = Path.Combine(disk.NetPath, "Pc_C_Data");
                    datas[11] = Path.Combine(disk.NetPath, "Pc_O_Data");
                    continue;
                }
            }
            return datas;
        }

        /// <summary>
        /// ZFlie
        /// </summary>
        /// <returns></returns>
        public static string ZFile()
        {
            foreach (Disk disk in DiskList.Get()) if (disk.Name == "ZFile") return disk.NetPath;
            if (MessageBox.Show("网络磁盘列表中没有{ZFile}，此磁盘是必须的，按“是”添加映射，按“取消”退出系统", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DiskMappingForm diskMappingForm = new DiskMappingForm();
                diskMappingForm.ShowDialog();
                ZFile();
            }
            else
            {
                Environment.Exit(0);
                return null;
            }
            return null;
        }

        /// <summary>
        /// NewData
        /// </summary>
        /// <returns></returns>
        public static string NewData()
        {
            foreach (Disk disk in DiskList.Get()) if (disk.Name == "NewData") return disk.NetPath;
            if (MessageBox.Show("网络磁盘列表中没有{NewData}，此磁盘是必须的，按“是”添加映射，按“取消”退出系统", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DiskMappingForm diskMappingForm = new DiskMappingForm();
                diskMappingForm.ShowDialog();
                NewData();
            }
            else
            {
                Environment.Exit(0);
                return null;
            }
            return null;
        }

        /// <summary>
        /// HistoryData
        /// </summary>
        /// <returns></returns>
        public static string HistoryData()
        {
            foreach (Disk disk in DiskList.Get()) if (disk.Name == "HistoryData") return disk.NetPath;
            if (MessageBox.Show("网络磁盘列表中没有{HistoryData}，此磁盘是必须的，按“是”添加映射，按“取消”退出系统", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DiskMappingForm diskMappingForm = new DiskMappingForm();
                diskMappingForm.ShowDialog();
                HistoryData();
            }
            else
            {
                Environment.Exit(0);
                return null;
            }
            return null;
        }

        /// <summary>
        /// OldData
        /// </summary>
        /// <returns></returns>
        public static string OldData()
        {
            foreach (Disk disk in DiskList.Get()) if (disk.Name == "OldData") return disk.NetPath;
            if (MessageBox.Show("网络磁盘列表中没有{OldData}，此磁盘是必须的，按“是”添加映射，按“取消”退出系统", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DiskMappingForm diskMappingForm = new DiskMappingForm();
                diskMappingForm.ShowDialog();
                OldData();
            }
            else
            {
                Environment.Exit(0);
                return null;
            }
            return null;
        }

        /// <summary>
        /// MyAttach
        /// </summary>
        /// <returns></returns>
        public static string MyAttach()
        {
            foreach (Disk disk in DiskList.Get()) if (disk.Name == "MyAttach") return disk.NetPath;
            if (MessageBox.Show("网络磁盘列表中没有{MyAttach}，此磁盘是必须的，按“是”添加映射，按“取消”退出系统", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DiskMappingForm diskMappingForm = new DiskMappingForm();
                diskMappingForm.ShowDialog();
                MyAttach();
            }
            else
            {
                Environment.Exit(0);
                return null;
            }
            return null;
        }

        /// <summary>
        /// DST
        /// </summary>
        /// <returns></returns>
        public static string DST()
        {
            foreach (Disk disk in DiskList.Get()) if (disk.Name == "DST") return disk.NetPath;
            if (MessageBox.Show("网络磁盘列表中没有{DST}，此磁盘是必须的，按“是”添加映射，按“取消”退出系统", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DiskMappingForm diskMappingForm = new DiskMappingForm();
                diskMappingForm.ShowDialog();
                DST();
            }
            else
            {
                Environment.Exit(0);
                return null;
            }
            return null;
        }

        /// <summary>
        /// Vector
        /// </summary>
        /// <returns></returns>
        public static string Vector()
        {
            foreach (Disk disk in DiskList.Get()) if (disk.Name == "Vector") return disk.NetPath;
            if (MessageBox.Show("网络磁盘列表中没有{Vector}，此磁盘是必须的，按“是”添加映射，按“取消”退出系统", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DiskMappingForm diskMappingForm = new DiskMappingForm();
                diskMappingForm.ShowDialog();
                Vector();
            }
            else
            {
                Environment.Exit(0);
                return null;
            }
            return null;
        }
        
    }
}
