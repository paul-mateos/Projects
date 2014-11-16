using ArtOfTest.WebAii.Core;
using QA.UI.TestingFramework.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.TelerikAcademy.Core.Pages.LoginPage
{
    public class LoginPage
    {
        public const string LoginUrl = @"https://telerikacademy.com/Users/Auth/Login";     

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

        public void Navigate()
        {
            Manager.Current.ActiveBrowser.NavigateTo(LoginUrl);
        }

        public void Login(User user)
        {
            this.Map.UserName.Text = user.Email;
            this.Map.Password.Text = user.Password;
            this.Map.Submit.Click();
            Manager.Current.ActiveBrowser.WaitUntilReady();
        }
    }
}
