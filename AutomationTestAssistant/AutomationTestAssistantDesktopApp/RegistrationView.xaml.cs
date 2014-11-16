using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using CustomControls;
using System.Collections.ObjectModel;
using ATADataModel;
using AutomationTestAssistantCore;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Navigation;

namespace AutomationTestAssistantDesktopApp
{
    public partial class RegistrationView : UserControl
    {
        private const string ToBeApprovedMessage = "Your Account will be approved in short period!";
        private const string InvalidCredentialsMessage = "Invalid email or password!";
        private const string RequiredFieldsValidationMessage = "You should fill required fields!";
        private const string PasswordEqualValidationMessage = "Passwords don't match!";
        private const string MemberCreatedMessage = "You have successfully registed! Please be patiant and wait for the activation email!";
        public ObservableCollection<CheckedItem> CheckedTeams { get; set; }

        public RegistrationView()
        {
            InitializeComponent();         
        }

        public MemberViewModel MemberViewModel { get; set; }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            ResetValidationMessage();
            List<string> selectedTeamNames = CheckedTeams.ToList();
            MemberViewModel.Password = tbPassword.Password;
            MemberViewModel.PasswordConfirm = tbPasswordConfirm.Password;
            bool areFilled = MemberViewModel.AreRequiredFieldsFilled();
            if (!areFilled)
            {
                DisplayValidationMessage(RequiredFieldsValidationMessage);
                return;
            }
            bool arePasswordEqual = MemberViewModel.ArePasswordEqual();
            if (!arePasswordEqual)
            {
                DisplayValidationMessage(PasswordEqualValidationMessage);
                return;
            }
            Member newMember = ATACore.Managers.MemberManager.CreateUser(ATACore.Managers.ContextManager.Context, MemberViewModel.UserName, tbPassword.Password, MemberViewModel.Email,
                MemberViewModel.TfsUserName, cbRole.SelectedItem.ToString(), selectedTeamNames, MemberViewModel.Comment);
            ATACore.Managers.ContextManager.Context.Dispose();
            tbPassword.Password = String.Empty;
            tbPasswordConfirm.Password = String.Empty;
            ModernDialog.ShowMessage(MemberCreatedMessage, "Success!", MessageBoxButton.OK);
            Navigator.Navigate("/LoginView.xaml", this);

        }       

        private void Registration_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeFields();
        }

        private void InitializeFields()
        {
            List<string> roles = new List<string>();
            Task t = Task.Factory.StartNew(() =>
            {
                MemberViewModel = new MemberViewModel();
                roles = MemberViewModel.GetRoles();

                CheckedTeams = new ObservableCollection<CheckedItem>();
                MemberViewModel.GetTeams().ForEach(x => CheckedTeams.Add(x));
            });
            Task t2 = t.ContinueWith(antecedent =>
            {
                DataContext = MemberViewModel;
                lbTeam.DataContext = CheckedTeams;
                cbRole.DataContext = roles;
                progressBar.Visibility = System.Windows.Visibility.Hidden;
                mainGrid.Visibility = System.Windows.Visibility.Visible;
                this.tbMemberUserName.Focus();
            }, TaskScheduler.FromCurrentSynchronizationContext());
            
        }

        private void DisplayValidationMessage(string validationMessage)
        {
            tbValidationMessage.Text = validationMessage;
            tbValidationMessage.Visibility = System.Windows.Visibility.Visible;
        }

        private void ResetValidationMessage()
        {
            tbValidationMessage.Text = String.Empty;
            tbValidationMessage.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
