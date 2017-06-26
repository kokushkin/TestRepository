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
            ServiceReference.BankServiceClient proxy = new
ServiceReference.BankServiceClient();
            Console.WriteLine("{0}: Äî – ñáåðåãàòåëüíûé ñ÷åò:{1}, ñ÷åò äî âîñòðåáîâàíèÿ {2}",
            System.DateTime.Now,
            proxy.GetBalance("savings"),
            proxy.GetBalance("checking"));
            proxy.Transfer("savings", "checking", 100);
            Console.WriteLine("{0}: Ïîñëå – ñáåðåãàòåëüíûé ñ÷åò:{1}, ñ÷åò äî âîñòðåáî-
            âàíèÿ { 2}
            ",
System.DateTime.Now,
proxy.GetBalance("savings"),
proxy.GetBalance("checking"));
            proxy.Close();
        }
    }
}
