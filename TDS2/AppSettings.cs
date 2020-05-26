using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace TDS2
{
    class AppSettings
    { 
        /// <summary>
       /// 更新地址
       /// </summary>
        private string updataUrl;
        /// <summary>
        /// 更新地址
        /// </summary>
        public string UpdataUrl
        {
            get { return updataUrl; }
            set { updataUrl = value; }
        }

        /// <summary>
        /// 是否自动更新
        /// </summary>
        private bool updataAuto;
        /// <summary>
        /// 是否自动更新
        /// </summary>
        public bool UpdataAuto
        {
            get { return updataAuto; }
            set { updataAuto = value; }
        }

        /// <summary>
        /// 获取AppSettings对象
        /// </summary>
        public AppSettings()
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(@"Documents\Settings.xml");
                XmlNode xmlnode = xml.DocumentElement;// 获得根节点
                if (xmlnode.ChildNodes.Count > 0)
                {
                    foreach (XmlNode node in xmlnode.ChildNodes)
                    {
                        switch (node.Name)
                        {
                            case "AppUpdata":// 在根节点中寻找节点
                                {
                                    updataUrl = node.Attributes["url"].Value;
                                    updataAuto = Convert.ToBoolean(node.Attributes["auto"].Value);
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
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
        /// 更新
        /// </summary>
        /// <param name="upURL">更新地址</param>
        /// <param name="showWindows">结果是否弹窗</param>
        public void GoUpdata(bool showWindows)
        {
            if (!Directory.Exists(updataUrl))// 地址检测
            {
                if (MessageBox.Show("程序更新地址 " + updataUrl + " 无效，是否重新设置？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;// 新版本更新选择窗口
                else
                {
                    AppSettingsForm settingsForm = new AppSettingsForm();
                    settingsForm.ShowDialog();
                    Environment.Exit(0);
                }
                return;
            }
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(updataUrl);
                FileInfo[] files = directoryInfo.GetFiles(@"TDS2*.exe", SearchOption.TopDirectoryOnly);// 扫描TDS2开头命名的exe文件
                if (files.Length == 0)// 没有发现TDS2开头命名的exe文件
                {
                    if (showWindows) MessageBox.Show("没有发现新版本", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                foreach (FileInfo file in files)// 遍历1或多个TDS2程序文件
                {
                    string version = Regex.Match(file.Name, @"[1-9]+[.][0-9]+[.][0-9]+[.][0-9]+").Groups[0].Value;// 获取版本号
                    if (version == "" || version == null) continue;// 在exe文件名中没有找到版本号
                    int web = int.Parse(version.Replace(".", ""));
                    int local = int.Parse(Application.ProductVersion.Replace(".", ""));
                    if (web < local) continue;// 本地比服务器版本高
                    if (web == local) continue;// 本地与服务器版本相同
                    if (MessageBox.Show("发现新版本：" + version + "\r\n当前版本：" + Application.ProductVersion + "\r\n按确定立即更新，请耐心等待后台下载完成安装", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;// 新版本更新选择窗口
                    Process.Start(file.FullName);
                    Environment.Exit(0);
                    return;
                }

                if (showWindows) MessageBox.Show("没有发现新版本", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (UnauthorizedAccessException)
            {
                if (MessageBox.Show("无权限访问更新地址，请是否继续运行？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;
            }
            catch (FileNotFoundException)
            {
                if (MessageBox.Show("更新地址不存在，请是否继续运行？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("程序更新时发生如下错误，是否继续运行？信息如下\r\n\r\n" + ex.ToString(), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;
            }
        }
    }
}
