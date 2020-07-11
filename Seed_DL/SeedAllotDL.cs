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
    public class SeedAllotDL
    {


        public DataTable GetSPStockID(string year, string season, string crop, string dist, string mand)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                DataSet dataSet = new DataSet();
                new SqlDataAdapter("select sp_stock_id from Dtls_SeedAllotment_Mandals where year='" + year + "' and season='" + season + "' AND crop = '" + crop + "' and  district='" + dist + "' and mandal='" + mand + "'", connection).Fill(dataSet, "stkid");
                return dataSet.Tables["stkid"];
            }
        }






        public DataTable GetSPStockLeftAtSP(string year, string season, string crop, int cv, string sp)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("checkStockAtSP", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.Char).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@cropv", SqlDbType.VarChar).Value = cv;
                    da.SelectCommand.Parameters.Add("@sp", SqlDbType.VarChar).Value = sp;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetSalepoints(string state,string dist, string mand)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SalesPointDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = "R";
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = state;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.VarChar).Value = mand;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


      public DataTable InsertStockDAL(stockBE obj)
      {
          using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("[Stock_IUDR]", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = "I";
                  da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = obj.crop;
                  da.SelectCommand.Parameters.Add("@cvcode", SqlDbType.Int).Value = obj.cropV;
                  da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = obj.year;
                  da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = obj.season;
                  da.SelectCommand.Parameters.Add("@lr_no", SqlDbType.VarChar).Value = obj.lrno;
                  da.SelectCommand.Parameters.Add("@lrdt", SqlDbType.Date).Value = obj.lrdt;
                  da.SelectCommand.Parameters.Add("@stock_received", SqlDbType.Decimal).Value = obj.rcvd;
                  da.SelectCommand.Parameters.Add("@spcode", SqlDbType.Decimal).Value = obj.salepoint;
                  da.SelectCommand.Parameters.Add("@nob", SqlDbType.VarChar).Value = obj.nob;
                  da.SelectCommand.Parameters.Add("@bagWeight", SqlDbType.VarChar).Value = obj.weight;
                  da.SelectCommand.Parameters.Add("@allotid", SqlDbType.Decimal).Value = obj.allot_id;
                  da.SelectCommand.Parameters.Add("@agency", SqlDbType.Int).Value = obj.agency;  
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }
      }

      //stock Update 
      public DataTable UpdateStockDAL(string rcvd, string lrno, string stkid, string nob, string aid, string old)
      {
          using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("[Stock_IUDR]", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = "U";
                  da.SelectCommand.Parameters.Add("@stock_received", SqlDbType.VarChar).Value = rcvd;
                  da.SelectCommand.Parameters.Add("@lr_no", SqlDbType.VarChar).Value = lrno;
                  da.SelectCommand.Parameters.Add("@stock_id", SqlDbType.VarChar).Value = stkid;
                  da.SelectCommand.Parameters.Add("@nob", SqlDbType.VarChar).Value = nob;
                  da.SelectCommand.Parameters.Add("@allotid", SqlDbType.VarChar).Value = aid;
                  da.SelectCommand.Parameters.Add("@allotedQty", SqlDbType.VarChar).Value = old;
                  da.SelectCommand.Parameters.Add("@updatedQty", SqlDbType.VarChar).Value = rcvd;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }
      }

      //Stock Delete //

      public DataTable DeleteStock(string stkid, string alloted,string allotid)
      {
          using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("[Stock_IUDR]", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = "D";
                  da.SelectCommand.Parameters.Add("@stock_id", SqlDbType.VarChar).Value = stkid;
                  da.SelectCommand.Parameters.Add("@allotedQty", SqlDbType.VarChar).Value = alloted;
                  da.SelectCommand.Parameters.Add("@allotid", SqlDbType.VarChar).Value = allotid;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }
      }
        // View Stock
      public DataTable ViewStock(string year, string season, string c,string sp)
      {
          using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("[Stock_IUDR]", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = "R";
                  da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                  da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                  da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = c;
                  da.SelectCommand.Parameters.Add("@spcode", SqlDbType.Decimal).Value = sp;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }
      }

      public DataTable ViewStockSeasonWs(string year, string season, string sp)
      {
          using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("Stock_IUDR", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = "S";
                  da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                  da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                  da.SelectCommand.Parameters.Add("@spcode", SqlDbType.Decimal).Value = sp;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }
      }
      //public DataTable ViewStock(string year, string season, string c,int cv, string flag)
      //{
      //    using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
      //    {
      //        using (SqlDataAdapter da = new SqlDataAdapter("[Stock_IUDR]", con))
      //        {
      //            da.SelectCommand.CommandType = CommandType.StoredProcedure;
      //            if (flag == "cropVariety")
      //            {
      //                da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = "R";
      //                da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = c;
      //                da.SelectCommand.Parameters.Add("@cvcode", SqlDbType.Int).Value = cv;
      //            }
      //            else
      //            {
      //                da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = "V";
      //                da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = c;
      //            }
      //            da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
      //            da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
      //            DataTable dt = new DataTable();
      //            da.Fill(dt);
      //            return dt;
      //        }
      //    }
      //}

      
       


        /*Seed Allotment to districts*/

        public DataTable InsertSeedAllotment(string year, string season, string crop, int cv, string dist, string alloted, string user, string agnecy)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "DI";
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@CropVcode", SqlDbType.Int).Value = cv;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@allotedQty", SqlDbType.VarChar).Value = alloted;
                    da.SelectCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                    da.SelectCommand.Parameters.Add("@agency", SqlDbType.VarChar).Value = agnecy;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable InsertSeedAllotmentAny(string year, string season, string crop, string dist, string alloted, string user, string agnecy)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "DY";
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@allotedQty", SqlDbType.VarChar).Value = alloted;
                    da.SelectCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                    da.SelectCommand.Parameters.Add("@agency", SqlDbType.VarChar).Value = agnecy;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable InsertSeedAllotmentALL(string year, string season, string crop, string dist, string alloted, string user, string agnecy)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "DA";
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@allotedQty", SqlDbType.VarChar).Value = alloted;
                    da.SelectCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                    da.SelectCommand.Parameters.Add("@agency", SqlDbType.VarChar).Value = agnecy;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable GetSeedAllotment(string year, string season)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "DR";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable DeletSeedAllotment(string allotid, string qty)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "DD"; 
                    da.SelectCommand.Parameters.Add("@allotid", SqlDbType.VarChar).Value = allotid;
                    da.SelectCommand.Parameters.Add("@allotedQty", SqlDbType.VarChar).Value = qty;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }






        public DataTable UpdateSeedAllotment(string allotid, string updated)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "DU";
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "DU";
                    da.SelectCommand.Parameters.Add("@allotid", SqlDbType.VarChar).Value = allotid;
                    da.SelectCommand.Parameters.Add("@allotedQty", SqlDbType.VarChar).Value = updated;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        /*Seed Allotement to mandals*/

        public DataTable InsertSeedAllotmentMandal(string year, string season, string crop, int cv, string dist, string mand, string alloted, string user)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "MI";
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@CropVcode", SqlDbType.Int).Value = cv;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@mandal", SqlDbType.VarChar).Value = mand;
                    da.SelectCommand.Parameters.Add("@allotedQty", SqlDbType.VarChar).Value = alloted;
                    da.SelectCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetSeedAllotmentMandal(string year, string season)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "MR";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable DeletSeedAllotmentMandal(string year, string season, string dist, string crop, string cv)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "MD";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@CropVcode", SqlDbType.Int).Value = cv;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable UpdateSeedAllotmentMandal(string year, string season, string dist, string crop, int cv, string alloted)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "MU";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@CropVcode", SqlDbType.Int).Value = cv;
                    da.SelectCommand.Parameters.Add("@allotedQty", SqlDbType.VarChar).Value = alloted;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable InsertSeedIssual(DataTable DtSeedReq, string fid, string year, string season, string sp, string user)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedIssual", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@sr", SqlDbType.Structured).Value = DtSeedReq;
                    da.SelectCommand.Parameters.Add("@FinYear", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@farmerid", SqlDbType.VarChar).Value = fid;
                    da.SelectCommand.Parameters.Add("@SeasonName", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@salepoint", SqlDbType.VarChar).Value = sp;
                    da.SelectCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                    //da.SelectCommand.Parameters.Add("@permitcode", SqlDbType.VarChar).Value = permit;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetSeedAllotmentCropWise(string year, string season, string crop)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "DR";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = crop;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetSeedAllotmentDistWise(string year, string season, string dist)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "VR";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable FreezeAllotment(DataTable Dt)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FreezeSeedAllotment", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@sa", SqlDbType.Structured).Value = Dt;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "1";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

    }
}
