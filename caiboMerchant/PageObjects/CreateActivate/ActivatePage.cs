using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace caiboMerchant.PageObjects.CreateActivate
{
   public class ActivatePage
    {
        public ActivatePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);

        }
        [FindsBy(How = How.XPath, Using = "/html/body/div/div/header/div[3]/ul/li[1]/a")]
        [CacheLookup]
        IWebElement FAQlink;
        [FindsBy(How = How.Id, Using = ("link-profile"))]
        [CacheLookup]
        IWebElement ProfileButton;
        [FindsBy(How = How.LinkText, Using = ("Profile"))]
        [CacheLookup]
        IWebElement ProfileLink;
        [FindsBy(How = How.LinkText, Using = ("Sign out"))]
        [CacheLookup]
        IWebElement SignOutButton;
        [FindsBy(How = How.LinkText, Using = ("Activate your Caibo account"))]
        [CacheLookup]
        IWebElement ActivateLink;
        [FindsBy(How = How.LinkText, Using = ("Get your test API keys"))]
        [CacheLookup]
        IWebElement TestAPI;
        [FindsBy(How = How.LinkText, Using = ("Get your live API keys"))]
        [CacheLookup]
        IWebElement LiveAPI;
        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div/div/button"))]
        [CacheLookup]
        IWebElement StartNowButton;
        [FindsBy(How = How.Id, Using = ("name"))]
        [CacheLookup]
        IWebElement FullName;
        [FindsBy(How = How.CssSelector, Using = ("button[type = 'submit']"))]
        [CacheLookup]
        IWebElement UpdateProfileButton;
        [FindsBy(How = How.Id, Using = ("password"))]
        [CacheLookup]
        IWebElement Password;
        [FindsBy(How = How.Id, Using = ("password_confirm"))]
        [CacheLookup]
        IWebElement ConfirmPass;
        [FindsBy(How = How.CssSelector, Using = ("button[type = 'submit']"))]
        [CacheLookup]
        IWebElement NewPassButton;

        public void SignOut()
        {
            ProfileButton.Click();
            SignOutButton.Click();

        }
        public void FAQ()
        {
            FAQlink.Click();

        }

        public void Profile()
        {
            ProfileButton.Click();
        }

        public void TestApi()
        {
            TestAPI.Click();
        }
        public void LiveApi()
        {
            LiveAPI.Click();
        }

        public void ActivateAccount()
        {
            StartNowButton.Click();
        }
    }
}
