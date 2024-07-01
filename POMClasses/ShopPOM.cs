using E_Commerce_AutomationTesting.Support;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static E_Commerce_AutomationTesting.Support.Helpers;

namespace E_Commerce_AutomationTesting.POMClasses
{

    internal class ShopPOM
    {
        private IWebDriver _driver;

        // Constructor that accepts an instance of IWebDriver
        public ShopPOM(IWebDriver driver)

        {
            this._driver = driver;
        }


        //Set locators for elements on the webpage.

        //Private propeties that return the 'Shop Link', 'Products' and the 'add-to-cart' button elements.
        private IWebElement Shop => _driver.FindElement(By.LinkText("Shop"));
        private IList<IWebElement> ProductElementLocator => _driver.FindElements(By.CssSelector("#main > ul > li.product"));

        // private IWebElement Product => _driver.FindElement(By.CssSelector("#main > ul > li.product"));
        private IWebElement addToCart => _driver.FindElement(By.Name("add-to-cart"));


        // Method that enters the shop, selects a random product, and adds it to the cart
        public void AddItemToCart(string item)
        {
            //Clicking on shop link
            Shop.Click();


            // Get all the product elements on the page
            var productElements = ProductElementLocator;

            // Find the product element that matches the specified item
            var productElement = productElements.FirstOrDefault(element => element.Text.Contains(item));

            // Check if the product element is found
            if (productElement != null)
            {
                // Click the product element to add it to the cart
                productElement.Click();

                // Add the selected product to the cart
                addToCart.Click();
            }
            else
            {
                // Handle the case when the specified item is not found
                throw new NotFoundException($"Item '{item}' not found on the shop page.");
            }

           
            addToCart.Click();


        }
    }
}
