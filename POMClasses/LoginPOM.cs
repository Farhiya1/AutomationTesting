using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_AutomationTesting.Utils;



namespace E_Commerce_AutomationTesting.POMClasses
{

    internal class LoginPOM 
    {
        private IWebDriver _driver;
        
        // Constructor to set driver object
        public LoginPOM(IWebDriver driver) 
        { 
            this._driver = driver;
          

        }

        //Set locators for elements on the webpage.

      
        public IWebElement Account => _driver.FindElement(By.LinkText("My account"));

        // Enter the username and password into the login form and submit it
        public IWebElement Username => _driver.FindElement(By.Id("username"));
        public IWebElement Password => _driver.FindElement(By.Id("password"));

        // Login button sumbitted
        public IWebElement LoginEnter => _driver.FindElement(By.Name("login"));

        //Login Method
        public void Login()
        {

          
    
            Account.Click();
            // Get the username and password from environment variables
            string username = Environment.GetEnvironmentVariable("SECRET_USERNAME");
            string password = Environment.GetEnvironmentVariable("SECRET_PASSWORD");
            // Print the username and password to the console (for debugging purposes)
            Console.WriteLine("Username set via env var is: " + username);
            Console.WriteLine("Passwords set via env var is: " + password);

            Username.SendKeys(username);
            Password.SendKeys(password);
            LoginEnter.Click();

        }

    }
}
