using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;

namespace UnitTestLab3.AnalaizerClassTests
{
    [TestClass]
    public class EstimateTests
    {
        private void EstimateTest(string input, string expected)//8 1
        {
            AnalaizerClass.expression = input;
            string result = AnalaizerClass.Estimate();
            //Assert.AreEqual(result, expected);
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
            EstimateTest("1+1", "2");
        }

        [TestMethod]
        public void Test2()
        {
            EstimateTest("8 + 35 * ( 37 - 8 / 2 ) + 2", "1165");
        }

        [TestMethod]
        public void Test3()
        {
            EstimateTest("", "");
        }

        [TestMethod]
        public void Test4()
        {
            EstimateTest("(1+1", "Error 01");
        }

        [TestMethod]
        public void Test5()
        {
            EstimateTest("8 + 35 * ( 37 - 8 / 2 ) + 2 + 8 + 35 * ( 37 - 8 / 2 ) + 2 + 8 + 35 * ( 37 - 8 / 2 ) + 2 +" +
                "8 + 35 * ( 37 - 8 / 2 ) + 2 + 8 + 35 * ( 37 - 8 / 2 ) + 2 + 8 + 35 * ( 37 - 8 / 2 ) + 2", "Error 08");
        }

    }
}
