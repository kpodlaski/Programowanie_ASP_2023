using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SpeedwayRace
{
    class Racer
    {
        private double Position;
        private double Velocity;
        private readonly double Distance;
        private readonly UIElement UiControl;

        private readonly Canvas Canvas;
        private readonly String Helmet;
        private static Random rand = new Random();
        private static double RiderSize = 30;
        private Barrier Barrier;
        public Racer(Canvas canvas, int id, String color, Barrier barrier)
        {
            this.Canvas = canvas;
            this.Distance = Canvas.ActualWidth - RiderSize;
            this.Helmet = color;
            this.UiControl = createEllipse(color);
            this.Canvas.Children.Add(this.UiControl);
            Canvas.SetTop(this.UiControl, RiderSize + 2*id * RiderSize);
            Position = 0;
            Velocity = 2 + rand.NextDouble()*3.0;
            this.Barrier = barrier;
        }

        private UIElement createEllipse(String color)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Stroke = System.Windows.Media.Brushes.Black;
            ellipse.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(color);
            ellipse.HorizontalAlignment = HorizontalAlignment.Left;
            ellipse.VerticalAlignment = VerticalAlignment.Center;
            ellipse.Width = RiderSize;
            ellipse.Height = RiderSize;
            return ellipse;
        }

        public void GetReadyAndStart()
        {

            Thread t = new Thread(this.DoRace);
            t.Start();
        }

        public void DoRace()
        {
            Barrier.SignalAndWait();
            while (Position< Distance)
            {
                Position += Velocity;
                //Console.WriteLine(Position);
                if (Position > Distance)
                {
                    Position = Distance;
                }
                updateUI();
                Thread.Sleep(100);
            }
            Console.WriteLine("Racer with " + Helmet + " helmet finished race");
        }

        private void updateUI()
        {
            Canvas.Dispatcher.BeginInvoke(new Action( () => {
                Canvas.SetLeft(UiControl, Position);
                }
            ) );
            
        }
    }
}
