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
    public class ProjectViewModel : ATADataModel.Project, INotifyPropertyChanged
    {
        private string localPath;
        public string LocalPath
        {
            get
            {
                return localPath;
            }
            set
            {
                localPath = value;
                OnPropertyChanged("LocalPath");
            }
        }

        public bool IsSelected { get; set; }
        public string UserName { get; set; }

        private void OnPropertyChanged(string property)
        {
            if (!String.IsNullOrEmpty(LocalPath))
            {
                ATACore.RegistryManager.WriterLocalPathToRegistry(UserName, TfsPath, LocalPath);
            }       
        }

        public ProjectViewModel(int projectId, string name, string tfsPath, string tfsUrl)
        {
            base.ProjectId = projectId;
            base.Name = name;
            base.TfsPath = tfsPath;
            base.TfsUrl = tfsUrl;
            WorkspacesForDelete = new List<string>();
            InitializeAdditionalPathsObservableCollection();
        }

        public ProjectViewModel(ATADataModel.Project project) : 
            this(project.ProjectId, project.Name, project.TfsPath, project.TfsUrl)
        {
            WorkspacesForDelete = new List<string>();
        }

        public ProjectViewModel(ATADataModel.Project project, string userName) :
            this(project.ProjectId, project.Name, project.TfsPath, project.TfsUrl)
        {
            LocalPath = ATACore.RegistryManager.GetProjectLocalPath(userName, TfsPath);
            WorkspacesForDelete = new List<string>();
        }

        private void InitializeAdditionalPathsObservableCollection()
        {
            additionalPaths = new ObservableCollection<AdditionalPathViewModel>();
            List<AdditionalPath> additionalPathsList = ATACore.Managers.AdditionalPathManager.GetAllAdditionalPathsByProjectId(ATACore.Managers.ContextManager.Context, ProjectId);
            ATACore.Managers.ContextManager.Context.Dispose();
            UserName = ATACore.RegistryManager.GetUserName();
            additionalPathsList.ForEach(p => additionalPaths.Add(new AdditionalPathViewModel(p, UserName)));
        }

        private ObservableCollection<AdditionalPathViewModel> additionalPaths;

        public ObservableCollection<AdditionalPathViewModel> ObservableAdditionalPaths
        {
            get
            {
                return additionalPaths;
            }
            set
            {
                additionalPaths = value;               
            }
        }

        public List<string> WorkspacesForDelete { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
