using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seed_DL;
using System.Data;
using Seed_BE;

namespace Seed_BL
{
    public class SeedAllotBL
    {

        SeedAllotDL objDist = new SeedAllotDL();

        public DataTable GetSPStockID(string year, string season, string crop, string dist, string mand)
        {
            return objDist.GetSPStockID(year, season, crop, dist, mand);
        }


        public DataTable GetSPStockLeftAtSP(string year, string season, string crop, int cv, string sp)
        {
            return objDist.GetSPStockLeftAtSP(year, season, crop, cv, sp);
        }


        public DataTable GetSalepoints(string state, string dist, string mand)
        {
            return objDist.GetSalepoints(state, dist,mand);
        }


        public DataTable InsertStock(stockBE obj)
        {
            return objDist.InsertStockDAL(obj);
        }
        public DataTable UpdateStock(string rcvd, string lrno, string stkid, string nob, string aid, string old)
        {
            return objDist.UpdateStockDAL(rcvd, lrno, stkid,nob,aid,old);
        }
        public DataTable DeleteStock(string stkid, string alloted,string allotid)
        {
            return objDist.DeleteStock(stkid,alloted,allotid);
        }
        public DataTable ViewStock(string year, string season, string c, string sp)
        {
            return objDist.ViewStock(year, season, c, sp);
        }

        public DataTable ViewStockSeasonWs(string year, string season, string sp)
        {
            return objDist.ViewStockSeasonWs(year, season, sp);
        }

        public DataTable InsertSeedAllotment(string year, string season, string crop, int cv, string dist, string alloted, string user, string agnecy)
        {
            return objDist.InsertSeedAllotment(year, season, crop, cv, dist, alloted, user,agnecy);
        }


        public DataTable InsertSeedAllotmentAny(string year, string season, string crop, string dist, string alloted, string user, string agnecy)
        {
            return objDist.InsertSeedAllotmentAny(year, season, crop, dist, alloted, user, agnecy);
        }

        public DataTable InsertSeedAllotmentAll(string year, string season, string crop, string dist, string alloted, string user, string agnecy)
        {
            return objDist.InsertSeedAllotmentALL(year, season, crop, dist, alloted, user, agnecy);
        }

        public DataTable GetSeedAllotment(string year, string season)
        {
            return objDist.GetSeedAllotment(year, season);
        }

        public DataTable DeletSeedAllotment(string allotid, string qty)
        {
            return objDist.DeletSeedAllotment(allotid,qty);
        }


        public DataTable UpdateSeedAllotment(string allotid, string updated)
        {
            return objDist.UpdateSeedAllotment(allotid, updated);
        }

        public DataTable InsertSeedAllotmentMandal(string year, string season, string crop, int cv, string dist, string mand, string alloted, string user)
        {
            return objDist.InsertSeedAllotmentMandal(year, season, crop, cv, dist, mand, alloted, user);
        }


        public DataTable InsertSeedIssual(DataTable DtSeedReq, string fid, string year, string season, string sp, string user)
        {
            return objDist.InsertSeedIssual(DtSeedReq, fid, year, season, sp,user);
        }


        public DataTable GetSeedAllotmentCropWise(string year, string season, string crop)
        {
            return objDist.GetSeedAllotmentCropWise(year, season, crop);
        }

        public DataTable GetSeedAllotmentDistWise(string year, string season, string dist)
        {
            return objDist.GetSeedAllotmentDistWise(year, season, dist);
        }

        public DataTable FreezeAllotment(DataTable Dt)
        {
            return objDist.FreezeAllotment(Dt);
        }
    }
}
