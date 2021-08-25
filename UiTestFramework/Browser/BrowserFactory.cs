using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace UiTestFramework.browser
{
    public static class BrowserFactory
    {
        static BrowserFactory()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
        }

        public static Browser CreateBrowser()
        {
            var webDriver = CreateWebDriver();
            return new Browser(webDriver);
        }

        private static IWebDriver CreateWebDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--incognito");
            var driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            return driver;
        }
    }
}