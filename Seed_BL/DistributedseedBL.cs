using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Seed_BE;
using Seed_DL;


namespace Seed_BL
{
    public class DistributedseedBL
    {
        DistributedseedDL objdl = new DistributedseedDL();

        public DataTable GetPrice(string permit)
        {
            return objdl.GetPrice(permit);
        }

        public DataTable GetPermitData(string pno,string sp)
        {
            return objdl.GetPermitData(pno,sp);
        }
        public DataTable InsertSeed(DataTable dt, string permit)
        {
            DistributedseedDL dds = new DistributedseedDL();
            return dds.InsertSeedRequestDtlsDAL(dt, permit);
        }
        public DataTable Getdistributedseedet(DistributionSeedBE obj, string permit)
        {
            DistributedseedDL dds = new DistributedseedDL();
            return dds.Distributedseeddata(obj,permit);
        }
        public DataTable InsertSeedDistribution(DataTable Dt, string year, string season, string farmer_id, string sp_code, string permit)
        {
            return objdl.InsertSeedDistribution(Dt,year, season, farmer_id, sp_code,permit);
        }

        public DataTable GetPurchaseReceipt(string permit, string sp_code,string adhar)
        {
            return objdl.GetPurchaseReceipt(permit, sp_code,adhar);
        }

        public DataTable GetPriceLabels(string year, string season, string crop, string cv)
        {
            return objdl.GetPriceLabels(year, season, crop, cv);
        }
    }
}
