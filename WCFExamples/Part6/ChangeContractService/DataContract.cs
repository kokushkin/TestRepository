using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChangeContractService
{

    [DataContract]
    public class Employee
    {
        //private int employeeID;
        //private string firstName;
        //private string lastName;
        //private string ssn;

        //public Employee()
        //{ }
        //public Employee(int employeeID, string firstName, string lastName)
        //{
        //    this.employeeID = employeeID;
        //    this.firstName = firstName;
        //    this.lastName = lastName;
        //}

        [DataMember]
        public string EmployeeID { get; set; }

        //    [DataMember]
        //public int EmployeeID
        //{
        //    get { return employeeID; }
        //    set { employeeID = value; }
        //}
        //[DataMember]
        //public string FirstName
        //{
        //    get { return firstName; }
        //    set { firstName = value; }
        //}
        //[DataMember]
        //public string LastName
        //{
        //    get { return lastName; }
        //    set { lastName = value; }
        //}
        //[DataMember]
        //public string SSN
        //{
        //    get { return ssn; }
        //    set { ssn = value; }
        //}
    }


    //[DataContract]
    //public class Employee //: IExtensibleDataObject
    //{
    //    //private ExtensionDataObject extensionData;
    //    //private int employeeID;
    //    //private string firstName;
    //    //private string lastName;
    //    //public Employee()
    //    //{ }
    //    //public Employee(int employeeID, string firstName, string lastName)
    //    //{
    //    //    this.employeeID = employeeID;
    //    //    this.firstName = firstName;
    //    //    this.lastName = lastName;
    //    //}
    //    //public ExtensionDataObject ExtensionData
    //    //{
    //    //    get { return extensionData; }
    //    //    set { extensionData = value; }
    //    //}

    //    [DataMember]
    //    public int EmployeeID { get; set; }

    //    //[DataMember]
    //    //public int EmployeeID
    //    //{
    //    //    get { return employeeID; }
    //    //    set { employeeID = value; }
    //    //}
    //    //[DataMember]
    //    //public string FirstName
    //    //{
    //    //    get { return firstName; }
    //    //    set { firstName = value; }
    //    //}
    //    //[DataMember]
    //    //public string LastName
    //    //{
    //    //    get { return lastName; }
    //    //    set { lastName = value; }
    //    //}
    //}
}
