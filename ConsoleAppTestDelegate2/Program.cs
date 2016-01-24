using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTestDelegate2
{
    class Program
    {
        // Type T is declared covariant by using the out keyword.
        public delegate T SampleGenericDelegate<out T>();

        public static void Test()
        {
            SampleGenericDelegate<String> dString = () => " ";

            // You can assign delegates to each other,
            // because the type T is declared covariant.
            SampleGenericDelegate<Object> dObject = dString;
        }

        static void Main(string[] args)
        {
        }
    }
}
