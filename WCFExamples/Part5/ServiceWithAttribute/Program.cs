using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServiceWithAttribute
{
    [AttributeUsage(AttributeTargets.Method)]
    public class myOperationBehavior : Attribute, IOperationBehavior
    {
        public string pattern;
        public string message;

        public void AddBindingParameters (OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyClientBehavior(OperationDescription operationDescription,ClientOperation clientOperation)
        {
        }
        public void ApplyDispatchBehavior (OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.ParameterInspectors.Add(
            new myParameterInspector(this.pattern, this.message));
        }
        public void Validate(OperationDescription operationDescription)
        { }
    }

    public class myParameterInspector : IParameterInspector
    {
        string _pattern;
        string _message;
        public myParameterInspector(string pattern, string message)
        {
            _pattern = pattern;
            _message = message;
        }
        public void AfterCall(string operationName,
        object[] outputs,
        object returnValue, object
        correlationState)
        { }
        public object BeforeCall(string operationName, object[] inputs)
        {
            foreach (object input in inputs)
            {
                if ((input != null) && (input.GetType() == typeof(string)))
                {
                    Regex regex = new Regex(_pattern);
                    if (regex.IsMatch((string)input))
                        throw new FaultException(string.Format("значение параметра вне диапазона:{0}, {1}",
                        (string)input, _message));
                }
            }
            return null;
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
        [myOperationBehavior(pattern = "[^a-zA-Z]", message = "Допустимы только буквы")]
        public double GetPrice(string ticker)
        {
            if (ticker == "MSFT") return 94.85;
            else return 0.0;
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
