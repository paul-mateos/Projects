using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using YouTube.SDK;
using YouTubeToGroovesharkImporter.Core.BusinessLogic.Entities;
using YouTubeToGroovesharkImporter.Core.ViewModels;

namespace YouTubeToGroovesharkImporter.UI.Views
{
    /// <summary>
    /// Interaction logic for YouTubeSongsImportView.xaml
    /// </summary>
    public partial class YouTubeSongsImportView : UserControl
    {
        public YouTubeSongsImportView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets you tube songs import view model.
        /// </summary>
        /// <value>
        /// You tube songs import view model.
        /// </value>
        public YouTubeSongsImportViewModel YouTubeSongsImportViewModel { get; set; }

        /// <summary>
        /// Handles the Loaded event of the UserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.YouTubeSongsImportViewModel = new YouTubeSongsImportViewModel();
            this.DataContext = this.YouTubeSongsImportViewModel;
        }

        /// <summary>
        /// Handles the Click event of the btnGetSongsYouTube control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnGetSongsYouTube_Click(object sender, RoutedEventArgs e)
        {
            this.HideDgSongs();
            this.YouTubeSongsImportViewModel.SongsCount = 0;
            this.YouTubeSongsImportViewModel.ObservableSongs.Clear();
            if (this.YouTubeSongsImportViewModel.SelectedPlaylist != null)
            {
                this.ShowProgressBar();
                List<YouTubeGroovesharkSong> youTubeGroovesharkSong = new List<YouTubeGroovesharkSong>();
                Task t = Task.Factory.StartNew(() =>
                {
                    youTubeGroovesharkSong = this.YouTubeSongsImportViewModel.PopulateYouTubeSongs();
                });
                t.ContinueWith(antecedent =>
                {
                    youTubeGroovesharkSong.ForEach(x => this.YouTubeSongsImportViewModel.ObservableSongs.Add(x));
                    this.YouTubeSongsImportViewModel.SongsCount = this.YouTubeSongsImportViewModel.ObservableSongs.Count;
                    this.HideProgressBar();
                    this.ShowDgSongs();
                    btnMap.IsEnabled = true;
                }, TaskScheduler.FromCurrentSynchronizationContext());   
            }
            else
            {
                ModernDialog.ShowMessage("Please Select an YouTube Playlist!", "Warning", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSynchronize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnSynchronize_Click(object sender, RoutedEventArgs e)
        {
            this.ShowProgressBar();
            Task t = Task.Factory.StartNew(() =>
            {
                this.YouTubeSongsImportViewModel.AddSongsToGrooveshark();
            });
            t.ContinueWith(antecedent =>
            {               
                this.HideProgressBar();
                ModernDialog.ShowMessage(
                    string.Format("Songs added = {0}", this.YouTubeSongsImportViewModel.songsAddedToGrooveshark),
                    "Success", 
                    MessageBoxButton.OK);
            }, TaskScheduler.FromCurrentSynchronizationContext());   
        }

        /// <summary>
        /// Handles the Click event of the btnMap control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnMap_Click(object sender, RoutedEventArgs e)
        {
            this.HideDgSongs();
            this.ShowProgressBar();
            List<YouTubeGroovesharkSong> songsToMap = new List<YouTubeGroovesharkSong>();
            Task t = Task.Factory.StartNew(() =>
            {
                //songsToMap = this.YouTubeSongsImportViewModel.MapYouTubeSongsToGrooveshark(this.YouTubeSongsImportViewModel.ObservableSongs.Skip(10).Take(6).ToList());
                songsToMap = this.YouTubeSongsImportViewModel.MapYouTubeSongsToGrooveshark(this.YouTubeSongsImportViewModel.ObservableSongs.ToList());
            });
            t.ContinueWith(antecedent =>
            {
                this.YouTubeSongsImportViewModel.ObservableSongs = new ObservableCollection<YouTubeGroovesharkSong>();
                songsToMap.ForEach(x => this.YouTubeSongsImportViewModel.ObservableSongs.Add(x));
                this.DataContext = this.YouTubeSongsImportViewModel;
                this.YouTubeSongsImportViewModel.SongsCount = this.YouTubeSongsImportViewModel.ObservableSongs.Count;
                this.HideProgressBar();
                this.ShowDgSongs();
                btnSynchronize.IsEnabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());   
        }

        /// <summary>
        /// Hides the progress bar.
        /// </summary>
        private void HideProgressBar()
        {
            progressBar.Visibility = System.Windows.Visibility.Hidden;
        }

        /// <summary>
        /// Shows the progress bar.
        /// </summary>
        private void ShowProgressBar()
        {
            progressBar.Visibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// Hides the dg songs.
        /// </summary>
        private void HideDgSongs()
        {
            dgSongs.Visibility = System.Windows.Visibility.Hidden;
        }

        /// <summary>
        /// Shows the dg songs.
        /// </summary>
        private void ShowDgSongs()
        {
            dgSongs.Visibility = System.Windows.Visibility.Visible;
        }       

        /// <summary>
        /// Handles the Click event of the btnRetry control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnRetry_Click(object sender, RoutedEventArgs e)
        {
            YouTubeGroovesharkSong selectedSong = (YouTubeGroovesharkSong)dgSongs.SelectedItem;
            if (selectedSong != null)
            {
                this.YouTubeSongsImportViewModel.RetryCurrentSongMapping(selectedSong);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnGetPlaylists control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnGetPlaylists_Click(object sender, RoutedEventArgs e)
        {
            this.ShowProgressBar();
            List<YouTubePlayList> playlists = new List<YouTubePlayList>();
            Task t = Task.Factory.StartNew(() =>
            {
                playlists = this.YouTubeSongsImportViewModel.PopulateYouTubePlaylists();
            });
            t.ContinueWith(antecedent =>
            {
                foreach (var currentPlaylist in playlists)
                {
                    if (!this.YouTubeSongsImportViewModel.ObservablePlaylists.Contains(currentPlaylist))
                    {
                        this.YouTubeSongsImportViewModel.ObservablePlaylists.Add(currentPlaylist);
                    }
                }
                if (this.YouTubeSongsImportViewModel.ObservablePlaylists.Count > 0)
                {
                    cbPlaylists.SelectedIndex = 0;
                }
                this.HideProgressBar();
            }, TaskScheduler.FromCurrentSynchronizationContext());  
        }
    }
}
