using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace caiboMerchant.PageObjects.CreateActivate
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
        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div/form/div[2]/section[1]/div/div[3]/div/div[2]/div/div[3]/label/div"))]
        [CacheLookup]
        IWebElement OriginOtherCheckbox;
        [FindsBy(How = How.Name, Using = ("origin_other"))]
        [CacheLookup]
        IWebElement OriginOtherField;
        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div/form/div[2]/section[1]/div/div[4]/div/div/div/div[4]/label/div"))]
        [CacheLookup]
        IWebElement CurrencyOtherCheckbox;
        [FindsBy(How = How.Name, Using = ("currency_other"))]
        [CacheLookup]
        IWebElement CurrencyOtherField;
        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div/form/div[2]/section[2]/div[2]/div/div[1]/label/div"))]
        [CacheLookup]
        IWebElement ProcessedCheckboxYes;
        [FindsBy(How = How.Name, Using = ("former_processor_from"))]
        [CacheLookup]
        IWebElement ProcessedFrom;
        [FindsBy(How = How.Name, Using = ("former_processor_to"))]
        [CacheLookup]
        IWebElement ProcessedTo;

        [FindsBy(How = How.Name, Using = ("former_processor"))]
        [CacheLookup]
        IWebElement FormerProcessor;
        [FindsBy(How = How.Name, Using = ("reason_for_leaving"))]
        [CacheLookup]
        IWebElement ReasonLeaving;
        [FindsBy(How = How.Name, Using = ("other_payment_cards"))]
        [CacheLookup]
        IWebElement CardsAccepted;
        [FindsBy(How = How.Name, Using = ("other_payment_methods"))]
        [CacheLookup]
        IWebElement OtherPaymentMethods;

        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div/form/div[2]/section[3]/div[2]/div/div/div/div[4]/label/div"))]
        [CacheLookup]
        IWebElement TransactionCurrencyOther;
        [FindsBy(How = How.Name, Using = ("transaction_currency_other"))]
        [CacheLookup]
        IWebElement TransactionCurrencyField;
        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div/form/div[2]/section[3]/div[3]/div/div/div/div[4]/label/div"))]
        [CacheLookup]
        IWebElement SettlementCurrencyOther;
        [FindsBy(How = How.Name, Using = ("settlement_currency_other"))]
        [CacheLookup]
        IWebElement SettlementCurrencyField;

        [FindsBy(How = How.Name, Using = ("billing_descriptor"))]
        [CacheLookup]
        IWebElement BillingDescriptor;
        [FindsBy(How = How.Name, Using = ("city_field"))]
        [CacheLookup]
        IWebElement CityField;
        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div/form/div[2]/section[3]/div[5]/div/div/div/div[1]/label/div"))]
        [CacheLookup]
        IWebElement ThreeDSecure;

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
            OriginOtherCheckbox.Click();
            OriginOtherField.SendKeys("BGN");
            CurrencyOtherCheckbox.Click();
            CurrencyOtherField.SendKeys("BGN");
            ProcessedCheckboxYes.Click();
            ProcessedFrom.SendKeys("01011955");
            ProcessedTo.SendKeys("01011999");
            FormerProcessor.SendKeys("na");
            ReasonLeaving.SendKeys("na");
            CardsAccepted.SendKeys("na");
            OtherPaymentMethods.SendKeys("na");
            TransactionCurrencyOther.Click();
            TransactionCurrencyField.SendKeys("BGN");
            SettlementCurrencyOther.Click();
            SettlementCurrencyField.SendKeys("BGN");
            BillingDescriptor.SendKeys("pay.com");
            CityField.SendKeys("Montana");
            ThreeDSecure.Click();

            SaveButton.Click();
            

        }
    }
}
