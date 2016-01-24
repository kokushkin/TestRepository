using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TestWriteToFileConsoleApplication
{

    class SafeFileOperations
    {

        static string copy = "Copy";

        public static void Write(byte[] inbytes, string filename, string copyName = null)
        {
            copyName = copyName ?? Path.GetFileNameWithoutExtension(filename) + copy + Path.GetExtension(filename);

            //write to copy
            File.WriteAllBytes(copyName, inbytes);

            //delete main
            File.Delete(filename);

            //rename copy to main
            File.Move(copyName, filename);
        }

        public static void Read(out byte[] outbytes, string filename, string copyName = null)
        {
            copyName = copyName ?? Path.GetFileNameWithoutExtension(filename) + copy + Path.GetExtension(filename);

            if (File.Exists(filename) && File.Exists(copyName))
                File.Delete(copyName);

            if (!File.Exists(filename) && File.Exists(copyName))
                File.Move(copyName, filename);

            outbytes = File.ReadAllBytes(filename);
        }


    }


    class Program
    {
        static void Main(string[] args)
        {

            string Filename = "TestFile.txt";

            if (File.Exists(Filename))
                File.Delete(Filename);

            File.Create(Filename).Close();


            //FileStream fs = new FileStream(Filename, FileMode.Create);

            FileInfo file = new FileInfo(Filename);
            
        
            List<string> longString = new List<string>();

            string[] stringArr = new string[10000000];

            for (int i = 0; i < 10000000; i++)
            {
                stringArr[i] = i + ". Идет запись в файл.";
            }

            //File.WriteAllLines(Filename , stringArr);
            //File.SetAccessControl(Filename, new FileSecurity(Filename, AccessControlSections.Audit));
            
            //file.Attributes.


            using (FileStream fs = new FileStream(Filename, FileMode.Create, FileAccess.Write, FileShare.None, 100000,false))
            {



                fs.Seek(0, SeekOrigin.Begin);

                for (int i = 0; i < 10000000; i++)
                {

                    byte[] bytes = Encoding.UTF8.GetBytes(stringArr[i] + Environment.NewLine);


                    

                    //на втором витке
                    //Смещение и длина вышли за границы массива или значение 
                    //    счетчика превышает количество элементов от указателя до конца исходной коллекции.
                    fs.Write(bytes, 0, bytes.Count());

                }

                fs.Flush();
                

            }


        }



        
    }
}
