using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ATADataModel;
using AutomationTestAssistantCore;

namespace AutomationTestAssistantDesktopApp
{
    public class CurrentExecutionViewModel 
    {
        public List<string> CommandsToBeExecuted { get; set; }

        public IpAddressSettings CurrentAgentMachineExecutionIpSettings { get; set; }

        public IpAddressSettings CurrentAgentMachineMsBuildLogIpSettings { get; set; }

        public TestsExecutionViewModel TestsExecutionViewModel { get; set; }

        public List<string> AlreadyCreatedWorkspaces { get; set; }

        public ConcurrentQueue<string> MessagesToBeDisplayed { get; set; }

        public AgentMachineViewModel CurrentSelectedMachine { get; set; }

        public CurrentExecutionViewModel(TestsExecutionViewModel testsExecutionViewModel)
        {
            
            TestsExecutionViewModel = testsExecutionViewModel;
            AlreadyCreatedWorkspaces = new List<string>();
            MessagesToBeDisplayed = new ConcurrentQueue<string>();
            CommandsToBeExecuted = new List<string>();
            CurrentSelectedMachine = TestsExecutionViewModel.GetCurrentlySelectedExecutionMachine();
            CurrentAgentMachineExecutionIpSettings = new IpAddressSettings(CurrentSelectedMachine.Ip, "8888");
            CurrentAgentMachineMsBuildLogIpSettings = new IpAddressSettings(CurrentSelectedMachine.Ip, "8889");
            GenerateMessagesToBeSentToAgent();
        }

        private void GenerateMessagesToBeSentToAgent()
        {
            string currentUserName = ATACore.RegistryManager.GetUserName();
            string currentTfsUserName = ATACore.Managers.MemberManager.GetTfsUserNameByUserName(ATACore.Managers.ContextManager.Context, currentUserName);
            ATACore.Managers.ContextManager.Context.Dispose();


            string msTestProj = ATACore.Project.ProjectInfoCollector.GetMsTestProjectPath(CurrentSelectedMachine.WorkingDirPath);
            string tfsProj = ATACore.Project.ProjectInfoCollector.GetTfsProjectPath(CurrentSelectedMachine.WorkingDirPath);
            List<string> selectedProjectsLocalPaths = new List<string>();
            List<string> selectedProjectsAgentPaths = new List<string>();
            foreach (var cTeam in MainWindow.AdminProjectSettingsViewModel.Teams)
            {
                foreach (var cProject in cTeam.ObservableProjects)
                {
                    if (!cProject.IsSelected)
                        continue;
                    
                    string tfsUrl = cProject.TfsUrl;
                    string tfsPath = cProject.TfsPath;
                    string pName = cProject.Name;
                    string localPath = ATACore.Project.ProjectInfoCollector.MapWorkingDirTfsPath(CurrentSelectedMachine.WorkingDirPath, cProject.TfsPath);
                    string agentCurrentProjReleaseDllPath = ATACore.Project.ProjectInfoCollector.GetAssemblyReleasePathByProjectFFullPath(pName, localPath);
                    selectedProjectsAgentPaths.Add(agentCurrentProjReleaseDllPath);
                    string currentMachineLocalPath = ATACore.RegistryManager.GetProjectLocalPath(currentUserName, tfsPath);
                    selectedProjectsLocalPaths.Add(currentMachineLocalPath);
                    string workspaceName = ATACore.RegistryManager.GetWorkspaceName(currentUserName, cProject.LocalPath);

                    GenerateProjectWorkspaceDeletionMessages(currentTfsUserName, tfsProj, tfsUrl, cProject.WorkspacesForDelete);
                    GenerateProjectWorkspaceCreationMessages(tfsProj, tfsUrl, tfsPath, localPath, workspaceName);
                    CommandsToBeExecuted.Add(ATACore.CommandExecutor.GenerateTfsGetLatestMessage(tfsProj, localPath, currentTfsUserName, CurrentAgentMachineMsBuildLogIpSettings));
                    PrepareAllCurrentProjectAddiotionalPaths(currentUserName, currentTfsUserName, cProject, CurrentSelectedMachine, msTestProj, tfsProj);
                    CommandsToBeExecuted.Add(ATACore.CommandExecutor.GenerateBuildMessage(localPath, pName, CurrentAgentMachineMsBuildLogIpSettings));
                  
                }
            }
            string resultsFilePath = GenerateTestExecutionCommand(CurrentSelectedMachine, msTestProj, selectedProjectsLocalPaths, selectedProjectsAgentPaths);
            CommandsToBeExecuted.Add(ATACore.CommandExecutor.GenerateResultParseMessage(resultsFilePath, currentUserName, CurrentAgentMachineMsBuildLogIpSettings));
        }

        private string GenerateTestExecutionCommand(AgentMachineViewModel currentSelectedMachine, string msTestProj, List<string> selectedProjectsLocalPaths, List<string> selectedProjectsAgentPaths)
        {
            List<string> selectedTestsMethodIds = new List<string>();
            GetSelectedTestsMethodIds(selectedTestsMethodIds);

            List<string> assembliesPaths = ATACore.Project.ProjectInfoCollector.GetAssemblyPathsByProjectPaths(selectedProjectsLocalPaths);
            List<TestLink> testLinks = ATACore.TestExecution.TestListGenerator.GetProjectTestLinksMultipleAssemblies(assembliesPaths, selectedProjectsAgentPaths);
            MethodInfo[] methodInfos = ATACore.Project.ProjectInfoCollector.GetProjectTestMethodsMultipleAssemblies(assembliesPaths);
            testLinks = ATACore.TestExecution.TestListGenerator.RemoveTestLinksNotSpecifiedIds(selectedTestsMethodIds, testLinks);
            string listName = Guid.NewGuid().ToString();
            string testListContent = ATACore.TestExecution.TestListGenerator.GenerateListOfSpecifiedTests(testLinks, listName);

            string uniqueTestResultName = ATACore.Utilities.TimeStampGenerator.GenerateTrxFilePath(currentSelectedMachine.WorkingDirPath);
        
            string messageToBeSend = ATACore.CommandExecutor.GenerateMsTestMessage(msTestProj, testListContent, uniqueTestResultName, listName, CurrentAgentMachineMsBuildLogIpSettings, currentSelectedMachine.WorkingDirPath);
            CommandsToBeExecuted.Add(messageToBeSend);

            return uniqueTestResultName;
        }

        private void GetSelectedTestsMethodIds(List<string> selectedTestsMethodIds)
        {
            foreach (var cT in TestsExecutionViewModel.Teams)
            {
                foreach (var cProject in cT.ObservableProjects)
                {
                    List<string> currentSelectedTestsMethodIds = cProject.ObservableTests.ToList().Where(t => t.IsSelected.Equals(true)).Select(x => x.MethodId).ToList();
                    selectedTestsMethodIds.AddRange(currentSelectedTestsMethodIds);
                }
            }
        }

        private void GenerateProjectWorkspaceCreationMessages(string tfsProj, string tfsUrl, string tfsPath, string localPath, string workspaceName)
        {
            if (!AlreadyCreatedWorkspaces.Contains(tfsPath))
            {
                CommandsToBeExecuted.Add(ATACore.CommandExecutor.GenerateCreateWorkspacetMessage(tfsProj, tfsUrl, workspaceName, tfsPath, localPath, CurrentAgentMachineMsBuildLogIpSettings));
                AlreadyCreatedWorkspaces.Add(tfsPath);
            }
        }

        private void GenerateProjectWorkspaceDeletionMessages(string currentTfsUserName, string tfsProj, string tfsUrl, List<string> workspacesForDeletion)
        {
            foreach (var cWorkspace in workspacesForDeletion)
            {
                CommandsToBeExecuted.Add(ATACore.CommandExecutor.GenerateDeleteWorkspacetMessage(tfsProj, tfsUrl, cWorkspace, currentTfsUserName, CurrentAgentMachineMsBuildLogIpSettings));
            }
        }

        private void PrepareAllCurrentProjectAddiotionalPaths(string currentUserName, string currentTfsUserName, ProjectViewModel cProject, AgentMachineViewModel currentSelectedMachine, string msTestProjPath, string tfsProj)
        {
            foreach (var cAdditionalPath in cProject.ObservableAdditionalPaths)
            {
                string localPath = ATACore.Project.ProjectInfoCollector.MapWorkingDirTfsPath(currentSelectedMachine.WorkingDirPath, cProject.TfsPath);
                string workspaceName = ATACore.RegistryManager.GetWorkspaceName(currentUserName, localPath);
                string tfsUrl = cAdditionalPath.TfsUrl;
                string tfsPath = cAdditionalPath.TfsPath;

                GenerateProjectWorkspaceDeletionMessages(currentTfsUserName, tfsProj, tfsUrl, cAdditionalPath.WorkspacesForDelete);
                GenerateProjectWorkspaceCreationMessages(tfsProj, tfsUrl, tfsPath, localPath, workspaceName);
                CommandsToBeExecuted.Add(ATACore.CommandExecutor.GenerateTfsGetLatestMessage(tfsProj, localPath, currentTfsUserName, CurrentAgentMachineMsBuildLogIpSettings));
            }
        }
    }
}
