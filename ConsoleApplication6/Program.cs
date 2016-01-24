using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{


    // В этом обобщенном интерфейсе поддерживается ковариантность.
    public interface IMyCoVarGenIF<out T>
    {
        T GetObject();
    } 

    // Реализовать интерфейс IMyCoVarGenIF.
    class MyClass<T> : IMyCoVarGenIF<T>
    {
        T obj;
        public MyClass(T v) { obj = v; }
        public T GetObject() { return obj; }
    }


    // Создать простую иерархию классов.
    class Alpha
    {
        string name;

        public Alpha(string n) { name = n; }

        public string GetName() { return name; }
        // ... 
    }
    class Beta : Alpha
    {
        public Beta(string n) : base(n) { }
        // ...
    } 




    




    class Program
    {
        static void Main(string[] args)
        {

            // Создать ссылку из интерфейса IMyCoVarGenIF на объект типа MyClass<Alpha>.
            // Это вполне допустимо как при наличии ковариантности, так и без нее.
            IMyCoVarGenIF<Alpha> AlphaRef = new MyClass<Alpha>(new Alpha("Alpha #1"));

            Console.WriteLine("Имя объекта, на который ссылается переменная AlphaRef: " +
              AlphaRef.GetObject().GetName());
            // А теперь создать объект MyClass<Beta> и присвоить его переменной AlphaRef.
            // *** Эта строка кода вполне допустима благодаря ковариантности. ***
            AlphaRef = new MyClass<Beta>(new Beta("Beta #1"));

            Console.WriteLine("Имя объекта, на который теперь ссылается " +
              "переменная AlphaRef: " + AlphaRef.GetObject().GetName()); 
        }
    }
}
