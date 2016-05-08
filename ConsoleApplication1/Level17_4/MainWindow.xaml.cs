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
using System.Reflection;
using System.Xml;
using System.Windows.Markup;

namespace Level17_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Type typeControl = typeof(Control);
            List<Type> myTypes = new List<Type>();

            // Ищем все типы в сборке
            Assembly assembly = Assembly.GetAssembly(typeof(Control));
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeControl) && !type.IsAbstract && type.IsPublic)
                {
                    myTypes.Add(type);
                }
            }
            // отсортируем список
            myTypes.Sort(new TypeComparer());

            lbx.ItemsSource = myTypes;
            lbx.DisplayMemberPath = "Name";
        }

        private void lbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // Get the selected type.
                Type type = (Type)lbx.SelectedItem;

                // Instantiate the type.
                ConstructorInfo info = type.GetConstructor(System.Type.EmptyTypes);
                Control control = (Control)info.Invoke(null);

                Window win = control as Window;
                if (win != null)
                {
                    // Create the window (but keep it minimized).
                    win.WindowState = System.Windows.WindowState.Minimized;
                    win.ShowInTaskbar = false;
                    win.Show();
                }
                else
                {
                    // Add it to the grid (but keep it hidden).
                    control.Visibility = Visibility.Collapsed;
                    grid.Children.Add(control);
                }

                // Get the template.
                ControlTemplate template = control.Template;

                // Get the XAML for the template.
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                StringBuilder sb = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(sb, settings);
                XamlWriter.Save(template, writer);

                // Display the template.
                txb.Text = sb.ToString();

                // Remove the control from the grid.
                if (win != null)
                {
                    win.Close();
                }
                else
                {
                    grid.Children.Remove(control);
                }
            }
            catch (Exception err)
            {
                txb.Text = "<< Error generating template: " + err.Message + ">>";
            }
        }
    }


    public class TypeComparer : IComparer<Type>
    {
        public int Compare(Type x, Type y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

}
