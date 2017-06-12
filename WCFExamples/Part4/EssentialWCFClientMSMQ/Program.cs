using EssentialWCFClient.EssentialWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace EssentialWCFClient
{
    [ServiceContract]
    public interface IStockQuoteRequest
    {
        [OperationContract(IsOneWay = true)]
        void SendQuoteRequest(string symbol);
    }

    [ServiceContract]
    public interface IStockQuoteResponse
    {
        [OperationContract(IsOneWay = true)]
        void SendQuoteResponse(string symbol, double price);
    }

    public class Program : IStockQuoteResponse
    {
        private static AutoResetEvent waitForResponse;
        static void Main(string[] args)
        {
            // Запустить владельца отвечающей службы
            MyServiceHost.StartService();
            try
            {
                waitForResponse = new AutoResetEvent(false);
                // Послать запрос серверу
                using (ChannelFactory<IStockQuoteRequest> cf = new ChannelFactory<IStockQuoteRequest>("NetMsmqRequestClient"))
                {
                    IStockQuoteRequest client = cf.CreateChannel();
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                    {
                        client.SendQuoteRequest("MSFT");
                        scope.Complete();
                    }
                    cf.Close();
                }
                waitForResponse.WaitOne();
            }
            finally
            {
                MyServiceHost.StopService();
            }
            Console.ReadLine();
        }
        #region ×ëåíû IStockQuoteResponseService
        public void SendQuoteResponse(string symbol, double price)
        {
            Console.WriteLine("{0} @ ${1}", symbol, price);
            waitForResponse.Set();
        }
        #endregion
    }


}
