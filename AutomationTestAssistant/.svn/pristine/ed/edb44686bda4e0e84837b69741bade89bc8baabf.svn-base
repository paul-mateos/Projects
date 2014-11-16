using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATADataModel;

namespace AutomationTestAssistantCore
{
    public class MemberRoleManager 
    {
        public MemberRole GetMemberRoleByRoleName(ATAEntities context, string roleName)
        {
            MemberRole currentRole = context.MemberRoles.Where(r => r.Role.Equals(roleName)).FirstOrDefault();
            return currentRole;
        }

        public MemberRoles GetMemberRoleByUserName(ATAEntities context, string userName)
        {
            Member cm = ATACore.Managers.MemberManager.GetMemberByUserName(context, userName);
            return (MemberRoles)cm.MemberRoleId;           
        }
    }
}
