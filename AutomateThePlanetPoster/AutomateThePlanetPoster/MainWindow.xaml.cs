using System.Windows;
using AutomateThePlanetPoster.Core;
using AutomateThePlanetPoster.Views;

namespace AutomateThePlanetPoster
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            currentContent.Content = new MainView();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PostsService.Instance.WritePostsToDisc();
        }
    }
}
