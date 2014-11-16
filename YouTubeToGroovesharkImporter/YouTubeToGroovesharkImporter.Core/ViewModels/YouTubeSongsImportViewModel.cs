using AAngelov.Utilities.UI.Core;
using Grooveshark.SDK;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using YouTube.SDK;
using YouTubeToGroovesharkImporter.Core.BusinessLogic.Core;
using YouTubeToGroovesharkImporter.Core.BusinessLogic.Entities;
using Artist = Grooveshark.SDK.Data.Artist;
using GetSongSearchResults = Grooveshark.SDK.Data.GetSongSearchResults;

namespace YouTubeToGroovesharkImporter.Core.ViewModels
{
    /// <summary>
    /// Contains Methods Related to YouTube Songs Import View
    /// </summary>
    public class YouTubeSongsImportViewModel : BaseNotifyPropertyChanged
    {
        /// <summary>
        /// The log
        /// </summary>
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The regex song pattern
        /// </summary>
        private static string RegexSongPattern = @"\s*(?<Artist>[a-zA-Z1-9\s\w]{1,})-(?<Name>[a-zA-Z1-9\-\s\w""']{1,})";

        /// <summary>
        /// You tube playlis identifier
        /// </summary>
        private string youTubePlaylisId;

        /// <summary>
        /// The songs count
        /// </summary>
        private int songsCount;

        /// <summary>
        /// You tube user
        /// </summary>
        private string youTubeUser;

        /// <summary>
        /// The selected playlist
        /// </summary>
        private YouTubePlayList selectedPlaylist;

        /// <summary>
        /// The songs added to grooveshark
        /// </summary>
        public int songsAddedToGrooveshark;

        /// <summary>
        /// Initializes a new instance of the <see cref="YouTubeSongsImportViewModel"/> class.
        /// </summary>
        public YouTubeSongsImportViewModel()
        {
            this.ObservableSongs = new ObservableCollection<YouTubeGroovesharkSong>();
            this.ObservablePlaylists = new ObservableCollection<YouTubePlayList>();
            this.songsAddedToGrooveshark = 0;
        }
        /// <summary>
        /// Gets or sets the observable songs.
        /// </summary>
        /// <value>
        /// The observable songs.
        /// </value>
        public ObservableCollection<YouTubeGroovesharkSong> ObservableSongs { get; set; }

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
        /// Populates you tube songs.
        /// </summary>
        public List<YouTubeGroovesharkSong> PopulateYouTubeSongs()
        {
            List<string> playListSongs = new List<string>();
            playListSongs = YouTubeServiceClient.Instance.GetPlayListSongs(this.YouTubeUser, this.SelectedPlaylist.Id);
            Regex regexNamespaceInitializations = new Regex(RegexSongPattern, RegexOptions.None);

            List<YouTubeGroovesharkSong> youTubeGroovesharkSong = new List<YouTubeGroovesharkSong>();
            foreach (string currentPlayListSong in playListSongs)
            {
                Match m = regexNamespaceInitializations.Match(currentPlayListSong);
                if (m.Success)
                {
                    youTubeGroovesharkSong.Add(new YouTubeGroovesharkSong(m.Groups["Artist"].ToString(), m.Groups["Name"].ToString()));
                }
            }

            return youTubeGroovesharkSong;
        }

        /// <summary>
        /// Populates you tube playlists.
        /// </summary>
        public List<YouTubePlayList> PopulateYouTubePlaylists()
        {
            List<YouTubePlayList> playlists = YouTubeServiceClient.Instance.GetUserPlayLists(this.YouTubeUser);
            return playlists;
        }

        /// <summary>
        /// Maps you tube songs to grooveshark.
        /// </summary>
        /// <param name="songsToMap">The songs to map.</param>
        /// <returns></returns>
        public List<YouTubeGroovesharkSong> MapYouTubeSongsToGrooveshark(List<YouTubeGroovesharkSong> songsToMap)
        {
            GroovesharkService groovesharkService = new GroovesharkService();
            this.MapSongsArtists(songsToMap, groovesharkService);
            this.MapSongsTitles(songsToMap, groovesharkService);

            return songsToMap;
        }

        /// <summary>
        /// Retries the current song mapping.
        /// </summary>
        /// <param name="song">The song.</param>
        public void RetryCurrentSongMapping(YouTubeGroovesharkSong song)
        {
            GroovesharkService groovesharkService = new GroovesharkService();
            this.MapYouTubeArtistToGroovesharkArtist(groovesharkService, song);
            this.MapYouTubeSongTitleToGroovesharkSongTitle(groovesharkService, song);
        }
        /// <summary>
        /// Maps the songs artists.
        /// </summary>
        /// <param name="songsToMap">The songs to map.</param>
        /// <param name="groovesharkService">The grooveshark service.</param>
        private void MapSongsArtists(List<YouTubeGroovesharkSong> songsToMap, GroovesharkService groovesharkService)
        {
            foreach (YouTubeGroovesharkSong currentSong in songsToMap)
            {
                this.MapYouTubeArtistToGroovesharkArtist(groovesharkService, currentSong);
            }
        }

        /// <summary>
        /// Maps you tube artist to grooveshark artist.
        /// </summary>
        /// <param name="groovesharkService">The grooveshark service.</param>
        /// <param name="currentSong">The current song.</param>
        private void MapYouTubeArtistToGroovesharkArtist(GroovesharkService groovesharkService, YouTubeGroovesharkSong currentSong)
        {
            Artist.Result artistResult = null;
            if (currentSong.YouTubeArtist != null)
            {
                artistResult = groovesharkService.GetArtistSearchResults(currentSong.YouTubeArtist, 5);
            }
            if (artistResult == null || artistResult.artists.Count == 0)
            {
                return;
            }
            string artistName = string.Empty;
            int artistId = default(int);

            var query = artistResult.artists.Where(x => x != null && x.ArtistName.ToLower().Equals(currentSong.YouTubeArtist.Trim().ToLower()));
            if (query.Count() > 0)
            {
                artistName = query.FirstOrDefault().ArtistName;
                artistId = query.FirstOrDefault().ArtistID;
            }
            if (string.IsNullOrEmpty(artistName))
            {
                query = artistResult.artists.Where(x => x != null && x.IsVerified.Equals(true));
                if (query.Count() > 0)
                {
                    artistName = query.FirstOrDefault().ArtistName;
                    artistId = query.FirstOrDefault().ArtistID;
                }
            }
            if (string.IsNullOrEmpty(artistName))
            {
                artistName = artistResult.artists.FirstOrDefault().ArtistName;
                artistId = artistResult.artists.FirstOrDefault().ArtistID;
            }
            currentSong.GroovesharkArtist = artistName;
            currentSong.GroovesharkArtistId = artistId;
        }

        /// <summary>
        /// Maps the songs titles.
        /// </summary>
        /// <param name="songsToMap">The songs to map.</param>
        /// <param name="groovesharkService">The grooveshark service.</param>
        private void MapSongsTitles(List<YouTubeGroovesharkSong> songsToMap, GroovesharkService groovesharkService)
        {
            foreach (YouTubeGroovesharkSong currentSong in songsToMap)
            {
                if (string.IsNullOrEmpty(currentSong.GroovesharkArtist) || currentSong.GroovesharkArtistId == 0)
                {
                    continue;
                }
                this.MapYouTubeSongTitleToGroovesharkSongTitle(groovesharkService, currentSong);
            }
        }

        /// <summary>
        /// Maps you tube song title to grooveshark song title.
        /// </summary>
        /// <param name="groovesharkService">The grooveshark service.</param>
        /// <param name="currentSong">The current song.</param>
        private void MapYouTubeSongTitleToGroovesharkSongTitle(GroovesharkService groovesharkService, YouTubeGroovesharkSong currentSong)
        {
            string searchName = currentSong.YouTubeSongTitle;
            string songTitle = string.Empty;
            int songId = default(int);
            bool shouldBreak = false;

            do
            {
                GetSongSearchResults.Result songsResult = null;
                searchName = this.TrimSpecialCharacters(searchName);
                if (currentSong.YouTubeArtist != null)
                {
                    songsResult = groovesharkService.GetSongSearchResults(searchName, limit: 20);
                }

                if (songsResult == null || songsResult.songs == null || songsResult.songs.Count == 0)
                {
                    searchName = GetNewSearchSongName(searchName, out shouldBreak);
                    if (shouldBreak)
                    {
                        break;
                    }
                    continue;
                }

                songTitle = string.Empty;
                songId = default(int);

                var query = songsResult.songs.Where(x => x != null && x.SongName != null && x.SongName.ToLower().Contains(searchName.Trim().ToLower()));
                if (query.Count() > 0)
                {
                    var searchedSong = query.FirstOrDefault(s => s.ArtistID.Equals(currentSong.GroovesharkArtistId));
                    if (searchedSong != null)
                    {
                        songTitle = searchedSong.SongName;
                        songId = searchedSong.SongID;
                    }
                }
                if (!string.IsNullOrEmpty(songTitle))
                {
                    break;
                }
                searchName = GetNewSearchSongName(searchName, out shouldBreak);
                if (shouldBreak)
                {
                    break;
                }
            }
            while (string.IsNullOrEmpty(songTitle));
            if (string.IsNullOrEmpty(songTitle) && songId == 0)
            {
                searchName = currentSong.YouTubeSongTitle;
                searchName = this.TrimSpecialCharacters(searchName);
                GetSongSearchResults.Result popularSongs = groovesharkService.GetArtistPopularSongs(currentSong.GroovesharkArtistId);
                songTitle = string.Empty;
                songId = default(int);
                do
                {
                    var query = popularSongs.songs.Where(x => x != null && x.SongName != null && x.SongName.ToLower().Contains(searchName.Trim().ToLower()));
                    if (query.Count() > 0)
                    {
                        var searchedSong = query.FirstOrDefault();
                        if (searchedSong != null)
                        {
                            songTitle = searchedSong.SongName;
                            songId = searchedSong.SongID;
                        }
                    }
                    if (!string.IsNullOrEmpty(songTitle))
                    {
                        break;
                    }
                    searchName = GetNewSearchSongName(searchName, out shouldBreak);
                    if (shouldBreak)
                    {
                        break;
                    }
                }
                while (string.IsNullOrEmpty(songTitle));
            }
            if (!string.IsNullOrEmpty(songTitle) && songId != 0)
            {
                currentSong.GroovesharkSongTitle = songTitle;
                currentSong.GroovesharkSongId = songId;
            }
        }

        /// <summary>
        /// Adds the songs to grooveshark.
        /// </summary>
        public void AddSongsToGrooveshark()
        {
            this.songsAddedToGrooveshark = 0;
            foreach (var currentSong in this.ObservableSongs)
            {
                bool isSuccessfullyAdded = false;
                if (currentSong.GroovesharkSongId != 0)
                {
                    isSuccessfullyAdded = GroovesharkService.Instance.AddUserFavoriteSong(currentSong.GroovesharkSongId, ExecutionContext.SessionId);
                }
                if (isSuccessfullyAdded)
                {
                    this.songsAddedToGrooveshark++;
                }
            }
        }

        /// <summary>
        /// Gets the new name of the search song.
        /// </summary>
        /// <param name="currentSong">The current song.</param>
        /// <param name="searchName">Name of the search.</param>
        /// <param name="shouldBreak">if set to <c>true</c> [should break].</param>
        /// <returns></returns>
        private string GetNewSearchSongName(string searchName, out bool shouldBreak)
        {
            string[] searchNameStr = searchName.Trim().Split(' ');
            string newSearchName = string.Empty;
            shouldBreak = false;

            for (int i = 0; i < searchNameStr.Length - 1; i++)
            {
                newSearchName += searchNameStr[i];
                newSearchName += " ";
            }
            newSearchName = this.TrimSpecialCharacters(newSearchName);

            if (newSearchName.Equals(searchName))
            {
                shouldBreak = true;
            }

            return newSearchName;
        }

        /// <summary>
        /// Trims the song title special characters.
        /// </summary>
        /// <param name="songTitle">The song title.</param>
        /// <returns>the trimmed string</returns>
        private string TrimSpecialCharacters(string songTitle)
        {
            string result = songTitle.Trim(new char[] {'?', '!', '"', '\'', '(', ')', '-', '_', ' ', '#', '@', '$', '%'});
            return result;
        }
    } 
}
