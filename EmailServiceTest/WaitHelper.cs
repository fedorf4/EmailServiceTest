using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
