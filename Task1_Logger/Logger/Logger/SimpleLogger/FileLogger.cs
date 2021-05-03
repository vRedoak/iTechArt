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
                    sw.WriteLine("Error: " + message);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"File write error: {ex.Message}");
            }
        }

        public void Error(Exception ex)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Error: " + ex.Message);
                }
            }
            catch (Exception exeption)
            {
                Console.WriteLine($"File write error: {exeption.Message}");
            }
        }

        public void Warning(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Warning: " + message);
                }
            }
            catch (Exception exeption)
            {
                Console.WriteLine($"File write error {exeption.Message}");
            }
        }

        public void Info(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Info: " + message);
                }
            }
            catch (Exception exeption)
            {
                Console.WriteLine($"File write error {exeption.Message}");
            }
        }
    }
}
