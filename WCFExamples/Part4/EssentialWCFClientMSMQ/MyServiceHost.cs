using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EssentialWCFClient
{
    internal class MyServiceHost
    {
        internal static ServiceHost myServiceHost = null;
        internal static void StartService()
        {
            string queueName =
        ConfigurationManager.AppSettings["queueName"];
            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);
            myServiceHost =
            new ServiceHost(typeof(EssentialWCFClient.Program));
            myServiceHost.Open();
        }
        internal static void StopService()
        {
            if (myServiceHost.State != CommunicationState.Closed)
                myServiceHost.Close();
        }
    }
}
