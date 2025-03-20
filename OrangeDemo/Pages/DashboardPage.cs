using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo.Pages
{
    public class DashboardPage
    {
        public static readonly By lbl_Header = By.XPath("//h6[text()='Dashboard']");

        public static readonly By menu_PIM = By.XPath("//span[text()='PIM']");
        public static readonly By menu_Claim = By.XPath("//span[text()='Claim']");
    }
}
