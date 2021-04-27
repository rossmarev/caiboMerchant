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
   public class CreateAccTests
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

            //business details
            var businessDetails = new BusinessDetails(_driver);
            businessDetails.EnterCOMPLETEBizDetails();


            //representatives
            var businessRep = new BusinessRep(_driver);
            businessRep.EnterBizRep();

            //bank details
            var bankDet = new BankDetails(_driver);
            bankDet.EnterBankDet();

            //processing info
            var processInfo = new ProcessingInfo(_driver);
            processInfo.EnterProcessingInfo();

            //risk management
            var riskManage = new RiskManagement(_driver);
            riskManage.EnterRiskManagement();

            //supporting docs
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
            businessDetails.EnterCOMPLETEBizDetails();


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

                signUpPage.PasswordField("!");
                passIndicator = _driver.FindElement(By.Id("pwindicator")).Text;
                bool passError1 = _driver.FindElement(By.Id("password-error")).Displayed;
                Assert.AreEqual("strong", passIndicator);
                Assert.IsFalse(passError1);

                signUpPage.PasswordField("@");
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
            signUpPage.PasswordsMatch("Sepacyber1!", "Sepacyber1!");
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
        public void SignUpValidDataPass8char()
        {
            _driver.Navigate().GoToUrl("https://putsbox.com/");

            var putsbox = new GenerateTestMail(_driver);
            var testMail = putsbox.CopyMail();

            _driver.Navigate().GoToUrl("https://caibo-merchant-staging.sepa-cyber.com/en//signup");
            var signUpPage = new CreateAccPage(_driver, testMail);
            signUpPage.CreateAccount("test", "testCompany", "SepaCT1!", "SepaCT1!");
            var verifyMailMessage = _driver.FindElement(By.XPath("/html/body/div/div/main/div/form/header/h5")).Text;
            Assert.AreEqual("Verify your email", verifyMailMessage);

        }

        [Test]
        public void SignUpMissingData()
        {
            var testMail = "";
            var signUpPage = new CreateAccPage(_driver, testMail);
            signUpPage.CreateAccount("", "", "", "");
            bool emailError = _driver.FindElement(By.Id("email-error")).Displayed;
            bool nameError = _driver.FindElement(By.Id("name-error")).Displayed;
            bool companyError = _driver.FindElement(By.Id("company-error")).Displayed;
            bool passError = _driver.FindElement(By.Id("password-error")).Displayed;

            Assert.Multiple(() =>
            {             
                Assert.IsTrue(emailError,"mail");
                Assert.IsTrue(nameError,"name");
                Assert.IsTrue(companyError,"comp");
                Assert.IsTrue(passError,"pass");
            });

        }


        [Test]
        public void SignUpWrongEmailFormat()
        {
            var testMail = "wrongEmailFormatasd";
            var signUpPage = new CreateAccPage(_driver, testMail);
            signUpPage.CreateAccount("test", "testCompany", "Sepacyber1!", "Sepacyber1!");
            var error = _driver.FindElement(By.CssSelector("small[id = 'email-error']")).Text;
            Assert.AreEqual("Please enter a valid email address.", error);
        }

        [Test]
        public void SignUpInvalidPass()
        {
            var testMail = "test@gmail.com";
            var signUpPage = new CreateAccPage(_driver, testMail);
            signUpPage.CreateAccount("test", "testCompany", "sepacyber", "sepacyber");
            var error = _driver.FindElement(By.CssSelector("small[id = 'password-error']")).Text;
            Assert.AreEqual("Password must include at least 8 characters, including numbers, uppercase, lowercase and special character.", error);
        }

        [Test]
        public void SignUpInvalidPassUpper()
        {
            var testMail = "test@gmail.com";
            var signUpPage = new CreateAccPage(_driver, testMail);
            signUpPage.CreateAccount("test", "testCompany", "Sepacyber", "Sepacyber");
            var error = _driver.FindElement(By.CssSelector("small[id = 'password-error']")).Text;
            Assert.AreEqual("Password must include at least 8 characters, including numbers, uppercase, lowercase and special character.", error);
        }


        [Test]
        public void SignUpInvalidPassNumber()
        {
            var testMail = "test@gmail.com";
            var signUpPage = new CreateAccPage(_driver, testMail);
            signUpPage.CreateAccount("test", "testCompany", "sepacyber1", "sepacyber1");
            var error = _driver.FindElement(By.CssSelector("small[id = 'password-error']")).Text;
            Assert.AreEqual("Password must include at least 8 characters, including numbers, uppercase, lowercase and special character.", error);
        }
        [Test]
        public void SignUpInvalidPassSchar()
        {
            var testMail = "test@gmail.com";
            var signUpPage = new CreateAccPage(_driver, testMail);
            signUpPage.CreateAccount("test", "testCompany", "sepacyber!", "sepacyber!");
            var error = _driver.FindElement(By.CssSelector("small[id = 'password-error']")).Text;
            Assert.AreEqual("Password must include at least 8 characters, including numbers, uppercase, lowercase and special character.", error);
        }
        [Test]
        public void SignUpInvalidPassLess8()
        {
            var testMail = "test@gmail.com";
            var signUpPage = new CreateAccPage(_driver, testMail);
            signUpPage.CreateAccount("test", "testCompany", "Sepa1!", "Sepa1!");
            var error = _driver.FindElement(By.CssSelector("small[id = 'password-error']")).Text;
            Assert.AreEqual("Password must include at least 8 characters, including numbers, uppercase, lowercase and special character.", error);
        }

       

        [Test]
        public void SignUpMismatchingPass()
        {
            var testMail = "test@gmail.com";
            var signUpPage = new CreateAccPage(_driver, testMail);
            signUpPage.CreateAccount("test", "testCompany", "Sepacyber1!", "Sepacyber1@");
            var error = _driver.FindElement(By.CssSelector("small[id = 'password_confirm-error']")).Text;
            Assert.AreEqual("Please enter the same value again.", error);


        }


        [Test]
        public void VerifyConfirmMail()
        {
            _driver.Navigate().GoToUrl("https://putsbox.com/");

            var putsbox = new GenerateTestMail(_driver);
            var testMail = putsbox.CopyMail();

            _driver.Navigate().GoToUrl("https://caibo-merchant-staging.sepa-cyber.com/en//signup");
            var signUpPage = new CreateAccPage(_driver, testMail);
            signUpPage.CreateAccount("test", "testCompany", "Sepacyber1!", "Sepacyber1!");

            _driver.Navigate().GoToUrl("https://putsbox.com/");

            putsbox.OpenInbox();
            putsbox.OpenMail();

            bool confirmMail = _driver.FindElement(By.XPath("/html/body/div/div[1]/div/table/tbody/tr[1]/td[2]")).Displayed;
            Assert.IsTrue(confirmMail);
        }

        [Test]
        public void VerifyResendConfirmMail()
        {
            _driver.Navigate().GoToUrl("https://putsbox.com/");

            var putsbox = new GenerateTestMail(_driver);
            var testMail = putsbox.CopyMail();

            _driver.Navigate().GoToUrl("https://caibo-merchant-staging.sepa-cyber.com/en//signup");
            var signUpPage = new CreateAccPage(_driver, testMail);
            signUpPage.CreateAccount("test", "testCompany", "Sepacyber1!", "Sepacyber1!");


            //Clcik on resend button, assert 2nd mail is delivered - to be completed when the issue with resend button is resolved
        }

        [Test]
        public void VerifyConfirmMailButton()
        {
            _driver.Navigate().GoToUrl("https://putsbox.com/");

            var putsbox = new GenerateTestMail(_driver);
            var testMail = putsbox.CopyMail();

            _driver.Navigate().GoToUrl("https://caibo-merchant-staging.sepa-cyber.com/en//signup");
            var signUpPage = new CreateAccPage(_driver, testMail);
            signUpPage.CreateAccount("test", "testCompany", "Sepacyber1!", "Sepacyber1!");
           
            _driver.Navigate().GoToUrl("https://putsbox.com/");        

            putsbox.OpenInbox();
            putsbox.OpenMail();

            string newTab = _driver.WindowHandles.Last();
            _driver.SwitchTo().Window(newTab);
            IWebElement confirmMail = _wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Confirm email address")));
            confirmMail.Click();

           
            bool activateAccountHeader = _driver.FindElement(By.XPath("//*[@id='main']/div/div/h4")).Displayed;
            Assert.IsTrue(activateAccountHeader);
        }


        [Test]
        public void VerifySignUpElements()
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

            IWebElement nameField = _driver.FindElement(By.Id("name"));
            var nameWidth = nameField.Size.Width;
            var nameHeight = nameField.Size.Height;
            var namePositionX = nameField.Location.X;
            var namePositionY = nameField.Location.Y;

            IWebElement companyField = _driver.FindElement(By.Id("company"));
            var companyWidth = companyField.Size.Width;
            var companyHeight = companyField.Size.Height;
            var companyPositionX = companyField.Location.X;
            var companyPositionY = companyField.Location.Y;

            IWebElement passField = _driver.FindElement(By.Id("password"));
            var passWidth = passField.Size.Width;
            var passHeight = passField.Size.Height;
            var passPositionX = passField.Location.X;
            var passPositionY = passField.Location.Y;

            IWebElement passConfirmField = _driver.FindElement(By.Id("password_confirm"));
            var passConfirmWidth = passConfirmField.Size.Width;
            var passConfirmHeight = passConfirmField.Size.Height;
            var passConfirmPositionX = passConfirmField.Location.X;
            var passConfirmPositionY = passConfirmField.Location.Y;

            IWebElement continueButton = _driver.FindElement(By.CssSelector("button[type = 'submit']"));
            var buttonWidth = continueButton.Size.Width;
            var buttonHeight = continueButton.Size.Height;
            var buttonPositionX = continueButton.Location.X;
            var buttonPositionY = continueButton.Location.Y;


            Assert.Multiple(() =>
            {
                Assert.IsTrue(caiboLogo.Displayed);
                Assert.AreEqual(238, logoWidth, "Element size is wrong");
                Assert.AreEqual(58, logoHeight, "Element size is wrong");
                Assert.AreEqual(95, logoPositionX, "Element position is wrong");
                Assert.AreEqual(35, logoPositionY, "Element position is wrong");

                Assert.IsTrue(header.Displayed);
                Assert.AreEqual("Create an account", header.Text);
                Assert.AreEqual(540, headerWidth, "Element size is wrong");
                Assert.AreEqual(52, headerHeight, "Element size is wrong");
                Assert.AreEqual(682, headerPositionX, "Element position is wrong");
                Assert.AreEqual(195, headerPositionY, "Element position is wrong");

                Assert.IsTrue(emailField.Enabled);
                Assert.AreEqual(530, emailWidth, "Element size is wrong");
                Assert.AreEqual(48, emailHeight, "Element size is wrong");
                Assert.AreEqual(686, emailPositionX, "Element position is wrong");
                Assert.AreEqual(328, emailPositionY, "Element position is wrong");

                Assert.IsTrue(nameField.Enabled);
                Assert.AreEqual(530, nameWidth, "Element size is wrong");
                Assert.AreEqual(48, nameHeight, "Element size is wrong");
                Assert.AreEqual(686, namePositionX, "Element position is wrong");
                Assert.AreEqual(438, namePositionY, "Element position is wrong");

                Assert.IsTrue(companyField.Enabled);
                Assert.AreEqual(530, companyWidth, "Element size is wrong");
                Assert.AreEqual(48, companyHeight, "Element size is wrong");
                Assert.AreEqual(686, companyPositionX, "Element position is wrong");
                Assert.AreEqual(548, companyPositionY, "Element position is wrong");
              
                Assert.IsTrue(passField.Enabled);
                Assert.AreEqual(530, passWidth, "Element size is wrong");
                Assert.AreEqual(48, passHeight, "Element size is wrong");
                Assert.AreEqual(686, passPositionX, "Element position is wrong");
                Assert.AreEqual(658, passPositionY, "Element position is wrong");

                Assert.IsTrue(passConfirmField.Enabled);
                Assert.AreEqual(530, passConfirmWidth, "Element size is wrong");
                Assert.AreEqual(48, passConfirmHeight, "Element size is wrong");
                Assert.AreEqual(686, passConfirmPositionX, "Element position is wrong");
                Assert.AreEqual(768, passConfirmPositionY, "Element position is wrong");

                Assert.IsTrue(continueButton.Enabled);
                Assert.AreEqual(540, buttonWidth, "Element size is wrong");
                Assert.AreEqual(68, buttonHeight, "Element size is wrong");
                Assert.AreEqual(682, buttonPositionX, "Element position is wrong");
                Assert.AreEqual(861, buttonPositionY, "Element position is wrong");


            });
        }
        [TearDown]
        public void EndTest()
        {
            _driver.Close();
            _driver.Quit();
            
        }

    }
}
