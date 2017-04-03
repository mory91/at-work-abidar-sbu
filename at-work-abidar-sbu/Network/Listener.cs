using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace at_work_abidar_sbu
{
    class Listener
    {
        private const int port = 4446;

        public void startListener()
        {
            bool done = false;

            UdpClient listener = new UdpClient(port);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Parse("192.168.1.255"), port);

            try
            {
                while (!done)
                {
                    Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref groupEP);
                    String s = "";//Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        Console.Write(" "+(char)bytes[i]);
                    }

                    Console.WriteLine("Received broadcast from {0} :\n {1}\n, size : {2}",
                        groupEP.ToString(),s,
                   //     ,
                        bytes.Length);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
            }
        }
    }
}
