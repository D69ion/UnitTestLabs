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
    public class CreateStackTests
    {
        private static Logger logger = CreateLogger();
        private const string component = "AnalaizerClass.CreateStack";
        private void CreateStackTest(int testNumber, string input, ArrayList expected)
        {
            AnalaizerClass.expression = input;
            var result = AnalaizerClass.CreateStack();
            bool b = true;
            for(int i = 0; i < result.Count; i++)
            {
                if (!result[i].Equals(expected[i]))
                {
                    b = false;
                    break;
                }
            }
            if (b)
            {
                Log.CreateLog(logger, component, testNumber, input, ListToString(expected), ListToString(result));
                Assert.AreEqual(true, true);
            }
            else
            {
                Log.CreateBugReport(logger, component, testNumber, input, ListToString(expected), ListToString(result), "");
                Assert.AreEqual(true, false);
            }
        }

        private string ListToString(ArrayList list)
        {
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < list.Count; i++)
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
            ArrayList arrayList = new ArrayList
            {
                "1",
                "1",
                "+"
            };
            CreateStackTest(1, "1 + 1 ", arrayList);
        }

        [TestMethod]
        public void Test2()
        {
            ArrayList arrayList = new ArrayList
            {
                "8",
                "35",
                "37",
                "8",
                "2",
                "/",
                "-",
                "*",
                "+",
                "2",
                "+"
            };
            CreateStackTest(2, "8 + 35 * ( 37 - 8 / 2 ) + 2 ", arrayList);
        }

        [TestMethod]
        public void Test3()
        {
            ArrayList arrayList = new ArrayList
            {
                "8", "35", "37", "8", "2", "/", "-", "*", "+", "2", "+", "8", "35", "37", "8", "2", "/", "-", "*", "+", "2", "+", "8", "35", "37", "8", "2", "/", "-", "*", "+", "2", "+"
            };
            CreateStackTest(3, "8 + 35 * ( 37 - 8 / 2 ) + 2 + 8 + 35 * ( 37 - 8 / 2 ) + 2 + 8 + 35 * ( 37 - 8 / 2 ) + 2 ", arrayList);
        }

        [TestMethod]
        public void Test4()
        {
            ArrayList arrayList = new ArrayList
            {
                
            };
            CreateStackTest(4, "", arrayList);
        }

        [TestMethod]
        public void Test5()
        {
            ArrayList arrayList = new ArrayList
            {
                "1", "2", "8", "2", "*", "+", "5", "2", "5", "6", "8", "4", "/", "*", "-", "2", "-", "*", "*", "-", "/"
            };
            CreateStackTest(5, "1 / ( 2 + 8 * 2 - 5 * ( 2 * ( 5 - 6 * ( 8 / 4 ) - 2 ) ) ) ", arrayList);
        }

    }
}
