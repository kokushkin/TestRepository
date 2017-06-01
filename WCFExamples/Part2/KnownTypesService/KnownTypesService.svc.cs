using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace KnownTypesService
{
    [ServiceBehavior(Namespace = "http://EssentialWCF/FinanceService/")]
    public class StockService : IStockService
    {

        public Price GetPrice(string id, string type)
        {
            if (type.Contains("Stock"))
            {
                StockPrice s = new StockPrice();
                s.Ticker = id;
                s.DailyVolume = 45000000;
                s.CurrentPrice = 94.15;
                s.CurrentTime = System.DateTime.Now;
                s.Currency = "USD";
                return s;
            }
            if (type.Contains("Metal"))
            {

                MetalPrice g = new MetalPrice();
                g.Metal = id;
                g.Quality = "0.999";
                g.CurrentPrice = 785.00;
                g.CurrentTime = System.DateTime.Now;
                g.Currency = "USD";
                return g;
            }
            return new Price();
        }

        public List<StockPrice> GetPricesAsCollection(string[] tickers)
        {
            List<StockPrice> list = new List<StockPrice>();
            for (int i = 0; i < tickers.GetUpperBound(0) + 1; i++)
            {
                StockPrice p = new StockPrice();
                p.Ticker = tickers[i];
                p.CurrentPrice = 94.85;
                p.CurrentTime = System.DateTime.Now;
                list.Add(p);
            }
            return list;

        }
    }
}
