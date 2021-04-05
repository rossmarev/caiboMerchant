using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace caiboMerchant.PageObjects.CreateActivate
{
    public class BankDetails
    { 
        public BankDetails(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.Name, Using = ("company_name"))]
        [CacheLookup]
        IWebElement CompanyName;
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-1-button']/span[2]"))]
        [CacheLookup]
        IWebElement CurrencyDropdown;
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-4']"))]
        [CacheLookup]
        IWebElement Currency;
        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div[1]/form/div/section/div/div[2]/div/div[1]/div[1]/div[1]/label/div"))]
        [CacheLookup]
        IWebElement Iban;
        [FindsBy(How = How.Name, Using = ("iban_account"))]
        [CacheLookup]
        IWebElement IbanN;
        [FindsBy(How = How.Name, Using = ("bic_routing"))]
        [CacheLookup]
        IWebElement Bic;
        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div[1]/form/footer/button"))]
        [CacheLookup]
        IWebElement SaveButton;
        public void EnterBankDet()
        {
            CurrencyDropdown.Click();
            Currency.Click();
            Iban.Click();
            IbanN.SendKeys("1234123123");
            Bic.SendKeys("BIC");
            SaveButton.Click();

        }
    }
}
