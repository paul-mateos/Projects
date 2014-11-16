using Microsoft.VisualStudio.TestTools.UnitTesting;
using QA.TelerikAcademy.Core.Base;
using QA.UI.TestingFramework.Core;
using QA.UI.TestingFramework.Core.Data;

namespace QA.TelerikAcademy.Tests
{
    [TestClass]
    public class PopulateSettings : BaseTest
    {
        private User currentUser;

        public SettingsService SettingsService { get; set; }

        public override void TestInit()
        {
            this.SettingsService = new Core.Base.SettingsService();
            this.currentUser = new User()
            {
                Email = "b114314@trbvm.com",
                Password = "123456",
                Username = "bosilchokurkov",
                FirstName = "FirstName",
                LastName = "LastName"
            };
        }

        [TestMethod]
        public void UpdateSettings_Valid()
        {
            this.SettingsService.UpdateSettings(this.currentUser);
        }
    }
}
