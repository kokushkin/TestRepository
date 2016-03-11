using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfTestGrafic
{
    public abstract class DoubleStringConverter
    {
        string ToString(double value);
        double ToDouble(string value);
    }

    public class DoubleStringDateTimeConverter : DoubleStringConverter
    {
        public override string ToString(double value)
        {
            DateTime dt = (new DateTime(1970, 1, 1)).AddSeconds(Math.Floor(value)).AddMilliseconds((value - Math.Floor(value)) * 1000);
            return dt.ToLongTimeString();
            //DateTime dt = new DateTime(Convert.ToInt32(value));
            //return String.Format(dt.ToString() + " {0}:{1}:{2}.{3}", dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }
        public override double ToDouble(string value)
        {
            DateTime dt = default(DateTime);
            DateTime.TryParse(value, out dt);
            DateTime nwDatetime = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            return (nwDatetime - new DateTime(1970, 1, 1)).TotalSeconds + dt.Second / 1000;
        }
    }

    [ValueConversion(typeof(double), typeof(string))]
    public class CostConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            // Возвращаем строку в формате 123.456.789 руб.
            return ((double)value).ToString("#,###", culture) + " руб.";
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            double result;
            if (Double.TryParse(value.ToString(), System.Globalization.NumberStyles.Any,
                         culture, out result))
            {
                return result;
            }
            else if (Double.TryParse(value.ToString().Replace(" руб.", ""), System.Globalization.NumberStyles.Any,
                         culture, out result))
            {
                return result;
            }
            return value;
        }
    }
}
