using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MyLogger
{
    public partial class Form1 : Form
    {
        Logger logger = new Logger(new LoggerProvider(), LoggerType.File);
        public Form1()
        {
            InitializeComponent();
            AllocConsole();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logger.Info("Button 1 was pressed");
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            logger.Warning("The mouse moves inside the forbidden button");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            logger.Info("Button 2 was pressed");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            logger.Error("Forbidden button was pressed");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            logger.Error(new Exception("Specially created error"));
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
