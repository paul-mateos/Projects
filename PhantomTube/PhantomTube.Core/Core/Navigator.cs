// <copyright file="Navigator.cs" company="AANGELOV">
// http://aangelov.com All rights reserved.
// </copyright>
// <author>Anton Angelov</author>

namespace PhantomTube.Core.Core
{
    using System;
    using System.Windows;
    using AAngelov.Utilities.UI.Core;

    /// <summary>
    /// Contains methods which navigate to different views with option to set different parameters
    /// </summary>
    public class Navigator : BaseNavigator
    { 
        /// <summary>
        /// Navigates to appearance settings view.
        /// </summary>
        /// <param name="source">The source.</param>
        public void NavigateToAppearanceSettingsView(FrameworkElement source)
        {
            this.Navigate(source, "/Views/SettingsView.xaml");
        }
    }
}