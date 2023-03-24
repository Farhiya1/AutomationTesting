using E_Commerce_AutomationTesting.POMClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using System.Reflection;

namespace E_Commerce_AutomationTesting.Support
{
    [Binding]
    public class HooksClass
    {
        private  IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
       

        public HooksClass(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Before]

        public void SetUp()
        {
           
            // Initialize the ChromeDriver or FirefoxDriver instance
            string browser = Environment.GetEnvironmentVariable("BROWSER_TYPE");

            if(string.IsNullOrEmpty(browser))
            {
                browser = "chrome";
            }
            // string browser = "chrome"; 
            switch (browser.ToLower())
            {
                case "firefox":
                    _driver = new FirefoxDriver();
                    break;

                case "chrome":
                default:
                    _driver = new ChromeDriver();
                    break;
            }


            //  Maximize the window when the browser opens
           _driver.Manage().Window.Maximize();

            //Using driver via scenario context
            _scenarioContext["driver"] = _driver;
            //Using driver to navigate to this url thats is stored in an enviroment variable.
            string url = Environment.GetEnvironmentVariable("SECRET_URL" );
            if(!string.IsNullOrEmpty( url ) )
            {
                Console.WriteLine("Website url is: " + url);
                _driver.Navigate().GoToUrl(url);

            }
            else
            {
                Console.WriteLine("URL is null or empty");
            }

            try
            {
                IWebElement dismissButton = _driver.FindElement(By.CssSelector(".woocommerce-store-notice__dismiss-link"));
                dismissButton.Click();
                Console.WriteLine("REMOVED STORE NOTICE BANNER");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Store notice not present, continue.");
            }

            


        }



        [After]

        public void TearDown()
        {

            //Clearing all items from the cart 
            CartPOM cart = new CartPOM(_driver);
            cart.GoToCartPage();
            IReadOnlyCollection<IWebElement> removeButtons = _driver.FindElements(By.ClassName("remove"));
            foreach (IWebElement removeButton in removeButtons)
            {
                IWebElement currentRemoveButton = _driver.FindElement(By.ClassName("remove"));

                // Click the current "Remove" button
                currentRemoveButton.Click();
                Console.WriteLine("item removed");

            }

            //Logout
            LogoutPOM logsout = new LogoutPOM(_driver);
            logsout.LogoutPage();

            // Quit the ChromeDriver instance
           _driver.Quit();
        }


    }
}
