using OpenQA.Selenium;
using UiTestFramework.browser;
using UiTestFramework.PageComponents;
using static UiTestFramework.Properties.Properties;
using UiTestFramework.pages.BasePage;

namespace UiTestFramework.pages.App
{
    public class MainPage : BasePage<MainPage>
    {
        public MainPage(Browser browser) : base(browser)
        {
            NavigationBar = new NavigationBar(browser);
        }

        public NavigationBar NavigationBar { get; }
        
        public override By GetRootLocator()
        {
            return By.CssSelector(".container *[role=main]");
        }

        protected override bool GetOpenByUrl()
        {
            return true;
        }

        protected override string GetPageUrl()
        {
            return MainSiteUrl;
        }
    }
}