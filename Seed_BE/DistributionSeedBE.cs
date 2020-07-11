using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seed_BE
{
   public class DistributionSeedBE
    {
       public string permitno { get; set; }
       public string cropname { get; set; }
       public string cropVname { get; set; }
       public string crop { get; set; }
       public string cropV { get; set; }
        //public int SeedQty_Requirement { get; set; }
        //public decimal Extent { get; set; }
        //public int SeedQty_Requested { get; set; }
        public int SeedQty_Issued { get; set; }
        public string ActualRate { get; set; }
        public string SubsidyRate { get; set; }
        public string year { get; set; }
        public string season { get; set; }
        public string farmerid { get; set; }
        public string farmerNm { get; set; }
        public string fatherNm { get; set; }
        public string spcode { get; set; }
        public string stockAvalbl { get; set; }
    }
}
