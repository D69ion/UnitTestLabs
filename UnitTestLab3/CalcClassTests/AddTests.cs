using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;
using NLog;
using NLog.Targets;
using NLog.Config;


namespace UnitTestLab3.CalcClassTests
{
    [TestClass]
    public class AddTests
    {
        private static Logger logger = CreateLogger();
        private const string component = "CalcClass.Add";

        private static Random random = new Random();
        private void PositiveAddTest(int testNumber, long a, long b)
        {
            long result = CalcClass.Add(a, b);
            long expected = a + b;
            Log.CreateLog(logger, component, testNumber, a.ToString(), expected.ToString(), result.ToString());
            Assert.AreEqual(result, expected);
        }

        private void NegativeAddTest(int testNumber, long a, long b, string exeption)
        {
            long result = CalcClass.Add(a, b);
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
            PositiveAddTest(1, random.Next(int.MinValue / 2, int.MaxValue / 2), random.Next(int.MinValue / 2, int.MaxValue / 2));
        }

        [TestMethod]
        public void Test2()
        {
            PositiveAddTest(2, random.Next(int.MinValue / 2, int.MaxValue / 2), random.Next(int.MinValue / 2, int.MaxValue / 2));
        }

        [TestMethod]
        public void Test3()
        {
            PositiveAddTest(3, random.Next(int.MinValue / 2, int.MaxValue / 2), random.Next(int.MinValue / 2, int.MaxValue / 2));
        }

        [TestMethod]
        public void Test4()
        {
            NegativeAddTest(4, (long)int.MinValue - 5, (long)int.MinValue - 5, "Error 06");
                 
        }

        [TestMethod]
        public void Test5()
        {
            NegativeAddTest(5, (long)int.MaxValue + 5, (long)int.MaxValue + 5, "Error 06");
        }
    }
}
