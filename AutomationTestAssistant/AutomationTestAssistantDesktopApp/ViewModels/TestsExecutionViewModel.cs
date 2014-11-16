using System.Collections.Generic;
using ATADataModel;
using FirstFloor.ModernUI.Presentation;
using AutomationTestAssistantCore;
using System.Collections.ObjectModel;

namespace AutomationTestAssistantDesktopApp
{
    public class TestsExecutionViewModel : NotifyPropertyChanged
    {
        public ObservableCollection<TeamTestsExecutionViewModel> Teams { get; set; }
        public string UserName { get; set; }

        public TestsExecutionViewModel(AdminProjectSettingsViewModel adminProjectSettingsViewModel)
        {
            Teams = new ObservableCollection<TeamTestsExecutionViewModel>();
            foreach (var cT in adminProjectSettingsViewModel.Teams)
            {
                bool hasSelectedProjects = AreThereSelectedProjects(cT.ObservableProjects);
                if (!hasSelectedProjects)
                    continue;
                Teams.Add(new TeamTestsExecutionViewModel(cT.TeamId, cT.Name, cT.ObservableProjects, cT.ObservableAgentMachines));
            }
        }

        public AgentMachineViewModel GetCurrentlySelectedExecutionMachine()
        {
            AgentMachineViewModel machine = null;
            foreach (var cT in Teams)
            {
                foreach (var cM in cT.ObservableAgentMachines)
                {
                    if(cM.IsSelected)
                    {
                        machine = cM;
                        break;
                    }
                }
            }
            return machine;
        }

        private bool AreThereSelectedProjects(ObservableCollection<ProjectViewModel> observableCollection)
        {
            bool areThereSelectedProjects = false;
            foreach (var cP in observableCollection)
            {
                if(cP.IsSelected)
                {
                    areThereSelectedProjects = true;
                    break;
                }
            }
            return areThereSelectedProjects;
        }

        public ObservableCollection<TeamTestsExecutionViewModel> GetTeams()
        {
            return Teams;
        }
    }
}
