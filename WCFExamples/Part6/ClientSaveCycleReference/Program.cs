using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSaveCycleReference
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.EmployeeInformationClient proxy = new ServiceReference1.EmployeeInformationClient();

            var employess = proxy.GetEmployeesOfTheMonth();

            proxy.Close();
        }
    }
}
