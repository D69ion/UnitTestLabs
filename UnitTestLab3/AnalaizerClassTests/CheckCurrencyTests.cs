using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;

namespace UnitTestLab3.AnalaizerClassTests
{
    [TestClass]
    public class CheckCurrencyTests
    {
        private void CheckCurrencyTest(string input, bool expected)
        {
            AnalaizerClass.expression = input;
            bool result = AnalaizerClass.CheckCurrency();
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Test1()
        {
            CheckCurrencyTest("1+(1+(1+1))", true);
        }

        [TestMethod]
        public void Test2()
        {
            CheckCurrencyTest("1+(1+(1+(1+(1+(1+1)))))", true);
        }

        [TestMethod]
        public void Test3()
        {
            CheckCurrencyTest("1+1+1+1", true);
        }

        [TestMethod]
        public void Test4()
        {
            CheckCurrencyTest("1+1+(1+1))", false);
        }

        [TestMethod]
        public void Test5()
        {
            CheckCurrencyTest("(1+1+1", false);
        }
    }
}
