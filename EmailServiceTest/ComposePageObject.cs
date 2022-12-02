using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace EmailServiceTest
{
    internal class ComposePageObject
    {
        private IWebDriver _webDriver;

        private readonly By _addressToInput = By.XPath("/html/body/div[1]/div/div[2]/div/div/div/div[2]/div[3]/div[2]/div/div/div[1]/div/div[2]/div/div/label/div/div/input");
        private readonly By _subjectInput = By.XPath("//input[@name='Subject']");
        private readonly By _emailEditor = By.XPath("//div[@role='textbox']");
        private readonly By _sendEmailButton = By.XPath("//span[text()='Отправить']");

        public ComposePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public ComposePageObject EnterAddressTo(string address)
        {
            WaitHelper.WaitElement(_webDriver, _addressToInput);
            _webDriver.FindElement(_addressToInput).SendKeys(address);
            return this;
        }

        public ComposePageObject EnterSubject(string subject)
        {
            _webDriver.FindElement(_subjectInput).SendKeys(subject);
            return this;
        }

        public ComposePageObject EnterEmailText(string text)
        {
            _webDriver.FindElement(_emailEditor).SendKeys(text);
            return this;
        }

        public ComposePageObject SendEmail()
        {
            _webDriver.FindElement(_sendEmailButton).Click();
            return this;
        }

        public ComposePageObject CloseSendedComposeModalWindwow()
        {
            new Actions(_webDriver)
                .SendKeys(Keys.Escape)
                .Perform();

            return this;
        }

        public bool IsEmailSent()
        {
            By sentLabel = By.XPath("//a[text()='Письмо отправлено']");
            WaitHelper.WaitElement(_webDriver, sentLabel);
            return _webDriver.FindElements(sentLabel).Any();
        }
    }
}
