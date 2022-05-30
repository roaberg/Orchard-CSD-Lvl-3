using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchard_CSD_Lvl_3
{
    class Harvest
    {
        //properties
        private DateTime harvestDate;
        private int thinningCountBefore;
        private int thinningCountAfter;
        private DateTime thinningDate;
        private int finalHarvestCount;

        public Harvest()
        {

        }

        public int CountDifference()
        {
            return thinningCountBefore  - thinningCountAfter;
        }

        public void SetHarvestDate(DateTime harvestDate)
        {
            this.harvestDate = harvestDate;
        }

        public void SetThinningCountBefore(int thinningCountBefore)
        {
            this.thinningCountBefore = thinningCountBefore;
        }
        public void SetThinningCountAfter(int thinningCountAfter)
        {
            this.thinningCountAfter = thinningCountAfter;
        }

        public void SetThinningDate(DateTime thinningDate)
        {
            this.thinningDate = thinningDate;


        }

        public void SetFinalHarvestCount(int finalHarvestCount)
        {
            this.finalHarvestCount = finalHarvestCount;
        }
    
        public int GetFinalHarvestCount()
        {
            return finalHarvestCount;
        }
    }   

}
