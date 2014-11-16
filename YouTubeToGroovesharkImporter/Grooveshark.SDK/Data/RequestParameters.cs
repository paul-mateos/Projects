using System;
using System.Collections.Generic;

namespace Grooveshark.SDK.Data
{
    /// <summary>
    /// Contains all needed parameters for valid Grooveshark request
    /// </summary>
    public class RequestParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestParameters"/> class.
        /// </summary>
        public RequestParameters()
        {
            parameters = new Dictionary<string, object>();
            header = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        /// <value>
        /// The method.
        /// </value>
        public string method { get; set; }

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>
        /// The header.
        /// </value>
        public Dictionary<string, string> header { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public Dictionary<string, Object> parameters { get; set; }
    }
}
