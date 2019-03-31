using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;
using NLog;
using NLog.Targets;
using NLog.Config;

namespace UnitTestLab3.CalcClassTests
{
    [TestClass]
    public class DivTests
    {
        private static Logger logger = CreateLogger();
        private const string component = "CalcClass.Div";
        private static Random random = new Random();
        private void PositiveDivTest(int testNumber, long a, long b)
        {
            long result = CalcClass.Div(a, b);
            long expected = a / b;
            Log.CreateLog(logger, component, testNumber, a.ToString(), expected.ToString(), result.ToString());
            Assert.AreEqual(result, expected);
        }

        private void NegativeDivTest(int testNumber, long a, long b, string exeption)
        {
            long result = CalcClass.Div(a, b);
            string exep = CalcClass.lastError;
            if (result == 0 && exep.Contains(exeption))
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
            PositiveDivTest(1, random.Next(int.MinValue + 5, int.MaxValue - 5), random.Next(int.MinValue + 5, int.MaxValue - 5));
        }

        [TestMethod]
        public void Test2()
        {
            PositiveDivTest(2,random.Next(int.MinValue + 5, int.MaxValue - 5), random.Next(int.MinValue + 5, int.MaxValue - 5));
        }

        [TestMethod]
        public void Test3()
        {
            PositiveDivTest(3, random.Next(int.MinValue + 5, int.MaxValue - 5), random.Next(int.MinValue + 5, int.MaxValue - 5));
        }

        [TestMethod]
        public void Test4()
        {
            PositiveDivTest(4, random.Next(int.MinValue + 5, int.MaxValue - 5), random.Next(int.MinValue + 5, int.MaxValue - 5));
        }

        [TestMethod]
        public void Test5()
        {
            NegativeDivTest(5, random.Next(int.MinValue + 5, int.MaxValue - 5), 0, "Error 09");
        }

        [TestMethod]
        public void Test6()
        {
            NegativeDivTest(6, (long)int.MaxValue + 5, (long)int.MaxValue + 5, "Error 06");
        }
    }
}
