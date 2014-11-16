using System.Collections.Generic;

namespace Grooveshark.SDK.Data.GetPlaylist
{
    /// <summary>
    /// Returned by GetPlaylist Method
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Gets or sets the name of the playlist.
        /// </summary>
        /// <value>
        /// The name of the playlist.
        /// </value>
        public string PlaylistName { get; set; }

        /// <summary>
        /// Gets or sets the ts modified.
        /// </summary>
        /// <value>
        /// The ts modified.
        /// </value>
        public int TSModified { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the playlist description.
        /// </summary>
        /// <value>
        /// The playlist description.
        /// </value>
        public string PlaylistDescription { get; set; }

        /// <summary>
        /// Gets or sets the cover art filename.
        /// </summary>
        /// <value>
        /// The cover art filename.
        /// </value>
        public string CoverArtFilename { get; set; }

        /// <summary>
        /// Gets or sets the songs.
        /// </summary>
        /// <value>
        /// The songs.
        /// </value>
        public List<Song> Songs { get; set; }
    }
}
