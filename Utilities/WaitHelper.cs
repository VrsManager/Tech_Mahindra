using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.WaitHelpers;

namespace Venkat_Assignment.Utilities
{
    public static class WaitHelper
    {
        // Method to wait for an element to be visible on the page
        public static IWebElement WaitForElementVisible(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));


        }

        //Method to set implicit wait for the driver
        public static void ImplicitWait(IWebDriver driver, int timeoutInSeconds = 10)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutInSeconds);
        }

        // Method to handle alert if present
        public static void HandleAlertIfPresent(IWebDriver driver)
        {
            try
            {
                var alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
            catch (NoAlertPresentException)
            {
                // Safe to continue
            }
        }
        // Method to select an option from a dropdown by visible text
        public static void SelectDropdownByText(IWebDriver driver, By locator, string visibleText, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            var dropdownElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            var selectElement = new SelectElement(dropdownElement);
            selectElement.SelectByText(visibleText);
        }

    }
}
