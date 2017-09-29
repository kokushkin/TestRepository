using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace EssentialWCF
{
    [DataContract]
    public class StockPrice
    {
        [DataMember]
        public double price;
        [DataMember]
        public int volume;
    }

    [ServiceContract]
    public interface IStockService
    {
        [OperationContract]
        StockPrice GetPrice(string ticker);
    }

    public class StockService : IStockService
    {
        public StockPrice GetPrice(string ticker)
        {
            return new StockPrice { price = 4.53, volume = 23 };
        }
    }
    public class Service
    {
        public static void Main()
        {
            ServiceHost serviceHost = new ServiceHost((typeof(StockService)));
            serviceHost.Open();
            Console.WriteLine("Для завершения нажмите <ENTER>.\n\n"); Console.ReadLine();
            serviceHost.Close();
        }
    }
}
