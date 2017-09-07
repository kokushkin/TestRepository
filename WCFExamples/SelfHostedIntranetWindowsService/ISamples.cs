using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SampleService
{
    [ServiceContract]
    public interface ISamples
    {
        [OperationContract]
        string GetSecretCode();
        [OperationContract]
        string GetMemberCode();
        [OperationContract]
        string GetPublicCode();
    }
}
