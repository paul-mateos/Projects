using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.App.Content;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using AutomationTestAssistantCore;
using AutomationTestAssistantCore.ExecutionEngine.Messages;
using System.Collections.Generic;

namespace AutomationTestAssistantDesktopApp
{
    public partial class MainWindow : ModernWindow
    {
        public const string TFS_PROJECT_PATH = "TfsOperations.proj";
        public const string MSTEST_PROJECT_PATH = "MsTest.proj";
        public static Task MsBuildLogListnerThreadWorker { get; set; }
        public static Task MessageLoggerThreadWorker { get; set; }
        public static Task GetBuildThreadWorker { get; set; }
        public static ConcurrentQueue<MessageArgsLogger> messagesToBeSend { get; set; }
        public static IpAddressSettings LocalMsBuildLogIpSettings { get; set; }
        public static IpAddressSettings LocalExecutionIpSettings { get; set; }
        public SettingsAppearanceViewModel SettingsAppearanceViewModel { get; set; }
        public static AdminProjectSettingsViewModel AdminProjectSettingsViewModel { get; set; }
        public static List<CurrentExecutionViewModel> CurrentExecutionViews;

        
        public MainWindow()
        {
            InitializeComponent();
            SettingsAppearanceViewModel = new SettingsAppearanceViewModel();
            messagesToBeSend = new ConcurrentQueue<MessageArgsLogger>();
            CurrentExecutionViews = new List<CurrentExecutionViewModel>();
            LocalMsBuildLogIpSettings = new IpAddressSettings("127.0.0.1:8889");
            LocalExecutionIpSettings = new IpAddressSettings("127.0.0.1:8888");
        }
    }
}
