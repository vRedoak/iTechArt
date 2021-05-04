using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Logger
{
    public class ConsoleLogger : ILogger
    {

        public ConsoleLogger()
        {

        }

        public void Error(string message)
        {
            Console.WriteLine("Error: "+ message + $" Time: {DateTime.Now}");
        }

        public void Error(Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message + $" Time: {DateTime.Now}");
        }

        public void Info(string message)
        {
            Console.WriteLine("Info: " + message + $" Time: {DateTime.Now}");
        }

        public void Warning(string message)
        {
            Console.WriteLine("Warning: " + message + $" Time: {DateTime.Now}");
        }



    }
}
