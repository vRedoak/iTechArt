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
            Console.WriteLine("Error: "+ message);
        }

        public void Error(Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        public void Info(string message)
        {
            Console.WriteLine("Info: " + message);
        }

        public void Warning(string message)
        {
            Console.WriteLine("Warning: " + message);
        }



    }
}
