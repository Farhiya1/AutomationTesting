using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_AutomationTesting.POMClasses;
using E_Commerce_AutomationTesting.Utils;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V108.Network;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace E_Commerce_AutomationTesting.TestCases
{
    [TestFixture]
    public class ShoppingOnline : Utils.TestBaseClass
    {
        // This test case searches for an item, adds it to cart, applies a discount coupon, 
        // navigates to checkout page and then logs out of the account.

        [Test, Category("Functional")]


        public void SearchItem()
        {
            // Create an instance of LoginPOM class and login to the account.
            LoginPOM loginToAccount = new LoginPOM(driver);
            loginToAccount.Login();

            // Create an instance of ShopPOM class and enter the shop page.
            ShopPOM EnterTheShop = new ShopPOM(driver);
            EnterTheShop.EnterShop();

            // Create an instance of CartPOM class and go to the cart page.
            CartPOM addToCart = new CartPOM(driver);
            addToCart.CartPage();

            // Create an instance of CartPOM class and apply a discount coupon.
            CartPOM addCoupon = new CartPOM(driver);
            addCoupon.GetDiscount();

            // Create an instance of NavigateToCheckoutPOM class and navigate to the checkout page.
            NavigateToCheckoutPOM checksout = new NavigateToCheckoutPOM(driver);
            checksout.NavigateToCheckoutPage();

            // Create an instance of LogoutPOM class and logout of the account.
            LogoutPOM logsout = new LogoutPOM(driver);
            logsout.LogoutPage();
        }




        //..........................TEST CASE 2.......................


        // This test case purchases an item by adding it to cart, navigating to checkout page and 
        // checking the order number on the order confirmation page. Then, it logs out of the account.

        [Test, Category("Functional")]
        public void PurchaseItem()
        {
            // Create an instance of LoginPOM class and login to the account.
            LoginPOM loginToAccount = new LoginPOM(driver);
            loginToAccount.Login();

            // Create an instance of ShopPOM class and enter the shop page.
            ShopPOM EnterTheShop = new ShopPOM(driver);
            EnterTheShop.EnterShop();

            // Create an instance of CartPOM class and go to the cart page.
            CartPOM addToCart = new CartPOM(driver);
            addToCart.CartPage();

            // Create an instance of NavigateToCheckoutPOM class and navigate to the checkout page.
            NavigateToCheckoutPOM checksout = new NavigateToCheckoutPOM(driver);
            checksout.NavigateToCheckoutPage();

            // Create an instance of CheckOrderNumberPOM class and check the order number on the confirmation page.
            CheckOrderNumberPOM orderChecker = new CheckOrderNumberPOM(driver);
            orderChecker.OrderCheck();

            // Create an instance of LogoutPOM class and logout of the account.
            LogoutPOM logsout = new LogoutPOM(driver);
            logsout.LogoutPage();
        } 


    }

}
