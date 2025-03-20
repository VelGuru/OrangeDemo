using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo.Pages
{
    public class PIMPage
    {
        public static readonly By btn_Add = By.XPath("//button[text()=' Add ']");
        public static readonly By txt_firstname = By.Name("firstName");
        public static readonly By txt_lastName = By.Name("lastName");
        public static readonly By cb_createLogin = By.XPath("//p[text()='Create Login Details']/following::span");
        public static readonly By btn_save = By.XPath("//button[text()=' Save ']");
    }
}
