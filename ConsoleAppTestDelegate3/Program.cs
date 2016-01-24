using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTestDelegate3
{
    class Program
    {
        public delegate T SampleGenericDelegate<T>();

        static void Main(string[] args)
        {
            Program.Test();
        }

        public static void Test()
        {


            SampleGenericDelegate<String> dString = () => " ";

            // You can assign the dObject delegate
            // to the same lambda expression as dString delegate
            // because of the variance support for 
            // matching method signatures with delegate types.
            SampleGenericDelegate<Object> dObject = () => " ";

            // The following statement generates a compiler error
            // because the generic type T is not marked as covariant.
            //SampleGenericDelegate <Object> dObject = dString;




            Action<object> actObj = x => Console.WriteLine("object: {0}", x);
            Action<string> actStr = x => Console.WriteLine("string: {0}", x);
            // All of the following statements throw exceptions at run time.
            //Action<string> actCombine = actStr + actObj;
            //actStr += actObj;
            //Delegate.Combine(actStr, actObj);


        }
    }
}
