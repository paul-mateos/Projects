using System;
using AAngelov.Utilities.UI.Core;
using FirstFloor.ModernUI.Windows.Controls;
using PhantomTube.Core.Core;
using PhantomTube.Core.Managers;

namespace PhantomTube.Core.ViewModels
{
    /// <summary>
    /// Contains Methods Related to the Login View
    /// </summary>
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
            this.UserName = RegistryManager.Instance.ReadUserName();
        }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                if (this.userName != value)
                {
                    this.userName = value;
                    RegistryManager.Instance.WriteUserName(this.userName);
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
            get
            {
                return this.password;
            }
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
            get
            {
                return null;
            }
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

            return areFilled;
        }

        /// <summary>
        /// Authenticates this instance.
        /// </summary>
        public void Authenticate()
        {
            ExecutionContext.CurrentUser = this.UserName;
        }
    }
}