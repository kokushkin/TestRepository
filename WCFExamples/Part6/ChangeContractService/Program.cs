using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChangeContractService
{
    public class EmployeeInformation : IEmployeeInformation
    {
        public Employee UpdateEmployee(Employee emp)
        {
            return emp;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            ServiceHost serviceHost = new ServiceHost(typeof(EmployeeInformation));

            serviceHost.Open();

            Console.WriteLine("Службы готовы к работе\n\n");
            Console.ReadLine();

            serviceHost.Close();

        }
    }
}
