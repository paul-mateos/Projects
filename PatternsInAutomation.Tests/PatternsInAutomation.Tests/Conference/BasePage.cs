using System;
using OpenQA.Selenium;

namespace PatternsInAutomation.Tests.Conference
{
    public abstract class BasePage<TMap> : BasePage
        where TMap : BasePageElementMap
    {
        private readonly TMap map;

        internal BasePage(IWebDriver driver, TMap map) : base(driver)
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

        public void Initialize(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal abstract string Url { get; }

        public virtual void Open(string part = "")
        {
            this.driver.Navigate().GoToUrl(string.Concat(this.Url, part));
        }
    }
}