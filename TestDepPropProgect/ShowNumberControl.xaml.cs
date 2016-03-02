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

namespace TestDepPropProgect
{
    /// <summary>
    /// Логика взаимодействия для ShowNumberControl.xaml
    /// </summary>
    public partial class ShowNumberControl : UserControl
    {
        public int CurrentNumber
        {
            get { return (int)GetValue(CurrentNumberProperty); }
            set { SetValue(CurrentNumberProperty, value); }
        }

        public static readonly DependencyProperty CurrentNumberProperty =
                    DependencyProperty.Register("CurrentNumber", typeof(int),
                    typeof(ShowNumberControl),
                    new UIPropertyMetadata(100,
                        new PropertyChangedCallback(CurrentNumberChanged)));

        private static void CurrentNumberChanged(DependencyObject depObj,
            DependencyPropertyChangedEventArgs args)
        {
            ShowNumberControl s = (ShowNumberControl)depObj;
            Label theLabel = s.numberDisplay;
            theLabel.Content = args.NewValue.ToString();
        }  

        public ShowNumberControl()
        {
            InitializeComponent();
           
        }
    }
}
