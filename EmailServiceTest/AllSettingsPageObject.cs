using EmailServiceTest.Extensions;
using OpenQA.Selenium;

namespace EmailServiceTest
{
    internal class AllSettingsPageObject
    {
        private readonly IWebDriver _webDriver;

        public AllSettingsPageObject(IWebDriver webDriver)
            => _webDriver = webDriver;

        public LogInteractionPageObject GoToLogInteractions()
        {
            _webDriver.FindElement(LeftSideBar.LogInteraction)
                .NavigateAndClick(_webDriver);

            return new LogInteractionPageObject(_webDriver);
        }

        public static class LeftSideBar
        {
            public static By LogInteraction = By.XPath(".//span[text()='Лог действий']//ancestor::p");
        }

    }
}