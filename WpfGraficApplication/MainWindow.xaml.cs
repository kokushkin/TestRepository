﻿using System;
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

namespace WpfGraficApplication
{
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

        public MainWindow()
        {
            InitializeComponent();

            Point[] PointArray = new Point[1];
            PointArray[0] = new Point(x, y);

            Grafic.AddFunction(PointArray, Colors.Green, "Green line");
            countTimer.Tick += new EventHandler((sender, e) => AddPoint());
            countTimer.Interval = new TimeSpan(0, 0, 3);
            countTimer.Start();

            Point[] PointArray1 = new Point[1];
            PointArray1[0] = new Point(x1, y1);

            Grafic.AddFunction(PointArray1, Colors.Red, "Red line");


        }

        void AddPoint()
        {
            x += 10;
            y += -10 + rnd.Next(20);
            Grafic.AddPoint(new Point(x, y), "Green line");

            x1 += 10;
            y1 += -20 + rnd.Next(40);
            Grafic.AddPoint(new Point(x1, y1), "Red line");
        }
    }
}
