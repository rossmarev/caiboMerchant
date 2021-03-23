using SeleniumExtras.PageObjects;
using OpenQA.Selenium;


namespace caiboMerchant.PageObjects
{
    public class GenerateTestMail
    {
        public GenerateTestMail(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "/html/body/div/div[1]/div/div/header/form/button")] 
        public IWebElement NewMail;

        [FindsBy(How = How.Id, Using = "putsbox-token-input")]
        public  IWebElement GetNewMail;


        public string  CopyMail()
        {
           NewMail.Click();
           var testMail = GetNewMail.GetAttribute("value");
           return testMail;
        }
        
    }
}


