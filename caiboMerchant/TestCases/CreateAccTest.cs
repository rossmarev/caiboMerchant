using System.Linq;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using caiboMerchant.PageObjects.CreateActivate;
using OpenQA.Selenium.Interactions;
using System;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = OpenQA.Selenium.Support.UI.ExpectedConditions;
using System.Collections.Generic;

namespace caiboMerchant.TestCases
{
   public class CreateAccTest
    {
        IWebDriver _driver;
        WebDriverWait _wait;

        [SetUp]
        public void Initialize()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
           _driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(20); 


        }






        [Test]
        public void CreateTest()
        {
            _driver.Navigate().GoToUrl("https://putsbox.com/");
            var generateTestMail = new GenerateTestMail(_driver);
            var testMail = generateTestMail.CopyMail();



            _driver.Navigate().GoToUrl("https://caibo-merchant-staging.sepa-cyber.com/en//signup");
            var createAccPage = new CreateAccPage(_driver, testMail);
            createAccPage.CreateAccount();


            _driver.Navigate().GoToUrl("https://putsbox.com/");

            var inbox = _driver.FindElement(By.XPath("/html/body/div/div[1]/div/div/section/div/div[2]/div/ul/li/a"));
            inbox.Click();

            IWebElement htmlMail = _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div/div[1]/div/table/tbody/tr/td[4]/a[2]")));
            htmlMail.Click();


            string newTab = _driver.WindowHandles.Last();
            _driver.SwitchTo().Window(newTab);
            IWebElement confirmMail = _wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Confirm email address")));
            confirmMail.Click();

            IWebElement startNow = _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='main']/div/div/button")));
            startNow.Click();


        }

        [Test]
        public void Login()
        {
            _driver.Navigate().GoToUrl("https://caibo-merchant-staging.sepa-cyber.com/en");

            var email = _driver.FindElement(By.Id("email"));
            email.SendKeys("israel_mayert@putsbox.com");
            var pass = _driver.FindElement(By.Id("password"));
            pass.SendKeys("Sepacyber1!");
            var loginButton = _driver.FindElement(By.XPath("/html/body/div/div/main/div/form/footer/button"));
            loginButton.Click();
            IWebElement startNow = _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='main']/div/div/button")));
            startNow.Click();

            var businessDetails = new BusinessDetails(_driver);
            businessDetails.EnterBizDetails();


            var businessRep = new BusinessRep(_driver);
            businessRep.EnterBizRep();


            var bankDet = new BankDetails(_driver);
            bankDet.EnterBankDet();

            var processInfo = new ProcessingInfo(_driver);
            processInfo.EnterProcessingInfo();

            var riskManage = new RiskManagement(_driver);
            riskManage.EnterRiskManagement();

            var supportDocs = new SupportingDocs(_driver);
            supportDocs.AttachDocs();
        }



       




        [TearDown]
        public void EndTest()
        {
            //driver.Quit();
        }

    }
}
