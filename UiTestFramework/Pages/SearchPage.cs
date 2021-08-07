using System;
using OpenQA.Selenium;
using UiTestFramework.browser;
using UiTestFramework.pages.BasePage;

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