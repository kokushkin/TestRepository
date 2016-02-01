using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQueueConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> qu = new Queue<string>();

            qu.Enqueue("1");
            qu.Enqueue("2");
            qu.Enqueue("3");

            var el = qu.FirstOrDefault();
            var el1 = qu.Peek();
            var el2 = qu.LastOrDefault();

        }
    }
}
