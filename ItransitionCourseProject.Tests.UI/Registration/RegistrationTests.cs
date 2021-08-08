using ItransitionCourseProject.Tests.UI.Base;
using ItransitionCourseProject.Tests.UI.Steps;
using NUnit.Framework;
using UiTestFramework.browser;
using UiTestFramework.Data.Factories;
using UiTestFramework.pages.App;
using UiTestFramework.Properties;

namespace ItransitionCourseProject.Tests.UI.Registration
{
    [TestFixture]
    public class RegistrationTests : Hook
    {
        [Test]
        [Category("Positive")]
        public void RegisterTest()
        {
            var user = UserDataFactory.GetRandomUser();

            ThreadLocalBrowserManager.GetBrowser()
                .OpenPage<MainPage>()
                .NavigationBar.ClickRegisterLink()
                .EnterEmail(user.Email)
                .EnterUsername(user.Name)
                .EnterPassword(user.Password)
                .EnterPasswordRepeat(user.Password)
                .ClickRegisterButton()
                .Do(page =>
                {
                    var expectedPageUrl = TestProperties.MainUrl;
                    var actualPageURl = page.Browser.CurrentUrl;
                    Assert.AreEqual(expectedPageUrl, actualPageURl, "Main Page isn't opened or it has incorrect url");
                });
        }

        [Test]
        [Category("Negative")]
        public void RegisterTwoAccountsForOneEmailTest()
        {
            var existingUser = RegistrationSteps.RegisterNewUser();
            var newUser = UserDataFactory.GetRandomUser();

            ThreadLocalBrowserManager.GetBrowser()
                .OpenPage<MainPage>()
                .NavigationBar.ClickRegisterLink()
                .EnterEmail(existingUser.Email)
                .EnterUsername(newUser.Name)
                .EnterPassword(newUser.Password)
                .EnterPasswordRepeat(newUser.Password)
                .ClickRegisterButton<RegistrationPage>()
                .Do(page =>
                {
                    Assert.Multiple(() =>
                    {
                        Assert.True(page.IsEmailErrorMessageDisplayed(), "Incorrect email error isn't displayed");
                        Assert.AreEqual("Email is already in use", page.GetIncorrectEmailMessageText(),
                            "Incorrect email error has incorrect text");
                    });
                });
        }
    }
}