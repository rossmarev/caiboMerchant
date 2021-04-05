using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace caiboMerchant.PageObjects.CreateActivate
{
   public class SupportingDocs
    {
        public SupportingDocs(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = ("incorporation"))]
        [CacheLookup]
        IWebElement CertIncorp;
        [FindsBy(How = How.Name, Using = ("memorandum"))]
        [CacheLookup]
        IWebElement Memorandum;
        [FindsBy(How = How.Name, Using = ("register"))]
        [CacheLookup]
        IWebElement Register;
        [FindsBy(How = How.Name, Using = ("company_bill"))]
        [CacheLookup]
        IWebElement CompanyBill;
        [FindsBy(How = How.Name, Using = ("shareholder_bill"))]
        [CacheLookup]
        IWebElement UtilityBill;
        [FindsBy(How = How.Name, Using = ("affiliate"))]
        [CacheLookup]
        IWebElement Affiliate;
        [FindsBy(How = How.Name, Using = ("passports"))]
        [CacheLookup]
        IWebElement Passports;
        [FindsBy(How = How.Name, Using = ("license"))]
        [CacheLookup]
        IWebElement License;
        [FindsBy(How = How.Name, Using = ("owners"))]
        [CacheLookup]
        IWebElement Owners;
        [FindsBy(How = How.Name, Using = ("standing"))]
        [CacheLookup]
        IWebElement Standing;
        [FindsBy(How = How.Name, Using = ("history"))]
        [CacheLookup]
        IWebElement ProcHistory;

        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div/form/footer/button"))]
        [CacheLookup]
        IWebElement SubmitApplication;

        public void AttachDocs()
        {
            CertIncorp.SendKeys("C:\\Users\\r.marev\\Downloads\\registeringPSP.pdf");
            Memorandum.SendKeys("C:\\Users\\r.marev\\Downloads\\registeringPSP.pdf");
            Register.SendKeys("C:\\Users\\r.marev\\Downloads\\registeringPSP.pdf");
            CompanyBill.SendKeys("C:\\Users\\r.marev\\Downloads\\registeringPSP.pdf");
            UtilityBill.SendKeys("C:\\Users\\r.marev\\Downloads\\registeringPSP.pdf");
            Affiliate.SendKeys("C:\\Users\\r.marev\\Downloads\\registeringPSP.pdf");
            Passports.SendKeys("C:\\Users\\r.marev\\Downloads\\registeringPSP.pdf");
            License.SendKeys("C:\\Users\\r.marev\\Downloads\\registeringPSP.pdf");
            Owners.SendKeys("C:\\Users\\r.marev\\Downloads\\registeringPSP.pdf");
            Standing.SendKeys("C:\\Users\\r.marev\\Downloads\\registeringPSP.pdf");
            ProcHistory.SendKeys("C:\\Users\\r.marev\\Downloads\\registeringPSP.pdf");
            SubmitApplication.Click();
             
}
    }
}
