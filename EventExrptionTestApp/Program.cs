using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExrptionTestApp
{
    public class A
    {
        B _subClass { get; set; }

        public A(B subClass)
        {
            _subClass = subClass;
            _subClass.SendMessage += OnSendMesasge;
        }

        private void OnSendMesasge(object sender, string e)
        {
            throw new NotImplementedException();
        }
    }

    public class B
    {
        public event EventHandler<string> SendMessage;

        public B()
        {

        }

        public void SentMessage(string message)
        {
            try
            {
                SendMessage?.Invoke(this, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in SentMessage");
            }
        }

    }



    class Program
    {
        static void Main(string[] args)
        {

            B provider = new B();
            A abonent = new A(provider);
            provider.SentMessage("blablabla");
        }
    }
}
