using OpenQA.Selenium;
using UiTestFramework.browser;

namespace UiTestFramework.pages.BasePage
{
    internal interface IPage
    {
        Browser Browser { get; init; }

        bool IsOpened();

        By GetRootLocator();
    }
}