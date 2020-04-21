using System.Collections.Generic;
using System.IO;
using System.Management;

namespace TDS2
{
   public static class SyetemDiskList
    {
        /// <summary>
        /// 获取本地电脑所有盘符
        /// </summary>
        /// <returns></returns>
        public static List<string> Get()
        {
            List<string> disks = new List<string>();
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * From Win32_LogicalDisk");
            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
            foreach (ManagementObject managementObject in managementObjectCollection)
            {
                switch (int.Parse(managementObject["DriveType"].ToString()))
                {
                    case (int)DriveType.Removable:// 可以移动磁盘     
                        {
                            disks.Add(managementObject["DeviceID"].ToString());
                            break;
                        }
                    case (int)DriveType.Fixed:// 本地磁盘     
                        {
                            disks.Add(managementObject["DeviceID"].ToString());
                            break;
                        }
                    case (int)DriveType.CDRom:// CD    
                        {
                            disks.Add(managementObject["DeviceID"].ToString());
                            break;
                        }
                    case (int)DriveType.Network:// 网络驱动   
                        {
                            disks.Add(managementObject["DeviceID"].ToString());
                            break;
                        }
                    case (int)DriveType.Ram:// RAM磁盘
                        {
                            disks.Add(managementObject["DeviceID"].ToString());
                            break;
                        }
                    case (int)DriveType.NoRootDirectory:// 驱动器没有根目录
                        {
                            disks.Add(managementObject["DeviceID"].ToString());
                            break;
                        }
                    default:// 驱动器类型未知    
                        {
                            disks.Add(managementObject["DeviceID"].ToString());
                            break;
                        }
                }
            }
            return disks;
        }

        /// <summary>
        /// 获取本地电脑未使用的盘符
        /// </summary>
        /// <returns></returns>
        public static List<string> GetFree()
        {
            List<string> disksUse = Get();
            List<string> disksFree = new List<string> { "C:", "D:", "E:", "F:", "G:", "H:", "I:", "J:", "K:", "L:", "M:", "N:", "O:", "P:", "Q:", "R:", "S:", "T:", "U:", "V:", "W:", "X:", "Y:", "Z:" };
            foreach (string s in disksUse) if (disksFree.Contains(s)) disksFree.Remove(s);
            return disksFree;
        }

        ///
    }
}
