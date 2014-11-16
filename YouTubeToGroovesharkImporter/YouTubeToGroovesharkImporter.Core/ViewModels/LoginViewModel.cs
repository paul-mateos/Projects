using AAngelov.Utilities.UI.Core;
using FirstFloor.ModernUI.Windows.Controls;
using Grooveshark.SDK;
using System;
using System.Windows;
using YouTubeToGroovesharkImporter.Core.BusinessLogic.Core;
using Authenticate = Grooveshark.SDK.Data.Authenticate;
using Session = Grooveshark.SDK.Data.Session;

namespace YouTubeToGroovesharkImporter.Core.ViewModels
{
    public partial class LoginViewModel : BaseNotifyPropertyChanged
    {
        private const string RequiredValueMessage = "Required value";
        private string userName;
        private string password;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        public LoginViewModel()
        {
            UserName = userName;
            Password = password;
            try
            {
                Session.Result sessionStartResult = GroovesharkService.Instance.StartSession();
                if (!sessionStartResult.success)
                {
                    this.ShowServiceUnavailableDialog();
                }
                else
                {
                    ExecutionContext.SessionId = sessionStartResult.sessionID;
                }
            }
            catch(Exception ex)
            {
                this.ShowServiceUnavailableDialog();
            }
        }       

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName
        {
            get { return this.userName; }
            set
            {
                if (this.userName != value)
                {
                    this.userName = value;
                    this.NotifyPropertyChanged("UserName");
                }
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password
        {
            get { return this.password; }
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    this.NotifyPropertyChanged("Password");
                }
            }
        }

        /// <summary>
        /// Gets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        public string Error
        {
            get { return null; }
        }

        /// <summary>
        /// Ares the required credentials fields filled.
        /// </summary>
        /// <returns></returns>
        public bool AreRequiredCredentialsFieldsFilled()
        {
            bool areFilled = true;
            if (string.IsNullOrEmpty(this.UserName))
            {
                areFilled = false;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                areFilled = false;
            }

            return areFilled;
        }

        /// <summary>
        /// Authenticates this instance.
        /// </summary>
        public bool Authenticate()
        {

            Authenticate.Result result = GroovesharkService.Instance.Authenticate(this.UserName, this.Password, ExecutionContext.SessionId);

           return result.success;
        }

        /// <summary>
        /// Shows the service unavailable dialog.
        /// </summary>
        private void ShowServiceUnavailableDialog()
        {
            ModernDialog.ShowMessage("The Grooveshark Service is currently unavailable please try again later!", "Warning", MessageBoxButton.OK);
        }
    }
}
