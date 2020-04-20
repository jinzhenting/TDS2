using System;
using System.Windows.Forms;

namespace TDS2
{
    public partial class AppSettingsForm : Form
    {
        public AppSettingsForm()
        {
            InitializeComponent();
            ///
            Disks disks = new Disks();// 获取文件系统
            zFileTextBox.Text = disks.ZFlie.NetPath;// 文件系统赋值
            zFileComboBox.Text = disks.ZFlie.LocalPath;
            newDataTextBox.Text = disks.NewData.NetPath;
            newDataComboBox.Text = disks.NewData.LocalPath;
            historyDataTextBox.Text = disks.HistoryData.NetPath;
            historyDataComboBox.Text = disks.HistoryData.LocalPath;
            oldDataTextBox.Text = disks.OldData.NetPath;
            oldDataComboBox.Text = disks.OldData.LocalPath;
            myAttachTextBox.Text = disks.MyAttach.NetPath;
            myAttachComboBox.Text = disks.MyAttach.LocalPath;
            dstTextBox.Text = disks.DST.NetPath;
            dstComboBox.Text = disks.DST.LocalPath;
            taTextBox.Text = disks.Ta.NetPath;
            taComboBox.Text = disks.Ta.LocalPath;
            tempTextBox.Text = disks.Temp.NetPath;
            tempComboBox.Text = disks.Temp.LocalPath;
            ///

        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        private void disksSaveButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        private void disksCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 浏览程序更新地址
        /// </summary>
        private void appUpButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 窗口载入时
        /// </summary>
        private void AppSettingsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
