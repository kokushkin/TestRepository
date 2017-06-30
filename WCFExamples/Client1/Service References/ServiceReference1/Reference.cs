﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client1.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IStockService")]
    public interface IStockService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/GetPrice", ReplyAction="http://tempuri.org/IStockService/GetPriceResponse")]
        double GetPrice(string ticker);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/GetPrice", ReplyAction="http://tempuri.org/IStockService/GetPriceResponse")]
        System.Threading.Tasks.Task<double> GetPriceAsync(string ticker);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStockServiceChannel : Client1.ServiceReference1.IStockService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StockServiceClient : System.ServiceModel.ClientBase<Client1.ServiceReference1.IStockService>, Client1.ServiceReference1.IStockService {
        
        public StockServiceClient() {
        }
        
        public StockServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StockServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StockServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StockServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double GetPrice(string ticker) {
            return base.Channel.GetPrice(ticker);
        }
        
        public System.Threading.Tasks.Task<double> GetPriceAsync(string ticker) {
            return base.Channel.GetPriceAsync(ticker);
        }
    }
}
