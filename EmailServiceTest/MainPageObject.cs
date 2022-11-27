using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Thread.Sleep(1000); // need to close pop-up window
            WaitHelper.WaitElement(_webDriver, _composeEmailButton);
            _webDriver.FindElement(_composeEmailButton).Click();
            return new(_webDriver);
        }

        public bool IsAuthorized(string login)
        {
            By authLabel = By.XPath("//span[text()='" + login + "']");
            WaitHelper.WaitElement(_webDriver, authLabel);
            return _webDriver.FindElements(authLabel).Any();
        }
    }
}
