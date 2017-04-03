using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace remote_control
{
    public partial class Main : Form
    {
        private Connection conn;

        public Main()
        {
            InitializeComponent();
            conn = new Connection();
            conn.StartListening();
        }

        private void sendbnt_Click(object sender, EventArgs e)
        {
            string json = new JavaScriptSerializer().Serialize(new
            {
                type = "bnt",
                destination = durationbnt.Text,
                duration = this.orientbnt.Text,
                orientation = this.destbnt.Text
            });
            conn.sendMsg(Encoding.ASCII.GetBytes(json));
        }

        private void sendbmt_Click(object sender, EventArgs e)
        {
            string json = new JavaScriptSerializer().Serialize(new
            {
                type = "bmt",
                container = containerbmt.Text,
                source = sourcebmt.Text,
                destination = destbmt.Text,
                object_list = listbmt.Text,
                final = finalbmt.Text
            });
            conn.sendMsg(Encoding.ASCII.GetBytes(json));
        }

        private void sendbtt_Click(object sender, EventArgs e)
        {
            string json = new JavaScriptSerializer().Serialize(new
            {
                type = "btt",
                objectbtt = objectbtt.Text,
                quantity = quantitybtt.Text,
                destination = destinationbtt.Text,
                source = sourcebtt.Text,
                container = containerbtt.Text
            });
            conn.sendMsg(Encoding.ASCII.GetBytes(json));
        }
    }
}

