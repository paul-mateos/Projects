using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATADataModel;
using AutomationTestAssistantCore;

namespace AutomationTestAssistantDesktopApp
{
    public class AgentMachineViewModel : AgentMachine, INotifyPropertyChanged
    {
        private bool isWorking;
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
            set
            {
                isWorking = value;
                OnPropertyChanged("IsWorking");
            }
        }

        private bool isSelected;
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }

        public AgentMachineViewModel(AgentMachine a)
        {
            base.Name = a.Name;
            base.Ip = a.Ip.Trim();
            base.WorkingDirPath = a.WorkingDirPath;
            base.AgentMachineId = a.AgentMachineId;
            IsWorking = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
