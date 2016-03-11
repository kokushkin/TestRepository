using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTestDoubleDateTimeStringConvert
{
    public class DoubleStringDateTimeConverter
    {
        public  string ToString(double value)
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
        public  double ToDouble(string value)
        {
            double res;
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
                    DateTime prsDt = DateTime.Parse(value);
                    res = prsDt.ToOADate();
                    break;
            }
            return res;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DoubleStringDateTimeConverter cnv = new DoubleStringDateTimeConverter();
            //DateTime dt = DateTime.UtcNow;
            //string str = cnv.ToString(dt.ToOADate());
            //Console.WriteLine(str);
            //double dbl = cnv.ToDouble(str);
            //Console.WriteLine(dbl);
            //Console.WriteLine(cnv.ToString(dbl));

            double pinfDouble = double.PositiveInfinity;
            string str = cnv.ToString(pinfDouble);
            double nanDouble = double.NaN;
            string str2 = cnv.ToString(nanDouble);
            double ninfDouble = double.NegativeInfinity;
            string str3 = cnv.ToString(ninfDouble);

            DateTime dtpinf = DateTime.FromOADate(pinfDouble);



            Console.ReadLine();




        }
    }
}
