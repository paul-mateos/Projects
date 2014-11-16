using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using CustomControls;
using System.Collections.ObjectModel;
using ATADataModel;
using AutomationTestAssistantCore;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Navigation;
using FirstFloor.ModernUI.Windows;

namespace AutomationTestAssistantDesktopApp
{
    public partial class AddAdditionalPathView : UserControl, IContent
    {
        private const string AdditionalPathSuccessfullyAddedMessage = "Additional Path successfully added!";
        public string ReturnUrl { get; set; }

        public AddAdditionalPathView()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);          
            window.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string tfsPath = tbTfsPath.Text;
            string tfsUrl = tbTfsUrl.Text;
            ATACore.Managers.AdditionalPathManager.AddNew(ATACore.Managers.ContextManager.Context, tfsPath, tfsUrl);
            ATACore.Managers.ContextManager.Context.Dispose();
            ModernDialog.ShowMessage(AdditionalPathSuccessfullyAddedMessage, "Success!", MessageBoxButton.OK);
            if (ReturnUrl.Equals("/AdminProjectSettingsView.xaml"))
            {
                Window window = Window.GetWindow(this);
                window.Close();
            }
            else
            {
                //AddSettingsWindow mnw = new AddSettingsWindow();
                //mnw.ContentSource = new Uri(ReturnUrl, UriKind.Relative);
                //mnw.Show();
                Navigator.Navigate(ReturnUrl, this);
            }
        }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
            FragmentManager fm = new FragmentManager(e.Fragment);
            ReturnUrl = fm.Fragments["returnUrl"];
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
        }
    }
}
