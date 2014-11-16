using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Awesomium.Core;
using PhantomTube.Core.ViewModels;
using YouTube.SDK;
using FirstFloor.ModernUI.Windows.Controls;
using System.Collections.ObjectModel;
using YouTube.SDK.Entities;
using System.Windows.Media;
using PhantomTube.Core.Managers;
using System.Windows.Threading;
using System.Windows.Input;

namespace PhantomTube.Views
{
    /// <summary>
    /// Interaction logic for YouTubeSongsImportView.xaml
    /// </summary>
    public partial class NewYouTubePlayerView : UserControl
    {
        /// <summary>
        /// The save command
        /// </summary>
        public static RoutedCommand PlayNextCommand = new RoutedCommand();

        /// <summary>
        /// The remove queue song command
        /// </summary>
        public static RoutedCommand RemoveQueueSongCommand = new RoutedCommand();

        private bool isPaused = false;
        private DispatcherTimer timer;
        private bool isDragging;

        public NewYouTubePlayerView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the Loaded event of the UserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            webControl.Source = @"E:\MainProjects\PhantomTube\PhantomTube\mainPlayerPage.html".ToUri();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
           JSValue time = webControl.ExecuteJavascriptWithResult("player.getCurrentTime()");
           ModernDialog.ShowMessage(time.ToString(), "Title", MessageBoxButton.OK);
        }
    }
}