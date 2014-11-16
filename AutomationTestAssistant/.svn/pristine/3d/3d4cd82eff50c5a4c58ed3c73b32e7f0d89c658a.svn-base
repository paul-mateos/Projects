using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;
using System.Reflection;
using AutomationTestAssistantCore;
using AutomationTestAssistantCore.ExecutionEngine.Contracts;
using AutomationTestAssistantCore.ExecutionEngine.Messages;
using System.Collections.Concurrent;

namespace ServerClient
{
    public partial class Main : Form
    {
        private TcpClient clientTcpWriter;
        private TcpClient clientTcpListner;
        private delegate void UpdateProgress(string currentProgress);
        private bool isConnected;
        private List<string> testIds;
        private string relativeMsTestProjPath = "\\..\\..\\..\\..\\MsTest.proj";
        private string relativeTfsProjPath = "\\..\\..\\..\\..\\TfsOperations.proj";
        private string msTestProjFullPath;
        private string tfsProjFullPath;
        private IpAddressSettings clientSettings;
        private IpAddressSettings agentSettings;
        private IpAddressSettings msBuildLogSettings;
        private static ConcurrentQueue<string> messagesToBeDisplayed;

        public Main()
        {
            InitializeComponent();
            testIds = new List<string>();
            BuildMsBuildProjectsFullPaths();
            GetIpsInformation();
            messagesToBeDisplayed = new ConcurrentQueue<string>();
            dgvProjects.Rows[0].Cells[0].Value = @"D:\AutomationTestAssistant\TestTime\TestTime.csproj";
        }

        private void GetIpsInformation()
        {
            agentSettings = new IpAddressSettings(tbAgentIp.Text);
            clientSettings = new IpAddressSettings(tbClientIp.Text);
            msBuildLogSettings = new IpAddressSettings(tbMsBuildLogIp.Text);
        }

        private void TestGetIpsInformation()
        {
            agentSettings = new IpAddressSettings("127.0.0.1:8887");
            clientSettings = new IpAddressSettings("127.0.0.1:8888");
            msBuildLogSettings = new IpAddressSettings("127.0.0.1:8889");
        }

        private void BuildMsBuildProjectsFullPaths()
        {
            string currentExecutablePath = Assembly.GetExecutingAssembly().Location;

            string asseblyFullPath = String.Concat(currentExecutablePath, relativeMsTestProjPath);
            msTestProjFullPath = Path.GetFullPath(asseblyFullPath);
            asseblyFullPath = String.Concat(currentExecutablePath, relativeTfsProjPath);
            tfsProjFullPath = Path.GetFullPath(asseblyFullPath);
        }      

        private void btnSendData_Click(object sender, EventArgs e)
        {
            List<string> projectPaths = GetProjectPaths();
            //List<string> assembliesPaths = ATACore.Project.ProjectInfoCollector.GetAssemblyPathsByProjectPaths(projectPaths);
            //List<TestLink> testLinks = ATACore.TestExecution.TestListGenerator.GetProjectTestLinksMultipleAssemblies(assembliesPaths);
            //MethodInfo[] methodInfos = ATACore.Project.ProjectInfoCollector.GetProjectTestMethodsMultipleAssemblies(assembliesPaths);
            //List<string> testIdsToBeExecuted = FilterCheckedTests();
            //testLinks = ATACore.TestExecution.TestListGenerator.RemoveTestLinksNotSpecifiedIds(testIdsToBeExecuted, testLinks);
            //string testListContent = ATACore.TestExecution.TestListGenerator.GenerateListOfSpecifiedTests(testLinks);          

            //string uniqueTestResultName = ATACore.Utilities.TimeStampGenerator.GenerateTrxFilePath();
            ////HACK NEED TO BE REWRITTEN, Test Links STORAGE Should be mapped to the get latest on the agent
            //string messageToBeSend = ATACore.CommandExecutor.GenerateMsTestMessage(msTestProjFullPath.Replace("D", "C"), testListContent.Replace("D:\\", "C:\\"), uniqueTestResultName, tbListName.Text, msBuildLogSettings);

            //ATACore.TcpWrapperProcessor.TcpClientWrapper.SendMessageToClient(clientTcpWriter, messageToBeSend);
        }       

        private void btnClose_Click(object sender, EventArgs e)
        {
            isConnected = false;
            clientTcpWriter.Close();
            clientTcpListner.Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            //TestGetIpsInformation();
            GetIpsInformation();
            backgroundWorker2.RunWorkerAsync();
            UpdateProgress uiUpdater = new UpdateProgress(DisplayClientMessage);
            clientTcpWriter = new TcpClient();
            clientTcpListner = new TcpClient();
            clientTcpWriter.Connect(agentSettings.IpString, clientSettings.Port);
            clientTcpListner.Connect(agentSettings.IpString, clientSettings.Port);   
            isConnected = true;   
            rtbMain.Text = "Client Socket Program - Server Connected ...";

            backgroundWorker1.RunWorkerAsync();
        }

        // Will update the status of the agents execution until the client is connected with the agent.
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (isConnected)
            {
                string messageStr = ATACore.TcpWrapperProcessor.TcpClientWrapper.ReadLargeClientMessage(clientTcpListner);
                messageStr = messageStr.CleanMessageEnd();
          
                messagesToBeDisplayed.Enqueue(messageStr);
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateProgress uiUpdater = new UpdateProgress(DisplayClientMessage);
            UpdateProgress uiUpdater1 = new UpdateProgress(DisplayMsBuildLogMessage);
            string msgArgsStr;
            MessageArgsLogger messageArgs;
            while (true)
            {
                if (messagesToBeDisplayed.Count > 0)
                {
                    bool isDequeued = messagesToBeDisplayed.TryDequeue(out msgArgsStr);
                    if (isDequeued)
                    {
                        messageArgs = (MessageArgsLogger)ATACore.CommandExecutor.MessageDeserializer(msgArgsStr, typeof(MessageArgsLogger));
                        switch (messageArgs.MessageSource)
                        {
                            case MessageSource.MsBuildLogger:
                                this.Invoke(uiUpdater1, messageArgs.LogMessage);
                                break;
                            case MessageSource.EnqueueLogger:
                            case MessageSource.DenqueueLogger:
                            case MessageSource.ExecutionLogger:
                                this.Invoke(uiUpdater, messageArgs.LogMessage);
                                break;
                        }
                    }
                }
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            rtbMain.Text = String.Empty;
            rtbMsBuild.Text = String.Empty;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshInternal();
        }     

        private void btnCreateWorkspaces_Click(object sender, EventArgs e)
        {            
            for (int i = 0; i < dgvWorkspaces.Rows.Count; i++)
            {
                string currentTfsPath = dgvWorkspaces.Rows[i].Cells[0].Value.ToString();
                string currentLocalPath = dgvWorkspaces.Rows[i].Cells[1].Value.ToString();
                string currentCollection = dgvWorkspaces.Rows[i].Cells[2].Value.ToString();
                string currentServerUrl = String.Concat(tfsServerUrl.Text, currentCollection);
                string currentWorkspaceName = Guid.NewGuid().ToString();
                dgvWorkspaces.Rows[i].Cells[3].Value = currentWorkspaceName;                
                string messageToBeSend = ATACore.CommandExecutor.GenerateCreateWorkspacetMessage(tfsProjFullPath, currentServerUrl, currentWorkspaceName, currentTfsPath, currentLocalPath, agentSettings);
                ATACore.TcpWrapperProcessor.TcpClientWrapper.SendMessageToClient(clientTcpWriter, messageToBeSend);            
            }           
        }

        private void btnDeleteWorkspaces_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvWorkspaces.Rows.Count; i++)
            {
                string currentTfsPath = dgvWorkspaces.Rows[i].Cells[1].Value.ToString();
                string currentLocalPath = dgvWorkspaces.Rows[i].Cells[2].Value.ToString();
                string currentCollection = dgvWorkspaces.Rows[i].Cells[2].Value.ToString();
                string currentServerUrl = String.Concat(tfsServerUrl.Text, currentCollection);
                string currentWorkspaceName = dgvWorkspaces.Rows[i].Cells[3].Value.ToString();
                string messageToBeSend = ATACore.CommandExecutor.GenerateDeleteWorkspacetMessage(tfsProjFullPath, currentServerUrl, currentWorkspaceName, tbUserName.Text, agentSettings);
                ATACore.TcpWrapperProcessor.TcpClientWrapper.SendMessageToClient(clientTcpWriter, messageToBeSend);
            }
        }

        private void btnGetLatest_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvWorkspaces.Rows.Count; i++)
            {
                string currentTfsPath = dgvWorkspaces.Rows[i].Cells[1].Value.ToString();
                string currentLocalPath = dgvWorkspaces.Rows[i].Cells[2].Value.ToString();
                string currentCollection = dgvWorkspaces.Rows[i].Cells[2].Value.ToString();
                string currentServerUrl = String.Concat(tfsServerUrl.Text, currentCollection);
                string messageToBeSend = ATACore.CommandExecutor.GenerateTfsGetLatestMessage(tfsProjFullPath, currentLocalPath, tbUserName.Text, agentSettings);
                ATACore.TcpWrapperProcessor.TcpClientWrapper.SendMessageToClient(clientTcpWriter, messageToBeSend);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            SendDisconnectMessage();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            SendDisconnectMessage();
        }

        private void btnStopCurrentlyExecutedProcess_Click(object sender, EventArgs e)
        {
            SendKillCurrentlyExecutedProcessMessage();
        }

        #region Private Helper methods    
        private void SendDisconnectMessage()
        {
            ATACore.TcpWrapperProcessor.TcpClientWrapper.SendMessageToClient(clientTcpWriter, String.Format("{0}#", Command.DISCONNECT.ToString()));
        }

        private void SendKillCurrentlyExecutedProcessMessage()
        {
            ATACore.TcpWrapperProcessor.TcpClientWrapper.SendMessageToClient(clientTcpWriter, String.Format("{0}#", Command.KILL.ToString()));
        }

        private void AddMethodsToCheckBoxListInternal(string currentProjectDllPath, MethodInfo[] currentDllMethods)
        {
            int i = 0;
            foreach (MethodInfo currentMethodInfo in currentDllMethods)
            {
                dgvMethods.Rows.Add(new DataGridViewRow());
                dgvMethods.Rows[i].Cells[1].Value = currentMethodInfo.Name;
                dgvMethods.Rows[i].Cells[2].Value = currentMethodInfo.DeclaringType.FullName;
                dgvMethods.Rows[i].Cells[3].Value = ATACore.TestExecution.TestListGenerator.GenerateTestMethodId(currentMethodInfo, currentProjectDllPath);
                i++;
            }
        }

        private void RefreshInternal()
        {
            for (int i = 0; i < dgvProjects.Rows.Count; i++)
            {
                string currentProjectPath = String.Empty;
                if (dgvProjects.Rows[i].Cells[0].Value != null)
                {
                    currentProjectPath = dgvProjects.Rows[i].Cells[0].Value.ToString();
                }
                AddMethodsForProjectInternal(currentProjectPath);
            }
        }

        private void AddMethodsForProjectInternal(string currentProjectPath)
        {
            if (File.Exists(currentProjectPath))
            {
                //ATACore.Project.ProjectBuilder.BuildProject(currentProjectPath);
                //string currentProjectDllPath = ATACore.Project.ProjectInfoCollector.GetAssemblyPathByProjectPath(currentProjectPath);
                //MethodInfo[] currentDllMethods = ATACore.Project.ProjectInfoCollector.GetProjectTestMethods(currentProjectDllPath);
                //AddMethodsToCheckBoxListInternal(currentProjectDllPath, currentDllMethods);
                //testIds.AddRange(ATACore.TestExecution.TestListGenerator.GenerateTestMethodIds(currentDllMethods, currentProjectDllPath));
            }
        }

        private List<string> FilterCheckedTests()
        {
            List<string> filteredTestIds = new List<string>();
            for (int i = 0; i < dgvMethods.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)dgvMethods.Rows[i].Cells[0];
                if (Convert.ToBoolean(currentCheckBox.Value))
                {
                    string currentChecked = dgvMethods.Rows[i].Cells[1].Value.ToString();
                    int index = testIds.FindIndex(x => x.Equals(dgvMethods.Rows[i].Cells[3].Value.ToString()));
                    if (index != -1)
                    {
                        filteredTestIds.Add(testIds[index]);
                    }
                }
            }
            return filteredTestIds;
        }

        private List<string> GetProjectPaths()
        {
            List<string> projectPaths = new List<string>();
            for (int i = 0; i < dgvProjects.Rows.Count; i++)
            {
                string currentProjectPath = String.Empty;
                if (dgvProjects.Rows[i].Cells[0].Value != null)
                {
                    currentProjectPath = dgvProjects.Rows[i].Cells[0].Value.ToString();
                }
                if (File.Exists(currentProjectPath))
                {
                    projectPaths.Add(currentProjectPath);
                }
            }

            return projectPaths;
        }     

        private void DisplayClientMessage(string agentMessage)
        {
            rtbMain.Text += String.Concat(Environment.NewLine, Environment.NewLine, agentMessage);
        }

        private void DisplayMsBuildLogMessage(string agentMessage)
        {
            rtbMsBuild.Text += String.Concat(Environment.NewLine, Environment.NewLine, agentMessage);
        }

        private void CheckAllTests()
        {
            foreach (DataGridViewRow row in dgvMethods.Rows)
            {
                row.Cells[0].Value = true;
            }
        }

        private void dgvProjects_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RefreshInternal();
            CheckAllTests();
        }        
        #endregion     
    }
}