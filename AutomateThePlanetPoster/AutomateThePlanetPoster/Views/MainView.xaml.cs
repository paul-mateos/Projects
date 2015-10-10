using System.Windows;
using System.Windows.Controls;
using AutomateThePlanetPoster.Core;

namespace AutomateThePlanetPoster.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = PostsService.Instance;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            PostsService.Instance.WritePostsToDisc();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            string generatedContent = PostsService.Instance.GeneratePostsContent();
            Clipboard.SetText(generatedContent);
            MessageBox.Show("The content was copied to your clipboard.");
        }

        private void btnBeautifyHtml_Click(object sender, RoutedEventArgs e)
        {
            string sourceHtmlString = tbSourceHtml.Text;
            if (string.IsNullOrEmpty(sourceHtmlString))
            {
                MessageBox.Show("The source HTML cannot be empty.");
            }
            else
            {
                CodeProjectArticlesBeautifierService beautifyService = new CodeProjectArticlesBeautifierService();
                string generatedContent = beautifyService.Beautify(sourceHtmlString);
                Clipboard.SetText(generatedContent);
                MessageBox.Show("The content was copied to your clipboard.");
            }
        }
    }
}