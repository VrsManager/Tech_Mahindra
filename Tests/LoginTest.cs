using FluentAssertions;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Venkat_Assignment.Pages;
using Venkat_Assignment.Utilities;
using Venkat_Assignment.TestData;

namespace Venkat_Assignment.Tests
{
    public class LoginTest : BaseClassUtils

    {
        // This method reads user login data from a JSON file 
        public static IEnumerable<UserData> GetUsers()
        {
            var json = File.ReadAllText("TestData/Users.json");
            return JsonConvert.DeserializeObject<List<UserData>>(json) ?? new List<UserData>();
        }
        [Test, TestCaseSource(nameof(GetUsers))]
        //Covering Positive and Negative scenarios of Login
        public void UserLoginTest(UserData user)
        {

            var loginPage = new LoginPageActions(new LoginPageLocators(driver));

            loginPage.Login( user);

            if (user.IsValid)
            { 
                   string message = loginPage.SuccessfulLogin();
                   Assert.AreEqual("Welcome", message);
            }
            else if (!user.IsValid)
            {   
                string message=loginPage.UnSuccessfulLogin();
                Console.WriteLine("Login Failed :"+ message);
                

            }
        }

        
    }
}
