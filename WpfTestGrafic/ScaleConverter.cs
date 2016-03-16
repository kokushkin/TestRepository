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

                if ((string)parameter == "X")
                    return actualSize / maxGraficSize;
                else if ((string)parameter == "Y")
                    return -actualSize / maxGraficSize;
                else
                    return 1;
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

    public class ArifmeticConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            try
            {
                string oper = (string)parameter;
                double[] parms = values.Select(o => (double)o).ToArray();
                if (oper == "avg")
                    return parms.Average();
                else
                    return 1;
            }
            catch (Exception ex)
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
