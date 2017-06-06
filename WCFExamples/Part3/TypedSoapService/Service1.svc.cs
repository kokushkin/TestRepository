using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TypedSoapService
{
    public class StockService : IStockService
    {
        public StockPrice GetPrice(StockPriceReq req)
        {
            StockPrice resp = new StockPrice();
            resp.Price = new PriceDetails();
            resp.Price.Ticker = req.Ticker;
            resp.Price.Amount = 94.85;
            return resp;
        }
    }
}
