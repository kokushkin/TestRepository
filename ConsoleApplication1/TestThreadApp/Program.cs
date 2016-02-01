using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestThreadApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    throw new NotImplementedException("sdasd");
                });
            }
            catch (AggregateException ex)
            {

            }




            Console.ReadLine();
        }
    }
}
