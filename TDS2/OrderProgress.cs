
using System.Data;
using System.Windows.Forms;

namespace TDS2
{
    public static class OrderProgress
    {
        /// <summary>
        /// 获取带子进度
        /// </summary>
        /// <param name="row">选中订单行</param>
        /// <returns></returns>
        public static string Get(DataRow row)
        {
            ///////////////////// 以后改为检测DST和EMB是否存在 /////////////////////////////////////////////////////////////////////////////

            if (row == null) return "未选中订单";
            if ((string)row["发带人"] != "") return "已发带";// 
            if ((string)row["订单类型"] == "已取消") return "已取消";// 
            if (((string)row["订单类型"] == "矢量新图" || (string)row["订单类型"] == "矢量报价") && (string)row["打版师"] != "" && (string)row["发带人"] == "") return "待做图";// 
            if (((string)row["订单类型"] == "新带" || (string)row["订单类型"] == "收费改带" || (string)row["订单类型"] == "免费改带" || (string)row["订单类型"] == "试打版") && ((string)row["车版师"] != "" || (string)row["质检员"] != "") && (string)row["发带人"] == "") return "待扫描";// 
            if (((string)row["订单类型"] == "新带" || (string)row["订单类型"] == "收费改带" || (string)row["订单类型"] == "免费改带" || (string)row["订单类型"] == "试打版") && (string)row["分带人"] != "" && (string)row["打版师"] != "" && (string)row["是否车版"]=="是" && (string)row["车版师"] == "" && (string)row["质检员"] == "" && (string)row["发带人"] == "") return "待车版";// 
            if (((string)row["订单类型"] == "新带" || (string)row["订单类型"] == "收费改带" || (string)row["订单类型"] == "免费改带" || (string)row["订单类型"] == "估针" || (string)row["订单类型"] == "试打版") && (string)row["分带人"] != "" && (string)row["发带人"] == "") return "待打版";// 
            if (((string)row["订单类型"] == "新带" || (string)row["订单类型"] == "收费改带" || (string)row["订单类型"] == "免费改带" || (string)row["订单类型"] == "估针" || (string)row["订单类型"] == "试打版") && (string)row["分带人"] == "" && (string)row["发带人"] == "") return "待分带";// 
            //if ((order.OrderClass == "新带" || order.OrderClass == "收费改带" || order.OrderClass == "免费改带" || order.OrderClass == "估针" || order.OrderClass == "试打版" || order.OrderClass == "矢量新图" || order.OrderClass == "矢量报价") && order.NrOutQc == "") return "待发带";// 以后改为
            MessageBox.Show("带子进度异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }
}
