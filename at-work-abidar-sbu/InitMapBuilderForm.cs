﻿using System;
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
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                string json = sr.ReadToEnd();
                var settings = new JsonSerializerSettings();
                settings.TypeNameHandling = TypeNameHandling.Objects;
                Map map = JsonConvert.DeserializeObject<Map>(json, settings);
                MapBuilderForm mp = new MapBuilderForm(map);
                mp.Show();
                sr.Close();
                this.Close();
            }
        }
    }
}
