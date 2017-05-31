using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace UnityDemo
{
    public class ContainerMagic
    {
        public static void RegisterElements(IUnityContainer container)
        {
            Dial dial = new Dial("Linear");
            container.RegisterInstance(dial);

            container.RegisterType<IBattery, Battery>();
            container.RegisterType<ITuner, Tuner>();

            var batteryType = typeof(IBattery);
            var tunerType = typeof(ITuner);
            container.RegisterType<IRadio, Radio>(new InjectionConstructor(batteryType, tunerType, typeof(string)));

            container.RegisterType<ISpeaker, CheapSpeaker>("Cheap");
            container.RegisterType<ISpeaker, PriceySpeaker>("Expensive");
        }
    }
}
