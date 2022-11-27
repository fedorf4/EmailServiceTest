namespace EmailServiceTest
{
    [TestFixture]
    public sealed class Tests : BaseTest
    {
        [Test]
        public void AuthorizeTest()
        {
            AuthorizationPageObject authPage = new(_webDriver);
            authPage.Authorize(TestSettings.Login, TestSettings.Password);

        }
    }
}