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
        //Private propeties that return the 'Shop Link', 'Product' and the 'add-to-cart' button elements.
        private IWebElement Shop => _driver.FindElement(By.LinkText("Shop"));
        private IWebElement Product => _driver.FindElement(By.CssSelector("#main > ul > li.product.type-product.post-28"));
        private IWebElement addToCart => _driver.FindElement(By.Name("add-to-cart"));

        // Method that enters the shop, clicks on a product, and adds it to the cart
        public void EnterShop()
        {
            Shop.Click();
            Product.Click();
            addToCart.Click();
          
        }
    }
}
