// <copyright file="ExecutionContext.cs" company="CodePlex">
// https://testcasemanager.codeplex.com/ All rights reserved.
// </copyright>
// <author>Anton Angelov</author>
namespace TestCaseManagerCore.Core
{
    using System.Collections.Generic;
    using TestCaseManagerCore.ViewModels;
    using TreeNotebookCore.ViewModels;

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
        public static SettingsViewModel SettingsViewModel { get; set; }
    }
}
