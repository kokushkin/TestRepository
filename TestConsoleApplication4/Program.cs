using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApplication4
{

    public class A
    {
        string simple;
    }

    public class B : A
    {
        int numer;
    }


    //Ошибка	2	TestConsoleApplication4.TestClass не реализует член интерфейса "TestConsoleApplication4.IBaseIntetface.Foo()". 
    //"TestConsoleApplication4.TestClass.Foo()" не удается реализовать "TestConsoleApplication4.IBaseIntetface.Foo()",
    //поскольку он не содержит соответствующего типа возвращаемого значения "TestConsoleApplication4.A".	
    //D:\REPOSITORY\parsersrc\StatusBukProxyChecker\TestConsoleApplication4\Program.cs	32	18	TestConsoleApplication4

    //public interface IBaseIntetface
    //{
    //    A Foo();
    //}


    //public interface IInterface : IBaseIntetface
    //{
    //    B Foo();
    //}



    //public class TestClass : IInterface
    //{
    //    public B Foo()
    //    {
    //        Console.WriteLine("A");
    //        return new B();
    //    }
    //}




    //OK   NO COVARIANT

    public interface ICovariantInterface<out T>  //Foo can return derivers. For ex. class B
    {
        T Foo();
    }

    public class CovariantClass : ICovariantInterface<B>
    {
        public B Foo()
        {
            Console.WriteLine("A");
            return new B();
        }
    }









    class Program
    {
        static void Main(string[] args)
        {
            //var tcl = new TestClass();
            //tcl.Foo();

            //OK    NO COVARIANT
            //var covarObj = new CovariantClass();
            //covarObj.Foo();


            ExperContainerManthPeople<ExperManthPeople> manthCont = new ExperContainerManthPeople<ExperManthPeople>();

            manthCont.OurPeople = new List<ExperManthPeople>();
            manthCont.OurPeople.Add(new ExperManthPeople { Name = "Alex", Year = 1998, Manth = 6 });
            manthCont.OurPeople.Add(new ExperManthPeople { Name = "Ivan", Year = 1996, Manth = 11 });
           

            IExperContainer<ExperPeople> Cont = manthCont;


            

            var ff = Cont.GetPeople().FirstOrDefault();


            var oldManth = manthCont.GetOldestPeople();
            var old = Cont.GetOldestPeople();
            


            Console.ReadLine();
        }
    }
}
