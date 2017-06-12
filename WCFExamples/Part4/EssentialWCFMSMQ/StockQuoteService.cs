using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EssentialWCF
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

    public class StockQuoteRequestService : IStockQuoteRequest
    {
        public void SendQuoteRequest(string symbol)
        {
            double value;
            if (symbol == "MSFT")
                value = 31.15;
            else if (symbol == "YHOO")
                value = 28.10;
            else if (symbol == "GOOG")
                value = 450.75;
            else
                value = double.NaN;

            //Отправить ответ клиенту в отдельную очередь.
            NetMsmqBinding msmqResponseBinding = new NetMsmqBinding();
            using (ChannelFactory<IStockQuoteResponse> cf = new ChannelFactory<IStockQuoteResponse>("NetMsmqResponseClient"))
            {
                IStockQuoteResponse client = cf.CreateChannel();
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    client.SendQuoteResponse(symbol, value);
                    scope.Complete();
                }
                cf.Close();
            }
        }
    }

}
