using AuctionSeleniumAutotests.pages.base_page;
using OpenQA.Selenium;
using UiTestFramework.elements.interfaces;

namespace UiTestFramework.elements.plain
{
    public class Input : BaseElement<Input>, IInput<Input>
    {
        internal Input(IPage parentPage, By locator, string name) : base(parentPage, locator, name)
        {
        }

        public Input SendKeys(string value)
        {
            Clear();
            GetWebElement().SendKeys(value);
            return this;
        }

        public Input Clear()
        {
            GetWebElement().Clear();
            return this;
        }
    }
}