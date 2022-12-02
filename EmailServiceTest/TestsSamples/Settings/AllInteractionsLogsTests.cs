namespace EmailServiceTest.TestsSamples.Settings
{
    [TestFixture]
    internal sealed class AllInteractionsLogsTests : BaseTest
    {
        [SetUp]
        public void BeforeTest()
        {
            AuthorizationPageObject authPage = new(_webDriver);
            MainPageObject mainPage = authPage.Authorize(TestSettings.Login, TestSettings.Password);
            Assert.IsTrue(mainPage.IsAuthorized(TestSettings.Login));
        }

        [Test]
        public void SendMailLog()
        {
            MainPageObject mainPage = new(_webDriver);

            mainPage.SendMailAndClose(
                    recipientEmail: TestSettings.Login,
                    subject: "Test email: " + DateTime.Now,
                    text: "Test dotTxt"
                );

            var allSettingsPage = mainPage.GoToAllSettingsPage();

            var logsPage = allSettingsPage.GoToLogInteractions();
            Thread.Sleep(1600);

            var logsBodies = logsPage.GetLogsRowBodies("письмо").Concat(logsPage.GetLogsRowBodies("писем"));
            Thread.Sleep(500);
            Assert.True(logsBodies.Any(lb => lb.Contains("Отправлено")));
        }
    }
}
