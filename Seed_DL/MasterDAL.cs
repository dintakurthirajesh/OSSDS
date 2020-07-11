using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Seed_BE;

namespace Seed_DL
{
    public class MasterDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString());
        public DataTable insertDisttDAL(string StateCode, string Dcode, string DistName)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("InsertDistDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = Dcode;
                    da.SelectCommand.Parameters.Add("@DistName", SqlDbType.VarChar).Value = DistName;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetNewDitricts(string StateCode)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter dam = new SqlDataAdapter("select * from Mst_New_Districts ", con);
                dam.Fill(ds, "Dist");
                return ds.Tables["Dist"];
            }
        }

        public DataTable GetNewMandals(string dist)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter dam = new SqlDataAdapter("select * from Mst_New_Mandals where DistCode='" + dist + "' ", con);
                dam.Fill(ds, "Mandal");
                return ds.Tables["Mandal"];
            }
        }

        public DataTable viewdataDAL(string StateCode)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter dam = new SqlDataAdapter("select * from Mst_District ", con);
                dam.Fill(ds, "Dist");
                return ds.Tables["Dist"];
            }
        }
        public DataTable BindMnadalDAL(string DistCode)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter dam = new SqlDataAdapter("select * from Mst_Mandal where DistCode='" + DistCode + "' ", con);
                dam.Fill(ds, "Mandal");
                return ds.Tables["Mandal"];
            }
        }

        public DataTable UpdateDistDAL(string StateCode, string DistCode, string DistName)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("UpdateDistDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@DistName", SqlDbType.VarChar).Value = DistName;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable DeletedistrictDAL(string statecode, string distcode, string distname)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DeleteDistDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = statecode;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = distcode;
                    da.SelectCommand.Parameters.Add("@DistName", SqlDbType.VarChar).Value = distname;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable DeletemandalDAL(string distcode, string mndcode, string mndname)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DeleteMndDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = distcode;
                    da.SelectCommand.Parameters.Add("@Mndcode", SqlDbType.VarChar).Value = mndcode;
                    da.SelectCommand.Parameters.Add("@Mndname", SqlDbType.VarChar).Value = mndname;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable insertMandaltDAL(string DistCode, string Mcode, string MandalName, string INSERT)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("MandalDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.VarChar).Value = Mcode;
                    da.SelectCommand.Parameters.Add("@MandalName", SqlDbType.VarChar).Value = MandalName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = INSERT;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable UpdateMandaltDAL(string DistCode, string MandalCode, string MandalName, string UPDATE)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("MandalDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.VarChar).Value = MandalCode;
                    da.SelectCommand.Parameters.Add("@MandalName", SqlDbType.VarChar).Value = MandalName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = UPDATE;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* crop code */
        public DataTable getInsertCropDAL(string CropName, string type, string no_of_acres, string qty, string packsize, int slno, string seedrate, string INSERT)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("CropDetails", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@CropName", SqlDbType.VarChar).Value = CropName;
                    da.SelectCommand.Parameters.Add("@cropType", SqlDbType.VarChar).Value = type;
                    da.SelectCommand.Parameters.Add("@no_of_acres", SqlDbType.VarChar).Value = no_of_acres;
                    da.SelectCommand.Parameters.Add("@qty", SqlDbType.VarChar).Value = qty;
                    da.SelectCommand.Parameters.Add("@packsize", SqlDbType.VarChar).Value = packsize;
                    da.SelectCommand.Parameters.Add("@slno", SqlDbType.Int).Value = slno;
                    da.SelectCommand.Parameters.Add("@seedrate", SqlDbType.VarChar).Value = seedrate;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = INSERT;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable UpdateCropDAL(string CropName, string type, string no_of_acres, string qty, string packsize, int slno, string seedrate, string cropcode, string UPDATE)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("CropDetails", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@CropName", SqlDbType.VarChar).Value = CropName;
                    da.SelectCommand.Parameters.Add("@cropType", SqlDbType.VarChar).Value = type;
                    da.SelectCommand.Parameters.Add("@no_of_acres", SqlDbType.VarChar).Value = no_of_acres;
                    da.SelectCommand.Parameters.Add("@qty", SqlDbType.VarChar).Value = qty;
                    da.SelectCommand.Parameters.Add("@packsize", SqlDbType.VarChar).Value = packsize;
                    da.SelectCommand.Parameters.Add("@slno", SqlDbType.Int).Value = slno;
                    da.SelectCommand.Parameters.Add("@seedrate", SqlDbType.VarChar).Value = seedrate;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = cropcode;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = UPDATE;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }




        
 


        public DataTable DeleteCropDAL(string CropCode,string Delete)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("CropDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = CropCode;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = Delete;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }

            }
        }
        /* crop code end */      




        public DataTable getInsertCropVDAL(string CropCd, string CropVName, string user, int company, string INSERT)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("CropVDetails", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = CropCd;
                    da.SelectCommand.Parameters.Add("@CropVName", SqlDbType.VarChar).Value = CropVName;
                    da.SelectCommand.Parameters.Add("@comapny", SqlDbType.Int).Value = company;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.NVarChar).Value = user;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = INSERT;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable UpdateCropVDAL(string CropCd, string CropVCd, string CropVName, string user, int company, string UPDATE)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("CropVDetails", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = CropCd;
                    da.SelectCommand.Parameters.Add("@CropVCode", SqlDbType.VarChar).Value = CropVCd;
                    da.SelectCommand.Parameters.Add("@CropVName", SqlDbType.VarChar).Value = CropVName;
                    da.SelectCommand.Parameters.Add("@comapny", SqlDbType.Int).Value = company;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.NVarChar).Value = user;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = UPDATE;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable DeleteCropVDAL(string CropVCd, string CropVName, string Delete)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("CropVDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@CropVCode", SqlDbType.VarChar).Value = CropVCd;
                    da.SelectCommand.Parameters.Add("@CropVName", SqlDbType.VarChar).Value = CropVName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = Delete;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable viewCropDAL()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter dam = new SqlDataAdapter("select * from LR_CropMst ", con);
                dam.Fill(ds, "Crop");
                return ds.Tables["Crop"];
            }
        }
        public DataTable viewCroplistDAL(string Cpcode)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter dam = new SqlDataAdapter("select CropVCode ,CropVName,CropVnmTel  from CropVariety_Mst  where CropCode ='" + Cpcode + "'", con);
                dam.Fill(ds, "CropV");
                return ds.Tables["CropV"];
            }
        }


        //sale point insert //
        public DataTable insertSalePontDAL(string StateCode, string DistCode, string Mcode, string SalePointName, string INSERT, string username, int Active, string incharge, string mobile, string inchSco,string spusernm)
        {

            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SalesPointDetails", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.VarChar).Value = Mcode;
                    da.SelectCommand.Parameters.Add("@SalePointName", SqlDbType.VarChar).Value = SalePointName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = INSERT;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
                    da.SelectCommand.Parameters.Add("@Active", SqlDbType.Int).Value = Active;
                    da.SelectCommand.Parameters.Add("@incharge", SqlDbType.VarChar).Value = incharge;
                    da.SelectCommand.Parameters.Add("@incharge_soc", SqlDbType.VarChar).Value = inchSco;
                    da.SelectCommand.Parameters.Add("@mobile", SqlDbType.VarChar).Value = mobile;
                    da.SelectCommand.Parameters.Add("@userNameSp", SqlDbType.VarChar).Value = spusernm;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

        }

        //sale point Update //
        public DataTable UpdateSalepoint(string StateCode, string DistCode, string mcode, string salepointname, string username, int Active, string update, string spcode, string inchargeagri, string mobile, string inchSoc)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SalesPointDetails", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                    da.SelectCommand.Parameters.Add("@spcode", SqlDbType.VarChar).Value = spcode;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.VarChar).Value = mcode;
                    da.SelectCommand.Parameters.Add("@SalePointName", SqlDbType.VarChar).Value = salepointname;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = update;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
                    da.SelectCommand.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
                    da.SelectCommand.Parameters.Add("@Date", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    da.SelectCommand.Parameters.Add("@incharge", SqlDbType.VarChar).Value = inchargeagri;
                    da.SelectCommand.Parameters.Add("@incharge_soc", SqlDbType.VarChar).Value = inchSoc;
                    da.SelectCommand.Parameters.Add("@mobile", SqlDbType.VarChar).Value = mobile;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        //sale point Delete //

        public DataTable DeleteSalepoint(string spname, string delete)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SalesPointDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Spcode", SqlDbType.VarChar).Value = spname;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.VarChar).Value = delete;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable viewSalesPointdataDAL(string DistCode, string Mcode)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dam = new SqlDataAdapter("select * from Mst_SalePoints  where DistCode='" + DistCode + "' and MandCode='" + Mcode + "'", con);
                dam.Fill(dt);
                return dt;
            }
        }

        public DataTable viewDistdataDAL(string DistCode)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter dam = new SqlDataAdapter("select * from Mst_Mandal  where DistCode='" + DistCode + "'", con);
                dam.Fill(ds, "Mandal");
                return ds.Tables["Mandal"];
            }
        }


        public DataTable GetCompany()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Company_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = 'R';
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetCrops()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("CropDetails", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = "V";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetCropsCompanyWise(string company)
        {

            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("CropVDetails", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@comapny", SqlDbType.VarChar).Value = company;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = "V";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

        }


        public DataTable InsertCompany(string name, DateTime date, int ActiveSt, string UserName)
        {

            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Company_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@comapny_name", SqlDbType.VarChar).Value = name;
                    da.SelectCommand.Parameters.Add("@active", SqlDbType.VarChar).Value = ActiveSt;
                    da.SelectCommand.Parameters.Add("@effective_dt", SqlDbType.DateTime).Value = date;
                    da.SelectCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = 'I';
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

        }



        public DataTable UpdateCompany(string name, DateTime date, int ActiveSt, string companyid, string UserName)
        {

            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Company_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@comapny_name", SqlDbType.VarChar).Value = name;
                    da.SelectCommand.Parameters.Add("@active", SqlDbType.VarChar).Value = ActiveSt;
                    da.SelectCommand.Parameters.Add("@effective_dt", SqlDbType.DateTime).Value = date;
                    da.SelectCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@company_id", SqlDbType.VarChar).Value = companyid;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = 'U';
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

        }

        public DataTable DeleteCompany(string companyid)
        {

            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Company_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@company_id", SqlDbType.VarChar).Value = companyid;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = 'D';
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

        }

        //public DataTable insertSalePontDAL(string StateCode, string DistCode, string Mcode, string SalePointName, string INSERT, string username, int Active, string incharge, string mobile, string inchSco)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
        //    {
        //        using (SqlDataAdapter da = new SqlDataAdapter("SalesPointDetails", connection))
        //        {
        //            da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //            da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
        //            da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
        //            da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.VarChar).Value = Mcode;
        //            da.SelectCommand.Parameters.Add("@SalePointName", SqlDbType.VarChar).Value = SalePointName;
        //            da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = INSERT;
        //            da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
        //            da.SelectCommand.Parameters.Add("@Active", SqlDbType.Int).Value = Active;
        //            da.SelectCommand.Parameters.Add("@incharge", SqlDbType.VarChar).Value = incharge;
        //            da.SelectCommand.Parameters.Add("@incharge_soc", SqlDbType.VarChar).Value = inchSco;
        //            da.SelectCommand.Parameters.Add("@mobile", SqlDbType.VarChar).Value = mobile;
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);
        //            return dt;
        //        }
        //    }
        //}

        public DataTable GetSalepoints(string StateCode, string DistCode, string mand)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("[SalesPointDetails]", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.VarChar).Value = mand;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = 'R';
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable getAgencies(string state)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                DataSet dataSet = new DataSet();
                new SqlDataAdapter("select * from Mst_Agencies where StateCode='" + state + "'", connection).Fill(dataSet, "Agency");
                return dataSet.Tables["Agency"];
            }
        }


       



        public DataTable viewCroplistCompanyWise(string Cpcode, string company)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("CropVDetails", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = Cpcode;
                    da.SelectCommand.Parameters.Add("@comapny", SqlDbType.VarChar).Value = company;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = "G";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable getPackSize(string Cpcode)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                DataSet dataSet = new DataSet();
                new SqlDataAdapter("select packing_size from LR_CropMst where CropCode='" + Cpcode + "'", connection).Fill(dataSet, "pcksize");
                return dataSet.Tables["pcksize"];
            }
        }

        //11/10/2017
      
         public DataTable getStates()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter dam = new SqlDataAdapter("SELECT StateCode ,StateName FROM Mst_State", con);
                dam.Fill(ds, "state");
                return ds.Tables["state"];
            }
        }


         public DataTable insertDistDAL(LocationBE obj)
         {
             using (SqlDataAdapter da = new SqlDataAdapter("DistrictMaster_IUDR", con))
             {
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = obj.statecd;
                 da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = obj.distcd;
                 da.SelectCommand.Parameters.Add("@DistlgCode", SqlDbType.VarChar).Value = obj.distlgcd;
                 da.SelectCommand.Parameters.Add("@DistName", SqlDbType.VarChar).Value = obj.distname;
                 //if (obj.Flage != "D")
                 //{
                 //    da.SelectCommand.Parameters.Add("@EffectiveDt", SqlDbType.Date).Value = obj.efct_dt;
                 //    da.SelectCommand.Parameters.Add("@Active", SqlDbType.Int).Value = obj.active;
                 //}
                 da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = obj.userid;
                 da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Flage;

                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }
         }
         public DataTable GetMaxCode()
         {
             using (SqlDataAdapter da = new SqlDataAdapter("DistrictMaster_IUDR", con))
             {
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "G";
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }
         }

         public DataTable viewdataDALlg(string StateCode)
         {
             using (SqlDataAdapter da = new SqlDataAdapter("DistrictMaster_IUDR", con))
             {
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                 da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "R";
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }
         }

         /* Mandal Details INSERT UPADATE DELETE RETRIEV */
         public DataTable GetMaxmandalCode(string districtcode)
         {
             using (SqlDataAdapter da = new SqlDataAdapter("MandalDetails_IUDR", con))
             {
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.VarChar).Value = "M";
                 da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = districtcode;
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }
         }
         public DataTable insertMandaltDAL(LocationBE obj)
         {


             using (SqlDataAdapter da = new SqlDataAdapter("MandalDetails_IUDR", con))
             {
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = obj.distcd;
                 da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.VarChar).Value = obj.mandalcd;
                 da.SelectCommand.Parameters.Add("@MandalName", SqlDbType.VarChar).Value = obj.mandalname;
                 da.SelectCommand.Parameters.Add("@MandCode_LG", SqlDbType.VarChar).Value = (obj.mandallgcd == null) ? DBNull.Value : (object)obj.mandallgcd;

                 if (obj.Flage != "D")
                 {

                     da.SelectCommand.Parameters.Add("@MandalType", SqlDbType.VarChar).Value = obj.MandalType;
                     da.SelectCommand.Parameters.Add("@erastwh_distnm", SqlDbType.VarChar).Value = obj.distname;
                     da.SelectCommand.Parameters.Add("@erastwh_distcd", SqlDbType.VarChar).Value = obj.distlgcd;

                 }
                 da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = obj.userid;
                 da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = obj.Flage;
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }

         }
         public DataTable insertsubdistrictDAL(LocationBE obj)
         {


             using (SqlDataAdapter da = new SqlDataAdapter("subdistrict_IUDR", con))
             {
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = obj.distcd;
                 da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.VarChar).Value = obj.mandalcd;
                 da.SelectCommand.Parameters.Add("@MandalName", SqlDbType.VarChar).Value = obj.mandalname;
                 da.SelectCommand.Parameters.Add("@MandCode_LG", SqlDbType.VarChar).Value = (obj.mandallgcd == null) ? DBNull.Value : (object)obj.mandallgcd;
                 da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = obj.Flage;
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }

         }
         public DataTable viewDistdataDAL(string DistCode, string Flag_IUP)
         {
             using (SqlDataAdapter da = new SqlDataAdapter("MandalDetails_IUDR", con))
             {
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                 da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.VarChar).Value = Flag_IUP;
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }
         }


         public DataTable GetVillages(string dist, string mand, string action)
         {

             using (SqlDataAdapter da = new SqlDataAdapter("villageDetails_IUDR", con))
             {
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.NVarChar).Value = action;
                 da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.NVarChar).Value = dist;
                 da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.NVarChar).Value = mand;
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }

         }

         public DataTable InsertVillage(LocationBE obj)
         {
             DataTable dt = new DataTable();
             if (obj.Flage == "I")
             {
                 DataTable dtm = new DataTable();
                 dtm = GetVillages(obj.distcd, obj.mandalcd, "M");
                 if (dtm.Rows.Count > 0)
                 {
                     string vcode = dtm.Rows[0]["MaxVillcd"].ToString();
                     if (vcode != "")
                     {
                         int vcd = Convert.ToInt32(vcode);
                         vcd = vcd + 1;

                         if (vcd < 10)
                         {
                             vcode = "00" + Convert.ToString(vcd);
                         }
                         else if (vcd > 10 && vcd < 100)
                         {
                             vcode = "0" + Convert.ToString(vcd);
                         }
                         else
                         {
                             vcode = Convert.ToString(vcd);
                         }

                         obj.villagecd = vcode;
                     }
                     else
                     {
                         obj.villagecd = "001";
                     }
                 }
             }
             using (SqlDataAdapter da = new SqlDataAdapter("villageDetails_IUDR", con))
             {
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.NVarChar).Value = obj.Flage;
                 da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.NVarChar).Value = obj.distcd;
                 da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.NVarChar).Value = obj.mandalcd;
                 da.SelectCommand.Parameters.Add("@villagecode", SqlDbType.NVarChar).Value = obj.villagecd;
                 da.SelectCommand.Parameters.Add("@villagecode_LG", SqlDbType.NVarChar).Value = obj.villagelgcd;
                 da.SelectCommand.Parameters.Add("@villageName", SqlDbType.NVarChar).Value = obj.villagename;

                 da.Fill(dt);
                 return dt;
             }

             return dt;
         }

         public DataTable InsertGramPanchayat_IDUR(LocationBE obj)
         {
             DataTable dt = new DataTable();

             using (SqlDataAdapter da = new SqlDataAdapter("GramPanchayatDetails_IUDR", con))
             {
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.NVarChar).Value = obj.Flage;
                 da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.NVarChar).Value = obj.distcd;
                 da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.NVarChar).Value = obj.mandalcd;
                 da.SelectCommand.Parameters.Add("@GPCode_LG", SqlDbType.NVarChar).Value = obj.panchayatcd;   
                 da.SelectCommand.Parameters.Add("@GPCode", SqlDbType.NVarChar).Value = obj.panchayatlgcd;                
                 da.SelectCommand.Parameters.Add("@GPName", SqlDbType.NVarChar).Value = obj.panchayatname;

                 da.Fill(dt);
                 return dt;
             }

             return dt;
         }
         public DataTable GetGramPanchayatDetails(string dist, string mand, string action)
         {

             using (SqlDataAdapter da = new SqlDataAdapter("GramPanchayatDetails_IUDR", con))
             {
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.NVarChar).Value = action;
                 da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.NVarChar).Value = dist;
                 if (mand != "")
                 {
                     da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.NVarChar).Value = mand;
                 }
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }

         }
         public DataTable viewRDLCLGConsolidatedReport(string StateCode)
         {
             using (SqlDataAdapter da = new SqlDataAdapter("RDLC_LG_Consolidated_Report", con))
             {
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@statecode", SqlDbType.VarChar).Value = StateCode;
                 //da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "R";
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }
         }

         public DataTable viewRDLCLGConsolidatedMandalReport(string StateCode, string distcd, string lgstatus)
         {
             using (SqlDataAdapter da = new SqlDataAdapter("RDLC_LG_Cons_MandalWs_Rpt", con))
             {
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@statecode", SqlDbType.VarChar).Value = StateCode;
                 da.SelectCommand.Parameters.Add("@distcode", SqlDbType.VarChar).Value = distcd;
                 da.SelectCommand.Parameters.Add("@lgstatus", SqlDbType.VarChar).Value = lgstatus;
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }
         }
         public DataTable viewRDLCLGConsolidatedVillageReport(string StateCode, string distcd, string lgstatus)
         {
             using (SqlDataAdapter da = new SqlDataAdapter("RDLC_LG_Cons_villageWs_Rpt", con))
             {
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@statecode", SqlDbType.VarChar).Value = StateCode;
                 da.SelectCommand.Parameters.Add("@distcode", SqlDbType.VarChar).Value = distcd;
                 da.SelectCommand.Parameters.Add("@lgstatus", SqlDbType.VarChar).Value = lgstatus;
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }
         }
         public DataTable viewRDLCLGConsolidatedGPReport(string StateCode, string distcd, string lgstatus)
         {
             using (SqlDataAdapter da = new SqlDataAdapter("RDLC_LG_Cons_GPWs_Rpt", con))
             {
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@statecode", SqlDbType.VarChar).Value = StateCode;
                 da.SelectCommand.Parameters.Add("@distcode", SqlDbType.VarChar).Value = distcd;
                 da.SelectCommand.Parameters.Add("@lgstatus", SqlDbType.VarChar).Value = lgstatus;
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }
         }
         public DataTable viewRDLCLGConsolidatedMandalWsGPReport(string StateCode, string distcd, string lgstatus,string mandalcd)
         {
             using (SqlDataAdapter da = new SqlDataAdapter("RDLC_LG_Cons_Mandal_GPWs_Rpt", con))
             {
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@statecode", SqlDbType.VarChar).Value = StateCode;
                 da.SelectCommand.Parameters.Add("@distcode", SqlDbType.VarChar).Value = distcd;
                 da.SelectCommand.Parameters.Add("@mandcode", SqlDbType.VarChar).Value = mandalcd;
                 da.SelectCommand.Parameters.Add("@lgstatus", SqlDbType.VarChar).Value = lgstatus;
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }
         }
         public DataTable viewRDLCLGConsolidatedMandalVillageReport(string StateCode, string distcd, string lgstatus, string mandalcd)
         {
             using (SqlDataAdapter da = new SqlDataAdapter("RDLC_LG_MandalWs_village_Rpt", con))
             {
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@statecode", SqlDbType.VarChar).Value = StateCode;
                 da.SelectCommand.Parameters.Add("@distcode", SqlDbType.VarChar).Value = distcd;
                 da.SelectCommand.Parameters.Add("@mandcode", SqlDbType.VarChar).Value = mandalcd;
                 da.SelectCommand.Parameters.Add("@lgstatus", SqlDbType.VarChar).Value = lgstatus;
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }
         }

         public DataTable UpdateMismatchVillagewithLgName(LocationBE obj)
         {
             DataTable dt = new DataTable();

             using (SqlDataAdapter da = new SqlDataAdapter("MismatchVillageNames_U", con))
             {
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@flag", SqlDbType.NVarChar).Value = obj.Flage;
                 da.SelectCommand.Parameters.Add("@distcd", SqlDbType.NVarChar).Value = obj.distcd;
                 da.SelectCommand.Parameters.Add("@mandalcd", SqlDbType.NVarChar).Value = obj.mandalcd;
                 da.SelectCommand.Parameters.Add("@villcd", SqlDbType.NVarChar).Value = obj.villagecd;
                 da.SelectCommand.Parameters.Add("@lgvillcd", SqlDbType.NVarChar).Value = obj.villagelgcd;
                 da.SelectCommand.Parameters.Add("@lgVillagename", SqlDbType.NVarChar).Value = obj.villagename;
                 da.SelectCommand.Parameters.Add("@lgdistcd", SqlDbType.NVarChar).Value = obj.distlgcd;

                 da.Fill(dt);
                 return dt;
             }

             return dt;
         }

         public DataTable GetLGHitCount(string depttype)
         {
             using (SqlDataAdapter da = new SqlDataAdapter("Dept_WS_Hit_count", con))
             {
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@depttype", SqlDbType.VarChar).Value = depttype;
               
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }
         }
         public DataTable Getlocationdet(LocationBE Obj)
         {
            
                 using (SqlDataAdapter da = new SqlDataAdapter("NFSM_LG_location_DET", con))
                 {
                     da.SelectCommand.CommandType = CommandType.StoredProcedure;
                     da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = Obj.Flage;
                     da.SelectCommand.Parameters.Add("@statecode", SqlDbType.VarChar).Value = Obj.statecd;
                     if (Obj.distlgcd != "" && Obj.distlgcd != null)
                     {
                         da.SelectCommand.Parameters.Add("@LgDistrictcd", SqlDbType.VarChar).Value = Obj.distlgcd;
                     }
                     if (Obj.mandallgcd != "" && Obj.mandallgcd != null)
                     {
                         da.SelectCommand.Parameters.Add("@LGMandalcd", SqlDbType.VarChar).Value = Obj.mandallgcd;
                     }


                     DataTable dt = new DataTable();
                     da.Fill(dt);
                     return dt;
                 }
             
         }
         public DataTable GetSoilhealthAdvisor(LocationBE obj, string action)
         {

             using (SqlDataAdapter da = new SqlDataAdapter("GetSoilHealthadvisor", con))
             {
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.NVarChar).Value = action;
                 da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.NVarChar).Value = obj.distcd;
                 da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.NVarChar).Value = obj.mandalcd;
                 da.SelectCommand.Parameters.Add("@Villagecd", SqlDbType.NVarChar).Value = obj.villagecd;
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }

         }
    
    }
   

}
