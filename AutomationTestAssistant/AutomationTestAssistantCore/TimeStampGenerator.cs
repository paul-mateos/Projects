using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace AutomationTestAssistantCore
{
    public class TimeStampGenerator
    {
        private CultureInfo ci = CultureInfo.InvariantCulture;

        public static string Generate()
        {
            return DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss");
        }
    }
}
