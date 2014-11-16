using AAngelov.Utilities.UI.ViewModels;
using FirstFloor.ModernUI.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using YouTubeToGroovesharkImporter.Core.BusinessLogic.Core;

namespace YouTubeToGroovesharkImporter.UI
{
       /// <summary>
    /// Initializes the main app window
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        /// <summary>
        /// The browse back command
        /// </summary>
        public static RoutedCommand BrowseBackCommand = new RoutedCommand();

        /// <summary>
        /// The current modern frame
        /// </summary>
        private ModernFrame currentModernFrame;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            ExecutionContext.SettingsViewModel = new BaseSettingsViewModel();
            BrowseBackCommand.InputGestures.Add(new KeyGesture(Key.Back, ModifierKeys.None));
        }

        /// <summary>
        /// Handles the Loaded event of the ModernWindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ModernWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // this.MinWidth = this.ActualWidth;
            // this.MinHeight = this.ActualHeight;
            // this.MaxHeight = this.ActualHeight;
            // this.MaxWidth = this.ActualWidth;
        }

        /// <summary>
        /// Handles the Executed event of the CommandBinding control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            NavigationCommands.BrowseBack.Execute(null, currentModernFrame);
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call System.Windows.FrameworkElement.ApplyTemplate().
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            currentModernFrame = (ModernFrame)GetTemplateChild("ContentFrame");
        }

        /// <summary>
        /// Handles the Closing event of the ModernWindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void ModernWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult messageBoxResult = ModernDialog.ShowMessage("Are you sure you want to exit?", "Confirm Exit!", MessageBoxButton.YesNoCancel);
            if (messageBoxResult != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}
