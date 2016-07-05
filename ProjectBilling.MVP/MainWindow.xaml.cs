using ProjectBilling.Business;
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

namespace ProjectBilling.UI.MVP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IProjectsModel model = null;

        public MainWindow()
        {
            InitializeComponent();
            model = new ProjectsModel();
        }

        private void showProjectsButton_Click(object sender,
    RoutedEventArgs e)
        {
            ProjectsView view = new ProjectsView();
            ProjectsPresenter presenter
                = new ProjectsPresenter(view, model);
            view.Owner = this;
            view.Show();
        }
    }
}
