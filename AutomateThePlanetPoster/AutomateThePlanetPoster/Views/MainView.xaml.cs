using System.Windows;
using System.Windows.Controls;
using AutomateThePlanetPoster.Core;

namespace AutomateThePlanetPoster.Views
{
    public partial class MainView : UserControl
    {
        public PostsService MainViewModel { get; set; }
        public MainView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.MainViewModel = new PostsService();
            this.DataContext = this.MainViewModel;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            PostsService.WritePostsToDisc();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            string generatedContent = PostsService.GeneratePostsContent();
            Clipboard.SetText(generatedContent);
            MessageBox.Show("The content was copied to your clipboard.");
        }
    }
}
