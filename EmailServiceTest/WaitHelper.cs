using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServiceTest
{
    internal static class WaitHelper
    {
        public static void WaitElement(IWebDriver webDriver, By locator, int seconds = 10)
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds))
                .Until(ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
