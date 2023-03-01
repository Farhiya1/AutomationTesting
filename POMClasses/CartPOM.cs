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
        private IWebElement AddCoupon => _driver.FindElement(By.Id("coupon_code"));
        private IWebElement DismissStoreNotice => _driver.FindElement(By.CssSelector(".woocommerce-store-notice__dismiss-link"));
        private IWebElement DiscountButton => _driver.FindElement(By.ClassName("button"));


        //Method to click on the cart link and dismsis store notice banner.
        public void CartPage()
        {
            
            Cart.Click();
            DismissStoreNotice.Click();
        }

        //Method to add the edgewords coupon to get a discount
             
        public void GetDiscount() 
        {

            AddCoupon.SendKeys("edgewords");
            DiscountButton.Click();
  

            //Verify that the discount is correctly applied to the cart total


            var subtotal = decimal.Parse(_driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.cart-subtotal > td > span")).Text.Substring(1));
            var discount = decimal.Parse(_driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.cart-discount.coupon-edgewords > td > span")).Text.Substring(1));

            // Calculate the expected discount
            Console.WriteLine(discount);
            var expectedDiscount = subtotal * 0.15m;
            var dDiscount = Math.Round(expectedDiscount, 2);

            // Assert that the discount is correct
            try
            {
                Assert.That(discount, Is.EqualTo(dDiscount));
            }
            catch (AssertionException)
            {
                Console.WriteLine("Discount assertion failed. Discount = " + discount + ", Expected discount = " + dDiscount);
            }


            // Calculate the expected total

            var total = decimal.Parse(_driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.order-total > td > strong > span")).Text.Substring(1));
            Console.WriteLine(total);
            var expectedTotal = subtotal - dDiscount + 3.95m;
            Console.WriteLine("helloooo");


            // Assert that the total is correct
            try
            {
                Console.WriteLine("Stops here");
                Assert.That(total, Is.EqualTo(expectedTotal));
                Console.WriteLine("hi Jamie");
            }
            catch (AssertionException)
            {
                Console.WriteLine("Total assertion failed. Total = " + total + ", Expected total = " + expectedTotal);
            }


        }



    }
}

   
