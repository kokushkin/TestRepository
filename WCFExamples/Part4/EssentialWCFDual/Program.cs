using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EssentialWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            MyServiceHost.StartService();
            Console.WriteLine("To close tipe any key");
            Console.ReadKey();
            MyServiceHost.StopService();
        }
    }

    internal class MyServiceHost
    {
        internal static ServiceHost myServiceHost = null;
        internal static void StartService()
        {
            myServiceHost = new
            ServiceHost(typeof(EssentialWCF.StockQuoteService));
            myServiceHost.Open();
        }
        internal static void StopService()
        {
            if (myServiceHost.State != CommunicationState.Closed)
                myServiceHost.Close();
        }
    }
}
