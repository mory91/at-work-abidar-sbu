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
    public partial class CreateWallForm : Form
    {
        public Map map;
        public double scalex, scaley;
        public CreateWallForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Wall wall = new Wall();
            wall.start = new Point(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
            wall.end = new Point(Int32.Parse(textBox5.Text), Int32.Parse(textBox4.Text));
            wall.scalex = scalex;
            wall.scaley = scaley;
            map.obstacles.Add(wall);
            this.Close();
        }
    }
}
