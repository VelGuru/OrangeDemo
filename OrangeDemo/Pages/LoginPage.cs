using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;

namespace OrangeDemo.Pages
{
    public class LoginPage
    {
        
        public static readonly By txt_Username = By.Name("username");

        public static readonly By txt_Password = By.Name("password");

        public static readonly By btn_Login = By.XPath("//button[text()=' Login ']");

        public static readonly By lbl_warning = By.XPath("//p[text()='Invalid credentials']");
        
    }
}
