using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Logger.SimpleLogger;

namespace Logger
{

    public enum RecordingMode
    {
        Console,
        File,
        Data_Base
    }

    public class MyLogger: ILogger
    {
        List<ILogger> objectToWrite = new List<ILogger>();

        public MyLogger(params RecordingMode[] recordingMode)
        {
            if (recordingMode.Contains(RecordingMode.Console))
            {
                objectToWrite.Add(new ConsoleLogger());
            }

            if (recordingMode.Contains(RecordingMode.File))
            {
                objectToWrite.Add(new FileLogger());
            }

            if (recordingMode.Contains(RecordingMode.Data_Base))
            {
                objectToWrite.Add(new DataBaseLoger());
            }

            if (objectToWrite.Count() == 0)
            {
                objectToWrite.Add(new ConsoleLogger());
            }
        }

        public void Error(string message)
        {
            objectToWrite.ForEach(x => x.Error(message));
        }

        public void Error(Exception ex)
        {
            objectToWrite.ForEach(x => x.Error(ex));
        }

        public void Info(string message)
        {
            objectToWrite.ForEach(x => x.Info(message));
        }

        public void Warning(string message)
        {
            objectToWrite.ForEach(x => x.Warning(message));
        }
    }
}
