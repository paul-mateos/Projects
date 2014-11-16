using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QA.UI.TestingFramework.Core;
using QA.TelerikAcademy.Core.Pages.LoginPage;
using QA.UI.TestingFramework.Core.Data;

namespace QA.TelerikAcademy.Tests
{
    [TestClass]
    public class UpdateSettings : BaseTest
    {
        private User currentUser;

        protected override void TestInit()
        {
            currentUser = new User()
            {
                Email = "b114314@trbvm.com",
                Password = "123456"
            };
        }
        [TestMethod]
        public void Update()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Navigate();
            loginPage.Login(currentUser);
        }
    }
}
