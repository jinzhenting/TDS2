using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

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
        public static List<string> Get(DataRow orderRow, DiskList diskList)
        {
            List<string> fileList = new List<string>();
            string searchPath = null;// 搜索路径
            string orderName = orderRow["订单号"].ToString().ToUpper();// 订单号，转换大写用于比对
            string orderClass = orderRow["订单类型"].ToString().ToUpper();// 订单类型
            string orderComputer = orderRow["订单电脑"].ToString().ToUpper();// 订单电脑
            string embZ = orderRow["订单号"].ToString();// 打版师
            string nrOutQc= orderRow["发带人"].ToString();// 发带人
            
            ///

            if (orderClass != "矢量新图" && orderClass != "矢量报价")// 只要不是矢量图 先在Emb和Ds的绝对位置检测
            {
                foreach (string dst in diskList.Datas)// 3个Data文件夹共12个子文件夹列表// Dst文件路径 和Emb分开遍历，是避免Dst和Emb不储存在同一个Data当中
                {
                    string dstPath = Path.Combine(dst, OrderNameParser.GetFilePath(orderName, "Dst"));
                    if (File.Exists(dstPath))
                    {
                        fileList.Add(dstPath);
                        searchPath = Path.GetDirectoryName(dstPath);
                        break;
                    }
                }
                foreach (string emb in diskList.Datas)// Emb文件路径 和Dst分开遍历，是避免Dst和Emb不储存在同一个Data当中
                {
                    string embPath = Path.Combine(emb, OrderNameParser.GetFilePath(orderName, "Emb"));
                    if (File.Exists(embPath))
                    {
                        fileList.Add(embPath);
                        break;
                    }
                }
                if (searchPath != null)// 如果Data in_out文件夹中发现了Dst，将继续搜索in_out文件夹就否有其他格式相关文件
                {
                    FileInfo[] fileInfos = new DirectoryInfo(searchPath).GetFiles(orderName + "*.*");
                    foreach (FileInfo fileInfo in fileInfos) if (fileInfo.Extension.ToLower() != ".dst") fileList.Add(fileInfo.FullName);// 排除Dst格式
                }

                /// 在 myAttachIn 中查找图片
                FileInfo[] myAttachIn = new DirectoryInfo(Path.Combine(diskList.MyAttach.LocalPath, "Attach_In")).GetFiles(orderName + "*.*");
                foreach (FileInfo fileInfo in myAttachIn) fileList.Add(fileInfo.FullName);

                /// 在 myAttachOut 中查找图片
                FileInfo[] myAttachOut = new DirectoryInfo(Path.Combine(diskList.MyAttach.LocalPath, "Attach_Out")).GetFiles(orderName + "*.*");
                foreach (FileInfo fileInfo in myAttachOut) fileList.Add(fileInfo.FullName);
            }

            /// O，E，F，Q，T，打版中
            if ((orderClass == "新带" || orderClass == "收费改带" || orderClass == "免费改带" || orderClass == "估针" || orderClass == "试打版") && nrOutQc == "" && embZ != "")
            {
                /// 在 打版师文件夹 中查找图片
                string zFlie = Path.Combine(diskList.ZFlie.LocalPath, embZ, "Jpg_Dst");// 在打版师文件夹中查找图片
                if (Directory.Exists(zFlie))
                {
                    FileInfo[] fileInfos = new DirectoryInfo(zFlie).GetFiles(orderName + "*.*");
                    foreach (FileInfo fileInfo in fileInfos) fileList.Add(fileInfo.FullName);
                }
            }

            /// AQ，AO，W
            if (orderClass == "矢量新图" || orderClass == "矢量报价" || orderClass == "等回复")// 等回复的带子是没有图片的，但有可能做过效果图，尝试查找IT做图文件夹
            {
                searchPath = Path.Combine(diskList.Vector.LocalPath, "Today");// Vector\Today中查找
                FileInfo[] today = new DirectoryInfo(searchPath).GetFiles(orderName + "*.*");
                foreach (FileInfo fileInfo in today) fileList.Add(fileInfo.FullName);
                ///
                searchPath = Path.Combine(diskList.Vector.LocalPath, OrderNameParser.GetFilePath(orderName, "Vector"));// Vector\VcetorData中查找
                if (Directory.Exists(searchPath))
                {
                    FileInfo[] vcetorData = new DirectoryInfo(searchPath).GetFiles(orderName + "*.*");
                    foreach (FileInfo fileInfo in vcetorData) fileList.Add(fileInfo.FullName);
                }
            }

            ///

            fileList.Reverse();// 文件列表倒序，遍历时从新到旧
            return fileList;
        }
    }
}
