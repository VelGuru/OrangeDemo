using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo.TestCases
{
    [TestClass]
    public class TimeCase
    {
        [TestMethod]
        public void TestMethod1()
        {
            string data = File.ReadAllText(ConfigurationManager.AppSettings["JsonData"]);

            JObject jsonData = JObject.Parse(data);
            string name = jsonData["Username"].ToString();
            string password = jsonData["Password"].ToString();
        }

        [TestMethod]
        public void TestMethod1()
        {
            string data = File.ReadAllText(ConfigurationManager.AppSettings["JsonData"]);

            JObject jsonData = JObject.Parse(data);
            string name = jsonData["Username"].ToString();
            string password = jsonData["Password"].ToString();
        }
    }
}
