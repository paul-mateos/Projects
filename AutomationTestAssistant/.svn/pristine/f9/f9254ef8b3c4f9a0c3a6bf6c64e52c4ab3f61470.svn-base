using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace AutomationTestAssistantDesktopApp
{
    public class Navigator
    {
        public static void Navigate(string url, FrameworkElement source)
        {
            DefaultLinkNavigator _navigator = new DefaultLinkNavigator();
            _navigator.Navigate(new Uri(url, UriKind.Relative), source, null);
        }
    }
}
