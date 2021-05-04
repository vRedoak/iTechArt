using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.IO;

namespace Logger.SimpleLogger
{
    public class DataBaseLoger : ILogger
    {
        string connectionString;

        public DataBaseLoger()
        {
            connectionString = Properties.Settings.Default.dataBaseConnection;

        }

        public void Error(string message)
        {
            try
            {

                using (SqlConnection sw = new SqlConnection(connectionString))
                {
                    sw.Open();
                    using (SqlCommand sc = new SqlCommand($"INSERT INTO Messages VALUES ('Error', '{message} Time: { DateTime.Now }')", sw))
                    {
                        SqlDataReader dr = sc.ExecuteReader();
                        dr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DataBase write error: {ex.Message}  Time: { DateTime.Now }");
            }
        }

        public void Error(Exception ex)
        {
            try
            {

                using (SqlConnection sw = new SqlConnection(connectionString))
                {
                    sw.Open();
                    using (SqlCommand sc = new SqlCommand($"INSERT INTO Messages VALUES ('Error', '{ex.Message}  Time: { DateTime.Now }')", sw))
                    {
                        SqlDataReader dr = sc.ExecuteReader();
                        dr.Close();
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"DataBase write error: {exception.Message}  Time: { DateTime.Now }");
            }
        }

        public void Warning(string message)
        {
            try
            {

                using (SqlConnection sw = new SqlConnection(connectionString))
                {
                    sw.Open();
                    using (SqlCommand sc = new SqlCommand($"INSERT INTO Messages VALUES ('Warning', '{message}  Time: { DateTime.Now }')", sw))
                    {
                        SqlDataReader dr = sc.ExecuteReader();
                        dr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DataBase write error: {ex.Message}  Time: { DateTime.Now }");
            }
        }

        public void Info(string message)
        {
            try
            {

                using (SqlConnection sw = new SqlConnection(connectionString))
                {
                    sw.Open();
                    using (SqlCommand sc = new SqlCommand($"INSERT INTO Messages VALUES ('Info', '{message}  Time: { DateTime.Now }')", sw))
                    {
                        SqlDataReader dr = sc.ExecuteReader();
                        dr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DataBase write error: {ex.Message}  Time: { DateTime.Now }");
            }
        }
    }
}
