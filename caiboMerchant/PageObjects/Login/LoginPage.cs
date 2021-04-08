using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace caiboMerchant.PageObjects.Login
{
  public  class LoginPage
    {
        public LoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = ("email"))]
        [CacheLookup]
        IWebElement Email;
        [FindsBy(How = How.Id, Using = ("password"))]
        [CacheLookup]
        IWebElement Password;
        [FindsBy(How = How.XPath, Using = ("/html/body/div/div/main/div/form/footer/button"))]
        [CacheLookup]
        IWebElement ContinueButton;
        [FindsBy(How = How.XPath, Using = ("/html/body/div/div/header/div[2]/a"))]
        [CacheLookup]
        IWebElement SignUpLink;
        [FindsBy(How = How.XPath, Using = ("/html/body/div/div/main/div/form/div/div[2]/label/a"))]
        [CacheLookup]
        IWebElement ForgotPassLink;

        [FindsBy(How = How.LinkText, Using =("Caibo"))]
        [CacheLookup]
        public IWebElement CaiboLogo;


        public void SignUp()
        {
            SignUpLink.Click();
        }

        public void EnterCredentials(string email,string pass)      
        {
            Email.SendKeys(email);
            Password.SendKeys(pass);
            ContinueButton.Click();
        }
        
        public void ResetPassLink()
        {
            ForgotPassLink.Click();
        }

       


    }
}
