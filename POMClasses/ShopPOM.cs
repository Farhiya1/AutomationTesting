using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private By ProductElementLocator = By.CssSelector("#main > ul > li.product");
        private IWebElement addToCart => _driver.FindElement(By.Name("add-to-cart"));


        // Method that enters the shop, selects a random product, and adds it to the cart
        public void AddItemToCart()
        {

            Shop.Click();

            // Get all the product elements on the page using the ProductElementLocator
            var productElements = _driver.FindElements(ProductElementLocator);

            // Select a random product 
            var randomIndex = new Random().Next(0, productElements.Count);
            var productElement = productElements[randomIndex];

            // Click the random product element and add it to the cart
            productElement.Click();
            addToCart.Click();

        }
    }
}
