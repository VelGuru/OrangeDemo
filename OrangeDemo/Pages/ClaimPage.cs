using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo.Pages
{
    public class ClaimPage
    {

        public static readonly By tab_submitClaim = By.XPath(" //a[text()='Submit Claim']");
        public static readonly By tab_myClaim = By.XPath(" //a[text()='My Claims']");

        public static readonly By dp_Event = By.XPath("//label[text()='Event']/following::div");
        public static readonly By dp_Currency = By.XPath("//label[text()='Currency']/following::div");

        public static readonly By dp_Option = By.XPath("//span[text()='Accommodation']");
        public static readonly By dp_Dinar = By.XPath("//span[text()='Algerian Dinar']");
        public static readonly By btn_create = By.XPath("//button[normalize-space()='Create']");
        public static readonly By btn_Submit = By.XPath("//button[normalize-space()='Submit']");

        public static readonly By txt_refId = By.XPath("//label[text()='Reference Id']/following::input");

        public static string refid(string text) => $"//div[contains(text(),'{text}')]";


        public static int add(int a, int b)
        {
            return a + b;
        }

        public static int sub(int a, int b) => a-b;

    }
}
