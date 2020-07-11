using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seed_DL;
using System.Data;


namespace Seed_BL
{

    public class MasterBAL
    {


        MasterDAL objDist = new MasterDAL();
        /*INSERT DIST*/
        public DataTable getInsertDistBAL(string StateCode, string Dcode, string DistName)
        {
            return objDist.insertDisttDAL(StateCode, Dcode, DistName);
        }
        /*VIEW DIST*/
        public DataTable viewdataBAL(string StateCode)
        {
            return objDist.viewdataDAL(StateCode);
        }
        /*UPDATE DIST*/
        public DataTable UpdateDistBAL(string StateCode, string DistCode, string DistName)
        {
            return objDist.UpdateDistDAL(StateCode, DistCode, DistName);
        }

        /*Delete District*/
        public DataTable DeletedistrictBAL(string statecode, string distcode, string distname)
        {


            return objDist.DeletedistrictDAL(statecode, distcode, distname);
        
        }

        /*Delete Mandal*/
        public DataTable DeletemandalBAL(string distcode, string mndcode, string mndname)
        {

            return objDist.DeletemandalDAL(distcode, mndcode, mndname);
        
        }

        public DataTable GetNewDitricts(string StateCode)
        {
            return objDist.GetNewDitricts(StateCode);
        }

        public DataTable GetNewMandals(string dist)
        {
            return objDist.GetNewMandals(dist);
        }

        public DataTable getdist(string StateCode)
        {
            return objDist.viewdataDAL(StateCode);
        }
        public DataTable BindMnadalBAL(string DistCode)
        {
            return objDist.BindMnadalDAL(DistCode);
        }
        /*INSERT Mandal*/
        public DataTable InsertMandalBAL(string DistCode, string Mcode, string MandalName, string INSERT)
        {
            return objDist.insertMandaltDAL(DistCode, Mcode, MandalName, INSERT);
        }
        /* Upadate Mandal*/
        public DataTable UpdateMandalBAL(string DistCode, string MandalCode, string MandalName, string INSERT)
        {
            return objDist.UpdateMandaltDAL(DistCode, MandalCode, MandalName, INSERT);
        }
        /*INSERT CROP*/
        public DataTable getInsertCropBAL(string CropName, string type, string no_of_acres, string qty, string packsize, int slno, string seedrate, string INSERT)
        {
            return objDist.getInsertCropDAL(CropName, type, no_of_acres, qty, packsize, slno, seedrate, INSERT);
        }
        /*VIEW Crop*/
        public DataTable viewdCropBAL()
        {
            return objDist.viewCropDAL();
        }
        /*UPDATECrop*/
        public DataTable UpdateCropBAL(string CropName, string type, string no_of_acres, string qty, string packsize, int slno, string seedrate, string cropcode, string UPDATE)
        {
            return objDist.UpdateCropDAL(CropName,type,no_of_acres,qty,packsize,slno,seedrate,cropcode,UPDATE);
        }
        /* Delete Crop */
        public DataTable DeleteCropBAL(string CropCd, string Delete)
        {

            return objDist.DeleteCropDAL(CropCd,  Delete);

        }

        /*INSERT CROPV*/
        public DataTable getInsertCropVBAL(string CropCd, string CropVName, string user, int company, string INSERT)
        {
            return objDist.getInsertCropVDAL(CropCd, CropVName,user,company, INSERT);
        }
        /*UPDATECropV*/
        public DataTable UpdateCropVBAL(string CropCd, string CropVCd, string CropVName, string user, int company, string UPDATE)
        {
            return objDist.UpdateCropVDAL(CropCd, CropVCd, CropVName,user,company, UPDATE);
        }
        /* Delete Crop variety */
        public DataTable DeleteCropVBAL(string CropVCd, string CropVName, string Delete)
        {
            return objDist.DeleteCropVDAL(CropVCd, CropVName, Delete);
        }
       
        /* INSERT SalesPoint*/
        public DataTable InsertSalePointBAL(string StateCode, string DistCode, string Mcode, string SalePointName, string INSERT, string username, int Active, string incharge, string mobile, string inchSco,string usrsp)
        {
            return objDist.insertSalePontDAL(StateCode, DistCode, Mcode, SalePointName, INSERT, username, Active,incharge,mobile,inchSco,usrsp);
        }
        /* Update SalesPoint*/
        public DataTable UpdateSalepoint(string StateCode, string DistCode, string mcode, string salepointname, string username, int Active, string update, string spcode, string inchargeagri, string mobile, string inchSoc)
        {
            return objDist.UpdateSalepoint(StateCode, DistCode, mcode, salepointname, username, Active, update, spcode, inchargeagri, mobile, inchSoc);
        }
        /* Delete SalesPoint*/
        public DataTable DltSalesPoint(string salepoint, string delete)
        {
            return objDist.DeleteSalepoint(salepoint, delete);
        }
        public DataTable viewdCroplistBAL(string Cpcode)
        {
            return objDist.viewCroplistDAL(Cpcode);
        }
       
        public DataTable viewDistdataBAL(string DistCode)
        {
            return objDist.viewDistdataDAL(DistCode);
        }
        public DataTable viewSalesPointdataBAL(string DistCode, string Mcode)
        {
            return objDist.viewSalesPointdataDAL(DistCode, Mcode);
        }




        public DataTable InsertCompany(string name, DateTime date, int ActiveSt, string UserName)
        {
            return objDist.InsertCompany(name, date, ActiveSt, UserName);
        }

        public DataTable UpdateCompany(string name, DateTime date, int ActiveSt, string companyid, string UserName)
        {
            return objDist.UpdateCompany(name, date, ActiveSt, companyid, UserName);
        }

        public DataTable DeleteCompany(string companyid)
        {
            return objDist.DeleteCompany(companyid);
        }

        public DataTable GetCompany()
        {
            return objDist.GetCompany();
        }

        public DataTable GetCrops()
        {
            return objDist.GetCrops();
        }

       

        public DataTable GetSalepoints(string StateCode, string DistCode, string mand)
        {
            return objDist.GetSalepoints(StateCode, DistCode, mand);
        }

        public DataTable getAgencies(string state)
        {
            return objDist.getAgencies(state);
        }

        public DataTable GetCropsCompanyWise(string company)
        {
            return objDist.GetCropsCompanyWise(company);
        }
        public DataTable viewCroplistCompanyWise(string Cpcode, string company)
        {
            return objDist.viewCroplistCompanyWise(Cpcode, company);
        }


        public DataTable getPackSize(string Cpcode)
        {
            return objDist.getPackSize(Cpcode);
        }
    }
}
