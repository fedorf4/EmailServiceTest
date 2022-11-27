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
        private readonly By _addressToInput = By.XPath("//div[@data-type='to']");
        private readonly By _subjectInput = By.XPath("//input[@name='Subject']");
        private readonly By _emailEditor = By.XPath("//div[@role='textbox']");

        public MainPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MainPageObject StartComposeEmail()
        {
            _webDriver.FindElement(_composeEmailButton).Click();
            return this;
        }

        public MainPageObject EnterAddressTo(string address)
        {
            _webDriver.FindElement(_addressToInput).SendKeys(address);
            return this;
        }

        public MainPageObject EnterSubject(string subject)
        {
            _webDriver.FindElement(_subjectInput).SendKeys(subject);
            return this;
        }

        public MainPageObject EnterEmailText(string text)
        {
            _webDriver.FindElement(_emailEditor).SendKeys(text);
            return this;
        }

    }
}
