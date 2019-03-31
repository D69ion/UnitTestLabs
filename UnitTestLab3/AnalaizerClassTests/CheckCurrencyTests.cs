using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;
using NLog;
using NLog.Targets;
using NLog.Config;

namespace UnitTestLab3.AnalaizerClassTests
{
    [TestClass]
    public class CheckCurrencyTests
    {
        private static Logger logger = CreateLogger();
        private const string component = "AnalaizerClass.CheckCurrency";
        private void CheckCurrencyTest(int testNumber, string input, bool expected)
        {
            AnalaizerClass.expression = input;
            bool result = AnalaizerClass.CheckCurrency();
            Log.CreateLog(logger, component, testNumber, input, expected.ToString(), result.ToString());
            Assert.AreEqual(result, expected);
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
            CheckCurrencyTest(1, "1+(1+(1+1))", true);
        }

        [TestMethod]
        public void Test2()
        {
            CheckCurrencyTest(2, "1+(1+(1+(1+(1+(1+1)))))", true);
        }

        [TestMethod]
        public void Test3()
        {
            CheckCurrencyTest(3, "1+1+1+1", true);
        }

        [TestMethod]
        public void Test4()
        {
            CheckCurrencyTest(4, "1+1+(1+1))", false);
        }

        [TestMethod]
        public void Test5()
        {
            CheckCurrencyTest(5, "(1+1+1", false);
        }
    }
}
