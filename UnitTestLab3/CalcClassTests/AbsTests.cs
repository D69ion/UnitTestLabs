using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;

namespace UnitTestLab3.CalcClassTests
{
    [TestClass]
    public class AbsTests
    {
        static Random random = new Random();
        private void PositiveAbsTest(long a)
        {
            long result = CalcClass.ABS(a);
            long expected = Math.Abs(a);
            Assert.AreEqual(result, expected);
        }

        private void NegativeAbsTest(long a, string exeption)
        {
            long result = CalcClass.ABS(a);
            string exep = CalcClass.lastError;
            if (result == 0 && exep.Equals(exeption))
            {
                Assert.AreEqual(result, 0);
            }
        }

        [TestMethod]
        public void Test1()
        {
            PositiveAbsTest(random.Next(int.MinValue + 5, int.MaxValue - 5));
        }

        [TestMethod]
        public void Test2()
        {
            PositiveAbsTest(random.Next(int.MinValue + 5, int.MaxValue - 5));
        }

        [TestMethod]
        public void Test3()
        {
            PositiveAbsTest(random.Next(int.MinValue + 5, int.MaxValue - 5));
        }

        [TestMethod]
        public void Test4()
        {
            NegativeAbsTest((long)int.MinValue - 5, "Error 06");
        }

        [TestMethod]
        public void Test5()
        {
            NegativeAbsTest((long)int.MaxValue + 5, "Error 06");
        }

    }
}
