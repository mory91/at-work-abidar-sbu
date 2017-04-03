using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace at_work_abidar_sbu.Network
{
    class NetworkListener
    {
        TcpClient tcpclnt = new TcpClient();
        private readonly log4net.ILog log =
    log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private String host = "";
        private int port = 15000;
        public NetworkListener(String host,int port)
        {
            Thread thread = new Thread(loop);
            this.host = host;
            this.port = port;
        }

        public Action<dynamic> MessageHandler { set; get; }

        private void loop()
        {


            do
            {
                try
                {
                    log.Info("Trying to Connect To " + host + ":" + port);
                    tcpclnt.Connect(host, port);
                    log.Info("Connected");

                }
                catch (SocketException e)
                {
                    log.Error(e);
                    Thread.Sleep(1000);                       
                }
                
            } while (!tcpclnt.Connected);
                
            Stream stm = tcpclnt.GetStream();

            while (tcpclnt.Connected)
            {
                byte[] bb = new byte[1000];
                int k = stm.Read(bb, 0, 100);
                string response = "";
                for (int i = 0; i < k; i++)
                    response += (Convert.ToChar(bb[i]));

                dynamic dyn = JsonConvert.DeserializeObject(response);
                var o = Newtonsoft.Json.JsonConvert.DeserializeObject(Convert.ToString(dyn)); ;
                
                log.Info("Message of Type:"+(string)o["type"]);
            }
       }

        ~NetworkListener()
        {
            tcpclnt.Close();
        }
    }
}
