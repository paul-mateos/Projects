using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ATADataModel;
using CustomControls;
using FirstFloor.ModernUI.Presentation;
using AutomationTestAssistantCore;
using System.Collections.ObjectModel;

namespace AutomationTestAssistantDesktopApp
{
    public class AddTeamViewModel : NotifyPropertyChanged
    {
        public string UserName { get; set; }

        public AddTeamViewModel GetAddTeamViewModel()
        {
            return new AddTeamViewModel();
        }

        public AddTeamViewModel()
        {
            UserName = ATACore.RegistryManager.GetUserName();
            projects = new ObservableCollection<CheckedItem>();
            agentMachines = new ObservableCollection<CheckedItem>();
            List<ATADataModel.Project> projectsList = ATACore.Managers.ProjectManager.GetAll(ATACore.Managers.ContextManager.Context);

            projectsList.ForEach(p => projects.Add(new CheckedItem(p.Name)));
            List<ATADataModel.AgentMachine> agentMachinesList = ATACore.Managers.AgentMachineManager.GetAll(ATACore.Managers.ContextManager.Context);
            agentMachinesList.ForEach(a => agentMachines.Add(new CheckedItem(a.Name)));
            ATACore.Managers.ContextManager.Context.Dispose();
        }

        private ObservableCollection<CheckedItem> projects;

        public ObservableCollection<CheckedItem> ObservableProjects
        {
            get
            {
                return projects;
            }
            set
            {
                projects = value;
               
            }
        }

        private ObservableCollection<CheckedItem> agentMachines;

        public ObservableCollection<CheckedItem> ObservableAgentMachines
        {
            get
            {
                return agentMachines;
            }
            set
            {
                agentMachines = value;

            }
        }
    }
}
