using System;
using System.Collections.Generic;
using System.Linq;
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

            double p = proxy.GetPrice("MSFT");
            Console.WriteLine("Price:{0}", p);
            proxy.Close();
        }
    }
}
