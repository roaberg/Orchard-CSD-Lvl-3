using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orchard_CSD_Lvl_3
{
    public partial class AddHarvest : Form
    {
        SqlConnection connection;
        string connectionString;
        private OrchardManager om;
        private DataTable dt;
        private DataView dv;
        private static int TreeID = -1;

        public AddHarvest(OrchardManager om)
        {
            this.om = om;
            InitializeComponent();
            if (txbSearchBlock.Text == "") //If the Search textbox is blank then do the following
            {
                txbSearchBlock.Focus();
            }
            //Listview Properties
            lvwTrees.View = View.Details;
            lvwTrees.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            //Add Columns
            lvwTrees.Columns.Add("ID");
            lvwTrees.Columns.Add("Block");
            lvwTrees.Columns.Add("Row", 75);
            lvwTrees.Columns.Add("Number", 50);
            lvwTrees.Columns.Add("Date Planted", 75);


            //Initialise Datatable and add Columns
            dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Block");
            dt.Columns.Add("Row");
            dt.Columns.Add("Number");
            dt.Columns.Add("DatePlanted");

            //Getting DataList from Rider Manager
            List<Tree> trees = this.om.GetTrees();

            foreach (var tree in trees)   //Code from Microsoft Teams
            {

                dt.Rows.Add(tree.GetTreeID(), tree.GetTreeBlock(), tree.GetTreeRow(), tree.GetTreeNo(), tree.GetDatePlanted());

            }
            //Fill Datatable
            dv = new DataView(dt);
            PopulateListView(dv);

        }
        //Fill Listview from dataviwew
        private void PopulateListView(DataView dv)
        {
            lvwTrees.Items.Clear();
            foreach (DataRow row in dv.ToTable().Rows)
            {
                lvwTrees.Items.Add(new ListViewItem(new String[] {row[0].ToString(), row[1].ToString(), row[2].ToString(),
                    row[3].ToString(), row[4].ToString() }));
            }
        }

        //public AddHarvest()
        //{
        //    InitializeComponent();
        //    connectionString = ConfigurationManager.ConnectionStrings["Orchard_CSD_Lvl_3.Properties.Settings.MrAppleConnectionString"].ConnectionString;
        //}

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAppleEnter_Click(object sender, EventArgs e)
        {
            string query2 = "INSERT INTO TblHarvests(ThinDate, BeforeThinCount, AfterCount) VALUES (@BeforeThinCount, @AfterThinCount,', '" + dtpThinningDate.Value.ToString("dd-MM-yyyy", DateTimeFormatInfo.InvariantInfo) + "')";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@TreeNum", nudAfterThinning.Value);
                command.Parameters.AddWithValue("@TreeRow", nudBeforeThinning.Value);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchBlock_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
