using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfTestGrafic
{

    //[ValueConversion(typeof(double), typeof(string))]
    //[MultiValueConversion]
    public class ScaleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            try
            {
                double actualSize = (double)values[0];
                double maxGraficSize = (double)values[1];

                return actualSize / maxGraficSize;
            }
            catch(Exception ex)
            {
                return 1;
            }
 
        }

        public object[] ConvertBack(object values, Type[] targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
