using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;

namespace UnitTestLab3.CalcClassTests
{
    [TestClass]
    public class ModTests
    {
        private static Random random = new Random();
        private void PositiveModTest(long a, long b)
        {
            long result = CalcClass.Mod(a, b);
            long expected = a % b;
            Assert.AreEqual(result, expected);
        }

        private void NegativeModTest(long a, long b, string exeption)
        {
            long result = CalcClass.Mod(a, b);
            string exep = CalcClass.lastError;
            if (result == 0 && exep.Equals(exeption))
            {
                Assert.AreEqual(result, 0);
            }
        }

        [TestMethod]
        public void Test1()
        {
            PositiveModTest(random.Next(int.MinValue / 2, int.MaxValue / 2), random.Next(int.MinValue / 2, int.MaxValue / 2));
        }

        [TestMethod]
        public void Test2()
        {
            PositiveModTest(random.Next(int.MinValue / 2, int.MaxValue / 2), random.Next(int.MinValue / 2, int.MaxValue / 2));
        }

        [TestMethod]
        public void Test3()
        {
            PositiveModTest(random.Next(int.MinValue / 2, int.MaxValue / 2), random.Next(int.MinValue / 2, int.MaxValue / 2));
        }

        [TestMethod]
        public void Test4()
        {
            NegativeModTest(int.MaxValue, int.MaxValue, "Error 06");
        }

        [TestMethod]
        public void Test5()
        {
            NegativeModTest(int.MinValue, int.MinValue, "Error 06");
        }

    }
}
