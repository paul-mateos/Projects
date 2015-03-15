using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AAngelov.Utilities.Managers;
using AutomateThePlanetPoster.Core;

namespace AutomateThePlanetPoster.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainViewModel MainViewModel { get; set; }
        public MainView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.MainViewModel = new MainViewModel();
            this.DataContext = this.MainViewModel;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.MainViewModel.WritePostsToDisc();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            string generatedContent = this.MainViewModel.GeneratePostsContent();
            Clipboard.SetText(generatedContent);
            MessageBox.Show("The content was copied to your clipboard.");
        }
    }
}
