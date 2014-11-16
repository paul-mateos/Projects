using AAngelov.Utilities.UI.Core;
using Google.Apis.YouTube.v3.Data;
using YouTube.SDK.Entities.Contracts;
using System;

namespace YouTube.SDK.Entities
{
    /// <summary>
    /// YouTube Grooveshark Import Song Entity
    /// </summary>
    public class YouTubeSong : BaseNotifyPropertyChanged, IYouTubeSong, IEquatable<YouTubeSong>
    {
        private string artist;

        private string title;

        private string songId;

        private string originalTitle;

        private Guid songGuid;

        /// <summary>
        /// Initializes a new instance of the <see cref="YouTubeSong"/> class.
        /// </summary>
        public YouTubeSong()
        {
            this.SongGuid = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YouTubeSong" /> class.
        /// </summary>
        /// <param name="artist">You tube artist.</param>
        /// <param name="title">You tube song title.</param>
        /// <param name="originalTitle">The original title.</param>
        /// <param name="songId">The song identifier.</param>
        /// <param name="playlistItemId">The playlist item identifier.</param>
        /// <param name="duration">The duration.</param>
        public YouTubeSong(
            string artist, 
            string title, 
            string originalTitle, 
            string songId, 
            string playlistItemId, 
            ulong? duration)
            : this()
        {
            this.Artist = artist;
            this.Title = title;
            this.OriginalTitle = originalTitle;
            this.SongId = songId;
            this.PlayListItemId = playlistItemId;
            this.Duration = duration;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YouTubeSong"/> class.
        /// </summary>
        /// <param name="iYouTubeSong">The i you tube song.</param>
        public YouTubeSong(IYouTubeSong iYouTubeSong)
        {
            this.Artist = iYouTubeSong.Artist;
            this.Title = iYouTubeSong.Title;
            this.SongId = iYouTubeSong.SongId;
            this.PlayListItemId = iYouTubeSong.PlayListItemId;
            this.Duration = iYouTubeSong.Duration;
            this.OriginalTitle = iYouTubeSong.OriginalTitle;
            this.SongGuid = iYouTubeSong.SongGuid;
        }

        /// <summary>
        /// Gets or sets the play list item identifier.
        /// </summary>
        /// <value>
        /// The play list item identifier.
        /// </value>
        public string PlayListItemId { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public ulong? Duration { get; set; }

        /// <summary>
        /// Gets or sets you tube artist.
        /// </summary>
        /// <value>
        /// You tube artist.
        /// </value>
        public string Artist
        {
            get
            {
                return this.artist;
            }

            set
            {
                this.artist = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the original title.
        /// </summary>
        /// <value>
        /// The original title.
        /// </value>
        public string OriginalTitle
        {
            get
            {
                return this.originalTitle;
            }

            set
            {
                this.originalTitle = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the song unique identifier.
        /// </summary>
        /// <value>
        /// The song unique identifier.
        /// </value>
        public Guid SongGuid
        {
            get
            {
                return this.songGuid;
            }

            set
            {
                if (this.songGuid == default(Guid))
                {
                    this.songGuid = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the song identifier.
        /// </summary>
        /// <value>
        /// The song identifier.
        /// </value>
        public string SongId
        {
            get
            {
                return this.songId;
            }

            set
            {
                this.songId = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url
        {
            get
            {
                return string.Concat("https://www.youtube.com/watch?v=", this.SongId);
            }
        }

        /// <summary>
        /// Gets or sets you tube song title.
        /// </summary>
        /// <value>
        /// You tube song title.
        /// </value>
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
                this.NotifyPropertyChanged();
            }
        }       

        /// <summary>
        /// Gets or sets a value indicating whether this instance is imported.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is imported; otherwise, <c>false</c>.
        /// </value>
        public bool IsImported { get; set; }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(YouTubeSong other)
        {
            return this.SongId.Equals(other.SongId);
        }
    }
}