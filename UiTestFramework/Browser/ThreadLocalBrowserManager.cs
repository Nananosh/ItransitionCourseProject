using System.Threading;

namespace UiTestFramework.browser
{
    public static class ThreadLocalBrowserManager
    {
        private static readonly ThreadLocal<Browser> ThreadLocalBrowser = new();

        public static Browser GetBrowser()
        {
            if (ThreadLocalBrowser.Value == null || ThreadLocalBrowser.Value.Closed)
                ThreadLocalBrowser.Value = BrowserFactory.CreateBrowser();
            return ThreadLocalBrowser.Value;
        }
    }
}