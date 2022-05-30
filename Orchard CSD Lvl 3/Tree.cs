using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchard_CSD_Lvl_3
{
    class Tree
    {
        private int treeNo;
        private int treeRow;
        private char treeBlock;
        private DateTime datePlanted;

        private List<Harvest> harvests = new List<Harvest>();

        public Tree(int tNo, int tRow, char tBlock, DateTime datePlanted)
        {
            treeNo = tNo;
            treeRow = tRow;
            treeBlock = tBlock;
            this.datePlanted = datePlanted;
        }

        public int GetTreeNo()
        {
            return 0;
        }

        public int GetTreeRow()
        {
            return 0;
        }

        public char GetTreeBlock()
        {
            return 'a';
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
