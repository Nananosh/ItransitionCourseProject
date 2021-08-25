using OpenQA.Selenium;
using UiTestFramework.browser;

namespace UiTestFramework.pages.Base
{
    internal interface IPage
    {
        Browser Browser { get; init; }

        bool IsOpened();

        By GetRootLocator();
    }
}