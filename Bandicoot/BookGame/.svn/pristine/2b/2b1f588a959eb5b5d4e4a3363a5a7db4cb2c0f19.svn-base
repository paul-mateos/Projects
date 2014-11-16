using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BookGame
{
    public class Stone : INotifyPropertyChanged
    {
        private bool isAvailable;
        public bool IsAvailable
        {
            get
            {
                return isAvailable;
            }
            set
            {
                isAvailable = value;
                NotifyPropertyChanged();
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
                NotifyPropertyChanged();
            }
        }

        private Visibility visibility;
        public Visibility Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;
                NotifyPropertyChanged();
            }
        }

        private Brush fill;
        public Brush Fill
        {
            get
            {
                return fill;
            }
            set
            {
                fill = value;
                NotifyPropertyChanged();
            }
        }

        private Brush stroke;
        public Brush Stroke
        {
            get
            {
                return stroke;
            }
            set
            {
                stroke = value;
                NotifyPropertyChanged();  
            }
        }

        private double strokeTickness;
        public double StrokeThickness
        {
            get
            {
                return strokeTickness;
            }
            set
            {
                strokeTickness = value;
                NotifyPropertyChanged();
            }
        }

        private Point location;
        public Point Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
                NotifyPropertyChanged();
            }
        }

        public Stone()
        {
            IsAvailable = true;
            IsSelected = false;
            this.Visibility = Visibility.Hidden;
            this.Fill = Colors.Grey.ColorToBrush();
        }

        public Stone(int i, int j) : this()
        {
            this.Location = new Point(i, j);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
