using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWithBehavior
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.StockServiceClient proxy = new ServiceReference1.StockServiceClient();

            var price = proxy.GetPrice("MS3FT");

            proxy.Close();
        }
    }
}
