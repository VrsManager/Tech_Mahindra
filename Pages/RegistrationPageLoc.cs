using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Venkat_Assignment.Pages
{
    public class RegistrationPageLoc
    {
        public readonly IWebDriver driver;

        public RegistrationPageLoc(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Locators for the registration page elements
        public IWebElement RegisterLink => driver.FindElement(By.LinkText("Register"));
        public IWebElement FirstNameField => driver.FindElement(By.Id("customer.firstName"));
        public IWebElement LastNameField => driver.FindElement(By.Id("customer.lastName"));
        public IWebElement AddressField => driver.FindElement(By.Id("customer.address.street"));
        public IWebElement CityField => driver.FindElement(By.Id("customer.address.city"));
        public IWebElement StateField => driver.FindElement(By.Id("customer.address.state"));
        public IWebElement ZipCodeField => driver.FindElement(By.Id("customer.address.zipCode"));
        public IWebElement PhoneField => driver.FindElement(By.Id("customer.phoneNumber"));
        public IWebElement SSNField => driver.FindElement(By.Id("customer.ssn"));
        public IWebElement UsernameField => driver.FindElement(By.Id("customer.username"));
        public IWebElement PasswordField => driver.FindElement(By.Id("customer.password"));
        public IWebElement ConfirmPasswordField => driver.FindElement(By.Id("repeatedPassword"));
        public IWebElement RegisterButton => driver.FindElement(By.XPath("//input[@value='Register' and @type='submit']"));
        public By SuccessMessageLocator => By.XPath("//h1[@class='title' and contains(text(),'Welcome')]");
        public By ErrorMessageLocator => By.XPath("//span[@id='repeatedPassword.errors' or contains(text(),'Passwords did not match.')]");

        public By AlreadyIfUserRegistered => By.XPath("//span[@id='customer.username.errors' or contains(text(),'Username already exists.')]");

    }
}
