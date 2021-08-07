using NUnit.Framework;
using UiTestFramework.browser;
using UiTestFramework.pages;

namespace ItransitionCourseProject.Tests.UI
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class Tests
    {
        [Test]
        public void Test()
        {
            ThreadLocalBrowserManager
                .GetBrowser()
                .OpenPage<GooglePage>()
                .EnterQueryIntoSearchField("Wikipedia")
                .ClickSearchButton()
                .IsOpened();
                
            ThreadLocalBrowserManager.GetBrowser().Quit();

            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            ThreadLocalBrowserManager
                .GetBrowser()
                .OpenPage<GooglePage>()
                .Browser.Quit();

            Assert.Pass();
        }
    }
}