using OpenQA.Selenium;

namespace EmailServiceTest
{
    [TestFixture]
    public sealed class Tests : BaseTest
    {
        [Test]
        public void AuthorizeTest()
        {
            AuthorizationPageObject authPage = new(_webDriver);
            MainPageObject mainPage = authPage.Authorize(TestSettings.Login, TestSettings.Password);
            Assert.IsTrue(mainPage.IsAuthorized(TestSettings.Login));
        }

        [Test]
        public void SendEmailTest()
        {
            AuthorizationPageObject authPage = new(_webDriver);
            bool isSent = authPage
                .Authorize(TestSettings.Login, TestSettings.Password)
                .StartComposeEmail()
                .EnterAddressTo(TestSettings.Login)
                .EnterSubject("Test email: " + DateTime.Now)
                .EnterEmailText("Test text")
                .SendEmail()
                .IsEmailSent();
            Assert.IsTrue(isSent);
        }

        [Test]
        public void AddFolderTest()
        {
            AuthorizationPageObject authPage = new(_webDriver);
            MainPageObject mainPage = authPage.Authorize(TestSettings.Login, TestSettings.Password);
            string name = "Test Folder" + DateTime.Now;
            mainPage.AddFolder(name);
            Assert.IsTrue(mainPage.IsFolderExist(name));
            mainPage.DeleteFolder(name);
            Assert.IsFalse(mainPage.IsFolderExist(name));
        }

        [Test]
        public void SignatureTest()
        {
            AuthorizationPageObject authPage = new(_webDriver);
            MainPageObject mainPage = authPage.Authorize(TestSettings.Login, TestSettings.Password);
            string senderName = "TestName";
            string signature = "Do not reply to this message";
            SettingsPageObject settingsPage = mainPage
                .OpenAllSettings()
                .OpenSiganturesSettings()
                .AddSignature(senderName, signature);
            _webDriver.SwitchTo().Window(_webDriver.WindowHandles[0]);
            _webDriver.Navigate().Refresh();
            bool isSignatureExist = mainPage
                .StartComposeEmail()
                .IsSignatureExist(signature);
            Assert.IsTrue(isSignatureExist);

            _webDriver.SwitchTo().Window(_webDriver.WindowHandles[1]);
            settingsPage.DeleteSignature();
            _webDriver.SwitchTo().Window(_webDriver.WindowHandles[0]);
            _webDriver.FindElement(By.XPath("//button[@title='Закрыть']")).Click();
            Thread.Sleep(1000);
            _webDriver.Navigate().Refresh();
            isSignatureExist = mainPage
                .StartComposeEmail()
                .IsSignatureExist(signature);
            Assert.IsFalse(isSignatureExist);
        }
    }
}
