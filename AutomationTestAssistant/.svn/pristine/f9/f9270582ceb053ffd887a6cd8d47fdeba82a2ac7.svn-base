using System;
using System.Linq;

namespace AutomationTestAssistantCore
{
    public class CultureChanger
    {
        //get the old CurrenCulture and set the new, en-US
        private System.Globalization.CultureInfo oldCI;

        public void SetNewCurrentCulture()
        {
            oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }

        //reset Current Culture back to the original

        public void ResetCurrentCulture()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;
        }

    }
}
