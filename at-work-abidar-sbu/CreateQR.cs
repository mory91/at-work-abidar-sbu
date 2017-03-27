using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace at_work_abidar_sbu
{
    public partial class CreateQR : Form
    {
        public Map map;
        public double scalex, scaley;
        public CreateQR()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QR qr = new QR();
            qr.start = new Point(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
            qr.scalex = scalex;
            qr.scaley = scaley;
            map.obstacles.Add(qr);
            this.Close();
        }
    }
}
