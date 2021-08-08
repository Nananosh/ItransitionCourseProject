using OpenQA.Selenium;
using UiTestFramework.browser;
using UiTestFramework.elements.plain;
using UiTestFramework.pages.Base;

namespace UiTestFramework.pages
{
    public class GooglePage : BasePage<GooglePage>
    {
        private readonly Button _searchButton;
        private readonly Input _searchInput;

        public GooglePage(Browser browser) : base(browser)
        {
            _searchButton = new Button(this, By.Name("btnK"), "Search");
            _searchInput = new Input(this, By.Name("q"), "Search");
        }

        public SearchPage ClickSearchButton()
        {
            _searchButton.Click();
            return new SearchPage(Browser);
        }

        public GooglePage EnterQueryIntoSearchField(string query)
        {
            _searchInput.SendKeys(query);
            return this;
        }

        protected override bool GetOpenByUrl()
        {
            return true;
        }

        public override string GetPageUrl()
        {
            return "https://google.com/";
        }

        public override By GetRootLocator()
        {
            return By.XPath("//input[@name='q']//ancestor::body");
        }
    }
}