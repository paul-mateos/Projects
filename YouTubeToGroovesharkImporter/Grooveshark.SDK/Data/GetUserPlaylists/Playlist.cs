using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grooveshark.SDK.Data.GetUserPlaylists
{
    /// <summary>
    /// Contains the properties of the play list object
    /// </summary>
    public class Playlist
    {
        /// <summary>
        /// Gets or sets the playlist identifier.
        /// </summary>
        /// <value>
        /// The playlist identifier.
        /// </value>
        public int PlaylistID { get; set; }

        /// <summary>
        /// Gets or sets the name of the playlist.
        /// </summary>
        /// <value>
        /// The name of the playlist.
        /// </value>
        public string PlaylistName { get; set; }

        /// <summary>
        /// Gets or sets the ts added.
        /// </summary>
        /// <value>
        /// The ts added.
        /// </value>
        public string TSAdded { get; set; }
    }
}
