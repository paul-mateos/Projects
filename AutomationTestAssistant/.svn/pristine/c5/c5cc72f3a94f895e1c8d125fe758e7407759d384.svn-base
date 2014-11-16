using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomControls;

namespace AutomationTestAssistantDesktopApp
{
    public static class CheckedItemManager
    {
        public static List<string> ToList(this ObservableCollection<CheckedItem> checkedItems)
        {
            List<string> selectedDescriptions = new List<string>();
            foreach (var item in checkedItems)
            {
                if (item.Selected)
                    selectedDescriptions.Add(item.Description);
            }
            return selectedDescriptions;
        }
    }
}
