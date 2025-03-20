using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OrangeDemo.Pages;
using System;
using System.IO;
using System.Threading;
using System.Configuration;
using OrangeDemo.Config;
using OrangeDemo.Extension;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace OrangeDemo
{
    [TestClass]
    public class OrangeLogin : BasePage
    {

        [TestMethod]
        [TestCategory("Profile")]
        [TestCategory("SmokeTest")]
        public void OrangeValidLogin()
        {
            var LoginData = JsonReader.LoadLoginData(JsonData);
            driver.FindElement(LoginPage.txt_Username).ClearandType(LoginData.Username);
            driver.FindElement(LoginPage.txt_Password).SendKeys(LoginData.Password);
            driver.FindElement(LoginPage.btn_Login).Click();
            Assert.IsTrue(driver.FindElement(DashboardPage.lbl_Header).Displayed);
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        public void OrangeInvalidLogin()
        {

            driver.FindElement(LoginPage.txt_Username).SendKeys(ExcelReader.GetTestData("Login", "Username"));
            driver.FindElement(LoginPage.txt_Password).SendKeys(ExcelReader.GetTestData("Login", "Password"));
            driver.FindElement(LoginPage.btn_Login).Click();
            Assert.IsTrue(driver.FindElement(LoginPage.lbl_warning).Displayed);
        }

        [TestMethod]
        public void AddEmployee()
        {
            driver.ClearAndSend(LoginPage.txt_Username, ExcelReader.GetTestData("Login", "Username"));


            driver.ClearAndSend(LoginPage.txt_Password, "admin123");



            driver.FindElement(LoginPage.btn_Login).Click();
            Assert.IsTrue(driver.FindElement(DashboardPage.lbl_Header).Displayed);
            driver.FindElement(DashboardPage.menu_PIM).Click();
            driver.FindElement(PIMPage.btn_Add).Click();
            driver.FindElement(PIMPage.txt_firstname).SendKeys(ExcelReader.GetTestData("UserDetails", "Firstname"));
            driver.FindElement(PIMPage.txt_lastName).SendKeys(ExcelReader.GetTestData("UserDetails", "Lastname"));
            driver.FindElement(PIMPage.cb_createLogin).Click();
            Thread.Sleep(3000); 
            driver.FindElement(PIMPage.btn_save).Click();
        }



        [TestMethod]
        public void AddClaims()
        {
            driver.FindElement(LoginPage.txt_Username).SendKeys(ExcelReader.GetTestData("Login", "Username"));
            driver.FindElement(LoginPage.txt_Password).SendKeys(ExcelReader.GetTestData("Login", "Password"));
            driver.FindElement(LoginPage.btn_Login).Click();
            driver.FindElement(DashboardPage.menu_Claim).Click();
            driver.FindElement(ClaimPage.tab_submitClaim).Click();
            driver.FindElement(ClaimPage.dp_Event).Click();
            driver.FindElement(ClaimPage.dp_Option).Click();
            driver.FindElement(ClaimPage.dp_Currency).Click();
            driver.FindElement(ClaimPage.dp_Dinar).Click();
            driver.FindElement(ClaimPage.btn_create).Click();
            WebDriverWait webDriverWait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(ClaimPage.txt_refId));
            string _refid = driver.FindElement(ClaimPage.txt_refId).GetAttribute("value");

            string xpath = ClaimPage.refid(_refid);

        }

        

    }
}
