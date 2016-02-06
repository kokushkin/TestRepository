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

namespace INotifyPropertyTestProject
{

    public class TextSaver : INotifyPropertyChanged
    {
        public string TextValue
        {
            get;

            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }




    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public TextSaver TxtSvr { get; set; }

        public MainWindow()
        {
            TxtSvr = new TextSaver();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int countClick = Convert.ToInt32(TxtSvr.TextValue);
            countClick++;
            TxtSvr.TextValue = countClick.ToString();
            TxtSvr.NotifyPropertyChanged("TextValue");
        }
    }
}
