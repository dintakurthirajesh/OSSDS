using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Seed_DL;

namespace Seed_BL
{
    public class CommonBL
    {
        CommonDL ObjDL = new CommonDL();
        public DataTable GetDistrictsByStateBAL(string StateCode)
        {
            return ObjDL.GetDistrictsByStateDAL(StateCode);
        }
        public DataTable GetMandalsByDistCodeBAL(string DistCode)
        {
            return ObjDL.GetMandalsByDistCodeDAL(DistCode);
        }
        public DataTable GetVillagesByDistMandCodeBAL(string DistCode , string MandCode)
        {
            return ObjDL.GetVillagesByDistMandCodeDAL(DistCode , MandCode);
        }


        public DataTable GetBankByStateBAL(string StateCode)
        {
            return ObjDL.GetBankByStateDAL(StateCode);
        }
    }
}
