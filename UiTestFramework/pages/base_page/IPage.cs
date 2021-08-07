using UiTestFramework.browser;
using OpenQA.Selenium;

namespace AuctionSeleniumAutotests.pages.base_page
{
    internal interface IPage
    {
        Browser Browser { get; init; }

        bool IsOpened();

        By GetRootLocator();
    }
}