using OpenQA.Selenium;
using PatternsInAutomation.Tests.Advanced.Core;
using System;

namespace PatternsInAutomation.Tests.Conference
{
    public abstract class BasePage<TMap> : IPage
        where TMap : BasePageElementMap
    {
        private static TMap map;
        private readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal abstract string Url { get; }

        internal TMap Map
        {
            get
            {
                if (map == null)
                {
                    map = (TMap) Activator.CreateInstance(typeof(TMap), driver);
                }
                return map;
            }
        }

        public virtual void Navigate(string part = "")
        {
            this.driver.Navigate().GoToUrl(string.Concat(this.Url, part));
        }
    }
}