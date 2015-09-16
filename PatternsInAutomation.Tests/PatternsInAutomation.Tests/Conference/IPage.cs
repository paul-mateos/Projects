using OpenQA.Selenium;

namespace PatternsInAutomation.Tests.Conference
{
    public interface IPage
    {
        void Navigate(string part = "");
    }
}
