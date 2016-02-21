using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
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


    public class SaveClass
    {
        public object Obj {get; set;}
        public string TypeName {get; set;}
    }


    class Program
    {
        static void Main(string[] args)
        {

            var obj = new A {Sub = new SubA {Name = "Vasia", Old = 40}, Id = 23213};

            SaveClass sv = new SaveClass { Obj = obj, TypeName = (typeof(A)).AssemblyQualifiedName };

            var serializer = new XmlSerializer(typeof(SaveClass));

            using(MemoryStream mStream = new MemoryStream())
            {
                serializer.Serialize(mStream, sv);         
                File.WriteAllBytes("test.txt", mStream.ToArray());
            }



            byte[] bytes = File.ReadAllBytes("test.txt");
            using(MemoryStream mStream = new MemoryStream(bytes))
            {
                mStream.Seek(0, SeekOrigin.Begin);
                var TypeSerializer = new XmlSerializer(typeof(string));
                string tpNm = (string)TypeSerializer.Deserialize(mStream);
                var tp = Type.GetType(tpNm);
                if(tp != default(Type))
                {
                    var nwDataSerializer = new XmlSerializer(tp);
                    mStream.Seek(0, SeekOrigin.Begin);
                    var desObj = nwDataSerializer.Deserialize(mStream);
                }              
            }


        }
    }
}
