using System;
using UiTestFramework.exceptions;
using UiTestFramework.pages.base_page;
using OpenQA.Selenium;

namespace UiTestFramework.browser
{
    public class Browser
    {
        private readonly IWebDriver _webDriver;

        internal Browser(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            Closed = false;
        }

        internal IWebDriver WebDriver => Closed ? throw new WebDriverClosedException("Driver is closed") : _webDriver;

        public bool Closed { get; private set; }

        public T OpenPage<T>() where T : BasePage<T>
        {
            return (T) Activator.CreateInstance(typeof(T), this)!;
        }

        public void Quit()
        {
            WebDriver.Quit();
            Closed = true;
            WebDriver.Dispose();
        }

        internal IWebElement FindElement(By locator)
        {
            return WebDriver.FindElement(locator);
        }
    }
}