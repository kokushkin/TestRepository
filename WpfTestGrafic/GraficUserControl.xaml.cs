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
    /// Логика взаимодействия для GraficUserControl.xaml
    /// </summary>
    public partial class GraficUserControl : UserControl
    {
        int restrictionCheckInterval = 10;
        int restrictionCheckCount = 0;

        public Dictionary<string, Tuple<Path, Label>> functions = new Dictionary<string, Tuple<Path, Label>>();

        private Dictionary<string, Four> squaresFunctions = new Dictionary<string, Four>();

        private Path coordPath;

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
        double _userXLenght;
        public double UserXLength
        {
            get
            {
                return _userXLenght;
            }
            set
            {
                _userXLenght = value;
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
        double _userYLength;
        public double UserYLength
        {
            get
            {
                return _userYLength;
            }
            set
            {
                _userYLength = value;
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
            DependencyProperty.Register("MaximumWidth", typeof(double), typeof(GraficUserControl), new PropertyMetadata(double.NaN));



        public double MaximumHeight
        {
            get { return (double)GetValue(MaximumHeightProperty); }
            set { SetValue(MaximumHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaximumHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumHeightProperty =
            DependencyProperty.Register("MaximumHeight", typeof(double), typeof(GraficUserControl), new PropertyMetadata(double.NaN));


        public double OffsetX
        {
            get { return (double)GetValue(OffsetXProperty); }
            set { SetValue(OffsetXProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OffsetX.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OffsetXProperty =
            DependencyProperty.Register("OffsetX", typeof(double), typeof(GraficUserControl), new PropertyMetadata(double.NaN));



        public double OffsetY
        {
            get { return (double)GetValue(OffsetYProperty); }
            set { SetValue(OffsetYProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OffsetY.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OffsetYProperty =
            DependencyProperty.Register("OffsetY", typeof(double), typeof(GraficUserControl), new PropertyMetadata(double.NaN));


        CostConverter xConverter;
        CostConverter yConverter;

        public GraficUserControl()
        {
            UserMinX = double.NaN;
            UserMaxX = double.NaN;
            UserXLength = double.PositiveInfinity;
            UserMinY = double.NaN;
            UserMaxY = double.NaN;
            UserYLength = double.PositiveInfinity;

            MinXRestriction = double.NaN;
            MaxXRestriction = double.NaN;
            XLengthRestriction = double.PositiveInfinity;
            MinYRestriction = double.NaN;
            MaxYRestriction = double.NaN;
            YLengthRestriction = double.PositiveInfinity;

            xConverter = new CostConverter();
            xConverter.cnv = new DoubleStringUnixTimeConverter();
            yConverter = new CostConverter();
            yConverter.cnv = new DoubleStringUnixTimeConverter();

            this.Resources.Add("XConverter", xConverter);
            this.Resources.Add("YConverter", yConverter);

            InitializeComponent();

            //var xConverter = (CostConverter)this.Resources["XConverter"];
            //xConverter.cnv = new DoubleStringDateTimeConverter();
            //var yConverter = (CostConverter)this.Resources["YConverter"];
            //yConverter.cnv = new DoubleStringDateTimeConverter();


        }

        public void UpdateGrafic()
        {
            double lMinX = double.NaN;
            double lMaxX = double.NaN;
            double lMinY = double.NaN;
            double lMaxY = double.NaN;
            
            if(!double.IsInfinity(UserMinX) && !double.IsNaN(UserMinX))
                lMinX = UserMinX;
            if (!double.IsInfinity(UserMaxX) && !double.IsNaN(UserMaxX))
                lMaxX = UserMaxX;
            if (!double.IsInfinity(UserMinY) && !double.IsNaN(UserMinY))
                lMinY = UserMinY;
            if (!double.IsInfinity(UserMaxY) && !double.IsNaN(UserMaxY))
                lMaxY = UserMaxY;
            
            if(double.IsNegativeInfinity(UserMinX) && !double.IsInfinity(UserXLength))
            {
                lMinX = MinX;
                lMaxX = MinX + UserXLength;
            }
            if(double.IsPositiveInfinity(UserMaxX) && !double.IsInfinity(UserXLength))
            {
                lMaxX = MaxX;
                lMinX = MaxX - UserXLength;
            }

            if (double.IsNegativeInfinity(UserMinY) && !double.IsInfinity(UserYLength))
            {
                lMinY = MinY;
                lMaxY = MinY + UserYLength;
            }
            if (double.IsPositiveInfinity(UserMaxY) && !double.IsInfinity(UserYLength))
            {
                lMaxY = MaxY;
                lMinY = MaxY - UserYLength;
            }

            var minX = !double.IsNaN(lMinX) ? lMinX : MinX;
            var maxX = !double.IsNaN(lMaxX) ? lMaxX : MaxX;
            MaximumWidth = maxX - minX;

            var minY = !double.IsNaN(lMinY) ? lMinY : MinY;
            var maxY = !double.IsNaN(lMaxY) ? lMaxY : MaxY;
            MaximumHeight = maxY - minY;

            OffsetX = -(!double.IsNaN(lMinX) ? lMinX : MinX);
            OffsetY = -(!double.IsNaN(lMinY) ? lMinY : MinY);




            //draw coordinate fild (9 lines)

            if(grid != null)
            {
                if (coordPath != null)
                    grid.Children.Remove(coordPath);

                PathGeometry geometry = new PathGeometry();
                geometry.Transform = (Transform)grid.FindResource("transform");
                int i = 0, j = 0;
                for (double x = minX; x < maxX; x += (maxX - minX) / 10)
                {
                    var pf = new PathFigure();
                    pf.StartPoint = new Point(x, minY);
                    pf.Segments.Add(new LineSegment(new Point(x, maxY), true));
                    geometry.Figures.Add(pf);
                    switch (i)
                    {
                        case 0:
                            x0.Content = xConverter.cnv.ToString(x);
                            break;
                        case 1:
                            x1.Content = xConverter.cnv.ToString(x);
                            break;
                        case 2:
                            x2.Content = xConverter.cnv.ToString(x);
                            break;
                        case 3:
                            x3.Content = xConverter.cnv.ToString(x);
                            break;
                        case 4:
                            x4.Content = xConverter.cnv.ToString(x);
                            break;
                        case 5:
                            x5.Content = xConverter.cnv.ToString(x);
                            break;
                        case 6:
                            x6.Content = xConverter.cnv.ToString(x);
                            break;
                        case 7:
                            x7.Content = xConverter.cnv.ToString(x);
                            break;
                        case 8:
                            x8.Content = xConverter.cnv.ToString(x);
                            break;
                        case 9:
                            x9.Content = xConverter.cnv.ToString(x);
                            break;
                        default:
                            break;

                    }
                    i++;
                }
                for (double y = minY; y < maxY; y += (maxY - minY) / 10)
                {
                    var pf = new PathFigure();
                    pf.StartPoint = new Point(minX, y);
                    pf.Segments.Add(new LineSegment(new Point(maxX, y), true));
                    geometry.Figures.Add(pf);
                    switch (j)
                    {
                        case 0:
                            y0.Content = yConverter.cnv.ToString(y);
                            break;
                        case 1:
                            y1.Content = yConverter.cnv.ToString(y);
                            break;
                        case 2:
                            y2.Content = yConverter.cnv.ToString(y);
                            break;
                        case 3:
                            y3.Content = yConverter.cnv.ToString(y);
                            break;
                        case 4:
                            y4.Content = yConverter.cnv.ToString(y);
                            break;
                        case 5:
                            y5.Content = yConverter.cnv.ToString(y);
                            break;
                        case 6:
                            y6.Content = yConverter.cnv.ToString(y);
                            break;
                        case 7:
                            y7.Content = yConverter.cnv.ToString(y);
                            break;
                        case 8:
                            y8.Content = yConverter.cnv.ToString(y);
                            break;
                        case 9:
                            y9.Content = yConverter.cnv.ToString(y);
                            break;
                        default:
                            break;

                    }
                    j++;
                }

                Path path = new Path();
                path.Stroke = new SolidColorBrush(Colors.Black);
                path.StrokeThickness = 1;
                path.Data = geometry;
                coordPath = path;
                grid.Children.Add(coordPath);
            }



            ///////////


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

    }
}
