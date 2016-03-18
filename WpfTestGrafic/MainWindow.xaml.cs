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
using System.Windows.Threading;

namespace WpfTestGrafic
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click_AddGreen(object sender, RoutedEventArgs e)
        {
            var stDate = new DateTime(2016, 1, 12);
            //Point[] PointArray = new Point[] { new Point(1457989481, 100), 
            //    new Point(1457989600, 80), 
            //    new Point(1457989800, 40), 
            //    new Point(1457989900, 100) };
            //Point[] PointArray = new Point[] { new Point(9481, 100), 
            //    new Point(9600, 80), 
            //    new Point(9800, 40), 
            //    new Point(9900, 100) };
            //Point[] PointArray = new Point[] { new Point(0, 0), 
            //    new Point(10, 30), 
            //    new Point(20, 20), 
            //    new Point(30, 80) };
            Point[] PointArray = new Point[] { new Point(30, 30), 
                new Point(40, 60), 
                new Point(50, 50), 
                new Point(60, 110) };
            Grafic.AddFunction(PointArray, Colors.Green, 2, "Green line");
        }

        private void Button_Click_AddBlack(object sender, RoutedEventArgs e)
        {
            var stDate = new DateTime(2016, 1, 12);
            //Point[] PointArray = new Point[] { new Point(1457989481, 20), 
            //    new Point(1457989600, 30), 
            //    new Point(1457989800, 40), 
            //    new Point(1457989900, 12) };
            //Point[] PointArray = new Point[] { new Point(9481, 20), 
            //    new Point(9600, 30), 
            //    new Point(9800, 40), 
            //    new Point(9900, 12) };
            Point[] PointArray = new Point[] { new Point(0, 0), 
                new Point(10, 30), 
                new Point(20, 20), 
                new Point(30, 80) };
            Grafic.AddFunction(PointArray, Colors.Black, 2, "Black line");
        }

        private void Button_Click_DeleteGreen(object sender, RoutedEventArgs e)
        {
            Grafic.DeleteFunction("Green line");
        }

        private void Button_Click_DeleteBlack(object sender, RoutedEventArgs e)
        {
            Grafic.DeleteFunction("Black line");
        }

        private void Button_Click_AddGreenPoint(object sender, RoutedEventArgs e)
        {
            Tuple<Path, Label> tpl = null;
            Grafic.functions.TryGetValue("Green line", out tpl);
            if (tpl != null)
            {
                var figure = ((PathGeometry)tpl.Item1.Data).Figures.LastOrDefault();
                var lastSegment = figure.Segments.LastOrDefault();
                if (lastSegment != null)
                {
                    var prevPoint = ((LineSegment)((PathGeometry)tpl.Item1.Data).Figures.LastOrDefault().Segments.LastOrDefault()).Point;
                    Grafic.AddPoint(new Point(prevPoint.X + rnd.Next(300),
                        prevPoint.Y + rnd.Next(100)), "Green line");
                    return;
                }
                else
                    Grafic.AddPoint(new Point(Grafic.MaxX + rnd.Next(300),
                        Grafic.MaxY + rnd.Next(50)), "Green line");
            }

        }

        private void Button_Click_AddBlackPoint(object sender, RoutedEventArgs e)
        {
            //Tuple<Path, Label> tpl = null;
            //functions.TryGetValue("Black line", out tpl);
            //if (tpl != null)
            //{
            //    var prevPoint = ((LineSegment)((PathGeometry)tpl.Item1.Data).Figures.LastOrDefault().Segments.LastOrDefault()).Point;
            //    AddPoint(new Point(prevPoint.X + rnd.Next(50), prevPoint.Y + rnd.Next(100)), "Black line");
            //}

            Tuple<Path, Label> tpl = null;
            Grafic.functions.TryGetValue("Black line", out tpl);
            if (tpl != null)
            {
                var figure = ((PathGeometry)tpl.Item1.Data).Figures.LastOrDefault();
                var lastSegment = figure.Segments.LastOrDefault();
                if (lastSegment != null)
                {
                    var prevPoint = ((LineSegment)((PathGeometry)tpl.Item1.Data).Figures.LastOrDefault().Segments.LastOrDefault()).Point;
                    Grafic.AddPoint(new Point(prevPoint.X + rnd.Next(300),
                        prevPoint.Y + rnd.Next(100)), "Black line");
                    return;
                }
                else
                    Grafic.AddPoint(new Point(Grafic.MaxX + rnd.Next(300),
                        Grafic.MaxY + rnd.Next(50)), "Black line");
            }
        }

    }
}
