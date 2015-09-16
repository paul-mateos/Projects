using System;
using OpenQA.Selenium;

namespace PatternsInAutomation.Tests.Conference.BingMainPage
{
    public class BingMainPage : BasePage<BingMainPageElementMap>
    {
        public BingMainPage(IWebDriver driver) : base(driver)
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
    }
}