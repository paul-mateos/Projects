using OpenQA.Selenium;

namespace PatternsInAutomation.Tests.Conference
{
    public abstract class BasePageElementMap
    {
        protected IWebDriver driver;

        public BasePageElementMap(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SwitchToDefault()
        {
            this.driver.SwitchTo().DefaultContent();
        }
    }
}
