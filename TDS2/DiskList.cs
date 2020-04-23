using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace TDS2
{
    public class DiskList
    {
        public DiskList()
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(@"Documents\Disks.xml");
                XmlNode xmlnode = xml.DocumentElement;// 获得根节点
                if (xmlnode.ChildNodes.Count > 0)
                {
                    foreach (XmlNode node in xmlnode.ChildNodes)// 在根节点中寻找节点
                    {
                        switch (node.Name)
                        {
                            case "ZFile":
                                {
                                    zFlie.Name = "ZFile";
                                    zFlie.NetPath = node.Attributes["netPath"].Value;
                                    zFlie.LocalPath = node.Attributes["localPath"].Value;
                                    break;
                                }
                            case "NewData":
                                {
                                    newData.Name = "NewData";
                                    newData.NetPath = node.Attributes["netPath"].Value;
                                    newData.LocalPath = node.Attributes["localPath"].Value;
                                    break;
                                }
                            case "HistoryData":
                                {
                                    historyData.Name = "HistoryData";
                                    historyData.NetPath = node.Attributes["netPath"].Value;
                                    historyData.LocalPath = node.Attributes["localPath"].Value;
                                    break;
                                }
                            case "OldData":
                                {
                                    oldData.Name = "OldData";
                                    oldData.NetPath = node.Attributes["netPath"].Value;
                                    oldData.LocalPath = node.Attributes["localPath"].Value;
                                    break;
                                }
                            case "MyAttach":
                                {
                                    myAttach.Name = "MyAttach";
                                    myAttach.NetPath = node.Attributes["netPath"].Value;
                                    myAttach.LocalPath = node.Attributes["localPath"].Value;
                                    break;
                                }
                            case "DST":
                                {
                                    dst.Name = "DST";
                                    dst.NetPath = node.Attributes["netPath"].Value;
                                    dst.LocalPath = node.Attributes["localPath"].Value;
                                    break;
                                }
                            case "Ta":
                                {
                                    ta.Name = "Ta";
                                    ta.NetPath = node.Attributes["netPath"].Value;
                                    ta.LocalPath = node.Attributes["localPath"].Value;
                                    break;
                                }
                            case "Temp":
                                {
                                    temp.Name = "Temp";
                                    temp.NetPath = node.Attributes["netPath"].Value;
                                    temp.LocalPath = node.Attributes["localPath"].Value;
                                    break;
                                }
                            case "Vector":
                                {
                                    vector.Name = "Vector";
                                    vector.NetPath = node.Attributes["netPath"].Value;
                                    vector.LocalPath = node.Attributes["localPath"].Value;
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show("文件夹配置文件节点命名错误，程序将自动退出", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Environment.Exit(0);
                                    return;
                                }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("文件夹配置文件格式错误，程序将自动退出", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
                ///
                datas.Add(Path.Combine(newData.LocalPath, "Pc_A_Data"));
                datas.Add(Path.Combine(newData.LocalPath, "Pc_B_Data"));
                datas.Add(Path.Combine(newData.LocalPath, "Pc_C_Data"));
                datas.Add(Path.Combine(newData.LocalPath, "Pc_O_Data"));
                datas.Add(Path.Combine(oldData.LocalPath, "Pc_A_Old"));
                datas.Add(Path.Combine(oldData.LocalPath, "Pc_B_Old"));
                datas.Add(Path.Combine(oldData.LocalPath, "Pc_C_Old"));
                datas.Add(Path.Combine(oldData.LocalPath, "Pc_O_Old"));
                datas.Add(Path.Combine(historyData.LocalPath, "Pc_A_History"));
                datas.Add(Path.Combine(historyData.LocalPath, "Pc_B_History"));
                datas.Add(Path.Combine(historyData.LocalPath, "Pc_C_History"));
                datas.Add(Path.Combine(historyData.LocalPath, "Pc_O_History"));
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("无权限访问文件夹配置文件，请尝试使用管理员权限运行本程序，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("文件夹配置文件不存在，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("访问文件夹配置文件时发生错误，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {


        }

        /// <summary>
        /// 获取3个Data文件夹共12个子文件夹列表
        /// </summary>
        private List<string> datas = new List<string>();
        /// <summary>
        /// 获取3个Data文件夹共12个子文件夹列表
        /// </summary>
        public List<string> Datas
        {
            get { return datas; }
            set { datas = value; }
        }

        private Disk zFlie = new Disk();
        public Disk ZFlie
        {
            get { return zFlie; }
            set { zFlie = value; }
        }

        private Disk newData = new Disk();
        public Disk NewData
        {
            get { return newData; }
            set { newData = value; }
        }

        private Disk historyData = new Disk();
        public Disk HistoryData
        {
            get { return historyData; }
            set { historyData = value; }
        }

        private Disk oldData = new Disk();
        public Disk OldData
        {
            get { return oldData; }
            set { oldData = value; }
        }

        private Disk myAttach = new Disk();
        public Disk MyAttach
        {
            get { return myAttach; }
            set { myAttach = value; }
        }

        private Disk dst = new Disk();
        public Disk DST
        {
            get { return dst; }
            set { dst = value; }
        }

        private Disk ta = new Disk();
        public Disk Ta
        {
            get { return ta; }
            set { ta = value; }
        }

        private Disk temp = new Disk();
        public Disk Temp
        {
            get { return temp; }
            set { temp = value; }
        }

        private Disk vector = new Disk();
        public Disk Vector
        {
            get { return vector; }
            set { vector = value; }
        }

    }
}
