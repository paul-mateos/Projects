using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AAngelov.Utilities.UI.Core;
using PhantomTube.Core.Core;
using YouTube.SDK;
using YouTube.SDK.Entities;
using YouTube.SDK.Entities.Contracts;
using PhantomTube.Core.Managers;

namespace PhantomTube.Core.ViewModels
{
    /// <summary>
    /// Contains Common Methods between playlist and player views
    /// </summary>
    public class BaseYouTubePlayerViewModel : BaseNotifyPropertyChanged
    {
        /// <summary>
        /// The log
        /// </summary>
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
      
        /// <summary>
        /// You tube playlis identifier
        /// </summary>
        protected string youTubePlaylisId;

        /// <summary>
        /// The songs count
        /// </summary>
        protected int songsCount;

        /// <summary>
        /// You tube user
        /// </summary>
        protected string youTubeUser;

        /// <summary>
        /// The selected playlist
        /// </summary>
        protected YouTubePlayList selectedPlaylist;

        /// <summary>
        /// The last selected playlist
        /// </summary>
        public string lastSelectedPlaylist;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseYouTubePlayerViewModel"/> class.
        /// </summary>
        public BaseYouTubePlayerViewModel()
        {
            this.ObservableSongs = new ObservableCollection<YouTubeSong>();
            this.ObservablePlaylists = new ObservableCollection<YouTubePlayList>();
            this.ObservableOriginalSongs = new ObservableCollection<YouTubeSong>();
            this.lastSelectedPlaylist = RegistryManager.Instance.ReadLastPlaylist();
        }

        /// <summary>
        /// Gets or sets the observable songs.
        /// </summary>
        /// <value>
        /// The observable songs.
        /// </value>
        public ObservableCollection<YouTubeSong> ObservableSongs { get; set; }

        /// <summary>
        /// Gets or sets the observable original songs.
        /// </summary>
        /// <value>
        /// The observable original songs.
        /// </value>
        public ObservableCollection<YouTubeSong> ObservableOriginalSongs { get; set; }

        /// <summary>
        /// Gets or sets the observable playlists.
        /// </summary>
        /// <value>
        /// The observable playlists.
        /// </value>
        public ObservableCollection<YouTubePlayList> ObservablePlaylists { get; set; }

        /// <summary>
        /// Gets or sets the selected playlist.
        /// </summary>
        /// <value>
        /// The selected playlist.
        /// </value>
        public YouTubePlayList SelectedPlaylist
        {
            get
            {
                return this.selectedPlaylist;
            }

            set
            {
                this.selectedPlaylist = value;
                RegistryManager.Instance.WriteLastSelectedPlaylist(this.selectedPlaylist.Name);
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets you tube playlis identifier.
        /// </summary>
        /// <value>
        /// You tube playlis identifier.
        /// </value>
        public string YouTubePlaylisId
        {
            get
            {
                return this.youTubePlaylisId;
            }

            set
            {
                this.youTubePlaylisId = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the songs count.
        /// </summary>
        /// <value>
        /// The songs count.
        /// </value>
        public int SongsCount
        {
            get
            {
                return this.songsCount;
            }

            set
            {
                this.songsCount = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets you tube user.
        /// </summary>
        /// <value>
        /// You tube user.
        /// </value>
        public string YouTubeUser
        {
            get
            {
                return this.youTubeUser;
            }

            set
            {
                this.youTubeUser = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the index of the selected playlist.
        /// </summary>
        /// <returns>the selected playlist index</returns>
        public int GetSelectedPlaylistIndex()
        {
            int result = default(int);
            if (!string.IsNullOrEmpty(this.lastSelectedPlaylist) && this.ObservablePlaylists.Count(x => x.Name.Equals(lastSelectedPlaylist)) > 0)
            {
                var firstPlaylist = this.ObservablePlaylists.First(x => x.Name.Equals(lastSelectedPlaylist));
                result = this.ObservablePlaylists.IndexOf(firstPlaylist);
            }

            return result;
        }

        /// <summary>
        /// Populates you tube songs.
        /// </summary>
        public List<YouTubeSong> PopulateYouTubeSongs()
        {
            List<IYouTubeSong> playListSongs = new List<IYouTubeSong>();
            playListSongs = YouTubeServiceClient.Instance.GetPlayListSongs(ExecutionContext.CurrentUser, this.SelectedPlaylist.Id);
          
            List<YouTubeSong> currentPlaylistSongs = new List<YouTubeSong>();
            foreach (IYouTubeSong currentPlayListSong in playListSongs)
            {
                currentPlaylistSongs.Add(new YouTubeSong(currentPlayListSong));
            }

            return currentPlaylistSongs;
        }

        /// <summary>
        /// Populates you tube playlists.
        /// </summary>
        public List<YouTubePlayList> PopulateYouTubePlaylists()
        {
            List<YouTubePlayList> playlists = YouTubeServiceClient.Instance.GetUserPlayLists(ExecutionContext.CurrentUser);
            return playlists;
        }

        /// <summary>
        /// Removes the song from playlist.
        /// </summary>
        /// <param name="song">The song.</param>
        public void RemoveSongFromPlaylist(YouTubeSong song)
        {
            YouTubeServiceClient.Instance.RemoveSongFromPlaylist(ExecutionContext.CurrentUser, song.PlayListItemId);
        }  

        /// <summary>
        /// Adds the new songs to observable collection.
        /// </summary>
        /// <param name="songsToAdd">The songs to add.</param>
        public void AddNewSongsToObservableCollection(List<YouTubeSong> songsToAdd)
        {
            this.ObservableSongs.Clear();
            foreach (var currentSong in songsToAdd)
            {
                this.ObservableSongs.Add(currentSong);
            }
        } 
    }
}