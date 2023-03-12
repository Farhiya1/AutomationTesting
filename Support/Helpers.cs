using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Security.Policy;

namespace E_Commerce_AutomationTesting.Support
{
    public class Helpers
    {
       

        public static void TakeScreenshot(IWebDriver driver, string screenshotname)
        {

            ITakesScreenshot screenShotBug = driver as ITakesScreenshot;
            Screenshot screenshotForm = screenShotBug.GetScreenshot();
            screenshotForm.SaveAsFile(@"C:\Users\FarhiyaMahamud\Documents\ScreenShots\" + screenshotname, ScreenshotImageFormat.Png);
            TestContext.WriteLine("Screenshot - can be viewed in the report");
            TestContext.AddTestAttachment(@"C:\Users\FarhiyaMahamud\Documents\ScreenShots\" + screenshotname);
        }



    }
}
