﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace caiboMerchant.PageObjects.CreateActivate
{
    public class BusinessRep
    {
        public BusinessRep(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);

        }
        [FindsBy(How = How.Name, Using = ("ceo[first_name]"))]
        [CacheLookup]
        IWebElement CeoFirstName;
        [FindsBy(How = How.Name, Using = ("ceo[last_name]"))]
        [CacheLookup]
        IWebElement CeoLastName;
        [FindsBy(How = How.Name, Using = ("ceo[passport_number]"))]
        [CacheLookup]
        IWebElement CeoPassportN;
        [FindsBy(How = How.Name, Using = ("ceo[dob]"))]
        [CacheLookup]
        IWebElement CeoDOB;
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-1-button']/span[2]"))]
        [CacheLookup]
        IWebElement CeoCountryDropdown;
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-1-menu']/li[212]"))]
        [CacheLookup]
        IWebElement CeoCountry;
        [FindsBy(How = How.Name, Using = ("ceo[street]"))]
        [CacheLookup]
        IWebElement CeoStreet;
        [FindsBy(How = How.Name, Using = ("ceo[city]"))]
        [CacheLookup]
        IWebElement CeoCity;
        [FindsBy(How = How.Name, Using = ("ceo[email]"))]
        [CacheLookup]
        IWebElement CeoMail;
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-2-button']/span[1]"))]
        [CacheLookup]
        IWebElement CeoCountryCodeDropdown;
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-2-menu']/li[2]"))]
        [CacheLookup]
        IWebElement CeoCountryCode;
        [FindsBy(How = How.Name, Using = ("ceo[mobile_number]"))]
        [CacheLookup]
        IWebElement CeoMobile;

        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div[1]/form/div/section[2]/div[1]/div/label/div"))]
        [CacheLookup]
        IWebElement AuthSignatory;
        [FindsBy(How = How.Name, Using = ("signatory[first_name]"))]
        [CacheLookup]
        IWebElement SignatoryFirstName;
        [FindsBy(How = How.Name, Using = ("signatory[last_name]"))]
        [CacheLookup]
        IWebElement SignatoryLastName;
        [FindsBy(How = How.Name, Using = ("signatory[passport_number]"))]
        [CacheLookup]
        IWebElement SignatoryPassportN;
        [FindsBy(How = How.Name, Using = ("signatory[dob]"))]
        [CacheLookup]
        IWebElement SignatoryDOB;
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-3-button']/span[2]"))]
        [CacheLookup]
        IWebElement SignatoryCountryDropdown;
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-507']"))]
        [CacheLookup]
        IWebElement SignatoryCountry;
        [FindsBy(How = How.Name, Using = ("signatory[street]"))]
        [CacheLookup]
        IWebElement SignatoryStreet;
        [FindsBy(How = How.Name, Using = ("signatory[city]"))]
        [CacheLookup]
        IWebElement SignatoryCity;
        [FindsBy(How = How.Name, Using = ("signatory[email]"))]
        [CacheLookup]
        IWebElement SignatoryMail;
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-4-button']/span[1]"))]
        [CacheLookup]
        IWebElement SignatoryCountryCodeDropdown;

        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-793']"))]
        [CacheLookup]
        IWebElement SignatoryCountryCode;

        [FindsBy(How = How.Name, Using = ("signatory[mobile_number]"))]
        [CacheLookup]
        IWebElement SignatoryMobile;

        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div[1]/form/div/section[3]/div[1]/div/label/div"))]
        [CacheLookup]
        IWebElement Shareholder;
        [FindsBy(How = How.Name, Using = ("shareholder_1[first_name]"))]
        [CacheLookup]
        IWebElement Shareholder1FirstName;
        [FindsBy(How = How.Name, Using = ("shareholder_1[last_name]"))]
        [CacheLookup]
        IWebElement Shareholder1LastName;
        [FindsBy(How = How.Name, Using = ("shareholder_1[passport_number]"))]
        [CacheLookup]
        IWebElement Shareholder1PassportN;
        [FindsBy(How = How.Name, Using = ("shareholder_1[dob]"))]
        [CacheLookup]
        IWebElement Shareholder1DOB;
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-3-button']/span[2]"))]
        [CacheLookup]
        IWebElement Shareholder1CountryDropdown;
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-746']"))]
        [CacheLookup]
        IWebElement Shareholder1Country;
        [FindsBy(How = How.Name, Using = ("shareholder_1[street]"))]
        [CacheLookup]
        IWebElement Shareholder1Street;
        [FindsBy(How = How.Name, Using = ("shareholder_1[city]"))]
        [CacheLookup]
        IWebElement Shareholder1City;
        [FindsBy(How = How.Name, Using = ("shareholder_1[email]"))]
        [CacheLookup]
        IWebElement Shareholder1Mail;
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-6-button']/span[1]"))]
        [CacheLookup]
        IWebElement Shareholder1CountryCodeDropdown;
        [FindsBy(How = How.XPath, Using = ("//*[@id='ui-id-793']"))]
        [CacheLookup]
        IWebElement Shareholder1CountryCode;
        [FindsBy(How = How.Name, Using = ("shareholder_1[mobile_number]"))]
        [CacheLookup]
        IWebElement Shareholder1Mobile;

        [FindsBy(How = How.XPath, Using = ("//*[@id='main']/div[1]/form/footer/button"))]
        [CacheLookup]
        IWebElement SaveButton;

        public void EnterBizRep()
        {
            CeoFirstName.SendKeys("John");
            CeoLastName.SendKeys("Doe");
            CeoPassportN.SendKeys("123345567789");
            CeoDOB.SendKeys("01011945");
            CeoCountryDropdown.Click();
            CeoCountry.Click();
            CeoStreet.SendKeys("elm st");
            CeoCity.SendKeys("varna");
            CeoMail.Clear();
            CeoMail.SendKeys("test@abv.bg");
            CeoCountryCodeDropdown.Click();
            CeoCountryCode.Click();
            CeoMobile.SendKeys("12345");
            

            // AuthSignatory.Click();           
            //  SignatoryFirstName.SendKeys("John");
            // SignatoryLastName.SendKeys("Doe");
            // SignatoryPassportN.SendKeys("123345567789");
            // SignatoryDOB.SendKeys("01011945");
            // SignatoryCountryDropdown.Click();
            // SignatoryCountry.Click();
            // SignatoryStreet.SendKeys("elm st");
            //SignatoryCity.SendKeys("varna");
            //SignatoryMail.SendKeys("test@abv.bg");
            // SignatoryCountryCodeDropdown.Click();
            // SignatoryCountryCode.Click();
            // SignatoryMobile.SendKeys("123456");

            // Shareholder.Click();
            // Shareholder1FirstName.SendKeys("John");
            // Shareholder1LastName.SendKeys("Doe");
            // Shareholder1PassportN.SendKeys("123345567789");
            // Shareholder1DOB.SendKeys("01011945");
            // Shareholder1CountryDropdown.Click();
            // Shareholder1Country.Click();
            //  Shareholder1Street.SendKeys("elm st");
            //  Shareholder1City.SendKeys("varna");
            // Shareholder1Mail.SendKeys("test@abv.bg");
            //  Shareholder1CountryCodeDropdown.Click();
            //  Shareholder1CountryCode.Click();
            //  Shareholder1Mobile.SendKeys("123456");

            SaveButton.Click();

        }
        public void EnterCeoEmail(string mail)
        {
            CeoMail.Clear();
            CeoMail.SendKeys(mail);
        }
        public void EnterPhone(string phone)
        {
            CeoCountryCodeDropdown.Click();
            CeoCountryCode.Click();
            CeoMobile.SendKeys(phone);
        }
        public void AuthSignator ()
        {
            AuthSignatory.Click();
        }
        public void DirectorFields(string firstname,string lastname,string passportN, string dob,string street,string city,string mail,string number )
        {
            CeoFirstName.SendKeys(firstname);
            CeoLastName.SendKeys(lastname);
            CeoPassportN.SendKeys(passportN);
            CeoDOB.SendKeys(dob);
            CeoCountryDropdown.Click();
            CeoCountry.Click();
            CeoStreet.SendKeys(street);
            CeoCity.SendKeys(city);
            CeoMail.Clear();
            CeoMail.SendKeys(mail);
            CeoCountryCodeDropdown.Click();
            CeoCountryCode.Click();
            CeoMobile.SendKeys(number);
            SaveButton.Click();
        }
    }
}
