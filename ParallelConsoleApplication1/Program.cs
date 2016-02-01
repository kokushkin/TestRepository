using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelConsoleApplication1
{
    class Program
    {

        static void MyTask(Object ct)
        {
            CancellationToken cancelTok = (CancellationToken)ct;
            cancelTok.ThrowIfCancellationRequested();

            Console.WriteLine("MyTask() №(0) запущен", Task.CurrentId);

            for(int count = 0; count < 10; count++)
            {
                if(!cancelTok.IsCancellationRequested)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("В методе MyTask №{0} подсчет равен {1}", Task.CurrentId, count);
                }
            }

            Console.WriteLine("MyTask() #{0} завершен", Task.CurrentId);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Основной поток запущен");
            CancellationTokenSource cancelTokSSrc = new CancellationTokenSource();
            Task tsk = Task.Factory.StartNew(MyTask, cancelTokSSrc.Token, cancelTokSSrc.Token);
        }
    }
}
