using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orchard_CSD_Lvl_3
{
    public class Tree
    {
        private int treeID;
        private int treeNo;
        private int treeRow;
        private char treeBlock;
        private DateTime datePlanted;

        private List<Harvest> harvests = new List<Harvest>();

        public Tree(int tID, int tNo, int tRow, char tBlock, DateTime datePlanted)
        {
            treeID = tID;
            treeNo = tNo;
            treeRow = tRow;
            treeBlock = tBlock;
            this.datePlanted = datePlanted;

            //MessageBox.Show($"{treeID} {treeNo} {treeRow} {treeBlock} {datePlanted.ToString()}");
        }

        public int GetTreeID()
        {
            return treeID;
        }
        public int GetTreeNo()
        {
            return treeNo;
        }

        public int GetTreeRow()
        {
            return treeRow;
        }

        public char GetTreeBlock()
        {
            return treeBlock;
        }

        public string GetDatePlanted()
        {
            return ""+ datePlanted.Year;
        }


        public decimal HarvestAvg()
        {
            double sumHarvestCount = 0;
            foreach (Harvest harvest in harvests)
            {
                sumHarvestCount += harvest.GetFinalHarvestCount();
            }

            return Convert.ToDecimal(Math.Round(sumHarvestCount / harvests.Count, 2));

        }





    }

        
}
