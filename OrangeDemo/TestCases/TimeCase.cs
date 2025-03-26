using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using OrangeDemo.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo.TestCases
{
    [TestClass]
    public class TimeCase : BasePage
    {
        [TestMethod]
        public void TimeTestMethod1()
        {
            string data = File.ReadAllText(ConfigurationManager.AppSettings["JsonData"]);

            JObject jsonData = JObject.Parse(data);
            string name = jsonData["Username"].ToString();
            string password = jsonData["Password"].ToString();
        }

        [TestMethod]
        public void TimeTestMethod2()
        {
            string data = File.ReadAllText(ConfigurationManager.AppSettings["JsonData"]);

            JObject jsonData = JObject.Parse(data);
            string name = jsonData["Username"].ToString();
            string password = jsonData["Password"].ToString();
            MySqlConnection conn=null;

            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ToString();
            try
            {
                 conn = new MySqlConnection(connectionString);
                // Open connection
                conn.Open();
                Console.WriteLine("Connected to MySQL database!");

                // Define SQL query
                string query = "SELECT * FROM customers";
                DataTable dataTable = new DataTable();

                // Execute query
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dataTable);

                string a = dataTable.Rows[0]["customerName"].ToString();
            }finally
            {
                conn.Close();
            }

        }
    }
}
