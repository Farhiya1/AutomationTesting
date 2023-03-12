using E_Commerce_AutomationTesting.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V108.Network;
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


        // Private property to get the 'Place Order' button element.
        //private IWebElement Orders => _driver.FindElement(By.Id("place_order"));
        private By orderNumberLocator = By.CssSelector("#post-6 > div > div > div > ul > li.woocommerce-order-overview__order.order");

        //private By orderNumberOnOrderPageLocator = By.CssSelector("#post-7 > div > div > div > table > tbody > tr > td.woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number");

        public string ConfirmOrderNumber()
           
        {
            Helpers.TakeScreenshot(_driver, "test2.png");


            // Find and extract the order number value from the order confirmation message.  
            string orderNumberValue =  _driver.FindElement(orderNumberLocator).Text.Substring(13).Trim();

            // Output the order number value to the console.
            Console.WriteLine($"order number value is: {orderNumberValue}");
           

            // Navigate to the 'My Account' page.
            _driver.FindElement(By.LinkText("My account")).Click();

            return orderNumberValue;
            
        }

    }
}
