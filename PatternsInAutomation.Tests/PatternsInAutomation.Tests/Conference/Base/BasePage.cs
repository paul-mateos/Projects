using System;
using OpenQA.Selenium;

namespace PatternsInAutomation.Tests.Conference.Base
{
    public abstract class BasePage<TMap> : BasePage
        where TMap : BaseElementMap
    {
        private readonly TMap map;

        public BasePage(IWebDriver driver, TMap map) : base(driver)
        {
            this.map = map;
        }

        internal TMap Map 
        {
            get
            {
                return this.map;
            }
        }
    }

    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public abstract string Url { get; }

        public virtual void Open(string part = "")
        {
            this.driver.Navigate().GoToUrl(string.Concat(this.Url, part));
        }
    }
}