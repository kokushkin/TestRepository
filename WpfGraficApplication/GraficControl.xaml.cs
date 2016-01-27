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

namespace WpfGraficApplication
{
    sealed class Four
    {
        public Four(double _minX, double _maxX, double _minY, double _maxY )
        {
            minX = _minX;
            maxX = _maxX;
            minY = _minY;
            maxY = _maxY;
        }

        public double minX;
        public double maxX;
        public double minY;
        public double maxY;
    }
    /// <summary>
    /// Логика взаимодействия для GraficControl.xaml
    /// </summary>
    public partial class GraficControl : UserControl
    {

        private Dictionary<string, Tuple<Polyline, Label>> functions = new Dictionary<string, Tuple<Polyline, Label>>();

        private Dictionary<string, Four> squaresFunctions = new Dictionary<string, Four>();

        public double minX;
        public double maxX;
        public double minY;
        public double maxY;

        public GraficControl()
        {
            InitializeComponent();

        }

        public void AddFunction(IEnumerable<Point> points, Color color, string description)
        {
            Polyline polyline = new Polyline();
            polyline.Stroke = new SolidColorBrush(color);
            polyline.StrokeThickness = 1;
            PointCollection pColl = new PointCollection(points);
            polyline.Points = pColl;
            R2.Children.Add(polyline);

            //Canvas.SetLeft(polyline, R2.Width / 2);
            var nwFour = new Four(polyline.Points.Min(p => p.X), polyline.Points.Max(p => p.Y),
                polyline.Points.Min(p => p.Y), polyline.Points.Max(p => p.Y));

            squaresFunctions.Add(description, nwFour);
            if(ChangeMinMax(ref minX, ref maxX, ref minY, ref maxY,
                nwFour.minX, nwFour.maxX, nwFour.minY, nwFour.maxY))
                GoToCenter();

            

            Label lbl = new Label();
            lbl.Content = description;
            lbl.Foreground = new SolidColorBrush(color);
            Descriptions.Children.Add(lbl);

            functions.Add(description, new Tuple<Polyline, Label>(polyline, lbl));


            //minX = points.Min(p => p.X) < mi



            //var maxX = points.Max(p => p.X);
            //var maxY = points.Max(p => p.Y);
            //R2.Width = maxX;
            //R2.Height = maxY;
           
        }

        public void AddPoint(Point point, string description)
        {
            Tuple<Polyline, Label> function = null;
            functions.TryGetValue(description, out function);
            if (function != null)
            {
                function.Item1.Points.Add(point);
            }

            //if (R2.Width < point.X)
            //    R2.Width = point.X;
            //if (R2.Height < point.Y)
            //    R2.Height = point.Y;
            var fSqr = squaresFunctions[description];
            ChangeMinMax(ref fSqr.minX, ref fSqr.maxX, ref fSqr.minY, ref fSqr.maxY,
                point.X, point.X, point.Y, point.Y);
            if(ChangeMinMax(ref minX, ref maxX, ref minY, ref maxY,
                fSqr.minX, fSqr.maxX, fSqr.minY, fSqr.maxY))
                GoToCenter();

            
        }

        public void RemoveFunction(string description)
        {
            Tuple<Polyline, Label> function = null;
            functions.TryGetValue(description, out function);
            if(function != null)
            {
                R2.Children.Remove(function.Item1);
                Descriptions.Children.Remove(function.Item2);
                functions.Remove(description);
            }
        }


        bool ChangeMinMax(ref double oldMinX, ref double oldMaxX,ref double oldMinY,ref double oldMaxY, 
            double nwMinX, double nwMaxX, double nwMinY, double nwMaxY)
        {
            bool flag = false;
            if (nwMinX < oldMinX)
            {
                oldMinX = nwMinX;
                flag = true;
            }
            if (nwMaxX > oldMaxX)
            {
                oldMaxX = nwMaxX;
                flag = true;
            }
            if (nwMinY < oldMinY)
            {
                oldMinY = nwMinY;
                flag = true;
            }              
            if (nwMaxY > oldMaxY)
            {
                oldMaxY = nwMaxY;
                flag = true;
            }
            return flag;
        }

        void GoToCenter()
        {
            foreach(var func in functions)
            {
                Canvas.SetLeft(func.Value.Item1, -minX);
                Canvas.SetTop(func.Value.Item1, -minY);
            }
            R2.Width = maxX - minX;
            R2.Height = maxY - minY;
        }
    }
}
