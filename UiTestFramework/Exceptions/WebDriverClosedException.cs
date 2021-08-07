using System;

namespace UiTestFramework.exceptions
{
    public class WebDriverClosedException : Exception
    {
        public WebDriverClosedException(string message) : base(message)
        {
        }
    }
}