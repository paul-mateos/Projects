using OpenQA.Selenium;

namespace PatternsInAutomation.Tests.Advanced.Core
{
    public class BasePageElementMap
    {
        protected IWebDriver browser;

        public BasePageElementMap()
        {
            this.browser = Driver.Browser;
        }
    }
}
