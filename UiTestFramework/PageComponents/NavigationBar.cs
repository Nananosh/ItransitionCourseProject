using System;
using OpenQA.Selenium;
using UiTestFramework.browser;
using UiTestFramework.elements.plain;
using UiTestFramework.pages.BasePage;

namespace UiTestFramework.PageComponents
{
    public class NavigationBar : BasePage<NavigationBar>
    {
        private readonly Link _loginLink;
        private readonly Link _registerLink;
        private readonly Label _titleLabel;

        public NavigationBar(Browser browser) : base(browser)
        {
            _titleLabel = new Label(this,
                By.CssSelector(".navbar-brand"), "Title");

            _loginLink = new Link(this,
                By.XPath(".//a[@href='/Account/Login' and text()='Login']"), "Login");

            _registerLink = new Link(this,
                By.XPath(".//a[@href='/Account/Register' and text()='Register']"), "Register");
        }

        public override By GetRootLocator()
        {
            return By.CssSelector("nav.navbar");
        }

        protected override bool GetOpenByUrl()
        {
            return false;
        }

        protected override string GetPageUrl()
        {
            throw new NotImplementedException();
        }

        public string GetTitle()
        {
            return _titleLabel.GetText();
        }

        public object ClickLoginLink()
        {
            _loginLink.Click();
            return null;
        }
        
        public object ClickRegisterLink()
        {
            _registerLink.Click();
            return null;
        }
    }
}