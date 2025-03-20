using OpenQA.Selenium;
using OrangeDemo.Config;
using OrangeDemo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo.Extension
{
    public static class WebDriverExtension
    {
        public static void ClearAndSend(this IWebDriver driver,By by,string text) 
        {
            driver.FindElement(by).ClearandType(text);
        }
    }
}
