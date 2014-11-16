using PhantomTube.Core.Core;
using System;
using System.Linq;
using System.Windows.Controls;

namespace PhantomTube.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsView"/> class.
        /// </summary>
        public SettingsView()
        {
            this.InitializeComponent();
            this.DataContext = ExecutionContext.SettingsViewModel;
        }
    }
}