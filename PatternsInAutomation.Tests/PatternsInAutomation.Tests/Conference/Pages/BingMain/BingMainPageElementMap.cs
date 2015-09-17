using OpenQA.Selenium;

namespace PatternsInAutomation.Tests.Conference.Pages.BingMain
{
    public class BingMainPageElementMap : BasePageElementMap
    {
        public BingMainPageElementMap(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement SearchBox 
        {
            get
            {
                return this.driver.FindElement(By.Id("sb_form_q"));
            }
        }

        public IWebElement GoButton 
        {
            get
            {
                return this.driver.FindElement(By.Id("sb_form_go"));
            }
        }
       
        public IWebElement ResultsCountDiv
        {
            get
            {
                return this.driver.FindElement(By.Id("b_tween"));
            }
        }
    }
}