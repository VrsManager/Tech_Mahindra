using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Venkat_Assignment.Utilities
{
    public class BaseClassUtils
    {
        protected IWebDriver driver;
        [SetUp]
        // This method will run before each test method in the derived test classes
        public void Setup()
        { 
            driver = DriverClass.CreateDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/");
        }
        // This method will run after each test method in the derived test classes
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver?.Dispose();
            
        }

    }
}
