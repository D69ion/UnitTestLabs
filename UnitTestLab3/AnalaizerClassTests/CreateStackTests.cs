using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseCalculator;
using System.Collections;

namespace UnitTestLab3.AnalaizerClassTests
{
    [TestClass]
    public class CreateStackTests
    {
        private void CreateStackTest(string input, ArrayList expected)//4 2 7 5
        {
            AnalaizerClass.expression = input;
            var result = AnalaizerClass.CreateStack();
            bool b = true;
            for(int i = 0; i < result.Count; i++)
            {
                if (!result[i].Equals(expected[i]))
                {
                    b = false;
                    break;
                }
            }
            if (b)
            {
                Assert.AreEqual(true, true);
            }
            else
            {
                Assert.AreEqual(true, false);
            }
        }

        [TestMethod]
        public void Test1()
        {
            ArrayList arrayList = new ArrayList
            {
                "1",
                "1",
                "+"
            };
            CreateStackTest("1 + 1 ", arrayList);
        }

        [TestMethod]
        public void Test2()
        {
            ArrayList arrayList = new ArrayList
            {
                "8",
                "35",
                "37",
                "8",
                "2",
                "/",
                "-",
                "*",
                "+",
                "2",
                "+"
            };
            CreateStackTest("8 + 35 * ( 37 - 8 / 2 ) + 2 ", arrayList);
        }

        [TestMethod]
        public void Test3()
        {
            ArrayList arrayList = new ArrayList
            {
                "8", "35", "37", "8", "2", "/", "-", "*", "+", "2", "+", "8", "35", "37", "8", "2", "/", "-", "*", "+", "2", "+", "8", "35", "37", "8", "2", "/", "-", "*", "+", "2", "+"
            };
            CreateStackTest("8 + 35 * ( 37 - 8 / 2 ) + 2 + 8 + 35 * ( 37 - 8 / 2 ) + 2 + 8 + 35 * ( 37 - 8 / 2 ) + 2 ", arrayList);
        }

        [TestMethod]
        public void Test4()
        {
            ArrayList arrayList = new ArrayList
            {
                
            };
            CreateStackTest("", arrayList);
        }

        [TestMethod]
        public void Test5()
        {
            ArrayList arrayList = new ArrayList
            {
                "1", "2", "8", "2", "*", "+", "5", "2", "5", "6", "8", "4", "/", "*", "-", "2", "-", "*", "*", "-", "/"
            };
            CreateStackTest("1 / ( 2 + 8 * 2 - 5 * ( 2 * ( 5 - 6 * ( 8 / 4 ) - 2 ) ) ) ", arrayList);
        }

    }
}
