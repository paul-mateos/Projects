using System;
using ArtOfTest.WebAii.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QA.UI.TestingFramework.Core
{
    [TestClass]
    public class BaseTest
    {
        public Browser Browser
        {
            get
            {
                return Manager.Current.ActiveBrowser;
            }
        }

        [TestInitialize]
        public void CoreTestInitialize()
        {
            this.InitizeBrowser();
            this.TestInit();
        }

        [TestCleanup]
        public void CoreTestCleanUp()
        {
            this.DisposeBrowser();
            this.TestCleanUp();
        }

        protected virtual void TestInit()
        {
        }

        protected virtual void TestCleanUp()
        {
        }
  
        private void DisposeBrowser()
        {
            foreach (var currentBrowser in Manager.Current.Browsers)
            {
                currentBrowser.Close();
            }
            Manager.Current.Dispose();
        }

        private void InitizeBrowser()
        {
            Settings mySettings = new Settings();
            mySettings.DisableDialogMonitoring = true;
            mySettings.Web.DefaultBrowser = BrowserType.InternetExplorer;
            mySettings.Web.KillBrowserProcessOnClose = true;
            var manager = new Manager(mySettings);
            manager.Start();
            Manager.Current.LaunchNewBrowser();
        }
    }
}
