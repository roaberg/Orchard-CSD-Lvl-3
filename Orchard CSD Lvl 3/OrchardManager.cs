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
            int treeindex = 0;
            foreach(Tree tree in trees)
            {
                int foundID = tree.GetTreeID();
                string query = $"Select * from TblHarvests where TreeId = {foundID}";

                using (SqlConnection myConnection = new SqlConnection(constring))
                {
                    string queryString = query;
                    SqlCommand cmd = new SqlCommand(queryString, myConnection);

                    myConnection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())

                    {
                        if (reader.HasRows == true)
                        {
                            int HarvestCount = 1;

                            while (reader.Read())
                            {
                              




                                if (reader["HarvestDate"].ToString() == "")
                                {
                                    
                                    trees[treeindex].AddHarvest(Convert.ToInt32(reader["BeforeThinCount"].ToString()), Convert.ToInt32(reader["AfterThinCount"].ToString()), Convert.ToDateTime(reader["ThinDate"].ToString()));
                                }
                                else if (reader["ThinDate"].ToString() == "")
                                {
                                    trees[treeindex].AddHarvest(Convert.ToDateTime(reader["HarvestDate"].ToString()), Convert.ToInt32(reader["HarvestCount"].ToString()));
                                }
                                else
                                {
                                   

                                    trees[treeindex].AddHarvest(Convert.ToInt32(reader["BeforeThinCount"].ToString()), Convert.ToInt32(reader["AfterThinCount"].ToString()), Convert.ToDateTime(reader["ThinDate"].ToString()), Convert.ToDateTime(reader["HarvestDate"].ToString()), Convert.ToInt32(reader["HarvestCount"].ToString()));

                                }
                                HarvestCount++;
                            }
                       

                        }

                        myConnection.Close();
                    }
                }
                //MessageBox.Show($"Number of Harvests{trees[treeindex].GetHarvests().Count}");
                treeindex++;
            }


        }

        public void ClearData()
        {
            trees.Clear();
           
        }

        public void SetTrees(List<Tree> trees)
        {
            this.trees = trees;

        }

        public List<Tree> GetTrees()
        {
            return trees;
        }



        //public void SetHarvests(List<Harvest> harvests)
        //{
        //    this.harvests = harvests;

        //}

        public Tree GetTree(int treeId)
        {
            //MessageBox.Show($"Search Tree Id {treeId}");
            Tree tree = new Tree(-1, -1, -1, '6', new DateTime());

            foreach (Tree foundtree in trees)
            {
                //MessageBox.Show($"{treeId} : {foundtree.GetTreeID()}");
                if (treeId == foundtree.GetTreeID())
                {
                    //MessageBox.Show("tree found");
                    tree = foundtree;
                    return tree;
                }
            }

            return tree;
        }


    }







}
