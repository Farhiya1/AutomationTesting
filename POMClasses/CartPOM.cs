using E_Commerce_AutomationTesting.Support;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static E_Commerce_AutomationTesting.Support.Helpers;

namespace E_Commerce_AutomationTesting.POMClasses
{
    internal class CartPOM
    {
        private IWebDriver _driver;

        // Constructor that accepts an instance of IWebDriver
        public CartPOM(IWebDriver driver)
        {
            this._driver = driver;
        }

        //Locators to find elements for the cart link, coupon code and click the discount button.
        private IWebElement Cart => _driver.FindElement(By.LinkText("Cart"));
        private IWebElement SendCoupon => _driver.FindElement(By.Id("coupon_code"));
        private IWebElement DiscountButton => _driver.FindElement(By.ClassName("button"));
        private IWebElement SubtotalElement => _driver.FindElement(By.CssSelector("#post-5 .cart-subtotal span"));
        private IWebElement DiscountElement => _driver.FindElement(By.CssSelector("#post-5 .cart-discount span"));
        private IWebElement TotalElement => _driver.FindElement(By.CssSelector("#post-5 .order-total strong span"));
        private IWebElement ShippingElement => _driver.FindElement(By.CssSelector("#shipping_method > li > label > span"));
        private IWebElement CheckoutButtons => _driver.FindElement(By.LinkText("Proceed to checkout"));

        //Method to click on the cart link.
        public void GoToCartPage()
        {
            
            Cart.Click(); 
          
        }

        //Method to add the edgewords coupon to get a discount
  
        public void AddCoupon(string coupon)
        {
           
            SendCoupon.SendKeys(coupon);
            DiscountButton.Click();
            
        }


        // Method that extracts the discount value from a web page and returns it as a decimal for verification.
        public decimal GetSubtotal()
        {
           
            return decimal.Parse(SubtotalElement.Text.Substring(1));

        }

        // Method that extracts the discount value from a web page and returns it as a decimal for verification.
        public decimal GetDiscount()
        {
            // Wait for the discount element to be displayed before extracting the value.
            Helpers.WaitForElDisplayed(By.CssSelector("#post-5 .cart-discount span"), 10, _driver);
            return decimal.Parse(DiscountElement.Text.Substring(1));

        }

        // Method that extracts the total value from a web page and returns it as a decimal for verification.
        public decimal GetTotal()
        {
        
            return decimal.Parse(TotalElement.Text.Substring(1));
        }

        // Method that extracts the shipping fee value from a web page and returns it as a decimal for calculating the total amount.
        public decimal GetShippingFee()
        {
            
            return decimal.Parse(ShippingElement.Text.Substring(1));
        }


        // Method to navigate to the checkout page.
        public void NavigateToCheckoutPage()
        {
            CheckoutButtons.Click();
        }


    }
}

   
