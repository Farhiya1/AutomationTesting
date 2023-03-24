using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Security.Policy;
using System.Reflection;

namespace E_Commerce_AutomationTesting.Support
{
    public class Helpers
    {

        //Helper method to take screenshot for bug reporting
        public static void TakeScreenshot(IWebDriver driver, string screenshotname)
        {

            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string folderPath = Path.Combine(path, @"..\..\..\..\", "BugsScreenshots");
           // Console.WriteLine(path);
            folderPath = Path.GetFullPath(folderPath);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            ITakesScreenshot screenShotBug = driver as ITakesScreenshot;
            Screenshot screenshotForm = screenShotBug.GetScreenshot();
            string filePath = Path.Combine(folderPath, screenshotname);
            screenshotForm.SaveAsFile(filePath, ScreenshotImageFormat.Png);

            TestContext.WriteLine("Screenshot - can be viewed in the report");
            TestContext.AddTestAttachment(filePath);


        }


        //Explicit waiter method.
        public static void WaitForElDisplayed(By locator, int timeToWaitInSeconds, IWebDriver driver)
        {

            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWaitInSeconds));
            wait2.Until(drv => drv.FindElement(locator).Displayed);
        }
    }
}
