using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seed_DL;
using System.Data;

namespace Seed_BL
{
    public class AOBAL
    {
        AODAL objAO = new AODAL();


        public DataTable GetSeedAllotment(string year, string season,  string crop, string cv)
        {
            return objAO.GetSeedAllotment(year, season,crop,cv);
        }


        public DataTable GetSeedAllotmentDistrict(string year, string season, string dist)
        {
            return objAO.GetSeedAllotmentDistrict(year, season, dist);
        }

        public DataTable InsertSeedAllotmentMandal(string year, string season, string crop, int cv, string dist, string mand, string alloted, string user, int aid)
        {
            return objAO.InsertSeedAllotmentMandal(year, season, crop, cv, dist, mand, alloted, user,aid);
        }


        public DataTable GetSeedAllotmentMandal(string year, string season, string crop, string dist)
        {
            return objAO.GetSeedAllotmentMandal(year, season,crop,dist);
        }


        public DataTable DeletSeedAllotmentMandal(string spstkid, string qty, string allotid)
        {
            return objAO.DeletSeedAllotmentMandal(spstkid,qty,allotid);
        }


        public DataTable UpdateSeedAllotmentMandal(string aid, string qty, string updated, string spstkid)
        {
            return objAO.UpdateSeedAllotmentMandal(aid,qty,updated,spstkid);
        }



        public DataTable GetSeedAllotmentMandals(string year, string season, string dist, string mand)
        {
            return objAO.GetSeedAllotmentMandals(year, season,dist, mand);
        }


        public DataTable GetSeedAllotmentCropWiseFreezed(string year, string season, string crop, string dist)
        {
            return objAO.GetSeedAllotmentCropWiseFreezed(year, season, crop, dist);
        }

        public DataTable GetMaxAllotemnt(string year, string season, string c, string spcode)
        {
            return objAO.GetMaxAllotemnt(year,season,c,spcode);
        }


        public DataTable GetSeedAllotmentDistrictCropWsFreezed(string year, string season, string crop)
        {
            return objAO.GetSeedAllotmentDistrictCropWsFreezed(year, season, crop);
        }


        public DataTable GetSeedAllotmentCropWise(string year, string season, string crop, string dist)
        {
            return objAO.GetSeedAllotmentCropWise(year, season, crop, dist);
        }

        public DataTable GetSeedAllotmentMandWise(string year, string season, string dist, string mandal)
        {
            return objAO.GetSeedAllotmentMandWise(year, season, dist, mandal);
        }

        public DataTable GetSeedAllotmentMandWiseFrrezed(string year, string season, string dist, string mandal)
        {
            return objAO.GetSeedAllotmentMandWiseFrrezed(year, season, dist, mandal);
        }

        public DataTable FreezeAllotment(DataTable Dt)
        {
            return objAO.FreezeAllotment(Dt);
        }

        public DataTable AddRep(string state, string dist, string mand, string sp, string user, string active, string name, string desig, string mobile, string addedby)
        {
            return objAO.AddRep(state, dist, mand, sp, user, active, name, desig, mobile, addedby);
        }

        public DataTable GetRep(string state, string dist, string mand)
        {
            return objAO.GetRep(state, dist, mand);
        }

        public DataTable GetRepDetails(string repid)
        {
            return objAO.GetRepDetails(repid);
        }
        public DataTable UpdateRep(string state, string dist, string mand, string active, string name, string desig, string mobile, string sp, string repid, string user)
        {
            return objAO.UpdateRep(state, dist, mand,active,name,desig,mobile,sp,repid,user);
        }

        public DataTable DeleteRep(string repid)
        {
            return objAO.DeleteRep(repid);
        }

        public DataTable InsertSeedAllotmentSP(string spstkid, string spcode, string alloted, string user, string agency, string year, string season, string crop, string dist, string mand)
        {
            return objAO.InsertSeedAllotmentSP(spstkid, spcode, alloted, user, agency, year, season, crop, dist, mand);
        }

         public DataTable UpdateSeedAllotmentSP(string old, string updated, string spstkid, string allotid)
        {
             return objAO.UpdateSeedAllotmentSP(old,updated,spstkid,allotid);
         }


         public DataTable DeleteSeedAllotmentSP(string allotid, string qty,string sptkid)
         {
             return objAO.DeleteSeedAllotmentSP(allotid, qty, sptkid);
         }

         public DataTable GetSeedAllotmentSP(string year, string season, string dist, string mand)
         {
             return objAO.GetSeedAllotmentSP(year, season, dist, mand);
         }

         public DataTable GetCropsMandalWise(string district, string mandal)
         {
             return objAO.GetCropsMandalWise(district, mandal);
         }
         public DataTable GetCropsMandalWisenew(string district, string mandal,string cropcodes)
         {
             return objAO.GetCropsMandalWisenew(district, mandal, cropcodes);
         }
         public DataTable GetDistrictsAcordingtoLogin(string Dist)
         {
             return objAO.GetDistrictsAcordingtoLogin(Dist);
         }

         public string GetSeasonbyMonth(string month)
         {
             return objAO.GetSeasonbyMonth(month);
         }

         public DataTable GetNewMandals(string newdistcode)
         {
             return objAO.GetNewMandals(newdistcode);
         }

         public DataTable GetNewVillages(string newdistcode, string newmandcode)
         {
             return objAO.GetNewVillages(newdistcode, newmandcode);
         }
    }
}
