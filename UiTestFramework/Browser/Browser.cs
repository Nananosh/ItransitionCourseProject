using System;
using OpenQA.Selenium;
using UiTestFramework.exceptions;
using UiTestFramework.pages.Base;

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

        public string CurrentUrl => WebDriver.Url;

        public T OpenPage<T>() where T : BasePage<T>
        {
            return (T) Activator.CreateInstance(typeof(T), this)!;
        }

        public void Quit()
        {
            WebDriver.Quit();
            Closed = true;
        }

        internal IWebElement FindElement(By locator)
        {
            return WebDriver.FindElement(locator);
        }

        internal IWebElement FindElement(IPage parentPage, By locator)
        {
            return WebDriver.FindElement(parentPage.GetRootLocator()).FindElement(locator);
        }
    }
}