using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;

namespace AutomationTestAssistantCore
{
    public static class StrtingParser
    {
        public static int ToInt(this string str)
        {
            return int.Parse(str);
        }

        public static double ToDouble(this string str)
        {
            return double.Parse(str);
        }

        public static DateTime ToDateTime(this string str)
        {
            return DateTime.Parse(str);
        }

        public static TimeSpan ToTimeSpan(this string str)
        {
            return TimeSpan.Parse(str);
        }
    }
}
