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
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;

 

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

            //Getting DataList from Orchard Manager
            List<Tree> trees = this.om.GetTrees();

            foreach (var tree in trees)   //Code from Microsoft Teams
            {

                dt.Rows.Add(tree.GetTreeID(), tree.GetTreeBlock(), tree.GetTreeRow(), tree.GetTreeNo(), tree.GetDatePlanted());

            }
            //Fill Datatable
            dv = new DataView(dt);
            PopulateListViewTrees(dv);

            rbnHarvest.Checked = true;

          

            


        }
        //Fill Listview from dataviwew
        private void PopulateListViewTrees(DataView dv)
        {
            lvwTrees.Items.Clear();
            foreach (DataRow row in dv.ToTable().Rows)
            {
                lvwTrees.Items.Add(new ListViewItem(new String[] {row[0].ToString(), row[1].ToString(), row[2].ToString(),
                    row[3].ToString(), row[4].ToString() }));
            }
        }
        private void PopulateListViewThinning(DataView dv)
        {
            lvwHarvest.Items.Clear();
            foreach (DataRow row in dv.ToTable().Rows)
            {
                lvwHarvest.Items.Add(new ListViewItem(new String[] {row[0].ToString(), row[1].ToString(), row[2].ToString(),
                    row[3].ToString() }));
            }
        }
        private void PopulateListViewHarvest(DataView dv)
        {
            lvwHarvest.Items.Clear();
            foreach (DataRow row in dv.ToTable().Rows)
            {
                lvwHarvest.Items.Add(new ListViewItem(new String[] {row[0].ToString(), row[1].ToString() }));
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
            if(lvwTrees.FocusedItem != null)
            {

                if (rbnHarvest.Checked == true)
                {
                    connectionString = ConfigurationManager.ConnectionStrings["Orchard_CSD_Lvl_3.Properties.Settings.MrAppleConnectionString"].ConnectionString;

                    con = new SqlConnection(connectionString);
                    con.Open();
                    cmd = new SqlCommand($"INSERT INTO TblHarvests (TreeId, HarvestDate, HarvestCount) VALUES ({treeID}, @HarvestDate, @HarvestCount)", con);


                    cmd.Parameters.AddWithValue("@HarvestDate", dtpHarvestDate.Text);
                    cmd.Parameters.AddWithValue("@HarvestCount", nudApplesCount.Value);
                    cmd.ExecuteNonQuery();

                    con.Close();

                    this.om.ClearData();
                    this.om.LoadData(connectionString);

                    //Getting DataList from Orchard Manager
                    List<Harvest> harvests = this.om.GetTree(treeID).GetHarvests();

                    //MessageBox.Show($"number of harvests {harvests.Count}");

                    dt2.Rows.Clear();

                    foreach (var harvest in harvests)   //Code from Microsoft Teams
                    {
                        if (harvest.GetHarvestDate().Year != 1)
                        {
                            dt2.Rows.Add(harvest.GetHarvestDate().Year + "", harvest.GetHarvestCount());

                        }

                    }

                    //Fill Datatable
                    dv2 = new DataView(dt2);
                    lvwHarvest.Items.Clear();
                    PopulateListViewHarvest(dv2);


                }
                else
                {
                    connectionString = ConfigurationManager.ConnectionStrings["Orchard_CSD_Lvl_3.Properties.Settings.MrAppleConnectionString"].ConnectionString;

                    con = new SqlConnection(connectionString);
                    con.Open();
                    cmd = new SqlCommand($"INSERT INTO TblHarvests (TreeId, ThinDate, BeforeThinCount, AfterThinCount) VALUES ({treeID}, @ThinDate, @BeforeThinCount, @AfterThinCount)", con);

                    cmd.Parameters.AddWithValue("@ThinDate", dtpThinningDate.Text);
                    cmd.Parameters.AddWithValue("@BeforeThinCount", nudBeforeThinning.Value);
                    cmd.Parameters.AddWithValue("@AfterThinCount", nudAfterThinning.Value);

                    cmd.ExecuteNonQuery();
                    
                    con.Close();

                    this.om.ClearData();
                    this.om.LoadData(connectionString);

                    //Getting DataList from orchard Manager
                    List<Harvest> harvests = this.om.GetTree(treeID).GetHarvests();

                    dt2.Rows.Clear();

                    foreach (var harvest in harvests)   //Code from Microsoft Teams
                    {

                        dt2.Rows.Add(harvest.GetThinningBeforeCount(), harvest.GetThinningAfterCount(), harvest.CountDifference(), harvest.GetThinningDate().Year + "");

                    }
                    //Fill Datatable
                    dv2 = new DataView(dt2);
                    lvwHarvest.Items.Clear();
                    PopulateListViewThinning(dv2);
                }

                dt2.Rows.Clear();

                    
                
            }
            else
            {
                MessageBox.Show("Please select a Tree");
            }
            //string query2 = "INSERT INTO TblHarvests(ThinDate, BeforeThinCount, AfterCount) VALUES (@BeforeThinCount, @AfterThinCount, @HarvestCount, " + dtpThinningDate.Value.ToString("dd-MM-yyyy", DateTimeFormatInfo.InvariantInfo) + dtpHarvestDate.Value.ToString("dd-MM-yyyy", DateTimeFormatInfo.InvariantInfo);
            //using (connection = new SqlConnection(connectionString))
            //using (SqlCommand command = new SqlCommand(query2, connection))
            //{
            //    connection.Open();

            //    command.Parameters.AddWithValue("@TreeNum", nudAfterThinning.Value);
            //    command.Parameters.AddWithValue("@TreeRow", nudBeforeThinning.Value);


            //}


            //string query = "Update a.TreeID FROM tblHarvest a" + "WHERE b.TreeID = @TreeID";




        }





        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchBlock_TextChanged(object sender, EventArgs e)
        {
            //filters out ints - Aplhabetical and blank characters accepted
            //restrict search button function until a valid value is entered


            Regex regex = new Regex("^[a-zA-Z]+$");
            if (regex.IsMatch(txbSearchBlock.Text) && txbSearchBlock.Text.Length <= 1)
            //&& (      
            {

                btnSearchTree.Enabled = true;



            }
           

            else if (txbSearchBlock.Text != "")
            {
                btnSearchTree.Enabled = false;
                
                
                MessageBox.Show("only use one alphabetical character");

                //nudSearchTreeRow.Enabled = false;
                //btnSearchTree.Enabled = false;

            }

            //txbSearchBlock.Text = String.Empty;
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(nudSearchTreeNum.Value) != 0)
            {

                btnSearchTree.Enabled = true;
            }

            else
            {

                btnSearchTree.Enabled = false;
            }
        }

        private void rbnThinning_CheckedChanged(object sender, EventArgs e)
        {


            //if (rbnHarvest.Checked == true)
            //{

            //    //Listview Properties
            //    lvwHarvest.View = View.Details;
            //    lvwHarvest.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            //    lvwHarvest.Columns.Clear();

            //    //Add Columns
            //    lvwHarvest.Columns.Add("Harvest Date", 67);
            //    lvwHarvest.Columns.Add("Harvest Count", 67);




            //    //Initialise Datatable and add Columns
            //    dt2 = new DataTable();
            //    dt2.Columns.Add("Harvest Date");
            //    dt2.Columns.Add("Harvest Count");






            //    dtpHarvestDate.Visible = true;
            //    lblAppleCount.Visible = true;
            //    nudApplesCount.Visible = true;
            //    lblHarvestDate.Visible = true;

            //    dtpThinningDate.Visible = false;
            //    lblBeforeThinning.Visible = false;
            //    lblThinningDate.Visible = false;
            //    lblAfterThinning.Visible = false;
            //    nudBeforeThinning.Visible = false;
            //    nudAfterThinning.Visible = false;

            //}
            //else
            //{
            //    //Listview Properties
            //    lvwHarvest.View = View.Details;
            //    lvwHarvest.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            //    lvwHarvest.Columns.Clear();

            //    //Add Columns
            //    lvwHarvest.Columns.Add("Thinning Count Before", 67);
            //    lvwHarvest.Columns.Add("Thinning Count After", 67);
            //    lvwHarvest.Columns.Add("Count Difference", 67);
            //    lvwHarvest.Columns.Add("Thinning Date", 67);



            //    //Initialise Datatable and add Columns
            //    dt2 = new DataTable();
            //    dt2.Columns.Add("Thinning Count Before");
            //    dt2.Columns.Add("Thinning Count After");
            //    dt2.Columns.Add("Count Difference");
            //    dt2.Columns.Add("Thinning Date");




            //    dtpHarvestDate.Visible = false;
            //    lblAppleCount.Visible = false;
            //    nudApplesCount.Visible = false;
            //    lblHarvestDate.Visible = false;

            //    dtpThinningDate.Visible = true;
            //    lblBeforeThinning.Visible = true;
            //    lblAfterThinning.Visible = true;
            //    nudBeforeThinning.Visible = true;
            //    nudAfterThinning.Visible = true;
            //    lblThinningDate.Visible = true;
            //}






        }

        private void dtpHarvestDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rbnHarvest_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("changed");
            //lvwHarvest.Columns.Clear();

            if (rbnHarvest.Checked == true)
            {
               
                //Listview Properties
                lvwHarvest.View = View.Details;
                lvwHarvest.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                lvwHarvest.Columns.Clear();

                //Add Columns
                lvwHarvest.Columns.Add("Harvest Date", 90);
                lvwHarvest.Columns.Add("Harvest Count", 90);




                //Initialise Datatable and add Columns
                dt2 = new DataTable();
                dt2.Columns.Add("Harvest Date");
                dt2.Columns.Add("Harvest Count");



              
               

                dtpHarvestDate.Visible = true;
                lblAppleCount.Visible = true;
                nudApplesCount.Visible = true;
                lblHarvestDate.Visible = true;

                dtpThinningDate.Visible = false;
                lblBeforeThinning.Visible = false;
                lblThinningDate.Visible = false;
                lblAfterThinning.Visible = false;
                nudBeforeThinning.Visible = false;
                nudAfterThinning.Visible = false;

                //Getting DataList from Orchard Manager
                List<Harvest> harvests = this.om.GetTree(treeID).GetHarvests();

                //MessageBox.Show($"number of harvests {harvests.Count}");

                foreach (var harvest in harvests)   //Code from Microsoft Teams
                {
                    if (harvest.GetHarvestDate().Year != 1)
                    {
                        dt2.Rows.Add(harvest.GetHarvestDate().Year + "", harvest.GetHarvestCount());

                    }

                }

                //Fill Datatable
                dv2 = new DataView(dt2);
                PopulateListViewHarvest(dv2);

            }
            else
            {
                //Listview Properties
                lvwHarvest.View = View.Details;
                lvwHarvest.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                lvwHarvest.Columns.Clear();

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




                dtpHarvestDate.Visible = false;
                lblAppleCount.Visible = false;
                nudApplesCount.Visible = false;
                lblHarvestDate.Visible = false;

                dtpThinningDate.Visible = true;
                lblBeforeThinning.Visible = true;
                lblAfterThinning.Visible = true;
                nudBeforeThinning.Visible = true;
                nudAfterThinning.Visible = true;
                lblThinningDate.Visible = true;

                //Getting DataList from orchard Manager
                List<Harvest> harvests = this.om.GetTree(treeID).GetHarvests();

                foreach (var harvest in harvests)   //Code from Microsoft Teams
                {

                    dt2.Rows.Add(harvest.GetThinningBeforeCount(), harvest.GetThinningAfterCount(), harvest.CountDifference(), harvest.GetThinningDate().Year + "");

                }
                //Fill Datatable
                dv2 = new DataView(dt2);
                PopulateListViewThinning(dv2);
            }


        }

        private void nudSearchTreeRow_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(nudSearchTreeRow.Value) != 0)
            {

                btnSearchTree.Enabled = true;




            }

            else
            {

                btnSearchTree.Enabled = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lvwHarvest.Clear();
            lvwTrees.Clear();

            

            this.Hide();
            Home newform = new Home(om);
            newform.ShowDialog();
        }

        private void lvwTrees_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt2.Rows.Clear(); 

            if (lvwTrees.SelectedItems.Count > 0)
            {
                treeID = Convert.ToInt32(lvwTrees.SelectedItems[0].Text);
            }

            //MessageBox.Show("" + treeID + $"\n{ this.om.GetTree(treeID).GetHarvests().Count}");

            if (rbnHarvest.Checked == true)
            {
                //Getting DataList from Orchard Manager
                List<Harvest> harvests = this.om.GetTree(treeID).GetHarvests();

                //MessageBox.Show($"number of harvests {harvests.Count}");

                foreach (var harvest in harvests)   //Code from Microsoft Teams
                {
                    if (harvest.GetHarvestDate().Year != 1)
                    {
                        dt2.Rows.Add(harvest.GetHarvestDate().Year + "", harvest.GetHarvestCount());
                    }
                    

                }

                //Fill Datatable
                dv2 = new DataView(dt2);
                PopulateListViewHarvest(dv2);

            }
            else
            {

                //Getting DataList from orchard Manager
                List<Harvest> harvests = this.om.GetTree(treeID).GetHarvests();

                foreach (var harvest in harvests)   //Code from Microsoft Teams
                {

                    dt2.Rows.Add(harvest.GetThinningBeforeCount(), harvest.GetThinningAfterCount(), harvest.CountDifference(), harvest.GetThinningDate().Year + "");

                }
                //Fill Datatable
                dv2 = new DataView(dt2);
                PopulateListViewThinning(dv2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dv.RowFilter = "";
            //MessageBox.Show(nudSearchTreeRow.Value+"");
            //search listviewbox via Tree Block txtbox
            if (!txbSearchBlock.Equals("") && txbSearchBlock.Text.Length == 1)
            {
                dv.RowFilter += string.Format("(Block Like '{0}')", txbSearchBlock.Text); // Code from https://www.youtube.com/watch?v=cycavkXug5U
                
            }
            //PopulateListView(dv);

            if (nudSearchTreeRow.Value != 0)
            {
                if (dv.RowFilter == "")
                    dv.RowFilter += string.Format("(Row Like '{0}')", nudSearchTreeRow.Text);
                else
                    dv.RowFilter += string.Format("AND (Row Like '{0}')", nudSearchTreeRow.Text);
                //MessageBox.Show("blah");


            }
            //PopulateListView(dv);

            if (nudSearchTreeNum.Value != 0)
            {
                if (dv.RowFilter == "")
                    dv.RowFilter += string.Format("(Number Like '{0}')", nudSearchTreeNum.Text);
                else
                    dv.RowFilter += string.Format("AND (Number Like '{0}')", nudSearchTreeNum.Text);

            }
            PopulateListViewTrees(dv);

            //dv.RowFilter = string.Format("Block Like '%{0}%'", filterTxt);


        }

        private void nudApplesCount_ValueChanged(object sender, EventArgs e)
        {
            CheckInput();
        }

        private void nudAfterThinning_ValueChanged(object sender, EventArgs e)
        {
            CheckInput();
        }

        private void nudBeforeThinning_ValueChanged(object sender, EventArgs e)
        {
            CheckInput();
        }





        private void CheckInput()
        {
            if (rbnHarvest.Checked == true)
            {
                if (nudApplesCount.Value != 0)
                {
                    btnUpdateApple.Enabled = true;
                }

                else
                {
                    btnUpdateApple.Enabled = false;
                }
            }

            else
            {
                if (Convert.ToInt32(nudBeforeThinning.Value) != 0 && Convert.ToInt32(nudAfterThinning.Value) != 0)
                {
                    btnUpdateApple.Enabled = true;
                }
                else
                {
                    btnUpdateApple.Enabled = false;
                }

            }
        }

        private void lvwTrees_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //if (lvwTrees.SelectedItems.Count > 0)
            //{
            //    treeID = Convert.ToInt32(lvwTrees.SelectedItems[0].Text);
            //}

            ////MessageBox.Show("" + treeID + $"\n{ this.om.GetTree(treeID).GetHarvests().Count}");

            //if (rbnHarvest.Checked == true)
            //{
            //    //Getting DataList from Orchard Manager
            //    List<Harvest> harvests = this.om.GetTree(treeID).GetHarvests();

            //    //MessageBox.Show($"number of harvests {harvests.Count}");

            //    foreach (var harvest in harvests)   //Code from Microsoft Teams
            //    {

            //        dt2.Rows.Add(harvest.GetHarvestDate().Year + "", harvest.GetHarvestCount());

            //    }

            //    //Fill Datatable
            //    dv2 = new DataView(dt2);
            //    PopulateListViewHarvest(dv2);

            //}
            //else
            //{

            //    //Getting DataList from orchard Manager
            //    List<Harvest> harvests = this.om.GetTree(treeID).GetHarvests();

            //    foreach (var harvest in harvests)   //Code from Microsoft Teams
            //    {

            //        dt2.Rows.Add(harvest.GetThinningBeforeCount(), harvest.GetThinningAfterCount(), harvest.CountDifference(), harvest.GetThinningDate().Year + "");

            //    }
            //    //Fill Datatable
            //    dv2 = new DataView(dt2);
            //    PopulateListViewThinning(dv2);
            //}
        }
    }




}
