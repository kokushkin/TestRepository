using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
namespace EssentialWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            //BasicHttpBinding binding = new BasicHttpBinding();
            //BindingParameterCollection parameters =
            //new BindingParameterCollection();
            //Message m =
            //Message.CreateMessage(MessageVersion.Soap11, "urn:sendmessage");
            //IChannelFactory<IOutputChannel> factory =
            //binding.BuildChannelFactory<IOutputChannel>(parameters);

            //IOutputChannel channel = factory.CreateChannel(
            //new EndpointAddress("http://localhost/sendmessage/"));
            //channel.Send(m);
            //channel.Close();
            //factory.Close();


            NetTcpBinding binding = new NetTcpBinding();
            BindingParameterCollection parameters =
            new BindingParameterCollection();
            Message m =
            Message.CreateMessage(MessageVersion.Soap12WSAddressing10,
            "urn:sendmessage");
            IChannelFactory<IDuplexChannel> factory =
            binding.BuildChannelFactory<IDuplexChannel>(parameters);
            factory.Open();
            IDuplexChannel channel = factory.CreateChannel(
            new EndpointAddress("net.tcp://localhost/sendmessage/"));
            channel.Open();
            channel.Send(m);
            channel.Close();
            factory.Close();


            //BasicHttpBinding binding = new BasicHttpBinding();
            //BindingParameterCollection parameters =
            //new BindingParameterCollection();
            //Message request =
            //Message.CreateMessage(MessageVersion.Soap11, "urn:sendmessage");
            //IChannelFactory<IRequestChannel> factory =
            //binding.BuildChannelFactory<IRequestChannel>(parameters);
            //factory.Open();
            //IRequestChannel channel = factory.CreateChannel(
            //new EndpointAddress("http://localhost/sendmessage/"));
            //channel.Open();
            //Message response = channel.Request(request);
            //channel.Close();
            //factory.Close();


            //CustomBinding binding = new CustomBinding(
            //    new OneWayBindingElement(),
            //    new TextMessageEncodingBindingElement(),
            //    new HttpTransportBindingElement());
        }
    }
}