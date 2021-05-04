using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Logger.SimpleLogger
{
    public class FileLogger : ILogger
    {
        string filePath;

        public FileLogger()
        {
            filePath = Properties.Settings.Default.filePath;
        }

        public void Error(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Error: " + message + $" Time: {DateTime.Now}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"File write error: {ex.Message} Time: {DateTime.Now}");
            }
        }

        public void Error(Exception ex)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Error: " + ex.Message + $" Time: {DateTime.Now}");
                }
            }
            catch (Exception exeption)
            {
                Console.WriteLine($"File write error: {exeption.Message} Time: {DateTime.Now}");
            }
        }

        public void Warning(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Warning: " + message + $" Time: {DateTime.Now}");
                }
            }
            catch (Exception exeption)
            {
                Console.WriteLine($"File write error {exeption.Message} Time: {DateTime.Now}");
            }
        }

        public void Info(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Info: " + message + $" Time: {DateTime.Now}");
                }
            }
            catch (Exception exeption)
            {
                Console.WriteLine($"File write error {exeption.Message} Time: {DateTime.Now}");
            }
        }
    }
}
