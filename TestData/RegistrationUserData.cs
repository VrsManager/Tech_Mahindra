using OpenQA.Selenium.DevTools.V143.Autofill;
using System;
using System.Collections.Generic;
using System.Text;


namespace Venkat_Assignment.TestData
{
    public class RegistrationUserData
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Address { get; set; }

        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
        public required string Phone { get; set; }
        public required string SSN { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
        public bool IsValid { get; set; }
    }
}
