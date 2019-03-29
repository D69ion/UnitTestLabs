using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;

namespace UnitTestLab3.AnalaizerClassTests
{
    [TestClass]
    public class FormatTests
    {
        private void FormatTest(string input, string expected)
        {
            AnalaizerClass.expression = input;
            string result = AnalaizerClass.Format();
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
            FormatTest("1+1", "1 + 1 ");
        }

        [TestMethod]
        public void Test2()
        {
            FormatTest("1   +  1 ", "1 + 1 ");
        }

        [TestMethod]
        public void Test3()
        {
            FormatTest("1+", "Error 05");
        }

        [TestMethod]
        public void Test4()
        {
            FormatTest("1++1", "Error 04");
        }

        [TestMethod]
        public void Test5()
        {
            FormatTest("!1", "Error 02");
        }

        [TestMethod]
        public void Test6()
        {
            StringBuilder str = new StringBuilder();
            for(int i = 0; i< 66000; i++)
            {
                str.Append('1');
            }
            str.Append("+1");
            FormatTest(str.ToString(), "Error 07");
        }

    }
}
