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
       private  IList<IWebElement> ProductElementLocator => _driver.FindElements(By.CssSelector("#main > ul > li.product"));
        private IWebElement addToCart => _driver.FindElement(By.Name("add-to-cart"));


        // Method that enters the shop, selects a random product, and adds it to the cart
        public void AddItemToCart()
        {
            //Clicking on shop link
            Shop.Click();

            // Get all the product elements on the page using the ProductElementLocator
            
            var productElements = ProductElementLocator;

            // Select a random product 
            var randomIndex = new Random().Next(0, ProductElementLocator.Count);
            var productElement = productElements[randomIndex];

            // Extract the product name from the product element text
            string productName = productElement.Text;

            // Determine the index of the pound sign and "SALE!" text in the product name
            int poundIndex = productName.IndexOf('£');
            int saleIndex = productName.IndexOf("SALE!");
            // If the "SALE!" text appears before the pound sign, extract the text before "SALE!"
            if (saleIndex >= 0 && saleIndex < poundIndex)
            {
                productName = productName.Substring(0, saleIndex).Trim();
            }
            else
            // If the pound sign appears in the product name, extract the text before the pound sign
            {

                productName = poundIndex >= 0 ? productName.Substring(0, poundIndex).Trim() : productName;
            }
            // Print the selected product name
            Console.WriteLine("The product selected is: " + productName);

            // Click the random product element and take a screenshot
            productElement.Click();
            Helpers.TakeScreenshot(_driver, "productpicture.png");
            // Add the selected product to the cart
            addToCart.Click();
            

        }
    }
}
