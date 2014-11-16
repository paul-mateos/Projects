using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    public partial class YouTubePlayerView : UserControl
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
     

        public YouTubePlayerView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets you tube songs import view model.
        /// </summary>
        /// <value>
        /// You tube songs import view model.
        /// </value>
        public YouTubePlayerViewModel YouTubePlayerViewModel { get; set; }

        /// <summary>
        /// Handles the Loaded event of the UserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.YouTubePlayerViewModel = new YouTubePlayerViewModel();
            this.GetCurrentUserPlaylists();
            this.DataContext = this.YouTubePlayerViewModel;
            this.YouTubePlayerViewModel.InitializeVolumeFromRegistry();
            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += new EventHandler(timer_Tick);
        }

        /// <summary>
        /// Handles the Command event of the playNext control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private void playNext_Command(object sender, ExecutedRoutedEventArgs e)
        {
            e.Handled = true;
            List<YouTubeSong> selectedSongs = this.GetSelectedSongsMainSongsGrid();
            this.YouTubePlayerViewModel.AddSongsToQueue(selectedSongs);
        }

        /// <summary>
        /// Handles the Command event of the removeQueueSongs control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private void removeQueueSongs_Command(object sender, ExecutedRoutedEventArgs e)
        {
            e.Handled = true;
            List<YouTubeSong> selectedSongs = this.GetSelectedSongsQueueSongsGrid();
            this.YouTubePlayerViewModel.RemoveSongsFromQueue(selectedSongs);
        }

        /// <summary>
        /// Gets the selected songs main songs grid.
        /// </summary>
        /// <returns></returns>
        private List<YouTubeSong> GetSelectedSongsMainSongsGrid()
        {
            List<YouTubeSong> selectedSongs = new List<YouTubeSong>();
            if (dgSongs.SelectedItems != null && dgSongs.SelectedItems.Count > 0)
            {
                foreach (YouTubeSong currentSong in dgSongs.SelectedItems)
                {
                    selectedSongs.Add(currentSong);
                }
            }

            return selectedSongs;
        }

        /// <summary>
        /// Gets the selected songs queue songs grid.
        /// </summary>
        /// <returns></returns>
        private List<YouTubeSong> GetSelectedSongsQueueSongsGrid()
        {
            List<YouTubeSong> selectedSongs = new List<YouTubeSong>();
            if (dgQueueSongs.SelectedItems != null && dgQueueSongs.SelectedItems.Count > 0)
            {
                foreach (YouTubeSong currentSong in dgQueueSongs.SelectedItems)
                {
                    selectedSongs.Add(currentSong);
                }
            }

            return selectedSongs;
        }

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (!this.isDragging)
            {
                timelineSlider.Value = player.Position.TotalSeconds;
                this.YouTubePlayerViewModel.CurrentSongProgress = player.Position.ToString(@"mm\:ss");
                this.YouTubePlayerViewModel.CurrentSongTimer = 
                    string.Concat(this.YouTubePlayerViewModel.CurrentSongDuration, 
                    "/",
                    this.YouTubePlayerViewModel.CurrentSongProgress);
                ////this.ChangeSelectedIndexCurrentlyPlayedSongMainSongsGrid();
            }
        }

        /// <summary>
        /// Changes the selected index currently played song.
        /// </summary>
        private void ChangeSelectedIndexCurrentlyPlayedSongMainSongsGrid()
        {
            int newIndex = this.YouTubePlayerViewModel.ObservableSongs.IndexOf(this.YouTubePlayerViewModel.CurrentPlayedSong);
            if(newIndex != -1)
            {
                this.dgSongs.SelectedIndex = newIndex;
                this.dgSongs.UpdateLayout();
                if (this.dgSongs.SelectedItem != null)
                {
                    this.dgSongs.ScrollIntoView(this.dgSongs.SelectedItem);
                    this.dgSongs.Focus();
                }
            }       
        }

        /// <summary>
        /// Hides the progress bar.
        /// </summary>
        private void HideProgressBar()
        {
            this.progressBar.Visibility = System.Windows.Visibility.Hidden;
        }

        /// <summary>
        /// Shows the progress bar.
        /// </summary>
        private void ShowProgressBar()
        {
            this.progressBar.Visibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// Hides the dg songs.
        /// </summary>
        private void HideDgSongs()
        {
            this.dgSongs.Visibility = System.Windows.Visibility.Hidden;
            this.dgQueueSongs.Visibility = System.Windows.Visibility.Hidden;
        }

        /// <summary>
        /// Shows the dg songs.
        /// </summary>
        private void ShowDgSongs()
        {
            this.dgSongs.Visibility = System.Windows.Visibility.Visible;
            this.dgQueueSongs.Visibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// Gets the current user playlists.
        /// </summary>
        private void GetCurrentUserPlaylists()
        {
            this.ShowProgressBar();
            List<YouTubePlayList> playlists = new List<YouTubePlayList>();
            Task t = Task.Factory.StartNew(() =>
            {
                playlists = this.YouTubePlayerViewModel.PopulateYouTubePlaylists();
            });
            t.ContinueWith(antecedent =>
            {
                foreach (var currentPlaylist in playlists)
                {
                    if (!this.YouTubePlayerViewModel.ObservablePlaylists.Contains(currentPlaylist))
                    {
                        this.YouTubePlayerViewModel.ObservablePlaylists.Add(currentPlaylist);
                    }
                }               
                if (this.YouTubePlayerViewModel.ObservablePlaylists.Count > 0)
                {
                    this.cbPlaylists.SelectedIndex = this.YouTubePlayerViewModel.GetSelectedPlaylistIndex();
                }
                this.HideProgressBar();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// Hides the songs grid.
        /// </summary>
        private void HideSongsGrid()
        {
            dgSongs.Visibility = System.Windows.Visibility.Hidden;
        }

        /// <summary>
        /// Shows the songs grid.
        /// </summary>
        private void ShowSongsGrid()
        {
            dgSongs.Visibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// Hides the player.
        /// </summary>
        private void HidePlayer()
        {
            player.Visibility = System.Windows.Visibility.Hidden;
        }

        /// <summary>
        /// Shows the player.
        /// </summary>
        private void ShowPlayer()
        {
            player.Visibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// Hides the player progress bar.
        /// </summary>
        private void HidePlayerProgressBar()
        {
            playerProgressBar.Visibility = System.Windows.Visibility.Hidden;
        }

        /// <summary>
        /// Shows the player progress bar.
        /// </summary>
        private void ShowPlayerProgressBar()
        {
            playerProgressBar.Visibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// Handles the Click event of the btnDisplayPlaylistSongs control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnDisplayPlaylistSongs_Click(object sender, RoutedEventArgs e)
        {
            this.HideDgSongs();
            this.YouTubePlayerViewModel.SongsCount = 0;
            this.YouTubePlayerViewModel.ObservableSongs.Clear();
            if (this.YouTubePlayerViewModel.SelectedPlaylist != null)
            {
                this.ShowProgressBar();
                List<YouTubeSong> youTubeGroovesharkSong = new List<YouTubeSong>();
                Task t = Task.Factory.StartNew(() =>
                {
                    youTubeGroovesharkSong = this.YouTubePlayerViewModel.PopulateYouTubeSongs();
                });
                t.ContinueWith(antecedent =>
                {
                    youTubeGroovesharkSong.ForEach(x => this.YouTubePlayerViewModel.ObservableSongs.Add(x));
                    youTubeGroovesharkSong.ForEach(x => this.YouTubePlayerViewModel.ObservableOriginalSongs.Add(x));
                    this.YouTubePlayerViewModel.SongsCount = this.YouTubePlayerViewModel.ObservableSongs.Count;
                    this.HideProgressBar();
                    this.ShowDgSongs();
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
            {
                ModernDialog.ShowMessage("Please Select an YouTube Playlist!", "Warning", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnPlay control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (this.YouTubePlayerViewModel.CurrentPlayedSong == null && dgSongs.SelectedItem != null)
            {
                this.YouTubePlayerViewModel.CurrentPlayedSong = (YouTubeSong)dgSongs.SelectedItem; 
            }
            if (this.YouTubePlayerViewModel.CurrentPlayedSong != null)
            {
                this.PlayInternal();
            }
            else
            {
                ModernDialog.ShowMessage("You should first select a song!", "Warning!", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Plays the internal.
        /// </summary>
        private void PlayInternal()
        {
            this.HidePlayer();
            this.YouTubePlayerViewModel.RemoveSongsFromQueue();
            this.ShowPlayerProgressBar();
            Task t = Task.Factory.StartNew(() =>
            {
                this.YouTubePlayerViewModel.PlaySongAsync(this.YouTubePlayerViewModel.CurrentPlayedSong).Wait();
            });
            t.ContinueWith(antecedent =>
            {
                player.Source = this.YouTubePlayerViewModel.CurrentUri;
                this.HidePlayerProgressBar();
                this.YouTubePlayerViewModel.AddSongsToQueue();
                this.ChangeSelectedIndexCurrentlyPlayedSongMainSongsGrid();
                this.ShowPlayer();
                player.Play();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// Handles the Click event of the btnPause control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            this.PauseInternal();
        }

        /// <summary>
        /// Pauses the internal.
        /// </summary>
        private void PauseInternal()
        {
            if (!this.isPaused)
            {
                player.Pause();
                this.isPaused = true;
                btnPause.Content = ">";
            }
            else
            {
                player.Play();
                this.isPaused = false;
                btnPause.Content = "||";
            }
        }

        /// <summary>
        /// Handles the Click event of the btnStop control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
        }

        /// <summary>
        /// Handles the ValueChanged event of the volumeSlider control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{System.Double}"/> instance containing the event data.</param>
        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.Volume = volumeSlider.Value;
            RegistryManager.Instance.WriteVolume(volumeSlider.Value);
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of the dgSongs control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private void dgSongs_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (dgSongs.SelectedItem != null)
            {
                this.YouTubePlayerViewModel.CurrentPlayedSong = (YouTubeSong)dgSongs.SelectedItem;
            }
            if (this.YouTubePlayerViewModel.CurrentPlayedSong != null)
            {
                this.PlayInternal();
            }
            else
            {
                ModernDialog.ShowMessage("You should first select a song!", "Warning!", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Handles the MediaEnded event of the player control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void player_MediaEnded(object sender, RoutedEventArgs e)
        {
            this.PlayNextSongInternal();
        }

        /// <summary>
        /// Plays the next song internal.
        /// </summary>
        private void PlayNextSongInternal()
        {
            this.HidePlayer();
            this.YouTubePlayerViewModel.RemoveSongsFromQueue();
            this.ShowPlayerProgressBar();
            Task t = Task.Factory.StartNew(() =>
            {
                this.YouTubePlayerViewModel.PlayNextSongAsync().Wait();
            });
            t.ContinueWith(antecedent =>
            {
                player.Source = this.YouTubePlayerViewModel.CurrentUri;
                this.HidePlayerProgressBar();
                this.YouTubePlayerViewModel.AddSongsToQueue();
                this.YouTubePlayerViewModel.RemoveSongsFromQueue();
                this.ChangeSelectedIndexCurrentlyPlayedSongMainSongsGrid();
                this.ShowPlayer();
                player.Play();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// Handles the KeyUp event of the TextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.KeyEventArgs"/> instance containing the event data.</param>
        private void TextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            this.YouTubePlayerViewModel.FilterSongs();
        }

        /// <summary>
        /// Handles the MouseDown event of the player control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private void player_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.PauseInternal();
        }

        /// <summary>
        /// Handles the MediaOpened event of the player control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void player_MediaOpened(object sender, RoutedEventArgs e)
        {
            btnPause.Content = "||";
            this.isPaused = false;
            if(player.NaturalDuration.HasTimeSpan)
            {
                TimeSpan ts = player.NaturalDuration.TimeSpan;             
                timelineSlider.Maximum = ts.TotalSeconds;
                this.YouTubePlayerViewModel.CurrentSongDuration = ts.ToString(@"mm\:ss");
                timelineSlider.SmallChange = 1;
                timelineSlider.LargeChange = Math.Min(10, ts.Seconds / 10);
            }
            timer.Start();
        }

        /// <summary>
        /// Handles the DragStarted event of the timelineSlider control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.Primitives.DragStartedEventArgs"/> instance containing the event data.</param>
        private void timelineSlider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            this.isDragging = true;
        }

        /// <summary>
        /// Handles the DragCompleted event of the timelineSlider control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.Primitives.DragCompletedEventArgs"/> instance containing the event data.</param>
        private void timelineSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            this.isDragging = false;
            player.Position = TimeSpan.FromSeconds(timelineSlider.Value);
        }

        /// <summary>
        /// Handles the Click event of the btnLast control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            if (this.YouTubePlayerViewModel.LastPlayedSong != null)
            {
                this.HidePlayer();
                this.ShowPlayerProgressBar();
                Task t = Task.Factory.StartNew(() =>
                {
                    this.YouTubePlayerViewModel.PlaySongAsync(this.YouTubePlayerViewModel.LastPlayedSong).Wait();
                });
                t.ContinueWith(antecedent =>
                {
                    player.Source = this.YouTubePlayerViewModel.CurrentUri;
                    this.HidePlayerProgressBar();
                    this.ChangeSelectedIndexCurrentlyPlayedSongMainSongsGrid();
                    this.ShowPlayer();
                    player.Play();
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }         
        }

        /// <summary>
        /// Handles the Click event of the btnNext control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            this.PlayNextSongInternal();
        }
    }
}