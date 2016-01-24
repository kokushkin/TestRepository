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
    /// <summary>
    /// Логика взаимодействия для GraficControl.xaml
    /// </summary>
    public partial class GraficControl : UserControl
    {
        public Point[] PointArray { get; set; }
        public Polyline[] Functions { get; set; }

        public GraficControl()
        {
            InitializeComponent();
            PointArray = new Point[4];
            PointArray[0] = new Point(0, 0);
            PointArray[1] = new Point(20, 20);
            PointArray[2] = new Point(64, 30);
            PointArray[3] = new Point(100, 200);
            Polyline polyLine = new Polyline();
            polyLine.Stroke = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            polyLine.StrokeThickness = 2;
            PointCollection pColl = new PointCollection(PointArray);
            polyLine.Points = pColl;
            R2.Children.Add(polyLine);
        }

        public void AddFunction(IEnumerable<Point> points, Color color, string Description)
        {
            Polyline polyline = new Polyline();
            polyline.Stroke = new SolidColorBrush(color);
            polyline.StrokeThickness = 1;
            PointCollection pColl = new PointCollection(points);
            polyline.Points = pColl;
            R2.Children.Add(polyline);

            Label lbl = new Label();
            lbl.Content = Description;
            lbl.Foreground = new SolidColorBrush(color);
            Descriptions.Children.Add(lbl);
        }
    }
}
