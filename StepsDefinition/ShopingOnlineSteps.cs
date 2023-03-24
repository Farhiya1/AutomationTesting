
using System;
using TechTalk.SpecFlow;
using E_Commerce_AutomationTesting.POMClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
//using static E_Commerce_AutomationTesting.Support.HooksClass;
using static E_Commerce_AutomationTesting.Support.Helpers;
using E_Commerce_AutomationTesting.Support;

namespace E_ommerce_AutomationTesting.StepsDefinition
 {

    [Binding]
public class ShoppingOnlineSteps 

{
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;


        public ShoppingOnlineSteps(ScenarioContext scenarioContext) 
        {
            
             _scenarioContext = scenarioContext;
            this.driver = (IWebDriver)_scenarioContext["driver"];
               
           
        }

       // Method logs in the user to their account.

        [Given(@"I am logged in to my account")]
        public void GivenIAmLoggedInToMyAccount()
        {
            // Create an instance of LoginPOM class and log in to the account
            LoginPOM loginToAccount = new LoginPOM(driver);
            loginToAccount.Login();


        }

        //Method adds an item to the user's cart.

        [When(@"I add an item to my cart")]
        public void WhenIAddAnItemToMyCart()
        {
            // Create an instance of ShopPOM class and add an item to the cart
            ShopPOM EnterTheShop = new ShopPOM(driver);
            EnterTheShop.AddItemToCart();
        }

        // Method applies a discount coupon to the user's cart.
        [When(@"I apply the discount coupon ""(.*)""")]
        public void WhenIApplyTheDiscountCoupon(string coupon)
        {
         
            // Create an instance of CartPOM class, navigate to the cart page and apply the edgewords coupon to the cart
            CartPOM cart = new CartPOM(driver);
            cart.GoToCartPage();
           
            cart.AddCoupon(coupon);
            
        }

        //Method verifies the discount applied to the user's cart.

        [Then(@"I should see a (.*)% discount applied to my cart total")]
        public void ThenIShouldSeeADiscountAppliedToMyCartTotal(int verifyCouponDiscount)
        {
            CartPOM cart = new CartPOM(driver);
          
            decimal subtotal = cart.GetSubtotal();
            Console.WriteLine($"The subtotal is: £{subtotal}");
            decimal discount = cart.GetDiscount();
            decimal expectedDiscount = Math.Round(subtotal * verifyCouponDiscount / 100, 2);
            Console.WriteLine($"The current discounted amount is: £{discount} and the expected discount amount is: £{expectedDiscount}");
            decimal total = cart.GetTotal();
            decimal shippingAmount = cart.GetShippingFee();
            Console.WriteLine(shippingAmount);
            decimal expectedTotal = subtotal - expectedDiscount + shippingAmount;
            Console.WriteLine($"The total amount is: £{total}. The expected total is: £{expectedTotal}.");

            //Assertions
            Assert.IsTrue(discount == expectedDiscount);
            Assert.IsTrue(total == expectedTotal);

            Helpers.TakeScreenshot(driver, "capturediscount.png");  

        }


        //Method proceeds the user to the checkout page.

        [When(@"I proceed to checkout")]
        public void WhenIProceedToCheckout()
        {
            // Create an instance of CartPOM class, navigate to the cart page.
            CartPOM addToCart = new CartPOM(driver);
            addToCart.GoToCartPage();
            CartPOM proceedToCheckout = new CartPOM(driver);
            proceedToCheckout.NavigateToCheckoutPage();
            // Create an instance of CheckoutPOM class and navigate to the checkout page.
            CheckoutPOM checksout = new CheckoutPOM(driver);
           // checksout.EnterBillingDetails();
            string firstName = TestContext.Parameters["billingFirstName "];
            string lastName = TestContext.Parameters["billingLastName"];
            string address = TestContext.Parameters["billingAddress"];
           
            string city = TestContext.Parameters["billingCity"];
        
            string postcode = TestContext.Parameters["billingPostCode"];
            string phoneNumber = TestContext.Parameters["billingPhone"];
         
            checksout.SetFirstName(firstName);
            checksout.SetLastName(lastName);
            checksout.SetAddressLine1(address);

            checksout.SetBillingCity(city);

            checksout.SetPostcode(postcode);
            checksout.SetPhoneNumber(phoneNumber);

          
            checksout.SelectChequeRadioButton();

        }

        //Method verifies the order number on the order confirmation page with the order number on the orders page.

        [Then(@"The order number shown should match the order number on orders page")]
        public void ThenTheOrderNumberShownShouldMatchTheOrderNumberOnOrdersPage()
        {
            // Create an instance of CheckoutPOM class to place an order.
            CheckoutPOM placingorder = new CheckoutPOM(driver);
            placingorder.placeOrder();

            // Create an instance of OrderConfirmationPOM and OrdersPOM classes to check the order number.
            OrderConfirmationPOM orderNumberConfirmation = new OrderConfirmationPOM(driver);
            OrdersPOM orderNumberOnOrderPage = new OrdersPOM(driver);

            // Get the order number from the order confirmation page and orders page.
            string orderNumberValue = orderNumberConfirmation.ConfirmOrderNumber();
            string orderNumberOnOrderPagValue = orderNumberOnOrderPage.OrdersPage();


            //Assert if two order number values are equal.
            Assert.That(orderNumberOnOrderPagValue, Is.EqualTo(orderNumberValue));
            
        }

    }
}