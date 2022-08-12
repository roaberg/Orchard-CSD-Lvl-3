using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchard_CSD_Lvl_3
{
    public class Harvest
    {
        //properties
        private DateTime harvestDate;
        private int thinningCountBefore;
        private int thinningCountAfter;
        private DateTime thinningDate;


        public Harvest()
        {

        }

        public Harvest(int tCountBefore, int tCountAfter, DateTime thinningdate)
        {
            thinningCountBefore = tCountBefore;
            thinningCountAfter = tCountAfter;
            this.thinningDate = thinningdate;

            //MessageBox.Show($"{treeID} {treeNo} {treeRow} {treeBlock} {datePlanted.ToString()}");
        }


        public int CountDifference()
        {
            return thinningCountBefore  - thinningCountAfter;
        }

        public void SetHarvestDate(DateTime harvestDate)
        {
            this.harvestDate = harvestDate;
        }

        public void SetThinningCountBefore() //int thinningCountBefore)
        {
            this.thinningCountBefore = thinningCountBefore;
        }
        public void SetThinningCountAfter()//int thinningCountAfter
        {
            this.thinningCountAfter = thinningCountAfter;
        }

        public string SetThinningDate(DateTime thinningdate)
        {
            return "" + thinningdate.Year;


        }
        public int GetThinningBeforeCount()
        {
            return thinningCountBefore;
        }

        public int GetThinningAfterCount()
        {
            return thinningCountAfter;
        }
        
        public DateTime GetThinningDate()
        {
            return thinningDate;
        }
















        //public void SetFinalHarvestCount(int finalHarvestCount)
        //{
        //    this.finalHarvestCount = finalHarvestCount;
        //}
    
        //public int GetFinalHarvestCount()
        //{
        //    return finalHarvestCount;
        //}
    }   

}
