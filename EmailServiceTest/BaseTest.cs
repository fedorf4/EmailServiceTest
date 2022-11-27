using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServiceTest
{
    public class BaseTest
    {
        protected IWebDriver _webDriver;

        [SetUp]
        protected void DoBeforeEachTest()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Navigate().GoToUrl(TestSettings.HostPrefix);
            _webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        protected void DoAfterEachTest()
        {
            _webDriver.Quit();
        }
    }
}
