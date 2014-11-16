using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Threading;
using ATADataModel;
using AutomationTestAssistantCore;
using AutomationTestAssistantCore.ExecutionEngine.Messages;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;

namespace AutomationTestAssistantDesktopApp
{
    public partial class ProjectSettingsLoadingView : UserControl, IContent
    {  
        private delegate void UpdateProgress(string currentProgress);
        private delegate void NavigateToNextPage();
        public bool IsLoaded { get; set; }
        public List<string> AlreadyCreatedWorkspaces { get; set; }

        public ProjectSettingsLoadingView()
        {
            InitializeComponent();
            IsLoaded = false;
            AlreadyCreatedWorkspaces = new List<string>();
        }

        private void ProcessSelectedProjectInfos()
        {
            try
            {
                string tfsProjectPath = @"D:\AutomationTestAssistant\TfsOperations.proj";
                string currentUserName = ATACore.RegistryManager.GetUserName();
                string currentTfsUserName = ATACore.Managers.MemberManager.GetTfsUserNameByUserName(ATACore.Managers.ContextManager.Context, currentUserName);
                ATACore.Managers.ContextManager.Context.Dispose();
                List<Task> taskToBeExecuted = new List<Task>();
                taskToBeExecuted.Add(new Task(() => {}));
                foreach (var cTeam in MainWindow.AdminProjectSettingsViewModel.Teams)
                {
                    foreach (var cProject in cTeam.ObservableProjects)
                    {
                        if (!cProject.IsSelected)
                            continue;
                        string localPath = GetProjectLocalPath(currentUserName, cProject.TfsPath);
                        if (String.IsNullOrEmpty(localPath))
                            continue;
                        string workspaceName = ATACore.RegistryManager.GetWorkspaceName(currentUserName, localPath);
                        Task t = taskToBeExecuted[taskToBeExecuted.Count - 1].ContinueWith((antecedent) =>
                        {
                            if (!String.IsNullOrEmpty(workspaceName))
                            {
                                DeleteWorkSpaceIfExists(tfsProjectPath, currentTfsUserName, cProject.TfsUrl, MainWindow.LocalMsBuildLogIpSettings, workspaceName);
                                cProject.WorkspacesForDelete.Add(workspaceName);
                            }
                        });
                        taskToBeExecuted.Add(t);
                     
                        //IF ALREADY EXISTS IS GOING TO UPDATE THE OLD VALUE SHOULD BE TESTED!
                        string tfsUrl = cProject.TfsUrl;
                        string tfsPath = cProject.TfsPath;
                        IpAddressSettings cIS = MainWindow.LocalMsBuildLogIpSettings;
                        if (!AlreadyCreatedWorkspaces.Contains(tfsPath))
                        {
                            ATACore.Utilities.FilesDeleter.DeleteAllFilesAndFolders(localPath);
                            string newWorkspaceName = Guid.NewGuid().ToString();
                            Task t1 = taskToBeExecuted[taskToBeExecuted.Count - 1].ContinueWith((antecedent) => CreateNewWorkspace(tfsProjectPath, currentUserName, tfsUrl, tfsPath, localPath, cIS, newWorkspaceName));
                            taskToBeExecuted.Add(t1);
                            AlreadyCreatedWorkspaces.Add(tfsPath);
                        }
                        Task t2 = taskToBeExecuted[taskToBeExecuted.Count - 1].ContinueWith((antecedent) => GetLatest(tfsProjectPath, currentTfsUserName, localPath, cIS));
                        taskToBeExecuted.Add(t2);
                        PrepareAllCurrentProjectAddiotionalPaths(taskToBeExecuted, tfsProjectPath, currentUserName, currentTfsUserName, cProject, cIS);
                        string pName = cProject.Name;

                        Task t3 = taskToBeExecuted[taskToBeExecuted.Count - 1].ContinueWith((antecedent) => BuildCurrentProject(localPath, pName, cIS));
                        taskToBeExecuted.Add(t3);                       
                    }
                }
                Task finalTask = taskToBeExecuted[taskToBeExecuted.Count - 1].ContinueWith((antecedent) =>
                {
                    NavigateToNextPage ng = new NavigateToNextPage(Navigate);
                    mainGrid.Dispatcher.BeginInvoke(ng, DispatcherPriority.Send);
                });
               taskToBeExecuted.Add(finalTask);
               taskToBeExecuted[0].Start();                
            }
            catch(Exception ex)
            {
                return;
            }
        }

        private void PrepareAllCurrentProjectAddiotionalPaths(List<Task> taskToBeExecuted, string tfsProjectPath, string currentUserName, string currentTfsUserName, ProjectViewModel cProject, IpAddressSettings msBuildLoggerIpSettings)
        {
            foreach (var cAdditionalPath in cProject.ObservableAdditionalPaths)
            {
                string localPath = GetProjectLocalPath(currentUserName, cAdditionalPath.TfsPath);
                string workspaceName = ATACore.RegistryManager.GetWorkspaceName(currentUserName, localPath);
                string tfsUrl = cAdditionalPath.TfsUrl;
                string tfsPath = cAdditionalPath.TfsPath;

                Task t1 = taskToBeExecuted[taskToBeExecuted.Count - 1].ContinueWith((antecedent) =>
                {
                    if (!String.IsNullOrEmpty(workspaceName))
                    {
                        DeleteWorkSpaceIfExists(tfsProjectPath, currentTfsUserName, tfsUrl, msBuildLoggerIpSettings, workspaceName);
                        cAdditionalPath.WorkspacesForDelete.Add(workspaceName);
                    }
                });

                taskToBeExecuted.Add(t1);
         
                if (!AlreadyCreatedWorkspaces.Contains(tfsPath))
                {
                    ATACore.Utilities.FilesDeleter.DeleteAllFilesAndFolders(localPath);
                    string newWorkspaceName = Guid.NewGuid().ToString();
                    Task t2 = taskToBeExecuted[taskToBeExecuted.Count - 1].ContinueWith((antecedent) => CreateNewWorkspace(tfsProjectPath, currentUserName, tfsUrl, tfsPath, localPath, msBuildLoggerIpSettings, newWorkspaceName));
                    taskToBeExecuted.Add(t2);
                    AlreadyCreatedWorkspaces.Add(tfsPath);
                }
                Task t3 = taskToBeExecuted[taskToBeExecuted.Count - 1].ContinueWith((antecedent) => GetLatest(tfsProjectPath, currentTfsUserName, localPath, msBuildLoggerIpSettings));
                taskToBeExecuted.Add(t3);
            }
        }

        private void DisplayClientMessage(string text)
        {
            rtbStatus.AppendText(String.Format("\n{0}\n", text));
            rtbStatus.ScrollToEnd();
        }

        private void Navigate()
        {
                ModernWindow mw = Window.GetWindow(this) as ModernWindow;
                Uri u1 = new Uri("/TestsExecutionView.xaml", UriKind.Relative);
                mw.ContentSource = u1;
        }

        private void BuildCurrentProject(string localPath, string name, IpAddressSettings msBuildLoggerIpSettings)
        {
            Process currentlyExecutedProcess;
            MessageArgsBuild buildArgs = new MessageArgsBuild(localPath, name, msBuildLoggerIpSettings);
            currentlyExecutedProcess = ATACore.CommandLine.CommandLineExecutor.ExecuteBuild(buildArgs);
            currentlyExecutedProcess.WaitForExit(Int32.MaxValue);
        }      

        private void GetLatest(string tfsProjectPath, string currentTfsUserName, string localPath, IpAddressSettings msBuildLoggerIpSettings)
        {
            Process currentlyExecutedProcess;
            MessageArgsTfsGettingLatest tfsGetLatestArgs = new MessageArgsTfsGettingLatest(Command.TFGL, tfsProjectPath, msBuildLoggerIpSettings, localPath, currentTfsUserName);
            currentlyExecutedProcess = ATACore.CommandLine.CommandLineExecutor.ExecuteTfsGetLatest(tfsGetLatestArgs);
            currentlyExecutedProcess.WaitForExit(Int32.MaxValue);
        }    

        private void CreateNewWorkspace(string tfsProjectPath, string currentUserName, string tfsUrl, string tfsPath, string localPath, IpAddressSettings msBuildLoggerIpSettings, string newWorkspaceName)
        {
            MessageArgsWorkspaceCreation tfsWorkspaceCreationArgs = new MessageArgsWorkspaceCreation(Command.TFSWN, tfsProjectPath, tfsUrl, msBuildLoggerIpSettings, newWorkspaceName, tfsPath, localPath);
            Process currentlyExecutedProcess = ATACore.CommandLine.CommandLineExecutor.ExecuteTfsCreateNewWorkspace(tfsWorkspaceCreationArgs);
            currentlyExecutedProcess.WaitForExit(Int32.MaxValue);
            ATACore.RegistryManager.WriterWorkspaceNameToRegistry(currentUserName, localPath, newWorkspaceName);
        }

        private void DeleteWorkSpaceIfExists(string tfsProjectPath, string currentTfsUserName, string tfsUrl, IpAddressSettings msBuildLoggerIpSettings, string workspaceName)
        {
            if (!String.IsNullOrEmpty(workspaceName))
            {
                MessageArgsWorkspaceDeletion tfsWorkspaceDeletionArgs = new MessageArgsWorkspaceDeletion(Command.TFSWD, tfsProjectPath, msBuildLoggerIpSettings, tfsUrl, workspaceName, currentTfsUserName);
                Process currentlyExecutedProcess = ATACore.CommandLine.CommandLineExecutor.ExecuteTfsDeleteWorkspace(tfsWorkspaceDeletionArgs);
                currentlyExecutedProcess.WaitForExit(Int32.MaxValue);
            }
        }

        private string GetProjectLocalPath(string currentUserName, string tfsPath)
        {
            string localPath = ATACore.RegistryManager.GetProjectLocalPath(currentUserName, tfsPath);
            return localPath;
        }

        private void DisplayMsBuildLog()
        {
            UpdateProgress uiUpdater = new UpdateProgress(DisplayClientMessage);
            while (true)
            {
                try
                {
                    if (MainWindow.messagesToBeSend.Count > 0)
                    {
                        MessageArgsLogger msgArgs;
                        bool isDequeued = MainWindow.messagesToBeSend.TryDequeue(out msgArgs);
                        if (isDequeued)
                        {
                            rtbStatus.Dispatcher.BeginInvoke(uiUpdater, DispatcherPriority.Normal, msgArgs.LogMessage);
                            Thread.Sleep(50);
                        }
                    }
                }
                catch(Exception ex)
                {
                    break;
                }
            }
        }

        private void On_Loaded(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
            {
                MainWindow.MsBuildLogListnerThreadWorker =
                Task.Factory.StartNew(() => ATACore.TcpWrapperProcessor.TcpMsBuildLoggerProcessor.ProcessMsBuildLoggerMessage(MainWindow.messagesToBeSend, MainWindow.LocalMsBuildLogIpSettings), TaskCreationOptions.LongRunning);

                MainWindow.MessageLoggerThreadWorker = Task.Factory.StartNew(() => DisplayMsBuildLog());
                MainWindow.GetBuildThreadWorker = Task.Factory.StartNew(() => ProcessSelectedProjectInfos());
                IsLoaded = true;
            }
        
        }

        public void OnFragmentNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
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