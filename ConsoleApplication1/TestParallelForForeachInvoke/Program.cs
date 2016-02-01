using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication12_Parallel_For__
{
    class Program
    {
        static int[] data;

        static void MyTransform(int i)
        {
            data[i] = data[i] / 10;

            if (data[i] < 10000) data[i] = 0;
            if (data[i] >= 10000) data[i] = 100;
            if (data[i] > 20000) data[i] = 200;
            if (data[i] > 30000) data[i] = 300;
        }

        static void Main()
        {
            Console.WriteLine("Основной поток запущен");

            data = new int[1000000];

            for (int i = 0; i < data.Length; i++)
                data[i] = i;

            // Распараллелить цикл методом For()
            ParallelOptions opt = new ParallelOptions();
            opt.MaxDegreeOfParallelism = 10;
            CancellationTokenSource cancelTokSSrc = new CancellationTokenSource();

            opt.CancellationToken = cancelTokSSrc.Token;

            ParallelLoopResult res = default(ParallelLoopResult);
            try
            {
                cancelTokSSrc.CancelAfter(100);
                res = Parallel.For(0, data.Length, opt, i => { MyTransform(i); opt.CancellationToken.ThrowIfCancellationRequested(); });
                //Thread.Sleep(2000);
                

            }
            catch(Exception ex)
            {
                if(!res.IsCompleted)
                {
                    Console.WriteLine("Операция была прервана");
                }
            }


            Console.WriteLine("Основной поток завершен");
            Console.ReadLine();
        }
    }
}