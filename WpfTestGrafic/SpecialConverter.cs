using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfTestGrafic
{
    public enum ConverterType
    {
        Border = 0,
        Interval = 1
    }

    public abstract class DoubleStringConverter
    {
        abstract public string ToString(double value, ConverterType type, ref double min, ref double max);
        abstract public double ToDouble(string value, ConverterType type, ref double min, ref double max);
    }

    public class DoubleStringDateTimeConverter : DoubleStringConverter
    {
        public override string ToString(double value, ConverterType type, ref double min, ref double max)
        {
            if(type == ConverterType.Border)
            {
                if (double.IsNegativeInfinity(value))
                    return "-∞";
                else if (double.IsPositiveInfinity(value))
                    return "∞";
                else if (double.IsNaN(value))
                    return "NaN";
                else
                {
                    DateTime dt = DateTime.FromOADate(value);
                    return dt.ToString("yyyy.MM.dd HH:mm:ss.fff");
                }
            }
            else
            {

            }


        }
        public override double ToDouble(string value, ConverterType type, ref double min, ref double max)
        {
            double res;
            switch(value)
            {
                case "-∞":
                    res = double.NegativeInfinity;
                    break;
                case "∞":
                    res = double.PositiveInfinity;
                    break;
                case "NaN":
                    res = double.NaN;
                    break;
                default:
                    DateTime prsDt = DateTime.Parse(value);
                    res =  prsDt.ToOADate();
                    break;
            }
            return res;

            
        }
    }

    [ValueConversion(typeof(double), typeof(string))]
    public class CostConverter : IValueConverter
    {
        public DoubleStringConverter cnv;

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            //DoubleStringConverter cnv = (DoubleStringConverter)parameter;
            return cnv.ToString((double)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            //DoubleStringConverter cnv = (DoubleStringConverter)parameter;
            return cnv.ToDouble((string)value);
        }
    }
}
