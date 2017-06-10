using EssentialWCFClient.EssentialWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EssentialWCFClient
{

    public class Program : IStockQuoteDuplexServiceCallback
    {
        private static AutoResetEvent waitForResponse;
        static void Main(string[] args)
        {
            string symbol = "MSFT";
            waitForResponse = new AutoResetEvent(false);
            InstanceContext callbackInstance =
            new InstanceContext(new Program());
            using (StockQuoteDuplexServiceClient client =
            new StockQuoteDuplexServiceClient(callbackInstance))
            {
                client.SendQuoteRequest(symbol);
                waitForResponse.WaitOne();
            }
            Console.ReadLine();
        }
        #region IStockQuoteDuplexServiceCallback Members
        public void SendQuoteResponse(string symbol, double price)
        {
            Console.WriteLine("{0} @ ${1}", symbol, price);
            waitForResponse.Set();
        }
        #endregion
    }
}
