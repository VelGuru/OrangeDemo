using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo.Extension
{
    public static class WebelementExtension
    {
        public static void ClearandType(this IWebElement element,string args)
        {
            element.Clear();
            element.SendKeys(args);
        }
    }
}
