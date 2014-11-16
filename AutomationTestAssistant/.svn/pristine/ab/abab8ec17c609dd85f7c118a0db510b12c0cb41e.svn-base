using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATADataModel;

namespace AutomationTestAssistantCore
{
    public class ActivationCodeManager
    {
        public bool IsActivationCodeValid(string userName, string code)
        {
            bool isValid = true;
            using (ATAEntities context = new ATAEntities())
            {
                Member m = ATACore.Managers.MemberManager.GetMemberByUserName(context, userName);
                var query = m.ActivationCodes.Where(c => c.Code.Equals(code) && c.ExpirationDate > DateTime.Now);
                isValid = query.ToList().Count > 0 ? true : false;
            }
            return isValid;
        }
    }
}
