using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;


namespace caiboMerchant.PageObjects
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
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-36']"))]
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
        [FindsBy(How = How.Name, Using = ("website"))]
        [CacheLookup]
        IWebElement BusinessWebsite;
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-2-button']/span[2]"))]
        [CacheLookup]
        IWebElement BusinessDropdown;
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-246']"))]
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

        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-258']"))]
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
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-1459']"))]
        [CacheLookup]
        IWebElement DeliveryTime;
        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div[1]/form/footer/button"))]
        [CacheLookup]
        IWebElement SaveButton;

        public void EnterBizDetails()
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
