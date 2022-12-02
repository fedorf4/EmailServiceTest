using OpenQA.Selenium;

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
            Assert.IsTrue(mainPage.IsDarckModeEnabled());
        }

        [Test]
        public void SetLightMode()
        {
            MainPageObject mainPage = new(_webDriver);
            mainPage.OpenSettings();
            _webDriver.FindElement(GetThemeXpath("Классическая")).Click();
            Assert.IsFalse(mainPage.IsDarckModeEnabled());
        }
    }
}
