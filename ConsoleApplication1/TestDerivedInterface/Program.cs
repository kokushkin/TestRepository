using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDerivedInterface
{
    public interface IJunWorker
    {
       int JunFunc1();
       int JunFunc2();
    }

    public interface ILowWorker
    {
        int LowFunc1();
        int LowFunc2();
    }
    public interface IDirector<out TJWorker, out TLWorker>
    {
        TJWorker JWorker { get; set; }
        TLWorker LWorker { get; set; }
        //TJWorker GetJWorker();
        //TLWorker GetLWorker();
    }

    public class CoolJunWorker : IJunWorker
    {
        public int JunFunc1()
        { return 0; }

        public int JunFunc2()
        { return 0; }
    }

    public class BadJunWorker : IJunWorker
    {
        public int JunFunc1()
        { return 1; }

        public int JunFunc2()
        { return 1; }
    }

    public class CoolLowWorker : ILowWorker
    {
        public int LowFunc1()
        { return 0; }
        public int LowFunc2()
        { return 0; }
    }

    public class BadLowWorker : ILowWorker
    {
        public int LowFunc1()
        { return 1; }
        public int LowFunc2()
        { return 1; }
    }


    public class BadCoolDirector : IDirector<BadJunWorker, CoolLowWorker>
    {

        public BadJunWorker JWorker { get; set; }
        public CoolLowWorker LWorker { get; set; }

        //public BadJunWorker GetJWorker()
        //{
        //    return new BadJunWorker();
        //}
        //public CoolLowWorker GetLWorker()
        //{
        //    return new CoolLowWorker();
        //}
    }



    class Program
    {
        static void Main(string[] args)
        {
            BadCoolDirector director = new BadCoolDirector();

            IDirector<IJunWorker, ILowWorker> idirector = director;
            //idirector.GetJWorker();
            //idirector.GetLWorker();

        }
    }
}
