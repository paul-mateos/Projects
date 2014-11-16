using System.Collections.Generic;

namespace Grooveshark.SDK.Data.AddUserFavoriteSong
{
    /// <summary>
    /// Returned by AddUserFavoriteSong Method
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Result"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool success { get; set; }
    }
}
