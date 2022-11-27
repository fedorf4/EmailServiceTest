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

    }
}