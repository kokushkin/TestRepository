﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UpdateSourceExperiment
{
    public class SimpleConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string svalue = (string)value;
            svalue = svalue + "Converted";
            return svalue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string svalue = (string)value;
            svalue = svalue.Replace("Converted", "");
            return svalue;
        }
    }
}
