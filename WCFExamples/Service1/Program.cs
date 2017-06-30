using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Service1
{
    public class myEndpointBehavior : IEndpointBehavior
    {
        public void AddBindingParameters
        (ServiceEndpoint endpoint,
        System.ServiceModel.Channels.BindingParameterCollection
        bindingParameters)
        {
        }
        public void ApplyClientBehavior
        (ServiceEndpoint endpoint,
        ClientRuntime clientRuntime)
        {
        }
        public void ApplyDispatchBehavior
        (ServiceEndpoint endpoint,
        EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(
            new myMessageInspector());
        }
        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }

    public class myMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest
        (ref System.ServiceModel.Channels.Message request,
        IClientChannel channel,
        InstanceContext instanceContext)
        {
            Console.WriteLine(request.ToString());
            return request;
        }
        public void BeforeSendReply
        (ref System.ServiceModel.Channels.Message reply,
        object correlationState)
        {
            Console.WriteLine(reply.ToString());
        }
    }

    [ServiceContract]
    public interface IStockService
    {
        [OperationContract]
        double GetPrice(string ticker);
    }

    public class StockService : IStockService
    {
        public double GetPrice(string ticker)
        {
            return 94.85;
        }
    }

    public class service
    {
        public static void Main()
        {
            ServiceHost serviceHost = new ServiceHost(typeof(StockService));
            foreach (ServiceEndpoint endpoint in
            serviceHost.Description.Endpoints)
                endpoint.Behaviors.Add(new myEndpointBehavior());
            serviceHost.Open();

            Console.WriteLine("Службы готовы к работе\n\n");
            Console.ReadLine();

            serviceHost.Close();
        }
    }
}
