using System.Collections.Generic;

namespace Grooveshark.SDK.Data.GetUserPlaylists
{
    /// <summary>
    /// Returned by GetUserPlaylists Method
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Gets or sets the playlists.
        /// </summary>
        /// <value>
        /// The playlists.
        /// </value>
        public List<Playlist> playlists { get; set; }
    }
}
