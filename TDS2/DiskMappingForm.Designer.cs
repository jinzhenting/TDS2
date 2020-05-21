namespace TDS2
{
    partial class DiskMappingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.zFileLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.diskListView = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.url = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.disk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.automapping = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.connectAccount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.forever = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.autoCheck = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.log = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.exitButton = new System.Windows.Forms.Button();
            this.mappingBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mappingButton = new System.Windows.Forms.Button();
            this.breakButton = new System.Windows.Forms.Button();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.reSelectButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.diskProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.diskProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.breakBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zFileLabel
            // 
            this.zFileLabel.AutoSize = true;
            this.zFileLabel.Location = new System.Drawing.Point(9, 7);
            this.zFileLabel.Name = "zFileLabel";
            this.zFileLabel.Size = new System.Drawing.Size(32, 17);
            this.zFileLabel.TabIndex = 52;
            this.zFileLabel.Text = "列表";
            this.zFileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diskListView
            // 
            this.diskListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diskListView.CheckBoxes = true;
            this.diskListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.url,
            this.disk,
            this.automapping,
            this.connectAccount,
            this.forever,
            this.autoCheck,
            this.log});
            this.diskListView.FullRowSelect = true;
            this.diskListView.GridLines = true;
            this.diskListView.Location = new System.Drawing.Point(-1, 31);
            this.diskListView.MultiSelect = false;
            this.diskListView.Name = "diskListView";
            this.diskListView.Size = new System.Drawing.Size(986, 472);
            this.diskListView.TabIndex = 99;
            this.diskListView.UseCompatibleStateImageBehavior = false;
            this.diskListView.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "名称";
            this.name.Width = 100;
            // 
            // url
            // 
            this.url.Text = "网络位置";
            this.url.Width = 200;
            // 
            // disk
            // 
            this.disk.Text = "盘符";
            this.disk.Width = 40;
            // 
            // automapping
            // 
            this.automapping.Text = "自动映射";
            this.automapping.Width = 70;
            // 
            // connectAccount
            // 
            this.connectAccount.Text = "网络认证方式";
            this.connectAccount.Width = 100;
            // 
            // forever
            // 
            this.forever.Text = "映射性质";
            this.forever.Width = 70;
            // 
            // autoCheck
            // 
            this.autoCheck.Text = "断开检测";
            this.autoCheck.Width = 70;
            // 
            // log
            // 
            this.log.Text = "日志";
            this.log.Width = 270;
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Location = new System.Drawing.Point(903, 509);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 101;
            this.exitButton.Text = "退出";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // mappingBackgroundWorker
            // 
            this.mappingBackgroundWorker.WorkerReportsProgress = true;
            this.mappingBackgroundWorker.WorkerSupportsCancellation = true;
            this.mappingBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.mappingBackgroundWorker_DoWork);
            this.mappingBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.mappingBackgroundWorker_ProgressChanged);
            this.mappingBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.mappingBackgroundWorker_RunWorkerCompleted);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Location = new System.Drawing.Point(881, 4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown1.TabIndex = 102;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(795, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 103;
            this.label1.Text = "断开检测间隔";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(947, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 104;
            this.label2.Text = "分钟";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mappingButton
            // 
            this.mappingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mappingButton.Location = new System.Drawing.Point(741, 509);
            this.mappingButton.Name = "mappingButton";
            this.mappingButton.Size = new System.Drawing.Size(75, 23);
            this.mappingButton.TabIndex = 105;
            this.mappingButton.Text = "映射";
            this.mappingButton.UseVisualStyleBackColor = true;
            this.mappingButton.Click += new System.EventHandler(this.mappingButton_Click);
            // 
            // breakButton
            // 
            this.breakButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.breakButton.Location = new System.Drawing.Point(822, 509);
            this.breakButton.Name = "breakButton";
            this.breakButton.Size = new System.Drawing.Size(75, 23);
            this.breakButton.TabIndex = 106;
            this.breakButton.Text = "断开";
            this.breakButton.UseVisualStyleBackColor = true;
            this.breakButton.Click += new System.EventHandler(this.breakButton_Click);
            // 
            // selectAllButton
            // 
            this.selectAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectAllButton.Location = new System.Drawing.Point(6, 509);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(75, 23);
            this.selectAllButton.TabIndex = 107;
            this.selectAllButton.Text = "全选";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // reSelectButton
            // 
            this.reSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.reSelectButton.Location = new System.Drawing.Point(87, 509);
            this.reSelectButton.Name = "reSelectButton";
            this.reSelectButton.Size = new System.Drawing.Size(75, 23);
            this.reSelectButton.TabIndex = 108;
            this.reSelectButton.Text = "反选";
            this.reSelectButton.UseVisualStyleBackColor = true;
            this.reSelectButton.Click += new System.EventHandler(this.reSelectButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diskProgressBar,
            this.diskProgressLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 109;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // diskProgressBar
            // 
            this.diskProgressBar.Name = "diskProgressBar";
            this.diskProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // diskProgressLabel
            // 
            this.diskProgressLabel.Name = "diskProgressLabel";
            this.diskProgressLabel.Size = new System.Drawing.Size(80, 17);
            this.diskProgressLabel.Text = "等待用户操作";
            // 
            // breakBackgroundWorker
            // 
            this.breakBackgroundWorker.WorkerReportsProgress = true;
            this.breakBackgroundWorker.WorkerSupportsCancellation = true;
            this.breakBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.breakBackgroundWorker_DoWork);
            this.breakBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.breakBackgroundWorker_ProgressChanged);
            this.breakBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.breakBackgroundWorker_RunWorkerCompleted);
            // 
            // DiskMappingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.reSelectButton);
            this.Controls.Add(this.selectAllButton);
            this.Controls.Add(this.breakButton);
            this.Controls.Add(this.mappingButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.diskListView);
            this.Controls.Add(this.zFileLabel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "DiskMappingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "磁盘映射";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DiskMappingForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label zFileLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ListView diskListView;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader url;
        private System.Windows.Forms.ColumnHeader disk;
        private System.Windows.Forms.ColumnHeader automapping;
        private System.Windows.Forms.ColumnHeader autoCheck;
        private System.Windows.Forms.Button exitButton;
        private System.ComponentModel.BackgroundWorker mappingBackgroundWorker;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader log;
        private System.Windows.Forms.Button mappingButton;
        private System.Windows.Forms.Button breakButton;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.Button reSelectButton;
        private System.Windows.Forms.ColumnHeader forever;
        private System.Windows.Forms.ColumnHeader connectAccount;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar diskProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel diskProgressLabel;
        private System.ComponentModel.BackgroundWorker breakBackgroundWorker;
    }
}