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
using System.Text.RegularExpressions;
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
        private DataTable dt2;
        private DataView dv;  
        private DataView dv2;
        private static int treeID = -1;
        private object filterTxt;

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
            lvwTrees.Columns.Add("ID", 67);
            lvwTrees.Columns.Add("Block", 67);
            lvwTrees.Columns.Add("Row", 67);
            lvwTrees.Columns.Add("Number", 67);
            lvwTrees.Columns.Add("Date Planted", 78);


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

        public AddHarvest()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Orchard_CSD_Lvl_3.Properties.Settings.MrAppleConnectionString"].ConnectionString;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAppleEnter_Click(object sender, EventArgs e)
        {
            string query2 = "INSERT INTO TblHarvests(ThinDate, BeforeThinCount, AfterCount) VALUES (@BeforeThinCount, @AfterThinCount, @HarvestCount, " + dtpThinningDate.Value.ToString("dd-MM-yyyy", DateTimeFormatInfo.InvariantInfo) + dtpHarvestDate.Value.ToString("dd-MM-yyyy", DateTimeFormatInfo.InvariantInfo);
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
            //filters out ints - Aplhabetical and blank characters accepted
            //restrict search button function until a valid value is entered

            Regex regex = new Regex("^[a-zA-Z]+$");
            if (regex.IsMatch(txbSearchBlock.Text) || txbSearchBlock.Text == "")
            {
                if (txbSearchBlock.Text == "")
                {
                    
                    btnSearchTree.Enabled = false;
                }

                else
                {
                    
                    btnSearchTree.Enabled = true;
                }


            }
            else
            {
                MessageBox.Show("only alphabetical characters");

                txbSearchBlock.Text = "";
                //nudSearchTreeRow.Enabled = false;
                //btnSearchTree.Enabled = false;

            }

        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(nudSearchTreeNum.Text) != 0)
            //{

            //    btnSearchTree.Enabled = false;
            //}

            //else
            //{

            //    btnSearchTree.Enabled = true;
            //}
        }

        private void rbnThinning_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnThinning.Checked == true)
            {
                dtpThinningDate.Visible = true;
                lblBeforeThinning.Visible = true;
                lblAfterThinning.Visible = true;
                nudBeforeThinning.Visible = true;
                nudAfterThinning.Visible = true;
                lblThinningDate.Visible = true;
            }
            else
            {
                dtpThinningDate.Visible = false;
                lblBeforeThinning.Visible = false;
                lblThinningDate.Visible = false;
                lblAfterThinning.Visible = false;
                nudBeforeThinning.Visible = false;
                nudAfterThinning.Visible = false;
            }

            if (rbnThinning.Checked == true)
            {
                
            }




            }

        private void dtpHarvestDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rbnHarvest_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnHarvest.Checked == true)
            {
                dtpHarvestDate.Visible = true;
                lblAppleCount.Visible = true;
                nudApplesCount.Visible = true;
                lblHarvestDate.Visible = true;

            }
            else
            {
                dtpHarvestDate.Visible = false;
                lblAppleCount.Visible = false;
                nudApplesCount.Visible = false;
                lblHarvestDate.Visible = false;
            }


        }

        private void nudSearchTreeRow_ValueChanged(object sender, EventArgs e)
        {
            //if (Convert.ToInt32 (nudSearchTreeRow.Value) != 0)
            //{

            //    btnSearchTree.Enabled = false;
            //}

            //else
            //{

            //    btnSearchTree.Enabled = true;
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home newform = new Home(om);
            newform.ShowDialog();
        }

        private void lvwTrees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvwTrees.SelectedItems.Count > 0)
            {
                treeID = Convert.ToInt32(lvwTrees.SelectedItems[0].Text);
            }
        
            MessageBox.Show("" + treeID);

            //Listview Properties
            lvwHarvest.View = View.Details;
            lvwHarvest.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            //Add Columns
            lvwHarvest.Columns.Add("Thinning Count Before", 67);
            lvwHarvest.Columns.Add("Thinning Count After", 67);
            lvwHarvest.Columns.Add("Count Difference", 67);
            lvwHarvest.Columns.Add("Thinning Date", 67);



            //Initialise Datatable and add Columns
            dt2 = new DataTable();
            dt2.Columns.Add("Thinning Count Before");
            dt2.Columns.Add("Thinning Count After");
            dt2.Columns.Add("Count Difference");
            dt2.Columns.Add("Thinning Date");


            //Getting DataList from Rider Manager
            List<Harvest> harvests = this.om.GetTree(treeID).GetHarvests();

            foreach (var harvest in harvests)   //Code from Microsoft Teams
            {

                dt2.Rows.Add(harvest.GetThinningBeforeCount(), harvest.GetThinningAfterCount(), harvest.CountDifference(), harvest.GetThinningDate().Year+"");

            }
            //Fill Datatable
            dv2 = new DataView(dt2);
            PopulateListView(dv2);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //MessageBox.Show(nudSearchTreeRow.Value+"");
            //search listviewbox via Tree Block txtbox
            if (!txbSearchBlock.Equals("") && txbSearchBlock.Text.Length == 1)
                
            {
                
                dv.RowFilter = string.Format("Block Like '{0}'", txbSearchBlock.Text); // Code from https://www.youtube.com/watch?v=cycavkXug5U
                
            }
            //PopulateListView(dv);

            if (nudSearchTreeRow.Value != 0)
            {
                //MessageBox.Show("blah");
                dv.RowFilter = string.Format("Row Like '{0}'", nudSearchTreeRow.Text);

            }
            //PopulateListView(dv);

            if (nudSearchTreeNum.Value != 0)
            {
                dv.RowFilter = string.Format("Number Like '{0}'", nudSearchTreeNum.Text);

            }
            PopulateListView(dv);

            //dv.RowFilter = string.Format("Block Like '%{0}%'", filterTxt);


        }
    }
}
