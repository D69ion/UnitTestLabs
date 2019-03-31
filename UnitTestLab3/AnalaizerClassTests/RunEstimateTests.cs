using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;
using System.Collections;
using NLog;
using NLog.Targets;
using NLog.Config;
using System.Text;

namespace UnitTestLab3.AnalaizerClassTests
{
    [TestClass]
    public class RunEstimateTests
    {
        private static Logger logger = CreateLogger();
        private const string component = "AnalaizerClass.RunEstimate";
        private void RunEstimateTest(int testNumber, ArrayList input, string expected)
        {
            AnalaizerClass.opz = input;
            string result = AnalaizerClass.RunEstimate();
            if (result.Contains(expected))
            {
                Log.CreateLog(logger, component, testNumber, ListToString(input), expected, result);
                Assert.AreEqual(true, true);
            }
            else
            {
                Log.CreateBugReport(logger, component, testNumber, ListToString(input), expected, result, "");
                Assert.AreEqual(false, true);
            }
        }

        private string ListToString(ArrayList list)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                builder.Append(list[i].ToString() + ' ');
            }
            return builder.ToString();
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
            ArrayList arrayList = new ArrayList { "1", "1", "+" };
            RunEstimateTest(1, arrayList, "2");
        }
        [TestMethod]
        public void Test2()
        {
            ArrayList arrayList = new ArrayList {  };
            RunEstimateTest(2, arrayList, "Error 03");
        }

        [TestMethod]
        public void Test3()
        {
            ArrayList arrayList = new ArrayList { "1", "+", "1" };
            RunEstimateTest(3, arrayList, "Error 03");
        }

        [TestMethod]
        public void Test4()
        {
            ArrayList arrayList = new ArrayList { ((long)int.MaxValue + 5).ToString(), "1", "+" };
            RunEstimateTest(4, arrayList, "Error 06");
        }

        [TestMethod]
        public void Test5()
        {
            ArrayList arrayList = new ArrayList { "1", "0", "/" };
            RunEstimateTest(5, arrayList, "Error 09");
        }

    }
}
