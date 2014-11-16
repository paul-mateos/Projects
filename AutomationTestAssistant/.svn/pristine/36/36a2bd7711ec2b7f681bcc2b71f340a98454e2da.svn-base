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
using System.Collections.ObjectModel;

namespace AutomationTestAssistantDesktopApp
{
    public class AddProjectViewModel : NotifyPropertyChanged
    {
        public string UserName { get; set; }

        public AddProjectViewModel GetAddTeamViewModel()
        {
            return new AddProjectViewModel();
        }

        public AddProjectViewModel()
        {
            UserName = ATACore.RegistryManager.GetUserName();
            additionalPaths = new ObservableCollection<CheckedItem>();
            List<ATADataModel.AdditionalPath> additionalPathsList = ATACore.Managers.AdditionalPathManager.GetAll(ATACore.Managers.ContextManager.Context);

            additionalPathsList.ForEach(p => additionalPaths.Add(new CheckedItem(p.TfsPath)));
            ATACore.Managers.ContextManager.Context.Dispose();
        }

        private ObservableCollection<CheckedItem> additionalPaths;

        public ObservableCollection<CheckedItem> ObservableAdditionalPaths
        {
            get
            {
                return additionalPaths;
            }
            set
            {
                additionalPaths = value;               
            }
        }
    }
}
