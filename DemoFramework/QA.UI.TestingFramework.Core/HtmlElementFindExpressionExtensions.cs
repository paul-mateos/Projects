namespace QA.UI.TestingFramework.Core
{
    public static class HtmlElementFindExpressionExtensions
    {
        public static string Xpath(this string expression)
        {
            return string.Concat("xpath=", expression);
        }
    }
}
