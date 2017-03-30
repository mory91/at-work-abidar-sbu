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
        public Map map;
        public CreateStageForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            MapObject stage = new MapObject(WordObjectType.Stage, nameTextBox.Text, Double.Parse(xTextBox.Text), 
                Double.Parse(yTextBox.Text), Int32.Parse(widthTextBox.Text), Int32.Parse(heightTextBox.Text));

        //    pathFinder.addObstacle((int) stage.X, (int) stage.Y, (int)stage.Width, (int)stage.Height);
            map.obstacles.Add(stage);
            this.Close();
        }
    }
}
