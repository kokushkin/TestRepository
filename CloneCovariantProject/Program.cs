using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://stackoverflow.com/questions/32594179/stackoverflowexception-by-using-explict-interface-implementation-having-covarian
namespace CloneCovariantProject
{
    public interface IClonable<out T>
    {
        T ShallowClone();
    }

    public interface IMyInterface
    {
        void DoSomething();
    }

    public interface IMyInterface<T> : IClonable<T>
    { }

    //public class MyClass : IMyInterface
    //{
    //    public void DoSomething()
    //    {
    //        Console.WriteLine("I do something.");
    //    }
    //}

    public class MyClass : IMyInterface
    {

        public void DoSomething()
        {
            Console.WriteLine("I do something (MyClass).");
        }
    }


    public class MyClassClonbl<T> : IClonable<T>
    {
        public T ShallowClone()
        {
            return (T)this.ShallowClone();
        }
    }




    public class MyClass1 : IMyInterface
    {

        public void DoSomething()
        {
            Console.WriteLine("I do something (MyClass1).");
        }
    }

    public class MyClass1Clonbl<T> : IClonable<T>
    {
        public T ShallowClone()
        {
            return (T)this.ShallowClone();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            IMyInterface<IMyInterface> ref1 = new MyClassClonbl<MyClass>();
            TestMethod(ref1);
            ref1 = new MyClass1();
            TestMethod(ref1);
            

        }

        static void TestMethod(IMyInterface<IMyInterface> inParametr)
        {
            inParametr.DoSomething();
            var obj = inParametr.ShallowClone();
            obj.DoSomething();
        }
    }
}
