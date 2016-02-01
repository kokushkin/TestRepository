using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        // Метод выполняемый в качестве задачи
        static void MyTask(Object ct)
        {
            CancellationToken cancelTok = (CancellationToken)ct;
            cancelTok.ThrowIfCancellationRequested();

            Console.WriteLine("MyTask() №{0} запущен", Task.CurrentId);

            for (int count = 0; count < 10; count++)
            {
                // Используем опрос
                if (!cancelTok.IsCancellationRequested)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("В методе MyTask №{0} подсчет равен {1}", Task.CurrentId, count);
                    //throw new NotImplementedException("JJSdjs");
                    cancelTok.ThrowIfCancellationRequested();
                }
            }

            Console.WriteLine("MyTask() #{0} завершен", Task.CurrentId);
            
        }

        static void Main()
        {
            Console.WriteLine("Основной поток запущен");

            // Объект источника признаков отмены
            CancellationTokenSource cancelTokSSrc = new CancellationTokenSource();

            // Запустить задачу, передав ей признак отмены
            Task tsk = Task.Factory.StartNew(MyTask, cancelTokSSrc.Token, cancelTokSSrc.Token);

            Thread.Sleep(2000);
            try
            {
                // отменить задачу
                cancelTokSSrc.Cancel();
                tsk.Wait();
            }
            catch (AggregateException exc)
            {
                if (tsk.IsCanceled)
                    Console.WriteLine("Задача tsk отменена");
            }
            finally
            {
                tsk.Dispose();
                cancelTokSSrc.Dispose();
            }

            Console.WriteLine("Основной поток завершен");
            Console.ReadLine();
        }
    }
}