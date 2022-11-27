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

        private readonly By _dropdownAccountsButton = By.XPath("//*[@id=\"ph-whiteline\"]/div/div[2]/div[2]/span[3]");
        private readonly By _addAccountButton = By.XPath("//div[text()='Добавить аккаунт']");

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
            _webDriver.FindElement(_dropdownAccountsButton).Click();
            Thread.Sleep(2000);
            _webDriver.FindElement(_addAccountButton).Click();
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
