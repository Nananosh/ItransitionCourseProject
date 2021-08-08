using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UiTestFramework.browser;

namespace UiTestFramework.pages.Base
{
    public abstract class BasePage<T> : LoadableComponent<T>, IPage where T : BasePage<T>
    {
        public delegate void PageAction(T page);

        public BasePage(Browser browser)
        {
            Browser = browser;
            Load();
        }

        public override string UnableToLoadMessage
        {
            get => $"Failed to load {GetType().Name}. Root locator: {GetRootLocator()}";
            set => base.UnableToLoadMessage = value;
        }

        public Browser Browser { get; init; }

        public bool IsOpened()
        {
            return IsLoaded;
        }

        public abstract By GetRootLocator();

        protected abstract bool GetOpenByUrl();

        public sealed override T Load()
        {
            return base.Load();
        }

        public T Do(PageAction action)
        {
            action.Invoke((T) this);
            return (T) this;
        }

        public abstract string GetPageUrl();

        protected sealed override void ExecuteLoad()
        {
            if (GetOpenByUrl()) Browser.WebDriver.Navigate().GoToUrl(GetPageUrl());
        }

        protected override bool EvaluateLoadedStatus()
        {
            return Browser.WebDriver.FindElement(GetRootLocator()).Displayed;
        }
    }
}