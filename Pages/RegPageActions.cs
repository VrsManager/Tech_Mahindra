using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Venkat_Assignment.TestData;
using Venkat_Assignment.Utilities;

namespace Venkat_Assignment.Pages
{
    public class RegPageActions
    {
        // This class encapsulates the actions that can be performed on the registration page of the application.
        private readonly RegistrationPageLoc registrationPageLoc;
        private readonly IWebDriver driver;
        public RegPageActions(RegistrationPageLoc registrationPageLoc)
        {
            this.registrationPageLoc = registrationPageLoc;
            this.driver = registrationPageLoc.driver; 
        }
        // Method to perform user registration by filling out the registration form and submitting it
        public void Register(RegistrationUserData user)
        {
            registrationPageLoc.RegisterLink.Click();
            registrationPageLoc.FirstNameField.SendKeys(user.FirstName);
            registrationPageLoc.LastNameField.SendKeys(user.LastName);
            registrationPageLoc.AddressField.SendKeys(user.Address);
            registrationPageLoc.CityField.SendKeys(user.City);
            registrationPageLoc.StateField.SendKeys(user.State);
            registrationPageLoc.ZipCodeField.SendKeys(user.ZipCode);
            registrationPageLoc.PhoneField.SendKeys(user.Phone);
            registrationPageLoc.SSNField.SendKeys(user.SSN);
            registrationPageLoc.UsernameField.SendKeys(user.Username);
            registrationPageLoc.PasswordField.SendKeys(user.Password);
            registrationPageLoc.ConfirmPasswordField.SendKeys(user.ConfirmPassword);
            registrationPageLoc.RegisterButton.Click();
        }

        // Method to retrieve the success message displayed after a successful registration or an error message
        // if the user is already registered
        public string GetSuccessMessage()
        {
            try
            {
                var element = WaitHelper.WaitForElementVisible(driver, registrationPageLoc.SuccessMessageLocator, 10);
                return element.Text;
            }
            catch (WebDriverException)
            {
                var errorElement = WaitHelper.WaitForElementVisible(driver, registrationPageLoc.AlreadyIfUserRegistered, 5);
                return errorElement.Text;
            }
        }
        public string GetErrorMessage()
        {
            var element = WaitHelper.WaitForElementVisible(driver, registrationPageLoc.ErrorMessageLocator, 10);
            return element.Text;
        }

    }
}