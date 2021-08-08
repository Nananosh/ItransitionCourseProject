using OpenQA.Selenium;
using UiTestFramework.browser;
using UiTestFramework.elements.plain;
using UiTestFramework.pages.Base;
using UiTestFramework.Properties;

namespace UiTestFramework.pages.App
{
    public class RegistrationPage : BasePage<RegistrationPage>
    {
        private readonly Input _emailInput;
        private readonly Input _usernameInput;
        private readonly Input _passwordInput;
        private readonly Input _passwordRepeatInput;
        private readonly Button _registerButton;

        public RegistrationPage(Browser browser) : base(browser)
        {
            _emailInput = new Input(this,
                By.Id("Email"), "Email");

            _usernameInput = new Input(this,
                By.Id("UserName"), "Username");

            _passwordInput = new Input(this,
                By.Id("Password"), "Password");

            _passwordRepeatInput = new Input(this,
                By.Id("PasswordConfirm"), "Repeat password");

            _registerButton = new Button(this,
                By.XPath("//*[@action='/Account/Register']//*[@type='submit']"), "Register");
        }

        public override By GetRootLocator()
        {
            return By.XPath("//*[contains(@class,'container')]//*[@role='main'][//h2[text()='Registration']]");
        }
        
        public override string GetPageUrl()
        {
            return TestProperties.RegistrationPageUrl;
        }

        protected override bool GetOpenByUrl()
        {
            return false;
        }

        public RegistrationPage EnterEmail(string email)
        {
            _emailInput.SendKeys(email);
            return this;
        }

        public RegistrationPage EnterUsername(string username)
        {
            _usernameInput.SendKeys(username);
            return this;
        }

        public RegistrationPage EnterPassword(string password)
        {
            _passwordInput.SendKeys(password);
            return this;
        }
        
        public RegistrationPage EnterPasswordRepeat(string passwordRepeat)
        {
            _passwordRepeatInput.SendKeys(passwordRepeat);
            return this;
        }

        public MainPage ClickRegisterButton()
        {
            _registerButton.Click();
            return new MainPage(Browser);
        }
    }
}