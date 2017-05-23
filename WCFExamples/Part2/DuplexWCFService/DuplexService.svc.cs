using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace DuplexService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class StockService : IStockService 
    {
        public class Worker
        {
            public string ticker;
            public Update workerProcess;
        }

        public static Hashtable workers = new Hashtable();

        public void RegisterForUpdates(string ticker)
        {
            Worker w = null;

            // при необходимости создаем новый рабочий объект, добавляем его
            // в хеш-тблицу и запускаем в отдельном потоке 
            if (!workers.ContainsKey(ticker))
            {
                w = new Worker();
                w.ticker = ticker;
                w.workerProcess = new Update();
                w.workerProcess.ticker = ticker;
                workers[ticker] = w;

                Thread t = new Thread(new
                    ThreadStart(w.workerProcess.SendUpdateToClient));
                t.IsBackground = true;
                t.Start();
            }

            // получить рабочий объект для данного тикера и добавить
            // прокси клиента в список обратных вызовов
            w = (Worker)workers[ticker];
            IClientCallback c = OperationContext.Current.GetCallbackChannel<IClientCallback>();
            lock (w.workerProcess.callbacks)
                w.workerProcess.callbacks.Add(c);
        }
    }

    public class Update
    {
        public string ticker;
        public List<IClientCallback> callbacks = new List<IClientCallback>();
        public void SendUpdateToClient()
        {
            Random w = new Random(); Random p = new Random(); while (true)
            {
                Thread.Sleep(w.Next(5000));
                //откуда-то получаем обновления
                lock (callbacks)
                    foreach (IClientCallback c in callbacks)
                        try
                        {
                            c.PriceUpdate(ticker, 100.00+p.NextDouble()*10);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ошибка при отправке кэшированного значения клиенту: {0}", ex.Message);
                        }
            }
        }
    } 
}
