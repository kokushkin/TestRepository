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

namespace WpfTestGrafic
{
    sealed class Four
    {
        public Four(double _minX, double _maxX, double _minY, double _maxY)
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Dictionary<string, Tuple<Path, Label>> functions = new Dictionary<string, Tuple<Path, Label>>();

        private Dictionary<string, Four> squaresFunctions = new Dictionary<string, Four>();

        public double UserMinX { get; set; }
        public double UserMaxX { get; set; }
        public double UserMinY { get; set; }
        public double UserMaxY { get; set; }

        public double MinX = double.NaN;
        public double MaxX = double.NaN;
        public double MinY = double.NaN;
        public double MaxY = double.NaN;

        public double MaximumWidth
        {
            get
            {
                var minX = !double.IsNaN(UserMinX) ? UserMinX : MinX;
                var maxX = !double.IsNaN(UserMaxX) ? UserMaxX : MaxX;
                return maxX - minX;
            }
            set { }
        }
        public double MaximumHeight 
        { 
            get
            {
                var minY = !double.IsNaN(UserMinY) ? UserMinY : MinY;
                var maxY = !double.IsNaN(UserMaxY) ? UserMaxY : MaxY;
                return maxY - minY;
            }
            set { }
        }


        public double OffsetX 
        {
            get
            {
                return -(!double.IsNaN(UserMinX) ? UserMinX : MinX);
            }

            set { }
        }
        public double OffsetY 
        {
            get
            {
                return -(!double.IsNaN(UserMinY) ? UserMinY : MinY);
            }
            set { } 
        }

        public MainWindow()
        {
            UserMinX = double.NaN;
            UserMaxX = double.NaN;
            UserMinY = double.NaN;
            UserMaxY = double.NaN;

            InitializeComponent();

            AddFunction(new Point[] { new Point(500, 400), new Point(40, 40) }, Colors.Black, 4, "Simple black function");
            AddFunction(new Point[] { new Point(100, 100), new Point(300, 600) }, Colors.Green, 4, "Simple green function");
        }


        public void AddFunction(IEnumerable<Point> points, Color color, double StrokeThickness, string description)
        {
            if (!squaresFunctions.ContainsKey(description) && !functions.ContainsKey(description))
            {
                PathFigure figure = new PathFigure();
                figure.StartPoint = points.FirstOrDefault();
                foreach (var point in points.Skip(1))
                    figure.Segments.Add(new LineSegment(point, true));
                PathGeometry geometry = new PathGeometry();
                geometry.Figures.Add(figure);
                geometry.Transform = (Transform)grid.FindResource("transform");
                Path path = new Path();
                path.Stroke = new SolidColorBrush(color);
                path.StrokeThickness = StrokeThickness;
                path.Data = geometry;
                grid.Children.Add(path);   
            
                Label lbl = new Label();
                lbl.Content = description;
                lbl.Foreground = new SolidColorBrush(color);
                Descriptions.Children.Add(lbl);

                functions.Add(description, new Tuple<Path, Label>(path, lbl));
                var four = new Four(points.Min(p => p.X), points.Max(p => p.Y),
                    points.Min(p => p.Y), points.Max(p => p.Y));
                squaresFunctions.Add(description, four);
                ChangeMinMax(ref MinX, ref MaxX, ref MinY, ref MaxY,
                    four.minX, four.maxX, four.minY, four.maxY);

            }
        }

        public void AddPoint(Point point, string description)
        {
            if (squaresFunctions.ContainsKey(description) && functions.ContainsKey(description))
            {
                Tuple<Path, Label> function = null;
                functions.TryGetValue(description, out function);
                if (function != null)
                    ((PathGeometry)function.Item1.Data).Figures.FirstOrDefault()
                        .Segments.Add(new LineSegment(point, true));

                var fSqr = squaresFunctions[description];

                //ChangeMinMax(ref fSqr.minX, ref fSqr.maxX, ref fSqr.minY, ref fSqr.maxY,
                //    point.X, point.X, point.Y, point.Y);
                //ChangeMinMax(ref minX, ref maxX, ref minY, ref maxY,
                //    fSqr.minX, fSqr.maxX, fSqr.minY, fSqr.maxY);
            }
        }

        static bool ChangeMinMax(ref double oldMinX, ref double oldMaxX, ref double oldMinY, ref double oldMaxY,
    double nwMinX, double nwMaxX, double nwMinY, double nwMaxY)
        {
            bool flag = false;
            if (double.IsNaN(oldMinX) || nwMinX < oldMinX)
            {
                oldMinX = nwMinX;
                flag = true;
            }
            if (double.IsNaN(oldMaxX) || nwMaxX > oldMaxX)
            {
                oldMaxX = nwMaxX;
                flag = true;
            }
            if (double.IsNaN(oldMinY) || nwMinY < oldMinY)
            {
                oldMinY = nwMinY;
                flag = true;
            }
            if (double.IsNaN(oldMaxY) || nwMaxY > oldMaxY)
            {
                oldMaxY = nwMaxY;
                flag = true;
            }
            return flag;
        }
    }
}
