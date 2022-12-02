using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace EmailServiceTest.Extensions
{
    internal static class WebElenetInteractionsExtensions
    {

        public static void NavigateAndClick(this IWebElement element, IWebDriver webDriver)
        {
            new Actions(webDriver)
                .MoveToElement(element)
                .Click()
                .Perform();
            Thread.Sleep(1600);
        }
    }
}
