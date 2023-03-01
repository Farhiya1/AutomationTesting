using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_AutomationTesting.POMClasses
{
    internal class NavigateToCheckoutPOM
    {
        private IWebDriver _driver;
        public NavigateToCheckoutPOM(IWebDriver driver) 
        {
          
            this._driver = driver;

        }


        //Set locators for the elements on the webpage
        private IWebElement CheckoutButtons => _driver.FindElement(By.LinkText("Proceed to checkout"));
        private IWebElement BillingFirstName => _driver.FindElement(By.Id("billing_first_name"));
        private IWebElement BillingLastName => _driver.FindElement(By.Id("billing_last_name"));
        private IWebElement BillingAddress => _driver.FindElement(By.Id("billing_address_1"));
        private IWebElement BillingCity => _driver.FindElement(By.Id("billing_city"));
        private IWebElement BillingPostCode => _driver.FindElement(By.Id("billing_postcode"));
        private IWebElement BillingPhone => _driver.FindElement(By.Id("billing_phone"));


        public void NavigateToCheckoutPage()
        {
            //_driver.FindElement(By.CssSelector("body > p > a")).Click();
            //Thread.Sleep(1000);
            CheckoutButtons.Click();


            //First checking if fields are empty then sending values to the page for billing information. 
            // Ids are stored in a list and a for loop is used to check all the fields to see if it's empty, and if it'sn't, it gets cleared.
            List<string> fieldIds = new List<string>() { "billing_first_name", "billing_last_name", "billing_address_1", "billing_city", "billing_postcode", "billing_phone" };

             foreach (string fieldId in fieldIds){
                IWebElement field = _driver.FindElement(By.Id(fieldId));
            if (!string.IsNullOrEmpty(field.GetAttribute("value")))
            {
                field.Clear();
            }
        }


        // New details are sent to Billing details input fields.
         BillingFirstName.SendKeys("nono");
         BillingLastName.SendKeys("haha");
         BillingAddress.SendKeys("Plough Lane");
         BillingCity.SendKeys("London");
         BillingPostCode.SendKeys("SW17 0BL");
         BillingPhone.SendKeys("02085473336");


            //Check if payment method is selected 
            IWebElement chequeRadioButton = _driver.FindElement(By.Id("payment_method_cheque"));

            if (!chequeRadioButton.Selected)
            {
                Console.WriteLine("NOT SELECTED");
                chequeRadioButton.Click();
            }
            else
            {
                Console.WriteLine("ALREADY SELECTED :)");
            }

            
        }






    }
}
