using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQueryLinq
{
    public static class Extensions
    {
        public static IEnumerable<int> ExceptLast(this IEnumerable<int> collection, int lastCount)
        {
            Queue<int> buffer = new Queue<int>(lastCount);
            bool bufferFull = false;

            foreach (var el in collection)
            {
                if (bufferFull)
                    yield return buffer.Dequeue();

                buffer.Enqueue(el);

                if (!bufferFull && buffer.Count() == lastCount)
                    bufferFull = true;
            }
        }
    }


    class Program
    {
        
        static void Main(string[] args)
        {
            int n = 10;
            IEnumerable<int> testList = ParallelEnumerable.Repeat(2, 100000000);

            Stopwatch wch = new Stopwatch();

            //wch.Reset();
            //wch.Start();

            //var count = testList.Count();

            //wch.Stop();

            //Console.WriteLine($"just count: time is {wch.Elapsed}");



            //wch.Reset();
            //wch.Start();

            //var elementsExceptN = testList.Take(testList.Count() - n);

            //wch.Stop();

            //Console.WriteLine($"lazy Take with count: time is {wch.Elapsed}");


            //wch.Reset();
            //wch.Start();

            //var elementsExceptNResult = testList.Take(testList.Count() - n).ToArray();

            //wch.Stop();

            //Console.WriteLine($"Take with count ToArray: time is {wch.Elapsed}");


            //wch.Reset();
            //wch.Start();

            //var elementsExceptN1 = testList.ExceptLast(n);//.ToArray();
            //foreach (var el in elementsExceptN1)
            //{

            //}

            //wch.Stop();

            //Console.WriteLine($"ExceptLast extension ToArray: time is {wch.Elapsed}");



            //wch.Reset();
            //wch.Start();

            //var elementsExceptN2 = testList.AsQueryable().Take(testList.Count() - n);

            //wch.Stop();

            //Console.WriteLine($"AsQueryable with Count: time is {wch.Elapsed}");



            //wch.Reset();
            //wch.Start();

            //var query = testList.AsQueryable().Reverse().Skip(n).Reverse();
            //var elementsExceptN3 = query.ToArray();
            ////foreach (var el in query)
            ////{

            ////}

            //var enumerator = query.GetEnumerator();
            //while (enumerator.MoveNext())
            //{

            //}


            //wch.Stop();

            //Console.WriteLine($"AsQueryable without count ToArray(): time is {wch.Elapsed}");


            wch.Reset();
            wch.Start();

            var queryEnum = testList.Reverse().Skip(n).Reverse();
            //var elementsExceptN3queryEnum = queryEnum.ToArray();
            var enumerator = queryEnum.GetEnumerator();
            while (enumerator.MoveNext())
            {

               
            }

            //wch.Stop();

            //Console.WriteLine($"IEnumerable without count ToArray(): time is {wch.Elapsed}");


            Console.ReadKey();

        }


    }
}
