using OpenQA.Selenium;
using E_Commerce_AutomationTesting.Support;
using System.Security.Cryptography.X509Certificates;

namespace E_Commerce_AutomationTesting.POMClasses
{
    internal class CheckoutPOM
    {
        private IWebDriver _driver;
        public CheckoutPOM(IWebDriver driver)
        {

            this._driver = driver;

        }


        //Set locators for the elements on the webpage
      
        private IWebElement BillingFirstName => _driver.FindElement(By.Id("billing_first_name"));
        private IWebElement BillingLastName => _driver.FindElement(By.Id("billing_last_name"));
        private IWebElement BillingAddress => _driver.FindElement(By.Id("billing_address_1"));
        private IWebElement BillingCity => _driver.FindElement(By.Id("billing_city"));
        private IWebElement BillingPostCode => _driver.FindElement(By.Id("billing_postcode"));
        private IWebElement BillingPhone => _driver.FindElement(By.Id("billing_phone"));
        private IWebElement chequeRadioButton => _driver.FindElement(By.CssSelector("#payment > ul > li.wc_payment_method.payment_method_cheque > div"));
        private IWebElement  PlaceOrderButton => _driver.FindElement(By.Id("place_order"));



        //Adding billing details to checkout page.
      
        public void SetFirstName(string firstName) 
        {
            BillingFirstName.Clear();
            BillingFirstName.Click();
            BillingFirstName.SendKeys(firstName);
        }
        public void SetLastName(string lastName)
        {
            BillingLastName.Clear();
            BillingLastName.Click();
            BillingLastName.SendKeys(lastName);
        }
      
        public void SetAddressLine1(string addressLine1)
        {
            BillingAddress.Clear();
            BillingAddress.Click();
            BillingAddress.SendKeys(addressLine1);
        }   
       
        public void SetBillingCity(string city)
        {
            BillingCity.Clear();
            BillingCity.Click();
            BillingCity.SendKeys(city);
        }
    
        public void SetPostcode(string postcode)
        {
            BillingPostCode.Clear();
            BillingPostCode.Click();
            BillingPostCode.SendKeys(postcode);
        }   
        public void SetPhoneNumber(string phoneNumber)
        {
            BillingPhone.Clear();
            BillingPhone.Click();
            BillingPhone.SendKeys(phoneNumber);
        }
        public void SelectChequeRadioButton()
        {
           Thread.Sleep(1000);
           
            chequeRadioButton.Click();
        }


       //Method to place order 
        public void placeOrder()
        {

            //Wait for the "place order"' element to be displayed before clicking the place order button.
            Helpers.WaitForElDisplayed(By.Id("place_order"), 10, _driver);
            PlaceOrderButton.Click();
        }

    }
}
