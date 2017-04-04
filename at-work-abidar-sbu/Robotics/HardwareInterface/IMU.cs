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
        private const string COMPort = "COM9";
        private const int BaudRate = 115200;
        private Thread DataRequester;
        private float degree;
        private float referenceDegree;
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
            Stop();
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
            var y = float.Parse(Received.Split(',')[2]);
//            var x = float.Parse(Received.Split(',')[1]);
//            var y = float.Parse(Received.Split(',')[2]);
//            var z = float.Parse(Received.Split(',')[3]);

//            var roll = Math.Atan2(2 * y * w - 2 * x * z, 1 - 2 * y * y - 2 * z * z);
//            var pitch = Math.Atan2(2 * x * w - 2 * y * z, 1 - 2 * x * x - 2 * z * z);
//            var yaw = Math.Atan((2 * (w * z + x * y)) /  ());
//            //Monitor.Enter(degree);
            degree = (float)y;
//            //Monitor.Exit(degree);
        }

        public float GetDegree()
        {

            return ((degree + (float)Math.PI) * 180) / (float)Math.PI;
        }

        public void SetReference()
        {
            referenceDegree = 0;
            referenceDegree = degree;
        }
    }
}
