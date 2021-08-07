using System;
using UiTestFramework.browser;
using UiTestFramework.pages.base_page;
using OpenQA.Selenium;

namespace UiTestFramework.pages
{
    public class SearchPage : BasePage<SearchPage>
    {
        public SearchPage(Browser browser) : base(browser)
        {
        }

        protected override bool GetOpenByUrl()
        {
            return false;
        }

        protected override string GetPageUrl()
        {
            throw new NotImplementedException();
        }

        public override By GetRootLocator()
        {
            return By.Id("result-stats");
        }
    }
}