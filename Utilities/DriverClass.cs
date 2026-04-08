using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Venkat_Assignment.Utilities
{
    public static class DriverClass
    {
        // This method creates and returns a new instance of the Chrome WebDriver with specified options.
        public static IWebDriver CreateDriver ()
        {
            var options= new ChromeOptions();
            options.AddArgument("--start--maximized");
            return new ChromeDriver(options);   
        }

    }
}
