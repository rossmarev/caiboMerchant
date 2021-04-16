using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace caiboMerchant.PageObjects.MyAccount

{
   public class Dashboard
    {
        public Dashboard(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.Id, Using = ("link-profile"))]
        [CacheLookup]
        IWebElement ProfileButton;
        [FindsBy(How = How.LinkText, Using = ("Sign out"))]
        [CacheLookup]
        IWebElement SignOutButton;
       

        public void SignOut()
        {
            ProfileButton.Click();
            SignOutButton.Click();
            
        }
        

    }
}
