using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Venkat_Assignment.Pages
{
    public class LoginPageLocators
    {
        public readonly IWebDriver driver;
        public LoginPageLocators(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Locators for the login page elements
        public IWebElement UsernameField => driver.FindElement(By.XPath("//input[@name='username']"));
        public IWebElement PasswordField
        {
            get { return driver.FindElement(By.XPath("//input[@name='password']")); }
        }
        public IWebElement LoginButton => driver.FindElement(By.XPath("//input[@value='Log In' or @type='submit']"));

        public By ErrorMessageForWrongUser => By.XPath("//div[@id='rightPanel']//p[contains(text(),'The username and password could not be verified.')]");

        public By WelcomeMessage => By.XPath("//p[@class='smallText']//b[contains(text(),'Welcome')]");

        public By ErrorMessageLoginForNullLogin=> By.XPath("//p[@class='error' and contains(text(),'Please enter a username')]");

    }
}
