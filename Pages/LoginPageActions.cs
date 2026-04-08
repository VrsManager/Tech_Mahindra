using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Venkat_Assignment.TestData;
using Venkat_Assignment.Utilities;

namespace Venkat_Assignment.Pages

{
    public class LoginPageActions

    {
        private readonly LoginPageLocators loginPageLocators ;
        private  readonly IWebDriver driver;
        public LoginPageActions(LoginPageLocators loginPageLocators)
        {
            this.loginPageLocators = loginPageLocators;
            this.driver = loginPageLocators.driver;
        }

        // Method to perform login action
        public void Login(UserData user)
        {
            loginPageLocators.UsernameField.Clear();
            loginPageLocators.UsernameField.SendKeys(user.Username);
            loginPageLocators.PasswordField.Clear();
            loginPageLocators.PasswordField.SendKeys(user.Password);
            loginPageLocators.LoginButton.Click();
        }

        // Method to verify successful login by checking for the presence of a welcome message
        public string SuccessfulLogin()
        {
            try
            {
                var element = WaitHelper.WaitForElementVisible(driver, loginPageLocators.WelcomeMessage, 10);
                return element.Text;
            }
            catch(WebDriverTimeoutException)
            {
                return "Login is not successful may be due to wrong credentials.";
            }
        }

        //Method to verify unsuccessful login by checking for the presence of an error message for wrong credentials
         public string UnSuccessfulLoginForWrongCredentials()
        {
            try
            {
                var errorElement = WaitHelper.WaitForElementVisible(driver, loginPageLocators.ErrorMessageForWrongUser, 10);
                return errorElement.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return "Error message for wrong credentials not found within timeout.";
            }
            catch (NoSuchElementException)
            {
                return "Error message element not present on page.";
            }

        }

        //Method to verify unsuccessful login by checking for the presence of an error message for null login
        public string UnSuccessfulLogin()
        {
            try
            {
                var element = WaitHelper.WaitForElementVisible(driver, loginPageLocators.ErrorMessageLoginForNullLogin, 10);
                return element.Text;
            }
            catch (WebDriverTimeoutException)
            {
                // fallback to wrong user error if null-login error not found
                var errorElement = WaitHelper.WaitForElementVisible(driver, loginPageLocators.ErrorMessageForWrongUser, 5);
                return errorElement.Text;
            }
            catch (NoSuchElementException)
            {
                return "No error message displayed for null login.";
            }
        }
    }
}
