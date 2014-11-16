using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATADataModel;
using AutomationTestAssistantCore;

namespace AutomationTestAssistantDesktopApp
{
    public class CurrentExecutionResultsViewModel
    {
        public CurrentExecutionResultsViewModel(ExecutionResultRun executionResultRun, List<TestResultRun> testResultRunsList)
        {
            testResultRunViewModels = new ObservableCollection<TestResultRunViewModel>();
            ExecutionResultRunViewModel = new ExecutionResultRunViewModel(executionResultRun);
            testResultRunsList.ForEach(r => testResultRunViewModels.Add(new TestResultRunViewModel(r)));
        }

        public ExecutionResultRunViewModel ExecutionResultRunViewModel { get; set; }


        private ObservableCollection<TestResultRunViewModel> testResultRunViewModels;

        public ObservableCollection<TestResultRunViewModel> ObservableTestResultRunViewModels
        {
            get
            {
                return testResultRunViewModels;
            }
            set
            {
                testResultRunViewModels = value;
            }
        }
    }
}
