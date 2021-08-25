using NUnit.Framework;
using UiTestFramework.browser;

namespace ItransitionCourseProject.Tests.UI.Base
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class Hook
    {
        [TearDown]
        public void CloseBrowser()
        {
            ThreadLocalBrowserManager.GetBrowser().Quit();
        }
    }
}