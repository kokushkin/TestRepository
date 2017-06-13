using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://ikeptwalking.com/microsoft-unity-tutorial/

namespace UnityDemo
{
    class Demo
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            ContainerMagic.RegisterElements(container);

            IBattery battery = container.Resolve<IBattery>();
            Console.WriteLine(battery.SerialNumber());

            //не сработало при Registration by convention

            //Dial dial = container.Resolve<Dial>();
            //Console.WriteLine(dial.DialType());

            ITuner tuner = container.Resolve<ITuner>();


            //не нужно, если юзается Registration by convention

            //IRadio radio = container.Resolve<IRadio>(new ParameterOverride("radioBattery", battery),
            //    new ParameterOverride("radioTuner", tuner),
            //    new ParameterOverride("radioName", "BrokenRadio"));
            //var param1 = radio.Battery;
            //var strManuf = param1.Manufacturer();
            //var param2 = radio.Tuner;
            //radio.Start();

            //ISpeaker cheapSpeaker = container.Resolve<ISpeaker>("Cheap");
            //ISpeaker priceySpeaker = container.Resolve<ISpeaker>("Expensive");
            //cheapSpeaker.Start();
            //priceySpeaker.Start();

            ICasing casing = container.Resolve<ICasing>();
            Console.WriteLine(casing.TypeOfMaterial());
        }
    }
}
