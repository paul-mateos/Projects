using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;

namespace AutomationTestAssistantCore
{
    public static class TextCleaner
    {
        public static string CleanSpaces(this string textToClean)
        {
            string result = (textToClean == null) ? String.Empty : textToClean.Trim(' ');
            return result;
        }

        public static string CleanMessageEnd(this string textToClean)
        {
            return textToClean.Trim('$');
        }
    }
}
