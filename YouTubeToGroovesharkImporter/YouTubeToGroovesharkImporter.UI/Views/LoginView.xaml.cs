using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using YouTubeToGroovesharkImporter.Core.ViewModels;

namespace YouTubeToGroovesharkImporter.UI.Views
{
    /// <summary>
    /// Login User Control Related Methods
    /// </summary>
    public partial class LoginView : UserControl
    {
        /// <summary>
        /// The invalid credentials message
        /// </summary>
        private const string InvalidCredentialsMessage = "Invalid email or password!";

        /// <summary>
        /// The required fields validation message
        /// </summary>
        private const string RequiredFieldsValidationMessage = "You should fill the required fields!";

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginView"/> class.
        /// </summary>
        public LoginView()
        {
            InitializeComponent();
            this.LoginViewModel = new LoginViewModel();
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
            this.ResetValidationMessage();
            this.LoginViewModel.Password = tbPassword.Password;
            bool areFilled = this.LoginViewModel.AreRequiredCredentialsFieldsFilled();
            if (!areFilled)
            {
                this.DisplayValidationMessage(RequiredFieldsValidationMessage);
                return;
            }
            this.ShowProgressBar();
            bool isAuthenticated = false;
            Task t = Task.Factory.StartNew(() =>
            {
               isAuthenticated = this.LoginViewModel.Authenticate();
            });
            t.ContinueWith(antecedent =>
            {
                this.HideProgressBar();
                if (!isAuthenticated)
                {
                    this.DisplayIncorrectUserCredentialsMessage();
                }
                else
                {
                    this.ResetValidationMessage();
                    this.DisplayAfterLoginActiveUserWindow();
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());          
        }

        /// <summary>
        /// Hides the progress bar.
        /// </summary>
        private void HideProgressBar()
        {
            pbLoginLoading.Visibility = System.Windows.Visibility.Hidden;
        }

        /// <summary>
        /// Shows the progress bar.
        /// </summary>
        private void ShowProgressBar()
        {
            pbLoginLoading.Visibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// Displays the incorrect user credentials message.
        /// </summary>
        private void DisplayIncorrectUserCredentialsMessage()
        {
            this.DisplayValidationMessage(InvalidCredentialsMessage);
        }

        /// <summary>
        /// Displays the after login active user window.
        /// </summary>
        private void DisplayAfterLoginActiveUserWindow()
        {
            ModernWindow mw = Window.GetWindow(this) as ModernWindow;

            mw.MenuLinkGroups.Clear();
            Uri u1 = new Uri("Views/YouTubeSongsImportView.xaml", UriKind.Relative);
            mw.ContentSource = u1;
        }

        /// <summary>
        /// Displays the validation message.
        /// </summary>
        /// <param name="validationMessage">The validation message.</param>
        private void DisplayValidationMessage(string validationMessage)
        {
            tbValidationMessage.Text = validationMessage;
            tbValidationMessage.Visibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// Resets the validation message.
        /// </summary>
        private void ResetValidationMessage()
        {
            tbValidationMessage.Text = String.Empty;
            tbValidationMessage.Visibility = System.Windows.Visibility.Hidden;
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
