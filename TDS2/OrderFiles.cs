using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TDS2
{
    /// <summary>
    /// 缩略图加载
    /// </summary>
    public static class OrderFiles
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="orderRow"></param>
        /// <returns></returns>
        public static List<string> Get(DataRow orderRow)
        {
            DiskList diskList = new DiskList();// 获取网络盘
            List<string> fileList = new List<string>();// 订单文件列表
            string orderName = orderRow["订单号"].ToString().ToUpper();// 订单号，转换大写用于比对
            string orderClass = orderRow["订单类型"].ToString().ToUpper();// 订单类型
            string orderComputer = orderRow["订单电脑"].ToString().ToUpper();// 订单电脑
            string embZ = orderRow["订单号"].ToString();// 打版师
            string nrOutQc= orderRow["发带人"].ToString();// 发带人

            ///

            if (orderClass != "矢量新图" && orderClass != "矢量报价")// 只要不是矢量图 先在Emb和Ds的绝对位置检测
            {
                foreach (string datas in diskList.Datas)// 3个Data文件夹共12个子文件夹列表// Dst文件路径 和Emb分开遍历，是避免Dst和Emb不储存在同一个Data当中
                {
                    string embPath = Path.Combine(datas, OrderNameParser.GetFilePath(orderName, "Emb"));// Emb文件路径 // 把匹配Emb放在前面，是因为只要有Emb，一定是这个Data正确，往后Dst的Data也是有效的
                    if (File.Exists(embPath)) fileList.Add(embPath);

                    string dstPath = Path.Combine(datas, OrderNameParser.GetFilePath(orderName, "Dst"));// Dst文件路径
                    if (File.Exists(dstPath))
                    {
                        fileList.Add(dstPath);
                        FileInfo[] fileInfos = new DirectoryInfo(Path.GetDirectoryName(dstPath)).GetFiles(orderName + "*.*");// 如果Data in_out文件夹中发现了Dst，将继续搜索in_out文件夹就否有其他格式相关文件// 排除Dst格式
                        foreach (FileInfo fileInfo in fileInfos) if (fileInfo.Extension.ToLower() != ".dst") fileList.Add(fileInfo.FullName);
                    }

                    if (fileList.Count > 0) break;// 搜索到文件时停止往后检测
                }

                /// 在 myAttachIn 中查找图片
                string attachInPath = Path.Combine(diskList.MyAttach.NetPath, "Attach_In");
                if (Directory.Exists(attachInPath))
                {
                    FileInfo[] attachIn = new DirectoryInfo(attachInPath).GetFiles(orderName + "*.*");
                    foreach (FileInfo fileInfo in attachIn) fileList.Add(fileInfo.FullName);
                }
                else
                {
                    MessageBox.Show("文件夹 " + attachInPath + " 不存在，请检查网络是否正常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return fileList;
                }

                /// 在 myAttachOut 中查找图片
                string attachOutPath = Path.Combine(diskList.MyAttach.NetPath, "Attach_Out");
                if (Directory.Exists(attachOutPath))
                {
                    FileInfo[] attachOut = new DirectoryInfo(attachOutPath).GetFiles(orderName + "*.*");
                    foreach (FileInfo fileInfo in attachOut) fileList.Add(fileInfo.FullName);
                }
                else
                {
                    MessageBox.Show("文件夹 " + attachOutPath + " 不存在，请检查网络是否正常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return fileList;
                }
            }

            ///

            if ((orderClass == "新带" || orderClass == "收费改带" || orderClass == "免费改带" || orderClass == "估针" || orderClass == "试打版") && nrOutQc == "" && embZ != "")// O，E，F，Q，T，打版中
            {
                /// 在 打版师文件夹 中查找图片
                string zFlie = Path.Combine(diskList.ZFlie.NetPath, embZ, "Jpg_Dst");// 在打版师文件夹中查找图片
                if (Directory.Exists(zFlie))
                {
                    FileInfo[] fileInfos = new DirectoryInfo(zFlie).GetFiles(orderName + "*.*");
                    foreach (FileInfo fileInfo in fileInfos) fileList.Add(fileInfo.FullName);
                }
            }

            ///
            
            if (orderClass == "矢量新图" || orderClass == "矢量报价" || orderClass == "等回复")// AQ，AO，W等回复的带子是没有图片的，但有可能做过效果图，尝试查找IT做图文件夹
            {
               string  todayPath = Path.Combine(diskList.Vector.LocalPath, "Today");// Vector\Today中查找
                FileInfo[] today = new DirectoryInfo(todayPath).GetFiles(orderName + "*.*");
                foreach (FileInfo fileInfo in today) fileList.Add(fileInfo.FullName);
                ///
                string vectorPath = Path.Combine(diskList.Vector.LocalPath, OrderNameParser.GetFilePath(orderName, "Vector"));// Vector\VcetorData中查找
                if (Directory.Exists(vectorPath))
                {
                    FileInfo[] vcetorData = new DirectoryInfo(vectorPath).GetFiles(orderName + "*.*");
                    foreach (FileInfo fileInfo in vcetorData) fileList.Add(fileInfo.FullName);
                }
            }

            ///

            fileList.Reverse();// 文件列表倒序，遍历时从新到旧

            return fileList;
        }
    }
}
