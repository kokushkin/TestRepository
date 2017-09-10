using EssentialWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TransportAuthenticationClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.StockServiceClient proxy = new ServiceReference1.StockServiceClient("BasicHttpsBinding_IStockService");

            //пришлось добавить из-за проблем с сертификатом
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                (se, cert, chain, sslerror) =>
                {

                    return true;
                };

            proxy.ClientCredentials.UserName.UserName = "TestName";
            proxy.ClientCredentials.UserName.Password = "TestPassword";


            double p = proxy.GetPrice("MSFT");
            Console.WriteLine("Price:{0}", p);
            proxy.Close();



            //ChannelFactory<IStockService> cf = new ChannelFactory<IStockService>("BasicHttpsBinding_IStockService_IStockService");
            //cf.Credentials.UserName.UserName = "TestName";
            //cf.Credentials.UserName.Password = "TestPassword";

            //IStockService proxy = cf.CreateChannel();


            //double p = proxy.GetPrice("MSFT");
            //Console.WriteLine("Price:{0}", p);

            //cf.Close();


        }
    }
}
