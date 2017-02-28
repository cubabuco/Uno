using System;
using System.IO;
using System.Windows.Forms;

namespace Uno
{
    class Logger
    {
        public static void FuncInit(string funcName)
        {
            CheckFileOpen();

            _mFileLog.WriteLine("\n" + DateTime.Now + " - "
                                + GetLogLevelName(LoggingLevel.LogGeneral)
                                + " - Entering " + funcName);
            _mFileLog.Flush();
        }

        public static void FuncExit(string funcName)
        {
            CheckFileOpen();

            _mFileLog.WriteLine("\n" + DateTime.Now + " - "
                                + GetLogLevelName(LoggingLevel.LogGeneral)
                                + " - Exiting " + funcName);
            _mFileLog.Flush();
        }

        private static void CheckFileOpen()
        {
            if (!IsLogFileOpen())
            {
                OpenLogFile(Data.LogFileName);
            }
        }

        public static void Write(int logLevel, string message)
        {
            CheckFileOpen();

            var tempVal = logLevel & Data.LogLevel;
            if (Data.LogLevel > LoggingLevel.LogGeneral && tempVal == logLevel)
            {
                _mFileLog.WriteLine("\n" + DateTime.Now + " - "
                                    + GetLogLevelName(logLevel)
                                    + " - " + message);
            }
            else if (LoggingLevel.LogGeneral == logLevel)
            {
                _mFileLog.WriteLine("\n" + DateTime.Now + " - "
                                    + GetLogLevelName(LoggingLevel.LogGeneral)
                                    + " - " + message);
            }

            _mFileLog.Flush();
        }

        private static string GetLogLevelName(int logLevel)
        {
            switch(logLevel)
            {
                case LoggingLevel.LogGeneral:
                    return "LOG GENERAL";

                case LoggingLevel.LogDebug:
                    return "LOG DEBUG";
            }
            return "LOG <Unknown>";
        }

        private static bool IsLogFileOpen()
        {
            return _mIsOpen;
        }

        private static void OpenLogFile(string fileName)
        {
            _mFileLog = new StreamWriter(Application.StartupPath + @"\" + fileName, true);
            _mIsOpen = true;
            _mFileLog.WriteLine("\n----------------- Uno log starting -----------------");
            _mFileLog.Flush();
        }

        private static TextWriter _mFileLog;
        private static bool _mIsOpen;
    }
}