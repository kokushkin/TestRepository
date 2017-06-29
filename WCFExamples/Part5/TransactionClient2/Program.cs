using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TransactionClient.ServiceReference1;

namespace TransactionClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                BankServiceClient proxy1 = new BankServiceClient();
                BankServiceClient proxy2 = new BankServiceClient();

                Console.WriteLine("{0}: До - cчет Alex:{1}, счет Victor {2}",
                System.DateTime.Now,
                proxy1.GetBalance("Alex"),
                proxy2.GetBalance("Victor"));

                proxy1.Withdraw("Alex", 100);
                proxy2.Deposit("Victor", 100);
                scope.Complete();
                proxy1.Close();
                proxy2.Close();
            }
            BankServiceClient proxy3 = new BankServiceClient();

            Console.WriteLine("{0}: После - cчет Alex:{1}, счет Victor {2}",
            System.DateTime.Now,
            proxy3.GetBalance("Alex"),
            proxy3.GetBalance("Victor"));
            proxy3.Close();
        }
    }
}
