﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EssentialWCFClient.EssentialWCF {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EssentialWCF.IStockQuoteDuplexService", CallbackContract=typeof(EssentialWCFClient.EssentialWCF.IStockQuoteDuplexServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IStockQuoteDuplexService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IStockQuoteDuplexService/SendQuoteRequest")]
        void SendQuoteRequest(string symbol);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IStockQuoteDuplexService/SendQuoteRequest")]
        System.Threading.Tasks.Task SendQuoteRequestAsync(string symbol);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStockQuoteDuplexServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IStockQuoteDuplexService/SendQuoteResponse")]
        void SendQuoteResponse(string symbol, double price);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStockQuoteDuplexServiceChannel : EssentialWCFClient.EssentialWCF.IStockQuoteDuplexService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StockQuoteDuplexServiceClient : System.ServiceModel.DuplexClientBase<EssentialWCFClient.EssentialWCF.IStockQuoteDuplexService>, EssentialWCFClient.EssentialWCF.IStockQuoteDuplexService {
        
        public StockQuoteDuplexServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public StockQuoteDuplexServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public StockQuoteDuplexServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public StockQuoteDuplexServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public StockQuoteDuplexServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void SendQuoteRequest(string symbol) {
            base.Channel.SendQuoteRequest(symbol);
        }
        
        public System.Threading.Tasks.Task SendQuoteRequestAsync(string symbol) {
            return base.Channel.SendQuoteRequestAsync(symbol);
        }
    }
}
