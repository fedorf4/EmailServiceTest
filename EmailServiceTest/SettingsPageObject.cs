using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServiceTest
{
    internal class SettingsPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _signatureButton = By.XPath("//a[@href='/settings/general#signature']");
        private readonly By _addSignatureButton = By.XPath("//button[@data-test-id='create']");
        private readonly By _senderNameInput = By.XPath("//input[@data-test-id='name_input']");
        private readonly By _signatureInput = By.XPath("//div[@role='textbox']");
        private readonly By _saveSignatureButton = By.XPath("//button[@data-test-id='save']");
        private readonly By _removeSignatureButton = By.XPath("//button[@data-test-id='remove']");
        private readonly By _deleteSignatureButton = By.XPath("//button[@data-test-id='delete']");

        public SettingsPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SettingsPageObject OpenSiganturesSettings()
        {
            _webDriver.SwitchTo().Window(_webDriver.WindowHandles[1]);
            WaitHelper.WaitElement(_webDriver, _signatureButton);
            _webDriver.FindElement(_signatureButton).Click();
            return this;
        }

        public SettingsPageObject AddSignature(string senderName, string signature)
        {
            WaitHelper.WaitElement(_webDriver, _addSignatureButton);
            _webDriver.FindElement(_addSignatureButton).Click();
            WaitHelper.WaitElement(_webDriver, _senderNameInput);
            _webDriver.FindElement(_senderNameInput).SendKeys(senderName);
            _webDriver.FindElement(_signatureInput).SendKeys(signature);
            var webElements = _webDriver.FindElements(_saveSignatureButton);
            _webDriver.FindElements(_saveSignatureButton)[1].Click();
            return this;
        } 

        public SettingsPageObject DeleteSignature()
        {
            WaitHelper.WaitElement(_webDriver, _removeSignatureButton);
            _webDriver.FindElements(_removeSignatureButton)[1].Click();
            WaitHelper.WaitElement(_webDriver, _deleteSignatureButton);
            _webDriver.FindElement(_deleteSignatureButton).Click();
            return this;
        }
    }
}
