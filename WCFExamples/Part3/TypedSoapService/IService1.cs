using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TypedSoapService
{
    [Serializable]
    public class PriceDetails
    {
        public string Ticker;
        public double Amount;
    }
    [MessageContract]
    public class StockPrice
    {
        [MessageHeader]
        public DateTime CurrentTime;
        [MessageBodyMember]
        public PriceDetails Price;
    }

    [MessageContract]
    public class StockPriceReq
    {
        [MessageBodyMember]
        public string Ticker;
    }
    [ServiceContract]
    public interface IStockService
    {
        [OperationContract]
        StockPrice GetPrice(StockPriceReq req);
    }

}
