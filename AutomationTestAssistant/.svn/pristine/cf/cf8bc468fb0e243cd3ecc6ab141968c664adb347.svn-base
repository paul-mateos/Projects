using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATADataModel;
using AutomationTestAssistantCore;
using CustomControls;

namespace AutomationTestAssistantDesktopApp
{
    public class TeamCheckedItemViewModel : Team
    {
        public TeamCheckedItemViewModel(int id, string name)
        {
            base.TeamId = id;
            base.Name = name;
            projects = new ObservableCollection<CheckedItem>();
            agentMachines = new ObservableCollection<CheckedItem>();
            List<ATADataModel.Project> projectsList = ATACore.Managers.ProjectManager.GetAllProjectsByTeamId(ATACore.Managers.ContextManager.Context, TeamId);

            projectsList.ForEach(p => projects.Add(new CheckedItem(p.Name)));
            List<ATADataModel.AgentMachine> agentMachinesList = ATACore.Managers.AgentMachineManager.GetAllAgentMachinesByTeamId(ATACore.Managers.ContextManager.Context, TeamId);
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
