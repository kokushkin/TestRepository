using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChangeContractClient
{
    [ServiceContract]
    public interface IEmployeeInformation
    {
        [OperationContract]
        Employee UpdateEmployee(Employee employee);
    }
}
