﻿namespace PatternsInAutomation.Tests.Advanced.Unity.Base
{
    public class BasePageValidator<M>
        where M : BasePageElementMap, new()
    {
        protected M Map
        {
            get
            {
                return new M();
            }
        }
    }
}