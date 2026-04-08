using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Venkat_Assignment.Pages;
using Venkat_Assignment.TestData;
using NUnit.Framework;
using Venkat_Assignment.Utilities;
using System.IO;
using System.Linq;

namespace Venkat_Assignment.Tests
{
    public class ProductEndToEndTest: BaseClassUtils
    {
        // This test case is designed to validate the end-to-end functionality of the product demo request process.
        // It reads user data from a JSON file, fills out the demo request form,
        // and verifies that the thank you message is displayed correctly.
        public static IEnumerable<ProductUserData> GetProductUser()
        {
            var json = File.ReadAllText("TestData/ProductUserData.json");
            return JsonConvert.DeserializeObject<List<ProductUserData>>(json) ?? new List<ProductUserData>();
        }
                

        [Test, TestCaseSource(nameof(GetProductUser))]
        public void ProductDemoRequest(ProductUserData ProductUser)
        {
            
            var productDemoRequestPage = new ProductPageActions(new ProductPageLoc(driver));
            productDemoRequestPage.RequestDemoForDotTest(ProductUser);

            string message = productDemoRequestPage.GetThankYouMessage();
            Assert.AreEqual("Thank You!", message);
        }

    }
}
