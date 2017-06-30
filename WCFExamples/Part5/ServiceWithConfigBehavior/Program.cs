using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace ServiceWithConfigBehavior
{
    public class myServiceBehavior : IServiceBehavior
    {
        string _EvaluationKey;
        string _EvaluationType;

        public myServiceBehavior(string EvaluationKey, string EvaluationType)
        {
            _EvaluationKey = EvaluationKey;
            _EvaluationType = EvaluationType;
        }
        public void AddBindingParameters(ServiceDescription serviceDescription,
        ServiceHostBase serviceHostBase,
        System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints,
        BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {

        }

        public void Validate(ServiceDescription serviceDescription,ServiceHostBase serviceHostBase)
        {
            if ((_EvaluationType == "Enterprise") &
            (_EvaluationKey != "SuperSecretEvaluationKey"))
                throw new Exception
                (String.Format("Неправильный ключ апробирования. Type:{ 0 }",_EvaluationType));
        }
    }

    public class myBehaviorExtensionElement : BehaviorExtensionElement
    {
        [ConfigurationProperty("EvaluationKey", DefaultValue = "", IsRequired = true)]
        public string EvaluationKey
        {
            get { return (string)base["EvaluationKey"]; }
            set { base["EvaluationKey"] = value; }
        }

        [ConfigurationProperty("EvaluationType",DefaultValue = "Enterprise", IsRequired = false)]
        public string EvaluationType
        {
            get { return (string)base["EvaluationType"]; }
            set { base["EvaluationType"] = value; }
        }

        public override Type BehaviorType
        {
            get { return typeof(myServiceBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new myServiceBehavior(EvaluationKey, EvaluationType);
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
            if (ticker == "MSFT")
                return 94.85;
            else
                return 0.0;
        }
    }




    public class service
    {
        public static void Main()
        {
            ServiceHost serviceHost = new ServiceHost(typeof(StockService));

            serviceHost.Open();

            Console.WriteLine("Службы готовы к работе\n\n");
            Console.ReadLine();

            serviceHost.Close();
        }
    }
}
