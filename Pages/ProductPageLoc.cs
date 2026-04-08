using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Venkat_Assignment.Pages
{
    public class ProductPageLoc
    {
        // This class serves as a repository for all the locators related to the product page of the application.
        public readonly IWebDriver driver;

        public ProductPageLoc(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement ProductLink => driver.FindElement(By.LinkText("Products"));

        public IWebElement ProductDropDown => driver.FindElement(By.XPath("//nav//span[contains(text(),'Products')]"));
       
        public By dotTestLink => By.XPath("//a//span[contains(text(),'dotTEST')]");

        public By RequestDemo => By.XPath("//a[contains(text(),'Request a Demo')]");

        public IWebElement EmailTextField => driver.FindElement(By.Name("email"));
        
        public IWebElement FirstNameTextField => driver.FindElement(By.XPath("//input[@name='firstname']"));
        public IWebElement LastNameTextField => driver.FindElement(By.XPath("//input[@name='lastname']"));
        public IWebElement CompanyTextField => driver.FindElement(By.XPath("//input[@name='company']"));
        public IWebElement JobTitleTextField => driver.FindElement(By.XPath("//input[@name='jobtitle']"));
        public IWebElement PhoneTextField => driver.FindElement(By.XPath("//input[@name='phone']"));
        public By CountryDropDown => By.XPath("//select[@name='country']");
        public IWebElement RequestDemoButton =>driver.FindElement(By.XPath("//input[@value='REQUEST DEMO']"));

        public By ThankYouText => By.XPath("//h2[contains(text(),'Thank You!')]");
        
        

    }
}
