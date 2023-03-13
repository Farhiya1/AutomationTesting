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


        // Navigate to the 'My Account' page.
        
     

        private IWebElement Account => _driver.FindElement(By.LinkText("My account"));
        private IWebElement LogOutConfirmation => _driver.FindElement(By.CssSelector("#post-7 > div > div > div > div > div > a"));
        public void LogoutPage()
        {
          
            Account.Click();
            //Logout
            _driver.Url = "https://www.edgewordstraining.co.uk/demo-site/my-account/customer-logout/?_wpnonce=866c96d7d3";
            //  Logout confirmation.
            LogOutConfirmation.Click();

        }
    }
}
