using EssentialWCFClient.EssentialWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialWCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            StockQuoteServiceClient proxy = new StockQuoteServiceClient();
            double p = proxy.GetQuote("MSFT");
            Console.WriteLine("Price:{0}", p);
            proxy.Close();
        }
    }
}
