﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AsyncClient.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IStockService")]
    public interface IStockService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/GetPrice", ReplyAction="http://tempuri.org/IStockService/GetPriceResponse")]
        double GetPrice(string ticker);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IStockService/GetPrice", ReplyAction="http://tempuri.org/IStockService/GetPriceResponse")]
        System.IAsyncResult BeginGetPrice(string ticker, System.AsyncCallback callback, object asyncState);
        
        double EndGetPrice(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStockServiceChannel : AsyncClient.ServiceReference1.IStockService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetPriceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetPriceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public double Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StockServiceClient : System.ServiceModel.ClientBase<AsyncClient.ServiceReference1.IStockService>, AsyncClient.ServiceReference1.IStockService {
        
        private BeginOperationDelegate onBeginGetPriceDelegate;
        
        private EndOperationDelegate onEndGetPriceDelegate;
        
        private System.Threading.SendOrPostCallback onGetPriceCompletedDelegate;
        
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
        
        public event System.EventHandler<GetPriceCompletedEventArgs> GetPriceCompleted;
        
        public double GetPrice(string ticker) {
            return base.Channel.GetPrice(ticker);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetPrice(string ticker, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetPrice(ticker, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public double EndGetPrice(System.IAsyncResult result) {
            return base.Channel.EndGetPrice(result);
        }
        
        private System.IAsyncResult OnBeginGetPrice(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string ticker = ((string)(inValues[0]));
            return this.BeginGetPrice(ticker, callback, asyncState);
        }
        
        private object[] OnEndGetPrice(System.IAsyncResult result) {
            double retVal = this.EndGetPrice(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetPriceCompleted(object state) {
            if ((this.GetPriceCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetPriceCompleted(this, new GetPriceCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetPriceAsync(string ticker) {
            this.GetPriceAsync(ticker, null);
        }
        
        public void GetPriceAsync(string ticker, object userState) {
            if ((this.onBeginGetPriceDelegate == null)) {
                this.onBeginGetPriceDelegate = new BeginOperationDelegate(this.OnBeginGetPrice);
            }
            if ((this.onEndGetPriceDelegate == null)) {
                this.onEndGetPriceDelegate = new EndOperationDelegate(this.OnEndGetPrice);
            }
            if ((this.onGetPriceCompletedDelegate == null)) {
                this.onGetPriceCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetPriceCompleted);
            }
            base.InvokeAsync(this.onBeginGetPriceDelegate, new object[] {
                        ticker}, this.onEndGetPriceDelegate, this.onGetPriceCompletedDelegate, userState);
        }
    }
}
