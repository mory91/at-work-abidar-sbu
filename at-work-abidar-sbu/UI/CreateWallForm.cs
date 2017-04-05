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
        public CreateWallForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x1 = Double.Parse(X1TextBox.Text);
            var y1 = Double.Parse(Y1TextBox.Text);

            var x2 = Double.Parse(X2TextBox.Text);
            var y2 = Double.Parse(Y2TextBox.Text);
            MapObject wall = new MapObject(WorldObjectType.Wall,x1,y1,(int) (x2-x1)+1,(int) (y2-y1)+1);
//            pathFinder.addObstacle(wall.start.X, wall.start.Y, wall.end.X - wall.start.X + 1, wall.end.Y - wall.start.Y + 1);
            map.obstacles.Add(wall);
            this.Close();
        }

        private void CreateWallForm_Load(object sender, EventArgs e)
        {

        }
    }
}
