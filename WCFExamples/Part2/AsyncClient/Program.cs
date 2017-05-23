﻿using AsyncClient.ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncClient
{
    class Program
    {
        static int c = 0;

        //Main with begin/and (using AsyncClient.ServiceReference1;)

        //static void Main(string[] args)
        //{
        //    StockServiceClient proxy = new StockServiceClient();
        //    IAsyncResult arGetPrice;
        //    for (int i = 0; i < 10; i++)
        //    {
        //        arGetPrice = proxy.BeginGetPrice("msft", GetPriceCallback, proxy);
        //        Interlocked.Increment(ref c);
        //    }

        //    while (c > 0)
        //    {
        //        Thread.Sleep(1000);
        //        Console.WriteLine("Ожидание... Незавершенных вызовов:{0}", c);
        //    }

        //    proxy.Close();
        //    Console.WriteLine("Готово!");

        //}

        //// Асинхронный обратный вызов для вывода результата.
        //static void GetPriceCallback(IAsyncResult ar)
        //{
        //    double d = ((StockServiceClient)ar.AsyncState).EndGetPrice(ar);
        //    Interlocked.Decrement(ref c);
        //}


        //Main with async/await (using AsyncClient.ServiceReference1;)

        static void Main(string[] args)
        {
            StockServiceClient proxy = new StockServiceClient();

            List<Task<double>> tasks = new List<Task<double>>();

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(proxy.GetPriceAsync("msft"));
            }


            while(!tasks.All(tsk => tsk.IsCompleted))
            {
                Thread.Sleep(1000);
                Console.WriteLine("Ожидание... Незавершенных вызовов");
            }

            Console.WriteLine("Результаты: {0}", string.Join(";", tasks.Select(tsk => tsk.Result)));

            proxy.Close();
            Console.WriteLine("Готово!");

        }
    }
}
