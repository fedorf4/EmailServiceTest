using EmailServiceTest.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace EmailServiceTest
{
    internal class MainPageObject
    {
        private IWebDriver _webDriver;

        private static readonly By _composeEmailButton = By.XPath("//a[@href='/compose/']");
        private static readonly By _settingsButton = By.XPath(".//span[@class='button2__wrapper']//div[@class='button2__txt' and text()='Настройки']");
        private static readonly By _allSettingsLink = By.XPath(".//a[@href='https://e.mail.ru/settings/?octaviusMode=1']");

        public MainPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public bool SendMailAndClose(string recipientEmail, string subject, string text)
        {
            var mailPageObj = StartComposeEmail()
                .EnterAddressTo(recipientEmail)
                .EnterSubject(subject)
                .EnterEmailText(text)
                .SendEmail();

            bool isSended = mailPageObj
                .IsEmailSent();

            mailPageObj.CloseSendedComposeModalWindwow();

            return isSended;
        }

        public ComposePageObject StartComposeEmail()
        {
            Thread.Sleep(5600); // need to close pop-up window
            var closeLeftUpBtns = _webDriver.FindElements(By.ClassName("ph-project-promo-close-icon__container"));
            if (closeLeftUpBtns.Any())
                closeLeftUpBtns.First().Click();

            WaitHelper.WaitElement(_webDriver, _composeEmailButton);
            _webDriver.FindElement(_composeEmailButton).Click();
            return new ComposePageObject(_webDriver);
        }

        public AllSettingsPageObject GoToAllSettingsPage()
        {
            _webDriver.FindElement(_settingsButton)
                .NavigateAndClick(_webDriver);

            _webDriver.FindElement(_allSettingsLink)
                .NavigateAndClick(_webDriver);

            return new AllSettingsPageObject(_webDriver);
        }

        public bool IsAuthorized(string login)
        {
            By authLabel = By.XPath("//span[text()='" + login + "']");
            WaitHelper.WaitElement(_webDriver, authLabel);
            return _webDriver.FindElements(authLabel).Any();
        }
    }
}
