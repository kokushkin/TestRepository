using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDateTimeToDictionaryConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Tuple<DateTime, string>> list = new List<Tuple<DateTime, string>>();
            list.Add(new Tuple<DateTime, string>(new DateTime(1994, 11, 12, 13, 23, 22, 10), "first"));
            list.Add(new Tuple<DateTime, string>(new DateTime(1994, 11, 12, 13, 23, 22, 11), "second"));
            list.Add(new Tuple<DateTime, string>(new DateTime(1994, 11, 12, 13, 23, 22, 12), "fird"));

            try
            {
                Dictionary<DateTime, string> dic = list.ToDictionary(h => h.Item1, h => h.Item2);
            }
            catch(Exception ex)
            {

            }



        }
    }
}
