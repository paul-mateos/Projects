using System;
using OpenQA.Selenium;

namespace PatternsInAutomation.Tests.Conference.Pages.BingMain
{
    public class BingMainPage : BasePage<BingMainPageElementMap>, IBingMainPage
    {
        internal BingMainPage(IWebDriver driver)
            : base(driver, new BingMainPageElementMap(driver))
        {
        }

        internal override string Url
        {
            get
            {
                return @"http://www.bing.com/";
            }
        }

        public void Search(string textToType)
        {
            this.Map.SearchBox.Clear();
            this.Map.SearchBox.SendKeys(textToType);
            this.Map.GoButton.Click();
        }
        public int GetResultsCount()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}