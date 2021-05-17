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
        IWebElement IbanCheckBox;
        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div[1]/form/div/section/div/div[2]/div/div[1]/div[1]/div[2]/label/div"))]
        [CacheLookup]
        IWebElement AccountCheckBox;
        [FindsBy(How = How.Name, Using = ("iban_account"))]
        [CacheLookup]
        IWebElement IbanAccN;
        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div[1]/form/div/section/div/div[2]/div/div[2]/div[1]/div[1]/label/div"))]
        [CacheLookup]
        IWebElement BicCheckBox;
        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div[1]/form/div/section/div/div[2]/div/div[2]/div[1]/div[2]/label/div"))]
        [CacheLookup]
        IWebElement RoutingCheckBox;
        [FindsBy(How = How.Name, Using = ("bic_routing"))]
        [CacheLookup]
        IWebElement BicRoutingN;
        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div[1]/form/footer/button"))]
        [CacheLookup]
        IWebElement SaveButton;
        public void EnterBankDet(string ibanN,string bicN)
        {
            CurrencyDropdown.Click();
            Currency.Click();
            IbanCheckBox.Click();
            IbanAccN.SendKeys(ibanN);
            BicRoutingN.SendKeys(bicN);
            SaveButton.Click();

        }
        public void IbanCheck()
        {
            IbanCheckBox.Click();
            
        }
        public void AccNCheck()
        {
            AccountCheckBox.Click();

        }
        public void EnterIbanAcc(string value)
        {
            IbanAccN.SendKeys(value);
            SaveButton.Click();
        }
        public void EnterBicRouting(string value)
        {
            BicRoutingN.SendKeys(value);
            SaveButton.Click();

        }


    }
}
