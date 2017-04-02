using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace at_work_abidar_sbu.AI.ObjectDetection
{
    class DetectedObject
    {
        private Rectangle bound;

        private String lable;

        public DetectedObject()
        {
        }

        public DetectedObject(Rectangle bound, string lable)
        {
            this.bound = bound;
            this.lable = lable;
        }

        public Rectangle Bound
        {
            get { return bound; }
            set { bound = value; }
        }

        public string Lable
        {
            get { return lable; }
            set { lable = value; }
        }
    }
}
