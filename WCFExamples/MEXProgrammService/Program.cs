using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace EssentialWCF
{
    [ServiceContract]
    public interface IStockService
    {
        [OperationContract]
        double GetPrice(string ticker);
    }
    public class StockService : IStockService
    {
        public double GetPrice(string ticker)
        {
            return 94.85;
        }
    }
    public class Service
    {
        public static void Main()
        {
            ServiceHost serviceHost = new ServiceHost((typeof(StockService)), new Uri("http://localhost:8000/EssentialWCF"));

            serviceHost.AddServiceEndpoint(typeof(IStockService), new BasicHttpBinding(), "");

            ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            behavior.HttpGetEnabled = true;
            serviceHost.Description.Behaviors.Add(behavior);

            serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            serviceHost.Open();
            Console.WriteLine("Для завершения нажмите <ENTER>.\n\n");
            Console.ReadLine();
            serviceHost.Close();
        }
    }
}
