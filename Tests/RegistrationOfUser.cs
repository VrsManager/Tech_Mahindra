using System;
using System.Collections.Generic;
using System.Text;
using Venkat_Assignment.Utilities;
using Venkat_Assignment.Pages;
using NUnit.Framework;
using FluentAssertions;
using Newtonsoft.Json;
using Venkat_Assignment.TestData;


namespace Venkat_Assignment.Tests
{
    public class Registration : BaseClassUtils
    {
        // This method reads user registration data from a JSON file and
        // returns it as an enumerable collection of RegistrationUserData objects.
        public static IEnumerable<RegistrationUserData> GetUser()
        {
            var json = File.ReadAllText("TestData/RegistrationUserData.json");
            return JsonConvert.DeserializeObject<List<RegistrationUserData>>(json) ?? new List<RegistrationUserData>();
        }
        [Test, TestCaseSource(nameof(GetUser))]

        // Covering Positive and Negative scenarios of Registration of user
        public void RegistrationOfUser(RegistrationUserData user)
        {

            var registrationPage = new RegPageActions(new RegistrationPageLoc(driver));
            registrationPage.Register(user);

            if (user.IsValid)
            {
                string message=registrationPage.GetSuccessMessage();
                Assert.AreEqual("Welcome "+user.Username, message);

            }
            else {
                string message=registrationPage.GetErrorMessage();
                Assert.AreEqual("Passwords did not match.", message);
            }

        }
    }
}
