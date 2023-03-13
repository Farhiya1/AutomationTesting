
using System;
using TechTalk.SpecFlow;
using E_Commerce_AutomationTesting.POMClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using static E_Commerce_AutomationTesting.Support.HooksClass;
using static E_Commerce_AutomationTesting.Support.Helpers;
using E_Commerce_AutomationTesting.Support;

namespace E_ommerce_AutomationTesting.StepsDefinition
 {

    [Binding]
public class ShoppingOnlineSteps 

{
     //  private readonly ScenarioContext _scenarioContext;
        //private IWebDriver driver;
       

        public ShoppingOnlineSteps(ScenarioContext scenarioContext) 
        {
            
            // _scenarioContext = scenarioContext;
            
         

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

        [When(@"I apply the discount coupon edgewords")]
        public void WhenIApplyTheDiscountCouponEdgewords()
        {
            // Create an instance of CartPOM class, navigate to the cart page and apply the edgewords coupon to the cart
            CartPOM cart = new CartPOM(driver);
            cart.GoToCartPage();
            cart.AddCoupon();
            
        }

        //Method verifies the discount applied to the user's cart.

        [Then(@"I should see a (.*)% discount applied to my cart total")]
        public void ThenIShouldSeeADiscountAppliedToMyCartTotal(int verifyCouponDiscount)
        {
            CartPOM cart = new CartPOM(driver);

            
           Assert.IsTrue(cart.IsDiscountApplied(verifyCouponDiscount));
           Assert.IsTrue(cart.VerifyDiscountByTotal(verifyCouponDiscount));

           Helpers.TakeScreenshot(driver, "capture-discount.png");
           

        }
        //Method proceeds the user to the checkout page.

        [When(@"I proceed to checkout")]
        public void WhenIProceedToCheckout()
        {
            // Create an instance of CartPOM class, navigate to the cart page.
            CartPOM addToCart = new CartPOM(driver);
            addToCart.GoToCartPage();
            // Create an instance of CheckoutPOM class and navigate to the checkout page.
            CheckoutPOM checksout = new CheckoutPOM(driver);
            // If the cheque radio button is already selected, print a message to the console for debugging purposes.
            bool alreadyselected = checksout.NavigateToCheckoutPage();
            if (alreadyselected)
            {
                Console.WriteLine("The cheque radio button was already selected.");
            }

            //Assert that the cheque radio button is selected.

            Assert.That(alreadyselected, Is.True, "cheque radio button was already selected");

           
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


            // Compare the two order number values and output the result to the console for debugging purpose.
            if (orderNumberOnOrderPagValue == orderNumberValue)
            {
                Console.WriteLine("Order numbers match");
            }
            
        }

        [Then(@"I should be able to logout")]
        public void ThenIShouldBeAbleToLogout()
        {
            // Create an instance of LogoutPOM class and logs user out of the account.
            LogoutPOM logsout = new LogoutPOM(driver);
            logsout.LogoutPage();
        }
    }
}