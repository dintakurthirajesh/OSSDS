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
    public class DistributedseedDL
    {
        DistributionSeedBE obj = new DistributionSeedBE();
        DataTable dt = new DataTable();


        public DataTable GetPrice(string permit)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetPrice", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Permit", SqlDbType.VarChar).Value = permit;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetPermitData(string permitno,string sp)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_GetpermitDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@PermiNo", SqlDbType.VarChar).Value = permitno;
                    da.SelectCommand.Parameters.Add("@sp_code", SqlDbType.VarChar).Value = sp;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable InsertSeedRequestDtlsDAL(DataTable DtSeedReq,string perm)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_GetpermitDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@dt", SqlDbType.Structured).Value = DtSeedReq;
                    da.SelectCommand.Parameters.Add("@PermiNo", SqlDbType.VarChar).Value = perm;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*
        public DataTable InsertSeedRequestDtlsDAL(DataTable DtSeedReq, string farmer, string FinYear, string SeasonName, string sp)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Insert_SeedRequestDtls", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@SeedRequest1_Dtls", SqlDbType.Structured).Value = DtSeedReq;
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
        */
        public DataTable Distributedseeddata(DistributionSeedBE data, string permit)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_GetpermitDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@PermiNo", SqlDbType.VarChar).Value = permit;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = data.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = data.season;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = data.crop;
                    da.SelectCommand.Parameters.Add("@cropV", SqlDbType.VarChar).Value = data.cropV;                  
                    da.Fill(dt);
                    //obj.cropname = dt.Rows[0]["CropName_Tel"].ToString();
                    //obj.Extent = Convert.ToDecimal(dt.Rows[0]["Extent"]);
                    //obj.SeedQty_Requirement = Convert.ToInt32(dt.Rows[0]["SeedQty_Requirement"].ToString());
                    //obj.SeedQty_Requested = Convert.ToInt32(dt.Rows[0]["SeedQty_Requested"].ToString());
                    //obj.SeedQty_Issued = Convert.ToInt32(dt.Rows[0]["SeedQty_Issued"].ToString());
                    return dt;
                }
            }
        }
        public DataTable InsertSeedDistribution(DataTable Dt, string year, string season, string farmer_id, string sp_code, string permit)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedDistribution_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@sd", SqlDbType.Structured).Value = Dt;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@farmer_id", SqlDbType.VarChar).Value = farmer_id;
                    da.SelectCommand.Parameters.Add("@sp_code", SqlDbType.VarChar).Value = sp_code;
                    da.SelectCommand.Parameters.Add("@permit", SqlDbType.VarChar).Value = permit;
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetPriceLabels(string year, string season, string crop, string cv)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetPrice", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@cropv", SqlDbType.VarChar).Value = cv;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "A";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetPurchaseReceipt(string permit, string sp_code,string adhar)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RDLC_purchase_slip", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@permit", permit);
                    da.SelectCommand.Parameters.Add("@adhar", adhar);
                    da.SelectCommand.Parameters.Add("@spcode", sp_code);
                    da.Fill(dt);
                    return dt;
                }
            }
        }


    }
}
