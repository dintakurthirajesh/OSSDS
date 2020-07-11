using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seed_BE;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

namespace Seed_DL
{
    public class SeedPriceDL
    {
        DataTable dt = new DataTable();
        public DataTable SeedPrice_IUDRDL(SeedPriceBE seedprice)
        {
            if (seedprice.Action == "I")
            {
                using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("SeedPrice_IUDR", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = seedprice.Action;
                        da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = seedprice.CropCode;
                        da.SelectCommand.Parameters.Add("@CropVCode", SqlDbType.VarChar).Value = seedprice.CropVCode;
                        da.SelectCommand.Parameters.Add("@SeedVarietyName", SqlDbType.VarChar).Value = seedprice.SeedVarietyName;
                        da.SelectCommand.Parameters.Add("@Subsidized_Price", SqlDbType.Int).Value = seedprice.Subsidized_Price;
                        da.SelectCommand.Parameters.Add("@Year", SqlDbType.Char).Value = seedprice.Year;
                        da.SelectCommand.Parameters.Add("@season", SqlDbType.Char).Value = seedprice.Season;
                        da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = seedprice.UserName;
                        da.SelectCommand.Parameters.Add("@Actual_MRP", SqlDbType.Int).Value = seedprice.Actual_Price;
                        da.Fill(dt);
                    }
                }
            }


            if (seedprice.Action == "A")
            {
                using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("SeedPrice_IUDR", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = seedprice.Action;
                        da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = seedprice.CropCode;
                        //da.SelectCommand.Parameters.Add("@CropVCode", SqlDbType.VarChar).Value = seedprice.CropVCode;
                        //da.SelectCommand.Parameters.Add("@SeedVarietyName", SqlDbType.VarChar).Value = seedprice.SeedVarietyName;
                        da.SelectCommand.Parameters.Add("@Subsidized_Price", SqlDbType.Decimal).Value = seedprice.Subsidized_Price;
                        da.SelectCommand.Parameters.Add("@Year", SqlDbType.Char).Value = seedprice.Year;
                        da.SelectCommand.Parameters.Add("@season", SqlDbType.Char).Value = seedprice.Season;
                        da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = seedprice.UserName;
                        da.SelectCommand.Parameters.Add("@Actual_MRP", SqlDbType.Decimal).Value = seedprice.Actual_Price;
                        da.Fill(dt);
                    }
                }
            }
            else if (seedprice.Action == "R")
            {
                using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("SeedPrice_IUDR", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = seedprice.Action;
                        da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = seedprice.CropCode;
                        da.SelectCommand.Parameters.Add("@CropVCode", SqlDbType.VarChar).Value = seedprice.CropVCode;
                        da.SelectCommand.Parameters.Add("@Year", SqlDbType.Char).Value = seedprice.Year;
                        da.SelectCommand.Parameters.Add("@season", SqlDbType.Char).Value = seedprice.Season;
                        da.Fill(dt);
                    }
                }
            }
            else if (seedprice.Action == "V")
            {
                using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("SeedPrice_IUDR", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = seedprice.Action;
                        da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = seedprice.CropCode;
                        da.SelectCommand.Parameters.Add("@Year", SqlDbType.Char).Value = seedprice.Year;
                        da.SelectCommand.Parameters.Add("@season", SqlDbType.Char).Value = seedprice.Season;
                        da.Fill(dt);
                    }
                }
            }
            else if (seedprice.Action == "U")
            {
                using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("SeedPrice_IUDR", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = seedprice.Action;
                        da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = seedprice.CropCode;
                        da.SelectCommand.Parameters.Add("@CropVCode", SqlDbType.VarChar).Value = seedprice.CropVCode;
                        da.SelectCommand.Parameters.Add("@SeedVarietyName", SqlDbType.VarChar).Value = seedprice.SeedVarietyName;
                        da.SelectCommand.Parameters.Add("@Subsidized_Price", SqlDbType.Int).Value = seedprice.Subsidized_Price;
                        da.SelectCommand.Parameters.Add("@Year", SqlDbType.Char).Value = seedprice.Year;
                        da.SelectCommand.Parameters.Add("@season", SqlDbType.Char).Value = seedprice.Season;
                        da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = seedprice.UserName;
                        da.SelectCommand.Parameters.Add("@Actual_MRP", SqlDbType.Int).Value = seedprice.Actual_Price;
                        da.Fill(dt);
                    }
                }

            }
            else if (seedprice.Action == "D")
            {
                using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("SeedPrice_IUDR", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = seedprice.Action;
                        da.SelectCommand.Parameters.Add("@CropVCode", SqlDbType.VarChar).Value = seedprice.CropVCode;
                        da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = seedprice.Year;
                        da.SelectCommand.Parameters.Add("@season", SqlDbType.Char).Value = seedprice.Season;
                        da.Fill(dt);
                    }
                }
            }

            else if (seedprice.Action == "S")
            {
                using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("SeedPrice_IUDR", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = seedprice.Action;
                        da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = seedprice.Year;
                        da.SelectCommand.Parameters.Add("@season", SqlDbType.Char).Value = seedprice.Season;
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
