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
    public partial class ViewStats : Form
    {
        public ViewStats()
        {
            InitializeComponent();
        }

        private void tblHarvestsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tblHarvestsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mrAppleDataSet1);

        }

        private void ViewStats_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mrAppleDataSet1.TblHarvests' table. You can move, or remove it, as needed.
            this.tblHarvestsTableAdapter.Fill(this.mrAppleDataSet1.TblHarvests);

        }
    }
}
