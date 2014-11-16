using System.Collections.Generic;

namespace Grooveshark.SDK.Data.GetSongSearchResults
{
    /// <summary>
    /// Returned by GetSongSearchResults Method
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Gets or sets the songs.
        /// </summary>
        /// <value>
        /// The songs.
        /// </value>
        public List<Song> songs { get; set; }
    }
}
