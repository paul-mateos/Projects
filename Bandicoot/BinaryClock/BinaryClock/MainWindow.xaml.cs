using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Forms;

namespace BinaryClock
{
    public partial class MainWindow : Window
    {
        public Ellipse[] Circles1 { get; set; }
        public Ellipse[] Circles2 { get; set; }
        public delegate void UpdateColour(Brush brush, Ellipse circle);
        public UpdateColour UpdateColourDelegate { get; set; }
        public Brush Gray { get; set; }
        public Brush Green { get; set; }
        public Brush Blue { get; set; }
        public Brush Orange { get; set; }
        public Brush Violet { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitializeCircles();
            InitializaColours();
            this.UpdateColourDelegate = new UpdateColour(UpdateCircleColour);
            Task mainTask = Task.Factory.StartNew(() => {});
            mainTask.ContinueWith((a) => CalculateTime());
            
        }

        private void InitializaColours()
        {
            Gray = (Brush)(new BrushConverter().ConvertFrom("#F0F0F0"));
            Green = (Brush)(new BrushConverter().ConvertFrom("#66FF33"));
            Blue = (Brush)(new BrushConverter().ConvertFrom("#33CCFF"));
            Orange = (Brush)(new BrushConverter().ConvertFrom("#FF4719"));
            Violet = (Brush)(new BrushConverter().ConvertFrom("#A347FF"));
        }

        private void UpdateCircleColour(Brush brush, Ellipse circle)
        {
            if (!brush.Equals(Gray) && !circle.Fill.Equals(Gray))
                circle.Fill = Violet;
            else
                circle.Fill = brush;
        }


        private void InitializeCircles()
        {
            Circles1 = new Ellipse[3];
            Circles2 = new Ellipse[4];
            Circles1[2] = c14;
            Circles1[1] = c12;
            Circles1[0] = c11;
            Circles2[3] = c28;
            Circles2[2] = c24;
            Circles2[1] = c22;
            Circles2[0] = c21;
        }

        private void CalculateTime()
        {
            while(true)
            {
                Thread.Sleep(200);
                CalculateSec();
                ResetColours(Circles1);
                ResetColours(Circles2);
                int min = DateTime.Now.Minute;
                int min2 = min % 10;
                CalculateMin(Circles2, min2, 4);
                int min1 = min / 10;
                CalculateMin(Circles1, min1, 3);
                int hour = DateTime.Now.Hour;
                int hour2 = hour % 10;
                CalculateHour(Circles2, hour2, 4);
                int hour1 = hour / 10;
                CalculateHour(Circles1, hour1, 2);               
            }
        }

        private void ResetColours(Ellipse[] circles)
        {
            for (int i = 0; i < circles.Length; i++)
                circles[i].Dispatcher.BeginInvoke(UpdateColourDelegate, DispatcherPriority.Normal, Gray, circles[i]); 
        }

        private void CalculateMin(Ellipse[] circles, int min2, int to)
        {
            for (int i = 0; i < to; i++)
            {
                int timeComponent = min2 & (1 << i);
                if (timeComponent != 0)
                    circles[i].Dispatcher.BeginInvoke(UpdateColourDelegate, DispatcherPriority.Normal, Orange, circles[i]);                
            }
        }

        private void CalculateHour(Ellipse[] circles, int hour, int to)
        {
            for (int i = 0; i < to; i++)
            {
                int timeComponent = hour & (1 << i);
                if (timeComponent != 0)
                    circles[i].Dispatcher.BeginInvoke(UpdateColourDelegate, DispatcherPriority.Normal, Blue, circles[i]);
            }
        }

        private void CalculateSec()
        {
            int sec = DateTime.Now.Second;
            cSec.Dispatcher.BeginInvoke(UpdateColourDelegate, DispatcherPriority.Normal, Gray, cSec); 
            if (sec > 30)
                cSec.Dispatcher.BeginInvoke(UpdateColourDelegate, DispatcherPriority.Normal, Green, cSec); 
        }

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();           
        }

        private void Window_MouseLeftButtonUp_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (System.Windows.Forms.Control.ModifierKeys == Keys.Alt)
                this.Close();
        }

        private void Window_MouseWheel_1(object sender, MouseWheelEventArgs e)
        {

        }
    }
}
