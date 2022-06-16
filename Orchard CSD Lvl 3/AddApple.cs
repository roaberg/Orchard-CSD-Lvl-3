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
          




            //DateTime dt = DateTime.ParseExact(dtpDatePlanted.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //string datePlanted = dt.ToString("yyyy/MM/dd");
            //INSERT INTO TblTree(TreeNum, TreeRow, TreeBlock, DatePlanted)VALUES(1, 1, 1, '2018/12/17')
            string query2 = "INSERT INTO TblTree(TreeNum, TreeRow, TreeBlock,DatePlanted) VALUES (@TreeNum, @TreeRow,'" + this.cbxblock.Text + "', '"+dtpDatePlanted.Value.ToString("dd-MM-yyyy", DateTimeFormatInfo.InvariantInfo) +"')";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();
                
                command.Parameters.AddWithValue("@TreeNum", nudNumber.Value);
                command.Parameters.AddWithValue("@TreeRow", nudRow.Value);
                //command.Parameters.AddWithValue("@DatePlanted", dtpDatePlanted.Text);
                
                //MessageBox.Show(query2);
                int numRows = command.ExecuteNonQuery();
                connection.Close();

                //MessageBox.Show($"Number of rows: {numRows}");

                if (numRows != 0 )
                {
                    MessageBox.Show("Tree successfully added");
                }
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
