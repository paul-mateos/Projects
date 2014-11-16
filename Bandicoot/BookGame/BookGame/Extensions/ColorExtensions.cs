using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BookGame
{
    public static class ColorExtensions
    {
        public static Brush ColorToBrush(this string color)
        {
            return (Brush)(new BrushConverter().ConvertFrom(color));
        }
    }
}
