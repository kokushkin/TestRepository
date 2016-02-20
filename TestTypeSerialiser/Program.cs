using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestTypeSerialiser
{

    public class SubA
    {
        public string Name {get; set;}
        public int Old {get; set;}
    }

    public class A
    {
        public SubA Sub { get; set; }

        public int Id { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {

            var obj = new A {Sub = new SubA {Name = "Vasia", Old = 40}, Id = 23213};

            var DataSerializer = new XmlSerializer(typeof(A));
            var TypeSerializer = new XmlSerializer(typeof(Type));

            using(MemoryStream mStream = new MemoryStream())
            {
                TypeSerializer.Serialize(mStream, typeof(A));
                DataSerializer.Serialize(mStream, obj);
                
                using(FileStream fStream = new FileStream("test.txt", FileMode.Create))
                {
                    File.WriteAllBytes("test.txt", mStream.ToArray());
                }
            }

            byte[] bytes = File.ReadAllBytes("test.txt");
            using(MemoryStream mStream = new MemoryStream(bytes))
            {
                Type tp = (Type)TypeSerializer.Deserialize(mStream);
                var nwDataSerializer = new XmlSerializer(tp);
                var desObj = nwDataSerializer.Deserialize(mStream);
            }


        }
    }
}
