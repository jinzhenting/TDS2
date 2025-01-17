﻿
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TDS2
{
    public partial class OrderCheckForm : Form
    {
        public OrderCheckForm(DataRow orderRow)
        {
            InitializeComponent();

            ///

            try// 图标
            {
                Icon = new Icon(Path.Combine(Application.StartupPath, @"Image\Skin\Check.ico"));
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

            List<string> files = OrderFiles.Get(orderRow);

            ///

            filesListView.Columns.Add("::");
            filesListView.Columns[0].Width = 600;
            for (int i = 0; i < files.Count; i++)
            {
                Image icon;
                string extension = Path.GetExtension(files[i]).ToLower();
                switch (extension)
                {
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                    case ".gif":
                    case ".bmp":
                    case ".tif":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(files[i]), 64, 64);
                            break;
                        }
                    case ".ai":
                    case ".eps":
                    case ".svg":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\ai.png"), 64, 64);
                            break;
                        }
                    case ".psd":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\psd.png"), 64, 64);
                            break;
                        }
                    case ".cdr":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\cdr.png"), 64, 64);
                            break;
                        }
                    case ".doc":
                    case ".docx":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\doc.png"), 64, 64);
                            break;
                        }
                    case ".ppt":
                    case ".pptx":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\ppt.png"), 64, 64);
                            break;
                        }
                    case ".xls":
                    case ".xlsx":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\xls.png"), 64, 64);
                            break;
                        }
                    case ".pdf":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\pdf.png"), 64, 64);
                            break;
                        }
                    case ".dst":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\dst.png"), 64, 64);
                            break;
                        }
                    case ".emb":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\emb.png"), 64, 64);
                            break;
                        }
                    case ".omf":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\omf.png"), 64, 64);
                            break;
                        }
                    case ".psf":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\psf.png"), 64, 64);
                            break;
                        }
                    case ".pxf":
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\pxf.png"), 64, 64);
                            break;
                        }
                    default:
                        {
                            icon = ImageZoom.Zoom(Image.FromFile(@"Image\Extension\UnImage.png"), 64, 64);
                            break;
                        }
                }
                filesIconImageList.Images.Add(icon);
                ListViewItem listViewItem = new ListViewItem();// 定义单个项目
                listViewItem.ImageIndex = i;
                listViewItem.Text = files[i];
                filesListView.Items.Add(listViewItem);
            }
            filesListView.SmallImageList = filesIconImageList;
            filesListView.LargeImageList = filesIconImageList;
            foreach (ListViewItem l in filesListView.Items) l.Checked = true;
        }

        /// <summary>
        /// 导步载入文件
        /// </summary>
        private void loadFilesBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // 以后改为后台载入
        }

        private void loadFilesBackgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void loadFilesBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }

        /// <summary>
        /// 退出按钮
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 打开选中文件按钮
        /// </summary>
        private void checkButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem l in filesListView.Items)
            {
                if (l.Checked == true)
                {
                    try
                    {
                       Process.Start(l.Text);// 添加事件
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("打开文件出现错误，描述如下：\r\n\r\n" + ex, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        return;
                    }
                }
            }

        }

        /// <summary>
        /// 文件格式关联设置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void extensionButton_Click(object sender, EventArgs e)
        {
            AppSettingsForm settingForm = new AppSettingsForm();
            settingForm.ShowDialog();
        }

        ///


    }
}
