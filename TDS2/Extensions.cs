using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace TDS2
{
    public class Extensions
    {
        public Extensions()
        {

            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(@"Documents\Extension.xml");
                XmlNode xmlnode = xml.DocumentElement;// 获得根节点
                if (xmlnode.ChildNodes.Count > 0)
                {
                    foreach (XmlNode node in xmlnode.ChildNodes)// 在根节点中寻找节点
                    {
                        if (node.Name == "Dst")
                        {
                            dst.Name = "Dst";
                            dst.App = node.Attributes["app"].Value;
                            dst.Relation = Convert.ToBoolean(node.Attributes["relation"].Value);
                        }

                        if (node.Name == "Emb")
                        {
                            emb.Name = "Emb";
                            emb.App = node.Attributes["app"].Value;
                            emb.Relation = Convert.ToBoolean(node.Attributes["relation"].Value);
                        }

                        if (node.Name == "Jpg")
                        {
                            jpg.Name = "Jpg";
                            jpg.App = node.Attributes["app"].Value;
                            jpg.Relation = Convert.ToBoolean(node.Attributes["relation"].Value);
                        }

                        if (node.Name == "Ai")
                        {
                            ai.Name = "Ai";
                            ai.App = node.Attributes["app"].Value;
                            ai.Relation = Convert.ToBoolean(node.Attributes["relation"].Value);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("文件夹配置文件格式错误，程序将自动退出", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
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

        private Extension dst = new Extension();
        public Extension Dst
        {
            get { return dst; }
            set { dst = value; }
        }

        private Extension emb = new Extension();
        public Extension Emb
        {
            get { return emb; }
            set { emb = value; }
        }

        private Extension jpg = new Extension();
        public Extension Jpg
        {
            get { return jpg; }
            set { jpg = value; }
        }

        private Extension ai = new Extension();
        public Extension Ai
        {
            get { return ai; }
            set { ai = value; }
        }

    }
}
