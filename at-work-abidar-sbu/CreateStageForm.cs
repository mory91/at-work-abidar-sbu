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
    public partial class CreateStageForm : Form
    {
		public PathFinder pathFinder;
        public Map map;
        public double scalex, scaley;
        public CreateStageForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Stage stage = new Stage();
            stage.start = new Point(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
            stage.width = Double.Parse(textBox5.Text);
            stage.height = Double.Parse(textBox4.Text);
			pathFinder.addObstacle(stage.start.X, stage.start.Y, (int)stage.width, (int)stage.height);
            stage.scalex = scalex;
            stage.scaley = scaley;
            stage.name = textBox3.Text;
            map.obstacles.Add(stage);
            this.Close();
        }
    }
}
