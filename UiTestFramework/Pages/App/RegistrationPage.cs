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
        private readonly Label _incorrectEmailMessageLabel;
        private readonly Label _validationErrorsLabel;
        private readonly Input _passwordInput;
        private readonly Input _passwordRepeatInput;
        private readonly Button _registerButton;
        private readonly Input _usernameInput;

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

            _incorrectEmailMessageLabel = new Label(this,
                By.Id("Email-error"), "Email error message");

            _validationErrorsLabel = new Label(this,
                By.CssSelector(".validation-summary-errors"), "Validation errors");
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
            return Browser.OpenPage<MainPage>();
        }

        public T ClickRegisterButton<T>() where T : BasePage<T>
        {
            _registerButton.Click();
            return Browser.OpenPage<T>();
        }

        public bool IsEmailErrorMessageDisplayed()
        {
            return _incorrectEmailMessageLabel.Displayed;
        }

        public string GetIncorrectEmailMessageText()
        {
            return _incorrectEmailMessageLabel.Text;
        }

        public string GetValidationErrorsText()
        {
            return _validationErrorsLabel.Text;
        }
    }
}