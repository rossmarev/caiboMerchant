using caiboMerchant.PageObjects.CreateActivate;
using caiboMerchant.PageObjects.Login;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace caiboMerchant.TestCases
{
    public class ActivateTests
    {
        IWebDriver _driver;
        WebDriverWait _wait;

        [SetUp]
        public void Initialize()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _driver.Navigate().GoToUrl("https://caibo-merchant-staging.sepa-cyber.com/en");


        }

        [Test]
        public void VerifyFAQ()
        {  
            // test with generating new account
          // _driver.Navigate().GoToUrl("https://putsbox.com/");
          // var putsbox = new GenerateTestMail(_driver);
          // var testMail = putsbox.CopyMail();
          // _driver.Navigate().GoToUrl("https://caibo-merchant-staging.sepa-cyber.com/en//signup");
          // var signUpPage = new CreateAccPage(_driver, testMail);
          // signUpPage.CreateAccount("test", "testCompany", "Sepacyber1!", "Sepacyber1!");
          // _driver.Navigate().GoToUrl("https://putsbox.com/");
          // putsbox.OpenInbox();
          // putsbox.OpenMail();
          // string newTab = _driver.WindowHandles.Last();
          // _driver.SwitchTo().Window(newTab);
          // IWebElement confirmMail = _wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Confirm email address")));
          // confirmMail.Click();

            //test with already opened account
            var loginPage = new LoginPage(_driver);
            loginPage.EnterCredentials("casper_jakubowski@putsbox.com", "Sepacyber1!");

            //to be continued...
        }


        [TearDown]
        public void EndTest()
        {
            //_driver.Quit();
        }

    }
}
