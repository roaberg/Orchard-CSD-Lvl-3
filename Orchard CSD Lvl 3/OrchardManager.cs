using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orchard_CSD_Lvl_3
{
    public class OrchardManager
    {
        private List<Tree> trees = new List<Tree>();

        public OrchardManager()
        {



        }

        public void LoadData(string constring)
        {

            using (SqlConnection myConnection = new SqlConnection(constring))
            {
                string queryString = "Select * from TblTree";
                SqlCommand cmd = new SqlCommand(queryString, myConnection);
 
                myConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //MessageBox.Show(reader["DatePlanted"].ToString());

                        trees.Add(new Tree(Convert.ToInt32(reader["TreeID"].ToString()), Convert.ToInt32(reader["TreeNum"].ToString()), Convert.ToInt32(reader["TreeRow"].ToString()), reader["TreeBlock"].ToString().ToCharArray()[0], Convert.ToDateTime(reader["DatePlanted"].ToString())));
                        
                    }

                    myConnection.Close();
                }
            }
        }

        public void SetTrees(List<Tree> trees)
        {
            this.trees = trees;

        }

        public List<Tree> GetTrees()
        {
            return trees;
        }
    }


}
