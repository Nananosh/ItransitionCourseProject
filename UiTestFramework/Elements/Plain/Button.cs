using OpenQA.Selenium;
using UiTestFramework.pages.Base;

namespace UiTestFramework.elements.plain
{
    public class Button : BaseElement<Button>
    {
        internal Button(IPage parentPage, By locator, string name) : base(parentPage, locator, name)
        {
        }
    }
}