using AuctionSeleniumAutotests.pages.base_page;
using OpenQA.Selenium;

namespace UiTestFramework.elements.plain
{
    public class Button : BaseElement<Button>
    {
        internal Button(IPage parentPage, By locator, string name) : base(parentPage, locator, name)
        {
        }
    }
}