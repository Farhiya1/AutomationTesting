using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace E_Commerce_AutomationTesting.Support
{
    [Binding]
    internal class HooksClass
    {
        public static IWebDriver driver;

        [Before]

        public void SetUp()
        {

            // Initialize the ChromeDriver or FirefoxDriver instance

            string browser = "chrome"; 
            switch (browser.ToLower())
            {
                case "firefox":
                    driver = new FirefoxDriver();
                    break;

                case "chrome":
                default:
                    driver = new ChromeDriver();
                    break;
            }

            //  Maximize the window when the browser opens
            driver.Manage().Window.Maximize();

            //Using driver to navigate to this url thats is stored in an enviroment variable.
            string url = Environment.GetEnvironmentVariable("SECRET_URL");
            Console.WriteLine(url);
            driver.Navigate().GoToUrl(url);


            //Set Timeout for WebElement Identification (Implicit wait)
           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }



        [After]

        public void TearDown()
        {

            // Quit the ChromeDriver instance
            // driver.Quit();
        }


    }
}
