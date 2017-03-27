using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using FTD2XX_NET;
using at_work_abidar_sbu.HardwareInterface;

namespace at_work_abidar_sbu
{
    public partial class MotorControlForm : Form
    {
        MotorControl motor = new MotorControl();
        CentralBoard board = new CentralBoard();
        Thread UpdateView;
        delegate void SetTextCallback(string text);

        public MotorControlForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            this.Focus();
            this.KeyPreview = true;
            if (motor.IsRunning())
            {
                startBtn.Enabled = false;
                stopBtn.Enabled = true;
                UpdateView = new Thread(new ThreadStart(UpdateSpeedEncoder));
                UpdateView.Start();
            }
            else
            {
                startBtn.Enabled = true;
                stopBtn.Enabled = false;
            }

            board.SetIRSensor(CentralBoard.IR.Front);
        }

        private void UpdateSpeedEncoder()
        {
            while (motor.IsRunning())
            {
                SetFrontLeftEncoder(motor.EncodersValue[(int)MotorControl.Motors.FrontLeft].ToString());
                SetFrontRightEncoder(motor.EncodersValue[(int)MotorControl.Motors.FrontRight].ToString());
                SetRearLeftEncoder(motor.EncodersValue[(int)MotorControl.Motors.RearLeft].ToString());
                SetRearRightEncoder(motor.EncodersValue[(int)MotorControl.Motors.RearRight].ToString());

                SetFrontLeftSpeed((128 - motor.MotorSpeed[(int)MotorControl.Motors.FrontLeft]).ToString());
                SetFrontRightSpeed((128 - motor.MotorSpeed[(int)MotorControl.Motors.FrontRight]).ToString());
                SetRearLeftSpeed((motor.MotorSpeed[(int)MotorControl.Motors.RearLeft] - 128).ToString());
                SetRearRightSpeed((motor.MotorSpeed[(int)MotorControl.Motors.RearLeft] - 128).ToString());


                for(int i = 0; i < 8;i++)
                {
                    Console.Write(board.GetIRValue(i));
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (!motor.IsRunning())
            {
                motor.Start();
                UpdateView = new Thread(new ThreadStart(UpdateSpeedEncoder));
                UpdateView.Start();
                board.Start();
                startBtn.Enabled = false;
                stopBtn.Enabled = true;
            }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            if(motor.IsRunning())
            {
                motor.Stop();
                startBtn.Enabled = true;
                stopBtn.Enabled = false;
                vTextBox.Text = "0";
                wTextBox.Text = "0.0";
            }
        }

        private void MotorControlForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            int speed = int.Parse(vTextBox.Text);
            float w = float.Parse(wTextBox.Text);

            if (motor.IsRunning())
            {
                if (e.KeyChar == 'w' || e.KeyChar == 'W')
                {
                    speed++;
                    vTextBox.Text = speed.ToString();
                }
                if (e.KeyChar == 's' || e.KeyChar == 'S')
                {
                    speed--;
                    vTextBox.Text = speed.ToString();
                }
                if (e.KeyChar == 'a' || e.KeyChar == 'A')
                {
                    w -= 0.1f;
                    wTextBox.Text = w.ToString();
                }
                if (e.KeyChar == 'd' || e.KeyChar == 'D')
                {
                    w += 0.1f;
                    wTextBox.Text = w.ToString();
                }
            }
        }

        #region SafeWindowControllSetter

        private void SetFrontLeftSpeed(string speed)
        {
            if (this.frontLeftSpeedtxt.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetFrontLeftSpeed);
                this.Invoke(d, new object[] { speed });
            }
            else
                this.frontLeftSpeedtxt.Text = speed;
        }
        private void SetFrontLeftEncoder(string encoder)
        {
            if (this.frontLeftEncodertxt.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetFrontLeftEncoder);
                this.Invoke(d, new object[] { encoder });
            }
            else
                this.frontLeftEncodertxt.Text = encoder;
        }

        private void SetFrontRightSpeed(string speed)
        {
            if (this.frontRightSpeedtxt.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetFrontRightSpeed);
                this.Invoke(d, new object[] { speed });
            }
            else
                this.frontRightSpeedtxt.Text = speed;
        }
        private void SetFrontRightEncoder(string encoder)
        {
            if (this.frontRightEncodertxt.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetFrontRightEncoder);
                this.Invoke(d, new object[] { encoder });
            }
            else
                this.frontRightEncodertxt.Text = encoder;
        }

        private void SetRearLeftSpeed(string speed)
        {
            if (this.rearLeftSpeedtxt.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetRearLeftSpeed);
                this.Invoke(d, new object[] { speed });
            }
            else
                this.rearLeftSpeedtxt.Text = speed;
        }
        private void SetRearLeftEncoder(string encoder)
        {
            if (this.rearLeftEncodertxt.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetRearLeftEncoder);
                this.Invoke(d, new object[] { encoder });
            }
            else
                this.rearLeftEncodertxt.Text = encoder;
        }

        private void SetRearRightSpeed(string speed)
        {
            if (this.rearRightSpeedtxt.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetRearRightSpeed);
                this.Invoke(d, new object[] { speed });
            }
            else
                this.rearRightSpeedtxt.Text = speed;
        }
        private void SetRearRightEncoder(string encoder)
        {
            if (this.rearRightEncodertxt.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetRearRightEncoder);
                this.Invoke(d, new object[] { encoder });
            }
            else
                this.rearRightEncodertxt.Text = encoder;
        }

        #endregion
    }
}
