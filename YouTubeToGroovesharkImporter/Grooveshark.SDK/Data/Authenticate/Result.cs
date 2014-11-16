using System.Collections.Generic;

namespace Grooveshark.SDK.Data.Authenticate
{
    /// <summary>
    /// Returned by Authenticate Method
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the name of the f.
        /// </summary>
        /// <value>
        /// The name of the f.
        /// </value>
        public string FName { get; set; }

        /// <summary>
        /// Gets or sets the name of the l.
        /// </summary>
        /// <value>
        /// The name of the l.
        /// </value>
        public string LName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is plus.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is plus; otherwise, <c>false</c>.
        /// </value>
        public bool IsPlus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is anywhere.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is anywhere; otherwise, <c>false</c>.
        /// </value>
        public bool IsAnywhere { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is premium.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is premium; otherwise, <c>false</c>.
        /// </value>
        public bool IsPremium { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Result"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool success { get; set; }
    }
}
