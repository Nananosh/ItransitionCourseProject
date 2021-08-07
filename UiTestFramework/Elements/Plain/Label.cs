using OpenQA.Selenium;
using UiTestFramework.pages.BasePage;

namespace UiTestFramework.elements.plain
{
    public class Label : BaseElement<Label>
    {
        internal Label(IPage parentPage, By locator, string name) : base(parentPage, locator, name)
        {
        }
    }
}