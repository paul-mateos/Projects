using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QA.UI.TestingFramework.Core;
using QA.UI.TestingFramework.Core.Data;
using QA.Telerik.Core.Base;

namespace QA.Telerik.Tests
{
    [TestClass]
    public class Login : BaseTest
    {
        private User currentUser;

        public override void TestInit()
        {
            this.currentUser = new User()
            {
                Email = "b277315@trbvm.com",
                Password = "123456",
                Username = "bosilchokurkov",
                FirstName = "Genadi",
                LastName = "Berkov"
            };
        }

        [TestMethod]
        public void Login_Telerik_Provider()
        {
            AccountLoginProvider.Instance.LoginUser(currentUser);
        }

        [TestMethod]
        public void Login_Telerik_Provider_Dynamic()
        {
            DynamicAccountLoginProvider.Instance.LoginUser(currentUser);
        }
    }
}