using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace caiboMerchant.PageObjects
{
   public class RiskManagement
    {
        public RiskManagement(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Name, Using = ("questionnaire[0][website]"))]
        [CacheLookup]
        IWebElement Website1;
        [FindsBy(How = How.XPath, Using = ("//*[@id='questionnaire[0][industry]-button']/span[2]"))]
        [CacheLookup]
        IWebElement IndustryDropdown1;
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-820']"))]
        [CacheLookup]
        IWebElement Industry1;
        [FindsBy(How = How.Name, Using = ("questionnaire[0][description]"))]
        [CacheLookup]
        IWebElement Description1;
        [FindsBy(How = How.Name, Using = ("questionnaire[0][domain_ownership]"))]
        [CacheLookup]
        IWebElement Domain1;
        [FindsBy(How = How.Name, Using = ("questionnaire[0][login_user]"))]
        [CacheLookup]
        IWebElement Username1;
        [FindsBy(How = How.Name, Using = ("questionnaire[0][login_password]"))]
        [CacheLookup]
        IWebElement Password1;
        [FindsBy(How = How.XPath, Using = ("//*[@id='questionnaire-default']/section/div[1]/div[4]/div/div/div[1]/label/div"))]
        [CacheLookup]
        IWebElement VipCustomer1;
        [FindsBy(How = How.XPath, Using = ("//*[@id='questionnaire-default']/section/div[1]/div[5]/div/div/div[1]/label/div"))]
        [CacheLookup]
        IWebElement SeparateCustomer1;
        [FindsBy(How = How.XPath, Using = ("//*[@id='questionnaire-default']/section/div[1]/div[6]/div/div/div[1]/label/div"))]
        [CacheLookup]
        IWebElement FraudPrevention1;
        [FindsBy(How = How.Name, Using = ("questionnaire[0][fraud_prevention_detail]"))]
        [CacheLookup]
        IWebElement FraudDescription1;
        [FindsBy(How = How.XPath, Using = ("//*[@id='questionnaire-default']/section/div[3]/div/div/div[1]/label/div"))]
        [CacheLookup]
        IWebElement Preauthorization1;
        [FindsBy(How = How.XPath, Using = ("//*[@id='questionnaire-default']/section/div[4]/div/div/div[1]/label/div"))]
        [CacheLookup]
        IWebElement CustomerSupport1;
        [FindsBy(How = How.XPath, Using = ("//*[@id='questionnaire-default']/section/div[5]/div/div/div[1]/label/div"))]
        [CacheLookup]
        IWebElement Affiliates1;
        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div[1]/form/footer/button"))]
        [CacheLookup]
        IWebElement SaveButton1;
        [FindsBy(How = How.XPath, Using = ("//*[@id='shareholder_2_button']"))]
        [CacheLookup]
        IWebElement AddWebsite2;
        [FindsBy(How = How.XPath, Using = ("//*[@id='questionnaire-4']/a"))]
        [CacheLookup]
        IWebElement RemoveWebsite2;

        public void EnterRiskManagement()
        {
            Website1.SendKeys("testtech.com");
            IndustryDropdown1.Click();
            Industry1.Click();
            Description1.SendKeys("test");
            Domain1.SendKeys("na");
            Username1.SendKeys("test");
            Password1.SendKeys("pass");
            VipCustomer1.Click();
            SeparateCustomer1.Click();
            FraudPrevention1.Click();
            FraudDescription1.SendKeys("na");
            Preauthorization1.Click();
            CustomerSupport1.Click();
            Affiliates1.Click();
           // AddWebsite2.Click();
           // RemoveWebsite2.Click();
            SaveButton1.Click();

        }
    }
}
