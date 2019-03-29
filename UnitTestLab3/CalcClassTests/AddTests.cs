using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;

namespace UnitTestLab3.CalcClassTests
{
    [TestClass]
    public class AddTests
    {
        private static Random random = new Random();
        private void PositiveAddTest(long a, long b)
        {
            long result = CalcClass.Add(a, b);
            long expected = a + b;
            Assert.AreEqual(result, expected);
        }

        private void NegativeAddTest(long a, long b, string exeption)
        {
            long result = CalcClass.Add(a, b);
            string exep = CalcClass.lastError;
            if (result == 0 && exep.Equals(exeption))
            {
                Assert.AreEqual(result, 0);
            }
        }

        [TestMethod]
        public void Test1()
        {
            PositiveAddTest(random.Next(int.MinValue / 2, int.MaxValue / 2), random.Next(int.MinValue / 2, int.MaxValue / 2));
        }

        [TestMethod]
        public void Test2()
        {
            PositiveAddTest(random.Next(int.MinValue / 2, int.MaxValue / 2), random.Next(int.MinValue / 2, int.MaxValue / 2));
        }

        [TestMethod]
        public void Test3()
        {
            PositiveAddTest(random.Next(int.MinValue / 2, int.MaxValue / 2), random.Next(int.MinValue / 2, int.MaxValue / 2));
        }

        [TestMethod]
        public void Test4()
        {
            NegativeAddTest((long)int.MinValue - 5, (long)int.MinValue - 5, "Error 06");
                 
        }

        [TestMethod]
        public void Test5()
        {
            NegativeAddTest((long)int.MaxValue + 5, (long)int.MaxValue + 5, "Error 06");
        }
    }
}
