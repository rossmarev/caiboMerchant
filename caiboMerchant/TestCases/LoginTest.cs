using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using caiboMerchant.PageObjects;
using System.Linq;


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
            var loginPage = new LoginPage(_driver);

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

        public void ResetPass()
        {
            var loginPage = new LoginPage(_driver);            
            loginPage.ResetPass();

            var email = _driver.FindElement(By.Name("login_email"));
            email.SendKeys("june@putsbox.com");
            var continueButton = _driver.FindElement(By.XPath("/html/body/div/div/main/div/form/footer/button"));
            continueButton.Click();

            _driver.Navigate().GoToUrl("https://putsbox.com/");

            var signIn = _driver.FindElement(By.PartialLinkText("Sign in"));
            signIn.Click();
            var emailPutsbox = _driver.FindElement(By.Id("user_email"));
            emailPutsbox.SendKeys("r.marev.workphone@gmail.com");
            var pass = _driver.FindElement(By.Id("user_password"));
            pass.SendKeys("Sepacyber1");
            var signinButton = _driver.FindElement(By.Name("commit"));
            signinButton.Click();

            var testMail = _driver.FindElement(By.PartialLinkText("june"));  
            testMail.Click();

            IWebElement htmlMail = _driver.FindElement(By.PartialLinkText("HTML"));
            htmlMail.Click();

            string newTab = _driver.WindowHandles.Last();
            _driver.SwitchTo().Window(newTab);

            IWebElement resetPass = _driver.FindElement(By.LinkText("Reset Password"));
            resetPass.Click();

            
            var newPass = _driver.FindElement(By.Id("password"));
            newPass.SendKeys("Sepacyber1@");
            var confirmNewPass = _driver.FindElement(By.Id("repeat_password"));
            confirmNewPass.SendKeys("Sepacyber1@");
            var confirmButton = _driver.FindElement(By.XPath("/html/body/div/div/main/div/form/footer/button"));
            confirmButton.Click();

            string successMessage = _driver.FindElement(By.XPath("//*[@id='form-message_resetpw']/p")).Text;
            Assert.AreEqual("You have successfully changed your password.", successMessage);

           
        }



        

        [TearDown]
        public void EndTest()
        {
           // _driver.Quit();
        }
    }
}
