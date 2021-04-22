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
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-1-menu']/li[225]"))]
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
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-2-menu']/li[4]"))] 
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
        IWebElement BankruptcyYes;
        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div[1]/form/div/section[3]/div[1]/div/div[2]/label/div"))]
        [CacheLookup]
        IWebElement BankruptcyNo;

        [FindsBy(How = How.Id, Using = ("bankruptcy_info"))]
        [CacheLookup]
        IWebElement BankruptcyDetails;

        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div[1]/form/div/section[4]/div[1]/div/div[1]/label/div"))]
        [CacheLookup]
        IWebElement ViolationYes;
        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div[1]/form/div/section[4]/div[1]/div/div[2]/label/div"))]
        [CacheLookup]
        IWebElement ViolationNo;
        [FindsBy(How = How.Name, Using = ("scheme_violation_details"))]
        [CacheLookup]
        IWebElement ViolationDetails;
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-3-button']/span[2]"))]
        [CacheLookup]
        IWebElement BusinessDescriptionDropdown;

        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-3-menu']/li[5]"))]
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
        [FindsBy(How = How.XPath, Using = ("//*[@id='duration-menu']/li[3]"))] 
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
            BankruptcyYes.Click();
            BankruptcyDetails.SendKeys(details);

        }

        public void EnterViolationDetails(string details)
        {
            ViolationYes.Click();
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
            BankruptcyYes.Click();
            BankruptcyDetails.SendKeys("NA");
            ViolationYes.Click();
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
        public void EnterClearedBizDetails()
        {

            CountryDropdown.Click();
            Country.Click();
            State.Clear();
            State.SendKeys("Varna");
            City.Clear();
            City.SendKeys("Varna");
            Zip.Clear();
            Zip.SendKeys("9000");
            Address1.Clear();
            Address1.SendKeys("45 st");
            BusinessWebsite.Clear();
            BusinessWebsite.SendKeys("test.com");
            BusinessDropdown.Click();
            BusinessType.Click();
            License.Clear();
            License.SendKeys("12345678");
            RegNumber.Clear();
            RegNumber.SendKeys("12345566");
            RegDate.Clear();
            RegDate.SendKeys("12121999");
            BankruptcyNo.Click();
            BankruptcyYes.Click();
            BankruptcyDetails.Clear();
            BankruptcyDetails.SendKeys("NA");

            ViolationNo.Click();
            ViolationYes.Click();
            ViolationDetails.Clear();
            ViolationDetails.SendKeys("NA");
            BusinessDescriptionDropdown.Click();
            BusinessDescription.Click();
            BusinessInfo.Clear();
            BusinessInfo.SendKeys("NA");
            BillingTerms.Clear();
            BillingTerms.SendKeys("NA");
            Return.Clear();
            Return.SendKeys("NA");
            DeliveryDropdown.Click();
            DeliveryTime.Click();
            SaveButton.Click();

        }
        public void ClearBizDetails()
        {

            CountryDropdown.Click();
            Country.Click();
            State.Clear();
            City.Clear();
            Zip.Clear();
            Address1.Clear();
            BusinessWebsite.Clear();
            BusinessDropdown.Click();
            BusinessType.Click();
            License.Clear();
            RegNumber.Clear();
            RegDate.Clear();
            BankruptcyNo.Click();

            ViolationNo.Click();
            BusinessDescriptionDropdown.Click();
            BusinessDescription.Click();
            BusinessInfo.Clear();
            BillingTerms.Clear();
            Return.Clear();
            DeliveryDropdown.Click();
            DeliveryTime.Click();

        }
    }
}
