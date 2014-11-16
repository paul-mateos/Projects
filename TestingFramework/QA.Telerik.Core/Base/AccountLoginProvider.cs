using QA.Telerik.Core.Pages.LoginPage;
using QA.UI.TestingFramework.Core.Providers;

namespace QA.Telerik.Core.Base
{
    public class AccountLoginProvider : LoginProvider<AccountLoginProvider>
    {
        public override UI.TestingFramework.Core.Contracts.ILogin Login
        {
            get
            {
                return new LoginPage();
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
