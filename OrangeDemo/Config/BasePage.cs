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

namespace OrangeDemo.Config
{
    public class BasePage
    {
        public IWebDriver driver;
        public string JsonData;

        [TestInitialize]
        public void setup()
        {
            InitBrowser(ConfigurationManager.AppSettings["browser"]);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.Url = ConfigReader.getUrl(ConfigurationManager.AppSettings["env"]);
            JsonData = File.ReadAllText(ConfigurationManager.AppSettings["JsonData"]);

        }

        [TestCleanup]
        public void cleanUp()
        {

            //driver.Quit();
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
