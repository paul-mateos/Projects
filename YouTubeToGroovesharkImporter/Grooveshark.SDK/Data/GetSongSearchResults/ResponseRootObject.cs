using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grooveshark.SDK.Data.GetSongSearchResults
{
    /// <summary>
    /// Response returned by GetSongSearchResults Method
    /// </summary>
    public class ResponseRootObject : BaseResponseRootObject
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public Result result { get; set; }
    }
}
