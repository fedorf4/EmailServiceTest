using System.Diagnostics;

namespace EmailServiceTest.TestsSamples
{
    [TestFixture]
    internal sealed class UIPerformanceTests : BaseTest
    {

        private void AsserDelaysMultipleStart(int cnt, Action<MainPageObject, int> func, long maxTime)
        {
            if (func is null)
                throw new ArgumentNullException(nameof(func));

            List<long> delays = new(cnt);

            while (cnt-- > 0)
            {
                var sw = Stopwatch.StartNew();
                AuthorizationPageObject authPage = new(_webDriver);
                MainPageObject mainPage = authPage.Authorize(TestSettings.Login, TestSettings.Password);
                Assert.That(mainPage.IsAuthorized(TestSettings.Login), Is.True);

                func.Invoke(mainPage, cnt);

                sw.Stop();
                delays.Add(sw.ElapsedMilliseconds);

                DoAfterEachTest();
                DoBeforeEachTest();
            }
            Assert.That(delays.All(t => t < maxTime));
            Assert.That(delays.Max() - delays.Min(), Is.LessThan(1000));
        }


        [Test]
        public void FromLogInToCompose()
        {

            AsserDelaysMultipleStart(5, (mainPage, i) => mainPage.SendMailAndClose(
                    recipientEmail: TestSettings.Login,
                    text: $"Hi-{i}",
                    subject: $"UI-performance - {i}"
                    ),
                    maxTime: 45 * 1000
            );
        }

        [Test]
        public void GoToLogsSpeedTest()
        {

            AsserDelaysMultipleStart(5, 
                (mainPage, i) => mainPage
                    .GoToAllSettingsPage()
                    .GoToLogInteractions(),
                maxTime: 120 * 1000
            );
        }
    }
}
