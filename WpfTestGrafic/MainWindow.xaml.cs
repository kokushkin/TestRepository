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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

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

            PathFigure fig1 = new PathFigure();
            fig1.StartPoint = new Point(500, 400);
            fig1.Segments.Add(new LineSegment(new Point(40, 40), true));
            PathGeometry pthGeom1 = new PathGeometry();
            pthGeom1.Figures.Add(fig1);
            pthGeom1.Transform = (Transform)grid.FindResource("transform");
            Path blackPath = new Path();
            blackPath.Stroke = new SolidColorBrush(Colors.Black);
            blackPath.StrokeThickness = 4;
            blackPath.Data = pthGeom1;
            grid.Children.Add(blackPath);

            PathFigure fig2 = new PathFigure();
            fig2.StartPoint = new Point(100, 100);
            fig2.Segments.Add(new LineSegment(new Point(300, 600), true));
            PathGeometry pthGeom2 = new PathGeometry();
            pthGeom2.Figures.Add(fig2);
            pthGeom2.Transform = (Transform)grid.FindResource("transform");
            Path greenPath = new Path();
            greenPath.Stroke = new SolidColorBrush(Colors.Green);
            greenPath.StrokeThickness = 4;
            greenPath.Data = pthGeom2;
            grid.Children.Add(greenPath);

        }

    }
}
