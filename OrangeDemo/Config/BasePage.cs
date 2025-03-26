using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Text.Json.Nodes;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Security.Cryptography.Pkcs;

namespace OrangeDemo.Config
{
    [TestClass]
    public class BasePage
    {
        public IWebDriver driver;
        public string JsonData;
        public static ExtentReports extent;
        public ExtentTest test; 
        public TestContext TestContext { get; set; }

        [AssemblyInitialize] // Runs once before any tests
        public static void Setup(TestContext context)
        {
            string workingdir = Environment.CurrentDirectory;
            string projectDir = Directory.GetParent(workingdir).Parent.FullName;
            string latestpath =Directory.CreateDirectory(projectDir+ "\\Report\\"+"Test"+DateTime.Now.ToString("ddMMyyhhmmtt")).FullName;
            string reportpath = latestpath +"\\index.html";

            ExtentSparkReporter report = new ExtentSparkReporter(reportpath);
            extent = new ExtentReports();
            extent.AttachReporter(report);
        }

        [TestInitialize]
        public void setup()
        {
            test = extent.CreateTest(TestContext.TestName);

            InitBrowser(ConfigurationManager.AppSettings["browser"]);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.Url = ConfigReader.getUrl(ConfigurationManager.AppSettings["env"]);
            JsonData = File.ReadAllText(ConfigurationManager.AppSettings["JsonData"]);
        }



        [TestCleanup]
        public void cleanUp()
        {
            var status = TestContext.CurrentTestOutcome.ToString();

            if (status == "Failed")
            {
                test.Fail("Test Failed");
            }
            else
            {

            }
            extent.Flush();
            driver.Quit();
        }

        [AssemblyCleanup] // Runs once after all tests
        public static void TearDown()
        {
            extent.Flush(); // Finalize report
        }

        public void InitBrowser(string browserName)
        {
            switch(browserName.ToLower()) 
            {
                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    options.AddArgument("--incognito");
                    options.AddArgument("--disable-popup-blocking");
                    driver = new ChromeDriver(options);
                    break;
                case "firefox":
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("--start-maximized");
                    firefoxOptions.AddArgument("--incognito");
                    driver = new FirefoxDriver(firefoxOptions);
                    break;
                case "edge":
                    EdgeOptions edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("--start-maximized");
                    edgeOptions.AddArgument("--incognito");
                    driver = new EdgeDriver(edgeOptions);
                    break;
            }
        }
    }
}
