using OpenQA.Selenium;
using UiTestFramework.pages.Base;

namespace UiTestFramework.elements.plain
{
    public class Link : BaseElement<Link>
    {
        internal Link(IPage parentPage, By locator, string name) : base(parentPage, locator, name)
        {
        }
    }
}