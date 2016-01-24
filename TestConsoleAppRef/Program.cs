using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleAppRef
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "String1";
            string str2 = str1;

            str2.Replace("Str", "Rts");

            Console.ReadLine();
        }
    }
}
