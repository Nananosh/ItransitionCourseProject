using NUnit.Framework;
using UiTestFramework.browser;
using UiTestFramework.Data.Factories;
using UiTestFramework.Data.Models;
using UiTestFramework.pages.App;
using UiTestFramework.Properties;

namespace ItransitionCourseProject.Tests.UI.Steps
{
    public static class RegistrationSteps
    {
        public static UserModel RegisterNewUser()
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
                })
                .Browser.Quit();

            return user;
        }
    }
}