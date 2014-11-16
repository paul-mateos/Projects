namespace Grooveshark.SDK.Data.Artist
{
    /// <summary>
    /// Returned by query service methods
    /// </summary>
    public class Pager
    {
        /// <summary>
        /// Gets or sets the number pages.
        /// </summary>
        /// <value>
        /// The number pages.
        /// </value>
        public int numPages { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has previous page.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has previous page; otherwise, <c>false</c>.
        /// </value>
        public bool hasPrevPage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has next page.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has next page; otherwise, <c>false</c>.
        /// </value>
        public bool hasNextPage { get; set; }
    }
}
