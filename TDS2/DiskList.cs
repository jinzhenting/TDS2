using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace TDS2
{
    public static class DiskList
    {
        public static List<Disk> Get()
        {
            try
            {
                List<Disk> disks = new List<Disk>();
                XmlDocument xml = new XmlDocument();
                xml.Load(@"Documents\Disks.xml");
                XmlNode xmlnode = xml.DocumentElement;// 获得根节点
                if (xmlnode.ChildNodes.Count > 0)
                {
                    foreach (XmlNode node in xmlnode.ChildNodes)// 在根节点中寻找节点
                    {
                        Disk disk = new Disk();
                        disk.Name = node.Name;
                        disk.NetPath = node.Attributes["netPath"].Value;
                        disk.LocalPath = node.Attributes["localPath"].Value;
                        disk.AutoMapping = node.Attributes["autoMapping"].Value == "true" ? "是" : "否";
                        disk.WindowsAccount = node.Attributes["windowsAccount"].Value == "true" ? "Windows凭据" : "用户名与密码";
                        disk.Forever = node.Attributes["forever"].Value == "true" ? "固定" : "临时";
                        disk.AutoCheck = node.Attributes["autoCheck"].Value == "true" ? "是" : "否";
                        disk.UserName = node.Attributes["userName"].Value;
                        disk.Password = node.Attributes["password"].Value;
                        disks.Add(disk);
                    }
                    return disks;
                }
                else
                {
                    MessageBox.Show("文件夹配置文件格式错误，程序将自动退出", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                    return null;
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("无权限访问文件夹配置文件，请尝试使用管理员权限运行本程序，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return null;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("文件夹配置文件不存在，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("访问文件夹配置文件时发生错误，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return null;
            }
        }

        /// <summary>
        /// 新建
        /// </summary>
        public static void Add(string diskName, string netPath, string localPath, string autoMapping, string windowsAccount, string forever, string autoCheck, string userName, string password)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(@"Documents\Disks.xml");
                XmlNode rootNode = xml.DocumentElement;// 获得根节点
                XmlNode node = xml.CreateNode("element", diskName, "");// 创建节点
                node.InnerText = "";// 添加空白值，节点才能生成前后标签对，不然只有前标签
                rootNode.AppendChild(node);// 添加节点
                XmlElement element = (XmlElement)xml.SelectSingleNode(@"Paths/" + diskName);// 操作xml节点属性主要用XmlElement对象所以取到结点后要转类型
                element.SetAttribute("netPath", netPath);// 添加属性
                element.SetAttribute("localPath", localPath);// 添加属性
                element.SetAttribute("autoMapping", autoMapping == "是" ? "true" : "false");
                element.SetAttribute("windowsAccount", windowsAccount == "Windows凭据" ? "true" : "false");
                element.SetAttribute("forever", forever == "固定" ? "true" : "false");
                element.SetAttribute("autoCheck", autoCheck == "是" ? "true" : "false");
                element.SetAttribute("userName", userName);
                element.SetAttribute("password", password);
                xml.Save(@"Documents\Disks.xml");
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("无权限访问网络磁盘配置文件，请尝试使用管理员权限运行本程序，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("网络磁盘配置文件不存在，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("访问网络磁盘配置文件时发生错误，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

        }

        /// <summary>
        /// 修改
        /// </summary>
        public static void Modify(string diskName, string netPath, string localPath, string autoMapping, string windowsAccount, string forever, string autoCheck, string userName, string password)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(@"Documents\Disks.xml");
                XmlNode rootNode = xml.DocumentElement;// 获得根节点
                foreach (XmlNode xmlnode in rootNode.ChildNodes)// 在根节点中寻找节点//找到对应的节点//获取对应节点的值
                    if (xmlnode.Name == diskName)
                    {
                        xmlnode.Attributes["netPath"].Value = netPath;
                        xmlnode.Attributes["localPath"].Value = localPath;
                        xmlnode.Attributes["autoMapping"].Value = autoMapping == "是" ? "true" : "false";
                        xmlnode.Attributes["windowsAccount"].Value = windowsAccount == "Windows凭据" ? "true" : "false";
                        xmlnode.Attributes["forever"].Value = forever == "固定" ? "true" : "false";
                        xmlnode.Attributes["autoCheck"].Value = autoCheck == "是" ? "true" : "false"; ;
                        xmlnode.Attributes["userName"].Value = userName;
                        xmlnode.Attributes["password"].Value = password;
                        break;
                    }
                xml.Save(@"Documents\Disks.xml");
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("无权限访问网络磁盘配置文件，请尝试使用管理员权限运行本程序，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("网络磁盘配置文件不存在，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("访问网络磁盘配置文件时发生错误，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public static void Delete(string diskName)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(@"Documents\Disks.xml");
                XmlNode rootNode = xml.DocumentElement;// 获得根节点
                foreach (XmlNode xmlnode in rootNode.ChildNodes)// 在根节点中寻找节点//找到对应的节点//获取对应节点的值
                {
                    if (xmlnode.Name == diskName)
                    {
                        rootNode.RemoveChild(xmlnode);
                        xml.Save(@"Documents\Disks.xml");
                        MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                MessageBox.Show("网络磁盘配置文件中没有查找到 " + diskName, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("无权限访问网络磁盘配置文件，请尝试使用管理员权限运行本程序，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("网络磁盘配置文件不存在，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("访问网络磁盘配置文件时发生错误，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

    }
}
