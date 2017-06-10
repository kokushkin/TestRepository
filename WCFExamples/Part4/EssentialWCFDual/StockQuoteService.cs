using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EssentialWCF
{
    [ServiceContract(CallbackContract = typeof(IStockQuoteCallback),
    SessionMode = SessionMode.Required)]
    public interface IStockQuoteDuplexService
    {
        [OperationContract(IsOneWay = true)]
        void SendQuoteRequest(string symbol);
    }
    public interface IStockQuoteCallback
    {
        [OperationContract(IsOneWay = true)]
        void SendQuoteResponse(string symbol, double price);
    }
    [ServiceBehavior(InstanceContextMode =
    InstanceContextMode.PerSession)]
    public class StockQuoteDuplexService : IStockQuoteDuplexService
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
            OperationContext ctx = OperationContext.Current;
            IStockQuoteCallback callback =
            ctx.GetCallbackChannel<IStockQuoteCallback>();
            callback.SendQuoteResponse(symbol, value);
        }
    }
}
