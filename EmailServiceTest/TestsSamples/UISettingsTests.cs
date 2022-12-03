using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace EmailServiceTest.TestsSamples
{
    [TestFixture]
    internal sealed class UISettingsTests : BaseTest
    {
        [SetUp]
        public void BeforeTest()
        {
            AuthorizationPageObject authPage = new(_webDriver);
            MainPageObject mainPage = authPage.Authorize(TestSettings.Login, TestSettings.Password);
            Assert.IsTrue(mainPage.IsAuthorized(TestSettings.Login));
        }

        private static By GetThemeXpath(string name)
            => By.XPath($".//span[text() = '{name}']//parent::div");

        [Test]
        public void SetDarkMode()
        {
            MainPageObject mainPage = new(_webDriver);
            mainPage.OpenSettings();
            _webDriver.FindElement(GetThemeXpath("Тёмная тема")).Click();
            Thread.Sleep(2000);
            Assert.IsTrue(mainPage.IsDarckModeEnabled());
        }

        [Test]
        public void SetLightMode()
        {
            MainPageObject mainPage = new(_webDriver);
            mainPage.OpenSettings();
            _webDriver.FindElement(GetThemeXpath("Классическая")).Click();
            Thread.Sleep(2000);
            Assert.IsFalse(mainPage.IsDarckModeEnabled());
        }

        [Test]
        public void ChangeScalingMode()
        {
            MainPageObject mainPage = new(_webDriver);
            bool isCompact = mainPage.IsCompactModeEnabled();

            bool isCompact2 = mainPage
                .ChangeCompactMode()
                .IsCompactModeEnabled();
            Assert.IsTrue(isCompact != isCompact2);

            isCompact = mainPage
                .ChangeCompactMode()
                .IsCompactModeEnabled();
            Assert.IsTrue(isCompact != isCompact2);
        }

        [Test]
        public void RemoveGosMail()
        {
            MainPageObject mainPage = new(_webDriver);
            string gosFolderTitle = "Госписьма";

            Thread.Sleep(1000);
            bool hasGosFolder = mainPage.HasFolder(gosFolderTitle);
            mainPage.SwitchSmartSorting(gosFolderTitle);
            Thread.Sleep(3000);
            bool hasGosFolder2 = mainPage.HasFolder(gosFolderTitle);
            Assert.That(hasGosFolder2, Is.Not.EqualTo(hasGosFolder));
            
            new Actions(_webDriver)
                .SendKeys(Keys.Escape)
                .Perform();
            Thread.Sleep(1000);
            mainPage.SwitchSmartSorting(gosFolderTitle);
            Thread.Sleep(3000);
            hasGosFolder = mainPage.HasFolder(gosFolderTitle);
            Assert.That(hasGosFolder, Is.Not.EqualTo(hasGosFolder2));
        }
    }
}
