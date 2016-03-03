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

        DispatcherTimer countTimer = new DispatcherTimer();

        double x = 0;
        double y = 0;

        double x1 = 0;
        double y1 = 0;

        Random rnd = new Random();










        private Dictionary<string, Tuple<Path, Label>> functions = new Dictionary<string, Tuple<Path, Label>>();

        private Dictionary<string, Four> squaresFunctions = new Dictionary<string, Four>();

        double _userMinX;
        public double UserMinX
        {
            get
            {
                return _userMinX;
            }
            set
            {
                _userMinX = value;
                UpdateGrafic();
            }
        }
        double _userMaxX;
        public double UserMaxX
        {
            get
            {
                return _userMaxX;
            }
            set
            {
                _userMaxX = value;
                UpdateGrafic();
            }
        }
        double _userMinY;
        public double UserMinY
        {
            get
            {
                return _userMinY;
            }
            set
            {
                _userMinY = value;
                UpdateGrafic();
            }
        }
        double _userMaxY;
        public double UserMaxY
        {
            get
            {
                return _userMaxY;
            }
            set
            {
                _userMaxY = value;
                UpdateGrafic();
            }
        }

        public double MinX = double.NaN;
        public double MaxX = double.NaN;
        public double MinY = double.NaN;
        public double MaxY = double.NaN;



        public double MaximumWidth
        {
            get { return (double)GetValue(MaximumWidthProperty); }
            set { SetValue(MaximumWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaximumWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumWidthProperty =
            DependencyProperty.Register("MaximumWidth", typeof(double), typeof(MainWindow), new PropertyMetadata(double.NaN));



        public double MaximumHeight
        {
            get { return (double)GetValue(MaximumHeightProperty); }
            set { SetValue(MaximumHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaximumHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumHeightProperty =
            DependencyProperty.Register("MaximumHeight", typeof(double), typeof(MainWindow), new PropertyMetadata(double.NaN));


        public double OffsetX
        {
            get { return (double)GetValue(OffsetXProperty); }
            set { SetValue(OffsetXProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OffsetX.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OffsetXProperty =
            DependencyProperty.Register("OffsetX", typeof(double), typeof(MainWindow), new PropertyMetadata(double.NaN));



        public double OffsetY
        {
            get { return (double)GetValue(OffsetYProperty); }
            set { SetValue(OffsetYProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OffsetY.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OffsetYProperty =
            DependencyProperty.Register("OffsetY", typeof(double), typeof(MainWindow), new PropertyMetadata(double.NaN));


        public MainWindow()
        {
            UserMinX = double.NaN;
            UserMaxX = double.NaN;
            UserMinY = double.NaN;
            UserMaxY = double.NaN;

            InitializeComponent();

            //AddFunction(new Point[] { new Point(500, 400), new Point(40, 40) }, Colors.Black, 4, "Simple black function");
            //AddFunction(new Point[] { new Point(100, 100), new Point(300, 600) }, Colors.Green, 4, "Simple green function");

            Button_Click(null, null);
        }

        public void UpdateGrafic()
        {
            var minX = !double.IsNaN(UserMinX) ? UserMinX : MinX;
            var maxX = !double.IsNaN(UserMaxX) ? UserMaxX : MaxX;
            MaximumWidth =  maxX - minX;

            var minY = !double.IsNaN(UserMinY) ? UserMinY : MinY;
            var maxY = !double.IsNaN(UserMaxY) ? UserMaxY : MaxY;
            MaximumHeight =  maxY - minY;

            OffsetX = -(!double.IsNaN(UserMinX) ? UserMinX : MinX);
            OffsetY = -(!double.IsNaN(UserMinY) ? UserMinY : MinY);
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
                var four = new Four(points.Min(p => p.X), points.Max(p => p.X),
                    points.Min(p => p.Y), points.Max(p => p.Y));
                squaresFunctions.Add(description, four);

                if (ChangeMinMax(ref MinX, ref MaxX, ref MinY, ref MaxY,
                    four.minX, four.maxX, four.minY, four.maxY))
                    UpdateGrafic();
              
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

                if(ChangeMinMax(ref fSqr.minX, ref fSqr.maxX, ref fSqr.minY, ref fSqr.maxY,
                   point.X, point.X, point.Y, point.Y))
                    if (ChangeMinMax(ref MinX, ref MaxX, ref MinY, ref MaxY,
                        fSqr.minX, fSqr.maxX, fSqr.minY, fSqr.maxY))
                        UpdateGrafic();
            }
        }







        void AddPoint()
        {
            x += 10;
            y += -10 + rnd.Next(200);
            AddPoint(new Point(x, y), "Green line");

            x1 += 10;
            y1 += -20 + rnd.Next(400);
            AddPoint(new Point(x1, y1), "Red line");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Point[] PointArray = new Point[1];
            PointArray[0] = new Point(x, y);

            AddFunction(PointArray, Colors.Green, 2, "Green line");
            countTimer.Tick += new EventHandler((sender1, e1) => AddPoint());
            countTimer.Interval = new TimeSpan(0, 0, 3);
            countTimer.Start();

            Point[] PointArray1 = new Point[1];
            PointArray1[0] = new Point(x1, y1);

            AddFunction(PointArray1, Colors.Red, 2, "Red line");

        }



    }
}
