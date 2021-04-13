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
using System.Threading;

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
            _driver.Navigate().GoToUrl("https://caibo-merchant-staging.sepa-cyber.com/en//signup");


        }

        [Test]
        public void CreateAcc()
        {
            _driver.Navigate().GoToUrl("https://putsbox.com/");

            var generateTestMail = new GenerateTestMail(_driver);
            var testMail = generateTestMail.CopyMail();



            _driver.Navigate().GoToUrl("https://caibo-merchant-staging.sepa-cyber.com/en//signup");
            var createAccPage = new CreateAccPage(_driver, testMail);
            createAccPage.CreateAccount("test","testCompany","Sepacyber1!","Sepacyber1!") ;


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

            var actualStatus = _driver.FindElement(By.XPath("//*[@id='main']/div/div/h4")).Text;
            Assert.AreEqual("Application status: Pending", actualStatus);

        }

        [Test]
        public void Activate()  //not to be used - it is 2nd part of create account - activate
        {
            _driver.Navigate().GoToUrl("https://caibo-merchant-staging.sepa-cyber.com/en");

            var email = _driver.FindElement(By.Id("email"));
            email.SendKeys("micheal@putsbox.com");
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

            var actualStatus = _driver.FindElement(By.XPath("//*[@id='main']/div/div/h4")).Text;
            Assert.AreEqual("Application status: Pending", actualStatus);
        }

        [Test]

        public void LoginLink()
        {
            var testMail = "test";//not used
            var signUpPage = new CreateAccPage(_driver,testMail);
            signUpPage.Login();
            Assert.AreEqual("https://caibo-merchant-staging.sepa-cyber.com/en", _driver.Url);
        }

       [Test]
       public void WrongEmailFormat()
        {
            var testMail = "test";//not used
            var signUpPage = new CreateAccPage(_driver, testMail);
            signUpPage.EmailField("wrongMailFormat");
            var error = _driver.FindElement(By.CssSelector("small[id = 'email-error']")).Text;
            Assert.AreEqual("Please enter a valid email address.", error);
        }

        [Test]
        public void ValidEmailFormat()
        {
            var testMail = "test";//not used
            var signUpPage = new CreateAccPage(_driver, testMail);
            signUpPage.EmailField("ValidMailFormat@test.com");
            bool error = _driver.FindElement(By.CssSelector("small[id = 'email-error']")).Displayed;
            Assert.IsFalse(error);
        }

        [Test]
        public void VerifyExistingEmail()
        {
            var testMail = "micheal@putsbox.com";
            var signUpPage = new CreateAccPage(_driver, testMail);
            signUpPage.CreateAccount("test", "testCompany", "Sepacyber1!", "Sepacyber1!");
            var error = _driver.FindElement(By.XPath("/html/body/div/div/main/div/form/div[2]/p")).Text;
            Assert.AreEqual("This email is already registered",error);
        }

        [Test]
        public void VerifyPasswordMasked()
        {
            var testMail = "test";//not used
            var signUpPage = new CreateAccPage(_driver, testMail);
            signUpPage.PasswordField("password");
            var passType = _driver.FindElement(By.Id("password")).GetAttribute("type");
            Assert.AreEqual("password", passType);
        }

        [Test]
        public void VerifyPassIndicator()
        {
            var testMail = "test";//not used
            var signUpPage = new CreateAccPage(_driver, testMail);
                    
            Assert.Multiple(() =>
            {
                signUpPage.PasswordField("P");
                var passIndicator = _driver.FindElement(By.Id("pwindicator")).Text;
                var passError = _driver.FindElement(By.Id("password-error")).Text;
                Assert.AreEqual("very weak", passIndicator);
                Assert.AreEqual("Password must include at least 8 characters, including numbers, uppercase, lowercase and special character.", passError);


                signUpPage.PasswordField("assword");
                passIndicator = _driver.FindElement(By.Id("pwindicator")).Text;
                passError = _driver.FindElement(By.Id("password-error")).Text;
                Assert.AreEqual("weak", passIndicator);
                Assert.AreEqual("Password must include at least 8 characters, including numbers, uppercase, lowercase and special character.", passError);

                signUpPage.PasswordField("12");
                passIndicator = _driver.FindElement(By.Id("pwindicator")).Text;
                passError = _driver.FindElement(By.Id("password-error")).Text;
                Assert.AreEqual("mediocre", passIndicator);
                Assert.AreEqual("Password must include at least 8 characters, including numbers, uppercase, lowercase and special character.", passError);

                signUpPage.PasswordField("");
                passIndicator = _driver.FindElement(By.Id("pwindicator")).Text;
                bool passError1 = _driver.FindElement(By.Id("password-error")).Displayed;
                Assert.AreEqual("strong", passIndicator);
                Assert.IsFalse(passError1);

                signUpPage.PasswordField("!@");
                passIndicator = _driver.FindElement(By.Id("pwindicator")).Text;
                passError1 = _driver.FindElement(By.Id("password-error")).Displayed;
                Assert.AreEqual("very strong", passIndicator);
                Assert.IsFalse(passError1);


            });
        }

        [Test]
        public void VerifyPassMatch()
        {
            var testMail = "test";//not used
            var signUpPage = new CreateAccPage(_driver, testMail);
            signUpPage.PasswordsMatch("Sepacyber1!", "Sepacyber1!i");
            bool mismatchError = _driver.FindElement(By.Id("password_confirm-error")).Displayed;
            Assert.IsFalse(mismatchError);
            
        }

        [Test]
        public void VerifyPassMismatch()
        {
            var testMail = "test";//not used
            var signUpPage = new CreateAccPage(_driver, testMail);
            signUpPage.PasswordsMatch("Sepacyber1!", "Sepacyber111111");
            var mismatchError = _driver.FindElement(By.Id("password_confirm-error")).Text;
            Assert.AreEqual("Please enter the same value again.",mismatchError);

        }

        [Test]
        public void SignUpValidData()
        {
            _driver.Navigate().GoToUrl("https://putsbox.com/");

            var putsbox = new GenerateTestMail(_driver);
            var testMail = putsbox.CopyMail();

            _driver.Navigate().GoToUrl("https://caibo-merchant-staging.sepa-cyber.com/en//signup");
            var signUpPage = new CreateAccPage(_driver, testMail);
            signUpPage.CreateAccount("test", "testCompany", "Sepacyber1!", "Sepacyber1!");
            var verifyMailMessage = _driver.FindElement(By.XPath("/html/body/div/div/main/div/form/header/h5")).Text;
            Assert.AreEqual("Verify your email", verifyMailMessage);

        }

        [Test]
        public void SignUpMissingData()
        {
            var testMail = "";
            var signUpPage = new CreateAccPage(_driver, testMail);
            signUpPage.CreateAccount("d", "d", "", "");
            bool emailError = _driver.FindElement(By.Id("email-error")).Displayed;
            bool nameError = _driver.FindElement(By.Id("name-error")).Displayed;
            bool companyError = _driver.FindElement(By.Id("company-error")).Displayed;
            bool passError = _driver.FindElement(By.Id("password-error")).Displayed;

            Assert.Multiple(() =>
            {             
                Assert.IsTrue(emailError,"mail");
                Assert.IsTrue(nameError,"name");
                Assert.IsTrue(companyError,"comp");
                Assert.IsTrue(passError,"pas");
            });

        }

        [TearDown]
        public void EndTest()
        {
            //driver.Quit();
        }

    }
}
