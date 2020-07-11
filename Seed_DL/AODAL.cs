using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Seed_DL
{
    public class AODAL
    {
        public DataTable GetSeedAllotment(string year, string season,string crop, string cv)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "DR";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@CropVcode", SqlDbType.VarChar).Value = cv;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetSeedAllotmentDistrict(string year, string season, string dist)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "11";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetSeedAllotmentMandal(string year, string season, string crop, string dist)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "MR";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = crop;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetSeedAllotmentMandals(string year, string season, string dist,string mand)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "RR";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@mandal", SqlDbType.VarChar).Value = mand;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable InsertSeedAllotmentMandal(string year, string season, string crop, int cv, string dist,string mand, string alloted, string user,int aid)
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
                    da.SelectCommand.Parameters.Add("@allotid", SqlDbType.Int).Value = aid;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetSeedAllotmentDistrictCropWsFreezed(string year, string season, string crop)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "15";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = crop;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetSeedAllotmentCropWise(string year, string season, string crop, string dist)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "12";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetSeedAllotmentCropWiseFreezed(string year, string season, string crop, string dist)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "17";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable DeletSeedAllotmentMandal(string spstkid, string qty, string allotid)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "MD";
                    da.SelectCommand.Parameters.Add("@sp_stkid", SqlDbType.VarChar).Value = spstkid;
                    da.SelectCommand.Parameters.Add("@allotedQty", SqlDbType.VarChar).Value = qty;
                    da.SelectCommand.Parameters.Add("@allotid", SqlDbType.VarChar).Value = allotid;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable UpdateSeedAllotmentMandal(string aid, string qty, string updated, string spstkid)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "MU";
                    da.SelectCommand.Parameters.Add("@sp_stkid", SqlDbType.VarChar).Value = spstkid;
                    da.SelectCommand.Parameters.Add("@allotid", SqlDbType.VarChar).Value = aid;
                    da.SelectCommand.Parameters.Add("@allotedQty", SqlDbType.VarChar).Value = qty;
                    da.SelectCommand.Parameters.Add("@updatedQty", SqlDbType.VarChar).Value = updated;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable GetMaxAllotemnt(string year, string season, string c, string spcode)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetMaxStock", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = c;
                    da.SelectCommand.Parameters.Add("@spcode", SqlDbType.BigInt).Value = spcode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable GetSeedAllotmentMandWise(string year, string season, string dist, string mandal)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "13";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@mandal", SqlDbType.VarChar).Value = mandal;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetSeedAllotmentMandWiseFrrezed(string year, string season, string dist, string mandal)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SeedAllot_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "16";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@mandal", SqlDbType.VarChar).Value = mandal;
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
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "2";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable AddRep(string state, string dist, string mand, string sp, string user, string active, string name, string desig, string mobile, string addedby)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Representative_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = state;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.VarChar).Value = mand;
                    da.SelectCommand.Parameters.Add("@spcode", SqlDbType.VarChar).Value = sp;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = user;
                    da.SelectCommand.Parameters.Add("@Active", SqlDbType.VarChar).Value = active;
                    da.SelectCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                    da.SelectCommand.Parameters.Add("@desig", SqlDbType.VarChar).Value = desig;
                    da.SelectCommand.Parameters.Add("@mobile", SqlDbType.VarChar).Value = mobile;
                    da.SelectCommand.Parameters.Add("@addedby", SqlDbType.VarChar).Value = addedby;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "I";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable DeleteRep(string repid)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Representative_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@rep_id", SqlDbType.VarChar).Value = repid;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "D";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetDistrictsAcordingtoLogin(string Dist)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetNewDistcodeByLogin", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = "D";
                    da.SelectCommand.Parameters.Add("@dist_lgcode", SqlDbType.VarChar).Value = Dist;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public string GetSeasonbyMonth(string month)
        {
            string str = "0";
            string cmdText = "select season from Dtls_seasons where month='" + month + "'";
            SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString());
            SqlCommand command = new SqlCommand(cmdText, connection);
            connection.Open();
            string str3 = command.ExecuteScalar().ToString();
            if (str3 != null)
            {
                str = str3.ToString();
            }
            connection.Close();
            return str;
        }

        public DataTable GetNewMandals(string newdistcode)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetNewDistcodeByLogin", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = "M";
                    da.SelectCommand.Parameters.Add("@New_dist_webland_code", SqlDbType.VarChar).Value = newdistcode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetNewVillages(string newdistcode, string newmandcode)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetNewDistcodeByLogin", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = "V";
                    da.SelectCommand.Parameters.Add("@new_mand_code_webland", SqlDbType.VarChar).Value = newmandcode;
                    da.SelectCommand.Parameters.Add("@New_dist_webland_code", SqlDbType.VarChar).Value = newdistcode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }




        

 


        public DataTable GetRep(string state, string dist, string mand)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Representative_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = state;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.VarChar).Value = mand;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "R";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

        }

        public DataTable GetRepDetails(string repid)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                DataSet dataSet = new DataSet();
                new SqlDataAdapter("select Name,Designation,r.mobile,spcode,s.SalePtName from Dtls_Representative r left join Mst_SalePoints s on r.spcode=s.SalePtCode where Rep_Id='" + repid + "'", connection).Fill(dataSet, "desig");
                return dataSet.Tables["desig"];
            }
        }

        public DataTable UpdateRep(string state, string dist, string mand, string active, string name, string desig, string mobile, string sp, string repid, string user)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Representative_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = state;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.VarChar).Value = mand;
                    da.SelectCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                    da.SelectCommand.Parameters.Add("@desig", SqlDbType.VarChar).Value = desig;
                    da.SelectCommand.Parameters.Add("@mobile", SqlDbType.VarChar).Value = mobile;
                    da.SelectCommand.Parameters.Add("@spcode", SqlDbType.VarChar).Value = sp;
                    da.SelectCommand.Parameters.Add("@Active", SqlDbType.VarChar).Value = active;
                    da.SelectCommand.Parameters.Add("@rep_id", SqlDbType.VarChar).Value = repid;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = user;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "U";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

        }

        public DataTable InsertSeedAllotmentSP(string spstkid, string spcode, string alloted, string user, string agency, string year, string season, string crop, string dist, string mand)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Stock_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "X";
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = crop;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@agency", SqlDbType.VarChar).Value = agency;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@allotedQty", SqlDbType.VarChar).Value = alloted;
                    da.SelectCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                    da.SelectCommand.Parameters.Add("@sp_stock_id", SqlDbType.Int).Value = spstkid;
                    da.SelectCommand.Parameters.Add("@spcode", SqlDbType.Int).Value = spcode;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@mand", SqlDbType.VarChar).Value = mand;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable UpdateSeedAllotmentSP(string old, string updated, string spstkid, string allotid)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Stock_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "A";
                    da.SelectCommand.Parameters.Add("@allotedQty", SqlDbType.VarChar).Value = old;
                    da.SelectCommand.Parameters.Add("@updatedQty", SqlDbType.VarChar).Value = updated;
                    da.SelectCommand.Parameters.Add("@allotid", SqlDbType.VarChar).Value = allotid;
                    da.SelectCommand.Parameters.Add("@sp_stock_id", SqlDbType.VarChar).Value = spstkid;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable GetSeedAllotmentSP(string year, string season, string dist, string mand)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Stock_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "Y";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;
                    da.SelectCommand.Parameters.Add("@mand", SqlDbType.VarChar).Value = mand;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable DeleteSeedAllotmentSP(string allotid, string qty,string spstkid)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Stock_IUDR", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "B";
                    da.SelectCommand.Parameters.Add("@allotid", SqlDbType.VarChar).Value = allotid;
                    da.SelectCommand.Parameters.Add("@allotedQty", SqlDbType.VarChar).Value = qty;
                    da.SelectCommand.Parameters.Add("@sp_stock_id", SqlDbType.VarChar).Value = spstkid;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }




        public DataTable GetCropsMandalWise(string district, string mandal)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                DataSet dataSet = new DataSet();
                new SqlDataAdapter("select distinct s.crop,c.CropName from Dtls_SeedAllotment_Mandals s left join LR_CropMst c on s.crop=c.CropCode   where s.district='" + district + "' and s.mandal='" + mandal + "'", connection).Fill(dataSet, "CropV");
                return dataSet.Tables["CropV"];
            }
        }



        public DataTable GetCropsMandalWisenew(string district, string mandal,string cropcodes)
        {
            
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
            {
                DataSet dataSet = new DataSet();
                new SqlDataAdapter("select distinct s.crop,c.CropName from Dtls_SeedAllotment_Mandals s left join LR_CropMst c on s.crop=c.CropCode   where s.district='" + district + "' and s.mandal='" + mandal + "' and  s.crop not in(" + cropcodes + ") ", connection).Fill(dataSet, "CropV");
                return dataSet.Tables["CropV"];
            }
        }
      

 


    }
}
