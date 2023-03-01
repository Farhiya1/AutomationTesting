using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;

namespace E_Commerce_AutomationTesting.Utils
{
    public class TestBaseClass
    {
        public IWebDriver driver;


        [SetUp]

        public void setup()
        {
           // Access Chrome driver or Firefox driver

           //driver = new FirefoxDriver();
            driver = new ChromeDriver();
          //When broswer open, screen is maximised
            driver.Manage().Window.Maximize();
         
          //Using driver to navigate to this url
            string url = Environment.GetEnvironmentVariable("SECRET_URL");
            Console.WriteLine(url);
            driver.Navigate().GoToUrl(url);

          
           //Set Timeout for WebElement Identification (Imlicit wait)
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

          
        }
      

        [TearDown]

        public void teardown()
        {


        //Quits Browser
          // driver.Quit();


        }
    }
}
