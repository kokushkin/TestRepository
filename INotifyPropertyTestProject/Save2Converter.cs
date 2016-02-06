using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace INotifyPropertyTestProject
{
    /// <summary>
    /// value[0] - save binding
    /// </summary>

    public class Save2Converter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return values[1];
        }

        public object[] ConvertBack(object values, Type[] targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            object[] objArr = new object[2];
            objArr[0] = values;
            objArr[1] = values;
            return objArr;
        }
    }
}
