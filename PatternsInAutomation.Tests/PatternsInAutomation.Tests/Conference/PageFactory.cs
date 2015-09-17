using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace PatternsInAutomation.Tests.Conference
{
    public static class PageFactory
    {
        private static readonly Dictionary<Type, BasePage> alreadyInitializedPages;

        static PageFactory()
        {
            alreadyInitializedPages = new Dictionary<Type, BasePage>();
        }

        public static TPage CreatePage<TPage> (this IWebDriver driver)
            where TPage : BasePage
        {
            TPage currentPageInstance = default(TPage);
            if (!alreadyInitializedPages.ContainsKey(typeof(TPage)))
            {
                currentPageInstance = (TPage) Activator.CreateInstance(typeof(TPage), driver);
                alreadyInitializedPages.Add(typeof(TPage), currentPageInstance);
            }
            else
            {
                currentPageInstance = (TPage) alreadyInitializedPages[typeof(BasePage)];
            }

            return currentPageInstance;
        }
    }
}
