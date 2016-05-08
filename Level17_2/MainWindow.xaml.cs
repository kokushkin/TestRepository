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
using System.Windows.Markup;
using System.Windows;

namespace Level17_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tw.Name = "treeView";
            tw.BorderBrush = new SolidColorBrush(Colors.Blue);
            tw.BorderThickness = new Thickness(2.0);
            tw.Margin = new Thickness(5.0);
        }

        public void ShowLogicalTree(DependencyObject element)
        {
            // Очистить дерево
            tw.Items.Clear();
            // Начать обработку элементов
            ProcessElement(element, null);
        }

        private TreeView tw = new TreeView();

        // Новое диалоговое окно с элементом TreeView
        public void MyShowDialog()
        {
            Window win = new Window();
            win.Title = "LogicTreeDisplay";
            win.Height = 400;
            win.Width = 250;

            Grid grid = new Grid();

            IAddChild container = grid;
            container.AddChild(tw);

            container = win;
            container.AddChild(grid);
            ShowLogicalTree(this);

            win.ShowDialog();
        }

        public void ProcessElement(DependencyObject element, TreeViewItem previousItem)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = element.GetType().Name;
            item.IsExpanded = true;
            if (previousItem == null)
            {
                tw.Items.Add(item);
            }
            else
            {
                previousItem.Items.Add(item);
            }
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                ProcessElement(VisualTreeHelper.GetChild(element, i), item);
            }
        }

        private void Btn_visualTreeView_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)InTreeView.IsChecked)
            {
                MyShowDialog();
            }
        }

    }
}
