﻿using System;
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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Orchard_CSD_Lvl_3
{
    public partial class AddApple : Form
        
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da; 

        private OrchardManager om;

        SqlConnection connection;
        string connectionString;

        public AddApple()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Orchard_CSD_Lvl_3.Properties.Settings.MrAppleConnectionString"].ConnectionString;
        
        

        
        }

        private void txbTreeBlock_TextChanged(object sender, EventArgs e)
        {
            CheckInput();
            Regex regex = new Regex("^[a-zA-Z]+$");
            if (regex.IsMatch(txbTreeBlock.Text) && txbTreeBlock.Text.Length == 1)
            {
                txbTreeBlock.BackColor = Color.White;

            }
            else
            {
                MessageBox.Show("only use one alphabetical character");

                txbTreeBlock.BackColor = Color.Red;


               
                //nudSearchTreeRow.Enabled = false;
                //btnSearchTree.Enabled = false;

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {



                connectionString = ConfigurationManager.ConnectionStrings["Orchard_CSD_Lvl_3.Properties.Settings.MrAppleConnectionString"].ConnectionString;

            con = new SqlConnection(connectionString);
            con.Open();

            cmd = new SqlCommand("INSERT INTO TblTree (TreeNum, TreeRow, TreeBlock, DatePlanted) VALUES (@TreeNum, @TreeRow, @TreeBlock, @DatePlanted)", con);
            cmd.Parameters.AddWithValue("@TreeNum", nudNumber.Value);
            cmd.Parameters.AddWithValue("@TreeRow", nudRow.Value);
            cmd.Parameters.AddWithValue("@TreeBlock", txbTreeBlock.Text);
            cmd.Parameters.AddWithValue("@DatePlanted", dtpDatePlanted.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Tree successfully added");

            



            ////DateTime dt = DateTime.ParseExact(dtpDatePlanted.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            ////string datePlanted = dt.ToString("yyyy/MM/dd");
            ////INSERT INTO TblTree(TreeNum, TreeRow, TreeBlock, DatePlanted)VALUES(1, 1, 1, '2018/12/17')
            //string query2 = "INSERT INTO TblTree(TreeNum, TreeRow, TreeBlock,DatePlanted) VALUES (@TreeNum, @TreeRow,'" + this.txbTreeBlock.Text + "', '" + dtpDatePlanted.Value.ToString("dd-MM-yyyy", DateTimeFormatInfo.InvariantInfo) + "')";
            //using (connection = new SqlConnection(connectionString))
            //using (SqlCommand command = new SqlCommand(query2, connection))
            //{
            //    connection.Open();

            //    command.Parameters.AddWithValue("@TreeNum", nudNumber.Value);
            //    command.Parameters.AddWithValue("@TreeRow", nudRow.Value);
            //    //command.Parameters.AddWithValue("@DatePlanted", dtpDatePlanted.Text);

            //    //MessageBox.Show(query2);
            //    int numRows = command.ExecuteNonQuery();
            //    connection.Close();

            //    //MessageBox.Show($"Number of rows: {numRows}");

            //    if (numRows != 0)
            //    {
            //        MessageBox.Show("Tree successfully added");
            //    }
            //}

        }
        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            CheckInput();
            if (Convert.ToInt32(nudNumber.Value) != 0)
            {
                nudNumber.BackColor = Color.White;
            }
            else
            {
                nudNumber.BackColor = Color.Red;
            } 

        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Home newform = new Home(om);
            newform.ShowDialog();

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void nudRow_ValueChanged(object sender, EventArgs e)
        {
            CheckInput();
            if (Convert.ToInt32(nudRow.Value) != 0)
            {
                nudRow.BackColor = Color.White;
            }
            else
            {
                nudRow.BackColor = Color.Red;
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CheckInput()
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
            if (Convert.ToInt32(nudNumber.Value) != 0 && regex.IsMatch(txbTreeBlock.Text) && txbTreeBlock.Text.Length == 1 && Convert.ToInt32(nudRow.Value) != 0)
            {
                btnAppleEnter.Enabled = true;
            }
            else
            {
                btnAppleEnter.Enabled = false;
            }
        }
    }
}
