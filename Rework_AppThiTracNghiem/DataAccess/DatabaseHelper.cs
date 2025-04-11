using System;
using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Rework_AppThiTracNghiem.DataAccess
{
    public class DatabaseHelper
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public static DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    DataTable result = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(result);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("Database Error: " + ex.Message);
                }
            }
        }

        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Database Error: " + ex.Message);
                }
            }
        }

        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception("Database Error: " + ex.Message);
                }
            }
        }
    }
}