using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;

namespace UnitTestLab3.CalcClassTests
{
    [TestClass]
    public class MultTests
    {
        private void PositiveMultTest(long a, long b)
        {
            long result = CalcClass.Mult(a, b);
            long expected = a * b;
            Assert.AreEqual(result, expected);
        }

        private void NegativeMultTest(long a, long b, string exeption)
        {
            long result = CalcClass.Mult(a, b);
            string exep = CalcClass.lastError;
            if (result == 0 && exep.Equals(exeption))
            {
                Assert.AreEqual(result, 0);
            }
        }

        [TestMethod]
        public void Test1()
        {
            PositiveMultTest(2, 2);
        }

        [TestMethod]
        public void Test2()
        {
            PositiveMultTest(-2, 2);
        }

        [TestMethod]
        public void Test3()
        {
            PositiveMultTest(0, 0);
        }

        [TestMethod]
        public void Test4()
        {
            NegativeMultTest((long)int.MaxValue, (long)int.MaxValue, "Error 06");
        }

        [TestMethod]
        public void Test5()
        {
            NegativeMultTest(int.MaxValue, int.MaxValue, "Error 06");
        }

        [TestMethod]
        public void Test6()
        {
            NegativeMultTest(int.MinValue, int.MinValue, "Error 06");
        }

    }
}
