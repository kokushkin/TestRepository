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

        public double MinX { get; set; }
        public double MaxX { get; set; }
        public double MinY { get; set; }
        public double MaxY { get; set; }

        public double MaximumWidth { get; set; }
        public double MaximumHeight { get; set; }

        public double OffsetX { get; set; }
        public double OffsetY { get; set; }

        public MainWindow()
        {
            MinX = 40;
            MaxX = 500;
            MinY = 40;
            MaxY = 600;
            MaximumWidth = MaxX - MinX;
            MaximumHeight = MaxY - MinY;
            OffsetX = -40;
            OffsetY = -40;

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
            }
        }
    }
}
