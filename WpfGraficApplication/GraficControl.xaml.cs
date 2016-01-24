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

        private Dictionary<string, Tuple<Polyline, Label>> functions = new Dictionary<string, Tuple<Polyline, Label>>();

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

            Label lbl = new Label();
            lbl.Content = description;
            lbl.Foreground = new SolidColorBrush(color);
            Descriptions.Children.Add(lbl);

            functions.Add(description, new Tuple<Polyline, Label>(polyline, lbl));
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
    }
}
