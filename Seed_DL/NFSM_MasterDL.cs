using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Seed_BE;
namespace Seed_DL
{
   public  class NFSM_MasterDL
    {
      //  SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString());
        public DataTable GetFInYear(string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Nfsm_Year_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = "R";

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable insert_year_IURD(NFSM_Members Obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Nfsm_Year_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = Obj.Flag;
                    da.SelectCommand.Parameters.Add("@yearcd", SqlDbType.VarChar).Value = Obj.yearcd;
                    da.SelectCommand.Parameters.Add("@yeardesc", SqlDbType.VarChar).Value = Obj.yeardesc;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable get_NFSMSchemeDetails(string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Nfsm_Scheme_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = "R";

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable insert_Scheme_IURD(NFSM_Members Obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Nfsm_Scheme_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@schemecd ", SqlDbType.VarChar).Value = Obj.schemecode;
                    da.SelectCommand.Parameters.Add("@schemename", SqlDbType.VarChar).Value = Obj.schemename;
                  
                    da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = Obj.userid;
                    da.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = Obj.ipaddress;                  
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = Obj.Flag;          
                   
                 
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable Get_Crop_IURD(string yearcode, string schemecode,string subschemecode, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Nfsm_CropDetails_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = "R";
                    da.SelectCommand.Parameters.Add("@yearcd", SqlDbType.VarChar).Value = yearcode;
                    da.SelectCommand.Parameters.Add("@schemecd", SqlDbType.VarChar).Value = schemecode;
                    da.SelectCommand.Parameters.Add("@subschemecd", SqlDbType.VarChar).Value = subschemecode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetIntervension_Details(string yearcode, string schemecode, string subschemecode, string cropcode, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Nfsm_Intervensions_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = "R";
                    da.SelectCommand.Parameters.Add("@yearcd", SqlDbType.VarChar).Value = yearcode;
                    da.SelectCommand.Parameters.Add("@schemecd", SqlDbType.VarChar).Value = schemecode;
                    da.SelectCommand.Parameters.Add("@subschemecd", SqlDbType.VarChar).Value = subschemecode;
                    da.SelectCommand.Parameters.Add("@Cropcode", SqlDbType.VarChar).Value = cropcode;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetItems_Details(string yearcode, string schemecode, string subschemecode, string cropcode, string intervencd, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Nfsm_Items_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = "R";
                    da.SelectCommand.Parameters.Add("@yearcd", SqlDbType.VarChar).Value = yearcode;
                    da.SelectCommand.Parameters.Add("@schemecd", SqlDbType.VarChar).Value = schemecode;
                    da.SelectCommand.Parameters.Add("@subinterven_code", SqlDbType.VarChar).Value = subschemecode;
                    da.SelectCommand.Parameters.Add("@Cropcode", SqlDbType.VarChar).Value = cropcode;
                    da.SelectCommand.Parameters.Add("@interven_code", SqlDbType.VarChar).Value = intervencd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetAgency_Details(string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("NFSM_Agency_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = "R";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetAgency_Details(string yearcode, string schemecode,string subschemecode, string cropcode, string intervencd, string itemcd,string subitemcd, string districtcd, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("NFSM_Agency_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = "RM";
                    da.SelectCommand.Parameters.Add("@yearcd", SqlDbType.VarChar).Value = yearcode;
                    da.SelectCommand.Parameters.Add("@schemecd", SqlDbType.VarChar).Value = schemecode;
                    da.SelectCommand.Parameters.Add("@subschemecd", SqlDbType.VarChar).Value = subschemecode;
                    da.SelectCommand.Parameters.Add("@Cropcode", SqlDbType.VarChar).Value = cropcode;
                    da.SelectCommand.Parameters.Add("@interven_code", SqlDbType.VarChar).Value = intervencd;
                    da.SelectCommand.Parameters.Add("@item_code", SqlDbType.VarChar).Value = itemcd;
                    da.SelectCommand.Parameters.Add("@subitem_code", SqlDbType.VarChar).Value = subitemcd;
                    da.SelectCommand.Parameters.Add("@distcd", SqlDbType.VarChar).Value = districtcd;
                    

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetAgencyitemsubsidy_Details(string yearcode, string schemecode, string subschemecode, string cropcode, string intervencd, string itemcd, string subitemcd, string districtcd, string agencycode, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("NFSM_Agency_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = "RS";
                    da.SelectCommand.Parameters.Add("@yearcd", SqlDbType.VarChar).Value = yearcode;
                    da.SelectCommand.Parameters.Add("@schemecd", SqlDbType.VarChar).Value = schemecode;
                    da.SelectCommand.Parameters.Add("@subschemecd", SqlDbType.VarChar).Value = subschemecode;
                    da.SelectCommand.Parameters.Add("@Cropcode", SqlDbType.VarChar).Value = cropcode;
                    da.SelectCommand.Parameters.Add("@interven_code", SqlDbType.VarChar).Value = intervencd;
                    da.SelectCommand.Parameters.Add("@item_code", SqlDbType.VarChar).Value = itemcd;
                    da.SelectCommand.Parameters.Add("@subitem_code", SqlDbType.VarChar).Value = subitemcd;
                    da.SelectCommand.Parameters.Add("@distcd", SqlDbType.VarChar).Value = districtcd;
                    da.SelectCommand.Parameters.Add("@agencycd", SqlDbType.VarChar).Value = agencycode;


                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetAgencyitemsubsidyCrop_Details(string yearcode, string schemecode, string subschemecode, string cropcode, string intervencd, string itemcd, string subitemcd, string districtcd, string agencycode, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("NFSM_Agency_Crop_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = "RS";
                    da.SelectCommand.Parameters.Add("@yearcd", SqlDbType.VarChar).Value = yearcode;
                    da.SelectCommand.Parameters.Add("@schemecd", SqlDbType.VarChar).Value = schemecode;
                    da.SelectCommand.Parameters.Add("@subschemecd", SqlDbType.VarChar).Value = subschemecode;
                    da.SelectCommand.Parameters.Add("@Cropcode", SqlDbType.VarChar).Value = cropcode;
                    da.SelectCommand.Parameters.Add("@interven_code", SqlDbType.VarChar).Value = intervencd;
                    da.SelectCommand.Parameters.Add("@item_code", SqlDbType.VarChar).Value = itemcd;
                    da.SelectCommand.Parameters.Add("@subitem_code", SqlDbType.VarChar).Value = subitemcd;
                    da.SelectCommand.Parameters.Add("@distcd", SqlDbType.VarChar).Value = districtcd;
                    da.SelectCommand.Parameters.Add("@agencycd", SqlDbType.VarChar).Value = agencycode;


                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable Getlocationdet(LocationBE Obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
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
        }

        public DataTable GetGender(string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter dam = new SqlDataAdapter("select * from DBT_Mst_Gender where GenderCode is not null ", con);
                dam.Fill(ds, "gender");
                return ds.Tables["gender"];
            }
          
        }
        public DataTable GetCasteDetails(string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter dam = new SqlDataAdapter("select * from DBT_Mst_Caste where CasteCode is not null order by CasteName asc ", con);
                dam.Fill(ds, "caste");
                return ds.Tables["caste"];
            }
        }
        public DataTable GetCategoryDetails(string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter dam = new SqlDataAdapter("select * from NFSM_Mst_Category where Category_Code is not null order by Category_Name ASc", con);
                dam.Fill(ds, "category");
                return ds.Tables["category"];
            }

        }
        public DataTable GetBanks(string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter dam = new SqlDataAdapter("select * from Mst_Bank where BankCode is not null order by bankname asc ", con);
                dam.Fill(ds, "bank");
                return ds.Tables["bank"];
            }

        }
        public DataTable insert_subScheme_IURD(NFSM_Members Obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Nfsm_Component_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@schemecd ", SqlDbType.VarChar).Value = Obj.schemecode;
                    da.SelectCommand.Parameters.Add("@Componentcd", SqlDbType.VarChar).Value = Obj.Componentcode;
                    da.SelectCommand.Parameters.Add("@Component_name", SqlDbType.VarChar).Value = Obj.Componentname;
                    da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = Obj.userid;
                    da.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = Obj.ipaddress;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = Obj.Flag;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable insert_crop_IURD(NFSM_Members Obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Nfsm_Intervention_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@schemecd ", SqlDbType.VarChar).Value = Obj.schemecode;
                    da.SelectCommand.Parameters.Add("@Componentcd", SqlDbType.VarChar).Value = Obj.Componentcode;
                    da.SelectCommand.Parameters.Add("@interven_code", SqlDbType.VarChar).Value = Obj.intervensioncd;
                    da.SelectCommand.Parameters.Add("@interven_name", SqlDbType.VarChar).Value = Obj.intervensionname;                  
                    da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = Obj.userid;
                    da.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = Obj.ipaddress;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = Obj.Flag;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable insert_SubIntervention_IURD(NFSM_Members Obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Nfsm_SubIntervention_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = Obj.Flag;
                    da.SelectCommand.Parameters.Add("@schemecd", SqlDbType.VarChar).Value = Obj.schemecode;
                    da.SelectCommand.Parameters.Add("@Componentcd", SqlDbType.VarChar).Value = Obj.Componentcode;
                    da.SelectCommand.Parameters.Add("@interven_code", SqlDbType.VarChar).Value = Obj.intervensioncd;
                    da.SelectCommand.Parameters.Add("@subinterven_code", SqlDbType.VarChar).Value = Obj.subintervensioncd;
                    da.SelectCommand.Parameters.Add("@subinterven_name", SqlDbType.VarChar).Value = Obj.subintervensionname;
                    da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = Obj.userid;
                    da.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = Obj.ipaddress;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable insert_Item_IURD(NFSM_Members Obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Nfsm_Items_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = Obj.Flag;
                    da.SelectCommand.Parameters.Add("@schemecd", SqlDbType.VarChar).Value = Obj.schemecode;
                    da.SelectCommand.Parameters.Add("@Componentcd", SqlDbType.VarChar).Value = Obj.Componentcode;
                    da.SelectCommand.Parameters.Add("@interven_code", SqlDbType.VarChar).Value = Obj.intervensioncd;
                    da.SelectCommand.Parameters.Add("@subinterven_code", SqlDbType.VarChar).Value = Obj.subintervensioncd;
                    da.SelectCommand.Parameters.Add("@item_code", SqlDbType.VarChar).Value = Obj.itemcd;
                    da.SelectCommand.Parameters.Add("@item_name", SqlDbType.VarChar).Value = Obj.itemname;
                    da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = Obj.userid;
                    da.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = Obj.ipaddress;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable insert_SubItem_IURD(NFSM_Members Obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Nfsm_SubItems_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = Obj.Flag;
                    da.SelectCommand.Parameters.Add("@schemecd", SqlDbType.VarChar).Value = Obj.schemecode;
                    da.SelectCommand.Parameters.Add("@Componentcd", SqlDbType.VarChar).Value = Obj.Componentcode;
                    da.SelectCommand.Parameters.Add("@interven_code", SqlDbType.VarChar).Value = Obj.intervensioncd;
                    da.SelectCommand.Parameters.Add("@subinterven_code", SqlDbType.VarChar).Value = Obj.subintervensioncd;
                    da.SelectCommand.Parameters.Add("@item_code", SqlDbType.VarChar).Value = Obj.itemcd;
                    da.SelectCommand.Parameters.Add("@subitem_code", SqlDbType.VarChar).Value = Obj.subitemcode;
                    da.SelectCommand.Parameters.Add("@subitem_name", SqlDbType.VarChar).Value = Obj.itemname;
                    da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = Obj.userid;
                    da.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = Obj.ipaddress;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable insert_MFGFirm_IURD(NFSM_Members Obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("NFSM_MFGFirmIUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@distcd", SqlDbType.VarChar).Value = Obj.distcd;
                    da.SelectCommand.Parameters.Add("@firmName", SqlDbType.VarChar).Value = Obj.FirmName;
                    da.SelectCommand.Parameters.Add("@Firm_code", SqlDbType.VarChar).Value = Obj.Firm_code;
                    da.SelectCommand.Parameters.Add("@phoneNo", SqlDbType.VarChar).Value = Obj.phoneNo;
                   
                    da.SelectCommand.Parameters.Add("@address", SqlDbType.VarChar).Value = Obj.address;
                    da.SelectCommand.Parameters.Add("@pincode", SqlDbType.VarChar).Value = Obj.pattadharno;
                    da.SelectCommand.Parameters.Add("@mobileno", SqlDbType.VarChar).Value = Obj.mobileno;
                    da.SelectCommand.Parameters.Add("@bankname", SqlDbType.VarChar).Value = Obj.bankcd;
                    da.SelectCommand.Parameters.Add("@ifsccd", SqlDbType.VarChar).Value = Obj.ifsccode;
                    da.SelectCommand.Parameters.Add("@accountno", SqlDbType.VarChar).Value = Obj.accountno;
                    da.SelectCommand.Parameters.Add("@agencycd", SqlDbType.VarChar).Value = Obj.agencycd;
                    da.SelectCommand.Parameters.Add("@yearcd", SqlDbType.VarChar).Value = Obj.yearcd;
                    da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = Obj.userid;
                    da.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = Obj.ipaddress;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = Obj.Flag;


                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable insert_Agencymaster_IURD(NFSM_Members Obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("NFSM_AgencyIUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@agencyname", SqlDbType.VarChar).Value = Obj.agencyname;
                    da.SelectCommand.Parameters.Add("@agencycd", SqlDbType.VarChar).Value = Obj.agencycd;
                    da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = Obj.userid;
                    da.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = Obj.ipaddress;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = Obj.Flag;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
