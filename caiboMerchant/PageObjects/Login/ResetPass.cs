using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace caiboMerchant.PageObjects.Login
{
    public class ResetPass
    {
        public ResetPass(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Name, Using = ("login_email"))]
        [CacheLookup]
        IWebElement Email;

        [FindsBy(How = How.XPath, Using = ("/html/body/div/div/main/div/form/footer/button"))]
        [CacheLookup]
        IWebElement ContinueButton;

        [FindsBy(How = How.LinkText, Using = ("resend"))]
        [CacheLookup]
        IWebElement ResendButton;

        [FindsBy(How = How.Name, Using = ("password"))]
        [CacheLookup]
        IWebElement NewPass;

        [FindsBy(How = How.Name, Using = ("repeat_password"))]
        [CacheLookup]
        IWebElement ConfirmPass;

        [FindsBy(How = How.XPath, Using = ("/html/body/div/div/main/div/form/footer/button"))]
        [CacheLookup]
        IWebElement ConfirmButton;




        public void EnterMail(string mail)
        {
            Email.SendKeys(mail);
            ContinueButton.Click();
        }

        public void ResendMailButton()
        {
           
           ResendButton.Click();
           
        }
        public void NewConfirmPass(string pass, string confirmPass)
        {
            NewPass.SendKeys(pass);
            ConfirmPass.SendKeys(confirmPass);
            ConfirmButton.Click();
        }

        
    }
}

