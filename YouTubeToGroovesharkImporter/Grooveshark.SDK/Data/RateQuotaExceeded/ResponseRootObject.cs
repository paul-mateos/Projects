using System.Collections.Generic;

namespace Grooveshark.SDK.Data.RateQuotaExceeded
{
    /// <summary>
    /// Response returned by Rate Quota Exceeded Error
    /// </summary>
    public class ResponseRootObject : BaseResponseRootObject
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public object result { get; set; }

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public List<Error> errors { get; set; }
    }
}
