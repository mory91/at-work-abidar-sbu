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
		public PathFinder pathFinder;
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
			pathFinder.addObstacle(wall.start.X, wall.start.Y, wall.end.X - wall.start.X + 1, wall.end.Y - wall.start.Y + 1);
			wall.scalex = scalex;
            wall.scaley = scaley;
            map.obstacles.Add(wall);
            this.Close();
        }
    }
}
