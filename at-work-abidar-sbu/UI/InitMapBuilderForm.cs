using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace at_work_abidar_sbu
{
    public partial class InitMapBuilderForm : Form
    {
        public InitMapBuilderForm()
        {
            InitializeComponent();
        }

        private void CreateMap_Click(object sender, EventArgs e)
        {
            MapBuilderForm mp = new MapBuilderForm(Double.Parse(width.Text), Double.Parse(height.Text));
            mp.Show();
             this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Map map = Map.Load(openFileDialog1.FileName);
                MapBuilderForm mp = new MapBuilderForm(map);
            }
        }
    }
}
