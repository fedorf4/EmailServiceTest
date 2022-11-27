using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServiceTest
{
    internal class AuthorizationPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _loginInput = By.XPath("//input[@name='username']");
        private readonly By _toEnterPasswordButton = By.XPath("//button[@data-test-id='next-button']");
        private readonly By _passwordInput = By.XPath("//input[@name='password']");
        private readonly By _signInButton = By.XPath("//button[@data-test-id='submit-button']");

        public AuthorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void Authorize(string login, string password)
        {
            Thread.Sleep(2000);
            _webDriver.FindElement(_loginInput).SendKeys(login);
            Thread.Sleep(2000);
            _webDriver.FindElement(_toEnterPasswordButton).Click();
            Thread.Sleep(2000);
            _webDriver.FindElement(_passwordInput).SendKeys(password);
            Thread.Sleep(2000);
            _webDriver.FindElement(_signInButton).Click();
        }
    }
}
