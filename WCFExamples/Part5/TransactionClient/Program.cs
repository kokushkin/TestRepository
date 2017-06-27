using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference.BankServiceClient proxy = new ServiceReference.BankServiceClient();

            Console.WriteLine("{0}: До - cчет Alex:{1}, счет Victor {2}",
            System.DateTime.Now,
            proxy.GetBalance("Alex"),
            proxy.GetBalance("Victor"));

            proxy.Transfer("Alex", "Victor", 100);

            Console.WriteLine("{0}: После - cчет Alex:{1}, счет Victor {2}",
            System.DateTime.Now,
            proxy.GetBalance("Alex"),
            proxy.GetBalance("Victor"));

            proxy.Close();
        }
    }
}
