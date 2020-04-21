using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace TDS2
{
    class Sql
    {
        public Sql()
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(@"Documents\Sql.xml");
                XmlNode xmlNode = xmlDocument.DocumentElement;// 获得根节点
                foreach (XmlNode node in xmlNode.ChildNodes)// 在根节点中寻找节点//找到对应的节点//获取对应节点的值
                {
                    switch (node.Name)
                    {
                        case "Sql":
                            {
                                serverIP = node.Attributes["serverip"].Value;
                                dataName = node.Attributes["dataname"].Value;
                                userID = node.Attributes["userid"].Value;
                                password = TDS2.Password.Decrypt(node.Attributes["password"].Value, "12345678");
                                connection = "Server=" + node.Attributes["serverip"].Value + "; Initial Catalog=" + node.Attributes["dataname"].Value + "; User ID=" + node.Attributes["userid"].Value + "; Password=" + TDS2.Password.Decrypt(node.Attributes["password"].Value, "12345678");
                                return;
                            }
                        default:
                            {
                                MessageBox.Show("数据库配置文件节点命名错误，程序将自动退出，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                return;
                            }
                    }
                }
                MessageBox.Show("数据库配置文件中查找不到" + "Sql" + "的内容，程序将自动退出，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Environment.Exit(0);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("无权限访问数据库配置文件，请尝试使用管理员权限运行本程序，程序将自动退出，描述如下\r\n\r\n" + ex, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("数据库配置文件不存在，程序将自动退出，描述如下\r\n\r\n" + ex, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("访问数据库配置文件时发生错误，程序将自动退出，描述如下\r\n\r\n" + ex, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// ServerIP
        /// </summary>
        private string serverIP;
        /// <summary>
        /// ServerIP
        /// </summary>
        public string ServerIP
        {
            get { return serverIP; }
            set { serverIP = value; }
        }

        /// <summary>
        /// dataName
        /// </summary>
        private string dataName;
        /// <summary>
        /// dataName
        /// </summary>
        public string DataName
        {
            get { return dataName; }
            set { dataName = value; }
        }

        /// <summary>
        /// UserID
        /// </summary>
        private string userID;
        /// <summary>
        /// UserID
        /// </summary>
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        /// <summary>
        /// Password
        /// </summary>
        private string password;
        /// <summary>
        /// Password
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Connection
        /// </summary>
        private string connection;
        /// <summary>
        /// Connection
        /// </summary>
        public string Connection
        {
            get { return connection; }
            set { connection = value; }
        }


    }
}
