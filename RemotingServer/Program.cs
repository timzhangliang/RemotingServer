using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Ipc;
using System.Text;
using System.Threading.Tasks;


namespace RemotingServer
{
    class Server
    {
        static void Main(string[] args)
        {
            //IpcChannel channel = new IpcChannel("myhost");
            //ChannelServices.RegisterChannel(channel, false);
            //RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemotingObjects.Person), "RemotingPersonService", WellKnownObjectMode.SingleCall);

            HttpChannel httpChannel = new HttpChannel(9001);
            ChannelServices.RegisterChannel(httpChannel, false);

            TcpChannel tcpChannel = new TcpChannel(9002);
            ChannelServices.RegisterChannel(tcpChannel, false);

            IpcChannel ipcChannel = new IpcChannel("MyHost");
            ChannelServices.RegisterChannel(ipcChannel, false);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemotingObjects.Person), "RemotingPersonService", WellKnownObjectMode.SingleCall);
            Console.ReadLine();

            System.Console.WriteLine("Server:Press Enter key to exit");
            System.Console.ReadLine();
        }
    }
}
