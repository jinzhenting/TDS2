namespace TDS2
{
    partial class OrderZStatisticsForm
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
            this.components = new System.ComponentModel.Container();
            this.zImageList = new System.Windows.Forms.ImageList(this.components);
            this.filesIconImageList = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statisticsProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statisticsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.closeButton = new System.Windows.Forms.Button();
            this.orderStartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.orderEndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.orderTimeLabel2 = new System.Windows.Forms.Label();
            this.orderTimeLabel1 = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.statisticsBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.typeListView = new DoubleBufferListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.zListView = new DoubleBufferListView();
            this.zColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.countColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stitchColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.endColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.histroyEfficiencyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.todayEfficiencyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.faultColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zImageList
            // 
            this.zImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.zImageList.ImageSize = new System.Drawing.Size(32, 32);
            this.zImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // filesIconImageList
            // 
            this.filesIconImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.filesIconImageList.ImageSize = new System.Drawing.Size(64, 64);
            this.filesIconImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statisticsProgressBar,
            this.statisticsLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 639);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statisticsProgressBar
            // 
            this.statisticsProgressBar.Name = "statisticsProgressBar";
            this.statisticsProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // statisticsLabel
            // 
            this.statisticsLabel.Name = "statisticsLabel";
            this.statisticsLabel.Size = new System.Drawing.Size(80, 17);
            this.statisticsLabel.Text = "等待用户操作";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(901, 609);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "关闭 (Esc)";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // orderStartDateTimePicker
            // 
            this.orderStartDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.orderStartDateTimePicker.Location = new System.Drawing.Point(65, 609);
            this.orderStartDateTimePicker.Name = "orderStartDateTimePicker";
            this.orderStartDateTimePicker.Size = new System.Drawing.Size(135, 23);
            this.orderStartDateTimePicker.TabIndex = 15;
            // 
            // orderEndDateTimePicker
            // 
            this.orderEndDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.orderEndDateTimePicker.Checked = false;
            this.orderEndDateTimePicker.Location = new System.Drawing.Point(228, 609);
            this.orderEndDateTimePicker.Name = "orderEndDateTimePicker";
            this.orderEndDateTimePicker.Size = new System.Drawing.Size(135, 23);
            this.orderEndDateTimePicker.TabIndex = 16;
            // 
            // orderTimeLabel2
            // 
            this.orderTimeLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.orderTimeLabel2.AutoSize = true;
            this.orderTimeLabel2.Location = new System.Drawing.Point(204, 612);
            this.orderTimeLabel2.Name = "orderTimeLabel2";
            this.orderTimeLabel2.Size = new System.Drawing.Size(20, 17);
            this.orderTimeLabel2.TabIndex = 18;
            this.orderTimeLabel2.Text = "到";
            // 
            // orderTimeLabel1
            // 
            this.orderTimeLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.orderTimeLabel1.AutoSize = true;
            this.orderTimeLabel1.Location = new System.Drawing.Point(6, 612);
            this.orderTimeLabel1.Name = "orderTimeLabel1";
            this.orderTimeLabel1.Size = new System.Drawing.Size(56, 17);
            this.orderTimeLabel1.TabIndex = 17;
            this.orderTimeLabel1.Text = "接带时间";
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.Location = new System.Drawing.Point(795, 609);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(100, 23);
            this.refreshButton.TabIndex = 31;
            this.refreshButton.Text = "重新载入 (F5)";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // statisticsBackgroundWorker
            // 
            this.statisticsBackgroundWorker.WorkerReportsProgress = true;
            this.statisticsBackgroundWorker.WorkerSupportsCancellation = true;
            this.statisticsBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.statisticsBackgroundWorker_DoWork);
            this.statisticsBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.statisticsBackgroundWorker_ProgressChanged);
            this.statisticsBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.statisticsBackgroundWorker_RunWorkerCompleted);
            // 
            // typeListView
            // 
            this.typeListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.typeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.typeListView.FullRowSelect = true;
            this.typeListView.GridLines = true;
            this.typeListView.Location = new System.Drawing.Point(529, 7);
            this.typeListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.typeListView.MultiSelect = false;
            this.typeListView.Name = "typeListView";
            this.typeListView.Size = new System.Drawing.Size(447, 595);
            this.typeListView.TabIndex = 7;
            this.typeListView.TabStop = false;
            this.typeListView.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = ":: 正在处理的版带";
            this.columnHeader2.Width = 135;
            // 
            // zListView
            // 
            this.zListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.zListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.zColumnHeader,
            this.countColumnHeader,
            this.stitchColumnHeader,
            this.endColumnHeader,
            this.histroyEfficiencyColumnHeader,
            this.todayEfficiencyColumnHeader,
            this.faultColumnHeader});
            this.zListView.FullRowSelect = true;
            this.zListView.GridLines = true;
            this.zListView.Location = new System.Drawing.Point(9, 7);
            this.zListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.zListView.MultiSelect = false;
            this.zListView.Name = "zListView";
            this.zListView.Size = new System.Drawing.Size(514, 595);
            this.zListView.TabIndex = 6;
            this.zListView.UseCompatibleStateImageBehavior = false;
            this.zListView.View = System.Windows.Forms.View.Details;
            // 
            // zColumnHeader
            // 
            this.zColumnHeader.Text = "打版师";
            this.zColumnHeader.Width = 50;
            // 
            // countColumnHeader
            // 
            this.countColumnHeader.Text = "已分带子数";
            this.countColumnHeader.Width = 75;
            // 
            // stitchColumnHeader
            // 
            this.stitchColumnHeader.Text = "已分针数";
            this.stitchColumnHeader.Width = 65;
            // 
            // endColumnHeader
            // 
            this.endColumnHeader.Text = "预计完成时间";
            this.endColumnHeader.Width = 90;
            // 
            // histroyEfficiencyColumnHeader
            // 
            this.histroyEfficiencyColumnHeader.Text = "历史效率";
            this.histroyEfficiencyColumnHeader.Width = 65;
            // 
            // todayEfficiencyColumnHeader
            // 
            this.todayEfficiencyColumnHeader.Text = "当天效率";
            this.todayEfficiencyColumnHeader.Width = 65;
            // 
            // faultColumnHeader
            // 
            this.faultColumnHeader.Text = "历史出错率";
            this.faultColumnHeader.Width = 75;
            // 
            // OrderZStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.orderStartDateTimePicker);
            this.Controls.Add(this.orderEndDateTimePicker);
            this.Controls.Add(this.orderTimeLabel2);
            this.Controls.Add(this.orderTimeLabel1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.typeListView);
            this.Controls.Add(this.zListView);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OrderZStatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "分发统计";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrderZStatisticsForm_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DoubleBufferListView zListView;
        private DoubleBufferListView typeListView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ImageList zImageList;
        private System.Windows.Forms.ImageList filesIconImageList;
        private System.Windows.Forms.ColumnHeader zColumnHeader;
        private System.Windows.Forms.ColumnHeader countColumnHeader;
        private System.Windows.Forms.ColumnHeader stitchColumnHeader;
        private System.Windows.Forms.ColumnHeader endColumnHeader;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar statisticsProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel statisticsLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DateTimePicker orderStartDateTimePicker;
        private System.Windows.Forms.DateTimePicker orderEndDateTimePicker;
        private System.Windows.Forms.Label orderTimeLabel2;
        private System.Windows.Forms.Label orderTimeLabel1;
        private System.Windows.Forms.Button refreshButton;
        private System.ComponentModel.BackgroundWorker statisticsBackgroundWorker;
        private System.Windows.Forms.ColumnHeader histroyEfficiencyColumnHeader;
        private System.Windows.Forms.ColumnHeader todayEfficiencyColumnHeader;
        private System.Windows.Forms.ColumnHeader faultColumnHeader;
    }
}