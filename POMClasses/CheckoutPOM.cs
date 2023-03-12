using OpenQA.Selenium;
using E_Commerce_AutomationTesting.Support;




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
        private IWebElement CheckoutButtons => _driver.FindElement(By.LinkText("Proceed to checkout"));
        private IWebElement BillingFirstName => _driver.FindElement(By.Id("billing_first_name"));
        private IWebElement BillingLastName => _driver.FindElement(By.Id("billing_last_name"));
        private IWebElement BillingAddress => _driver.FindElement(By.Id("billing_address_1"));
        private IWebElement BillingCity => _driver.FindElement(By.Id("billing_city"));
        private IWebElement BillingPostCode => _driver.FindElement(By.Id("billing_postcode"));
        private IWebElement BillingPhone => _driver.FindElement(By.Id("billing_phone"));

        List<string> fieldIds = new List<string>() { "billing_first_name", "billing_last_name", "billing_address_1", "billing_city", "billing_postcode", "billing_phone" };
        private IWebElement chequeRadioButton => _driver.FindElement(By.Id("payment_method_cheque"));
        private IWebElement  PlaceOrderButton => _driver.FindElement(By.Id("place_order"));


        //Navigate to checkout page method, complete billing details on checkout page and place order.
        public bool NavigateToCheckoutPage()
        {
          //Click on checkout button
            CheckoutButtons.Click();


            //First checking if fields are empty then sending values to the page for billing information. 
            // Ids are stored in a list and a for loop is used to check all the fields to see if it's empty, and if it'sn't, it gets cleared.
            
            foreach (string fieldId in fieldIds)
            {
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

            if (!chequeRadioButton.Selected)
            {
                Console.WriteLine("NOT SELECTED");
                chequeRadioButton.Click();
                return false;
            }
            else
            {
                Console.WriteLine("ALREADY SELECTED :)");
                return true;
            }


            
            

        }


        public void placeOrder()
        {

        

            Thread.Sleep(1000);
            // Click the 'Place Order' button.
            PlaceOrderButton.Click();
        }




    }
}
