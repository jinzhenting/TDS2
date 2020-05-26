namespace TDS2
{
    partial class MessageForm
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
            this.uesrListView = new System.Windows.Forms.ListView();
            this.sendButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.getMessageTimer = new System.Windows.Forms.Timer(this.components);
            this.messageRichTextBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.getMessageBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.addPictureBox = new System.Windows.Forms.PictureBox();
            this.zooz1PictureBox = new System.Windows.Forms.PictureBox();
            this.zooz2PictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zooz1PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zooz2PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uesrListView
            // 
            this.uesrListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uesrListView.BackColor = System.Drawing.SystemColors.Menu;
            this.uesrListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.uesrListView.Location = new System.Drawing.Point(1, 0);
            this.uesrListView.Name = "uesrListView";
            this.uesrListView.Size = new System.Drawing.Size(229, 562);
            this.uesrListView.TabIndex = 0;
            this.uesrListView.UseCompatibleStateImageBehavior = false;
            this.uesrListView.View = System.Windows.Forms.View.List;
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.sendButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ScrollBar;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendButton.Location = new System.Drawing.Point(436, 147);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(100, 26);
            this.sendButton.TabIndex = 1;
            this.sendButton.TabStop = false;
            this.sendButton.Text = "发送 (Enter)";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            this.sendButton.MouseLeave += new System.EventHandler(this.sendButton_MouseLeave);
            this.sendButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sendButton_MouseMove);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Location = new System.Drawing.Point(236, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.messageRichTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.zooz2PictureBox);
            this.splitContainer1.Panel2.Controls.Add(this.zooz1PictureBox);
            this.splitContainer1.Panel2.Controls.Add(this.addPictureBox);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.sendButton);
            this.splitContainer1.Panel2.Controls.Add(this.sendTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(548, 562);
            this.splitContainer1.SplitterDistance = 377;
            this.splitContainer1.TabIndex = 8;
            this.splitContainer1.TabStop = false;
            // 
            // sendTextBox
            // 
            this.sendTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sendTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sendTextBox.Location = new System.Drawing.Point(13, 39);
            this.sendTextBox.Multiline = true;
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sendTextBox.Size = new System.Drawing.Size(523, 100);
            this.sendTextBox.TabIndex = 0;
            // 
            // getMessageTimer
            // 
            this.getMessageTimer.Interval = 5000;
            this.getMessageTimer.Tick += new System.EventHandler(this.getMessageTimer_Tick);
            // 
            // messageRichTextBox
            // 
            this.messageRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageRichTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.messageRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageRichTextBox.Location = new System.Drawing.Point(13, 12);
            this.messageRichTextBox.Name = "messageRichTextBox";
            this.messageRichTextBox.ReadOnly = true;
            this.messageRichTextBox.Size = new System.Drawing.Size(523, 352);
            this.messageRichTextBox.TabIndex = 0;
            this.messageRichTextBox.Text = "";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 1);
            this.panel1.TabIndex = 2;
            // 
            // getMessageBackgroundWorker
            // 
            this.getMessageBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.getMessageBackgroundWorker_DoWork);
            // 
            // addPictureBox
            // 
            this.addPictureBox.Location = new System.Drawing.Point(11, 6);
            this.addPictureBox.Name = "addPictureBox";
            this.addPictureBox.Size = new System.Drawing.Size(24, 24);
            this.addPictureBox.TabIndex = 3;
            this.addPictureBox.TabStop = false;
            this.addPictureBox.Click += new System.EventHandler(this.addPictureBox_Click);
            this.addPictureBox.MouseLeave += new System.EventHandler(this.addPictureBox_MouseLeave);
            this.addPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.addPictureBox_MouseMove);
            // 
            // zooz1PictureBox
            // 
            this.zooz1PictureBox.Location = new System.Drawing.Point(41, 6);
            this.zooz1PictureBox.Name = "zooz1PictureBox";
            this.zooz1PictureBox.Size = new System.Drawing.Size(24, 24);
            this.zooz1PictureBox.TabIndex = 4;
            this.zooz1PictureBox.TabStop = false;
            this.zooz1PictureBox.Click += new System.EventHandler(this.zooz1PictureBox_Click);
            this.zooz1PictureBox.MouseLeave += new System.EventHandler(this.zooz1PictureBox_MouseLeave);
            this.zooz1PictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.zooz1PictureBox_MouseMove);
            // 
            // zooz2PictureBox
            // 
            this.zooz2PictureBox.Location = new System.Drawing.Point(71, 6);
            this.zooz2PictureBox.Name = "zooz2PictureBox";
            this.zooz2PictureBox.Size = new System.Drawing.Size(24, 24);
            this.zooz2PictureBox.TabIndex = 5;
            this.zooz2PictureBox.TabStop = false;
            this.zooz2PictureBox.Click += new System.EventHandler(this.zooz2PictureBox_Click);
            this.zooz2PictureBox.MouseLeave += new System.EventHandler(this.zooz2PictureBox_MouseLeave);
            this.zooz2PictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.zooz2PictureBox_MouseMove);
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.uesrListView);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MessageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "消息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessagesForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessagesForm_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.addPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zooz1PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zooz2PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView uesrListView;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox sendTextBox;
        private System.Windows.Forms.Timer getMessageTimer;
        private System.Windows.Forms.RichTextBox messageRichTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker getMessageBackgroundWorker;
        private System.Windows.Forms.PictureBox addPictureBox;
        private System.Windows.Forms.PictureBox zooz2PictureBox;
        private System.Windows.Forms.PictureBox zooz1PictureBox;
    }
}