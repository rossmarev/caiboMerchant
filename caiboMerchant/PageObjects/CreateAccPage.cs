using OpenQA.Selenium;

using SeleniumExtras.PageObjects;




namespace caiboMerchant.PageObjects
{
   
   public class CreateAccPage
    {
        string mail;


        public CreateAccPage(IWebDriver driver, string testMail)
        {
            PageFactory.InitElements(driver, this);
            this.mail = testMail;
        }

        [FindsBy(How = How.Id, Using = "email")]
        [CacheLookup]
        public  IWebElement Email;
        

        [FindsBy(How = How.Id, Using = "name")]
        [CacheLookup]
        private IWebElement Name;

        [FindsBy(How = How.Id, Using = "company")]
        [CacheLookup]
        private IWebElement Company;

        [FindsBy(How = How.Id, Using = "password")]
        [CacheLookup]
        private IWebElement Password;

        [FindsBy(How = How.Id, Using = "password_confirm")]
        [CacheLookup]
        private IWebElement ConfirmPassword;

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/main/div/form/footer/button")]
        [CacheLookup]
        private IWebElement CreateAccButton;

        public void CreateAccount()
        {
            Email.SendKeys(this.mail);
            Name.SendKeys("test");
            Company.SendKeys("testCompany");
            Password.SendKeys("Sepacyber1!");
            ConfirmPassword.SendKeys("Sepacyber1!");
            CreateAccButton.Click();

        }


    }
}
