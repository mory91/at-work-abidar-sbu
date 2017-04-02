using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using at_work_abidar_sbu.AI.Navigation;
using at_work_abidar_sbu.GraphicUtils;
using Newtonsoft.Json;

namespace at_work_abidar_sbu
{
    public partial class MapBuilderForm : Form
    {
		PathFinder pathFinder;
        double scalex, scaley;
        private double height, width;
        private Map map;
        Bitmap res;
        PathShape path;
        public MapBuilderForm(double x, double y)
        {
            InitializeComponent();
            width = x;
            height = y;
            res = new Bitmap((int)pictureBox1.Width, (int)pictureBox1.Height);
            scalex = res.Width / x;
            scaley = res.Height / y;
            using (Graphics grp = Graphics.FromImage(res))
            {
                grp.FillRectangle(
                    Brushes.White, 0, 0, res.Width, res.Height);
            }
            map = new Map();
            map.height = height;
            map.width = width;
            pictureBox1.Image = res;
            listBox1.DataSource = map.obstacles;
            listBox1.DisplayMember = "Name";

			pathFinder = new PathFinder();
		}
        public MapBuilderForm(Map map)
        {
            InitializeComponent();
            this.map = map;
            pictureBox1.Image = res;
            listBox1.DataSource = map.obstacles;
            listBox1.DisplayMember = "Name";
            height = map.height;
            width = map.width;
            DrawMap();
            ResetList();
        }

        private void createStage_Click(object sender, EventArgs e)
        {
            CreateStageForm cs = new CreateStageForm();
		    cs.map = map;
            cs.FormClosing += (o, form) =>
            {
                map = cs.map;
                DrawMap();
                ResetList();
            };
            cs.Show();

        }

        private void createWall_Click(object sender, EventArgs e)
        {
            CreateWallForm cg = new CreateWallForm();
		    cg.map = map;
            cg.FormClosing += (o, form) =>
            {
                map = cg.map;
                DrawMap();
        //      pictureBox1.Image = map.build(res); ;
                listBox1.DataSource = null;
                listBox1.DataSource = map.obstacles;
            };
            cg.Show();
        }

        private void DrawMap()
        {
            Renderer renderer = new Renderer();
            pictureBox1.Image = renderer.EmptyFrame(pictureBox1.Width, pictureBox1.Height, Color.White)
                .DrawMap(map)
                .DrawPath(path, map)
                .GetBitmap(); ;

        }

        private void createQR_Click(object sender, EventArgs e)
        {
            CreateQRForm qr = new CreateQRForm();
            qr.map = map;
//            qr.scalex = scalex;
//            qr.scaley = scaley;
            qr.FormClosing += (o, form) =>
            {
                map = qr.map;
                DrawMap();
                ResetList();
            };
            qr.Show();
        }

        private void ResetList()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = map.obstacles;
        }


        private void btnPath_Click(object sender, EventArgs e)
		{
			CreatePathForm createPathForm = new CreatePathForm();
			createPathForm.pathFinder = pathFinder;
			createPathForm.map = map;
			createPathForm.FormClosing += (o, form) =>
			{
				map = createPathForm.map;
			    path = new PathShape();
                
                path.path = pathFinder.getPath();
                DrawMap();
                ResetList();
            };
			createPathForm.Show();
		}

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {
            map.obstacles.RemoveAt(listBox1.SelectedIndex);
            DrawMap();
            ResetList();
        }

		private void save_Click(object sender, EventArgs e)
		{
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            map.Save(unixTimestamp+".map");
        }
    }

}
