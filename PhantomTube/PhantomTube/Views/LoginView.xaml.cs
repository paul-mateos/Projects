using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FirstFloor.ModernUI.Windows.Controls;
using PhantomTube.Core.ViewModels;
using FirstFloor.ModernUI.Presentation;

namespace PhantomTube.Views
{
    /// <summary>
    /// Login User Control Related Methods
    /// </summary>
    public partial class LoginView : UserControl
    {
        /// <summary>
        /// The required fields validation message
        /// </summary>
        private const string RequiredFieldsValidationMessage = "You should fill the required fields!";

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginView"/> class.
        /// </summary>
        public LoginView()
        {
            this.InitializeComponent();
            this.LoginViewModel = new LoginViewModel();
            this.DataContext = this.LoginViewModel;
        }

        /// <summary>
        /// Gets or sets the login view model.
        /// </summary>
        /// <value>
        /// The login view model.
        /// </value>
        public LoginViewModel LoginViewModel { get; set; }

        /// <summary>
        /// Handles the Click event of the btnLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            this.LoginViewModel.UserName = tbMemberUserName.Text;
            this.ResetValidationMessage();
            bool areFilled = this.LoginViewModel.AreRequiredCredentialsFieldsFilled();
            if (!areFilled)
            {
                this.DisplayValidationMessage(RequiredFieldsValidationMessage);
                return;
            }
            this.ShowProgressBar();
            this.LoginViewModel.Authenticate();
            this.HideProgressBar();
            this.ResetValidationMessage();
            this.AddNewLinksToWindow();
            this.DisplayAfterLoginActiveUserWindow();    
        }

        /// <summary>
        /// Hides the progress bar.
        /// </summary>
        private void HideProgressBar()
        {
            this.pbLoginLoading.Visibility = System.Windows.Visibility.Hidden;
        }

        /// <summary>
        /// Shows the progress bar.
        /// </summary>
        private void ShowProgressBar()
        {
            this.pbLoginLoading.Visibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// Displays the after login active user window.
        /// </summary>
        private void DisplayAfterLoginActiveUserWindow()
        {
            ModernWindow mw = Window.GetWindow(this) as ModernWindow;

            Uri u1 = new Uri("Views/YouTubePlayerView.xaml", UriKind.Relative);
            mw.ContentSource = u1;
        }

        /// <summary>
        /// Adds the new links to window.
        /// </summary>
        private void AddNewLinksToWindow()
        {
            ModernWindow mw = Window.GetWindow(this) as ModernWindow;
            mw.MenuLinkGroups.Clear();
            LinkGroup lg = new LinkGroup();

            Link l1 = new Link();
            l1.DisplayName = "Edit Playlists";
            Uri u1 = new Uri("/Views/YouTubePlaylistsEditView.xaml", UriKind.Relative);
            l1.Source = u1;
            mw.ContentSource = u1;
            lg.Links.Add(l1);

            Link l3 = new Link();
            l3.DisplayName = "YouTube Player";
            Uri u3 = new Uri("/Views/YouTubePlayerView.xaml", UriKind.Relative);
            l3.Source = u3;
            lg.Links.Add(l3);     
            mw.MenuLinkGroups.Add(lg);
        }

        /// <summary>
        /// Displays the validation message.
        /// </summary>
        /// <param name="validationMessage">The validation message.</param>
        private void DisplayValidationMessage(string validationMessage)
        {
            this.tbValidationMessage.Text = validationMessage;
            this.tbValidationMessage.Visibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// Resets the validation message.
        /// </summary>
        private void ResetValidationMessage()
        {
            this.tbValidationMessage.Text = String.Empty;
            this.tbValidationMessage.Visibility = System.Windows.Visibility.Hidden;
        }

        /// <summary>
        /// Handles the Loaded event of the UserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this.LoginViewModel;
        }
    }
}