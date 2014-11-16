using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControls
{
    public class CheckedItem
    {
        public CheckedItem()
        {
        }

        public CheckedItem(string description)
        {
            Description = description;
            Selected = false;
        }

        private bool selected;
        private string description;

        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
            }
        }
    }
}
