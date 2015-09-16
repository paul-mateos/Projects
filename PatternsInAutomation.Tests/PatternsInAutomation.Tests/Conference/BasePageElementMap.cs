using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace PatternsInAutomation.Tests.Conference
{
    public abstract class BasePageElementMap
    {
        protected IWebDriver browser;
        protected WebDriverWait browserWait;

        public BasePageElementMap(IWebDriver browser)
        {
            this.browser = browser;
            this.browserWait = new WebDriverWait(browser, new TimeSpan(0, 0, 30));
        }

        public void SwitchToDefault()
        {
            this.browser.SwitchTo().DefaultContent();
        }
    }
}
