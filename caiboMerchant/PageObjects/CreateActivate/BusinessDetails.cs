using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;



namespace caiboMerchant.PageObjects.CreateActivate
{
   public class BusinessDetails
    {

        public BusinessDetails(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-1-button']/span[2]"))]
        [CacheLookup]
        IWebElement CountryDropdown;
        [FindsBy(How = How.XPath, Using = ("/html/body/div/div/main/div[2]/ul/li[33]/div"))]
        [CacheLookup]
        IWebElement Country;
        [FindsBy(How = How.Name, Using = ("state"))]
        [CacheLookup]
        IWebElement State;
        [FindsBy(How = How.Name, Using = ("city"))]
        [CacheLookup]
        IWebElement City;
        [FindsBy(How = How.Name, Using = ("zip"))]
        [CacheLookup]
        IWebElement Zip;
        [FindsBy(How = How.Name, Using = ("address_1"))]
        [CacheLookup]
        IWebElement Address1;
        [FindsBy(How = How.Name, Using = ("address_2"))]
        [CacheLookup]
        IWebElement Address2;
        [FindsBy(How = How.Name, Using = ("company_name"))]
        [CacheLookup]
        IWebElement CompanyName;
        [FindsBy(How = How.Name, Using = ("website"))]
        [CacheLookup]
        IWebElement BusinessWebsite;
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-2-button']/span[2]"))]
        [CacheLookup]
        IWebElement BusinessDropdown;
        [FindsBy(How = How.XPath, Using = ("/html/body/div/div/main/div[3]/ul/li[3]/div"))] ///html/body/div/div/main/div[3]/ul/li[3]/div
        [CacheLookup]
        IWebElement BusinessType;
        [FindsBy(How = How.Name, Using = ("licenses_held"))]
        [CacheLookup]
        IWebElement License;
        [FindsBy(How = How.Name, Using = ("registration_number"))]
        [CacheLookup]
        IWebElement RegNumber;
        [FindsBy(How = How.Name, Using = ("registration_date"))]
        [CacheLookup]
        IWebElement RegDate;
        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div[1]/form/div/section[3]/div[1]/div/div[1]/label/div"))]
        [CacheLookup]
        IWebElement Bankruptcy;

        [FindsBy(How = How.Id, Using = ("bankruptcy_info"))]
        [CacheLookup]
        IWebElement BankruptcyDetails;

        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div[1]/form/div/section[4]/div[1]/div/div[1]/label/div"))]
        [CacheLookup]
        IWebElement Violation;
        [FindsBy(How = How.Name, Using = ("scheme_violation_details"))]
        [CacheLookup]
        IWebElement ViolationDetails;
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-3-button']/span[2]"))]
        [CacheLookup]
        IWebElement BusinessDescriptionDropdown;

        [FindsBy(How = How.XPath, Using = ("/html/body/div/div/main/div[4]/ul/li[20]/div"))]
        [CacheLookup]
        IWebElement BusinessDescription;
        [FindsBy(How = How.Name, Using = ("business_description"))]
        [CacheLookup]
        IWebElement BusinessInfo;
        [FindsBy(How = How.Name, Using = ("terms"))]
        [CacheLookup]
        IWebElement BillingTerms;
        [FindsBy(How = How.Name, Using = ("policy"))]
        [CacheLookup]
        IWebElement Return;
        [FindsBy(How = How.XPath, Using = ("//*[@id='duration-button']/span[2]"))]
        [CacheLookup]
        IWebElement DeliveryDropdown;
        [FindsBy(How = How.XPath, Using = ("/html/body/div/div/main/div[5]/ul/li[2]/div"))]
        [CacheLookup]
        IWebElement DeliveryTime;
        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div[1]/form/footer/button"))]
        [CacheLookup]
        IWebElement SaveButton;

        public void EnterBizAddress(string state, string city, string zip, string addess1, string address2)
        {

            CountryDropdown.Click();
            Country.Click();
            State.SendKeys(state);
            City.SendKeys(city);
            Zip.SendKeys(zip);
            Address1.SendKeys(addess1);
            Address2.SendKeys(address2);
            
        }
        public void EnterBizDetails(string website, string license, string regnumber)
        {
            BusinessWebsite.SendKeys(website);
            BusinessDropdown.Click();
            BusinessType.Click();
            License.SendKeys(license);
            RegNumber.SendKeys(regnumber);
        }

        public void EnterRegDate(string date)
        {
            RegDate.SendKeys(date); 
        }

        public void EnterBankruptcyDetails(string details)
        {
            Bankruptcy.Click();
            BankruptcyDetails.SendKeys(details);

        }

        public void EnterViolationDetails(string details)
        {
            Violation.Click();
            ViolationDetails.SendKeys(details);

        }

        public void EnterBizDescription(string info, string terms, string returns)
        {
            BusinessDescriptionDropdown.Click();
            BusinessDescription.Click();
            BusinessInfo.SendKeys(info);
            BillingTerms.SendKeys(terms);
            Return.SendKeys(returns);
            DeliveryDropdown.Click();
            DeliveryTime.Click();
        }
        public void Save()
        { 
            SaveButton.Click();
        }
        public void EnterCOMPLETEBizDetails()
        {

            CountryDropdown.Click();
            Country.Click();
            State.SendKeys("Varna");
            City.SendKeys("Varna");
            Zip.SendKeys("9000");
            Address1.SendKeys("45 st");
            BusinessWebsite.SendKeys("test.com");
            BusinessDropdown.Click();
            BusinessType.Click();
            License.SendKeys("12345678");
            RegNumber.SendKeys("12345566");
            RegDate.SendKeys("12121999");
            Bankruptcy.Click();
            BankruptcyDetails.SendKeys("NA");
            Violation.Click();
            ViolationDetails.SendKeys("NA");
            BusinessDescriptionDropdown.Click();
            BusinessDescription.Click();
            BusinessInfo.SendKeys("NA");
            BillingTerms.SendKeys("NA");
            Return.SendKeys("NA");
            DeliveryDropdown.Click();
            DeliveryTime.Click();
            SaveButton.Click();
        }
    }
}
