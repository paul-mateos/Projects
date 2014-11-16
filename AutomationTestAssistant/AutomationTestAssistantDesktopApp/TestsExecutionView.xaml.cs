using System;
using System.Windows;
using System.Windows.Controls;
using FirstFloor.ModernUI.Windows.Controls;

namespace AutomationTestAssistantDesktopApp
{
    public partial class TestsExecutionView : UserControl
    {  
        public TestsExecutionViewModel TestsExecutionViewModel { get; set; }
        public TestsExecutionView()
        {
            InitializeComponent();
            TestsExecutionViewModel = new TestsExecutionViewModel(MainWindow.AdminProjectSettingsViewModel);
            mainGrid.DataContext = TestsExecutionViewModel.GetTeams();        
        }

        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExecutionWindow w = new ExecutionWindow(new CurrentExecutionViewModel(TestsExecutionViewModel));
                w.Show();
            }
            catch(Exception ex)
            {
                ModernDialog.ShowMessage(String.Concat(ex.Message, " ", ex.StackTrace), "Exception!", MessageBoxButton.OK);
            }
        }
    }
}