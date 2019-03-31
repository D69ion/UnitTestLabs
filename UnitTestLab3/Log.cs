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

        public static void CreateLog(Logger logger, string methodName, int testNumber, string input, string expected, string result)
        {
            StringBuilder @string = new StringBuilder();
            @string.Append(methodName + " Тест №" + testNumber + "\r\n").Append("Входные данные: " + input + "\r\n").Append("Ожидаемый результат: " + expected + "\r\n").Append("Полученный результат: " + result + "\r\n\r\n");
            logger.Info(@string.ToString());
        }

        public static void CreateBugReport(Logger logger, string component, int testNumber, string input, string expected, string result, string exeption)
        {
            StringBuilder @string = new StringBuilder();
            @string.Append(component + " Тест №" + testNumber + "\r\n").Append("Входные данные: " + input + "\r\n").Append("Ожидаемый результат: " + expected + "\r\n").Append("Полученный результат: " + result + "\r\n")
                .Append("Ошибка: " + exeption + "\r\n").Append("Описание: \r\n").Append("Проект: BaseCalculator\r\n").Append("Номер версии: 1.0.0\r\nКомпонент: " + component + "\r\n").Append("Серьезность: \r\nПриоритет: \r\n\r\n");
            logger.Info(@string.ToString());
        }
    }
}
