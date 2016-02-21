using System;
using System.ComponentModel;
using System.Reflection;

namespace AutomateThePlanetPoster.Core
{
    public static class EnumHelper
    {
        public static string Description(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        public static string GetTitle(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            TitleAttribute[] attributes =
                (TitleAttribute[])fi.GetCustomAttributes(typeof(TitleAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Value;
            }
            else
            {
                return value.ToString();
            }
        }
    }
}