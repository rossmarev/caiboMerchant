using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace caiboMerchant.PageObjects
{
    public class ProcessingInfo
    {
        public ProcessingInfo(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = ("est_no_monthly_transactions"))]
        [CacheLookup]
        IWebElement TransactionsN;
        [FindsBy(How = How.Name, Using = ("total_sales"))]
        [CacheLookup]
        IWebElement SalesVol;
        [FindsBy(How = How.Name, Using = ("avg_transaction_amount"))]
        [CacheLookup]
        IWebElement AvgAmount;
        [FindsBy(How = How.Name, Using = ("min_to_max_ticket"))]
        [CacheLookup]
        IWebElement MinMax;
        [FindsBy(How = How.Name, Using = ("monthly_chargeback"))]
        [CacheLookup]
        IWebElement Chargeback;



        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div/form/footer/button"))]
        [CacheLookup]
        IWebElement SaveButton;

        public void EnterProcessingInfo()
        {
            TransactionsN.SendKeys("100");
            SalesVol.SendKeys("100000");
            AvgAmount.SendKeys("50");
            MinMax.SendKeys("10-500");
            Chargeback.SendKeys("2000");

            SaveButton.Click();
            

        }
    }
}
