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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Point[] PointArray { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            PointArray = new Point[4];
            PointArray[0] = new Point(0, -100);
            PointArray[1] = new Point(20, 20);
            PointArray[2] = new Point(70, 20);
            PointArray[3] = new Point(140, 200);
            //Polyline polyLine = new Polyline();
            //polyLine.Stroke = new SolidColorBrush(Colors.Green);
            //polyLine.StrokeThickness = 2;
            //PointCollection pColl = new PointCollection(PointArray);
            //polyLine.Points = pColl;

            //Grafic.R2.Children.Add(polyLine);

            Grafic.AddFunction(PointArray, Colors.Green, "Green line");
            
        }
    }
}
