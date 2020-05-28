using System;
using System.Collections.Generic;

namespace TDS2
{
    public class MessageNotes
    {
        /// <summary>
        /// 发送人
        /// </summary>
        private string sendUser;
        /// <summary>
        /// 发送人
        /// </summary>
        public string SendUser
        {
            get { return sendUser; }
            set { sendUser = value; }
        }

        /// <summary>
        /// 发送时间
        /// </summary>
        private string sendTime;
        /// <summary>
        /// 发送时间
        /// </summary>
        public string SendTime
        {
            get { return sendTime; }
            set { sendTime = value; }
        }

        /// <summary>
        /// 发送电脑
        /// </summary>
        private string sendComputer;
        /// <summary>
        /// 发送电脑
        /// </summary>
        public string SendComputer
        {
            get { return sendComputer; }
            set { sendComputer = value; }
        }

        /// <summary>
        /// 接收人
        /// </summary>
        private string receiveUser;
        /// <summary>
        /// 接收人
        /// </summary>
        public string ReceiveUser
        {
            get { return receiveUser; }
            set { receiveUser = value; }
        }

        /// <summary>
        /// 接收部门
        /// </summary>
        private string receiveDepartment;
        /// <summary>
        /// 接收部门
        /// </summary>
        public string ReceiveDepartment
        {
            get { return receiveDepartment; }
            set { receiveDepartment = value; }
        }
        
        /// <summary>
        /// 关联订单号
        /// </summary>
        private string orderTape;
        /// <summary>
        /// 关联订单号
        /// </summary>
        public string OrderTape
        {
            get { return orderTape; }
            set { orderTape = value; }
        }
        
        /// <summary>
        /// 内容
        /// </summary>
        private List<string> messageContent = new List<string>();
        /// <summary>
        /// 内容
        /// </summary>
        public List<string> MessageContent
        {
            get { return messageContent; }
            set { messageContent = value; }
        }

        /// <summary>
        /// 是否已读
        /// </summary>
        private bool reading;
        /// <summary>
        /// 是否已读
        /// </summary>
        public bool Reading
        {
            get { return reading; }
            set { reading = value; }
        }

        /// <summary>
        /// 读取时间
        /// </summary>
        private DateTime readTime;
        /// <summary>
        /// 读取时间
        /// </summary>
        public DateTime ReadTime
        {
            get { return readTime; }
            set { readTime = value; }
        }

        /// <summary>
        /// 是否已处理
        /// </summary>
        private bool complete;
        /// <summary>
        /// 是否已处理
        /// </summary>
        public bool Complete
        {
            get { return complete; }
            set { complete = value; }
        }

        /// <summary>
        /// 读取时间
        /// </summary>
        private DateTime completeTime;
        /// <summary>
        /// 读取时间
        /// </summary>
        public DateTime CompleteTime
        {
            get { return completeTime; }
            set { completeTime = value; }
        }

    }
}
