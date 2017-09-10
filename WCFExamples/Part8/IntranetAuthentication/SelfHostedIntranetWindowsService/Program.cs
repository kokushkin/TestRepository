using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SampleService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost((typeof(Samples)));
            serviceHost.Open();
            Console.WriteLine("Для завершения нажмите <ENTER>.\n\n"); Console.ReadLine();
            serviceHost.Close();
        }
    }
}
