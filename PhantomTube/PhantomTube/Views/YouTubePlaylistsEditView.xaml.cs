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
using System.Windows.Input;

namespace PhantomTube.Views
{
    /// <summary>
    /// Interaction logic for YouTubeSongsImportView.xaml
    /// </summary>
    public partial class YouTubePlaylistsEditView : UserControl
    {
        /// <summary>
        /// The move up test case command
        /// </summary>
        public static RoutedCommand MoveUpTestCasesCommand = new RoutedCommand();

        /// <summary>
        /// The move down test case command
        /// </summary>
        public static RoutedCommand MoveDownTestCasesCommand = new RoutedCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="YouTubePlaylistsEditView"/> class.
        /// </summary>
        public YouTubePlaylistsEditView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets you tube songs import view model.
        /// </summary>
        /// <value>
        /// You tube songs import view model.
        /// </value>
        public YouTubePlaylistsEditViewModel YouTubePlaylistsEditViewModel { get; set; }

        /// <summary>
        /// Handles the Loaded event of the UserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.YouTubePlaylistsEditViewModel = new YouTubePlaylistsEditViewModel();
            this.GetCurrentUserPlaylists();
            this.DataContext = this.YouTubePlaylistsEditViewModel;
            this.InitializeFastKeys();
        }

        /// <summary>
        /// Initializes the fast keys.
        /// </summary>
        private void InitializeFastKeys()
        {
            MoveUpTestCasesCommand.InputGestures.Add(new KeyGesture(Key.Up, ModifierKeys.Alt));
            MoveDownTestCasesCommand.InputGestures.Add(new KeyGesture(Key.Down, ModifierKeys.Alt));
        }

        /// <summary>
        /// Handles the Command event of the moveDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private void moveDown_Command(object sender, ExecutedRoutedEventArgs e)
        {
            this.MoveDownInternal();
            this.dgSongs.Focus();
        }

        /// <summary>
        /// Handles the Command event of the moveUp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private void moveUp_Command(object sender, ExecutedRoutedEventArgs e)
        {
            this.MoveUpInternal();
            this.dgSongs.Focus();
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
        }

        /// <summary>
        /// Shows the dg songs.
        /// </summary>
        private void ShowDgSongs()
        {
            this.dgSongs.Visibility = System.Windows.Visibility.Visible;
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
                playlists = this.YouTubePlaylistsEditViewModel.PopulateYouTubePlaylists();
            });
            t.ContinueWith(antecedent =>
            {
                foreach (var currentPlaylist in playlists)
                {
                    if (!this.YouTubePlaylistsEditViewModel.ObservablePlaylists.Contains(currentPlaylist))
                    {
                        this.YouTubePlaylistsEditViewModel.ObservablePlaylists.Add(currentPlaylist);
                    }
                }
                if (this.YouTubePlaylistsEditViewModel.ObservablePlaylists.Count > 0)
                {
                    this.cbPlaylists.SelectedIndex = this.YouTubePlaylistsEditViewModel.GetSelectedPlaylistIndex();
                }
                this.HideProgressBar();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.HideDgSongs();
            this.ShowProgressBar();
            Task t = Task.Factory.StartNew(() =>
            {
                this.YouTubePlaylistsEditViewModel.SaveCurrentPlaylist();
            });
            t.ContinueWith(antecedent =>
            {
                this.HideProgressBar();
                this.ShowDgSongs();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// Handles the Click event of the btnSortByTitle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnSortByTitle_Click(object sender, RoutedEventArgs e)
        {
            this.HideDgSongs();
            this.ShowProgressBar();
            List<YouTubeSong> songs = new List<YouTubeSong>();
            Task t = Task.Factory.StartNew(() =>
            {
                songs = this.YouTubePlaylistsEditViewModel.SortSongsByTitle();
            });
            t.ContinueWith(antecedent =>
            {
                this.YouTubePlaylistsEditViewModel.AddNewSongsToObservableCollection(songs);
                this.HideProgressBar();
                this.ShowDgSongs();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// Handles the Click event of the btnSortByArtist control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnSortByArtist_Click(object sender, RoutedEventArgs e)
        {
            this.HideDgSongs();
            this.ShowProgressBar();
            List<YouTubeSong> songs = new List<YouTubeSong>();
            Task t = Task.Factory.StartNew(() =>
            {
                songs = this.YouTubePlaylistsEditViewModel.SortSongsByArtist();
            });
            t.ContinueWith(antecedent =>
            {
                this.YouTubePlaylistsEditViewModel.AddNewSongsToObservableCollection(songs);
                this.HideProgressBar();
                this.ShowDgSongs();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// Handles the Click event of the btnExport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text Files (*.txt)|*.txt";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                this.HideDgSongs();
                this.ShowProgressBar();
                string filename = dlg.FileName;
                Task t1 = Task.Factory.StartNew(() =>
                {
                    this.YouTubePlaylistsEditViewModel.ExportSongsFromCurrentPlaylist(dlg.FileName);
                });
                t1.ContinueWith(antecedent =>
                {
                    this.HideProgressBar();
                    this.ShowDgSongs();
                    string message = String.Format("{0} songs exported from {1} playlist!", 
                        this.YouTubePlaylistsEditViewModel.ObservableSongs.Count, 
                        this.YouTubePlaylistsEditViewModel.SelectedPlaylist.Name);
                    ModernDialog.ShowMessage(message, "Success!", MessageBoxButton.OK);
                    System.Diagnostics.Process.Start(filename);
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        /// <summary>
        /// Handles the Click event of the btnDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            YouTubeSong songForDeletion = ((FrameworkElement)sender).DataContext as YouTubeSong;         
            this.YouTubePlaylistsEditViewModel.ObservableSongs.Remove(songForDeletion);
            this.YouTubePlaylistsEditViewModel.RemoveSongFromPlaylist(songForDeletion);
        }

        /// <summary>
        /// Handles the Click event of the btnDisplayPlaylistSongs control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnDisplayPlaylistSongs_Click(object sender, RoutedEventArgs e)
        {
            this.HideDgSongs();
            this.YouTubePlaylistsEditViewModel.SongsCount = 0;
            this.YouTubePlaylistsEditViewModel.ObservableSongs.Clear();
            if (this.YouTubePlaylistsEditViewModel.SelectedPlaylist != null)
            {
                this.ShowProgressBar();
                List<YouTubeSong> youTubeGroovesharkSong = new List<YouTubeSong>();
                Task t = Task.Factory.StartNew(() =>
                {
                    youTubeGroovesharkSong = this.YouTubePlaylistsEditViewModel.PopulateYouTubeSongs();
                });
                t.ContinueWith(antecedent =>
                {
                    youTubeGroovesharkSong.ForEach(x => this.YouTubePlaylistsEditViewModel.ObservableSongs.Add(x));
                    youTubeGroovesharkSong.ForEach(x => this.YouTubePlaylistsEditViewModel.ObservableOriginalSongs.Add(x));
                    this.YouTubePlaylistsEditViewModel.SongsCount = this.YouTubePlaylistsEditViewModel.ObservableSongs.Count;
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
        /// Handles the Click event of the btnMoveUp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnMoveUp_Click(object sender, RoutedEventArgs e)
        {
            this.MoveUpInternal();
        }

        /// <summary>
        /// Handles the Click event of the btnMoveDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnMoveDown_Click(object sender, RoutedEventArgs e)
        {
            this.MoveDownInternal();
        }

        /// <summary>
        /// Moves up test steps internal.
        /// </summary>
        private void MoveUpInternal()
        {
            // validate the move if it's out of the boudaries return
            if (this.dgSongs.SelectedItems.Count == 0)
            {
                this.DisplayNonSelectionWarning();
                return;
            }
            int startIndex = this.YouTubePlaylistsEditViewModel.ObservableSongs.IndexOf(this.dgSongs.SelectedItems[0] as YouTubeSong);
            if (startIndex == 0)
            {
                return;
            }
            int count = this.dgSongs.SelectedItems.Count;
            if (this.dgSongs.SelectedItems.Count == 0)
            {
                return;
            }
            //using (new UndoTransaction("Move up selected steps", true))
            //{
            this.YouTubePlaylistsEditViewModel.CreateNewTestCaseCollectionAfterMoveUp(startIndex, count);
            this.SelectNextItemsAfterMoveUp(startIndex, count);
            //}
            this.dgSongs.UpdateLayout();
            this.dgSongs.ScrollIntoView(this.dgSongs.SelectedItem);
        }

        /// <summary>
        /// Moves down test steps internal.
        /// </summary>
        private void MoveDownInternal()
        {
            // validate the move if it's out of the boudaries return
            if (this.dgSongs.SelectedItems.Count == 0)
            {
                this.DisplayNonSelectionWarning();
                return;
            }
            int startIndex = this.YouTubePlaylistsEditViewModel.ObservableSongs.IndexOf(this.dgSongs.SelectedItems[0] as YouTubeSong);
            int count = this.dgSongs.SelectedItems.Count;
            if (startIndex == this.YouTubePlaylistsEditViewModel.ObservableSongs.Count - 1)
            {
                return;
            }
            if ((startIndex + count) >= this.YouTubePlaylistsEditViewModel.ObservableOriginalSongs.Count)
            {
                return;
            }
            //using (new UndoTransaction("Move down selected steps", true))
            //{
            this.YouTubePlaylistsEditViewModel.CreateNewTestCaseCollectionAfterMoveDown(startIndex, count);
            this.SelectNextItemsAfterMoveDown(startIndex, count);
            //}
            this.dgSongs.UpdateLayout();
            this.dgSongs.ScrollIntoView(this.dgSongs.SelectedItems[this.dgSongs.SelectedItems.Count - 1]);
        }

        /// <summary>
        /// Selects the next songs after move up.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="selectedTestStepsCount">The selected songs count.</param>
        private void SelectNextItemsAfterMoveUp(int startIndex, int selectedTestStepsCount)
        {
            this.dgSongs.SelectedItems.Clear();
            for (int i = startIndex - 1; i < startIndex + selectedTestStepsCount - 1; i++)
            {
                this.dgSongs.SelectedItems.Add(this.dgSongs.Items[i]);
            }
            //UndoRedoManager.Instance().Push((si, c) => this.SelectNextItemsAfterMoveDown(si, c), startIndex - 1, selectedTestStepsCount, "Select next items after move up");
        }

        /// <summary>
        /// Selects the next songs after move down.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="selectedTestStepsCount">The selected songs count.</param>
        private void SelectNextItemsAfterMoveDown(int startIndex, int selectedTestStepsCount)
        {
            this.dgSongs.SelectedItems.Clear();
            for (int i = startIndex + 1; i < startIndex + selectedTestStepsCount + 1; i++)
            {
                this.dgSongs.SelectedItems.Add(this.dgSongs.Items[i]);
            }
            //UndoRedoManager.Instance().Push((si, c) => this.SelectNextItemsAfterMoveUp(si, c), startIndex + 1, selectedTestStepsCount, "Select next items after move up");
        }

        /// <summary>
        /// Displays the non selection warning.
        /// </summary>
        private void DisplayNonSelectionWarning()
        {
            ModernDialog.ShowMessage("No selected songs.", "Warning", MessageBoxButton.OK);
        }
    }
}