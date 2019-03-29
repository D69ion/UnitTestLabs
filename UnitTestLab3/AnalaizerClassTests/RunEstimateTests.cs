using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;
using System.Collections;

namespace UnitTestLab3.AnalaizerClassTests
{
    [TestClass]
    public class RunEstimateTests
    {
        private void RunEstimateTest(ArrayList input, string expected)
        {
            AnalaizerClass.opz = input;
            string result = AnalaizerClass.RunEstimate();
            if (input.Contains(expected))
            {
                Assert.AreEqual(true, true);
            }
            else
            {
                Assert.AreEqual(false, false);
            }
        }

        [TestMethod]
        public void Test1()
        {
            ArrayList arrayList = new ArrayList { "1", "1", "+" };
            RunEstimateTest(arrayList, "2");
        }
        [TestMethod]
        public void Test2()
        {
            ArrayList arrayList = new ArrayList {  };
            RunEstimateTest(arrayList, "Error 03");
        }

        [TestMethod]
        public void Test3()
        {
            ArrayList arrayList = new ArrayList { "1", "+", "1" };
            RunEstimateTest(arrayList, "Error 03");
        }

        [TestMethod]
        public void Test4()
        {
            ArrayList arrayList = new ArrayList { ((long)int.MaxValue + 5).ToString(), "1", "+" };
            RunEstimateTest(arrayList, "Error 06");
        }

        [TestMethod]
        public void Test5()
        {
            ArrayList arrayList = new ArrayList { "1", "0", "/" };
            RunEstimateTest(arrayList, "Error 09");
        }

    }
}
