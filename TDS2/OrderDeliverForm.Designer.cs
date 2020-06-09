namespace TDS2
{
    partial class OrderDeliverForm
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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("打版师列表");
            this.picturePanel = new System.Windows.Forms.Panel();
            this.filesListView = new DoubleBufferListView();
            this.orderPictureBox = new System.Windows.Forms.PictureBox();
            this.filesIconImageList = new System.Windows.Forms.ImageList(this.components);
            this.deliverButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.difficultyRadioButtonA = new System.Windows.Forms.RadioButton();
            this.difficultyRadioButtonB = new System.Windows.Forms.RadioButton();
            this.difficultyRadioButtonC = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.quoteCountComboBox1 = new System.Windows.Forms.ComboBox();
            this.quoteCountComboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.zImageList = new System.Windows.Forms.ImageList(this.components);
            this.zListView = new DoubleBufferListView();
            this.messageListView = new DoubleBufferListView();
            this.otherListView = new DoubleBufferListView();
            this.doubleBufferListView1 = new DoubleBufferListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statisticsButton = new System.Windows.Forms.Button();
            this.picturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picturePanel
            // 
            this.picturePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picturePanel.BackColor = System.Drawing.SystemColors.Window;
            this.picturePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picturePanel.Controls.Add(this.filesListView);
            this.picturePanel.Controls.Add(this.orderPictureBox);
            this.picturePanel.Location = new System.Drawing.Point(8, 133);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(645, 600);
            this.picturePanel.TabIndex = 1;
            // 
            // filesListView
            // 
            this.filesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filesListView.FullRowSelect = true;
            this.filesListView.GridLines = true;
            this.filesListView.Location = new System.Drawing.Point(-1, 449);
            this.filesListView.MultiSelect = false;
            this.filesListView.Name = "filesListView";
            this.filesListView.Size = new System.Drawing.Size(646, 150);
            this.filesListView.TabIndex = 0;
            this.filesListView.UseCompatibleStateImageBehavior = false;
            this.filesListView.SelectedIndexChanged += new System.EventHandler(this.filesListView_SelectedIndexChanged);
            // 
            // orderPictureBox
            // 
            this.orderPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.orderPictureBox.Location = new System.Drawing.Point(15, 14);
            this.orderPictureBox.Name = "orderPictureBox";
            this.orderPictureBox.Size = new System.Drawing.Size(614, 420);
            this.orderPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.orderPictureBox.TabIndex = 0;
            this.orderPictureBox.TabStop = false;
            // 
            // filesIconImageList
            // 
            this.filesIconImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.filesIconImageList.ImageSize = new System.Drawing.Size(64, 64);
            this.filesIconImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // deliverButton
            // 
            this.deliverButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deliverButton.Location = new System.Drawing.Point(915, 483);
            this.deliverButton.Name = "deliverButton";
            this.deliverButton.Size = new System.Drawing.Size(100, 40);
            this.deliverButton.TabIndex = 8;
            this.deliverButton.Text = "分发 (Enter)";
            this.deliverButton.UseVisualStyleBackColor = true;
            this.deliverButton.Click += new System.EventHandler(this.deliverButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(1021, 483);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(120, 40);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "取消分发 (Back)";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "打版难度";
            // 
            // difficultyRadioButtonA
            // 
            this.difficultyRadioButtonA.AutoSize = true;
            this.difficultyRadioButtonA.Location = new System.Drawing.Point(70, 9);
            this.difficultyRadioButtonA.Name = "difficultyRadioButtonA";
            this.difficultyRadioButtonA.Size = new System.Drawing.Size(34, 21);
            this.difficultyRadioButtonA.TabIndex = 1;
            this.difficultyRadioButtonA.TabStop = true;
            this.difficultyRadioButtonA.Text = "A";
            this.difficultyRadioButtonA.UseVisualStyleBackColor = true;
            // 
            // difficultyRadioButtonB
            // 
            this.difficultyRadioButtonB.AutoSize = true;
            this.difficultyRadioButtonB.Location = new System.Drawing.Point(113, 9);
            this.difficultyRadioButtonB.Name = "difficultyRadioButtonB";
            this.difficultyRadioButtonB.Size = new System.Drawing.Size(34, 21);
            this.difficultyRadioButtonB.TabIndex = 2;
            this.difficultyRadioButtonB.TabStop = true;
            this.difficultyRadioButtonB.Text = "B";
            this.difficultyRadioButtonB.UseVisualStyleBackColor = true;
            // 
            // difficultyRadioButtonC
            // 
            this.difficultyRadioButtonC.AutoSize = true;
            this.difficultyRadioButtonC.Location = new System.Drawing.Point(156, 9);
            this.difficultyRadioButtonC.Name = "difficultyRadioButtonC";
            this.difficultyRadioButtonC.Size = new System.Drawing.Size(34, 21);
            this.difficultyRadioButtonC.TabIndex = 3;
            this.difficultyRadioButtonC.TabStop = true;
            this.difficultyRadioButtonC.Text = "C";
            this.difficultyRadioButtonC.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "估针数";
            // 
            // quoteCountComboBox1
            // 
            this.quoteCountComboBox1.FormattingEnabled = true;
            this.quoteCountComboBox1.Items.AddRange(new object[] {
            "1000",
            "2000",
            "3000",
            "4000",
            "5000",
            "6000",
            "7000",
            "8000",
            "9000",
            "10000",
            "11000",
            "12000",
            "13000",
            "14000",
            "15000",
            "16000",
            "17000",
            "18000",
            "19000",
            "20000"});
            this.quoteCountComboBox1.Location = new System.Drawing.Point(58, 7);
            this.quoteCountComboBox1.MaxDropDownItems = 50;
            this.quoteCountComboBox1.Name = "quoteCountComboBox1";
            this.quoteCountComboBox1.Size = new System.Drawing.Size(132, 25);
            this.quoteCountComboBox1.TabIndex = 1;
            // 
            // quoteCountComboBox2
            // 
            this.quoteCountComboBox2.FormattingEnabled = true;
            this.quoteCountComboBox2.Items.AddRange(new object[] {
            "1000",
            "2000",
            "3000",
            "4000",
            "5000",
            "6000",
            "7000",
            "8000",
            "9000",
            "10000",
            "11000",
            "12000",
            "13000",
            "14000",
            "15000",
            "16000",
            "17000",
            "18000",
            "19000",
            "20000"});
            this.quoteCountComboBox2.Location = new System.Drawing.Point(58, 38);
            this.quoteCountComboBox2.MaxDropDownItems = 50;
            this.quoteCountComboBox2.Name = "quoteCountComboBox2";
            this.quoteCountComboBox2.Size = new System.Drawing.Size(170, 25);
            this.quoteCountComboBox2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "至";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.difficultyRadioButtonA);
            this.panel1.Controls.Add(this.difficultyRadioButtonB);
            this.panel1.Controls.Add(this.difficultyRadioButtonC);
            this.panel1.Location = new System.Drawing.Point(915, 357);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 40);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.quoteCountComboBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.quoteCountComboBox2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(915, 403);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(242, 74);
            this.panel2.TabIndex = 7;
            // 
            // zImageList
            // 
            this.zImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.zImageList.ImageSize = new System.Drawing.Size(32, 32);
            this.zImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // zListView
            // 
            this.zListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.zListView.FullRowSelect = true;
            this.zListView.GridLines = true;
            this.zListView.Location = new System.Drawing.Point(661, 188);
            this.zListView.MultiSelect = false;
            this.zListView.Name = "zListView";
            this.zListView.Size = new System.Drawing.Size(246, 541);
            this.zListView.TabIndex = 4;
            this.zListView.UseCompatibleStateImageBehavior = false;
            // 
            // messageListView
            // 
            this.messageListView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.messageListView.FullRowSelect = true;
            this.messageListView.GridLines = true;
            this.messageListView.Location = new System.Drawing.Point(915, 133);
            this.messageListView.MultiSelect = false;
            this.messageListView.Name = "messageListView";
            this.messageListView.Size = new System.Drawing.Size(242, 218);
            this.messageListView.TabIndex = 5;
            this.messageListView.TabStop = false;
            this.messageListView.UseCompatibleStateImageBehavior = false;
            this.messageListView.View = System.Windows.Forms.View.Details;
            // 
            // otherListView
            // 
            this.otherListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.otherListView.FullRowSelect = true;
            this.otherListView.GridLines = true;
            this.otherListView.Location = new System.Drawing.Point(8, 7);
            this.otherListView.MultiSelect = false;
            this.otherListView.Name = "otherListView";
            this.otherListView.Size = new System.Drawing.Size(1149, 120);
            this.otherListView.TabIndex = 0;
            this.otherListView.TabStop = false;
            this.otherListView.UseCompatibleStateImageBehavior = false;
            this.otherListView.View = System.Windows.Forms.View.Details;
            // 
            // doubleBufferListView1
            // 
            this.doubleBufferListView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doubleBufferListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.doubleBufferListView1.FullRowSelect = true;
            this.doubleBufferListView1.GridLines = true;
            this.doubleBufferListView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.doubleBufferListView1.Location = new System.Drawing.Point(659, 133);
            this.doubleBufferListView1.MultiSelect = false;
            this.doubleBufferListView1.Name = "doubleBufferListView1";
            this.doubleBufferListView1.Size = new System.Drawing.Size(250, 600);
            this.doubleBufferListView1.TabIndex = 2;
            this.doubleBufferListView1.TabStop = false;
            this.doubleBufferListView1.UseCompatibleStateImageBehavior = false;
            this.doubleBufferListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "::";
            this.columnHeader1.Width = 151;
            // 
            // statisticsButton
            // 
            this.statisticsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statisticsButton.Location = new System.Drawing.Point(823, 144);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(75, 25);
            this.statisticsButton.TabIndex = 3;
            this.statisticsButton.Text = "分发统计";
            this.statisticsButton.UseVisualStyleBackColor = true;
            this.statisticsButton.Click += new System.EventHandler(this.statisticsButton_Click);
            // 
            // OrderDeliverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 741);
            this.Controls.Add(this.statisticsButton);
            this.Controls.Add(this.zListView);
            this.Controls.Add(this.messageListView);
            this.Controls.Add(this.otherListView);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.deliverButton);
            this.Controls.Add(this.picturePanel);
            this.Controls.Add(this.doubleBufferListView1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1180, 780);
            this.Name = "OrderDeliverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "分带";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrderDeliverForm_KeyDown);
            this.Resize += new System.EventHandler(this.OrderDeliverForm_Resize);
            this.picturePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferListView filesListView;
        private System.Windows.Forms.Panel picturePanel;
        private System.Windows.Forms.PictureBox orderPictureBox;
        private DoubleBufferListView otherListView;
        private System.Windows.Forms.ImageList filesIconImageList;
        private System.Windows.Forms.Button deliverButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton difficultyRadioButtonA;
        private System.Windows.Forms.RadioButton difficultyRadioButtonB;
        private System.Windows.Forms.RadioButton difficultyRadioButtonC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox quoteCountComboBox1;
        private System.Windows.Forms.ComboBox quoteCountComboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DoubleBufferListView messageListView;
        private DoubleBufferListView zListView;
        private System.Windows.Forms.ImageList zImageList;
        private DoubleBufferListView doubleBufferListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button statisticsButton;
    }
}