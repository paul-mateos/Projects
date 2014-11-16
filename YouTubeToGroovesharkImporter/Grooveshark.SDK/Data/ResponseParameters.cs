using System;
using System.Collections.Generic;

namespace Grooveshark.SDK.Data
{
    /// <summary>
    /// Contains all properties of Grooveshark Response Object
    /// </summary>
    public class ResponseParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseParameters"/> class.
        /// </summary>
        public ResponseParameters()
        {
            result = new Dictionary<string, object>();
            header = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>
        /// The header.
        /// </value>
        public Dictionary<string, string> header { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public Dictionary<string, Object> result { get; set; }
    }
}
