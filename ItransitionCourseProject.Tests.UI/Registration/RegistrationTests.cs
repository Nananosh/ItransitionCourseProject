using ItransitionCourseProject.Tests.UI.Base;
using NUnit.Framework;
using UiTestFramework.browser;
using UiTestFramework.pages.App;
using UiTestFramework.Properties;

namespace ItransitionCourseProject.Tests.UI.Registration
{
    [TestFixture]
    public class RegistrationTests : Hook
    {
        [Test]
        [Category("Positive")]
        public void RegistrationTest()
        {
            ThreadLocalBrowserManager.GetBrowser()
                .OpenPage<MainPage>()
                .NavigationBar.ClickRegisterLink()
                .EnterEmail("autotest@gmail.com")
                .EnterUsername("Autotest")
                .EnterPassword("Test12*345")
                .EnterPasswordRepeat("Test12*345")
                .ClickRegisterButton()
                .Do(page =>
                {
                    var expectedPageUrl = TestProperties.MainUrl;
                    var actualPageURl = page.Browser.CurrentUrl;
                    Assert.AreEqual(expectedPageUrl, actualPageURl, "Main Page isn't opened or it has incorrect url");
                });
        }
    }
}