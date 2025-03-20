using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using OrangeDemo.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Web;

namespace OrangeDemo.TestCases
{
    
    [TestClass]
    public class JsonTest
    {

        [TestMethod]
        public void TestMethod1()
        {
            string data = File.ReadAllText(ConfigurationManager.AppSettings["JsonData"]);

            JObject jsonData=JObject.Parse(data);
            string name = jsonData["Username"].ToString();
            string password = jsonData["Password"].ToString();
        }

        [TestMethod]
        public void TestMethod2()
        {
            string data = File.ReadAllText(ConfigurationManager.AppSettings["JsonData"]);

            LoginDTO login =JsonSerializer.Deserialize<LoginDTO>(data);

            string username= login.Username;
            string password= login.Password;

            LoginDTO login1 = new LoginDTO();
            login1.Username = "vel";
            login1.Password = "adin123";

            string data1=JsonSerializer.Serialize(login1);
        }
    }
}
