using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChangeContract
{

    [DataContract]
    public class Employee : IExtensibleDataObject
    {
        private int employeeID;
        private string firstName;
        private string lastName;
        private ExtensionDataObject extensionData;


        public Employee()
        { }
        public Employee(int employeeID, string firstName, string lastName)
        {
            this.employeeID = employeeID;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public ExtensionDataObject ExtensionData
        {
            get { return extensionData; }
            set { extensionData = value; }
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
