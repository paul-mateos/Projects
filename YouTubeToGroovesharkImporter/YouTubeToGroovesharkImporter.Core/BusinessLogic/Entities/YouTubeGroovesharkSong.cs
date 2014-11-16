using AAngelov.Utilities.UI.Core;
namespace YouTubeToGroovesharkImporter.Core.BusinessLogic.Entities
{
    /// <summary>
    /// YouTube Grooveshark Import Song Entity
    /// </summary>
    public class YouTubeGroovesharkSong : BaseNotifyPropertyChanged
    {
        private string youTubeArtist;

        private int youTubeArtistId;

        private string youTubeSongTitle;

        private string groovesharkArtist;

        private int groovesharkArtistId;

        private string groovesharkSongTitle;

        private int groovesharkSongId;

        /// <summary>
        /// Initializes a new instance of the <see cref="YouTubeGroovesharkSong"/> class.
        /// </summary>
        /// <param name="youTubeArtist">You tube artist.</param>
        /// <param name="youTubeSongTitle">You tube song title.</param>
        public YouTubeGroovesharkSong(string youTubeArtist, string youTubeSongTitle)
        {
            this.YouTubeArtist = youTubeArtist;
            this.YouTubeSongTitle = youTubeSongTitle;
        }

        /// <summary>
        /// Gets or sets you tube artist.
        /// </summary>
        /// <value>
        /// You tube artist.
        /// </value>
        public string YouTubeArtist
        {
            get
            {
                return this.youTubeArtist;
            }

            set
            {
                this.youTubeArtist = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets you tube artist identifier.
        /// </summary>
        /// <value>
        /// You tube artist identifier.
        /// </value>
        public int YouTubeArtistId
        {
            get
            {
                return this.youTubeArtistId;
            }

            set
            {
                this.youTubeArtistId = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets you tube song title.
        /// </summary>
        /// <value>
        /// You tube song title.
        /// </value>
        public string YouTubeSongTitle
        {
            get
            {
                return this.youTubeSongTitle;
            }

            set
            {
                this.youTubeSongTitle = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the grooveshark artist.
        /// </summary>
        /// <value>
        /// The grooveshark artist.
        /// </value>
        public string GroovesharkArtist
        {
            get
            {
                return this.groovesharkArtist;
            }

            set
            {
                this.groovesharkArtist = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the grooveshark artist identifier.
        /// </summary>
        /// <value>
        /// The grooveshark artist identifier.
        /// </value>
        public int GroovesharkArtistId
        {
            get
            {
                return this.groovesharkArtistId;
            }

            set
            {
                this.groovesharkArtistId = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the grooveshark song title.
        /// </summary>
        /// <value>
        /// The grooveshark song title.
        /// </value>
        public string GroovesharkSongTitle
        {
            get
            {
                return this.groovesharkSongTitle;
            }

            set
            {
                this.groovesharkSongTitle = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the grooveshark song identifier.
        /// </summary>
        /// <value>
        /// The grooveshark song identifier.
        /// </value>
        public int GroovesharkSongId
        {
            get
            {
                return this.groovesharkSongId;
            }

            set
            {
                this.groovesharkSongId = value;
                this.NotifyPropertyChanged();
            }
        }
    }
}
