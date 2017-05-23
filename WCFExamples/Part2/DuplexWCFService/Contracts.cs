using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DuplexService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract(CallbackContract = typeof(IClientCallback))]
    public interface IStockService 
    {

        [OperationContract(IsOneWay = true)]
        void RegisterForUpdates(string ticker);
    }

    public interface IClientCallback
    {
        [OperationContract(IsOneWay = true)]
        void PriceUpdate(string ticker, double price);
    }


}
