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
        private static readonly By _startAddFolderButton = By.XPath("//div[text()='Новая папка']");
        private static readonly By _folderNameInput = By.XPath("//input[@name='name']");
        private static readonly By _submitAddFolderButton = By.XPath("//button[@data-test-id='submit']");
        private readonly By _settingsButton = By.ClassName("settings");
        private readonly By _allSettingsButton = By.XPath("//span[text()='Все настройки']");

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
            Thread.Sleep(3600); // need to close pop-up window
            var closeLeftUpBtns = _webDriver.FindElements(By.ClassName("ph-project-promo-close-icon__container"));
            if (closeLeftUpBtns.Any())
                closeLeftUpBtns.First().Click();

            WaitHelper.WaitElement(_webDriver, _composeEmailButton);
            _webDriver.FindElement(_composeEmailButton).Click();
            return new ComposePageObject(_webDriver);
        }

        public MainPageObject OpenSettings()
        {
            WaitHelper.WaitElement(_webDriver, _settingsButton);
            _webDriver.FindElement(_settingsButton)
                .NavigateAndClick(_webDriver);
            return this;
        }

        public AllSettingsPageObject GoToAllSettingsPage()
        {
            _webDriver.FindElement(_settingsButton)
                .NavigateAndClick(_webDriver);

            _webDriver.FindElement(_allSettingsLink)
                .NavigateAndClick(_webDriver);

            return new AllSettingsPageObject(_webDriver);
        }

        public MainPageObject AddFolder(string name)
        {
            WaitHelper.WaitElement(_webDriver, _startAddFolderButton);
            _webDriver.FindElement(_startAddFolderButton).Click();
            WaitHelper.WaitElement(_webDriver, _folderNameInput);
            _webDriver.FindElement(_folderNameInput).SendKeys(name);
            _webDriver.FindElement(_submitAddFolderButton).Click();
            return this;
        }

        public MainPageObject DeleteFolder(string name)
        {
            By folderXPath = By.XPath($"//*[text()='{name}']");
            WaitHelper.WaitElement(_webDriver, folderXPath);
            IWebElement folder = _webDriver.FindElement(folderXPath);
            new Actions(_webDriver)
                .ContextClick(folder)
                .Perform();
            Thread.Sleep(1000);
            _webDriver.FindElement(By.XPath("//*[text()='Удалить папку']")).Click();
            Thread.Sleep(1000);
            _webDriver.FindElement(By.XPath("//*[text()='Удалить']")).Click();
            Thread.Sleep(1000);
            return this;
        }

        public SettingsPageObject OpenAllSettings()
        {
            WaitHelper.WaitElement(_webDriver, _settingsButton);
            _webDriver.FindElement(_settingsButton).Click();
            WaitHelper.WaitElement(_webDriver, _allSettingsButton);
            _webDriver.FindElement(_allSettingsButton).Click();
            return new SettingsPageObject(_webDriver);
        }

        public bool IsFolderExist(string name)
        {
            Thread.Sleep(500);
            By folder = By.XPath("//a[@title='" + name + ", нет писем']");
            return _webDriver.FindElements(folder).Any();
        }

        public bool IsAuthorized(string login)
        {
            By authLabel = By.XPath("//span[text()='" + login + "']");
            WaitHelper.WaitElement(_webDriver, authLabel);
            return _webDriver.FindElements(authLabel).Any();
        }

        public bool IsDarckModeEnabled() 
            => _webDriver.FindElement(By.XPath("/html/body")).GetAttribute("class").Contains("g-dark-mode");

        public MainPageObject ChangeCompactMode()
        {
            OpenSettings();
            var xpath = By.XPath(".//div[contains(@data-test-id, 'ponymode')]");
            WaitHelper.WaitElement(_webDriver, xpath);
            _webDriver.FindElement(xpath).Click();
            return this;
        }

        public bool IsCompactModeEnabled()
            => _webDriver.FindElement(By.XPath("/html/body")).GetAttribute("class").Contains("g-pony-mode");

        public MainPageObject SwitchSmartSorting(string name)
        {
            OpenSettings();
            _webDriver.FindElement(By.XPath(".//span[text()='Умная сортировка']")).NavigateAndClick(_webDriver);
            var xpath = By.XPath(".//small[text()='Госписьма']//following::div");
            WaitHelper.WaitElement(_webDriver, xpath);
            _webDriver.FindElement(xpath).Click();
            return this;
        }

        public bool HasFolder(string name)
            => _webDriver.FindElements(By.XPath($".//div[@class='nav__folder-name__txt' and text() = '{name}']")).Any();
    }
}
