// <copyright file="Navigator.cs" company="AANGELOV">
// http://aangelov.com All rights reserved.
// </copyright>
// <author>Anton Angelov</author>
namespace YouTubeToGroovesharkImporter.Core.BusinessLogic.Core
{
    using System;
    using System.Windows;
    using AAngelov.Utilities.UI.Core;

    /// <summary>
    /// Contains methods which navigate to different views with option to set different parameters
    /// </summary>
    public static class Navigator
    {    
        /// <summary>
        /// Navigates to appearance settings view.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void NavigateToAppearanceSettingsView(this FrameworkElement source)
        {
            source.Navigate("/Views/SettingsView.xaml");
        }
    }
}
