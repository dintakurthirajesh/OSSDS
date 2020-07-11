using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Seed_DL
{
    public class ReportsDL
    {
        public DataTable generatePermitDAL(string FarmerId, string FinYear, string SeasonName,string Permit)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RDLC_GeneratePermit", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@FarmerId", SqlDbType.VarChar).Value = FarmerId;
                    da.SelectCommand.Parameters.Add("@FinYear", SqlDbType.VarChar).Value = FinYear;
                    da.SelectCommand.Parameters.Add("@SeasonName", SqlDbType.VarChar).Value = SeasonName;
                    da.SelectCommand.Parameters.Add("@Permit", SqlDbType.VarChar).Value = Permit;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetAllotmentDistWise(string year, string seasson, string crop)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("ViewSeedAllotmentDistWise", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = seasson;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = crop;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetAllotmentMandWise(string year, string seasson, string crop, string dist)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("ViewSeedAllotmentMandWise", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = seasson;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = crop;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetAllotmentSPWise(string year, string seasson, string crop, string dist, string mand)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("ViewSeedAllotmentSP", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = seasson;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@mand", SqlDbType.VarChar).Value = mand;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetAllSalePoints()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("ViewSp", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "5";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetAllSalePointsInDistrict(string dist)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("ViewSp", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "6";
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }




        public DataTable GetCount(string action)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("HomepgReports", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable GetCropReport(string FinYear, string SeasonName, string crop, string cv)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetReport", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "2";
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = FinYear;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = SeasonName;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@cv", SqlDbType.VarChar).Value = cv;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetFarmers(string FinYear, string SeasonName, string dist, string mand)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetReport", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "1";
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = FinYear;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = SeasonName;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@mand", SqlDbType.VarChar).Value = mand;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetSalePoints()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("ViewSp", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "1";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetSalePointsDist(string dist)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("ViewSp", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "2";
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetSalePointsMand(string dist, string mand)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("ViewSp", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "4";
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@mand", SqlDbType.VarChar).Value = mand;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetAllSalePointsInDist(string dist)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("ViewSp", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "6";
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetSaleInfo( string FinYear, string SeasonName,String sp)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetSalesInfo", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = FinYear;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = SeasonName;
                    da.SelectCommand.Parameters.Add("@spcode", SqlDbType.VarChar).Value = sp;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetPermits_SPWiseDAL(string FinYear, string SeasonName, string SpCode)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetPermits_SPWise", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = FinYear;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = SeasonName;
                    da.SelectCommand.Parameters.Add("@spcode", SqlDbType.Int).Value = SpCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetPermits_DtWise(string sp, DateTime fromdt, DateTime todt)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RDLC_PermitsDtWs", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@spcode", SqlDbType.VarChar).Value = sp;
                    da.SelectCommand.Parameters.Add("@fromdt", SqlDbType.Date).Value = fromdt;
                    da.SelectCommand.Parameters.Add("@todt", SqlDbType.Date).Value = todt;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetPermits_All(string FinYear, string SeasonName)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RDLC_PermitsData", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = FinYear;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = SeasonName;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetPermits_MandWS(string FinYear, string SeasonName, string DistCode)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RDLC_Permits_MandWs", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = FinYear;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = SeasonName;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = DistCode;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetPermits_SpWs(string FinYear, string SeasonName, string DistCode, string mandal)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RDLC_Permits_SpWs", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = FinYear;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = SeasonName;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@mand", SqlDbType.VarChar).Value = mandal;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetPermits_SpWsAllDL(string FinYear, string SeasonName, string DistCode, string mandal, string SalPoint)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetPermits_All", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = FinYear;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = SeasonName;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@mand", SqlDbType.VarChar).Value = mandal;
                    da.SelectCommand.Parameters.Add("@spcode", SqlDbType.VarChar).Value = SalPoint;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable GetDistributionDistWs(string FinYear, string SeasonName)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RDLC_Distrbution_DistWs", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = FinYear;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = SeasonName;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetreportDistributionMandWise(string year, string season, string distcode)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RDLC_Distribution_MandWise", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@district", SqlDbType.VarChar).Value = distcode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetreportDistrbutionSPWise(string year, string season, string distcode, string mandalcode)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RDLC_DistrbutionSPWise", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@distcode", SqlDbType.VarChar).Value = distcode;
                    da.SelectCommand.Parameters.Add("@mandcode", SqlDbType.VarChar).Value = mandalcode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetDistributionDtWs(string sp, DateTime fromdt, DateTime todt)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RDLC_ViewSeedDistributed", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@spcode", SqlDbType.VarChar).Value = sp;
                    da.SelectCommand.Parameters.Add("@fromdt", SqlDbType.Date).Value = fromdt;
                    da.SelectCommand.Parameters.Add("@todt", SqlDbType.Date).Value = todt;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetDailyReport(string FinYear, string SeasonName,string crop,string date)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RDLC_DailyRprt", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = FinYear;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = SeasonName;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@date", SqlDbType.VarChar).Value = date;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable GetDistWsAllReport(string FinYear, string SeasonName)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RDLC_DailyRprtDistWise", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = FinYear;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = SeasonName;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetCropWsAbstract(string FinYear, string SeasonName)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RDLC_Abstract_CropWise", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = FinYear;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = SeasonName;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        //24102017
        public DataTable Getreportsalepointwisefarmerdetails(string salepoint, string yearcode, string seasoncode)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RDLC_ViewSeedDistributed_new", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@spcode", SqlDbType.VarChar).Value = salepoint;
                    da.SelectCommand.Parameters.Add("@yearcode", SqlDbType.VarChar).Value = yearcode;
                    da.SelectCommand.Parameters.Add("@seasoncode", SqlDbType.VarChar).Value = seasoncode;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetDistributionDetailsDistWs(string FinYear, string SeasonName,string crop)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RDLC_Distribution_Details", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = FinYear;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = SeasonName;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = crop;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

       

        public DataTable GetDistributionDetailsmandalWs(string FinYear, string SeasonName, string crop,string districtcd)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RDLC_Distribution_Details_MandWs", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = FinYear;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = SeasonName;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = districtcd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetDistributionDetailsfarmerWs(string FinYear, string SeasonName, string crop, string districtcd, string castcd,string gender)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("[GRID_DistbutionDetails_CategoryWs]", con))
                {
                   

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = FinYear;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = SeasonName;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@districd", SqlDbType.VarChar).Value = districtcd;
                    da.SelectCommand.Parameters.Add("@castecd", SqlDbType.VarChar).Value = castcd;
                    da.SelectCommand.Parameters.Add("@gender", SqlDbType.VarChar).Value = gender;
                    
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetDistributionMandalWsFarmerDetail(string FinYear, string SeasonName, string crop, string districtcd, string mandalcd, string castcd, string gender)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("[GRID_Distbution_Mandal_FarmerWs]", con))
                {


                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = FinYear;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = SeasonName;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@districd", SqlDbType.VarChar).Value = districtcd;
                    da.SelectCommand.Parameters.Add("@mandcd", SqlDbType.VarChar).Value = mandalcd;
                    da.SelectCommand.Parameters.Add("@castecd", SqlDbType.VarChar).Value = castcd;
                    da.SelectCommand.Parameters.Add("@gender", SqlDbType.VarChar).Value = gender;


                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetDistributionDet_Mandal_SpWs(string FinYear, string SeasonName, string crop, string districtcd,string mandcd)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Grid_Distribution_Det_Mandal_SpWs", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = FinYear;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = SeasonName;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = districtcd;
                    da.SelectCommand.Parameters.Add("@mandcd", SqlDbType.VarChar).Value = mandcd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetDistributionSalePointWsFarmerDetails(string FinYear, string SeasonName, string crop, string districtcd, string mandalcd, string castcd, string gender, string salepointcd)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("[GRID_Distbution_Mandal_SpWs_Farmer]", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = FinYear;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = SeasonName;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@districd", SqlDbType.VarChar).Value = districtcd;
                    da.SelectCommand.Parameters.Add("@mandcd", SqlDbType.VarChar).Value = mandalcd;
                    da.SelectCommand.Parameters.Add("@castecd", SqlDbType.VarChar).Value = castcd;
                    da.SelectCommand.Parameters.Add("@gender", SqlDbType.VarChar).Value = gender;
                    da.SelectCommand.Parameters.Add("@salepoint", SqlDbType.VarChar).Value = salepointcd;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
