using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntranetWindowsClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для обращения к службе нажмите ENTER");
            Console.ReadLine();
            ServiceReference1.SamplesClient proxy = new ServiceReference1.SamplesClient("netTcp");
            try
            {
                Console.WriteLine(proxy.GetPublicCode());
                Console.WriteLine(proxy.GetMemberCode());
                Console.WriteLine(proxy.GetSecretCode());
            }
            catch (Exception e)
            {
                Console.WriteLine("Исключение = " + e.Message);
            }
            Console.ReadLine();
        }
        
            
    }
}
