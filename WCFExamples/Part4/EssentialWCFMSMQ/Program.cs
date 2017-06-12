using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
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
        internal static string queueName = null;
        internal static ServiceHost myServiceHost = null;
        internal static void StartService()
        {
            queueName = ConfigurationManager.AppSettings["queueName"];
            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);
            myServiceHost = new ServiceHost(typeof(EssentialWCF.StockQuoteRequestService));
            myServiceHost.Open();
        }
        internal static void StopService()
        {
            if (myServiceHost.State != CommunicationState.Closed)
                myServiceHost.Close();
        }
    }
}
