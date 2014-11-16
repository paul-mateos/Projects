using System.Collections.Generic;

namespace Grooveshark.SDK.Data.Artist
{
    /// <summary>
    /// Returned by artist queries
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Gets or sets the pager.
        /// </summary>
        /// <value>
        /// The pager.
        /// </value>
        public Pager pager { get; set; }

        /// <summary>
        /// Gets or sets the artists.
        /// </summary>
        /// <value>
        /// The artists.
        /// </value>
        public List<Artist> artists { get; set; }
    }
}
