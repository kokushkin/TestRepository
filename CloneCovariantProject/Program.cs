using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneCovariantProject
{
    public interface IClonable<out T> : IMyInterface
    {
        T ShallowClone();
    }

    public interface IMyInterface
    {
        void DoSomething();
    }

    //public class MyClass : IMyInterface
    //{
    //    public void DoSomething()
    //    {
    //        Console.WriteLine("I do something.");
    //    }
    //}

    public class MyClassCloneble<T> : IClonable<T>, IMyInterface
    {

        public T ShallowClone()
        {
            return (T)this.ShallowClone();
        }

        public void DoSomething()
        {
            Console.WriteLine("I do something.");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            IClonable<IMyInterface> ref1 = new MyClassCloneble<IClonable<IMyInterface>>();

        }
    }
}
