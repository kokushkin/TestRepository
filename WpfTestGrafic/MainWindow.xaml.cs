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
        }
    }
}
