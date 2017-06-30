using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.StockServiceClient proxy = new ServiceReference1.StockServiceClient();

            var price =proxy.GetPrice("DFDF");

            proxy.Close();
        }
    }
}
