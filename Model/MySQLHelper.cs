using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MySQLHelper
    {
        private static string GetConnectionString()
        {
            return "Server=" + System.Configuration.ConfigurationManager.AppSettings["Server"].ToString() + ";" +
                    "Database=" + System.Configuration.ConfigurationManager.AppSettings["DataBase"].ToString() + ";" +
                    "User Id=" + System.Configuration.ConfigurationManager.AppSettings["UserID"].ToString() + "; " +
                    "Password=" + EncryptHelper.Decrypt(System.Configuration.ConfigurationManager.AppSettings["Password"].ToString()) + ";";
        }
        private static MySqlConnection GetConnection()
        {
            return new MySqlConnection(GetConnectionString());
        }
        public static DataTable ExecuteDataTable(string Procedure)
        {
            MySqlCommand cmd = new MySqlCommand(Procedure, GetConnection());
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }
        public static DataTable ExecuteDataTable(string Procedure, Dictionary<string, string> Parameters)
        {
            MySqlCommand cmd = new MySqlCommand(Procedure, GetConnection());
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                foreach (KeyValuePair<string, string> item in Parameters)
                {
                    if (item.Value == null)
                        cmd.Parameters.Add(new MySqlParameter(item.Key, DBNull.Value));
                    else
                        cmd.Parameters.Add(new MySqlParameter(item.Key, item.Value));
                }

                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }

        }
        public static DataSet ExecuteDataSet(string Procedure, Dictionary<string, string> Parameters)
        {
            MySqlCommand cmd = new MySqlCommand(Procedure, GetConnection());
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                foreach (KeyValuePair<string, string> item in Parameters)
                {
                    if (item.Value == null)
                        cmd.Parameters.Add(new MySqlParameter(item.Key, DBNull.Value));
                    else
                        cmd.Parameters.Add(new MySqlParameter(item.Key, item.Value));
                }

                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }

        }
    }
}
