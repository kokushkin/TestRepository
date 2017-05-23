using DuplexClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DuplexClient
{
    public class CallbackHandler : IStockServiceCallback
    {
        static InstanceContext site = new InstanceContext(new CallbackHandler());
        static StockServiceClient proxy = new StockServiceClient(site);
        public void PriceUpdate(string ticker, double price)
        {
            Console.WriteLine("Получено извещение в : {0}. {1}:{2}", System.DateTime.Now, ticker, price);
        }
        class Program
        {
            static void Main(string[] args)
            {
                proxy.RegisterForUpdates("MSFT");
                Console.WriteLine("Для завершения нажмите любую клавишу");
                Console.ReadLine();
            }
        }
    }
}
