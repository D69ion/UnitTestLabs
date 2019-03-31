using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;
using NLog;
using NLog.Targets;
using NLog.Config;

namespace UnitTestLab3.CalcClassTests
{
    [TestClass]
    public class AbsTests
    {
        private static Logger logger = CreateLogger();
        private const string component = "CalcClass.Abs";
        static Random random = new Random();
        private void PositiveAbsTest(long a, int testNumber)
        {
            long result = CalcClass.ABS(a);
            long expected = Math.Abs(a);
            Log.CreateLog(logger, "CalcClass.Abs", testNumber, a.ToString(), expected.ToString(), result.ToString());
            Assert.AreEqual(result, expected);
        }

        private void NegativeAbsTest(long a, string exeption, int testNumber)
        {
            long result = CalcClass.ABS(a);
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
            PositiveAbsTest(random.Next(int.MinValue + 5, int.MaxValue - 5), 1);
        }

        [TestMethod]
        public void Test2()
        {
            PositiveAbsTest(random.Next(int.MinValue + 5, int.MaxValue - 5), 2);
        }

        [TestMethod]
        public void Test3()
        {
            PositiveAbsTest(random.Next(int.MinValue + 5, int.MaxValue - 5), 3);
        }

        [TestMethod]
        public void Test4()
        {
            NegativeAbsTest((long)int.MinValue - 5, "Error 06", 4);
        }

        [TestMethod]
        public void Test5()
        {
            NegativeAbsTest((long)int.MaxValue + 5, "Error 06", 5);
        }

    }
}
