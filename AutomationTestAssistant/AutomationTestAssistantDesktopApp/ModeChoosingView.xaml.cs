using System;
using System.Windows;
using System.Windows.Controls;
using FirstFloor.ModernUI.Windows.Controls;

namespace AutomationTestAssistantDesktopApp
{
    public partial class ModeChoosingView : UserControl
    {

        public ModeChoosingView()
        {
            InitializeComponent();      
        }

        private void btnExecutionMode_Click_1(object sender, RoutedEventArgs e)
        {
            ModernWindow mw = Window.GetWindow(this) as ModernWindow;
            mw.MenuLinkGroups.Clear();
            Uri u1 = new Uri("/BeforeExecutionProjectSettingsView.xaml", UriKind.Relative);
            mw.ContentSource = u1;
        }

        private void btnResultsMode_Click_1(object sender, RoutedEventArgs e)
        {
            ModernWindow mw = Window.GetWindow(this) as ModernWindow;
            mw.MenuLinkGroups.Clear();
            Uri u1 = new Uri("/AllResultsView.xaml", UriKind.Relative);
            mw.ContentSource = u1;
        }
    }
}