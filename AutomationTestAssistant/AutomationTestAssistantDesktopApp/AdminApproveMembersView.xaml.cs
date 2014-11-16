using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using ATADataModel;
using AutomationTestAssistantCore;
using FirstFloor.ModernUI.Windows.Controls;

namespace AutomationTestAssistantDesktopApp
{
    public partial class AdminApproveMembersView : UserControl
    {
        public ObservableCollection<Member> MembersForApproval { get; set; }
        private const string SuccessfullyApprovedMessage = "Account successfully approved!";

        public AdminApproveMembersView()
        {
            InitializeComponent();
            List<Member> members = ATACore.Managers.MemberManager.GetAllMembersForApproval(ATACore.Managers.ContextManager.Context);
            ATACore.Managers.ContextManager.Context.Dispose();
            MembersForApproval = new ObservableCollection<Member>();
            members.ForEach(m => MembersForApproval.Add(m));
            dataGrid.ItemsSource = MembersForApproval;            
        }

        private void approveButton_Click(object sender, RoutedEventArgs e)
        {
            Member currentMember = ((FrameworkElement)sender).DataContext as Member;
            ATACore.Managers.MemberManager.ApproveUser(ATACore.Managers.ContextManager.Context, currentMember.UserName, currentMember.UserMemberRole);
            ATACore.Managers.ContextManager.Context.Dispose();
            ModernDialog.ShowMessage(SuccessfullyApprovedMessage, "Success!", MessageBoxButton.OK);
            MembersForApproval.Remove(currentMember);
        }
    }
}
