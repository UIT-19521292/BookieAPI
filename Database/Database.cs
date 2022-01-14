using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace BKStore_API.Database
{
    public class Database
    {
        public static DataTable ReadTable(string StoredProcedureName, Dictionary<string, object> para = null)
        {
            try
            {
                // result variable
                DataTable resultTable = new DataTable();

                // create connection
                string SQLConnectionString = ConfigurationManager.ConnectionStrings["BKStoreConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(SQLConnectionString);

                connection.Open();

                // create and assign properties for command
                SqlCommand sqlCmd = connection.CreateCommand();
                sqlCmd.Connection = connection;
                sqlCmd.CommandText = StoredProcedureName;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                // check parameters in Stored procedure
                if (para != null)
                {
                    foreach (KeyValuePair<string, object> data in para)
                    {
                        if (data.Value == null)
                        {
                            sqlCmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                        }
                        else
                        {
                            sqlCmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                        }
                    }
                }

                // execute sqlCommand and assign to result variable
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCmd;
                sqlDA.Fill(resultTable);

                connection.Close();

                return resultTable;
            }
            catch
            {
                return null;
            }
        }

        public static int InsertValue(string StoredProcedureName, Dictionary<string, object> para = null)
        {
            try
            {
                // create connection
                string SQLConnectionString = ConfigurationManager.ConnectionStrings["BKStoreConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(SQLConnectionString);

                connection.Open();

                // create and assign properties for command
                SqlCommand sqlCmd = connection.CreateCommand();
                sqlCmd.Connection = connection;
                sqlCmd.CommandText = StoredProcedureName;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                // check parameters in Stored procedure
                if (para != null)
                {
                    foreach (KeyValuePair<string, object> data in para)
                    {
                        if (data.Value == null)
                        {
                            sqlCmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                        }
                        else
                        {
                            sqlCmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                        }
                    }
                }

                // execute sqlCommand and assign to result variable
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.InsertCommand = sqlCmd;
                int id = (int)sqlDA.InsertCommand.ExecuteScalar();
                connection.Close();

                return id;
            }
            catch
            {
                return 0;
            }
        }

        public static bool DeleteValue(string StoredProcedureName, Dictionary<string, object> para = null)
        {
            try
            {
                // create connection
                string SQLConnectionString = ConfigurationManager.ConnectionStrings["BKStoreConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(SQLConnectionString);

                connection.Open();

                // create and assign properties for command
                SqlCommand sqlCmd = connection.CreateCommand();
                sqlCmd.Connection = connection;
                sqlCmd.CommandText = StoredProcedureName;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                // check parameters in Stored procedure
                if (para != null)
                {
                    foreach (KeyValuePair<string, object> data in para)
                    {
                        if (data.Value == null)
                        {
                            sqlCmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                        }
                        else
                        {
                            sqlCmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                        }
                    }
                }

                // execute sqlCommand and assign to result variable
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.DeleteCommand = sqlCmd;
                int check = sqlDA.DeleteCommand.ExecuteNonQuery();
                connection.Close();
                if (check >= 1)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool UpdateValue(string StoredProcedureName, Dictionary<string, object> para = null)
        {
            try
            {
                // create connection
                string SQLConnectionString = ConfigurationManager.ConnectionStrings["BKStoreConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(SQLConnectionString);

                connection.Open();

                // create and assign properties for command
                SqlCommand sqlCmd = connection.CreateCommand();
                sqlCmd.Connection = connection;
                sqlCmd.CommandText = StoredProcedureName;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                // check parameters in Stored procedure
                if (para != null)
                {
                    foreach (KeyValuePair<string, object> data in para)
                    {
                        if (data.Value == null)
                        {
                            sqlCmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                        }
                        else
                        {
                            sqlCmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                        }
                    }
                }

                // execute sqlCommand and assign to result variable
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.UpdateCommand = sqlCmd;
                int check = sqlDA.UpdateCommand.ExecuteNonQuery();
                connection.Close();
                if (check >= 1)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

    }
}