using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using caiboMerchant.PageObjects.Login;
using caiboMerchant.PageObjects.CreateActivate;
using System.Linq;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace caiboMerchant.TestCases
{
    public class LoginTest
    {
        IWebDriver _driver;
        WebDriverWait _wait;

        [SetUp]
        public void Initialize()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            //_wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _driver.Navigate().GoToUrl("https://caibo-merchant-staging.sepa-cyber.com/en");

        }

        [Test]
        public void ValidCredentials()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.EnterCredentials("israel_mayert@putsbox.com", "Sepacyber1!");

            Assert.AreEqual("https://caibo-merchant-staging.sepa-cyber.com/en/registration", _driver.Url);
        }

        [Test]
        public void SignUpLink()
        {
            

           var loginPage = new LoginPage(_driver);
            loginPage.SignUp();
            Assert.AreEqual("https://caibo-merchant-staging.sepa-cyber.com/en//signup", _driver.Url);

        }

        [Test]
        public void InvalidEmailFormat()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.EnterCredentials("asdf", "Sepacyber1!");
            string actualError = _driver.FindElement(By.Id("email-error")).Text;
            Assert.AreEqual("Please enter a valid email address.", actualError);
        }

        [Test]
        public void WrongPass()
        {
           var loginPage = new LoginPage(_driver);
            loginPage.EnterCredentials("israel_mayert@putsbox.com", "wrong pass");
            string actualError = _driver.FindElement(By.XPath("/html/body/div/div/main/div/form/div[2]")).Text;
            Assert.AreEqual("Incorrect email or password!", actualError);
        }

        [Test]

        public void WrongEmail()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.EnterCredentials("wrong_email@putsbox.com", "Sepacyber1!");
            string actualError = _driver.FindElement(By.XPath("/html/body/div/div/main/div/form/div[2]")).Text;

            Assert.AreEqual("Incorrect email or password!", actualError);

        }


        [Test]

        public void ResetPasss()
        {
            var loginPage = new LoginPage(_driver);            
            loginPage.ResetPassLink();


            var resetPassPage = new ResetPass(_driver);
            resetPassPage.EnterMail("micheal@putsbox.com");

            _driver.Navigate().GoToUrl("https://putsbox.com/");
            var putsboxMail = new GenerateTestMail(_driver);
            putsboxMail.PutsboxSignIn();

            _driver.Navigate().Refresh();
           
            putsboxMail.OpenResetMail();

            string newTab = _driver.WindowHandles.Last();
            _driver.SwitchTo().Window(newTab);

            putsboxMail.ClickResetPass();

            resetPassPage.NewConfirmPass("Sepacyber1!", "Sepacyber1!");
                
             
            string successMessage = _driver.FindElement(By.XPath("//*[@id='form-message_resetpw']/p")).Text;
            Assert.AreEqual("You have successfully changed your password.", successMessage);

            string inboxTab = _driver.WindowHandles.First();
            _driver.SwitchTo().Window(inboxTab);

             //clear history
           
            putsboxMail.ClearHistory();
            IAlert confirmAlert = _driver.SwitchTo().Alert();
            confirmAlert.Accept();


        }


        [Test]

        public void ResetMismatchingPass()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.ResetPassLink();


            var resetPassPage = new ResetPass(_driver);
            resetPassPage.EnterMail("micheal@putsbox.com");

            _driver.Navigate().GoToUrl("https://putsbox.com/");
            var putsboxMail = new GenerateTestMail(_driver);
            putsboxMail.PutsboxSignIn();

            _driver.Navigate().Refresh();

            putsboxMail.OpenResetMail();

            string newTab = _driver.WindowHandles.Last();
            _driver.SwitchTo().Window(newTab);

            putsboxMail.ClickResetPass();

            resetPassPage.NewConfirmPass("Sepacyber1!", "Sepacyber1@");


            string errorMessage = _driver.FindElement(By.XPath("/html/body/div/div/main/div/form/div[2]/p")).Text;
            Assert.AreEqual("Passwords do not match!", errorMessage);

            string inboxTab = _driver.WindowHandles.First();
            _driver.SwitchTo().Window(inboxTab);

            //clear history

            putsboxMail.ClearHistory();
            IAlert confirmAlert = _driver.SwitchTo().Alert();
            confirmAlert.Accept();
        }

            [Test]
        public void ResetPassWrongMail()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.ResetPassLink();

            var resetPassPage = new ResetPass(_driver);
            resetPassPage.EnterMail("asd@abv.bg");
            string actualError = _driver.FindElement(By.XPath("/html/body/div/div/main/div/form/div[2]/p")).Text;
            Assert.AreEqual("account not found, please check email-address", actualError);
        }

        [Test]

        public void ResendButton()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.ResetPassLink();

            var resetPassPage = new ResetPass(_driver);
            resetPassPage.EnterMail("micheal@putsbox.com");

            Actions action = new Actions(_driver);
            IWebElement resendBut = _driver.FindElement(By.LinkText("resend"));
            action.KeyDown(Keys.Control).Click(resendBut).KeyUp(Keys.Control).Build().Perform();

            string newTab = _driver.WindowHandles.Last();
            _driver.SwitchTo().Window(newTab);


            _driver.Navigate().GoToUrl("https://putsbox.com/");

            var putsboxSignIn = new GenerateTestMail(_driver);
            putsboxSignIn.PutsboxSignIn();

            var testMail = _driver.FindElement(By.PartialLinkText("micheal"));
            testMail.Click();
            var resetMail = _driver.FindElement(By.XPath("/html/body/div/div[1]/div/table/tbody/tr[1]/td[2]")).Displayed;
            Assert.IsTrue(resetMail);

            //clear inbox history
            putsboxSignIn.ClearHistory();
            IAlert confirmAlert = _driver.SwitchTo().Alert();
            confirmAlert.Accept();

            string firstTab = _driver.WindowHandles.First();
            _driver.SwitchTo().Window(firstTab);

            resetPassPage.ResendMailButton();

           var enterResendMail = new ResetPass(_driver);
            enterResendMail.EnterMail("micheal@putsbox.com"); 

            _driver.SwitchTo().Window(newTab);

             resetMail = _driver.FindElement(By.XPath("/html/body/div/div[1]/div/table/tbody/tr[1]/td[2]")).Displayed;
            Assert.IsTrue(resetMail);

            //clear inbox history
            putsboxSignIn.ClearHistory();
            confirmAlert = _driver.SwitchTo().Alert();
            confirmAlert.Accept();

        }


        [TearDown]
        public void EndTest()
        {
           // _driver.Quit();
        }
    }
}
