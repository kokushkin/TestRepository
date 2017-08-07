using ChangeContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChangeContractClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Employee()
            {
                EmployeeID = 123456,
                FirstName = "John",
                LastName = "Doe",
                SSN = "000-00-0000"
            };

            Console.WriteLine("{0} {1}, {2}, {3}", new object[] {
                e.FirstName,
                e.LastName,
                e.EmployeeID,
                e.SSN
            });


            ChannelFactory<IEmployeeInformation> factory
                = new ChannelFactory<IEmployeeInformation>("BasicHttpBinding_IEmployeeInformation");

            var chanel = factory.CreateChannel();


            var e1 = chanel.UpdateEmployee(e);

            factory.Close();

            Console.WriteLine("{0} {1}, {2}, {3}", new object[] {
                e1.FirstName,
                e1.LastName,
                e1.EmployeeID,
                e1.SSN
            });

            Console.WriteLine("Для завершения нажмите [ENTER].");
            Console.ReadLine();
        }
    }
}
