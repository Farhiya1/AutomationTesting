using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V108.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_AutomationTesting.POMClasses
{
    internal class CheckOrderNumberPOM
    {
        private IWebDriver _driver;
        
        public CheckOrderNumberPOM(IWebDriver _driver)
        {
            this._driver = _driver;
        }


        // Private property to get the 'Place Order' button element.
        private IWebElement Orders => _driver.FindElement(By.Id("place_order"));
      
        public void OrderCheck()
        {
            // Click the 'Place Order' button.
            Orders.Click();

            // Find and extract the order number value from the order confirmation message.
            IWebElement orderNumber = _driver.FindElement(By.CssSelector("#post-6 > div > div > div > ul > li.woocommerce-order-overview__order.order"));
            string orderNumberValue = orderNumber.Text.Substring(13).Trim();

            // Output the order number value to the console.
            Console.WriteLine($"order number value is: {orderNumberValue}");

            // Navigate to the 'My Account' page.
            _driver.FindElement(By.LinkText("My account")).Click();
            // Navigate to the 'Orders' tab.
            _driver.FindElement(By.CssSelector("#post-7 > div > div > nav > ul > li.woocommerce-MyAccount-navigation-link.woocommerce-MyAccount-navigation-link--orders")).Click();
            // Find and extract the order number value on the 'Orders' page.
            IWebElement orderNumberOnOrderPage = _driver.FindElement(By.CssSelector("#post-7 > div > div > div > table > tbody > tr > td.woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number"));
            string orderNumberOnOrderPagValue = orderNumberOnOrderPage.Text.Substring(1).Trim();
            // Output the order number value on the 'Orders' page to the console.
            Console.WriteLine($"order number value on order page is: {orderNumberOnOrderPagValue}");

            // Compare the two order number values and output the result to the console.
            if (orderNumberValue == orderNumberOnOrderPagValue)
            {
                Console.WriteLine("Order numbers match");
            }
            else
            {
                Console.WriteLine("Order numbers do not match");
            }
        }

    }
}
