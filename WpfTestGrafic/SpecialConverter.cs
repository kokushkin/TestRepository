using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfTestGrafic
{
    public abstract class DoubleStringConverter
    {
        abstract public string ToString(double value);
        abstract public double ToDouble(string value);
    }

    public class DoubleStringDateTimeConverter : DoubleStringConverter
    {
        public override string ToString(double value)
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
        public override double ToDouble(string value)
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

    public class DoubleStringUnixTimeConverter : DoubleStringConverter
    {
        public override string ToString(double value)
        {
            if (double.IsNegativeInfinity(value))
                return "-∞";
            else if (double.IsPositiveInfinity(value))
                return "∞";
            else if (double.IsNaN(value))
                return "NaN";
            else
                return string.Format("{0} sec.", value);

        }
        public override double ToDouble(string value)
        {
            double res = 0;
            switch (value)
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
                    var groups = Regex.Match(value, @"^\s*(\d+)\s*sec.\s*$").Groups;
                    if(groups != null)
                        double.TryParse(groups[1].Value, out res);
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

    [ValueConversion(typeof(double), typeof(double))]
    public class HalfConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return ((double)value)/2;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [ValueConversion(typeof(double), typeof(double))]
    public class NegativeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return -(double)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
