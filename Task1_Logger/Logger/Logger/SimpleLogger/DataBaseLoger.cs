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
                    using (SqlCommand sc = new SqlCommand($"INSERT INTO Messages VALUES ('Error', '{message}')", sw))
                    {
                        SqlDataReader dr = sc.ExecuteReader();
                        dr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DataBase write error: {ex.Message}");
            }
        }

        public void Error(Exception ex)
        {
            try
            {

                using (SqlConnection sw = new SqlConnection(@"Data Source = WSA-112-21\SQL_EXPRESS; Initial Catalog = ForLogs; Integrated Security = True; User Id = ICX\V.Krasnadubskaya; Password = 5128245.ru"))
                {
                    sw.Open();
                    using (SqlCommand sc = new SqlCommand($"INSERT INTO Messages VALUES ('Error', '{ex.Message}')", sw))
                    {
                        SqlDataReader dr = sc.ExecuteReader();
                        dr.Close();
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"DataBase write error: {exception.Message}");
            }
        }

        public void Warning(string message)
        {
            try
            {

                using (SqlConnection sw = new SqlConnection(@"Data Source = WSdA-112-21\SQL_EXPRESS; Initial Catalog = ForLogs; Integrated Security = True; User Id = ICX\V.Krasnadubskaya; Password = 5128245.ru"))
                {
                    sw.Open();
                    using (SqlCommand sc = new SqlCommand($"INSERT INTO Messages VALUES ('Warning', '{message}')", sw))
                    {
                        SqlDataReader dr = sc.ExecuteReader();
                        dr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DataBase write error: {ex.Message}");
            }
        }

        public void Info(string message)
        {
            try
            {

                using (SqlConnection sw = new SqlConnection(@"Data Source = WSdA-112-21\SQL_EXPRESS; Initial Catalog = ForLogs; Integrated Security = True; User Id = ICX\V.Krasnadubskaya; Password = 5128245.ru"))
                {
                    sw.Open();
                    using (SqlCommand sc = new SqlCommand($"INSERT INTO Messages VALUES ('Info', '{message}')", sw))
                    {
                        SqlDataReader dr = sc.ExecuteReader();
                        dr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DataBase write error: {ex.Message}");
            }
        }
    }
}
