using Microsoft.Extensions.Configuration;

namespace EmailServiceTest
{
    internal static class TestSettings
    {
        private static readonly IConfiguration _config;

        static TestSettings()
        {
            string projPath = new DirectoryInfo(Directory.GetCurrentDirectory())
                !.Parent
                !.Parent
                !.Parent
                !.FullName;

            _config = new ConfigurationBuilder()
                        .SetBasePath(projPath)
                        .AddJsonFile("config.json", optional: false, reloadOnChange: true)
                        .AddUserSecrets<BaseTest>()
                        .Build();
        }

        public static string HostPrefix => _config["host-prefix"];
        public static string Login => _config["e-mail-login"];
        public static string Password => _config["e-mail-password"];
    }
}
