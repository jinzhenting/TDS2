using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TDS2
{
    public partial class MessagePanel : UserControl
    {
        public MessagePanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 最后接收时间
        /// </summary>
        public DateTime LastGetMessageTime;

        /// <summary>
        /// 新消息
        /// </summary>
        /// <param name="me">用户</param>
        /// <param name="messageNote"></param>
        public void New(User me, MessageNote messageNote)
        {
            foreach (string msg in messageNote.MessageContent)
            {



                //label1.Paint += new PaintEventHandler(DrawBorder(label1,));

            }
        }

        /// <summary>
        /// 功控填充颜色所用brush
        /// </summary>
        private SolidBrush SegBrush;

        /// <summary>
        /// 绘制边框
        /// </summary>
        /// <param name="label">Label</param>
        /// <param name="g"></param>
        /// <param name="color">lable背景颜色</param>
        /// <param name="color">边框颜色</param>       
        private void DrawBorder(Label label, Graphics g, Color color, Color bordercolor)
        {
            SegBrush = new SolidBrush(color);
            Pen pen = new Pen(SegBrush, 1);
            //e.Graphics.FillRectangle(SegBrush, RcTime);
            label.BorderStyle = BorderStyle.None;
            label.BackColor = color;
            pen.Color = Color.White;
            Rectangle myRectangle = new Rectangle(0, 0, label.Width, label.Height);
            ControlPaint.DrawBorder(g, myRectangle, bordercolor, ButtonBorderStyle.Solid);//画个边框
            // g.DrawRectangle(pen, myRectangle);
            // g.DrawEllipse(pen, myRectangle);
        }
        

        ///



    }
}
