using System;
using OpenQA.Selenium;
using UiTestFramework.elements.interfaces;
using UiTestFramework.exceptions;
using UiTestFramework.pages.Base;
namespace UiTestFramework.elements
{
    public abstract class BaseElement<TElement> : IClickable<TElement>, IContainingText
        where TElement : BaseElement<TElement>, IClickable<TElement>, IContainingText
    {
        private readonly string _name;

        internal BaseElement(IPage parentPage, By locator, string name)
        {
            ParentPage = parentPage;
            Locator = locator;
            Name = name;
        }

        private bool ShouldBeDisplayed { get; set; }
        private IPage ParentPage { get; }
        private By Locator { get; }

        private string Name
        {
            get => $"{_name} {GetType().Name}";
            init => _name = value;
        }

        public TElement Click()
        {
            GetWebElement().Click();
            return (TElement) this;
        }

        public TElement ClickByActions()
        {
            throw new NotImplementedException();
        }

        public TElement ClickByScript()
        {
            throw new NotImplementedException();
        }

        public string GetText()
        {
            return GetWebElement().Text;
        }

        protected IWebElement GetWebElement()
        {
            ThrowExceptionIfParentPageIsNotOpened();
            var element = FindWebElement(Locator);
            ThrowExceptionIfElementIsNotDisplayedButShouldBe(element, $"Cannot find element {Name}, {Locator}");
            return element;
        }

        private void ThrowExceptionIfParentPageIsNotOpened()
        {
            if (!ParentPage.IsOpened()) throw new ParentPageIsNotOpenedException(ParentPage.GetRootLocator());
        }

        private IWebElement FindWebElement(By locator)
        {
            return ParentPage.Browser.FindElement(ParentPage, locator);
        }

        private void ThrowExceptionIfElementIsNotDisplayedButShouldBe(IWebElement element, string errorMessage)
        {
            if (ShouldBeDisplayed && !element.Displayed) throw new ElementIsNotDisplayedException(errorMessage);
        }
    }
}