using System.Diagnostics;

namespace EmailServiceTest.TestsSamples
{
    [TestFixture]
    internal sealed class PerformanceTestsClient
    {
        [Test]
        public void SimpleGetSpeedTest()
        {
            HttpClient client = new();

            int cnt = 5;
            Stopwatch sw = new();
            List<long> delays = new(cnt);
            while (cnt-- > 0)
            {
                HttpRequestMessage request = new()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(TestSettings.HostPrefix + cnt)
                };

                sw.Restart();
                client.Send(request);
                sw.Stop();
                delays.Add(sw.ElapsedMilliseconds);
                Thread.Sleep(500);
            }

            Assert.That(delays.Max() - delays.Min(), Is.LessThan(1000));
        }

    }
}
