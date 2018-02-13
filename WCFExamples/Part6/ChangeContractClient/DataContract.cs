﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChangeContract
{
    [DataContract]
    public class Employee
    {
        private int employeeID;
        private string firstName;
        private string lastName;
        private string ssn;

        public Employee()
        { }
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
        public string SSN
        {
            get { return ssn; }
            set { ssn = value; }
        }
    }
}