using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seed_DL;
using System.Data;

namespace Seed_BL
{
    public class ReportsBL
    {
        ReportsDL ObjDL = new ReportsDL();

        public DataTable generatePermitBAL(string FarmerId , string FinYear , string SeasonName,string Permit)
        {
            return ObjDL.generatePermitDAL(FarmerId, FinYear, SeasonName,Permit);
        }

        public DataTable GetAllotmentDistWise(string year, string seasson, string crop)
        {
            return ObjDL.GetAllotmentDistWise(year, seasson, crop);
        }

        public DataTable GetAllotmentMandWise(string year, string seasson, string crop, string dist)
        {
            return ObjDL.GetAllotmentMandWise(year, seasson, crop, dist);
        }

        public DataTable GetAllotmentSPWise(string year, string seasson, string crop, string dist, string mand)
        {
            return ObjDL.GetAllotmentSPWise(year, seasson, crop, dist, mand);
        }

        public DataTable GetAllSalePoints()
        {
            return ObjDL.GetAllSalePoints();
        }

        public DataTable GetAllSalePointsInDistrict(string dist)
        {
            return ObjDL.GetAllSalePointsInDistrict(dist);
        }

        public DataTable GetCount(string action)
        {
            return ObjDL.GetCount(action);
        }

        public DataTable GetCropReport(string FinYear, string SeasonName, string crop, string cv)
        {
            return ObjDL.GetCropReport(FinYear, SeasonName, crop, cv);
        }


        public DataTable GetFarmers(string FinYear, string SeasonName, string dist, string mand)
        {
            return ObjDL.GetFarmers(FinYear, SeasonName, dist, mand);
        }

        public DataTable GetSalePoints()
        {
            return ObjDL.GetSalePoints();
        }

        public DataTable GetSalePointsDist(string dist)
        {
            return ObjDL.GetSalePointsDist(dist);
        }


        public DataTable GetSalePointsMand(string dist, string mand)
        {
            return ObjDL.GetSalePointsMand(dist, mand);
        }

        public DataTable GetAllSalePointsInDist(string dist)
        {
            return ObjDL.GetAllSalePointsInDist(dist);
        }

        public DataTable GetSaleInfoBAL(string FinYear, string SeasonName, String sp)
        {
            return ObjDL.GetSaleInfo(FinYear, SeasonName,sp);
        }
        public DataTable GetPermits_SPWiseBAL(string FinYear, string SeasonName, string SpCode)
        {
            return ObjDL.GetPermits_SPWiseDAL(FinYear, SeasonName, SpCode);
        }


        public DataTable GetPermits_All(string FinYear, string SeasonName)
        {
            return ObjDL.GetPermits_All(FinYear, SeasonName);
        }

        public DataTable GetPermits_MandWS(string FinYear, string SeasonName, string DistCode)
        {
            return ObjDL.GetPermits_MandWS(FinYear, SeasonName, DistCode);

        }
        public DataTable GetPermits_SpWs(string FinYear, string SeasonName, string DistCode, string mandal)
        {
            return ObjDL.GetPermits_SpWs(FinYear, SeasonName, DistCode, mandal);
        }
        public DataTable GetPermits_SpWsAllBL(string FinYear, string SeasonName, string DistCode, string mandal, string SalPoint)
        {
            return ObjDL.GetPermits_SpWsAllDL(FinYear, SeasonName, DistCode, mandal, SalPoint);
        }




        public DataTable GetPermits_DtWise(string sp, DateTime fromdt, DateTime todt)
        {
            return ObjDL.GetPermits_DtWise(sp, fromdt, todt);
        }

        public DataTable GetDistributionDtWs(string sp, DateTime fromdt, DateTime todt)
        {
            return ObjDL.GetDistributionDtWs(sp, fromdt, todt);
        }

        public DataTable GetreportDistributionMandWise(string year, string season, string distcode)
        {
            return ObjDL.GetreportDistributionMandWise(year, season, distcode);
        }
        public DataTable GetreportDistrbutionSPWise(string year, string season, string distcode, string mandalcode)
        {
            return ObjDL.GetreportDistrbutionSPWise(year, season, distcode, mandalcode);
        }

        public DataTable GetDailyReport(string FinYear, string SeasonName, string crop, string date)
        {
            return ObjDL.GetDailyReport(FinYear, SeasonName,crop,date);
        }


        public DataTable GetDistWsAllReport(string FinYear, string SeasonName)
        {
            return ObjDL.GetDistWsAllReport(FinYear, SeasonName);
        }

        public DataTable GetCropWsAbstract(string FinYear, string SeasonName)
        {
            return ObjDL.GetCropWsAbstract(FinYear, SeasonName);
        }
        //24102017
        public DataTable Getreportsalepointwisefarmerdetails(string salepoint, string yearcode, string seasoncode)
        {
            return ObjDL.Getreportsalepointwisefarmerdetails(salepoint, yearcode, seasoncode);
        }




        public DataTable GetDistributionDetailsDistWs(string FinYear, string SeasonName, string crop)
        {
            return ObjDL.GetDistributionDetailsDistWs(FinYear, SeasonName, crop);
        }
        public DataTable GetDistributionDetailsmandalWs(string FinYear, string SeasonName, string crop,string districtcd)
        {
            return ObjDL.GetDistributionDetailsmandalWs(FinYear, SeasonName, crop, districtcd);
        }
        public DataTable GetDistributionDetailsfarmerWs(string FinYear, string SeasonName, string crop, string districtcd, string castcd, string gender)
        {
            return ObjDL.GetDistributionDetailsfarmerWs(FinYear, SeasonName, crop, districtcd, castcd, gender);
        }
        public DataTable GetDistributionMandalWsFarmerDetails(string FinYear, string SeasonName, string crop, string districtcd,string mandcd, string castcd, string gender)
        {
            return ObjDL.GetDistributionMandalWsFarmerDetail(FinYear, SeasonName, crop, districtcd, mandcd, castcd, gender);
        }

        public DataTable GetDistributionDet_Mandal_SpWs(string FinYear, string SeasonName, string crop, string districtcd, string mandcd)
        {
            return ObjDL.GetDistributionDet_Mandal_SpWs(FinYear, SeasonName, crop, districtcd, mandcd);
        }
        public DataTable GetDistributionSalePointWsFarmerDetails(string FinYear, string SeasonName, string crop, string districtcd, string mandcd, string castcd, string gender,string salepointcd)
        {
            return ObjDL.GetDistributionSalePointWsFarmerDetails(FinYear, SeasonName, crop, districtcd, mandcd, castcd, gender, salepointcd);
        }


        public DataTable GetDistributionDistWs(string FinYear, string SeasonName)
        {
            return ObjDL.GetDistributionDistWs(FinYear, SeasonName);
        }
    }
}
