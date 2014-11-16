// <copyright file="ExecutionContext.cs" company="AANGELOV">
// http://aangelov.com All rights reserved.
// </copyright>
// <author>Anton Angelov</author>

namespace PhantomTube.Core.Core
{
    using AAngelov.Utilities.UI.ViewModels;
    using System.Collections.Generic;

    /// <summary>
    /// Contains App Execution Context Properties
    /// </summary>
    public static class ExecutionContext
    {
        /// <summary>
        /// Initializes the <see cref="ExecutionContext"/> class.
        /// </summary>
        static ExecutionContext()
        {
            PlayLists = new List<string>();
        }

        /// <summary>
        /// Gets or sets the settings view model.
        /// </summary>
        /// <value>
        /// The settings view model.
        /// </value>
        public static BaseSettingsViewModel SettingsViewModel { get; set; }


        /// <summary>
        /// Gets or sets the play lists.
        /// </summary>
        /// <value>
        /// The play lists.
        /// </value>
        public static List<string> PlayLists { get; set; }

        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        public static string CurrentUser { get; set; }
    }
}