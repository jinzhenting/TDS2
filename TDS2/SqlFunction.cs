using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TDS2
{

    public static class SqlFunction
    {
        /// <summary>
        /// 以带号查询时Sql语句转换
        /// </summary>
        /// <param name="tape">带号</param>
        /// <returns></returns>
        public static string TapeSelect(User user, string tape, string sqlDataTable)
        {
            string sql = "SELECT";

            ///
            
            sql += " UPPER(sTape) 订单号,";// 转大写
            sql += " T_in_time 接单时间,";
            sql += " sYear 接单年,";
            sql += " sMonth 接单月,";
            sql += " sDate 接单日,";
            sql += " UPPER(Code) 客户,";// 转大写
            sql += " sOrder 客户的订单号,";
            sql += " UPPER(Mode) 订单类型,";
            sql += " UPPER(Urgency) 紧急类别,";// 转大写
            sql += " RNT 最迟返回时间,";
            sql += " UPPER(LEFT(Mark_pc, 1)) 订单电脑,";// 转大写 // 截取左1字符
            sql += " UPPER(DS) 返回文件格式,";// 转大写
            sql += " Remind_time 订单重新提醒时间,";
            sql += " Last_modi_time 订单修改时间,";
            sql += " TimeSpent 订单接发总用时,";
            sql += " Quantity 订单含版带数,";
            sql += " Description 订单说明,";
            sql += " zDescription 打版师注意事项,";
            sql += " eDescription 车版师注意事项,";
            sql += " UPPER(InQC) 接带人,";// 转大写
            sql += " UPPER(In_Shift) 接带班次,";// 转大写
            sql += " CD 接带计算机,";
            sql += " Record_in_time 接带时间,";
            sql += " UPPER(Manager) 分带人,";// 转大写
            sql += " OrderType 图案风格,";
            sql += " Class 打版难度,";
            sql += " OrderQuoteName 估针编号,";
            sql += " OrderQuoteCount1 估针针数始,";
            sql += " OrderQuoteCount2 估针针数终,";
            sql += " OrderQuoteZ 估针打版师,";
            sql += " EmbWidth 版带宽,";
            sql += " EmbHeight 版带高,";
            sql += " EmbPosition 面料或位置,";
            sql += " UPPER(V) 版带版本,";// 转大写
            sql += " UPPER(Editfrom) 改带利用版本,";// 转大写
            sql += " UPPER(Z) 打版师,";// 转大写
            sql += " UPPER(OZ) 原版打版师,";// 转大写
            sql += " CPZClass 打版师级别,";
            sql += " PointedZ 优秀打版师,";
            sql += " UPPER(Z_Shift) 打版班次,";// 转大写
            sql += " Z_time1 打版开始时间,";
            sql += " Z_time2 打版完成时间,";
            sql += " ZS_H 打版师针数,";
            sql += " RealS_W 总针数,";
            sql += " ChargeS 收费针数,";
            sql += " UPPER(Sewout) 是否车版,";// 转大写
            sql += " UPPER(E) 车版师,";// 转大写
            sql += " E_time 车版完成时间,";
            sql += " EM 车版机器编号,";
            sql += " UPPER(QI) 质检员,";// 转大写
            sql += " QualityProblemLevel 质量问题等级,";
            sql += " RevisionCount 重新车版次数,";
            sql += " UPPER(OA) 扫描人,";// 转大写
            sql += " OA_time 扫描完成时间,";
            sql += " UPPER(OutQC) 发带人,";// 转大写
            sql += " UPPER(Out_shift) 发带班次,";// 转大写
            sql += " Record_out_time 发带时间";

            ///

            if (sqlDataTable == "新数据") sql += " FROM TDS WHERE";
            else sql += " FROM TDS_H WHERE";

            ///

            sql += " sTape='" + tape + "'";// 以带号查询

            ///

            if (user.Dept == "Z") sql += " AND Z='" + user.UserName + "'";// 打版师只能查询自己的带子

            ///

            return sql;
        }

        /// <summary>
        /// 以列表查询时Sql语句转换
        /// </summary>
        /// <param name="dept">部门</param>
        /// <param name="progress">带子进度</param>
        /// <param name="class_">带子类型</param>
        /// <param name="end">带子紧急类别</param>
        /// <returns>Sql语句</returns>
        public static string ListSelect(User user, string timeStatr, string timeEnd, string progress, string class_, string end, string sqlDataTable)
        {
            string sql = "SELECT";

            ///

            sql += " UPPER(sTape) 订单号,";// 转大写
            sql += " T_in_time 接单时间,";
            sql += " sYear 接单年,";
            sql += " sMonth 接单月,";
            sql += " sDate 接单日,";
            sql += " UPPER(Code) 客户,";// 转大写
            sql += " sOrder 客户的订单号,";
            sql += " UPPER(Mode) 订单类型,";
            sql += " UPPER(Urgency) 紧急类别,";// 转大写
            sql += " RNT 最迟返回时间,";
            sql += " UPPER(LEFT(Mark_pc, 1)) 订单电脑,";// 转大写 // 截取左1字符
            sql += " UPPER(DS) 返回文件格式,";// 转大写
            sql += " Remind_time 订单重新提醒时间,";
            sql += " Last_modi_time 订单修改时间,";
            sql += " TimeSpent 订单接发总用时,";
            sql += " Quantity 订单含版带数,";
            sql += " Description 订单说明,";
            sql += " zDescription 打版师注意事项,";
            sql += " eDescription 车版师注意事项,";
            sql += " UPPER(InQC) 接带人,";// 转大写
            sql += " UPPER(In_Shift) 接带班次,";// 转大写
            sql += " CD 接带计算机,";
            sql += " Record_in_time 接带时间,";
            sql += " UPPER(Manager) 分带人,";// 转大写
            sql += " OrderType 图案风格,";
            sql += " Class 打版难度,";
            sql += " OrderQuoteName 估针编号,";
            sql += " OrderQuoteCount1 估针针数始,";
            sql += " OrderQuoteCount2 估针针数终,";
            sql += " OrderQuoteZ 估针打版师,";
            sql += " EmbWidth 版带宽,";
            sql += " EmbHeight 版带高,";
            sql += " EmbPosition 面料或位置,";
            sql += " UPPER(V) 版带版本,";// 转大写
            sql += " UPPER(Editfrom) 改带利用版本,";// 转大写
            sql += " UPPER(Z) 打版师,";// 转大写
            sql += " UPPER(OZ) 原版打版师,";// 转大写
            sql += " CPZClass 打版师级别,";
            sql += " PointedZ 优秀打版师,";
            sql += " UPPER(Z_Shift) 打版班次,";// 转大写
            sql += " Z_time1 打版开始时间,";
            sql += " Z_time2 打版完成时间,";
            sql += " ZS_H 打版师针数,";
            sql += " RealS_W 总针数,";
            sql += " ChargeS 收费针数,";
            sql += " UPPER(Sewout) 是否车版,";// 转大写
            sql += " UPPER(E) 车版师,";// 转大写
            sql += " E_time 车版完成时间,";
            sql += " EM 车版机器编号,";
            sql += " UPPER(QI) 质检员,";// 转大写
            sql += " QualityProblemLevel 质量问题等级,";
            sql += " RevisionCount 重新车版次数,";
            sql += " UPPER(OA) 扫描人,";// 转大写
            sql += " OA_time 扫描完成时间,";
            sql += " UPPER(OutQC) 发带人,";// 转大写
            sql += " UPPER(Out_shift) 发带班次,";// 转大写
            sql += " Record_out_time 发带时间";

            ///

            if (sqlDataTable == "新数据") sql += " FROM TDS WHERE";
            else sql += " FROM TDS_H WHERE";

            ///

            sql += " Record_in_time>='" + timeStatr + "' and Record_in_time<='" + timeEnd + "'";// 接带时间

            ///

            switch (progress)
            {
                case "待分带":
                    {
                        sql += " AND (Mode='O' OR Mode='E' OR Mode='F' OR Mode='Q' OR Mode='T') AND (Manager IS NULL OR Manager='')";// 带子进度 待分带
                        break;
                    }
                case "待打版":
                    {
                        sql += " AND (Mode='O' OR Mode='E' OR Mode='F' OR Mode='Q' OR Mode='T') AND Manager IS NOT NULL AND Z IS NOT NULL AND OutQC IS NULL";// 带子进度 待打版
                        break;
                    }
                case "待做图":
                    {
                        sql += " AND (Mode='AQ' OR Mode='AO') AND OutQC IS NULL";// 带子进度 待做图
                        break;
                    }
                case "待车版":
                    {
                        sql += " AND (Mode='O' OR Mode='E' OR Mode='F' OR Mode='T') AND Manager IS NOT NULL AND Sewout='yes' AND E IS NULL AND QI IS NULL AND OutQC IS NULL";// 带子进度 待车版
                        break;
                    }
                case "待扫描":
                    {
                        sql += " AND (Mode='O' OR Mode='E' OR Mode='F' OR Mode='T') AND QI IS NOT NULL AND OutQC IS NULL";// 带子进度 待扫描
                        break;
                    }
                case "待发带":
                    {
                        sql += " AND (Mode='O' OR Mode='E' OR Mode='F' OR Mode='Q' OR Mode='T' OR Mode='AQ' OR Mode='AO') AND Manager IS NOT NULL AND Z IS NOT NULL AND OutQC IS NULL";// 带子进度 待发带
                        break;
                    }
                case "未发带":
                    {
                        sql += " AND (Mode='O' OR Mode='E' OR Mode='F' OR Mode='Q' OR Mode='T' OR Mode='AQ' OR Mode='AO') AND OutQC IS NULL";// 带子进度 未发带
                        break;
                    }
                case "已发带":
                    {
                        sql += " AND OutQC IS NOT NULL";// 带子进度 已发带
                        break;
                    }
                case "已取消":
                    {
                        sql += " AND Mode='C'";// 带子进度 已取消
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            ///

            switch (class_)
            {
                case "新带":// 带子分类 新带
                    {
                        sql += " AND Mode='O'";
                        break;
                    }
                case "收费改带":// 带子分类 收费改带
                    {
                        sql += " AND Mode='E'";
                        break;
                    }
                case "免费改带":// 带子分类 免费改带
                    {
                        sql += " AND Mode='F'";
                        break;
                    }
                case "估针":// 带子分类 估针
                    {
                        sql += " AND Mode='Q'";
                        break;
                    }
                case "试打版":// 带子分类 试打版
                    {
                        sql += " AND Mode='T'";
                        break;
                    }
                case "等回复":// 带子分类 等回复
                    {
                        sql += " AND Mode='W'";
                        break;
                    }
                case "矢量新图":// 带子分类 矢量图
                    {
                        sql += " AND Mode='AO'";
                        break;
                    }
                case "矢量报价":// 带子分类 矢量报价
                    {
                        sql += " AND Mode='AQ'";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            ///

            switch (end)
            {
                case "急改 - 30分钟内":// 紧急类别 急改
                    {
                        sql += " AND Urgency='Rush Editing'";
                        break;
                    }
                case "改带 - 1小时内":// 紧急类别 改带break;
                    {
                        sql += " AND Urgency='Editing'";
                        break;
                    }
                case "估针 - 1小时内":// 紧急类别 估针
                    {
                        sql += " AND Urgency='Quote'";
                        break;
                    }
                case "特急 - 1小时内":// 紧急类别 特急
                    {
                        sql += " AND Urgency='Super Rush'";
                        break;
                    }
                case "紧急 - 5小时内":// 紧急类别 紧急
                    {
                        sql += " AND Urgency='Rush'";
                        break;
                    }
                case "一般 - 17:00前":// 紧急类别 一般
                    {
                        sql += " AND Urgency='5PM'";
                        break;
                    }
                case "正常 - 24小时内":// 紧急类别 正常
                    {
                        sql += " AND Urgency='24 hours'";
                        break;
                    }
                case "长时 - 2至3天":// 紧急类别 长时
                    {
                        sql += " AND Urgency='2-3 days'";
                        break;
                    }
                case "超长时 - 4至6天":// 紧急类别 超长时
                    {
                        sql += " AND Urgency='4-6 days'";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            ///

            if (user.Dept == "Z") sql += " AND Z='" + user.UserName + "'";// 打版师只能查询自己的带子

            ///

            return sql;
        }

        /// <summary>
        /// 订单列表DataTable标准化转换
        /// </summary>
        /// <param name="newDataTable">新数据表</param>
        /// <param name="inTable">旧数据表</param>
        public static void Table2Standard(DataTable inTable)
        {
            foreach (DataRow row in inTable.Rows)
            {
                switch (Convert.ToString(row["订单类型"]))// 订单类型
                {
                    case "O":
                        {
                            row["订单类型"] = "新带";
                            break;
                        }
                    case "E":
                        {
                            row["订单类型"] = "收费改带";
                            break;
                        }
                    case "F":
                        {
                            row["订单类型"] = "免费改带";
                            break;
                        }
                    case "Q":
                        {
                            row["订单类型"] = "估针";
                            break;
                        }
                    case "T":
                        {
                            row["订单类型"] = "试打版";
                            break;
                        }
                    case "C":
                        {
                            row["订单类型"] = "已取消";
                            break;
                        }
                    case "W":
                        {
                            row["订单类型"] = "等回复";
                            break;
                        }
                    case "AO":
                        {
                            row["订单类型"] = "矢量新图";
                            break;
                        }
                    case "AQ":
                        {
                            row["订单类型"] = "矢量报价";
                            break;
                        }
                    default:
                        {
                            row["订单类型"] = "订单类型字段错误";
                            break;
                        }
                }

                ///

                switch (Convert.ToString(row["紧急类别"]).ToUpper())// 紧急类别
                {
                    case "RUSH EDITING":// 订单类型 急改
                        {
                            row["紧急类别"] = "急改 - 30分钟内";
                            break;
                        }
                    case "EDITING":// 订单类型 改带
                        {
                            row["紧急类别"] = "改带 - 1小时内";
                            break;
                        }
                    case "QUOTE":// 订单类型 估针
                        {
                            row["紧急类别"] = "估针 - 1小时内";
                            break;
                        }
                    case "SUPER RUSH":// 订单类型 特急带
                        {
                            row["紧急类别"] = "特急 - 1小时内";
                            break;
                        }
                    case "RUSH":// 订单类型 急带
                        {
                            row["紧急类别"] = "紧急 - 5小时内";
                            break;
                        }
                    case "5PM":// 订单类型 一般
                        {
                            row["紧急类别"] = "一般 - 17:00时前";
                            break;
                        }
                    case "24 HOURS":// 订单类型 正常
                        {
                            row["紧急类别"] = "正常 - 24小时内";
                            break;
                        }
                    case "2-3 DAYS":// 订单类型 长时
                        {
                            row["紧急类别"] = "长时 - 2至3天";
                            break;
                        }
                    case "4-6 DAYS":// 订单类型 超长时
                        {
                            row["紧急类别"] = "超长时 - 4至6天";
                            break;
                        }
                    default:
                        {
                            //row["紧急类别"] = "";
                            break;
                        }
                }

                ///

                if (row["订单含版带数"].ToString() == "N" || row["订单含版带数"].ToString() == "") row["订单含版带数"] = "1";

                ///

                switch (Convert.ToString(row["接带班次"]))// 接带班次
                {
                    case "A":
                        {
                            row["接带班次"] = "中";
                            break;
                        }
                    case "M":
                        {
                            row["接带班次"] = "早";
                            break;
                        }
                    case "E":
                        {
                            row["接带班次"] = "晚";
                            break;
                        }
                    default:
                        {
                            row["接带班次"] = "";
                            break;
                        }
                }

                ///
                
                if (Convert.ToString(row["打版师"]) == "空") row["打版师"] = "";

                ///
                
                if (Convert.ToString(row["原版打版师"]) == "空") row["原版打版师"] = "";

                ///

                switch (Convert.ToString(row["接带班次"]))// 接带班次
                {
                    case "A":
                        {
                            row["接带班次"] = "中";
                            break;
                        }
                    case "M":
                        {
                            row["接带班次"] = "早";
                            break;
                        }
                    case "E":
                        {
                            row["接带班次"] = "晚";
                            break;
                        }
                    default:
                        {
                            row["接带班次"] = "";
                            break;
                        }
                }

                ///

                if (Convert.ToString(row["是否车版"]) == "YES") row["是否车版"] = "是";// 是否车版
                
                ///

                if (Convert.ToString(row["重新车版次数"]) == "") row["重新车版次数"] = "0";
                
                ///

                switch (Convert.ToString(row["接带班次"]))// 接带班次
                {
                    case "A":
                        {
                            row["接带班次"] = "中";
                            break;
                        }
                    case "M":
                        {
                            row["接带班次"] = "早";
                            break;
                        }
                    case "E":
                        {
                            row["接带班次"] = "晚";
                            break;
                        }
                    default:
                        {
                            row["接带班次"] = "";
                            break;
                        }
                }

                ///
            }
        }

        /// <summary>
        /// SELECT语句返回DataTable
        /// </summary>
        /// <param name="select">SELECT * FROM 表 WHERE 列='值'</param>
        /// <returns>数据表</returns>
        public static DataTable Select(string select)
        {
            try
            {
                SqlConnection sql = new SqlConnection();
                SqlDataAdapter sqldataadapter = new SqlDataAdapter();
                System.Data.SqlClient.SqlConnection sqlconnection = new System.Data.SqlClient.SqlConnection(sql.Connection);
                SqlCommand sqlcommand = new SqlCommand(select, sqlconnection);
                sqlconnection.Open();
                sqldataadapter.SelectCommand = sqlcommand;
                DataTable datatable = new DataTable();
                sqldataadapter.Fill(datatable);
                sqlconnection.Close();
                sqlconnection.Dispose();
                return datatable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库查询错误，描述如下\r\n\r\n" + ex, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// UPDATE语句返回Bool
        /// </summary>
        /// <param name="up">UPDATE 表 SET 列='值', 列='值' WHERE 列='值'</param>
        /// <returns></returns>
        public static bool Up(string up)
        {
            try
            {
                SqlConnection sql = new SqlConnection();
                System.Data.SqlClient.SqlConnection sqlconnection = new System.Data.SqlClient.SqlConnection(sql.Connection);
                sqlconnection.Open();
                SqlCommand sqlCommand = new SqlCommand(up, sqlconnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlconnection.Close();
                sqlconnection.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库查询错误，描述如下\r\n\r\n" + ex, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// INSERT语句返回Bool
        /// </summary>
        /// <param name="insert">INSERT INTO 表 (列,列,列) VALUES('值','值','值')</param>
        /// <returns></returns>
        public static bool Insert(string insert)
        {
            try
            {
                SqlConnection sql = new SqlConnection();
                System.Data.SqlClient.SqlConnection sqlconnection = new System.Data.SqlClient.SqlConnection(sql.Connection);
                sqlconnection.Open();
                SqlCommand sqlCommand = new SqlCommand(insert, sqlconnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlconnection.Close();
                sqlconnection.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库查询错误，描述如下\r\n\r\n" + ex, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// DELETE语句返回Bool
        /// </summary>
        /// <param name="delete">DELETE FROM 表名称 WHERE 列名称 = 值</param>
        /// <returns></returns>
        public static bool Delete(string delete)
        {
            try
            {
                SqlConnection sql = new SqlConnection();
                System.Data.SqlClient.SqlConnection sqlconnection = new System.Data.SqlClient.SqlConnection(sql.Connection);
                sqlconnection.Open();
                SqlCommand sqlCommand = new SqlCommand(delete, sqlconnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlconnection.Close();
                sqlconnection.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库查询错误，描述如下\r\n\r\n" + ex, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// DROP TABLE语句返回Bool
        /// </summary>
        /// <param name="depot">图库名</param>
        /// <param name="drop">DROP TABLE 表名</param>
        /// <returns></returns>
        public static bool Dropable(string drop)
        {
            try
            {
                SqlConnection sql = new SqlConnection();
                System.Data.SqlClient.SqlConnection sqlconnection = new System.Data.SqlClient.SqlConnection(sql.Connection);
                sqlconnection.Open();
                SqlCommand sqlCommand = new SqlCommand(drop, sqlconnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlconnection.Close();
                sqlconnection.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库查询错误，描述如下\r\n\r\n" + ex, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// CREATE TABLE语句返回Bool
        /// </summary>
        /// <param name="create">CREATE TABLE 表(列 表配置, 列 表配置)</param>
        /// <returns></returns>
        public static bool CreateTable(string create)
        {
            try
            {
                SqlConnection sql = new SqlConnection();
                System.Data.SqlClient.SqlConnection sqlconnection = new System.Data.SqlClient.SqlConnection(sql.Connection);
                sqlconnection.Open();
                SqlCommand sqlCommand = new SqlCommand(create, sqlconnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlconnection.Close();
                sqlconnection.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库查询错误，描述如下\r\n\r\n" + ex, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
