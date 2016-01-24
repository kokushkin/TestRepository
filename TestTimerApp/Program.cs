using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TestTimerApp
{
    class Program
    {
        Timer timer = null;

        static void Main(string[] args)
        {

           TimerCallback tcb =  new TimerCallback(o => Func());
           Timer timer = new Timer(tcb, null, 100, 10000);

           Thread.Sleep(100000);
        }

        public static void Func()
        {
            Thread.Sleep(2000);
            Console.WriteLine("A");

        }
    }
}
