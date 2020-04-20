using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TDS2
{
   public class Order
    {
        /// <summary>
        /// 订单号
        /// </summary>
        private string orderName;
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderName
        {
            get { return orderName; }
            set { orderName = value; }
        }

        /// <summary>
        /// 订单类型
        /// </summary>
        private string orderClass;
        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderClass
        {
            get { return orderClass; }
            set { orderClass = value; }
        }

        /// <summary>
        /// 接单时间（TB）
        /// </summary>
        private DateTime? orderInTime;
        /// <summary>
        /// 接单时间（TB）
        /// </summary>
        public DateTime? OrderInTime
        {
            get { return orderInTime; }
            set { orderInTime = value; }
        }

        /// <summary>
        /// 接单年
        /// </summary>
        private string orderInYear;
        /// <summary>
        /// 接单年
        /// </summary>
        public string OrderInYear
        {
            get { return orderInYear; }
            set { orderInYear = value; }
        }

        /// <summary>
        /// 接单月
        /// </summary>
        private string orderInMonth;
        /// <summary>
        /// 接单月
        /// </summary>
        public string OrderInMonth
        {
            get { return orderInMonth; }
            set { orderInMonth = value; }
        }

        /// <summary>
        /// 接单日
        /// </summary>
        private string orderInDay;
        /// <summary>
        /// 接单日
        /// </summary>
        public string OrderInDay
        {
            get { return orderInDay; }
            set { orderInDay = value; }
        }

        /// <summary>
        /// 客户
        /// </summary>
        private string orderCustomer;
        /// <summary>
        /// 客户
        /// </summary>
        public string OrderCustomer
        {
            get { return orderCustomer; }
            set { orderCustomer = value; }
        }

        /// <summary>
        /// 订单紧急度
        /// </summary>
        private string orderUrgency;
        /// <summary>
        /// 订单紧急度
        /// </summary>
        public string OrderUrgency
        {
            get { return orderUrgency; }
            set { orderUrgency = value; }
        }

        /// <summary>
        /// 订单在此时间前返回
        /// </summary>
        private DateTime? orderLatestReturnTime;
        /// <summary>
        /// 订单在此时间前返回
        /// </summary>
        public DateTime? OrderLatestReturnTime
        {
            get { return orderLatestReturnTime; }
            set { orderLatestReturnTime = value; }
        }

        /// <summary>
        /// 订单电脑区域
        /// </summary>
        private string orderComputer;
        /// <summary>
        /// 订单电脑区域
        /// </summary>
        public string OrderComputer
        {
            get { return orderComputer; }
            set { orderComputer = value; }
        }

        /// <summary>
        /// 打版难度
        /// </summary>
        private string orderDifficulty;
        /// <summary>
        /// 打版难度
        /// </summary>
        public string OrderDifficulty
        {
            get { return orderDifficulty; }
            set { orderDifficulty = value; }
        }

        /// <summary>
        /// 返回文件格式
        /// </summary>
        private string orderReturnFormat;
        /// <summary>
        /// 返回文件格式
        /// </summary>
        public string OrderReturnFormat
        {
            get { return orderReturnFormat; }
            set { orderReturnFormat = value; }
        }

        /// <summary>
        /// 订单最后修改时间
        /// </summary>
        private DateTime? orderLastModiTime;
        /// <summary>
        /// 订单最后修改时间
        /// </summary>
        public DateTime? OrderLastModiTime
        {
            get { return orderLastModiTime; }
            set { orderLastModiTime = value; }
        }

        /// <summary>
        /// 订单接发总用时
        /// </summary>
        private double orderTimeSpent;
        /// <summary>
        /// 订单接发总用时
        /// </summary>
        public double OrderTimeSpent
        {
            get { return orderTimeSpent; }
            set { orderTimeSpent = value; }
        }

        /// <summary>
        /// 订单包含版带数量
        /// </summary>
        private int orderQuantity;
        /// <summary>
        /// 订单包含版带数量
        /// </summary>
        public int OrderQuantity
        {
            get { return orderQuantity; }
            set { orderQuantity = value; }
        }

        /// <summary>
        /// 订单描述
        /// </summary>
        private string orderDescription;
        /// <summary>
        /// 订单描述
        /// </summary>
        public string OrderDescription
        {
            get { return orderDescription; }
            set { orderDescription = value; }
        }

        /// <summary>
        /// 接带人员
        /// </summary>
        private string nrInQC;
        /// <summary>
        /// 接带人员
        /// </summary>
        public string NrInQC
        {
            get { return nrInQC; }
            set { nrInQC = value; }
        }

        /// <summary>
        /// 接带班次
        /// </summary>
        private string nrInShift;
        /// <summary>
        /// 接带班次
        /// </summary>
        public string NrInShift
        {
            get { return nrInShift; }
            set { nrInShift = value; }
        }

        /// <summary>
        /// 接带计算机
        /// </summary>
        private string nrInComputer;
        /// <summary>
        /// 接带计算机
        /// </summary>
        public string NrInComputer
        {
            get { return nrInComputer; }
            set { nrInComputer = value; }
        }

        /// <summary>
        /// 接带时间
        /// </summary>
        private DateTime? nrInTime;
        /// <summary>
        /// 接带时间
        /// </summary>
        public DateTime? NrInTime
        {
            get { return nrInTime; }
            set { nrInTime = value; }
        }

        /// <summary>
        /// 分带人员
        /// </summary>
        private string embManager;
        /// <summary>
        /// 分带人员
        /// </summary>
        public string EmbManager
        {
            get { return embManager; }
            set { embManager = value; }
        }

        /// <summary>
        /// 图案风格
        /// </summary>
        private string embClass;
        /// <summary>
        /// 图案风格
        /// </summary>
        public string EmbClass
        {
            get { return embClass; }
            set { embClass = value; }
        }

        /// <summary>
        /// 版带版本
        /// </summary>
        private string embVersion;
        /// <summary>
        /// 版带版本
        /// </summary>
        public string EmbVersion
        {
            get { return embVersion; }
            set { embVersion = value; }
        }

        /// <summary>
        /// 改带利用版本
        /// </summary>
        private string embEditVersion;
        /// <summary>
        /// 改带利用版本
        /// </summary>
        public string EmbEditVersion
        {
            get { return embEditVersion; }
            set { embEditVersion = value; }
        }

        /// <summary>
        /// 打版人员
        /// </summary>
        private string embZ;
        /// <summary>
        /// 打版人员
        /// </summary>
        public string EmbZ
        {
            get { return embZ; }
            set { embZ = value; }
        }

        /// <summary>
        /// 原打版人员
        /// </summary>
        private string embOriginalZ;
        /// <summary>
        /// 原打版人员
        /// </summary>
        public string EmbOriginalZ
        {
            get { return embOriginalZ; }
            set { embOriginalZ = value; }
        }

        /// <summary>
        /// 打版班次
        /// </summary>
        private string embZShift;
        /// <summary>
        /// 打版班次
        /// </summary>
        public string EmbZShift
        {
            get { return embZShift; }
            set { embZShift = value; }
        }

        /// <summary>
        /// 打版开始时间
        /// </summary>
        private DateTime? embZStartTime;
        /// <summary>
        /// 打版开始时间
        /// </summary>
        public DateTime? EmbZStartTime
        {
            get { return embZStartTime; }
            set { embZStartTime = value; }
        }

        /// <summary>
        /// 打版完成时间
        /// </summary>
        private DateTime? embZEndTime;
        /// <summary>
        /// 打版完成时间
        /// </summary>
        public DateTime? EmbZEndTime
        {
            get { return embZEndTime; }
            set { embZEndTime = value; }
        }

        /// <summary>
        /// 打版师针数
        /// </summary>
        private int embZCount;
        /// <summary>
        /// 打版师针数
        /// </summary>
        public int EmbZCount
        {
            get { return embZCount; }
            set { embZCount = value; }
        }

        /// <summary>
        /// 总针数
        /// </summary>
        private int embCount;
        /// <summary>
        /// 总针数
        /// </summary>
        public int EmbCount
        {
            get { return embCount; }
            set { embCount = value; }
        }

        /// <summary>
        /// 收费针数
        /// </summary>
        private int embChargesCount;
        /// <summary>
        /// 收费针数
        /// </summary>
        public int EmbChargesCount
        {
            get { return embChargesCount; }
            set { embChargesCount = value; }
        }

        /// <summary>
        /// 是否车版
        /// </summary>
        private bool embSewout;
        /// <summary>
        /// 是否车版
        /// </summary>
        public bool EmbSewout
        {
            get { return embSewout; }
            set { embSewout = value; }
        }

        /// <summary>
        /// 车版人员
        /// </summary>
        private string embE;
        /// <summary>
        /// 车版人员
        /// </summary>
        public string EmbE
        {
            get { return embE; }
            set { embE = value; }
        }

        /// <summary>
        /// 车版完成时间
        /// </summary>
        private DateTime? embEEndTime;
        /// <summary>
        /// 车版完成时间
        /// </summary>
        public DateTime? EmbEEndTime
        {
            get { return embEEndTime; }
            set { embEEndTime = value; }
        }

        /// <summary>
        /// 车版机器编号
        /// </summary>
        private string embSewingMachine;
        /// <summary>
        /// 车版机器编号
        /// </summary>
        public string EmbSewingMachine
        {
            get { return embSewingMachine; }
            set { embSewingMachine = value; }
        }

        /// <summary>
        /// 质检人员
        /// </summary>
        private string embQi;
        /// <summary>
        /// 质检人员
        /// </summary>
        public string EmbQi
        {
            get { return embQi; }
            set { embQi = value; }
        }

        /// <summary>
        /// 打版质量问题等级
        /// </summary>
        private string embQualityLevel;
        /// <summary>
        /// 打版质量问题等级
        /// </summary>
        public string EmbQualityLevel
        {
            get { return embQualityLevel; }
            set { embQualityLevel = value; }
        }

        /// <summary>
        /// 重新车版次数
        /// </summary>
        private int embReSewoutCount;
        /// <summary>
        /// 重新车版次数
        /// </summary>
        public int EmbReSewoutCount
        {
            get { return embReSewoutCount; }
            set { embReSewoutCount = value; }
        }

        /// <summary>
        /// 扫描人员
        /// </summary>
        private string embScaner;
        /// <summary>
        /// 扫描人员
        /// </summary>
        public string EmbScaner
        {
            get { return embScaner; }
            set { embScaner = value; }
        }

        /// <summary>
        /// 扫描完成时间
        /// </summary>
        private DateTime? embScanerTime;
        /// <summary>
        /// 扫描完成时间
        /// </summary>
        public DateTime? EmbScanerTime
        {
            get { return embScanerTime; }
            set { embScanerTime = value; }
        }

        /// <summary>
        /// 发带人员
        /// </summary>
        private string nrOutQc;
        /// <summary>
        /// 发带人员
        /// </summary>
        public string NrOutQc
        {
            get { return nrOutQc; }
            set { nrOutQc = value; }
        }

        /// <summary>
        /// 发带班次
        /// </summary>
        private string nrOutShift;
        /// <summary>
        /// 发带班次
        /// </summary>
        public string NrOutShift
        {
            get { return nrOutShift; }
            set { nrOutShift = value; }
        }

        /// <summary>
        /// 发带时间
        /// </summary>
        private DateTime? nrOutTime;
        /// <summary>
        /// 发带时间
        /// </summary>
        public DateTime? NrOutTime
        {
            get { return nrOutTime; }
            set { nrOutTime = value; }
        }

        /// <summary>
        /// 文件夹路径
        /// </summary>
        private string folderPath;
        /// <summary>
        /// 文件夹路径
        /// </summary>
        public string FolderPath
        {
            get { return folderPath; }
            set { folderPath = value; }
        }

        /// <summary>
        /// 文件路径
        /// </summary>
        private List<string> filesPath=new List<string>();
        /// <summary>
        /// 文件路径
        /// </summary>
        public List<string> FilesPath
        {
            get { return filesPath; }
            set { filesPath = value; }
        }
        
    }
}
