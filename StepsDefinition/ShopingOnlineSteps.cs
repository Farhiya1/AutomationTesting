
using System;
using TechTalk.SpecFlow;
using E_Commerce_AutomationTesting.POMClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using static E_Commerce_AutomationTesting.Support.HooksClass;

namespace E_ommerce_AutomationTesting.StepsDefinition
 {

 [Binding]
public class ShoppingOnlineSteps 

{
     //  private readonly ScenarioContext _scenarioContext;
        //private IWebDriver driver;
       

        public ShoppingOnlineSteps(ScenarioContext scenarioContext) 
        {
            //  _scenarioContext = scenarioContext;
            // _scenarioContext = scenarioContext;
            
         

        }


        [Given(@"I am logged in to my account")]
        public void GivenIAmLoggedInToMyAccount()
        {
           // _scenarioContext.Pending();

            LoginPOM loginToAccount = new LoginPOM(driver);
            loginToAccount.Login();

        }

        [When(@"I add an item to my cart")]
        public void WhenIAddAnItemToMyCart()
        {
            //  _scenarioContext.Pending();
            ShopPOM EnterTheShop = new ShopPOM(driver);
            EnterTheShop.AddItemToCart();
        }

        [When(@"I apply the discount coupon edgewords")]
        public void WhenIApplyTheDiscountCouponEdgewords()
        {
            //  _scenarioContext.Pending();
            CartPOM cart = new CartPOM(driver);
            cart.GoToCartPage();
            // Add the edgewords coupon to the cart.

            // CartPOM addDiscount = new CartPOM(driver);
            cart.AddCoupon();
            

            // Check if the discount is applied.
            //Assert.IsTrue(cart.IsDiscountApplied());
           // Assert.IsTrue(cart.VerifyDiscountByTotal());
        }

        //[Then(@"I should see a discount applied to my cart total")]
        //public void ThenIShouldSeeADiscountAppliedToMyCartTotal()
        //{


        [Then(@"I should see a (.*)% discount applied to my cart total")]
        public void ThenIShouldSeeADiscountAppliedToMyCartTotal(int p0)
        {
            //_scenarioContext.Pending();
            CartPOM cart = new CartPOM(driver);

            
           Assert.IsTrue(cart.IsDiscountApplied(p0));
           Assert.IsTrue(cart.VerifyDiscountByTotal(p0));

        }

        [When(@"I proceed to checkout")]
        public void WhenIProceedToCheckout()
        {
            // _scenarioContext.Pending();

            CartPOM addToCart = new CartPOM(driver);
            addToCart.GoToCartPage();


            CheckoutPOM checksout = new CheckoutPOM(driver);
           // checksout.NavigateToCheckoutPage();

            bool alreadyselected = checksout.NavigateToCheckoutPage();
            if (alreadyselected)
            {
                Console.WriteLine("The cheque radio button was already selected.");
            }

            Assert.That(alreadyselected, Is.True, "cheque radio button was already selected");

           
        }

        [Then(@"I should see my order number on the confirmation page")]
        public void ThenIShouldSeeMyOrderNumberOnTheConfirmationPage()
        {

            CheckoutPOM placingorder = new CheckoutPOM(driver);
            placingorder.placeOrder();
            //_scenarioContext.Pending();
            // Create an instance of CheckOrderNumberPOM class and check the order number on the confirmation page.
            OrderConfirmationPOM orderChecker = new OrderConfirmationPOM(driver);
            //orderChecker.OrderCheck();

            OrdersPOM orders = new OrdersPOM(driver);
            // orders.OrdersPage();

            string orderNumberValue = orderChecker.OrderCheck();
            string orderNumberOnOrderPagValue = orders.OrdersPage();


            //Assert if two order number values are equal.
            Assert.That(orderNumberOnOrderPagValue, Is.EqualTo(orderNumberValue));


            // Compare the two order number values and output the result to the console.
            if (orderNumberOnOrderPagValue == orderNumberValue)
            {
                Console.WriteLine("Order numbers match");
            }

        }

        [Then(@"I should be able to logout")]
        public void ThenIShouldBeAbleToLogout()
        {
            // _scenarioContext.Pending();
            LogoutPOM logsout = new LogoutPOM(driver);
            logsout.LogoutPage();
        }
    }
}