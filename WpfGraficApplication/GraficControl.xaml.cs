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

        private List<Line> coordLines = new List<Line>();

        public double minX;
        public double maxX;
        public double minY;
        public double maxY;

        public GraficControl()
        {
            InitializeComponent();
            minX = 0;
            maxX = 100;
            minY = 0;
            maxY = 100;
            R2.Width = maxX - minX;
            R2.Height = maxY - minY;
            DrowCoordinates();
        }



        public void AddFunction(IEnumerable<Point> points, Color color, string description)
        {
            if(!squaresFunctions.ContainsKey(description) && !functions.ContainsKey(description))
            {
                Polyline polyline = new Polyline();
                polyline.Stroke = new SolidColorBrush(color);
                polyline.StrokeThickness = CalculateThickness(0.005, R2.Width, R2.Height);
                PointCollection pColl = new PointCollection(points);
                polyline.Points = pColl;


                var nwFour = new Four(polyline.Points.Min(p => p.X), polyline.Points.Max(p => p.Y),
                    polyline.Points.Min(p => p.Y), polyline.Points.Max(p => p.Y));
           
                squaresFunctions.Add(description, nwFour);

                RecalculateSquare();
                GoToCenter();
                DrowCoordinates();

                R2.Children.Add(polyline);

                Label lbl = new Label();
                lbl.Content = description;
                lbl.Foreground = new SolidColorBrush(color);
                Descriptions.Children.Add(lbl);

                functions.Add(description, new Tuple<Polyline, Label>(polyline, lbl));
            }
        }

        public void AddPoint(Point point, string description)
        {
            if(squaresFunctions.ContainsKey(description) && functions.ContainsKey(description))
            {
                Tuple<Polyline, Label> function = null;
                functions.TryGetValue(description, out function);
                if (function != null)
                {
                    function.Item1.Points.Add(point);
                }

                var fSqr = squaresFunctions[description];
                ChangeMinMax(ref fSqr.minX, ref fSqr.maxX, ref fSqr.minY, ref fSqr.maxY,
                    point.X, point.X, point.Y, point.Y);
                if (ChangeMinMax(ref minX, ref maxX, ref minY, ref maxY,
                    fSqr.minX, fSqr.maxX, fSqr.minY, fSqr.maxY))
                {
                    GoToCenter();
                    DrowCoordinates();
                }
                    
            }

         
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


        static bool ChangeMinMax(ref double oldMinX, ref double oldMaxX,ref double oldMinY,ref double oldMaxY, 
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
            R2.Width = maxX - minX;
            R2.Height = maxY - minY;
            foreach(var func in functions)
            {
                Canvas.SetLeft(func.Value.Item1, -minX);
                Canvas.SetTop(func.Value.Item1, -minY);
                func.Value.Item1.StrokeThickness = CalculateThickness(0.005, R2.Width, R2.Height);
            }
            foreach(var line in coordLines)
            {
                Canvas.SetLeft(line, -minX);
                Canvas.SetTop(line, -minY);
                line.StrokeThickness = CalculateThickness(0.001, R2.Width, R2.Height);
            }
        }

        void RecalculateSquare()
        {
            minX = squaresFunctions.Min(sq => sq.Value.minX);
            maxX = squaresFunctions.Max(sq => sq.Value.maxX);
            minY = squaresFunctions.Min(sq => sq.Value.minY);
            maxY = squaresFunctions.Max(sq => sq.Value.maxY);
        }

        void DrowCoordinates()
        {
            foreach (var line in coordLines)
                R2.Children.Remove(line);

            var xLine = new Line();
            xLine.X1 = 0;
            xLine.X2 = maxX - minX;
            xLine.Y1 = (maxY - minY)/2;
            xLine.Y2 = (maxY - minY)/2;
            xLine.Stroke = new SolidColorBrush(Colors.Black);
            xLine.StrokeThickness = (double.IsNaN(R2.Width) || double.IsNaN(R2.Height)) ? 0.2 :
                CalculateThickness(0.001, R2.Width, R2.Height);

            var yLine = new Line();
            yLine.X1 = (maxX - minX) / 2;
            yLine.X2 = (maxX - minX) / 2;
            yLine.Y1 = 0;
            yLine.Y2 = maxY - minY;
            yLine.Stroke = new SolidColorBrush(Colors.Black);
            yLine.StrokeThickness = (double.IsNaN(R2.Width) || double.IsNaN(R2.Height)) ? 0.2 :
                CalculateThickness(0.001, R2.Width, R2.Height);

            coordLines.Add(xLine);
            coordLines.Add(yLine);

            R2.Children.Add(xLine);
            R2.Children.Add(yLine);
        }


        static double CalculateThickness(double coef, double width, double height)
        {
            var coef1 = width / height < 1 ? width / height : height / width;

            return width * coef1 * coef + height * coef1 * coef;
        }
    }
}
