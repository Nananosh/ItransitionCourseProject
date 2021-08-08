using System;

namespace UiTestFramework.exceptions
{
    public class ElementIsNotDisplayedException : Exception
    {
        public ElementIsNotDisplayedException(string message) : base(message)
        {
        }
    }
}