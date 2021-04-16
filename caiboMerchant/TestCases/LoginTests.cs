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
using caiboMerchant.PageObjects.MyAccount;
using System.Linq;
using OpenQA.Selenium.Interactions;
using System.Threading;


namespace caiboMerchant.TestCases
{
    public class LoginTestsInbox
    {
        IWebDriver _driver;
        WebDriverWait _wait;


        [SetUp]
        public void Initialize()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            //_wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _driver.Navigate().GoToUrl("https://putsbox.com");
            var putsbox = new GenerateTestMail(_driver);
            putsbox.PutsboxSignIn();
            _driver.Navigate().GoToUrl("https://putsbox.com/micheal/inspect");
            putsbox.ClearHistory();           
            IAlert confirmAlert = _driver.SwitchTo().Alert();
            confirmAlert.Accept();
            Thread.Sleep(3000);
            _driver.Navigate().GoToUrl("https://caibo-merchant-staging.sepa-cyber.com/en");

        }
      

        [Test]

        public void ResetPasss()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.ResetPassLink();


            var resetPassPage = new ResetPass(_driver);
            resetPassPage.EnterMail("micheal@putsbox.com");

            _driver.Navigate().GoToUrl("https://putsbox.com/micheal/inspect");
            var putsboxMail = new GenerateTestMail(_driver);
            Thread.Sleep(2000);

            putsboxMail.OpenResetLink();

            string newTab = _driver.WindowHandles.Last();
            _driver.SwitchTo().Window(newTab);

            putsboxMail.ClickResetPass();

            resetPassPage.NewConfirmPass("Sepacyber1@", "Sepacyber1@");


            string successMessage = _driver.FindElement(By.XPath("//*[@id='form-message_resetpw']/p")).Text;
            Assert.AreEqual("You have successfully changed your password.", successMessage);

            

        }


        [Test]

        public void ResetMismatchingPass()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.ResetPassLink();


            var resetPassPage = new ResetPass(_driver);
            resetPassPage.EnterMail("micheal@putsbox.com");

            _driver.Navigate().GoToUrl("https://putsbox.com/micheal/inspect");
            Thread.Sleep(2000);

            var putsboxMail = new GenerateTestMail(_driver);


            putsboxMail.OpenResetLink();

            string newTab = _driver.WindowHandles.Last();
            _driver.SwitchTo().Window(newTab);

            putsboxMail.ClickResetPass();

            resetPassPage.NewConfirmPass("Sepacyber1!", "Sepacyber1@");


            string errorMessage = _driver.FindElement(By.XPath("/html/body/div/div/main/div/form/div[2]/p")).Text;
            Assert.AreEqual("Passwords do not match!", errorMessage);

           

        }


        [Test]

        public void ResendButton()
        {
            var putsbox = new GenerateTestMail(_driver);

            var loginPage = new LoginPage(_driver);
            loginPage.ResetPassLink();

            var resetPassPage = new ResetPass(_driver);
            resetPassPage.EnterMail("micheal@putsbox.com");

            Actions action = new Actions(_driver);
            IWebElement resendBut = _driver.FindElement(By.LinkText("resend"));
            action.KeyDown(Keys.Control).Click(resendBut).KeyUp(Keys.Control).Build().Perform();

            string newTab = _driver.WindowHandles.Last();
            _driver.SwitchTo().Window(newTab);


            _driver.Navigate().GoToUrl("https://putsbox.com/micheal/inspect");
            Thread.Sleep(3000);


           
            Assert.IsTrue(_driver.FindElement(By.XPath("/html/body/div/div[1]/div/table/tbody/tr[1]/td[2]")).Displayed);

            //clear inbox history
            putsbox.ClearHistory();
            IAlert confirmAlert = _driver.SwitchTo().Alert();
            confirmAlert.Accept();
            Thread.Sleep(4000);


            string firstTab = _driver.WindowHandles.First();
            _driver.SwitchTo().Window(firstTab);

            resetPassPage.ResendMailButton();

            var enterResendMail = new ResetPass(_driver);
            enterResendMail.EnterMail("micheal@putsbox.com");

            _driver.SwitchTo().Window(newTab);
            Thread.Sleep(5000);

            Assert.IsTrue(_driver.FindElement(By.XPath("/html/body/div/div[1]/div/table/tbody/tr[1]/td[2]")).Displayed);

           


        }

        [Test]

        public void LoginNewPass()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.ResetPassLink();


            var resetPassPage = new ResetPass(_driver);
            resetPassPage.EnterMail("micheal@putsbox.com");

            _driver.Navigate().GoToUrl("https://putsbox.com/micheal/inspect");
            _driver.Navigate().Refresh();

            var putsboxMail = new GenerateTestMail(_driver);


            putsboxMail.OpenResetLink();

            string newTab = _driver.WindowHandles.Last();
            _driver.SwitchTo().Window(newTab);

            putsboxMail.ClickResetPass();

            resetPassPage.NewConfirmPass("Sepacyber2!", "Sepacyber2!");

            IWebElement continueToAccButton = _driver.FindElement(By.Id("changedButton"));
            continueToAccButton.Click();

            loginPage.EnterCredentials("micheal@putsbox.com", "Sepacyber2!");

            Assert.AreEqual("https://caibo-merchant-staging.sepa-cyber.com/en/dashboard", _driver.Url,"Login not successful");

            

        }

        [Test]

        public void LoginOldPass()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.ResetPassLink();


            var resetPassPage = new ResetPass(_driver);
            resetPassPage.EnterMail("micheal@putsbox.com");

            _driver.Navigate().GoToUrl("https://putsbox.com/micheal/inspect");
            _driver.Navigate().Refresh();

            var putsboxMail = new GenerateTestMail(_driver);


            putsboxMail.OpenResetLink();

            string newTab = _driver.WindowHandles.Last();
            _driver.SwitchTo().Window(newTab);

            putsboxMail.ClickResetPass();

            resetPassPage.NewConfirmPass("Sepacyber1@", "Sepacyber1@");

            IWebElement continueToAccButton = _driver.FindElement(By.Id("changedButton"));
            continueToAccButton.Click();

            loginPage.EnterCredentials("micheal@putsbox.com", "Sepacyber1!");

            string actualError = _driver.FindElement(By.XPath("html/body/div/div/main/div/form/div[2]/p")).Text;
            Assert.AreEqual("Incorrect email or password!", actualError,"Login with old password");

           

        }

       

        [TearDown]
        public void EndTest()
        {
            _driver.Quit();
        }
    }

    public class LoginTestsNoInbox
     {
        IWebDriver _driver;
        WebDriverWait _wait;


        [SetUp]
        public void Initialize()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            //_wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Navigate().GoToUrl("https://caibo-merchant-staging.sepa-cyber.com/en");

        }

        [Test]
        public void ValidCredentials()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.EnterCredentials("israel_mayert@putsbox.com", "Sepacyber1!");

            Assert.AreEqual("https://caibo-merchant-staging.sepa-cyber.com/en/registration", _driver.Url,"Not logged in with valid credentials");
        }

       
        [Test]
        public void SignUpLink()
        {


            var loginPage = new LoginPage(_driver);
            loginPage.SignUp();
            Assert.AreEqual("https://caibo-merchant-staging.sepa-cyber.com/en//signup", _driver.Url,"Sign up link not working");

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
        public void LogOut()
        {
            var loginPage = new LoginPage(_driver);
            var dashboard = new Dashboard(_driver);
            loginPage.EnterCredentials("israel_mayert@putsbox.com", "Sepacyber1!");
            dashboard.SignOut();

            bool header = _driver.FindElement(By.XPath("/html/body/div/div/main/div/form/header/h3")).Displayed;
            Assert.IsTrue(header);
        }

        [Test]
        public void LoginAfterLogout()
        {
            var loginPage = new LoginPage(_driver);
            var dashboard = new Dashboard(_driver);
            loginPage.EnterCredentials("israel_mayert@putsbox.com", "Sepacyber1!");
            dashboard.SignOut();

            var continueButton = _driver.FindElement(By.XPath("/html/body/div/div/main/div/form/footer/button"));
            continueButton.Click();
            string emailError = _driver.FindElement(By.Id("email-error")).Text;
            Assert.AreEqual("This field is required.", emailError);
            string passError = _driver.FindElement(By.Id("password-error")).Text;
            Assert.AreEqual("This field is required.", passError);

        }

        [Test]
        public void VerifyLoginElements()
        {
            IWebElement caiboLogo = _driver.FindElement(By.LinkText("Caibo"));
            var logoWidth = caiboLogo.Size.Width;
            var logoHeight = caiboLogo.Size.Height;
            var logoPositionX = caiboLogo.Location.X;//96
            var logoPositionY = caiboLogo.Location.Y;//35

            IWebElement header = _driver.FindElement(By.XPath("/html/body/div/div/main/div/form/header/h3"));
            var headerWidth = header.Size.Width;
            var headerHeight = header.Size.Height;
            var headerPositionX = header.Location.X;
            var headerPositionY = header.Location.Y;

            IWebElement emailField = _driver.FindElement(By.Id("email"));
            var emailWidth = emailField.Size.Width;
            var emailHeight = emailField.Size.Height;
            var emailPositionX = emailField.Location.X;
            var emailPositionY = emailField.Location.Y;

            IWebElement passField = _driver.FindElement(By.Id("password"));
            var passWidth = passField.Size.Width;
            var passHeight = passField.Size.Height;
            var passPositionX = passField.Location.X;
            var passPositionY = passField.Location.Y;

            IWebElement continueButton = _driver.FindElement(By.CssSelector("button[type = 'submit']"));
            var buttonWidth = continueButton.Size.Width;
            var buttonHeight = continueButton.Size.Height;
            var buttonPositionX = continueButton.Location.X;
            var buttonPositionY = continueButton.Location.Y;


            Assert.Multiple(() =>
            {
                Assert.IsTrue(caiboLogo.Displayed);
                Assert.AreEqual(238, logoWidth,"Element size is wrong");
                Assert.AreEqual(58, logoHeight, "Element size is wrong");
                Assert.AreEqual(96, logoPositionX,"Element position is wrong");
                Assert.AreEqual(35, logoPositionY, "Element position is wrong");

                Assert.IsTrue(header.Displayed);
                Assert.AreEqual("Login to your account", header.Text);
                Assert.AreEqual(540, headerWidth, "Element size is wrong");
                Assert.AreEqual(52, headerHeight, "Element size is wrong");
                Assert.AreEqual(690, headerPositionX, "Element position is wrong");
                Assert.AreEqual(325, headerPositionY, "Element position is wrong");

                Assert.IsTrue(emailField.Enabled);
                Assert.AreEqual(530, emailWidth, "Element size is wrong");
                Assert.AreEqual(48, emailHeight, "Element size is wrong");
                Assert.AreEqual(695, emailPositionX, "Element position is wrong");
                Assert.AreEqual(458, emailPositionY, "Element position is wrong");

                Assert.IsTrue(passField.Enabled);
                Assert.AreEqual(530, passWidth, "Element size is wrong");
                Assert.AreEqual(48, passHeight, "Element size is wrong");
                Assert.AreEqual(695, passPositionX, "Element position is wrong");
                Assert.AreEqual(568, passPositionY, "Element position is wrong");

                Assert.IsTrue(continueButton.Enabled);
                Assert.AreEqual(540, buttonWidth, "Element size is wrong");
                Assert.AreEqual(68, buttonHeight, "Element size is wrong");
                Assert.AreEqual(690, buttonPositionX, "Element position is wrong");
                Assert.AreEqual(661, buttonPositionY, "Element position is wrong");


            });
        }

        [TearDown]
        public void EndTest()
        {
            _driver.Quit();
        }
    }
}
