using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using at_work_abidar_sbu.AI.Navigation;

namespace at_work_abidar_sbu
{
	public partial class CreatePathForm : Form
    {
		public PathFinder pathFinder;
		public Map map;
        PathShape pathShape = new PathShape();
        public CreatePathForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
//            pathFinder.LoadInMap(map);
//            pathFinder.setSrc(Int32.Parse(srcXTextBox.Text), Int32.Parse(srcYTextBox.Text));
//			pathFinder.setDst(Int32.Parse(dstXtextBox.Text), Int32.Parse(dstYTextBox.Text));
//            
//            pathFinder.findPath();
//			pathShape.path = pathFinder.getPath();
//			pathShape.start = new Point(Int32.Parse(srcXTextBox.Text), Int32.Parse(srcYTextBox.Text));
//            //	map.obstacles.Add(pathShape);
			Close();
        }
    }
}
