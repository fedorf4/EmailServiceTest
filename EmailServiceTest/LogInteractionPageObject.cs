using OpenQA.Selenium;

namespace EmailServiceTest
{
    internal class LogInteractionPageObject
    {
        private readonly IWebDriver _webDriver;

        private static readonly By _todayLogsList = By.XPath(".//div[@data-test-id='day-0']");

        public LogInteractionPageObject(IWebDriver webDriver)
            => _webDriver = webDriver;

        public IEnumerable<string> GetLogsRowBodies(string bodySubstring)
        {
            var todayLogs = _webDriver.FindElement(_todayLogsList);

            var suitableLogs = todayLogs.FindElements(By.XPath($".//small[contains(text(), '{bodySubstring}')]"));

            return suitableLogs.Select(i => i.Text);
        }
    }
}