namespace PatternsInAutomation.Tests.Conference
{
    public class BasePageAsserter<TMap>
        where TMap : BasePageElementMap, new()
    {
        protected TMap Map
        {
            get
            {
                return new TMap();
            }
        }
    }
}