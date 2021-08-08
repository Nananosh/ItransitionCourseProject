using System;
using OpenQA.Selenium;
using UiTestFramework.browser;
using UiTestFramework.elements.plain;
using UiTestFramework.pages.App;
using UiTestFramework.pages.Base;

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

        public string Title => _titleLabel.Text;

        public override By GetRootLocator()
        {
            return By.CssSelector("nav.navbar");
        }

        protected override bool GetOpenByUrl()
        {
            return false;
        }

        public override string GetPageUrl()
        {
            throw new NotImplementedException();
        }

        public object ClickLoginLink()
        {
            _loginLink.Click();
            return null;
        }

        public RegistrationPage ClickRegisterLink()
        {
            _registerLink.Click();
            return new RegistrationPage(Browser);
        }
    }
}