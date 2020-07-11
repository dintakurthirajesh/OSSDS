using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Seed_DL
{
    public class StockTransfer
    {
        public DataTable GetStockPosition(string year, string season,string dist, string mand, string crop,string cv)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("StockTransfer", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "MAO";
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@mand", SqlDbType.VarChar).Value = mand;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@cropV", SqlDbType.VarChar).Value = cv;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable GetSps(string spcode, string dist, string mand)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("StockTransfer", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "GetSps";
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@mand", SqlDbType.VarChar).Value = mand;
                    da.SelectCommand.Parameters.Add("@slptcode", SqlDbType.VarChar).Value = spcode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable SptoSpTransfer(string fromsp,string crop,string cv, string year, string season,string nobtotr,string weight,string tosp,string user, string ip)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("StockTransfer", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "sptosp";
                    da.SelectCommand.Parameters.Add("@slptcode", SqlDbType.VarChar).Value = fromsp;
                    da.SelectCommand.Parameters.Add("@tosp", SqlDbType.VarChar).Value = tosp;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@cropV", SqlDbType.VarChar).Value = cv;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@bagsto_trnsfr", SqlDbType.VarChar).Value = nobtotr;
                    da.SelectCommand.Parameters.Add("@weight", SqlDbType.VarChar).Value = weight;
                    //da.SelectCommand.Parameters.Add("@allot_id", SqlDbType.VarChar).Value = allotid;
                    da.SelectCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                    da.SelectCommand.Parameters.Add("@ip", SqlDbType.VarChar).Value = ip;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable SptoMandTransfer(string year, string season, string crop, string cv, string spcode, string nobtotr, string weight,  string user, string ip)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("StockTransfer", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "spTomand";
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season; 
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@cropV", SqlDbType.VarChar).Value = cv;
                    da.SelectCommand.Parameters.Add("@slptcode", SqlDbType.VarChar).Value = spcode;
                    da.SelectCommand.Parameters.Add("@bagsto_trnsfr", SqlDbType.VarChar).Value = nobtotr;
                    da.SelectCommand.Parameters.Add("@weight", SqlDbType.VarChar).Value = weight;
                    //da.SelectCommand.Parameters.Add("@allot_id", SqlDbType.VarChar).Value = allotid;
                    da.SelectCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                    da.SelectCommand.Parameters.Add("@ip", SqlDbType.VarChar).Value = ip;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


   
        /// ***Stock Transfer By DAO
     
        public DataTable GetStockPositionMandWise(string year, string season, string dist, string crop, string cv)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("StockTransfer_DAO", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "DAO";
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@cropV", SqlDbType.VarChar).Value = cv;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetMandals(string dist, string mand)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("StockTransfer_DAO", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "GetMandals";
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@frm_mand", SqlDbType.VarChar).Value = mand;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable MandalToMandalTrnsfer(string year, string season, string dist,string from , string to, string crop)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("StockTransfer_DAO", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "DAO";
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@frm_mand", SqlDbType.VarChar).Value = from;
                    da.SelectCommand.Parameters.Add("@to_mand", SqlDbType.VarChar).Value = to;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable MandalToDistTrnsfer(string year, string season, string dist, string from, string crop)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("StockTransfer_DAO", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "DAO";
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@frm_mand", SqlDbType.VarChar).Value = from;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
