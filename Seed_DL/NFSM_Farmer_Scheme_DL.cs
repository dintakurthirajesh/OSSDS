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
    public class NFSM_Farmer_Scheme_DL
    {
        //SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString());
        public DataTable InsertandupdateFarmerDetails(NFSM_Members obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("NFSM_InsertFarmer_IUR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@farmerid", SqlDbType.VarChar).Value = obj.farmerid;
                    da.SelectCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = obj.farmername;
                    da.SelectCommand.Parameters.Add("@relation", SqlDbType.VarChar).Value = obj.fatherorhusname;
                    da.SelectCommand.Parameters.Add("@caste", SqlDbType.VarChar).Value = obj.catstecd;
                    da.SelectCommand.Parameters.Add("@gender", SqlDbType.VarChar).Value = obj.gendercd;
                    da.SelectCommand.Parameters.Add("@statecd", SqlDbType.VarChar).Value = obj.statecd;
                    da.SelectCommand.Parameters.Add("@distcd", SqlDbType.VarChar).Value = obj.distcd;
                    da.SelectCommand.Parameters.Add("@mandcd", SqlDbType.VarChar).Value = obj.mandalcd;
                    da.SelectCommand.Parameters.Add("@villagecd", SqlDbType.VarChar).Value = obj.villagecd;
                    da.SelectCommand.Parameters.Add("@address", SqlDbType.VarChar).Value = obj.address;
                    da.SelectCommand.Parameters.Add("@adhar", SqlDbType.VarChar).Value = obj.aadharno;
                    da.SelectCommand.Parameters.Add("@mobile", SqlDbType.VarChar).Value = obj.mobileno;
                    da.SelectCommand.Parameters.Add("@emailid", SqlDbType.VarChar).Value = obj.emailid;
                    da.SelectCommand.Parameters.Add("@bankcd", SqlDbType.VarChar).Value = obj.bankcd;
                    da.SelectCommand.Parameters.Add("@ifsccd", SqlDbType.VarChar).Value = obj.ifsccode;
                    da.SelectCommand.Parameters.Add("@acno", SqlDbType.VarChar).Value = obj.accountno;
                    da.SelectCommand.Parameters.Add("@DiffAbled", SqlDbType.VarChar).Value = obj.DifferentlyAbled;
                    da.SelectCommand.Parameters.Add("@perDisability", SqlDbType.VarChar).Value = obj.percentDisability;
                    da.SelectCommand.Parameters.Add("@categorycd", SqlDbType.VarChar).Value = obj.categorycd;
                    da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = obj.userid;
                    da.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = obj.ipaddress;
                    da.SelectCommand.Parameters.Add("@nfsmportal", SqlDbType.VarChar).Value = "NFSM";
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = obj.Flag;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable InsertandupdateSchemeDetails(NFSM_Members obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Nfsm_schemefiling", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@farmerid", SqlDbType.VarChar).Value = obj.farmerid;
                    da.SelectCommand.Parameters.Add("@yearcd", SqlDbType.VarChar).Value = obj.yearcd;
                    da.SelectCommand.Parameters.Add("@schemetype", SqlDbType.VarChar).Value = obj.schemetype;
                    da.SelectCommand.Parameters.Add("@schemecd", SqlDbType.VarChar).Value = obj.schemecode;
                    da.SelectCommand.Parameters.Add("@subschemecd", SqlDbType.VarChar).Value = obj.subschemecode;
                    da.SelectCommand.Parameters.Add("@cropcd", SqlDbType.VarChar).Value = obj.cropcd;
                    da.SelectCommand.Parameters.Add("@intevcd", SqlDbType.VarChar).Value = obj.intervensioncd;
                    da.SelectCommand.Parameters.Add("@subintevcd", SqlDbType.VarChar).Value = obj.subintervensioncd;
                    da.SelectCommand.Parameters.Add("@itemcd", SqlDbType.VarChar).Value = obj.itemcd;
                    da.SelectCommand.Parameters.Add("@subitemcd", SqlDbType.VarChar).Value = obj.subitemcode;
                    da.SelectCommand.Parameters.Add("@agencycd", SqlDbType.VarChar).Value = obj.agencycd;
                    da.SelectCommand.Parameters.Add("@distcd", SqlDbType.VarChar).Value = obj.distcd;
                    da.SelectCommand.Parameters.Add("@fullcost", SqlDbType.VarChar).Value = obj.fullcost;
                    da.SelectCommand.Parameters.Add("@subsidyamt", SqlDbType.VarChar).Value = obj.subsidyamt;
                    da.SelectCommand.Parameters.Add("@nonsubsidyamt", SqlDbType.VarChar).Value = obj.nonsubsidyamt;
                    da.SelectCommand.Parameters.Add("@landtype", SqlDbType.VarChar).Value = obj.LandType;
                    da.SelectCommand.Parameters.Add("@landextent", SqlDbType.VarChar).Value = obj.landextent;
                    da.SelectCommand.Parameters.Add("@pattadharno", SqlDbType.VarChar).Value = obj.pattadharno;
                    da.SelectCommand.Parameters.Add("@bankcd", SqlDbType.VarChar).Value = obj.bankcd;
                    da.SelectCommand.Parameters.Add("@challanno", SqlDbType.VarChar).Value = obj.challanno;
                    da.SelectCommand.Parameters.Add("@challanamt", SqlDbType.Decimal).Value = obj.challanamount;
                    da.SelectCommand.Parameters.Add("@challandt", SqlDbType.Date).Value = obj.challandate;
                    da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = obj.userid;
                    da.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = obj.ipaddress;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = obj.Flag;

                    da.SelectCommand.Parameters.Add("@CategoryCode", SqlDbType.VarChar).Value = obj.categorycd;
                    da.SelectCommand.Parameters.Add("@firmcode", SqlDbType.VarChar).Value = obj.Firm_code;
                    //da.SelectCommand.Parameters.Add("@MaxLenth", SqlDbType.VarChar).Value = obj.MaxLength;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetFarmerBasicDetails(NFSM_Members obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("NFSM_InsertFarmer_IUR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@farmerid", SqlDbType.VarChar).Value = obj.farmerid;
                    da.SelectCommand.Parameters.Add("@statecd", SqlDbType.VarChar).Value = obj.statecd;
                    da.SelectCommand.Parameters.Add("@distcd", SqlDbType.VarChar).Value = obj.distcd;
                    da.SelectCommand.Parameters.Add("@mandcd", SqlDbType.VarChar).Value = obj.mandalcd;
                    da.SelectCommand.Parameters.Add("@villagecd", SqlDbType.VarChar).Value = obj.villagecd;

                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = "R";

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetSchemefilingDetailstoApprove(NFSM_Members obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("NFSM_GetSchemeFiling_det", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@farmerid", SqlDbType.VarChar).Value = obj.farmerid;
                    da.SelectCommand.Parameters.Add("@schemecd", SqlDbType.VarChar).Value = obj.schemecode;
                    da.SelectCommand.Parameters.Add("@subschemecd", SqlDbType.VarChar).Value = obj.subschemecode;
                    da.SelectCommand.Parameters.Add("@cropcd", SqlDbType.VarChar).Value = obj.cropcd;
                    da.SelectCommand.Parameters.Add("@intevcd", SqlDbType.VarChar).Value = obj.intervensioncd;
                    da.SelectCommand.Parameters.Add("@itemcd", SqlDbType.VarChar).Value = obj.itemcd;
                    da.SelectCommand.Parameters.Add("@subitemcd", SqlDbType.VarChar).Value = obj.subitemcode;
                    da.SelectCommand.Parameters.Add("@agencycd", SqlDbType.VarChar).Value = obj.agencycd;
                    da.SelectCommand.Parameters.Add("@distcd", SqlDbType.VarChar).Value = obj.distcd;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = obj.Flag;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable Update_Status_Schemefiling(DataTable Dt, string flag, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("NFSM_StatusUpdate", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@dt", SqlDbType.Structured).Value = Dt;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = flag;
                    Dt = new DataTable();
                    da.Fill(Dt);
                    return Dt;
                }
            }
        }

        public DataTable InsertschemeDocuments(NFSM_Members obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Nfsm_schemefiling_docs", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@farmerid", SqlDbType.VarChar).Value = obj.farmerid;
                    da.SelectCommand.Parameters.Add("@distcd", SqlDbType.VarChar).Value = obj.distcd;
                    da.SelectCommand.Parameters.Add("@yearcd", SqlDbType.VarChar).Value = obj.yearcd;
                    da.SelectCommand.Parameters.Add("@schemecd", SqlDbType.VarChar).Value = obj.schemecode;
                    da.SelectCommand.Parameters.Add("@subschemecd", SqlDbType.VarChar).Value = obj.subschemecode;
                    da.SelectCommand.Parameters.Add("@cropcd", SqlDbType.VarChar).Value = obj.cropcd;
                    da.SelectCommand.Parameters.Add("@intevcd", SqlDbType.VarChar).Value = obj.intervensioncd;
                    da.SelectCommand.Parameters.Add("@itemcd", SqlDbType.VarChar).Value = obj.itemcd;
                    da.SelectCommand.Parameters.Add("@subitemcd", SqlDbType.VarChar).Value = obj.subitemcode;
                    da.SelectCommand.Parameters.Add("@agencycd", SqlDbType.VarChar).Value = obj.agencycd;
                    da.SelectCommand.Parameters.Add("@doc_code", SqlDbType.VarChar).Value = obj.doc_code;
                    da.SelectCommand.Parameters.Add("@doc_type", SqlDbType.VarChar).Value = obj.doc_type;
                    da.SelectCommand.Parameters.Add("@upImage", SqlDbType.VarBinary).Value = obj.upImage;
                    da.SelectCommand.Parameters.Add("@invoice_other", SqlDbType.VarChar).Value = obj.invoice_other;
                    da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = obj.userid;
                    da.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = obj.ipaddress;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = obj.Flag;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable Getutilization_certi_supply_order_details(NFSM_Members obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("NFSM_Get_Agencyforwared_list", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@farmerid", SqlDbType.VarChar).Value = obj.farmerid;
                    da.SelectCommand.Parameters.Add("@schemecd", SqlDbType.VarChar).Value = obj.schemecode;
                    da.SelectCommand.Parameters.Add("@subschemecd", SqlDbType.VarChar).Value = obj.subschemecode;
                    da.SelectCommand.Parameters.Add("@cropcd", SqlDbType.VarChar).Value = obj.cropcd;
                    da.SelectCommand.Parameters.Add("@intevcd", SqlDbType.VarChar).Value = obj.intervensioncd;
                    da.SelectCommand.Parameters.Add("@itemcd", SqlDbType.VarChar).Value = obj.itemcd;
                    da.SelectCommand.Parameters.Add("@subitemcd", SqlDbType.VarChar).Value = obj.subitemcode;
                    da.SelectCommand.Parameters.Add("@agencycd", SqlDbType.VarChar).Value = obj.agencycd;
                    da.SelectCommand.Parameters.Add("@distcd", SqlDbType.VarChar).Value = obj.distcd;
                    da.SelectCommand.Parameters.Add("@mandcd", SqlDbType.VarChar).Value = obj.mandalcd;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = obj.Flag;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable Generateutilization_certi_supply(NFSM_Members obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("NFSM_UC_SO_Generate", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@distcd", SqlDbType.VarChar).Value = obj.distcd;
                    da.SelectCommand.Parameters.Add("@farmerid", SqlDbType.VarChar).Value = obj.farmerid;
                    da.SelectCommand.Parameters.Add("@yearcd", SqlDbType.VarChar).Value = obj.yearcd;
                    da.SelectCommand.Parameters.Add("@schemecd", SqlDbType.VarChar).Value = obj.schemecode;
                    da.SelectCommand.Parameters.Add("@subschemecd", SqlDbType.VarChar).Value = obj.subschemecode;
                    da.SelectCommand.Parameters.Add("@cropcd", SqlDbType.VarChar).Value = obj.cropcd;
                    da.SelectCommand.Parameters.Add("@intevcd", SqlDbType.VarChar).Value = obj.intervensioncd;
                    da.SelectCommand.Parameters.Add("@itemcd", SqlDbType.VarChar).Value = obj.itemcd;
                    da.SelectCommand.Parameters.Add("@agencycd", SqlDbType.VarChar).Value = obj.agencycd;
                    da.SelectCommand.Parameters.Add("@mandcd", SqlDbType.VarChar).Value = obj.mandalcd;
                    da.SelectCommand.Parameters.Add("@ucuid", SqlDbType.VarChar).Value = obj.uid;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = obj.Flag;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable UpdateNFSMChallanDetails(NFSM_Members obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("NFSM_UpdScheme_ChallanDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@distcd", SqlDbType.VarChar).Value = obj.distcd;
                    da.SelectCommand.Parameters.Add("@farmerid", SqlDbType.VarChar).Value = obj.farmerid;
                    da.SelectCommand.Parameters.Add("@yearcd", SqlDbType.VarChar).Value = obj.yearcd;
                    da.SelectCommand.Parameters.Add("@schemecd", SqlDbType.VarChar).Value = obj.schemecode;
                    da.SelectCommand.Parameters.Add("@cropcd", SqlDbType.VarChar).Value = obj.cropcd;
                    da.SelectCommand.Parameters.Add("@intevcd", SqlDbType.VarChar).Value = obj.intervensioncd;
                    da.SelectCommand.Parameters.Add("@itemcd", SqlDbType.VarChar).Value = obj.itemcd;
                    da.SelectCommand.Parameters.Add("@agencycd", SqlDbType.VarChar).Value = obj.agencycd;
                    da.SelectCommand.Parameters.Add("@mandcd", SqlDbType.VarChar).Value = obj.mandalcd;
                    da.SelectCommand.Parameters.Add("@ucuid", SqlDbType.VarChar).Value = obj.uid;
                    da.SelectCommand.Parameters.Add("@bankcd", SqlDbType.VarChar).Value = obj.bankcd;
                    da.SelectCommand.Parameters.Add("@challanno", SqlDbType.VarChar).Value = obj.challanno;
                    da.SelectCommand.Parameters.Add("@challanamt", SqlDbType.Decimal).Value = obj.challanamount;
                    da.SelectCommand.Parameters.Add("@challandt", SqlDbType.Date).Value = obj.challandate;


                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = "U";

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable NFSM_ItemWise_subsidyDetails(NFSM_Members obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Nfsm_Mst_Subsidy_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;


                    da.SelectCommand.Parameters.Add("@yearcd", SqlDbType.VarChar).Value = obj.yearcd;
                    da.SelectCommand.Parameters.Add("@schemecd", SqlDbType.VarChar).Value = obj.schemecode;
                    da.SelectCommand.Parameters.Add("@Component_code", SqlDbType.VarChar).Value = obj.Componentcode;
                    da.SelectCommand.Parameters.Add("@interven_code", SqlDbType.VarChar).Value = obj.intervensioncd;
                    da.SelectCommand.Parameters.Add("@Subinterven_code", SqlDbType.VarChar).Value = obj.subintervensioncd;
                    da.SelectCommand.Parameters.Add("@itemcd", SqlDbType.VarChar).Value = obj.itemcd;
                    da.SelectCommand.Parameters.Add("@Specific_code", SqlDbType.VarChar).Value = obj.subitemcode;
                    da.SelectCommand.Parameters.Add("@category_cd", SqlDbType.VarChar).Value = obj.categorycd;
                    da.SelectCommand.Parameters.Add("@fullcost", SqlDbType.VarChar).Value = obj.fullcost;
                    da.SelectCommand.Parameters.Add("@subsidyamt", SqlDbType.VarChar).Value = obj.subsidyamt;
                    da.SelectCommand.Parameters.Add("@nonsubsidyamt", SqlDbType.VarChar).Value = obj.nonsubsidyamt;
                    da.SelectCommand.Parameters.Add("@item_units", SqlDbType.VarChar).Value = obj.item_nos;
                    da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = obj.userid;
                    da.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = obj.ipaddress;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = obj.Flag;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable NFSM_ItemWiseCrop_subsidyDetails(NFSM_Members obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Nfsm_Mst_Subsidy_Crop_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@yearcd", SqlDbType.VarChar).Value = obj.yearcd;
                    da.SelectCommand.Parameters.Add("@schemecd", SqlDbType.VarChar).Value = obj.schemecode;
                    da.SelectCommand.Parameters.Add("@Component_code", SqlDbType.VarChar).Value = obj.Componentcode;
                    da.SelectCommand.Parameters.Add("@interven_code", SqlDbType.VarChar).Value = obj.intervensioncd;
                    da.SelectCommand.Parameters.Add("@Subinterven_code", SqlDbType.VarChar).Value = obj.subintervensioncd;
                    da.SelectCommand.Parameters.Add("@itemcd", SqlDbType.VarChar).Value = obj.itemcd;
                    da.SelectCommand.Parameters.Add("@Specific_code", SqlDbType.VarChar).Value = obj.subitemcode;
                    da.SelectCommand.Parameters.Add("@category_cd", SqlDbType.VarChar).Value = obj.categorycd;
                    da.SelectCommand.Parameters.Add("@fullcost", SqlDbType.VarChar).Value = obj.fullcost;
                    da.SelectCommand.Parameters.Add("@subsidyamt", SqlDbType.VarChar).Value = obj.subsidyamt;
                    da.SelectCommand.Parameters.Add("@nonsubsidyamt", SqlDbType.VarChar).Value = obj.nonsubsidyamt;
                    da.SelectCommand.Parameters.Add("@item_units", SqlDbType.VarChar).Value = obj.item_nos;
                    da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = obj.userid;
                    da.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = obj.ipaddress;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = obj.Flag;
                    da.SelectCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = obj.gendercd;
                    da.SelectCommand.Parameters.Add("@Perccentage", SqlDbType.VarChar).Value = obj.Percentage;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable NFSM_ItemWise_AgencysubsidyDetails(NFSM_Members obj, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Nfsm_Agency_Item_Subsidy_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;


                    da.SelectCommand.Parameters.Add("@yearcd", SqlDbType.VarChar).Value = obj.yearcd;
                    da.SelectCommand.Parameters.Add("@schemecd", SqlDbType.VarChar).Value = obj.schemecode;
                    da.SelectCommand.Parameters.Add("@Componentcd", SqlDbType.VarChar).Value = obj.Componentcode;
                    da.SelectCommand.Parameters.Add("@intevcd", SqlDbType.VarChar).Value = obj.intervensioncd;
                    da.SelectCommand.Parameters.Add("@Subinterven_code", SqlDbType.VarChar).Value = obj.subintervensioncd;
                    da.SelectCommand.Parameters.Add("@itemcd", SqlDbType.VarChar).Value = obj.itemcd;
                    da.SelectCommand.Parameters.Add("@subitemcd", SqlDbType.VarChar).Value = obj.subitemcode;
                    da.SelectCommand.Parameters.Add("@fullcost", SqlDbType.VarChar).Value = obj.fullcost;
                    da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = obj.userid;
                    da.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = obj.ipaddress;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = obj.Flag;
                    da.SelectCommand.Parameters.Add("@Firm_code", SqlDbType.VarChar).Value = obj.Firm_code;
                    da.SelectCommand.Parameters.Add("@agencycd", SqlDbType.VarChar).Value = obj.agencycd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetFinalUtilizationCertificatelist(DataTable Dt, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("NFSM_GetFinaluclist", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@dt", SqlDbType.Structured).Value = Dt;
                    Dt = new DataTable();
                    da.Fill(Dt);
                    return Dt;
                }
            }
        }
        public DataTable Update_SubsidyReleaseStatus(DataTable Dt, string flag, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("NFSM_SubsidyReleaseStatus_Update", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@dt", SqlDbType.Structured).Value = Dt;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = flag;
                    Dt = new DataTable();
                    da.Fill(Dt);
                    return Dt;
                }
            }
        }
    }
}
