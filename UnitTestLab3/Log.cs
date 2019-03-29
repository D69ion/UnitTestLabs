using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace UnitTestLab3
{
    public static class Log
    {
        public static string LogPath { get => Environment.CurrentDirectory + "\\log.txt"; }
        public static Logger Logger { get => logger; set => logger = value; }

        private static Logger logger;

        static Log()
        {
            logger = LogManager.GetCurrentClassLogger();
        }

        public static void CreateLog(int testNumber, string input, string expected, string result)
        {
            string log = string.Format("\nТест №{0}\nВходные данные: {1}\nОжидаемый результат: {2}\nПолученный результат: {3}\n", testNumber, input, expected, result);
            Logger.Info(log);
        }

        public static void CreateBugReport(string componentName, int testNumber, string input, string expected, string result)
        {

        }
    }
}
