using SeleniumExtras.PageObjects;
using OpenQA.Selenium;


namespace caiboMerchant.PageObjects.CreateActivate
{
    public class GenerateTestMail
    {
        public GenerateTestMail(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.PartialLinkText, Using = "Sign in")]
        public IWebElement SignIn;

        [FindsBy(How = How.Id, Using = "user_email")]
        public IWebElement EmailPutsbox;

        [FindsBy(How = How.Id, Using = "user_password")]
        public IWebElement Pass;

        [FindsBy(How = How.Name, Using = "commit")]
        public IWebElement SignInButton;

        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/header/form/button")]  
        public IWebElement NewMail;

        [FindsBy(How = How.Id, Using = "putsbox-token-input")]
        public  IWebElement GetNewMail;



      



        public string  CopyMail()
        {
           SignIn.Click();
           EmailPutsbox.SendKeys("r.marev.workphone@gmail.com");
            Pass.SendKeys("Sepacyber1");
            SignInButton.Click();
            NewMail.Click();
           var testMail = GetNewMail.GetAttribute("value");
           return testMail;
        }

        public void PutsboxSignIn()
        {
            SignIn.Click();
            EmailPutsbox.SendKeys("r.marev.workphone@gmail.com");
            Pass.SendKeys("Sepacyber1");
            SignInButton.Click();
        }
        
    }
}


