using System;
using System.Linq;
using System.Windows.Controls;
using YouTubeToGroovesharkImporter.Core.BusinessLogic.Core;

namespace YouTubeToGroovesharkImporter.UI.Views
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
