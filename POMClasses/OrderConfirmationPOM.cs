using E_Commerce_AutomationTesting.Support;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.Extensions;
using System.Drawing.Imaging;
using Microsoft.VisualBasic;
using static E_Commerce_AutomationTesting.Support.Helpers;


namespace E_Commerce_AutomationTesting.POMClasses
{
    internal class OrderConfirmationPOM
    {
        private IWebDriver _driver;
        
        public OrderConfirmationPOM(IWebDriver _driver)
        {
            this._driver = _driver;
        }


        private IWebElement orderNumberLocator => _driver.FindElement(By.CssSelector("#post-6 ul > li.woocommerce-order-overview__order.order")); 
        private IWebElement MyAccountPage => _driver.FindElement(By.LinkText("My account"));
       

        //Methods to get the order number
        public string ConfirmOrderNumber()
           
        {

            // Find and extract the order number value from the order confirmation message.  
          
            Helpers.WaitForElDisplayed(By.CssSelector("#post-6 ul > li.woocommerce-order-overview__order.order"), 5, _driver);

            string orderNumberValue = orderNumberLocator.Text.Substring(13).Trim();
           // Helpers.TakeScreenshot(_driver, "confirmordernumber.png");
         
            // Output the order number value to the console.
            Console.WriteLine($"order number value is: {orderNumberValue}");
           

            // Navigate to the 'My Account' page.

            MyAccountPage.Click();

            return orderNumberValue;
           

        }

    }
}
