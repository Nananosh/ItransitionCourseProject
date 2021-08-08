using System;
using OpenQA.Selenium;

namespace UiTestFramework.exceptions
{
    public class ParentPageIsNotOpenedException : Exception
    {
        public ParentPageIsNotOpenedException(By parentLocator) : base($"Parent page isn't loaded {parentLocator}")
        {
        }
    }
}