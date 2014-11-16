using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grooveshark.SDK.Data
{
    /// <summary>
    /// Contains the properties of the song object
    /// </summary>
    public class Song
    {
        /// <summary>
        /// Gets or sets the song identifier.
        /// </summary>
        /// <value>
        /// The song identifier.
        /// </value>
        public int SongID { get; set; }

        /// <summary>
        /// Gets or sets the name of the song.
        /// </summary>
        /// <value>
        /// The name of the song.
        /// </value>
        public string SongName { get; set; }

        /// <summary>
        /// Gets or sets the artist identifier.
        /// </summary>
        /// <value>
        /// The artist identifier.
        /// </value>
        public int ArtistID { get; set; }

        /// <summary>
        /// Gets or sets the name of the artist.
        /// </summary>
        /// <value>
        /// The name of the artist.
        /// </value>
        public string ArtistName { get; set; }

        /// <summary>
        /// Gets or sets the album identifier.
        /// </summary>
        /// <value>
        /// The album identifier.
        /// </value>
        public int AlbumID { get; set; }

        /// <summary>
        /// Gets or sets the name of the album.
        /// </summary>
        /// <value>
        /// The name of the album.
        /// </value>
        public string AlbumName { get; set; }

        /// <summary>
        /// Gets or sets the cover art filename.
        /// </summary>
        /// <value>
        /// The cover art filename.
        /// </value>
        public string CoverArtFilename { get; set; }

        /// <summary>
        /// Gets or sets the popularity.
        /// </summary>
        /// <value>
        /// The popularity.
        /// </value>
        public string Popularity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is low bitrate available.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is low bitrate available; otherwise, <c>false</c>.
        /// </value>
        public bool IsLowBitrateAvailable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is verified.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is verified; otherwise, <c>false</c>.
        /// </value>
        public bool IsVerified { get; set; }

        /// <summary>
        /// Gets or sets the flags.
        /// </summary>
        /// <value>
        /// The flags.
        /// </value>
        public int Flags { get; set; }

        /// <summary>
        /// Gets or sets the sort.
        /// </summary>
        /// <value>
        /// The sort.
        /// </value>
        public int Sort { get; set; }
    }
}
