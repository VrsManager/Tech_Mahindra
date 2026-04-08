using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Venkat_Assignment.TestData;
using Venkat_Assignment.Utilities;

namespace Venkat_Assignment.Pages
{
    public class ProductPageActions
    {
        private readonly ProductPageLoc productPageLoc;
        private readonly IWebDriver driver;
        public ProductPageActions(ProductPageLoc productPageLoc)
        {
            this.productPageLoc = productPageLoc;
            this.driver = productPageLoc.driver;
        }
        // Method to request a demo for the dotTEST product by navigating through the product page,
        // filling out the demo request form,and submitting it
        public void RequestDemoForDotTest(ProductUserData user)
        {
            productPageLoc.ProductLink.Click();
            productPageLoc.ProductDropDown.Click();

            WaitHelper.WaitForElementVisible(driver, productPageLoc.dotTestLink, 5);
             driver.FindElement(productPageLoc.dotTestLink).Click();

            
            WaitHelper.WaitForElementVisible(driver, productPageLoc.RequestDemo, 5);
            driver.FindElement(productPageLoc.RequestDemo).Click();

            WaitHelper.ImplicitWait(driver, 5);
            WaitHelper.HandleAlertIfPresent(driver);

          
            productPageLoc.EmailTextField.SendKeys(user.email);
            productPageLoc.FirstNameTextField.SendKeys(user.firstName);
            productPageLoc.LastNameTextField.SendKeys(user.lastName);
            productPageLoc.CompanyTextField.SendKeys(user.company);
            productPageLoc.JobTitleTextField.SendKeys(user.jobTitle);

            Actions actions = new Actions(driver);
            actions.MoveToElement(productPageLoc.PhoneTextField).Perform();
            productPageLoc.PhoneTextField.SendKeys(user.phone);

            actions.MoveToElement(driver.FindElement(productPageLoc.CountryDropDown)).Perform();
            driver.FindElement(productPageLoc.CountryDropDown).Click();            
            WaitHelper.SelectDropdownByText(driver, productPageLoc.CountryDropDown, user.country, 10);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            actions.MoveToElement(productPageLoc.RequestDemoButton).Perform();
            var submitButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(productPageLoc.RequestDemoButton));
            submitButton.Click();

        }

        // Method to retrieve the "Thank You" message displayed after successfully submitting the demo request form
        public string GetThankYouMessage()
        {
            try
            {
                var element = WaitHelper.WaitForElementVisible(driver, productPageLoc.ThankYouText, 10);
                return element.Text;
            }
            catch (WebDriverException)
            {
                return "Thank You message not found within timeout.";
            }
        }
    }
}
