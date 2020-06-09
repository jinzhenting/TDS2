namespace TDS2
{
    partial class OrderZForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.deliverButton = new System.Windows.Forms.Button();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.filesListView = new DoubleBufferListView();
            this.orderPictureBox = new System.Windows.Forms.PictureBox();
            this.filesIconImageList = new System.Windows.Forms.ImageList(this.components);
            this.messageListView = new DoubleBufferListView();
            this.otherListView = new DoubleBufferListView();
            this.picturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(877, 358);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 40);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "取消 (Esc)";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // deliverButton
            // 
            this.deliverButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deliverButton.Location = new System.Drawing.Point(771, 358);
            this.deliverButton.Name = "deliverButton";
            this.deliverButton.Size = new System.Drawing.Size(100, 40);
            this.deliverButton.TabIndex = 3;
            this.deliverButton.Text = "开始 (Enter)";
            this.deliverButton.UseVisualStyleBackColor = true;
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
            this.picturePanel.Size = new System.Drawing.Size(757, 546);
            this.picturePanel.TabIndex = 1;
            // 
            // filesListView
            // 
            this.filesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filesListView.FullRowSelect = true;
            this.filesListView.GridLines = true;
            this.filesListView.Location = new System.Drawing.Point(-1, 395);
            this.filesListView.MultiSelect = false;
            this.filesListView.Name = "filesListView";
            this.filesListView.Size = new System.Drawing.Size(757, 150);
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
            this.orderPictureBox.Size = new System.Drawing.Size(726, 365);
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
            // messageListView
            // 
            this.messageListView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.messageListView.FullRowSelect = true;
            this.messageListView.GridLines = true;
            this.messageListView.Location = new System.Drawing.Point(771, 133);
            this.messageListView.MultiSelect = false;
            this.messageListView.Name = "messageListView";
            this.messageListView.Size = new System.Drawing.Size(255, 219);
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
            this.otherListView.Size = new System.Drawing.Size(1018, 120);
            this.otherListView.TabIndex = 0;
            this.otherListView.TabStop = false;
            this.otherListView.UseCompatibleStateImageBehavior = false;
            this.otherListView.View = System.Windows.Forms.View.Details;
            // 
            // OrderZForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 691);
            this.Controls.Add(this.messageListView);
            this.Controls.Add(this.otherListView);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.deliverButton);
            this.Controls.Add(this.picturePanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(600, 480);
            this.Name = "OrderZForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "打版";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrderZForm_KeyDown);
            this.Resize += new System.EventHandler(this.OrderZForm_Resize);
            this.picturePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferListView messageListView;
        private DoubleBufferListView otherListView;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button deliverButton;
        private System.Windows.Forms.Panel picturePanel;
        private DoubleBufferListView filesListView;
        private System.Windows.Forms.PictureBox orderPictureBox;
        private System.Windows.Forms.ImageList filesIconImageList;
    }
}