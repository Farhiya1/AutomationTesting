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
          
            // Access Chrome driver or Firefox driver

           driver = new FirefoxDriver();
           // driver = new ChromeDriver();
            //When broswer open, screen is maximised
            driver.Manage().Window.Maximize();

            //Using driver to navigate to this url
            string url = Environment.GetEnvironmentVariable("SECRET_URL");
            Console.WriteLine(url);
            driver.Navigate().GoToUrl(url);


            //Set Timeout for WebElement Identification (Implicit wait)
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        //[After]

        //public void teardown()
        //{
        //    driver.Quit();
        //}

    }
}
