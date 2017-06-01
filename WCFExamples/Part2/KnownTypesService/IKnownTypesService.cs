using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace KnownTypesService
{
    [DataContract(Namespace = "http://EssentialWCF/")]
    [KnownType(typeof(StockPrice))]
    [KnownType(typeof(MetalPrice))]
    public class Price
    {
        [DataMember]
        public double CurrentPrice;
        [DataMember]
        public DateTime CurrentTime;
        [DataMember]
        public string Currency;
    }
    [DataContract(Namespace = "http://EssentialWCF/")]
    public class StockPrice : Price
    {
        [DataMember]
        public string Ticker;
        [DataMember]
        public long DailyVolume;
    }
    [DataContract(Namespace = "http://EssentialWCF/")]
    public class MetalPrice : Price
    {
        [DataMember]
        public string Metal;
        [DataMember]
        public string Quality;
    }

    [CollectionDataContract]
    public class StockPriceCollection : List<StockPrice>
    { }


    [ServiceContract(Namespace = "http://EssentialWCF/FinanceService/")]
    public interface IStockService
    {
        [OperationContract]
        Price GetPrice(string id, string type);

        [OperationContract]
        List<StockPrice> GetPricesAsCollection(string[] tickers);

        }
    }
