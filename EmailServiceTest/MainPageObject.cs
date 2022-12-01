using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace EmailServiceTest
{
    internal class MainPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _composeEmailButton = By.XPath("//a[@href='/compose/']");

        public MainPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        
        public ComposePageObject StartComposeEmail()
        {
            Thread.Sleep(5600); // need to close pop-up window
            var closeLeftUpBtns = _webDriver.FindElements(By.ClassName("ph-project-promo-close-icon__container"));
            if(closeLeftUpBtns.Any())
                closeLeftUpBtns.First().Click();

            WaitHelper.WaitElement(_webDriver, _composeEmailButton);
            _webDriver.FindElement(_composeEmailButton).Click();
            return new ComposePageObject(_webDriver);
        }

        public bool IsAuthorized(string login)
        {
            By authLabel = By.XPath("//span[text()='" + login + "']");
            WaitHelper.WaitElement(_webDriver, authLabel);
            return _webDriver.FindElements(authLabel).Any();
        }
    }
}
