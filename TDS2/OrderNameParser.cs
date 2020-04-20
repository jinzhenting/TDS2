using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TDS2
{
    /// <summary>
    /// 订单号解析器
    /// </summary>
    class OrderNameParser
    {
        /// <summary>
        /// 订单号
        /// </summary>
        private static string Type;

        /// <summary>
        /// 客户
        /// </summary>
        private static string Customer;

        /// <summary>
        /// 年
        /// </summary>
        private static string Year;

        /// <summary>
        /// 月
        /// </summary>
        private static string Month;

        /// <summary>
        /// 版本
        /// </summary>
        private static string Version;

        /// <summary>
        /// 数量
        /// </summary>
        private static string Count;

        /// <summary>
        /// 报价
        /// </summary>
        private static string Q;

        /// <summary>
        /// 来源
        /// </summary>
        private static string G;

        /// <summary>
        /// 根据订单类型返回路径
        /// </summary>
        /// <param name="inOrderName">传入订单号</param>
        /// <param name="inOrderClass">订单类型，暂时支持 Dst; Emb; Vector</param>
        /// <returns>订单的本地文件路径</returns>
        public static string GetFilePath(string inOrderName, string inOrderClass)
        {
            if (Parser(inOrderName))
            {
                if (inOrderClass == "Dst") return Path.Combine(Customer.Substring(0, 1), Customer, "In_Out", Year + Month, inOrderName + ".dst");// Dst模式
                else if (inOrderClass == "Emb") return Path.Combine(Customer.Substring(0, 1), Customer, "Emb", Year + Month, inOrderName + ".emb");// Emb模式
                else if (inOrderClass == "Vector") return Path.Combine("VcetorData", Year + Month, Customer);// Vector模式
            }
            MessageBox.Show("传入解析器的订单号 " + inOrderName + " 错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return inOrderName;
        }

        private static bool Parser(string str)// 检测
        {
            return (New(str) || Old(str));// 如果New订单检测成功，返回true，否则返回Old的检测结果
        }

        /// <summary>
        /// 新订单检测模式
        /// </summary>
        /// <param name="str">订单号</param>
        /// <returns></returns>
        private static bool New(string str)
        {
            str = ClearQ(str);// 清除Q_和1_-9_开头的估计编号
            string regex = @"^([A-Za-z]{1,5})([0-9][0-9])([1-9A-Ca-c])([Gg])?([0-9][0-9][0-9]?)([A-Za-z])?";// 新订单号取2位年份
            Match match = Regex.Match(str, regex);
            if (match.Groups[0].Value == "" || match.Groups[0] == null) return false;
            string year_temp = Years(match.Groups[2].Value);// 年转换
            string month_temp = Months(match.Groups[3].Value);// 月转换
            DateTime type_month = DateTime.ParseExact(year_temp + month_temp, "yyyyMM", System.Globalization.CultureInfo.CurrentCulture);// 本年本月对比
            DateTime now_month = DateTime.Now;
            if (DateTime.Compare(type_month, now_month) > 0) return false;// 如果订单号中读取到的年月是未来的，即表示New规则不适合，返回false，轮到旧订单模式检测
            Type = match.Groups[0].Value;// 写数据
            Customer = match.Groups[1].Value;
            Year = year_temp;
            Month = month_temp;
            G = CustomerG(match.Groups[4].Value);
            Count = Counts(match.Groups[5].Value);
            Version = Versions(match.Groups[6].Value);
            return true;
        }

        /// <summary>
        /// 旧订单检测模式
        /// </summary>
        /// <param name="str">订单号</param>
        /// <returns></returns>
        private static bool Old(string str)// 旧订单
        {
            str = ClearQ(str);// 清除Q_和1_-9_开头的估计编号
            string regex = "^([A-Za-z]{1,5})([0-9])([1-9A-Ca-c])([Gg])?([0-9][0-9][0-9]?)([A-Za-z])?";// 旧订单号取1位年份
            Match match = Regex.Match(str, regex);
            if (match.Groups[0].Value == "" || match.Groups[0] == null) return false;
            Type = match.Groups[0].Value;// 写数据
            Customer = match.Groups[1].Value;
            Year = Years(match.Groups[2].Value);
            Month = Months(match.Groups[3].Value);
            G = CustomerG(match.Groups[4].Value);
            Count = Counts(match.Groups[5].Value);
            Version = Versions(match.Groups[6].Value);
            return true;
        }

        /// <summary>
        /// 把订单号中检测到的年份转换成yyyy格式
        /// </summary>
        /// <param name="year">订单号中检测到的年份</param>
        /// <returns></returns>
        private static string Years(string year)
        {
            string[] years = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] new_years = { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09" };
            for (int i = 0; i < years.Length; i++)
            {
                if (years[i] == year)
                {
                    year = new_years[i];
                    break;
                }
            }
            return year = "20" + year;
        }

        /// <summary>
        /// 把订单号中检测到的月份转换成MM格式
        /// </summary>
        /// <param name="month">订单号中检测到的月份</param>
        /// <returns></returns>
        private static string Months(string month)// 月转换
        {
            string[] months = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "a", "b", "c" };
            string[] new_months = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "10", "11", "12" };
            for (int i = 0; i < months.Length; i++)
            {
                if (months[i] == month)
                {
                    month = new_months[i];
                    break;
                }
            }
            return month;
        }

        /// <summary>
        /// 转换订单数为int类型
        /// </summary>
        /// <param name="str">订单数</param>
        /// <returns></returns>
        private static string Counts(string str)
        {
            return str = Regex.Replace(str, "^[0]+", string.Empty);// 以0开头的任意长度正数
        }

        /// <summary>
        /// 转换版带版本号
        /// </summary>
        /// <param name="version">版带版本号</param>
        /// <returns></returns>
        private static string Versions(string version)// 版本
        {
            return (version == "") ? "原" : version.ToUpper();
        }

        /// <summary>
        /// 清除Q_和1_-9_开头的估计编号
        /// </summary>
        /// <param name="str">订单号</param>
        /// <returns></returns>
        private static string ClearQ(string str)
        {
            if (Regex.IsMatch(str, "^([Qq1-9]_)"))// Q_和1_-9_开头
            {
                Q = "报价订单";
                return str = Regex.Replace(str, "^([Qq1-9]_)", string.Empty);
            }
            Q = "正式订单";
            return str;
        }

        /// <summary>
        /// 转换订单来源
        /// </summary>
        /// <param name="str">订单来源</param>
        /// <returns></returns>
        private static string CustomerG(string str)// 来源
        {
            if (Regex.IsMatch(str, "^[Gg]$")) return G = "客户送版";// G代表客户送版
            return G = "内部打版";
        }


    }
}
