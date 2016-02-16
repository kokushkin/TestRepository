using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace UpdateSourceExperiment
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string StringBuffer { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int countClick = StringBuffer != "" ? Convert.ToInt32(StringBuffer) : 0;
            countClick++;
            StringBuffer = countClick.ToString();
            NotifyPropertyChanged("StringBuffer");
        }

        private void Binding_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            var bindingExpression =
                BindingOperations.GetBindingExpression(e.TargetObject, e.Property);



            bindingExpression.UpdateSource();
        }
    }
}
