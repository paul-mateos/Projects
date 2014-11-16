using System;
using System.Windows;
using System.Windows.Controls;
using AutomationTestAssistantCore;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;

namespace AutomationTestAssistantDesktopApp
{
    public partial class AllResultsView : UserControl
    {
        public AllResultsViewModel AllResultsViewModel { get; set; }

        public AllResultsView()
        {
           
        }    

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            ExecutionResultRunViewModel currentExecutionResultViewModel = ((FrameworkElement)sender).DataContext as ExecutionResultRunViewModel;
            ModernWindow mw = Window.GetWindow(this) as ModernWindow;
            Uri u1 = new Uri(String.Format("/ExecutionResultsView.xaml#executionResultRunId={0}", currentExecutionResultViewModel.ExecutionResultRunId), UriKind.Relative);
            mw.ContentSource = u1;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {            
            string currentUserName = ATACore.RegistryManager.GetUserName();
            AllResultsViewModel = new AllResultsViewModel(currentUserName);
            allTestResultRunsDataGrid.ItemsSource = AllResultsViewModel.ObservableExecutionResultRunViewModels;
        }
    }
}
