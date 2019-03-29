using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;

namespace UnitTestLab3.CalcClassTests
{
    [TestClass]
    public class IAbsTests
    {
        private static Random random = new Random();
        private void PositiveIAbsTest(long a)
        {
            long result = CalcClass.IABS(a);
            long expected = 0;
            if(a < 0)
            {
                expected = a;
            }
            if(a > 0)
            {
                expected = -a;
            }
            Assert.AreEqual(result, expected);
        }

        private void NegativeIAbsTest(long a, string exeption)
        {
            long result = CalcClass.IABS(a);
            string exep = CalcClass.lastError;
            if (result == 0 && exep.Equals(exeption))
            {
                Assert.AreEqual(result, 0);
            }
        }

        [TestMethod]
        public void Test1()
        {
            PositiveIAbsTest(random.Next(int.MinValue + 5, 0));
        }

        [TestMethod]
        public void Test2()
        {
            PositiveIAbsTest(random.Next(0, int.MaxValue - 5));
        }

        [TestMethod]
        public void Test3()
        {
            PositiveIAbsTest(random.Next(int.MinValue + 5, int.MaxValue - 5));
        }

        [TestMethod]
        public void Test4()
        {
            NegativeIAbsTest(int.MaxValue, "Error 06");
        }

        [TestMethod]
        public void Test5()
        {
            NegativeIAbsTest(int.MinValue, "Error 06");
        }

    }
}
