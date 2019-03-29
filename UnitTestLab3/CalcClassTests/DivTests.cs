using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;

namespace UnitTestLab3.CalcClassTests
{
    [TestClass]
    public class DivTests
    {
        private static Random random = new Random();
        private void PositiveDivTest(long a, long b)
        {
            long result = CalcClass.Div(a, b);
            long expected = a / b;
            Assert.AreEqual(result, expected);
        }

        private void NegativeDivTest(long a, long b, string exeption)
        {
            long result = CalcClass.Div(a, b);
            string exep = CalcClass.lastError;
            if (result == 0 && exep.Equals(exeption))
            {
                Assert.AreEqual(result, 0);
            }
        }

        [TestMethod]
        public void Test1()
        {
            PositiveDivTest(random.Next(int.MinValue + 5, int.MaxValue - 5), random.Next(int.MinValue + 5, int.MaxValue - 5));
        }

        [TestMethod]
        public void Test2()
        {
            PositiveDivTest(random.Next(int.MinValue + 5, int.MaxValue - 5), random.Next(int.MinValue + 5, int.MaxValue - 5));
        }

        [TestMethod]
        public void Test3()
        {
            PositiveDivTest(random.Next(int.MinValue + 5, int.MaxValue - 5), random.Next(int.MinValue + 5, int.MaxValue - 5));
        }

        [TestMethod]
        public void Test4()
        {
            PositiveDivTest(random.Next(int.MinValue + 5, int.MaxValue - 5), random.Next(int.MinValue + 5, int.MaxValue - 5));
        }

        [TestMethod]
        public void Test5()
        {
            NegativeDivTest(random.Next(int.MinValue + 5, int.MaxValue - 5), 0, "Error 09");
        }

        [TestMethod]
        public void Test6()
        {
            NegativeDivTest((long)int.MaxValue + 5, (long)int.MaxValue + 5, "Error 06");
        }
    }
}
