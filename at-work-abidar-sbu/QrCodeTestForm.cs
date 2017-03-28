using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace at_work_abidar_sbu
{
    public partial class QrCodeTestForm : Form
    {
        public QrCodeTestForm()
        {
            InitializeComponent();
        }

		private void button1_Click(object sender, EventArgs e)
		{
			// create a barcode reader instance
			IBarcodeReader reader = new BarcodeReader();
			// load a bitmap
			var barcodeBitmap = (Bitmap)Bitmap.FromFile(textBox1.Text);
			// detect and decode the barcode inside the bitmap
			var result = reader.Decode(barcodeBitmap);
			// do something with the result
			if (result != null)
			{
				textBox3.Text = result.BarcodeFormat.ToString();
				textBox2.Text = result.Text;
			}
			else
			{
				textBox3.Text = ":|";
				textBox2.Text = ":|";
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				textBox1.Text = openFileDialog1.FileName;
				pictureBox1.Load(textBox1.Text);
			}
		}
	}
}
