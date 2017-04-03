using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace at_work_abidar_sbu.HardwareInterface
{
    class IMU
    {
        private SerialPort serial;
        private const string COMPort = "COM4";
        private const int BaudRate = 115200;
        private Thread DataRequester;
        private float degree;
        private bool running;

        public IMU()
        {
            serial = new SerialPort(COMPort, BaudRate);
            serial.Open();
            serial.DataReceived += Serial_DataReceived;
            degree = 0;
        }

        ~IMU()
        {
            serial.Close();
        }

        private void RequestData()
        {
            string Request = ":1\n";
            while(running)
            {
                serial.Write(Request);
                Thread.Sleep(100);
            }
        }

        public void Start()
        {
            if (!running)
            {
                degree = 0;
                DataRequester = new Thread(new ThreadStart(RequestData));
                running = true;
                DataRequester.Start();
            }
        }

        public void Stop()
        {
            running = false;
        }

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string Received = serial.ReadLine();
            Monitor.Enter(degree);
            degree = float.Parse(Received.Split(',')[2]);
            degree = (float)(degree * 360 / Math.PI);
            Monitor.Exit(degree);
        }

        public float GetDegree()
        {
            Monitor.Enter(degree);
            var res = degree;
            Monitor.Exit(degree);
            return res;
        }
    }
}
