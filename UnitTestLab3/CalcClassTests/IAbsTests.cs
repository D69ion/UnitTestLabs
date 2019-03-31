using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;
using NLog;
using NLog.Targets;
using NLog.Config;

namespace UnitTestLab3.CalcClassTests
{
    [TestClass]
    public class IAbsTests
    {
        private static Logger logger = CreateLogger();
        private const string component = "CalcClass.IAbs";
        private static Random random = new Random();
        private void PositiveIAbsTest(int testNumber, long a)
        {
            long result = CalcClass.IABS(a);
            long expected = 0;
            if(a < 0)
            {
                expected = a;
            }
            if(a > 0)
            {
                expected = -a;
            }
            Log.CreateLog(logger, component, testNumber, a.ToString(), expected.ToString(), result.ToString());
            Assert.AreEqual(result, expected);
        }

        private void NegativeIAbsTest(int testNumber, long a, string exeption)
        {
            long result = CalcClass.IABS(a);
            string exep = CalcClass.lastError;
            if (result == 0 && exep.Equals(exeption))
            {
                Log.CreateLog(logger, component, testNumber, a.ToString(), "0 " + exeption, result.ToString() + " " + exep);
                Assert.AreEqual(result, 0);
            }
            else
            {
                Log.CreateBugReport(logger, component, testNumber, a.ToString(), "0 " + exeption, result.ToString() + " " + exep, "");
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
            PositiveIAbsTest(1, random.Next(int.MinValue + 5, 0));
        }

        [TestMethod]
        public void Test2()
        {
            PositiveIAbsTest(2, random.Next(0, int.MaxValue - 5));
        }

        [TestMethod]
        public void Test3()
        {
            PositiveIAbsTest(3, random.Next(int.MinValue + 5, int.MaxValue - 5));
        }

        [TestMethod]
        public void Test4()
        {
            NegativeIAbsTest(4, int.MaxValue, "Error 06");
        }

        [TestMethod]
        public void Test5()
        {
            NegativeIAbsTest(5, int.MinValue, "Error 06");
        }

    }
}
