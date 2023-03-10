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
        private By orderNumberOnOrderPageLocator = By.CssSelector("#post-7 > div > div > div > table > tbody > tr > td.woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number");
        private IWebElement NavigateToOrdersPage => _driver.FindElement(By.CssSelector("#post-7 > div > div > nav > ul > li.woocommerce-MyAccount-navigation-link.woocommerce-MyAccount-navigation-link--orders"));

        public string OrdersPage()
        {
            //Navigate to orders page
            NavigateToOrdersPage.Click();

            // Find and extract the order number value on the 'Orders' page.
            string orderNumberOnOrderPagValue = _driver.FindElement(orderNumberOnOrderPageLocator).Text.Substring(1).Trim();

            // Output the order number value on the 'Orders' page to the console.
            Console.WriteLine($"order number value on order page is: {orderNumberOnOrderPagValue}");

            //Returns value to main test class
            return orderNumberOnOrderPagValue;

        }
    }

}
