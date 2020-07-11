using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Seed_BE;
/// <summary>
/// Summary description for Request_IssueDL
/// </summary>
/// 
namespace Seed_DL
{
    public class Request_IssueDL
    {
        public DataTable getCropDetailsDAL(Request_IssueBE ObjBE)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Insert_GetCropDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = ObjBE.DistCode;
                    da.SelectCommand.Parameters.Add("@MandCode", SqlDbType.VarChar).Value = ObjBE.MandCode;
                    da.SelectCommand.Parameters.Add("@VillCode", SqlDbType.VarChar).Value = ObjBE.VillCode;
                    da.SelectCommand.Parameters.Add("@KhataNo", SqlDbType.VarChar).Value = ObjBE.KhataNo;
                    da.SelectCommand.Parameters.Add("@FinYear", SqlDbType.VarChar).Value = ObjBE.FinYear;
                    da.SelectCommand.Parameters.Add("@SeasonName", SqlDbType.NVarChar).Value = ObjBE.SeasonName;
                    da.SelectCommand.Parameters.Add("@FarmerName", SqlDbType.NVarChar).Value = ObjBE.Farmer_Name;
                    da.SelectCommand.Parameters.Add("@FatherName", SqlDbType.NVarChar).Value = ObjBE.Father_Name;
                    da.SelectCommand.Parameters.Add("@adhar", SqlDbType.NVarChar).Value = ObjBE.AadharNo;
                    da.SelectCommand.Parameters.Add("@CropDtls", SqlDbType.Structured).Value = ObjBE.CropDetails_KhataWs;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
       

        public DataTable InsertFarmerDetailsDAL(Request_IssueBE ObjBE)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("InsertFarmerData", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = ObjBE.DistCode;
                    da.SelectCommand.Parameters.Add("@MandCode", SqlDbType.VarChar).Value = ObjBE.MandCode;
                    da.SelectCommand.Parameters.Add("@VillCode", SqlDbType.VarChar).Value = ObjBE.VillCode;
                    da.SelectCommand.Parameters.Add("@KhataNo", SqlDbType.VarChar).Value = ObjBE.KhataNo;
                    da.SelectCommand.Parameters.Add("@FinYear", SqlDbType.VarChar).Value = ObjBE.FinYear;
                    da.SelectCommand.Parameters.Add("@SeasonName", SqlDbType.NVarChar).Value = ObjBE.SeasonName;
                    da.SelectCommand.Parameters.Add("@FarmerName", SqlDbType.NVarChar).Value = ObjBE.Farmer_Name;
                    da.SelectCommand.Parameters.Add("@FarmerType", SqlDbType.NVarChar).Value = ObjBE.Farmer_Type;
                    da.SelectCommand.Parameters.Add("@FatherName", SqlDbType.NVarChar).Value = ObjBE.Father_Name;
                    da.SelectCommand.Parameters.Add("@adhar", SqlDbType.NVarChar).Value = ObjBE.AadharNo;
                    da.SelectCommand.Parameters.Add("@surveyno", SqlDbType.NVarChar).Value = ObjBE.surveynos;
                    da.SelectCommand.Parameters.Add("@extent", SqlDbType.NVarChar).Value = ObjBE.extent;
                    da.SelectCommand.Parameters.Add("@caste", SqlDbType.NVarChar).Value = ObjBE.Caste;
                    da.SelectCommand.Parameters.Add("@gender", SqlDbType.NVarChar).Value = ObjBE.Gender;
                    da.SelectCommand.Parameters.Add("@acno", SqlDbType.NVarChar).Value = ObjBE.acno;
                    da.SelectCommand.Parameters.Add("@bank", SqlDbType.NVarChar).Value = ObjBE.bank;
                    da.SelectCommand.Parameters.Add("@branch", SqlDbType.NVarChar).Value = ObjBE.branch;
                    da.SelectCommand.Parameters.Add("@ifsc", SqlDbType.NVarChar).Value = ObjBE.ifsc;
                    da.SelectCommand.Parameters.Add("@mobile", SqlDbType.NVarChar).Value = ObjBE.mobile;

                    da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = ObjBE.personName;
                    da.SelectCommand.Parameters.Add("@padhar", SqlDbType.NVarChar).Value = ObjBE.personAdhar;
                    da.SelectCommand.Parameters.Add("@relation", SqlDbType.NVarChar).Value = ObjBE.relation;
                    da.SelectCommand.Parameters.Add("@pmobile", SqlDbType.NVarChar).Value = ObjBE.personMobile;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable InsertSeedRequestDtlsDAL(DataTable DtSeedReq,string farmer,string FinYear , string SeasonName,string sp)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedIssual", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@sr", SqlDbType.Structured).Value = DtSeedReq;
                    da.SelectCommand.Parameters.Add("@farmerid", SqlDbType.VarChar).Value = farmer;
                    da.SelectCommand.Parameters.Add("@FinYear", SqlDbType.VarChar).Value = FinYear;
                    da.SelectCommand.Parameters.Add("@SeasonName", SqlDbType.VarChar).Value = SeasonName;
                    da.SelectCommand.Parameters.Add("@salepoint", SqlDbType.VarChar).Value = sp;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable getCropExtentDAL(string CropCode,string Extent)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("CropRequirement", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = CropCode;
                    da.SelectCommand.Parameters.Add("@Extent", SqlDbType.VarChar).Value = Extent;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        

        public DataTable getStockDetails(string year, string season, Int64 sp)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Stock_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = "V";
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@spcode", SqlDbType.BigInt).Value = sp;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


     




        public DataTable CheckEligibilty(string fid,string khatano)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("CheckEligibilty", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@farmerid", SqlDbType.VarChar).Value = fid;
                    da.SelectCommand.Parameters.Add("@Khatano", SqlDbType.VarChar).Value = khatano;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable InsertDetails(string farmerid, string adhar, string padhar, string gender, string caste, string survey, string pnm, string relation, string pmobile, string mobile, string type, string acno, string bank, string branch, string ifsc)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("InertPurchaser", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@farmerid", SqlDbType.VarChar).Value = farmerid;
                    da.SelectCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = pnm;
                    da.SelectCommand.Parameters.Add("@adhar", SqlDbType.VarChar).Value = adhar;
                    da.SelectCommand.Parameters.Add("@padhar", SqlDbType.VarChar).Value = padhar;
                    da.SelectCommand.Parameters.Add("@relation", SqlDbType.VarChar).Value = relation;
                    da.SelectCommand.Parameters.Add("@mobile", SqlDbType.VarChar).Value = mobile;
                    da.SelectCommand.Parameters.Add("@pmobile", SqlDbType.VarChar).Value = pmobile;
                    da.SelectCommand.Parameters.Add("@caste", SqlDbType.VarChar).Value = caste;
                    da.SelectCommand.Parameters.Add("@gender", SqlDbType.VarChar).Value = gender;
                    da.SelectCommand.Parameters.Add("@surveynos", SqlDbType.VarChar).Value = survey;
                    da.SelectCommand.Parameters.Add("@type", SqlDbType.VarChar).Value = type;
                    da.SelectCommand.Parameters.Add("@bank", SqlDbType.VarChar).Value = bank;
                    da.SelectCommand.Parameters.Add("@branch", SqlDbType.VarChar).Value = branch;
                    da.SelectCommand.Parameters.Add("@ifsc", SqlDbType.VarChar).Value = ifsc;
                    da.SelectCommand.Parameters.Add("@acno", SqlDbType.VarChar).Value = acno;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable CheckAdhar(string adhar)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("CheckAdharNumber", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@adhar", SqlDbType.VarChar).Value = adhar;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }




       

 

 
  
 

    }
}