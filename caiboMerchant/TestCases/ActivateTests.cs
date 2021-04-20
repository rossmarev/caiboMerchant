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
using Validation;

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
            var activatePage = new ActivatePage(_driver);
            activatePage.FAQ();
            var faqTab = _driver.WindowHandles.Last();
            _driver.SwitchTo().Window(faqTab);
            Assert.AreEqual("https://caibo.digital/faqs/", _driver.Url);
        }

        [Test]
        public void Profile()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.EnterCredentials("casper_jakubowski@putsbox.com", "Sepacyber1!");
            var activatePage = new ActivatePage(_driver);
            activatePage.Profile();
            Assert.IsTrue(_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div/header/div[3]/ul/li[2]/nav"))).Displayed);
            
        }

        [Test]
        public void LogOut()
        {
            var loginPage = new LoginPage(_driver);
            var activatePage = new ActivatePage(_driver);
            loginPage.EnterCredentials("casper_jakubowski@putsbox.com", "Sepacyber1!");
            activatePage.SignOut();

            bool header = _driver.FindElement(By.XPath("/html/body/div/div/main/div/form/header/h3")).Displayed;
            Assert.IsTrue(header);
        }


        [Test]
        public void VerifyTestAPI()
        {
            var loginPage = new LoginPage(_driver);
            var activatePage = new ActivatePage(_driver);
            loginPage.EnterCredentials("casper_jakubowski@putsbox.com", "Sepacyber1!");
            activatePage.TestApi();
            
            Assert.Multiple(() =>
            {
                Assert.IsTrue(_driver.FindElement(By.CssSelector("label[for = 'memberId']")).Displayed);
                Assert.IsTrue(_driver.FindElement(By.CssSelector("label[for = 'secret']")).Displayed);
                Assert.IsTrue(_driver.FindElement(By.CssSelector("label[for = 'url']")).Displayed);
                Assert.IsTrue(_driver.FindElement(By.CssSelector("label[for = 'documentation']")).Displayed);
            });

            var apiDocs = _driver.FindElement(By.LinkText("https://api-doc.sepa-cyber.com/"));
            apiDocs.Click();
           // var apiTab = _driver.WindowHandles.Last();
           // _driver.SwitchTo().Window(apiTab);
            Assert.AreEqual("https://api-doc.sepa-cyber.com/", _driver.Url);
        }

        [Test]
        public void VerifyLiverAPI()
        {
            var loginPage = new LoginPage(_driver);
            var activatePage = new ActivatePage(_driver);
            loginPage.EnterCredentials("casper_jakubowski@putsbox.com", "Sepacyber1!");
            activatePage.LiveApi();

            Assert.IsTrue(_driver.FindElement(By.XPath("//*[@id='main']/div/div/p")).Displayed);
            activatePage.ActivateAccount();
            Assert.AreEqual("https://caibo-merchant-staging.sepa-cyber.com/en/registration/step1", _driver.Url);
        }

        [Test]
        public void StartNowButton()
        {
            var loginPage = new LoginPage(_driver);
            var activatePage = new ActivatePage(_driver);
            loginPage.EnterCredentials("casper_jakubowski@putsbox.com", "Sepacyber1!");
            activatePage.ActivateAccount();
            Assert.Multiple(() =>
             {
                 Assert.AreEqual("https://caibo-merchant-staging.sepa-cyber.com/en/registration/step1/", _driver.Url);
                 Assert.IsTrue(_driver.FindElement(By.LinkText("Business details")).Enabled);
                 Assert.IsTrue(_driver.FindElement(By.LinkText("Business representative")).Enabled);
                 Assert.IsTrue(_driver.FindElement(By.LinkText("Bank details")).Enabled);
                 Assert.IsTrue(_driver.FindElement(By.LinkText("Processing information")).Enabled);
                 Assert.IsTrue(_driver.FindElement(By.LinkText("Risk management questionnaire")).Enabled);
                 Assert.IsTrue(_driver.FindElement(By.LinkText("Supporting documents")).Enabled);
             });
        }


            [TearDown]
        public void EndTest()
        {
            //_driver.Quit();
        }

    }
}
