
using System.Data;

namespace TDS2
{
    /// <summary>
    /// 带子进度
    /// </summary>
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
            if (row["发带人"].ToString() != "") return "已发带";// 
            if (row["订单类型"].ToString() == "已取消") return "已取消";// 
            if ((row["订单类型"].ToString() == "矢量新图" || row["订单类型"].ToString() == "矢量报价") && row["打版师"].ToString() != "" && row["发带人"].ToString() == "") return "待做图";// 
            if ((row["订单类型"].ToString() == "新带" || row["订单类型"].ToString() == "收费改带" || row["订单类型"].ToString() == "免费改带" || row["订单类型"].ToString() == "试打版") && (row["车版师"].ToString() != "" || row["质检员"].ToString() != "") && row["发带人"].ToString() == "") return "待扫描";// 
            if ((row["订单类型"].ToString() == "新带" || row["订单类型"].ToString() == "收费改带" || row["订单类型"].ToString() == "免费改带" || row["订单类型"].ToString() == "试打版") && row["分带人"].ToString() != "" && row["打版师"].ToString() != "" && row["是否车版"].ToString()=="是" && row["车版师"].ToString() == "" && row["质检员"].ToString() == "" && row["发带人"].ToString() == "") return "待车版";// 
            if ((row["订单类型"].ToString() == "新带" || row["订单类型"].ToString() == "收费改带" || row["订单类型"].ToString() == "免费改带" || row["订单类型"].ToString() == "估针" || row["订单类型"].ToString() == "试打版") && row["分带人"].ToString() != "" && row["发带人"].ToString() == "") return "待打版";// 
            if ((row["订单类型"].ToString() == "新带" || row["订单类型"].ToString() == "收费改带" || row["订单类型"].ToString() == "免费改带" || row["订单类型"].ToString() == "估针" || row["订单类型"].ToString() == "试打版") && row["分带人"].ToString() == "" && row["发带人"].ToString() == "") return "待分带";// 
            //if ((order.OrderClass == "新带" || order.OrderClass == "收费改带" || order.OrderClass == "免费改带" || order.OrderClass == "估针" || order.OrderClass == "试打版" || order.OrderClass == "矢量新图" || order.OrderClass == "矢量报价") && order.NrOutQc == "") return "待发带";// 以后改为
            //MessageBox.Show("带子进度异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }
}
