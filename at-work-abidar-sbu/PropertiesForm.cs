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
    public partial class PropertiesForm : Form
    {
        public PropertiesForm()
        {
            InitializeComponent();
        }

        private void PropertiesForm_Load(object sender, EventArgs e)
        {
            
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> property = new Dictionary<string, string>();
            foreach (DataGridViewRow  row in dataGridView1.Rows)
            {
                if(row.Cells["PropertyName"].Value != null && row.Cells["PropertyValue"].Value != null)
                    property.Add((string)row.Cells["PropertyName"].Value, (string)row.Cells["PropertyValue"].Value);       
            }
            PropertyManager.i.SaveConfig(textBox1.Text,property);
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            PropertyManager.i.Load(textBox1.Text);
            Dictionary<string, string> property = new Dictionary<string, string>();
            property = PropertyManager.i.GetConfig(textBox1.Text);

            dataGridView1.Rows.Clear();
            foreach (KeyValuePair<string, string> entry in property)
            {
                dataGridView1.Rows.Add(entry.Key, entry.Value);
            }
        }
    }
}
