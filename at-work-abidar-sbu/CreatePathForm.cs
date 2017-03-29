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
	public partial class CreatePathForm : Form
    {
		public PathFinder pathFinder;
		public Map map;
		public double scalex, scaley;
        public CreatePathForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
			pathFinder.setSrc(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
			pathFinder.setDst(Int32.Parse(textBox5.Text), Int32.Parse(textBox4.Text));
			pathFinder.findPath();
			PathShape pathShape = new PathShape();
			pathShape.path = pathFinder.getPath();
			pathShape.start = new Point(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
			pathShape.scalex = scalex;
			pathShape.scaley = scaley;
			map.obstacles.Add(pathShape);
			this.Close();
        }
    }
}
