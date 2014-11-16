using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using ATADataModel;
using AutomationTestAssistantCore;
using FirstFloor.ModernUI.Windows.Controls;

namespace AutomationTestAssistantDesktopApp
{
    public partial class AdminProjectSettingsView : UserControl
    {
        public AdminProjectSettingsViewModel AdminProjectSettingsViewModel { get; set; }
        public AdminProjectSettingsView()
        {
            InitializeComponent();
        }
        private void btnCreateTeam_Click(object sender, RoutedEventArgs e)
        {
            AddSettingsWindow mnw = new AddSettingsWindow();
            mnw.Show();
        }

        private void brnCreateProject_Click(object sender, RoutedEventArgs e)
        {
            AddSettingsWindow mnw = new AddSettingsWindow();
            mnw.ContentSource = new Uri("/AddProjectView.xaml#returnUrl=/AdminProjectSettingsView.xaml", UriKind.Relative);            
            mnw.Show();
        }

        private void btnCreateAdditionalPath_Click(object sender, RoutedEventArgs e)
        {
            AddSettingsWindow mnw = new AddSettingsWindow();
            mnw.ContentSource = new Uri("/AddAdditionalPathView.xaml#returnUrl=/AdminProjectSettingsView.xaml", UriKind.Relative);
            mnw.Show();
        }

        private void brnCreateMachine_Click(object sender, RoutedEventArgs e)
        {
            AddSettingsWindow mnw = new AddSettingsWindow();
            mnw.ContentSource = new Uri("/AddAgentMachineView.xaml#returnUrl=/AdminProjectSettingsView.xaml", UriKind.Relative);
            mnw.Show();
        }
    }
}
