using QA.UI.TestingFramework.Core.Contracts;

namespace QA.Telerik.Core.Pages.LoginPage
{
    public class LoginPage : ILogin
    {       
        public LoginPageMap Map 
        {
            get
            {
                return new LoginPageMap();
            }
        }

        public LoginPageValidator Validator
        {
            get
            {
                return new LoginPageValidator();
            }
        }

        public void TypeEmail(string email)
        {
            this.Map.Email.Text = email;
        }

        public void TypePassword(string password)
        {
            this.Map.Password.Text = password;
        }

        public void Submit()
        {
            this.Map.LoginButton.Click();
        }
    }
}
