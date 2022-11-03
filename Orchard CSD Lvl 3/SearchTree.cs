using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orchard_CSD_Lvl_3
{
    public partial class SearchTree : Form
    {
        private OrchardManager om;
        public SearchTree(OrchardManager om)
        {
            this.om = om;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home newform = new Home(om);
            newform.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home newform = new Home(om);
            newform.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
