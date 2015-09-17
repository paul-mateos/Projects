using System;
using OpenQA.Selenium;

namespace PatternsInAutomation.Tests.Conference
{
    public abstract class BasePage<TMap> : BasePage
        where TMap : BasePageElementMap
    {
        private TMap map;

        public BasePage(IWebDriver driver) : base(driver)
        {
        }

        internal TMap Map
        {
            get
            {
                if (map == null)
                {
                    map = (TMap)Activator.CreateInstance(typeof(TMap), driver);
                }
                return map;
            }
        }
    }

    public abstract class BasePage
    {
        protected readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal abstract string Url { get; }

        public virtual void Navigate(string part = "")
        {
            this.driver.Navigate().GoToUrl(string.Concat(this.Url, part));
        }
    }
}