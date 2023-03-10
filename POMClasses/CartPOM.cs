using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //Locators to find elements for the cart link, coupon code, dismiss the store notice banner at the footer of the page and click the discount button.
        private IWebElement Cart => _driver.FindElement(By.LinkText("Cart"));
        private IWebElement SendCoupon => _driver.FindElement(By.Id("coupon_code"));
        private IWebElement DismissStoreNotice => _driver.FindElement(By.CssSelector(".woocommerce-store-notice__dismiss-link"));
        private IWebElement DiscountButton => _driver.FindElement(By.ClassName("button"));

        private By SubtotalLocator = By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.cart-subtotal > td > span");
        private By DiscountLocator = By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.cart-discount.coupon-edgewords > td > span");
        private By TotalLocator = By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.order-total > td > strong > span");
           

        //Method to click on the cart link and dismsis store notice banner.
        public void GoToCartPage()
        {
            
            Cart.Click();
            DismissStoreNotice.Click();
        }

        //Method to add the edgewords coupon to get a discount
      
        public void AddCoupon()
        {
            
            SendCoupon.SendKeys("edgewords");
            DiscountButton.Click();
            

        }

        // Method to check if the discount is applied.
        public bool IsDiscountApplied(int discountRequested)
        {


            try
            {
                decimal subtotal = decimal.Parse(_driver.FindElement(SubtotalLocator).Text.Substring(1));
                Console.WriteLine($"The subtotal is: £{subtotal}");
                decimal discount = decimal.Parse(_driver.FindElement(DiscountLocator).Text.Substring(1));
                Console.WriteLine($"The current discounted amount is: £{discount}");
                decimal expectedDiscount = Math.Round(subtotal * discountRequested/100, 2);
                Console.WriteLine($"The expected discount amount is: £{expectedDiscount}");
                return discount == expectedDiscount;
            }
            catch (Exception)
            {
                return false;
            }

        }



        // Method to verify the total discount.
        public bool VerifyDiscountByTotal(int discountRequested)
        {
            try
            {
                decimal subtotal = decimal.Parse(_driver.FindElement(SubtotalLocator).Text.Substring(1));

                decimal discount = decimal.Parse(_driver.FindElement(DiscountLocator).Text.Substring(1));
                decimal expectedDiscount = Math.Round(subtotal * discountRequested /100, 2);
                decimal total = decimal.Parse(_driver.FindElement(TotalLocator).Text.Substring(1));
                decimal expectedTotal = subtotal - expectedDiscount + 3.95m;
                Console.WriteLine($"The total amount is: £{total}. The expected total is: £{expectedTotal}.");

                return total == expectedTotal;
            }
            catch (Exception)
            {
                return false;
            }
           
        }



    }
}

   
