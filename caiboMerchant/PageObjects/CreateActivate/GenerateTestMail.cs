﻿using SeleniumExtras.PageObjects;
using OpenQA.Selenium;

namespace caiboMerchant.PageObjects.CreateActivate
{
    public class GenerateTestMail
    {
        
        public GenerateTestMail(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.PartialLinkText, Using = "Sign in")]
        public IWebElement SignIn;

        [FindsBy(How = How.PartialLinkText, Using = "Sign out")]
        public IWebElement SignOut;

        [FindsBy(How = How.Id, Using = "user_email")]
        public IWebElement EmailPutsbox;

        [FindsBy(How = How.Id, Using = "user_password")]
        public IWebElement Pass;

        [FindsBy(How = How.Name, Using = "commit")]
        public IWebElement SignInButton;

        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/header/form/button")]  
        public IWebElement NewMail;

        [FindsBy(How = How.Id, Using = "putsbox-token-input")]
        public  IWebElement GetNewMail;


        [FindsBy(How = How.XPath, Using = "/html/body/div/div[1]/div/div/section/div/div[2]/div/ul/li[1]/a" )] 
        public IWebElement TestMail;

        [FindsBy(How = How.PartialLinkText, Using = "HTML")]
        public IWebElement HtmlLink;

        [FindsBy(How = How.LinkText, Using = "Reset Password")]
        public IWebElement ResetPassButton;

        [FindsBy(How = How.LinkText, Using ="Clear History")]
        public IWebElement ClearHistoryButton;





        public string  CopyMail()
        {
           SignIn.Click();
           EmailPutsbox.SendKeys("r.marev.workphone@gmail.com");
            Pass.SendKeys("Sepacyber1");
            SignInButton.Click();
            NewMail.Click();
           var testMail = GetNewMail.GetAttribute("value");
           return testMail;
        }

        public void PutsboxSignIn()
        {
            SignIn.Click();
            EmailPutsbox.SendKeys("r.marev.workphone@gmail.com");
            Pass.SendKeys("Sepacyber1");
            SignInButton.Click();
        }
        
        public void OpenResetLink()
        {
            HtmlLink.Click();
        }
        public void OpenInbox()
        {
            TestMail.Click();
            
        }


        public void ClickResetPass()
        {
            
            ResetPassButton.Click();
        }

        public void ClearHistory()
        {
            ClearHistoryButton.Click();
            
        }

        public void InboxSignOut()
        {
            SignOut.Click();

        }

        public void OpenMail()
        {
            HtmlLink.Click();

        }

    }
}


