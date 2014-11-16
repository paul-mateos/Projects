using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ATADataModel;
using CustomControls;
using FirstFloor.ModernUI.Presentation;
using AutomationTestAssistantCore;

namespace AutomationTestAssistantDesktopApp
{
    public partial class MemberViewModel : NotifyPropertyChanged
    {
        private const string RequiredValueMessage = "Required value";
        private string userName;
        private string password;
        private List<CheckedItem> teams;

        public MemberViewModel()
        {
            UserName = userName;
            Password = password;
        }
        public List<string> Roles { get; set; }
        public List<CheckedItem> Teams { get; set; }
        public string Email { get; set; }
        public string TfsUserName { get; set; }
        public string Comment { get; set; }
        public string PasswordConfirm { get; set; }

        public string UserName
        {
            get { return this.userName; }
            set
            {
                if (this.userName != value) {
                    this.userName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }

        public string Password
        {
            get { return this.password; }
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    OnPropertyChanged("Password");
                }
            }
        }    

        public List<CheckedItem> GetTeams()
        {
            if (teams == null)
            {
                var context = new ATAEntities();
                var query = from x in context.Teams
                            select new CheckedItem
                            {
                                Description = x.Name,
                                Selected = false
                            };
                teams = query.ToList();           
            }
            return teams;
        }

        public List<string> GetRoles()
        {
            if (Roles == null)
            {
                var context = new ATAEntities();
                Roles = context.MemberRoles.Select(x => x.Role).ToList();
            }
            return Roles;
        }
        
        public string Error
        {
            get { return null; }
        }

        public bool AreRequiredFieldsFilled()
        {
            bool areFilled = true;
            areFilled = String.IsNullOrEmpty(UserName.CleanSpaces()) ? false : true;
            areFilled = String.IsNullOrEmpty(Password.CleanSpaces()) ? false : true;
            areFilled = String.IsNullOrEmpty(PasswordConfirm.CleanSpaces()) ? false : true;
            areFilled = String.IsNullOrEmpty(Email.CleanSpaces()) ? false : true;
            areFilled = String.IsNullOrEmpty(TfsUserName.CleanSpaces()) ? false : true;
            areFilled = GetTeams().Where(x => x.Selected.Equals(true)).ToList().Count == 0 ? false : true;

            return areFilled;
        }

        public bool AreRequiredCredentialsFieldsFilled()
        {
            bool areFilled = true;
            areFilled = String.IsNullOrEmpty(UserName.CleanSpaces()) ? false : true;
            areFilled = String.IsNullOrEmpty(Password.CleanSpaces()) ? false : true;

            return areFilled;
        }

        public bool ArePasswordEqual()
        {
            return Password.Equals(PasswordConfirm);
        }

        //public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        //{
        //    return string.IsNullOrEmpty((string)value) ? 
        //        new ValidationResult(false, RequiredValueMessage) :
        //        new ValidationResult(true, null);       
        //}

        //public string this[string columnName]
        //{
        //    get
        //    {
        //        if (columnName == "UserName")
        //            return string.IsNullOrEmpty(this.UserName) ? RequiredValueMessage : null;
        //        if (columnName == "Password")
        //            return string.IsNullOrEmpty(this.Password) ? RequiredValueMessage : null;
        //        return null;
        //    }
        //}

       
    }
}
