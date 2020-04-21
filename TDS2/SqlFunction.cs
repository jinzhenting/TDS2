using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TDS2
{
    /// <summary>
    /// SQL数据库查询
    /// </summary>
    public static class SqlFunction
    {
        /// <summary>
        /// SELECT
        /// </summary>
        /// <param name="select">SELECT * FROM 表 WHERE 列='值'</param>
        /// <returns>数据表</returns>
        public static DataTable Select(string select)
        {
            try
            {
                Sql sql = new Sql();
                SqlDataAdapter sqldataadapter = new SqlDataAdapter();
                SqlConnection sqlconnection = new SqlConnection(sql.Connection);
                SqlCommand sqlcommand = new SqlCommand(select, sqlconnection);
                sqlconnection.Open();
                sqldataadapter.SelectCommand = sqlcommand;
                DataTable datatable = new DataTable();
                if (datatable.Rows.Count > 0) datatable.Clear();
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
        /// UPDATE
        /// </summary>
        /// <param name="up">UPDATE 表 SET 列='值', 列='值' WHERE 列='值'</param>
        /// <returns></returns>
        public static bool Up(string up)
        {
            try
            {
                Sql sql = new Sql();
                SqlConnection sqlconnection = new SqlConnection(sql.Connection);
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
        /// INSERT
        /// </summary>
        /// <param name="insert">INSERT INTO 表 (列,列,列) VALUES('值','值','值')</param>
        /// <returns></returns>
        public static bool Insert(string insert)
        {
            try
            {
                Sql sql = new Sql();
                SqlConnection sqlconnection = new SqlConnection(sql.Connection);
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
        /// DELETE
        /// </summary>
        /// <param name="delete">DELETE FROM 表名称 WHERE 列名称 = 值</param>
        /// <returns></returns>
        public static bool Delete(string delete)
        {
            try
            {
                Sql sql = new Sql();
                SqlConnection sqlconnection = new SqlConnection(sql.Connection);
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
        /// DROP TABLE
        /// </summary>
        /// <param name="depot">图库名</param>
        /// <param name="drop">DROP TABLE 表名</param>
        /// <returns></returns>
        public static bool Dropable(string drop)
        {
            try
            {
                Sql sql = new Sql();
                SqlConnection sqlconnection = new SqlConnection(sql.Connection);
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
        /// CREATE TABLE
        /// </summary>
        /// <param name="create">CREATE TABLE 表(列 表配置, 列 表配置)</param>
        /// <returns></returns>
        public static bool CreateTable(string create)
        {
            try
            {
                Sql sql = new Sql();
                SqlConnection sqlconnection = new SqlConnection(sql.Connection);
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
