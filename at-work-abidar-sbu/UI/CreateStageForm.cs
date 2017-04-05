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
            typeCombo.DataSource = Enum.GetValues(typeof(WorldObjectType));
        }
        private void button1_Click(object sender, EventArgs e)
        {

            WorldObjectType type;
            Enum.TryParse<WorldObjectType>(typeCombo.SelectedValue.ToString(), out type);
            MapObject stage = new MapObject(type, nameTextBox.Text, Double.Parse(xTextBox.Text), 
            Double.Parse(yTextBox.Text), Int32.Parse(widthTextBox.Text), Int32.Parse(heightTextBox.Text));
            //    pathFinder.addObstacle((int) stage.X, (int) stage.Y, (int)stage.Width, (int)stage.Height);

            stage.Left = leftChk.Checked;
            stage.Right = rightChk.Checked;
            stage.Up = upChk.Checked;
            stage.Down = downChk.Checked;

            map.obstacles.Add(stage);


            this.Close();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnMaxX_Click(object sender, EventArgs e)
        {
            xTextBox.Text = ((int)map.width).ToString();
        }

        private void btnMaxY_Click(object sender, EventArgs e)
        {
            yTextBox.Text = ((int)map.height).ToString();
        }

        private void btnMaxWidth_Click(object sender, EventArgs e)
        {
            widthTextBox.Text = ((int)map.width).ToString();
        }

        private void btnMaxHeight_Click(object sender, EventArgs e)
        {
            heightTextBox.Text = ((int)map.height).ToString();
        }
    }
}
