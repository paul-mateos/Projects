// <copyright file="ExecutionContext.cs" company="AANGELOV">
// http://aangelov.com All rights reserved.
// </copyright>
// <author>Anton Angelov</author>
namespace YouTubeToGroovesharkImporter.Core.BusinessLogic.Core
{
    using AAngelov.Utilities.UI.ViewModels;

    /// <summary>
    /// Contains App Execution Context Properties
    /// </summary>
    public class ExecutionContext
    {       
        /// <summary>
        /// Gets or sets the settings view model.
        /// </summary>
        /// <value>
        /// The settings view model.
        /// </value>
        public static BaseSettingsViewModel SettingsViewModel { get; set; }

        /// <summary>
        /// Gets or sets the session identifier.
        /// </summary>
        /// <value>
        /// The session identifier.
        /// </value>
        public static string SessionId { get; set; }

        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        public Grooveshark.SDK.Data.Authenticate.Result CurrentUser { get; set; }
    }
}
