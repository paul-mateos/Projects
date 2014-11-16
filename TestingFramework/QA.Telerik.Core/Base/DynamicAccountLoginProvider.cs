using System;
using QA.Telerik.Core.Pages.LoginPage;
using QA.UI.TestingFramework.Core.Providers;

namespace QA.Telerik.Core.Base
{
    public class DynamicAccountLoginProvider : DynamicLoginProvider<AccountLoginProvider>
    {
        public override dynamic Login
        {
            get
            {
                return new DynamicLoginPage();
            }
        }

        public override string Url
        {
            get
            {
                return @"https://www.telerik.com/login/v2/telerik";
            }
        }
    }
}
