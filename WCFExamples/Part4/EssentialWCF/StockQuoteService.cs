using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EssentialWCF
{
    [ServiceContract]
    public interface IStockQuoteService
    {
        [OperationContract]
        double GetQuote(string symbol);
    }

    public class StockQuoteService : IStockQuoteService
    {
        public double GetQuote(string symbol)
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
            return value;
        }
    }
}
