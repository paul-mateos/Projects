using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TreeNotebook
{
    /// <summary>
    /// Interaction logic for TestView.xaml
    /// </summary>
    public partial class TestView : UserControl
    {
        public TestView()
        {
            InitializeComponent();
         
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            List<Order> orders = new List<Order>()
            {
                new Order() {OrderID = 1, Name = "Gencho"},
                 new Order() {OrderID = 12, Name = "Gencho"},
                  new Order() {OrderID = 13, Name = "Gencho"},
                   new Order() {OrderID = 14, Name = "Gencho"},
                    new Order() {OrderID = 15, Name = "Gencho"},
                     new Order() {OrderID = 16, Name = "Gencho"}
            };
            _dataGrid.ItemsSource = orders;
        }
    }
}
