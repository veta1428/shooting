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
using System.Windows.Shapes;

namespace shooting
{
    /// <summary>
    /// Логика взаимодействия для Shooting.xaml
    /// </summary>
    public partial class Shooting : Window
    {
        private int Radius;

        private int succeededhits = 0;

        private int allHits = 0;

        public Shooting(int radius)
        {            
            InitializeComponent();
            Radius = radius;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Radius > 205)
            {
                this.Height = 2 * Radius + 40;
                this.Width = 1.7 * this.Height;                
            }

            this.MinHeight = this.Height;
            this.MinWidth = this.MinHeight;

            gridforshooting.Height = 2 * this.Height;
            gridforshooting.Width = 2 * this.Width;           

            targety.Radius = Radius;
            targety.Centre = new Point(gridforshooting.Width / 2, gridforshooting.Height / 2);        
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            allhitsnumber.Content = ++allHits;

            Point coord = e.GetPosition(gridforshooting);
            Ellipse circle = new Ellipse();
            circle.Height = 5;
            circle.Width = 5;
            circle.Fill = Brushes.Black;
            circle.VerticalAlignment = VerticalAlignment.Top;
            circle.HorizontalAlignment = HorizontalAlignment.Left;
            circle.Margin = new Thickness(coord.X, coord.Y, 0, 0);
            gridforshooting.Children.Add(circle);
        }

        private void targety_MouseDown(object sender, MouseButtonEventArgs e)
        {
            hitsnumber.Content = ++succeededhits; 
        }
    }
}