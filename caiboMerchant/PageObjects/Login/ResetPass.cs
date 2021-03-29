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

        public void EnterMail(string mail)
        {
            Email.SendKeys(mail);
            ContinueButton.Click();
        }
    }
}

