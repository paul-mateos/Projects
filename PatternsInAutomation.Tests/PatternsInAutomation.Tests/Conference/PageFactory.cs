using PatternsInAutomation.Tests.Advanced.Core;
using System;
using System.Collections.Generic;

namespace PatternsInAutomation.Tests.Conference
{
    public static class PageFactory<TPage> where TPage : class, IPage
    {
        private static readonly Dictionary<Type, TPage> alreadyInitializedPages;

        static PageFactory()
        {
            alreadyInitializedPages = new Dictionary<Type, TPage>();
        }

        public static TPage Create()
        {
            TPage currentPageInstance = default(TPage);
            if (!alreadyInitializedPages.ContainsKey(typeof(TPage)))
            {
                currentPageInstance = (TPage) Activator.CreateInstance(typeof(TPage), Driver.Browser);
                alreadyInitializedPages.Add(typeof(TPage), currentPageInstance);
            }
            else
            {
                currentPageInstance = alreadyInitializedPages[typeof(TPage)];
            }

            return currentPageInstance;
        }
    }
}
