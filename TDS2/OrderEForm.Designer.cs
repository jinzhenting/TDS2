namespace TDS2
{
    partial class OrderEForm
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
            this.messageListView = new DoubleBufferListView();
            this.otherListView = new DoubleBufferListView();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.filesListView = new DoubleBufferListView();
            this.orderPictureBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.difficultyRadioButtonA = new System.Windows.Forms.RadioButton();
            this.difficultyRadioButtonB = new System.Windows.Forms.RadioButton();
            this.difficultyRadioButtonC = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.filesIconImageList = new System.Windows.Forms.ImageList(this.components);
            this.picturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderPictureBox)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // messageListView
            // 
            this.messageListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageListView.FullRowSelect = true;
            this.messageListView.GridLines = true;
            this.messageListView.Location = new System.Drawing.Point(759, 133);
            this.messageListView.MultiSelect = false;
            this.messageListView.Name = "messageListView";
            this.messageListView.Size = new System.Drawing.Size(268, 219);
            this.messageListView.TabIndex = 2;
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
            this.otherListView.Size = new System.Drawing.Size(1019, 120);
            this.otherListView.TabIndex = 0;
            this.otherListView.TabStop = false;
            this.otherListView.UseCompatibleStateImageBehavior = false;
            this.otherListView.View = System.Windows.Forms.View.Details;
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
            this.picturePanel.Size = new System.Drawing.Size(745, 550);
            this.picturePanel.TabIndex = 1;
            // 
            // filesListView
            // 
            this.filesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filesListView.FullRowSelect = true;
            this.filesListView.GridLines = true;
            this.filesListView.Location = new System.Drawing.Point(-1, 399);
            this.filesListView.MultiSelect = false;
            this.filesListView.Name = "filesListView";
            this.filesListView.Size = new System.Drawing.Size(745, 150);
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
            this.orderPictureBox.Size = new System.Drawing.Size(714, 370);
            this.orderPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.orderPictureBox.TabIndex = 0;
            this.orderPictureBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(880, 496);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 40);
            this.button1.TabIndex = 7;
            this.button1.Text = "车版完毕 (Enter)";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.numericUpDown1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.numericUpDown2);
            this.panel4.Location = new System.Drawing.Point(759, 404);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(268, 40);
            this.panel4.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "绣花机号";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(70, 6);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(55, 23);
            this.numericUpDown2.TabIndex = 1;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(200, 6);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(55, 23);
            this.numericUpDown1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "修改次数";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.radioButton4);
            this.panel2.Controls.Add(this.radioButton5);
            this.panel2.Controls.Add(this.radioButton6);
            this.panel2.Location = new System.Drawing.Point(759, 358);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 40);
            this.panel2.TabIndex = 3;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(218, 11);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(43, 21);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "N2";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "是否车版";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(67, 11);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(46, 21);
            this.radioButton4.TabIndex = 1;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Yes";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(119, 11);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(44, 21);
            this.radioButton5.TabIndex = 2;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "No";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(169, 11);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(43, 21);
            this.radioButton6.TabIndex = 3;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "N1";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.difficultyRadioButtonA);
            this.panel1.Controls.Add(this.difficultyRadioButtonB);
            this.panel1.Controls.Add(this.difficultyRadioButtonC);
            this.panel1.Location = new System.Drawing.Point(759, 450);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 40);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "车版质量问题等级";
            // 
            // difficultyRadioButtonA
            // 
            this.difficultyRadioButtonA.AutoSize = true;
            this.difficultyRadioButtonA.Location = new System.Drawing.Point(129, 9);
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
            this.difficultyRadioButtonB.Location = new System.Drawing.Point(171, 9);
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
            this.difficultyRadioButtonC.Location = new System.Drawing.Point(220, 9);
            this.difficultyRadioButtonC.Name = "difficultyRadioButtonC";
            this.difficultyRadioButtonC.Size = new System.Drawing.Size(34, 21);
            this.difficultyRadioButtonC.TabIndex = 3;
            this.difficultyRadioButtonC.TabStop = true;
            this.difficultyRadioButtonC.Text = "C";
            this.difficultyRadioButtonC.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(759, 496);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 40);
            this.button2.TabIndex = 6;
            this.button2.Text = "选线色 (Space)";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // filesIconImageList
            // 
            this.filesIconImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.filesIconImageList.ImageSize = new System.Drawing.Size(64, 64);
            this.filesIconImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // OrderEForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 691);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.messageListView);
            this.Controls.Add(this.otherListView);
            this.Controls.Add(this.picturePanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1050, 730);
            this.Name = "OrderEForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "车版";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrderEForm_KeyDown);
            this.Resize += new System.EventHandler(this.OrderEForm_Resize);
            this.picturePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderPictureBox)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DoubleBufferListView messageListView;
        private DoubleBufferListView otherListView;
        private System.Windows.Forms.Panel picturePanel;
        private DoubleBufferListView filesListView;
        private System.Windows.Forms.PictureBox orderPictureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton difficultyRadioButtonA;
        private System.Windows.Forms.RadioButton difficultyRadioButtonB;
        private System.Windows.Forms.RadioButton difficultyRadioButtonC;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ImageList filesIconImageList;
    }
}