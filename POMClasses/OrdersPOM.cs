using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_AutomationTesting.POMClasses
{
    internal class OrdersPOM
    {
        private IWebDriver _driver;


        // Constructor that accepts an instance of IWebDriver
        public OrdersPOM(IWebDriver driver)
        {
            this._driver = driver;
        }

        //Locators
        private IWebElement orderNumberOnOrderPageLocator => _driver.FindElement(By.CssSelector("#post-7 .woocommerce-orders-table__cell-order-number")); 
        private IWebElement NavigateToOrdersPage => _driver.FindElement(By.CssSelector("#post-7 .woocommerce-MyAccount-navigation-link--orders"));

        //Method to return order number from order page
        public string OrdersPage()
        {
            //Navigate to orders page
            NavigateToOrdersPage.Click();

            // Find and extract the order number value on the 'Orders' page.
            string orderNumberOnOrderPagValue = orderNumberOnOrderPageLocator.Text.Substring(1).Trim();

            // Output the order number value on the 'Orders' page to the console.
            Console.WriteLine($"order number value on order page is: {orderNumberOnOrderPagValue}");

            //Returns value to main test class
            return orderNumberOnOrderPagValue;

        }
    }

}
