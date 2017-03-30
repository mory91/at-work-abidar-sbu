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
    public partial class CreateQRForm : Form
    {
        public Map map;
        public double scalex, scaley;
        public CreateQRForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MapObject qr = new MapObject(WordObjectType.QR,Double.Parse(textBox1.Text), Double.Parse(textBox2.Text));
           
            //qr = new Point(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
            map.obstacles.Add(qr);
            this.Close();
        }
    }
}
