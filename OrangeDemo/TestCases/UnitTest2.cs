using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrangeDemo.Config;
using System;

namespace OrangeDemo
{
    [TestClass]
    
    public class UnitTest2 : BasePage
    {
        [TestMethod]
        public void TestMethod1()
        {
            string a = "asdfa";
            Assert.IsTrue(a.Contains("55"));
        }

        [TestMethod]
        public void TestMethod2()
        {

        }
    }
}
