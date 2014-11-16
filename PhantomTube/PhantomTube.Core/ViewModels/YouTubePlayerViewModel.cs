using System.Collections.Generic;
using System.Linq;
using YouTube.SDK.Entities;
using MT = MyToolkit.Multimedia;
using System.Windows.Controls;
using System.Threading.Tasks;
using System;
using PhantomTube.Core.Managers;
using System.Collections.ObjectModel;
using System.Text;

namespace PhantomTube.Core.ViewModels
{
    /// <summary>
    /// Contains Methods Related to YouTube Songs Import View
    /// </summary>
    public class YouTubePlayerViewModel : BaseYouTubePlayerViewModel
    {
        /// <summary>
        /// The log
        /// </summary>
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The volume
        /// </summary>
        private double volume;

        /// <summary>
        /// The songs filter
        /// </summary>
        private string songsFilter;

        /// <summary>
        /// The current song progress
        /// </summary>
        private string currentSongProgress;

        /// <summary>
        /// The current song duration
        /// </summary>
        private string currentSongDuration;

        /// <summary>
        /// The current song timer
        /// </summary>
        private string currentSongTimer;

        /// <summary>
        /// The current played song
        /// </summary>
        private YouTubeSong currentPlayedSong;

        /// <summary>
        /// The last played song
        /// </summary>
        private YouTubeSong lastPlayedSong;

        public YouTubePlayerViewModel()
        {
            this.ObservableQueueSongs = new ObservableCollection<YouTubeSong>();
        }

        /// <summary>
        /// Gets or sets the songs filter.
        /// </summary>
        /// <value>
        /// The songs filter.
        /// </value>
        public string SongsFilter
        {
            get
            {
                return this.songsFilter;
            }

            set
            {
                this.songsFilter = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        /// <value>
        /// The volume.
        /// </value>
        public double Volume
        {
            get
            {
                return this.volume;
            }

            set
            {
                this.volume = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the current song progress.
        /// </summary>
        /// <value>
        /// The current song progress.
        /// </value>
        public string CurrentSongProgress
        {
            get
            {
                return this.currentSongProgress;
            }

            set
            {
                this.currentSongProgress = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the current song timer.
        /// </summary>
        /// <value>
        /// The current song timer.
        /// </value>
        public string CurrentSongTimer
        {
            get
            {
                return currentSongTimer;
            }

            set
            {
                this.currentSongTimer = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the duration of the current song.
        /// </summary>
        /// <value>
        /// The duration of the current song.
        /// </value>
        public string CurrentSongDuration
        {
            get
            {
                return this.currentSongDuration;
            }

            set
            {
                this.currentSongDuration = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the current played song.
        /// </summary>
        /// <value>
        /// The current played song.
        /// </value>
        public YouTubeSong CurrentPlayedSong
        {
            get
            {
                return this.currentPlayedSong;
            }

            set
            {
                this.LastPlayedSong = this.currentPlayedSong;
                this.currentPlayedSong = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the last played song.
        /// </summary>
        /// <value>
        /// The last played song.
        /// </value>
        public YouTubeSong LastPlayedSong
        {
            get
            {
                return this.lastPlayedSong;
            }

            set
            {
                this.lastPlayedSong = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the observable queue songs.
        /// </summary>
        /// <value>
        /// The observable queue songs.
        /// </value>
        public ObservableCollection<YouTubeSong> ObservableQueueSongs { get; set; }

        /// <summary>
        /// Gets or sets the current URI.
        /// </summary>
        /// <value>
        /// The current URI.
        /// </value>
        public Uri CurrentUri { get; set; }

        /// <summary>
        /// Initializes the volume from registry.
        /// </summary>
        public void InitializeVolumeFromRegistry()
        {
            double? registryVolume = RegistryManager.Instance.ReadVolume();
            if (registryVolume == null)
            {
                registryVolume = 1;
            }
            this.Volume = (double)registryVolume;
        }       

        /// <summary>
        /// Filters the songs.
        /// </summary>
        public void FilterSongs()
        {
            IEnumerable<YouTubeSong> searchableCollection = this.ObservableOriginalSongs;
            var filteredList = searchableCollection.Where(t => t.Artist.ToLower().Contains(this.SongsFilter.ToLower()) || t.Title.ToLower().Contains(this.SongsFilter.ToLower())).ToList();
            this.ObservableSongs.Clear();
            filteredList.ForEach(x => this.ObservableSongs.Add(x));
            this.SongsCount = filteredList.Count;
        }

        /// <summary>
        /// Plays the song.
        /// </summary>
        /// <param name="song">The song.</param>
        public async Task PlaySongAsync(YouTubeSong song)
        {           
            var url = await MT.YouTube.GetVideoUriAsync(song.SongId, MT.YouTubeQuality.QualityLow);
            this.CurrentUri = url.Uri;
            this.CurrentPlayedSong = song;
        }

        /// <summary>
        /// Plays the next song asynchronous.
        /// </summary>
        /// <returns>the play next song task</returns>
        public async Task PlayNextSongAsync()
        {
            YouTubeSong nextSong = this.GetNextSongToBePlayed();          
            await this.PlaySongAsync(nextSong);       
        }


        /// <summary>
        /// Adds the songs to queue.
        /// </summary>
        public void AddSongsToQueue()
        {
            string songsToBeAddedRegistry = RegistryManager.Instance.ReadSongsToBeAdded();
            if(!string.IsNullOrEmpty(songsToBeAddedRegistry))
            {
                string[] songGuides = songsToBeAddedRegistry.Split(',');
                foreach (string currentSongGuid in songGuides)
                {
                    var currentSong = this.ObservableOriginalSongs.First(s => s.SongGuid.ToString().Equals(currentSongGuid.ToString()));
                    this.ObservableQueueSongs.Add(currentSong);
                }
                RegistryManager.Instance.WriteSongsToBeAdded(string.Empty);
            }           
        }

        /// <summary>
        /// Adds the songs to be added to queue to registry.
        /// </summary>
        /// <param name="songsToBeAdded">The songs to be added.</param>
        public void AddSongsToBeAddedToQueueToRegistry(ICollection<YouTubeSong> songsToBeAdded)
        {
            StringBuilder sb = new StringBuilder();
            foreach (YouTubeSong currentSong in songsToBeAdded)
            {
                sb.Append(string.Format("{0},", currentSong.SongGuid));
            }
            RegistryManager.Instance.WriteSongsToBeAdded(sb.ToString().TrimEnd(','));
        }

        /// <summary>
        /// Adds the songs to be removed from queue to registry.
        /// </summary>
        /// <param name="songsToBeRemoved">The songs to be removed.</param>
        public void AddSongsToBeRemovedFromQueueToRegistry(ICollection<YouTubeSong> songsToBeRemoved)
        {
            StringBuilder sb = new StringBuilder();
            foreach (YouTubeSong currentSong in songsToBeRemoved)
            {
                sb.Append(string.Format("{0},", currentSong.SongGuid));
            }
            RegistryManager.Instance.WriteSongsToBeDeleted(sb.ToString().TrimEnd(','));
        }

        /// <summary>
        /// Removes the songs from queue.
        /// </summary>
        public void RemoveSongsFromQueue()
        {
            string songsToBeDeletedRegistry = RegistryManager.Instance.ReadSongsToBeDeleted();
            if (!string.IsNullOrEmpty(songsToBeDeletedRegistry))
            {
                string[] songGuides = songsToBeDeletedRegistry.Split(',');
                foreach (string currentSongGuid in songGuides)
                {
                    var currentSong = this.ObservableOriginalSongs.First(s => s.SongGuid.ToString().Equals(currentSongGuid.ToString()));
                    this.ObservableQueueSongs.Remove(currentSong);
                }
                RegistryManager.Instance.WriteSongsToBeDeleted(string.Empty);
            }  
        }

        /// <summary>
        /// Removes the songs from queue.
        /// </summary>
        /// <param name="songsToBeRemoved">The songs to be removed.</param>
        public void RemoveSongsFromQueue(ICollection<YouTubeSong> songsToBeRemoved)
        {
            foreach (YouTubeSong currentSong in songsToBeRemoved)
            {
                this.ObservableQueueSongs.Remove(currentSong);
            }
        }

        /// <summary>
        /// Adds the songs to queue.
        /// </summary>
        /// <param name="songsToBeAdded">The songs to be added.</param>
        public void AddSongsToQueue(ICollection<YouTubeSong> songsToBeAdded)
        {
            foreach (YouTubeSong currentSong in songsToBeAdded)
            {
                this.ObservableQueueSongs.Add(currentSong);
            }
        }

        /// <summary>
        /// Removes the first song from queue.
        /// </summary>
        public void RemoveFirstSongFromQueue()
        {
            if (this.ObservableQueueSongs.Count > 0)
            {
                this.ObservableQueueSongs.Remove(this.ObservableQueueSongs[0]);
            }
        }

        /// <summary>
        /// Gets the next song to be played.
        /// </summary>
        /// <returns>the next song to be played</returns>
        private YouTubeSong GetNextSongToBePlayed()
        {
            YouTubeSong nextSongToBePlayed = null;
            if (this.ObservableQueueSongs.Count > 0)
            {
                nextSongToBePlayed = this.ObservableQueueSongs.First();
                this.AddSongsToBeRemovedFromQueueToRegistry(new List<YouTubeSong> { nextSongToBePlayed });
            }
            else
            {
                int currentSongIndex = this.ObservableOriginalSongs.IndexOf(this.CurrentPlayedSong);
                int nextIndex = 0;
                if (this.ObservableOriginalSongs.Count - 1 > currentSongIndex)
                {
                    nextIndex = currentSongIndex + 1;
                }
                nextSongToBePlayed = this.ObservableOriginalSongs[nextIndex];
            }

            return nextSongToBePlayed;
        }
    }
}