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
    public class AllResultsViewModel
    {
        public AllResultsViewModel(string userName)
        {
            List<Team> teams = ATACore.Managers.TeamManager.GetAllUserTeams(ATACore.Managers.ContextManager.Context, userName);
            List<ExecutionResultRun> executionResultRuns = ATACore.Managers.ExecutionResultRunManager.GetAllByTeams(ATACore.Managers.ContextManager.Context, teams);
            ATACore.Managers.ContextManager.Dispose();
            executionResultRunViewModels = new ObservableCollection<ExecutionResultRunViewModel>();
            executionResultRuns.ForEach(e => executionResultRunViewModels.Add(new ExecutionResultRunViewModel(e)));
        }


        private ObservableCollection<ExecutionResultRunViewModel> executionResultRunViewModels;

        public ObservableCollection<ExecutionResultRunViewModel> ObservableExecutionResultRunViewModels
        {
            get
            {
                return executionResultRunViewModels;
            }
            set
            {
                executionResultRunViewModels = value;
            }
        }
    }
}
