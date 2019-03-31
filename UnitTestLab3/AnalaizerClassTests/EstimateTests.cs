using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;
using NLog;
using NLog.Targets;
using NLog.Config;

namespace UnitTestLab3.AnalaizerClassTests
{
    [TestClass]
    public class EstimateTests
    {
        private static Logger logger = CreateLogger();
        private const string component = "AnalaizerClass.Estimate";
        private void EstimateTest(int testNumber, string input, string expected)
        {
            AnalaizerClass.expression = input;
            string result = AnalaizerClass.Estimate();
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
            EstimateTest(1, "1+1", "2");
        }

        [TestMethod]
        public void Test2()
        {
            EstimateTest(2, "8 + 35 * ( 37 - 8 / 2 ) + 2", "1165");
        }

        [TestMethod]
        public void Test3()
        {
            EstimateTest(3, "", "");
        }

        [TestMethod]
        public void Test4()
        {
            EstimateTest(4, "(1+1", "Error 01");
        }

        [TestMethod]
        public void Test5()
        {
            EstimateTest(5, "8 + 35 * ( 37 - 8 / 2 ) + 2 + 8 + 35 * ( 37 - 8 / 2 ) + 2 + 8 + 35 * ( 37 - 8 / 2 ) + 2 +" +
                "8 + 35 * ( 37 - 8 / 2 ) + 2 + 8 + 35 * ( 37 - 8 / 2 ) + 2 + 8 + 35 * ( 37 - 8 / 2 ) + 2", "Error 08");
        }

    }
}
