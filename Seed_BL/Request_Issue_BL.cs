using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Seed_DL;
using Seed_BE;

/// <summary>
/// Summary description for Request_Issue_BL
/// </summary>
/// 
namespace Seed_BL
{
    public class Request_Issue_BL
    {
        Request_IssueDL objDL = new Request_IssueDL();
        
        public DataTable getCropDetailsBAL(Request_IssueBE objBE)
        {
            return objDL.getCropDetailsDAL(objBE);
        }

        public DataTable InsertFarmerDetailsBAL(Request_IssueBE ObjBE)
        {
            return objDL.InsertFarmerDetailsDAL(ObjBE);
        }

        public DataTable InsertSeedRequestDtlsBAL(DataTable DtSeedReq,string farmer,string FinYear , string SeasonName,string sp)
        {
            return objDL.InsertSeedRequestDtlsDAL(DtSeedReq,farmer, FinYear, SeasonName,sp);
        }
        public DataTable getCropExtentBAL(string CropCode, string Extent)
        {
            return objDL.getCropExtentDAL(CropCode,  Extent);
        }


         public DataTable getStockDetails(string year, string season, Int64 sp)
        {
            return objDL.getStockDetails(year, season, sp);
         }

         public DataTable CheckEligibilty(string fid,string khatano)
         {
             return objDL.CheckEligibilty(fid,khatano);
         }

         public DataTable InsertDetails(string farmerid, string adhar, string padhar, string gender, string caste, string survey, string pnm, string relation, string pmobile, string mobile, string type, string acno, string bank, string branch, string ifsc)
         {
             return objDL.InsertDetails(farmerid, adhar, padhar, gender, caste, survey, pnm, relation, pmobile, mobile, type, acno, bank, branch, ifsc);
         }

         public DataTable CheckAdhar(string adhar)
         {
             return objDL.CheckAdhar(adhar);
         }
    }
}