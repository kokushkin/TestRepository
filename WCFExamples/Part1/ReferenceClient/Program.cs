using ReferenceClient.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            StockServiceClient proxy = new StockServiceClient();
            double p = proxy.GetPrice("msft");
            Console.WriteLine("Price:{0}", p);
            proxy.Close();
        }
    }
}
