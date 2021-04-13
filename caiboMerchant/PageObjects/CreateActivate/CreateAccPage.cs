using OpenQA.Selenium;

using SeleniumExtras.PageObjects;




namespace caiboMerchant.PageObjects.CreateActivate
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
          IWebElement Email;
        

        [FindsBy(How = How.Id, Using = "name")]
        [CacheLookup]
         IWebElement Name;

        [FindsBy(How = How.Id, Using = "company")]
        [CacheLookup]
         IWebElement Company;

        [FindsBy(How = How.Id, Using = "password")]
        [CacheLookup]
         IWebElement Password;

        [FindsBy(How = How.Id, Using = "password_confirm")]
        [CacheLookup]
         IWebElement ConfirmPassword;

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/main/div/form/footer/button")]
        [CacheLookup]
         IWebElement CreateAccButton;

        [FindsBy(How = How.LinkText, Using = "Login")]
        [CacheLookup]
         IWebElement LoginLink;

        public void CreateAccount()
        {
            Email.SendKeys(this.mail);
            Name.SendKeys("test");
            Company.SendKeys("testCompany");
            Password.SendKeys("Sepacyber1!");
            ConfirmPassword.SendKeys("Sepacyber1!");
            CreateAccButton.Click();

        }

        public void Login()
        {
            LoginLink.Click();
        }

        public void EmailField(string email)
        {
            Email.SendKeys(email);
            Name.Click();
        }
        public void PasswordField(string pass)
        {
            Password.SendKeys(pass);
            Name.Click();
        }

        public void PasswordsMatch(string pass,string confirmPass)
        {
            Password.SendKeys(pass);
            ConfirmPassword.SendKeys(confirmPass);
            Name.Click();
        }

    }
}
