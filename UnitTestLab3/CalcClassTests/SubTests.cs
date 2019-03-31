using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;
using NLog;
using NLog.Targets;
using NLog.Config;

namespace UnitTestLab3.CalcClassTests
{
    [TestClass]
    public class SubTests
    {
        private static Logger logger = CreateLogger();
        private const string component = "CalcClass.Sub";
        private static Random random = new Random();
        private void PositiveSubTest(int testNumber, long a, long b)
        {
            long result = CalcClass.Sub(a, b);
            long expected = a - b;
            Log.CreateLog(logger, component, testNumber, a.ToString(), expected.ToString(), result.ToString());
            Assert.AreEqual(result, expected);
        }

        private void NegativeSubTest(int testNumber, long a, long b, string exeption)
        {
            long result = CalcClass.Sub(a, b);
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
            PositiveSubTest(1, random.Next(int.MinValue / 2, int.MaxValue / 2), random.Next(int.MinValue / 2, int.MaxValue / 2));
        }

        [TestMethod]
        public void Test2()
        {
            PositiveSubTest(2, random.Next(int.MinValue / 2, int.MaxValue / 2), random.Next(int.MinValue / 2, int.MaxValue / 2));
        }

        [TestMethod]
        public void Test3()
        {
            PositiveSubTest(3, random.Next(int.MinValue / 2, int.MaxValue / 2), random.Next(int.MinValue / 2, int.MaxValue / 2));
        }

        [TestMethod]
        public void Test4()
        {
            NegativeSubTest(4, int.MaxValue, int.MaxValue, "Error 06");
        }

        [TestMethod]
        public void Test5()
        {
            NegativeSubTest(5, int.MinValue, int.MinValue, "Error 06");
        }

    }
}
