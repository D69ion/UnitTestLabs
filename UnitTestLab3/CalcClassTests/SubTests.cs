using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;

namespace UnitTestLab3.CalcClassTests
{
    [TestClass]
    public class SubTests
    {
        private static Random random = new Random();
        private void PositiveSubTest(long a, long b)
        {
            long result = CalcClass.Sub(a, b);
            long expected = a - b;
            Assert.AreEqual(result, expected);
        }

        private void NegativeSubTest(long a, long b, string exeption)
        {
            long result = CalcClass.Sub(a, b);
            string exep = CalcClass.lastError;
            if (result == 0 && exep.Equals(exeption))
            {
                Assert.AreEqual(result, 0);
            }
        }

        [TestMethod]
        public void Test1()
        {
            PositiveSubTest(random.Next(int.MinValue / 2, int.MaxValue / 2), random.Next(int.MinValue / 2, int.MaxValue / 2));
        }

        [TestMethod]
        public void Test2()
        {
            PositiveSubTest(random.Next(int.MinValue / 2, int.MaxValue / 2), random.Next(int.MinValue / 2, int.MaxValue / 2));
        }

        [TestMethod]
        public void Test3()
        {
            PositiveSubTest(random.Next(int.MinValue / 2, int.MaxValue / 2), random.Next(int.MinValue / 2, int.MaxValue / 2));
        }

        [TestMethod]
        public void Test4()
        {
            NegativeSubTest(int.MaxValue, int.MaxValue, "Error 06");
        }

        [TestMethod]
        public void Test5()
        {
            NegativeSubTest(int.MinValue, int.MinValue, "Error 06");
        }

    }
}
