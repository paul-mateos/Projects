using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using ATADataModel;
using AutomationTestAssistantCore;
using AutomationTestAssistantCore.ExecutionEngine.Contracts;
using AutomationTestAssistantCore.ExecutionEngine.Messages;
using FirstFloor.ModernUI.App.Content;
using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;

namespace AutomationTestAssistantDesktopApp
{
    public partial class ExecutionResultsView : UserControl, IContent
    {
        public CurrentExecutionResultsViewModel CurrentExecutionResultsViewModel { get; set; }

        public ExecutionResultsView()
        {
        }    

        public void OnFragmentNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            FragmentManager fm = new FragmentManager(e.Fragment);
            string currentExecutionResultId = fm.Fragments["executionResultRunId"];
            ExecutionResultRun executionResultRun = ATACore.Managers.ExecutionResultRunManager.GetByExecutionResultRun(ATACore.Managers.ContextManager.Context, currentExecutionResultId);
            List<TestResultRun> testResultRuns = ATACore.Managers.TestResultRunManager.GetRunsByExecutionResultRun(ATACore.Managers.ContextManager.Context, currentExecutionResultId);
            CurrentExecutionResultsViewModel = new AutomationTestAssistantDesktopApp.CurrentExecutionResultsViewModel(executionResultRun, testResultRuns);
            ATACore.Managers.ContextManager.Dispose();
            mainGrid.DataContext = CurrentExecutionResultsViewModel;
            executionResultRunGrid.DataContext = CurrentExecutionResultsViewModel.ExecutionResultRunViewModel;
            testResultRunDataGrid.ItemsSource = CurrentExecutionResultsViewModel.ObservableTestResultRunViewModels;
        }

        public void OnNavigatedFrom(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
        }

        public void OnNavigatedTo(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
        }

        public void OnNavigatingFrom(FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs e)
        {
        }
    }
}
