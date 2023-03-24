using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_AutomationTesting.POMClasses
{
    internal class LogoutPOM
    {
        private IWebDriver _driver;

        public LogoutPOM (IWebDriver driver)
        {
           this._driver = driver;
        }


        // Navigate to the 'My Account' page, and log out.
        
        private IWebElement Account => _driver.FindElement(By.LinkText("My account"));
        private IWebElement Logout=> _driver.FindElement(By.LinkText("Logout"));
        
      
        //Logout method
        public void LogoutPage()
        {
          
           Account.Click();
           Logout.Click();
            
        }
    }
}
