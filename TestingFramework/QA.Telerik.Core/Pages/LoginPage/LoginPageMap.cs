using ArtOfTest.WebAii.Controls.HtmlControls;
using QA.UI.TestingFramework.Core;

namespace QA.Telerik.Core.Pages.LoginPage
{
    public class LoginPageMap : BaseElementMap
    {
        public HtmlInputEmail Email
        {
            get
            {
                return this.Find.ById<HtmlInputEmail>("username");
            }
        }

        public HtmlInputPassword Password
        {
            get
            {
                return this.Find.ById<HtmlInputPassword>("password");
            }
        }

        public HtmlButton LoginButton
        {
            get
            {
                return this.Find.ById<HtmlButton>("LoginButton");
            }
        }
    }
}
