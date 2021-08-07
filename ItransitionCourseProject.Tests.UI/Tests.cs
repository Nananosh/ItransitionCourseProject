using NUnit.Framework;
using UiTestFramework.browser;
using UiTestFramework.pages;
using UiTestFramework.pages.App;

namespace ItransitionCourseProject.Tests.UI
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class Tests
    {
        [TearDown]
        public void CloseBrowser()
        {
            ThreadLocalBrowserManager.GetBrowser().Quit();
        }

        [Test]
        public void Test()
        {
            ThreadLocalBrowserManager
                .GetBrowser()
                .OpenPage<MainPage>()
                .Do(Assert.Pass)
                .NavigationBar.ClickRegisterLink();
        }

        [Test]
        public void Test2()
        {
            ThreadLocalBrowserManager
                .GetBrowser()
                .OpenPage<GooglePage>();

            Assert.Pass();
        }
    }
}