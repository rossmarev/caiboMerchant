using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace caiboMerchant.PageObjects.Login
{
    public class ResendMail
    {
        public ResendMail(IWebDriver driver)
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



        public void EnterMail(string mail)
        {
            Email.SendKeys(mail);
            ContinueButton.Click();
        }

        public void ResendMailButton()
        {
           
           ResendButton.Click();
        }
    }
}

