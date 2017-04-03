using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using at_work_abidar_sbu.HardwareInterface;
using System.Threading;

namespace at_work_abidar_sbu.UI
{
    public partial class IMUTest : Form
    {
        IMU imu;
        Thread ViewUpdater;
        private bool running;
        delegate void SetTextCallback(string text);

        public IMUTest()
        {
            InitializeComponent();
        }


        private void SetValue(string value)
        {
            if (this.valueLbl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetValue);
                this.Invoke(d, new object[] { value });
            }
            else
                this.valueLbl.Text = value;
        }

        private void GetData()
        {
            while (running)
            {
                SetValue(imu.GetDegree().ToString());
                Thread.Sleep(100);
            }
        }


        private void IMUTest_Load(object sender, EventArgs e)
        {
            imu = new IMU();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            imu.Start();
            ViewUpdater = new Thread(new ThreadStart(GetData));
            running = true;
            ViewUpdater.Start();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            imu.Stop();
            running = false;
            SetValue("Stopped");
        }

        private void setRefBtn_Click(object sender, EventArgs e)
        {
            imu.SetReference();
        }
    }
}
