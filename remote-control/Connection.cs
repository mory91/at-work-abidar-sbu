using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace remote_control
{
    class Connection
    {
        public static string data = null;

        private Socket handler;
        private TcpListener listener;

        public void StartListening()
        {
            byte[] bytes = new Byte[1024];
//            IPHostEntry ipHostInfo = Dns.Resolve("127.0.0.1");
//            IPAddress ipAddress = ipHostInfo.AddressList[0];
//            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 15000);
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"),15000);
            try
            {
    
                
                listener.Start();
                Console.WriteLine("Waiting for a connection...");
                handler = listener.AcceptSocket();
                Console.WriteLine("Connected!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void sendMsg(byte[] msg)
        {
            if (!handler.Connected)
                handler.Connect("127.0.0.1", 15000);
            handler.Send(msg);
        }

        ~Connection()
        {
             handler.Shutdown(SocketShutdown.Both);  
             handler.Close();  
        }
    }
}
