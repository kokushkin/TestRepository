using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelExceptionTestProgect
{
    class Program
    {

        static void InnerFunction2(int[] arr, int i)
        {
            var x = 1 / (arr[i] - 10);
        }

        static void InnerFunction1(int[] arr, int i)
        {
            InnerFunction2(arr, i);
        }


        static void Function2()
        {
            var arr = Enumerable.Repeat(10, 10).ToArray();

            try
            {
                //Parallel.For(0, 10, i =>
                //{
                //    var x = 1 / (arr[i] - 10);
                //    //InnerFunction1(arr, i);
                //});

                ThreadPool.QueueUserWorkItem(o =>
                    {
                        int y = 0;
                        int x = 1 / y;
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        static void Function1()
        {
            Function2();
        }



        static void Main(string[] args)
        {

            Function1();


            Console.ReadLine();
        }
    }
}
