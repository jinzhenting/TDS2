using System;
using System.Data;

namespace TDS2
{
    public static class OrderFunction
    {
        /// <summary>
        /// 数据行2订单
        /// </summary>
        /// <param name="newDataTable">新数据表</param>
        /// <param name="oldDataRow">旧数据行</param>
        public static Order Row2Order(DataRow oldDataRow)
        {
            Order order = new Order();

            ///

            order.OrderName = Convert.ToString(oldDataRow["sTape"]);// 订单号

            ///

            try { order.OrderInTime = Convert.ToDateTime(oldDataRow["T_in_time"]); }// 接单时间（TB）,,,,,,有些InTime有年月日有些没有
            catch { order.OrderInTime = null; }

            ///

            order.OrderInYear = Convert.ToString(oldDataRow["sYear"]);// 接单年

            ///

            order.OrderInMonth = Convert.ToString(oldDataRow["sMonth"]);// 接单月

            ///

            order.OrderInDay = Convert.ToString(oldDataRow["sDate"]);// 接单日

            ///

            order.OrderCustomer = Convert.ToString(oldDataRow["Code"]);// 客户

            ///

            switch (Convert.ToString(oldDataRow["Mode"])) // 订单类型
            {
                case "O":
                    {
                        order.OrderClass = "新带";
                        break;
                    }
                case "E":
                    {
                        order.OrderClass = "收费改带";
                        break;
                    }
                case "F":
                    {
                        order.OrderClass = "免费改带";
                        break;
                    }
                case "Q":
                    {
                        order.OrderClass = "估针";
                        break;
                    }
                case "T":
                    {
                        order.OrderClass = "试打版";
                        break;
                    }
                case "C":
                    {
                        order.OrderClass = "已取消";
                        break;
                    }
                case "W":
                    {
                        order.OrderClass = "等回复";
                        break;
                    }
                case "AO":
                    {
                        order.OrderClass = "矢量新图";
                        break;
                    }
                case "AQ":
                    {
                        order.OrderClass = "矢量报价";
                        break;
                    }
                default:
                    {
                        order.OrderClass = "订单类型字段错误";
                        break;
                    }
            }

            ///

            switch (Convert.ToString(oldDataRow["Urgency"]))// 紧急度
            {
                case "Rush Editing":// 订单类型 急改带
                    {
                        order.OrderUrgency = "急改 - 30分钟内";
                        break;
                    }
                case "Editing":// 订单类型 改带
                    {
                        order.OrderUrgency = "改带 - 1小时内";
                        break;
                    }
                case "Quote":// 订单类型 估针
                    {
                        order.OrderUrgency = "估针 - 1小时内";
                        break;
                    }
                case "Super Rush":// 订单类型 特急带
                    {
                        order.OrderUrgency = "特急 - 1小时内";
                        break;
                    }
                case "Rush":// 订单类型 急带
                    {
                        order.OrderUrgency = "紧急 - 5小时内";
                        break;
                    }
                case "5PM":// 订单类型 一般
                    {
                        order.OrderUrgency = "一般 - 17:00时前";
                        break;
                    }
                case "24 hours":// 订单类型 正常
                    {
                        order.OrderUrgency = "正常 - 24小时内";
                        break;
                    }
                case "2-3 days":// 订单类型 长时
                    {
                        order.OrderUrgency = "长时 - 2至3天";
                        break;
                    }
                case "4-6 days":// 订单类型 超长时
                    {
                        order.OrderUrgency = "超长时 - 4至6天";
                        break;
                    }
                default:
                    {
                        order.OrderUrgency = "";
                        break;
                    }
            }

            ///

            try { order.OrderLatestReturnTime = Convert.ToDateTime(oldDataRow["RNT"]); }// 订单在此时间内返回
            catch { order.OrderLatestReturnTime = null; }

            ///

            order.OrderComputer = Convert.ToString(oldDataRow["Mark_pc"]).Replace("_Computer", "");// 订单电脑区域

            ///

            order.OrderDifficulty = Convert.ToString(oldDataRow["Class"]);// 打版难度

            ///

            order.OrderReturnFormat = Convert.ToString(oldDataRow["DS"]);// 返回文件格式

            ///

            try { order.OrderLastModiTime = Convert.ToDateTime(oldDataRow["Last_modi_time"]); }// 订单最后修改时间
            catch { order.OrderLastModiTime = null; }

            ///

            try { order.OrderTimeSpent = Convert.ToDouble(oldDataRow["TimeSpent"]); }// 订单接发总用时
            catch { order.OrderTimeSpent = 0; }

            ///

            try { order.OrderQuantity = Convert.ToInt32(oldDataRow["Quantity"]); }// 订单包含的版带数量
            catch { order.OrderQuantity = 1; }

            ///

            order.OrderDescription = Convert.ToString(oldDataRow["Description"]);// 订单描述

            ///

            order.NrInQC = Convert.ToString(oldDataRow["InQC"]).ToUpper();// 接带人员

            ///

            switch (Convert.ToString(oldDataRow["In_Shift"]).ToUpper())// 接带班次
            {
                case "A":
                    {
                        order.NrInShift = "中";
                        break;
                    }
                case "M":
                    {
                        order.NrInShift = "早";
                        break;
                    }
                case "E":
                    {
                        order.NrInShift = "晚";
                        break;
                    }
                default:
                    {
                        order.NrInShift = "";
                        break;
                    }
            }

            ///

            order.NrInComputer = Convert.ToString(oldDataRow["CD"]);// 接带计算机

            ///

            order.NrInTime = Convert.ToDateTime(oldDataRow["Record_in_time"]);// 接带时间

            ///

            order.EmbManager = Convert.ToString(oldDataRow["Manager"]).ToUpper();// 分带人员

            ///

            order.EmbClass = Convert.ToString(oldDataRow["OrderType"]);// 图案风格

            ///

            order.EmbVersion = Convert.ToString(oldDataRow["V"]);// 版带版本

            ///

            order.EmbEditVersion = Convert.ToString(oldDataRow["Editfrom"]);// 改带利用版本

            ///

            order.EmbZ = Convert.ToString(oldDataRow["Z"]).ToUpper();// 打版人员
            if (order.EmbZ=="空") order.EmbZ="";

            ///

            order.EmbOriginalZ = Convert.ToString(oldDataRow["OZ"]).ToUpper();// 原打版人员
            if (order.EmbOriginalZ == "空") order.EmbOriginalZ = "";

            ///

            switch (Convert.ToString(oldDataRow["Z_Shift"]).ToUpper())// 接带班次
            {
                case "A":
                    {
                        order.EmbZShift = "中";
                        break;
                    }
                case "M":
                    {
                        order.EmbZShift = "早";
                        break;
                    }
                case "E":
                    {
                        order.EmbZShift = "晚";
                        break;
                    }
                default:
                    {
                        order.EmbZShift = "";
                        break;
                    }
            }
            
            ///

            try { order.EmbZStartTime = Convert.ToDateTime(oldDataRow["Z_time1"]); }// 打版开始时间
            catch { order.EmbZStartTime = null; }

            ///

            try { order.EmbZEndTime = Convert.ToDateTime(oldDataRow["Z_time2"]); }// 打版完成时间
            catch { order.EmbZEndTime = null; }

            ///

            try { order.EmbZCount = Convert.ToInt32(oldDataRow["ZS_H"]); }// 打版师针数
            catch { order.EmbZCount = 0; }

            ///

            try { order.EmbCount = Convert.ToInt32(oldDataRow["RealS_W"]); }// 总针数
            catch { order.EmbCount = 0; }

            ///

            try { order.EmbChargesCount = Convert.ToInt32(oldDataRow["ChargeS"]); }// 收费针数
            catch { order.EmbChargesCount = 0; }

            ///

            order.EmbSewout = Convert.ToString(oldDataRow["Sewout"]) == "yes";// 是否车版

            ///

            order.EmbE = Convert.ToString(oldDataRow["E"]).ToUpper();// 车版人员

            ///

            try { order.EmbEEndTime = Convert.ToDateTime(oldDataRow["E_time"]); }// 车版完成时间
            catch { order.EmbEEndTime = null; }

            ///

            order.EmbSewingMachine = Convert.ToString(oldDataRow["EM"]);// 车版机器编号

            ///

            order.EmbQi = Convert.ToString(oldDataRow["QI"]).ToUpper();// 质检人员

            ///

            order.EmbQualityLevel = Convert.ToString(oldDataRow["QualityProblemLevel"]);// 打版质量问题等级

            ///

            order.EmbReSewoutCount = Convert.ToInt16(oldDataRow["RevisionCount"]);// 重新车版次数

            ///

            order.EmbScaner = Convert.ToString(oldDataRow["OA"]).ToUpper();// 扫描人员

            ///

            try { order.EmbScanerTime = Convert.ToDateTime(oldDataRow["OA_time"]); }// 扫描完成时间
            catch { order.EmbScanerTime = null; }

            ///

            order.NrOutQc = Convert.ToString(oldDataRow["OutQC"]).ToUpper();// 发带人员

            ///
            
            switch (Convert.ToString(oldDataRow["Out_shift"]).ToUpper())// 接带班次
            {
                case "A":
                    {
                        order.NrOutShift = "中";
                        break;
                    }
                case "M":
                    {
                        order.NrOutShift = "早";
                        break;
                    }
                case "E":
                    {
                        order.NrOutShift = "晚";
                        break;
                    }
                default:
                    {
                        order.NrOutShift = "";
                        break;
                    }
            }

            ///

            try { order.NrOutTime = Convert.ToDateTime(oldDataRow["Record_out_time"]); }// 发带时间
            catch { order.NrOutTime = null; }

            ///

            return order;
        }

        /// <summary>
        /// 表头规范化转换
        /// </summary>
        /// <param name="field">旧字段</param>
        /// <returns></returns>
        public static string Field2Old(string field)
        {
            field.Replace("OrderName", "sTape");// 订单号
            field.Replace("OrderInTime", "T_in_time");// 接单时间（TB）,,,,,,有些InTime有年月日有些没有
            field.Replace("OrderInYear", "sYear");// 接单年
            field.Replace("OrderInMonth", "sMonth");// 接单月
            field.Replace("OrderInDay", "sDate");// 接单日
            field.Replace("OrderCustomer", "Code");// 客户
            field.Replace("OrderPurchase", "sOrder");// 客户的订单号
            field.Replace("OrderClass", "Mode");// 订单类型
            field.Replace("OrderUrgency", "Urgency");// 订单紧急类型
            field.Replace("OrderLatestReturnTime", "RNT");// 订单在此时间内返回
            field.Replace("OrderComputer", "Mark_pc");// 订单电脑区域
            field.Replace("OrderDifficulty", "Class");// 打版难度
            field.Replace("OrderReturnFormat", "DS");// 返回文件格式
            field.Replace("OrderRemindTime", "Remind_time");// 订单重新提醒时间
            field.Replace("OrderLastModiTime", "Last_modi_time");// 订单最后修改时间
            field.Replace("OrderTimeSpent", "TimeSpent");// 订单接发总用时
            field.Replace("OrderQuantity", "Quantity");// 订单包含的版带数量
            field.Replace("OrderDescription", "Description");// 订单描述
            field.Replace("NrInQC", "InQC");// 接带人员
            field.Replace("NrInShift", "In_Shift");// 接带班次
            field.Replace("NrInComputer", "CD");// 接带计算机
            field.Replace("NrInTime", "Record_in_time");// 接带时间
            field.Replace("EmbManager", "Manager");// 分带人员
            field.Replace("EmbClass", "OrderType");// 图案风格
            field.Replace("EmbVersion", "V");// 版带版本
            field.Replace("EmbEditVersion", "Editfrom");// B版以上改带时，需要的上一个版本
            field.Replace("EmbZ", "Z");// 打版人员
            field.Replace("EmbOriginalZ", "OZ");// 原打版人员
            field.Replace("EmbZClass", "CPZClass");// 打版人员级别
            field.Replace("EmbZPointed", "PointedZ");// 优秀打版人员
            field.Replace("EmbZShift", "Z_Shift");// 打版班次
            field.Replace("EmbZStartTime", "Z_time1");// 打版开始时间
            field.Replace("EmbZEndTime", "Z_time2");// 打版完成时间
            field.Replace("EmbZCount", "ZS_H");// 打版师针数
            field.Replace("EmbCount", "RealS_W");// 总针数
            field.Replace("EmbChargesCount", "ChargeS");// 收费针数
            field.Replace("EmbSewout", "Sewout");// 是否车版
            field.Replace("EmbE", "E");// 车版人员
            field.Replace("EmbEEndTime", "E_time");// 车版完成时间
            field.Replace("EmbSewingMachine", "EM");// 车版机器编号
            field.Replace("EmbQi", "QI");// 质检人员
            field.Replace("EmbQualityLevel", "QualityProblemLevel");// 打版质量问题等级
            field.Replace("EmbReSewoutCount", "RevisionCount");// 打版质量引起的重新车版次数
            field.Replace("EmbScaner", "OA");// 扫描人员
            field.Replace("EmbScanerTime", "OA_time");// 扫描完成时间
            field.Replace("NrOutQc", "OutQC");// 发带人员
            field.Replace("NrOutShift", "Out_shift");// 发带班次
            field.Replace("NrOutTime", "Record_out_time");// 发带时间
            return field;
        }

        ///
    }
}
