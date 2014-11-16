using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FirstFloor.ModernUI.Windows.Controls;

namespace AutomationTestAssistantDesktopApp
{
    public partial class ExecutionWindow : ModernWindow
    {
        public ExecutionWindow(CurrentExecutionViewModel currentExecutionViewModel)
        {
            InitializeComponent();
            MainWindow.CurrentExecutionViews.Add(currentExecutionViewModel);
            int index = MainWindow.CurrentExecutionViews.Count - 1;
            this.ContentSource = new Uri(String.Concat("/ExecutionView.xaml#currentExecutionViewModelIndex=", index), UriKind.Relative);
            //ExecutionView executionView = new ExecutionView(currentExecutionViewModel);
            //this.Content = executionView;
        }
    }
}
