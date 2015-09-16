using OpenQA.Selenium;

namespace PatternsInAutomation.Tests.Conference.BingMainPage
{
    public class BingMainPageElementMap : BasePageElementMap
    {
        public BingMainPageElementMap(IWebDriver browser) : base(browser)
        {
        }

        public IWebElement SearchBox 
        {
            get
            {
                return this.browser.FindElement(By.Id("sb_form_q"));
            }
        }

        public IWebElement GoButton 
        {
            get
            {
                return this.browser.FindElement(By.Id("sb_form_go"));
            }
        }
       
        public IWebElement ResultsCountDiv
        {
            get
            {
                return this.browser.FindElement(By.Id("b_tween"));
            }
        }
    }
}