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
        int restrictionCheckInterval = 10;
        int restrictionCheckCount = 0;

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

        double _minXRestriction;
        public double MinXRestriction
        {
            get
            {
                return _minXRestriction;
            }
            set
            {
                _minXRestriction = value;
                RestrictAll();
                UpdateGrafic();
                
            }
        }
        double _maxXRestriction;
        public double MaxXRestriction
        {
            get
            {
                return _maxXRestriction;
            }
            set
            {
                _maxXRestriction = value;
                RestrictAll();
                UpdateGrafic();
            }
        }
        double _xLengthRestriction;
        public double XLengthRestriction
        {
            get
            {
                return _xLengthRestriction;
            }
            set
            {
                _xLengthRestriction = value;
                RestrictAll();
                UpdateGrafic();
            }
        }
        double _minYRestriction;
        public double MinYRestriction
        {
            get
            {
                return _minYRestriction;
            }
            set
            {
                _minYRestriction = value;
                RestrictAll();
                UpdateGrafic();
            }
        }
        double _maxYRestriction;
        public double MaxYRestriction
        {
            get
            {
                return _maxYRestriction;
            }
            set
            {
                _maxYRestriction = value;
                RestrictAll();
                UpdateGrafic();
            }
        }
        double _yLengthRestriction;
        public double YLengthRestriction
        {
            get
            {
                return _yLengthRestriction;
            }
            set
            {
                _yLengthRestriction = value;
                RestrictAll();
                UpdateGrafic();
            }
        }
    
    





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

            MinXRestriction = double.NaN;
            MaxXRestriction = double.NaN;
            XLengthRestriction = double.PositiveInfinity;
            MinYRestriction = double.NaN;
            MaxYRestriction = double.NaN;
            YLengthRestriction = double.PositiveInfinity;


            InitializeComponent();

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

        static bool ChangeMinMaxAdd(ref double oldMinX, ref double oldMaxX, ref double oldMinY, ref double oldMaxY,
double nwMinX, double nwMaxX, double nwMinY, double nwMaxY)
        {
            bool flag = false;
            if (double.IsNaN(oldMinX) || (!double.IsNaN(nwMinX) && nwMinX < oldMinX))
            {
                oldMinX = nwMinX;
                flag = true;
            }
            if (double.IsNaN(oldMaxX) || (!double.IsNaN(nwMaxX) && nwMaxX > oldMaxX))
            {
                oldMaxX = nwMaxX;
                flag = true;
            }
            if (double.IsNaN(oldMinY) || (!double.IsNaN(nwMinY) && nwMinY < oldMinY))
            {
                oldMinY = nwMinY;
                flag = true;
            }
            if (double.IsNaN(oldMaxY) || (!double.IsNaN(nwMaxY) && nwMaxY > oldMaxY))
            {
                oldMaxY = nwMaxY;
                flag = true;
            }
            return flag;
        }

        //Set new MinMax borders
        static bool ChangeMinMaxDelete(ref double oldMinX, ref double oldMaxX, ref double oldMinY, ref double oldMaxY,
double nwMinX, double nwMaxX, double nwMinY, double nwMaxY)
        {
            //bool flag = false;
            //if (double.IsNaN(oldMinX) || nwMinX > oldMinX)
            //{
            //    oldMinX = nwMinX;
            //    flag = true;
            //}
            //if (double.IsNaN(oldMaxX) || nwMaxX < oldMaxX)
            //{
            //    oldMaxX = nwMaxX;
            //    flag = true;
            //}
            //if (double.IsNaN(oldMinY) || nwMinY > oldMinY)
            //{
            //    oldMinY = nwMinY;
            //    flag = true;
            //}
            //if (double.IsNaN(oldMaxY) || nwMaxY < oldMaxY)
            //{
            //    oldMaxY = nwMaxY;
            //    flag = true;
            //}
            //return flag;
            oldMinX = nwMinX;
            oldMaxX = nwMaxX;
            oldMinY = nwMinY;
            oldMaxY = nwMaxY;
            return true;

        }


        static bool ChangeMinMaxDelete(IEnumerable<Four> fourths, ref double oldMinX, ref double oldMaxX, ref double oldMinY, ref double oldMaxY,
            double delMinX, double delMaxX, double delMinY, double delMaxY)
        {
            bool flag = false;
            if (delMinX <= oldMinX)
            {
                oldMinX = fourths.Count() != 0 ? fourths.Min(sq => sq.minX) : double.NaN;
                flag = true;
            }              
            if (delMaxX >= oldMaxX)
            {
                oldMaxX = fourths.Count() != 0 ? fourths.Max(sq => sq.maxX) : double.NaN;
                flag = true;
            }               
            if (delMinY <= oldMinY)
            {
                oldMinY = fourths.Count() != 0 ? fourths.Min(sq => sq.minY) : double.NaN;
                flag = true;
            }
                
            if (delMaxY >= oldMaxY)
            {
                oldMaxY = fourths.Count() != 0 ? fourths.Max(sq => sq.maxY) : double.NaN;
                flag = true;
            }
            return flag;
        }

        IEnumerable<Point> RestrictionCheck(IEnumerable<Point> points)
        {
            IEnumerable<Point> resPoints = points;

            if (!double.IsInfinity(MinXRestriction) && !double.IsNaN(MinXRestriction))
                resPoints = points.Where(pt => pt.X >= MinXRestriction);
            if (!double.IsInfinity(MaxXRestriction) && !double.IsNaN(MaxXRestriction))
                resPoints = points.Where(pt => pt.X >= MaxXRestriction);


            if (double.IsPositiveInfinity(MaxXRestriction) && !double.IsInfinity(XLengthRestriction))
            {
                var maxX = points.Max(pt => pt.X);
                maxX = !double.IsNaN(MaxX) ? Math.Max(maxX, MaxX) : maxX;
                resPoints = points.Where(pt => pt.X >= maxX - XLengthRestriction);
            }
            if (double.IsNegativeInfinity(MinXRestriction) && !double.IsInfinity(XLengthRestriction))
            {
                var minX = points.Min(pt => pt.X);
                minX = !double.IsNaN(MinX) ? Math.Min(minX, MinX) : minX;
                resPoints = points.Where(pt => pt.X <= minX + XLengthRestriction);
            }


            if (!double.IsInfinity(MinYRestriction) && !double.IsNaN(MinYRestriction))
                resPoints = points.Where(pt => pt.Y >= MinYRestriction);
            if (!double.IsInfinity(MaxYRestriction) && !double.IsNaN(MaxYRestriction))
                resPoints = points.Where(pt => pt.Y >= MaxYRestriction);


            if (double.IsPositiveInfinity(MaxYRestriction) && !double.IsInfinity(YLengthRestriction))
            {
                var maxY = points.Max(pt => pt.Y);
                maxY = !double.IsNaN(MaxY) ? Math.Max(maxY, MaxY) : maxY;
                resPoints = points.Where(pt => pt.Y >= maxY - YLengthRestriction);
            }
            if (double.IsNegativeInfinity(MinYRestriction) && !double.IsInfinity(YLengthRestriction))
            {
                var minY = points.Min(pt => pt.Y);
                minY = !double.IsNaN(MinY) ? Math.Min(minY, MinY) : minY;
                resPoints = points.Where(pt => pt.Y <= minY + YLengthRestriction);
            }

            return resPoints.ToArray();
        }

        void RestrictAll()
        {
            List<Point> delPoints = new List<Point>();

            foreach (var func in functions)
            {
                var path = func.Value.Item1;

                PathFigure pf = ((PathGeometry)path.Data).Figures.FirstOrDefault();
                List<Point> lpt = new List<Point>();
                lpt.Add(pf.StartPoint);
                lpt.AddRange(pf.Segments.Select(sg => ((LineSegment)sg).Point).ToArray());
                var lptnw = RestrictionCheck(lpt).ToList();

                var delFuncPoints = lpt.Except(lptnw);
                var fSqr = squaresFunctions[func.Key];
                ChangeMinMaxDelete(ref fSqr.minX, ref fSqr.maxX, ref fSqr.minY, ref fSqr.maxY,
                    lptnw.Count != 0 ? lptnw.Min(pt => pt.X) : double.NaN, 
                    lptnw.Count != 0 ? lptnw.Max(pt => pt.X) : double.NaN, 
                    lptnw.Count != 0 ? lptnw.Min(pt => pt.Y) : double.NaN,
                    lptnw.Count != 0 ? lptnw.Max(pt => pt.Y) : double.NaN);

                delPoints.AddRange(delFuncPoints);

                pf.StartPoint = lptnw.FirstOrDefault();
                pf.Segments.Clear();
                foreach (var pnt in lptnw.Skip(1))
                    pf.Segments.Add(new LineSegment(pnt, true));
            }
            if(delPoints.Count() != 0)
                if(ChangeMinMaxDelete(squaresFunctions.Select(sq => sq.Value).ToArray(), ref MinX, ref MaxX, ref MinY, ref MaxY,
                        delPoints.Min(pt=>pt.X), delPoints.Max(pt=>pt.X), delPoints.Min(pt=>pt.Y), delPoints.Max(pt=>pt.Y)))
                        UpdateGrafic();
        }

        public void AddFunction(IEnumerable<Point> points, Color color, double StrokeThickness, string description)
        {
            if (!squaresFunctions.ContainsKey(description) && !functions.ContainsKey(description))
            {
                points = RestrictionCheck(points);

                PathFigure figure = new PathFigure();
                if(points.Count() != 0)
                {
                    figure.StartPoint = points.FirstOrDefault();
                    foreach (var point in points.Skip(1))
                        figure.Segments.Add(new LineSegment(point, true));
                }

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
                Four four = new Four(double.NaN, double.NaN, double.NaN, double.NaN);
                if(points.Count() != 0)
                {
                    four = new Four(points.Min(p => p.X), points.Max(p => p.X),
    points.Min(p => p.Y), points.Max(p => p.Y));
                }

                squaresFunctions.Add(description, four);

                if (ChangeMinMaxAdd(ref MinX, ref MaxX, ref MinY, ref MaxY,
                    four.minX, four.maxX, four.minY, four.maxY))
                    UpdateGrafic();
              
            }
        }

        public void DeleteFunction(string description)
        {
            if (squaresFunctions.ContainsKey(description) && functions.ContainsKey(description))
            {
                var four = squaresFunctions[description];
                squaresFunctions.Remove(description);
                var tpl = functions[description];
                functions.Remove(description);

                grid.Children.Remove(tpl.Item1);
                Descriptions.Children.Remove(tpl.Item2);


                if(ChangeMinMaxDelete(squaresFunctions.Select(sq => sq.Value).ToArray(), ref MinX, ref MaxX, ref MinY, ref MaxY,
                    four.minX, four.maxX, four.minY, four.maxY))
                    UpdateGrafic();

            }
        }

        public void AddPoint(Point point, string description)
        {
            if (squaresFunctions.ContainsKey(description) && functions.ContainsKey(description))
            {
                var res = RestrictionCheck(new Point[] { point });
                if (res.Count() == 0)
                    return;

                restrictionCheckCount++;
                if(restrictionCheckCount > restrictionCheckInterval)
                {
                    RestrictAll();
                    UpdateGrafic();
                    restrictionCheckCount = 0;
                }

                Tuple<Path, Label> function = null;
                functions.TryGetValue(description, out function);
                if (function != null)
                    ((PathGeometry)function.Item1.Data).Figures.FirstOrDefault()
                        .Segments.Add(new LineSegment(point, true));

                var fSqr = squaresFunctions[description];

                if (ChangeMinMaxAdd(ref fSqr.minX, ref fSqr.maxX, ref fSqr.minY, ref fSqr.maxY,
                   point.X, point.X, point.Y, point.Y))
                    if (ChangeMinMaxAdd(ref MinX, ref MaxX, ref MinY, ref MaxY,
                        fSqr.minX, fSqr.maxX, fSqr.minY, fSqr.maxY))
                        UpdateGrafic();
            }
        }




        private void Button_Click_AddGreen(object sender, RoutedEventArgs e)
        {
            Point[] PointArray = new Point[] { new Point(10, 100), new Point(30, 80), new Point(40, 40), new Point(70, 100) };
            AddFunction(PointArray, Colors.Green, 2, "Green line");
        }

        private void Button_Click_AddBlack(object sender, RoutedEventArgs e)
        {
            Point[] PointArray = new Point[] { new Point(50, 20), new Point(70, 30), new Point(80, 40), new Point(110, 12) };
            AddFunction(PointArray, Colors.Black, 2, "Black line");
        }

        private void Button_Click_DeleteGreen(object sender, RoutedEventArgs e)
        {
            DeleteFunction("Green line");
        }

        private void Button_Click_DeleteBlack(object sender, RoutedEventArgs e)
        {
            DeleteFunction("Black line");
        }

        private void Button_Click_AddGreenPoint(object sender, RoutedEventArgs e)
        {
            Tuple<Path, Label> tpl = null;
            functions.TryGetValue("Green line", out tpl);
            if(tpl != null)
            {
                var figure = ((PathGeometry)tpl.Item1.Data).Figures.LastOrDefault();
                var lastSegment = figure.Segments.LastOrDefault();      
                if(lastSegment != null)
                {
                    var prevPoint = ((LineSegment)((PathGeometry)tpl.Item1.Data).Figures.LastOrDefault().Segments.LastOrDefault()).Point;
                    AddPoint(new Point(prevPoint.X + rnd.Next(50), prevPoint.Y + rnd.Next(100)), "Green line");
                    return;
                }
                else
                    AddPoint(new Point(MaxX + rnd.Next(50), MaxY + rnd.Next(50)), "Green line");
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
            functions.TryGetValue("Black line", out tpl);
            if (tpl != null)
            {
                var figure = ((PathGeometry)tpl.Item1.Data).Figures.LastOrDefault();
                var lastSegment = figure.Segments.LastOrDefault();
                if (lastSegment != null)
                {
                    var prevPoint = ((LineSegment)((PathGeometry)tpl.Item1.Data).Figures.LastOrDefault().Segments.LastOrDefault()).Point;
                    AddPoint(new Point(prevPoint.X + rnd.Next(50), prevPoint.Y + rnd.Next(100)), "Black line");
                    return;
                }
                else
                    AddPoint(new Point(MaxX + rnd.Next(50), MaxY + rnd.Next(50)), "Black line");
            }
        }



    }
}
