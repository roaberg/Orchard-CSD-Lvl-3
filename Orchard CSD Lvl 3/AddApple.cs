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
    public partial class AddApple : Form
    {
        SqlConnection connection;
        string connectionString;

        public AddApple()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Orchard_CSD_Lvl_3.Properties.Settings.MrAppleConnectionString"].ConnectionString;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void nudRow_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.ParseExact(dtpDatePlanted.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            
            string datePlanted = dt.ToString("yyyy/MM/dd");
            //INSERT INTO TblTree(TreeNum, TreeRow, TreeBlock, DatePlanted)VALUES(1, 1, 1, '2018/12/17')
            string query = "INSERT INTO TblTree VALUES ('@TreeNum, @TreeRow,'" + this.cbxblock.Text + "','"+datePlanted+"')";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                
                command.Parameters.AddWithValue("@TreeNum", nudNumber.Value);
                command.Parameters.AddWithValue("@TreeRow", nudRow.Value);
               
                //MessageBox.Show(query);
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 newform = new Form1();
            newform.ShowDialog();

        }
    }
}
