using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSaveCycleReference
{
    [DataContract]
    public class Employee
    {
        private int employeeID;
        private string firstName;
        private string lastName;

        public Employee(int employeeID, string firstName, string lastName)
        {
            this.employeeID = employeeID;
            this.firstName = firstName;
            this.lastName = lastName;
        }
        [DataMember]
        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }
        [DataMember]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        [DataMember]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        [DataMember]
        public IEnumerable<Work> YourWorks { get; set; }

    }

    [DataContract]
    public class Work
    {
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime Till { get; set; }

        [DataMember]
        public Employee Employee { get; set; }
    }


    [ServiceContract]
    public interface IEmployeeInformation
    {
        [OperationContract]
        Employee[] GetEmployeesOfTheMonth();
    }

    public class EmployeeInformation : IEmployeeInformation
    {
        public EmployeeInformation()
        { }
        public Employee[] GetEmployeesOfTheMonth()
        {
            List<Employee> list = new List<Employee>(6);
            Employee Employee1 = new Employee(1, "John", "Doe");
            Employee1.YourWorks = new List<Work>
                {
                    new Work
                    {
                        Description = "Clean Ketchen",
                        Till = DateTime.Now.AddDays(1),
                        Employee = Employee1
                    },
                    new Work
                    {
                        Description = "Prepare deener",
                        Till = DateTime.Now.AddDays(1),
                        Employee = Employee1
                    }
                };
            Employee Employee2 = new Employee(2, "Jane", "Doe");
            Employee2.YourWorks = new List<Work>
                {
                    new Work
                    {
                        Description = "Wash Yourself",
                        Till = DateTime.Now.AddDays(1),
                        Employee = Employee2
                    },
                    new Work
                    {
                        Description = "Calculate gamma function",
                        Till = DateTime.Now.AddDays(2),
                        Employee = Employee2
                    }
                };

            Employee Employee3 = new Employee(3, "John", "Smith");
            list.Add(Employee1);
            list.Add(Employee2);
            list.Add(Employee3);
            list.Add(Employee1);
            list.Add(Employee2);
            list.Add(Employee3);
            return list.ToArray();
        }
    }

    public class  Service
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
