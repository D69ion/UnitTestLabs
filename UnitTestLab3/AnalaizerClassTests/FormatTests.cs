using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;
using NLog;
using NLog.Targets;
using NLog.Config;

namespace UnitTestLab3.AnalaizerClassTests
{
    [TestClass]
    public class FormatTests
    {
        private static Logger logger = CreateLogger();
        private const string component = "AnalaizerClass.Format";
        private void FormatTest(int testNumber, string input, string expected)
        {
            AnalaizerClass.expression = input;
            string result = AnalaizerClass.Format();
            if (result.Contains(expected))
            {
                Log.CreateLog(logger, component, testNumber, input, expected, result);
                Assert.AreEqual(true, true);
            }
            else
            {
                Log.CreateBugReport(logger, component, testNumber, input, expected, result, "");
                Assert.AreEqual(false, true);
            }
        }

        private static Logger CreateLogger()
        {
            LoggingConfiguration configuration = new LoggingConfiguration();
            FileTarget fileTarget = new FileTarget("log") { FileName = Log.LogPath };
            //fileTarget.DeleteOldFileOnStartup = true;
            configuration.AddRule(LogLevel.Info, LogLevel.Fatal, fileTarget);
            LogManager.Configuration = configuration;
            return LogManager.GetCurrentClassLogger();
        }

        [TestMethod]
        public void Test1()
        {
            FormatTest(1, "1+1", "1 + 1 ");
        }

        [TestMethod]
        public void Test2()
        {
            FormatTest(2, "1   +  1 ", "1 + 1 ");
        }

        [TestMethod]
        public void Test3()
        {
            FormatTest(3, "1+", "Error 05");
        }

        [TestMethod]
        public void Test4()
        {
            FormatTest(4, "1++1", "Error 04");
        }

        [TestMethod]
        public void Test5()
        {
            FormatTest(5, "!1", "Error 02");
        }

        [TestMethod]
        public void Test6()
        {
            StringBuilder str = new StringBuilder();
            for(int i = 0; i< 66000; i++)
            {
                str.Append('1');
            }
            str.Append("+1");
            FormatTest(6, str.ToString(), "Error 07");
        }

    }
}
