using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_BL;
using Seed_BE;
using Seed_DL;
using System.Data;
using System.Web.Script.Serialization;
public partial class NFSM_MAO_SchemeFiling : System.Web.UI.Page
{
    MasterDAL objDist = new MasterDAL();
    CommonFuncs objCommon = new CommonFuncs();
    LocationBE objinsert = new LocationBE();
    Validate objValidate = new Validate();
    NFSM_MasterDL NfsmMaster = new NFSM_MasterDL();
    NFSM_Members nfsmobj = new NFSM_Members();
    NFSM_Farmer_Scheme_DL obj = new NFSM_Farmer_Scheme_DL();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
            {
                Response.Redirect("~/nfsm/Error.aspx");
            }
            else
            {
                string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
                string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
                int len = http_hos.Length;
                if (http_ref.IndexOf(http_hos, 0) < 0)
                {
                    Response.Redirect("~/nfsm/Error.aspx");
                }
            }
            if (Session["Rolecode"] == null)
            {
                Response.Redirect("~/nfsm/Error.aspx");
            }

            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            //clear Caching 
            PrevBrowCache.enforceNoCache();

            if (!IsPostBack)
            {
                lblUsrName.Text = Session["Role"].ToString();
                lblDist.Text = Session["district"].ToString();

                lblMand.Text = Session["mandal"].ToString();
                BindYear();
                BindCaste();
                BindScheme();
                BindBanks();
                BindAgency();
                pnlstateschemdetails.Visible = true;
                try
                {
                    GetAadhardetailsfromCGG.KharifCottonCropFarmerReportSoapClient objclient = new GetAadhardetailsfromCGG.KharifCottonCropFarmerReportSoapClient();

                    var serializer = new JavaScriptSerializer();
                    List<FarmerDetails> deserialized = serializer.Deserialize<List<FarmerDetails>>(objclient.GetFarmerDetailsByAadhar("NIC", "Nic20180112", Session["farmerid"].ToString()));

                    foreach (FarmerDetails item in deserialized)
                    {
                        txtlandextent.Text = item.TotalExtent;
                        txtsurveyno.Text = item.SurveyNo;

                    }
                }
                catch { }
                //ddlintervention.Items.Clear();
                //ddlitem.Items.Clear();

                //ddlintervention.Items.Insert(0, new ListItem("Select Intervensions", ""));
                //ddlitem.Items.Insert(0, new ListItem("Select Items", ""));


            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/nfsm/Error.aspx");
        }
    }
    protected void BindBanks()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.GetBanks(Session["constr"].ToString());
        objCommon.BindDropDownLists(ddlbank, dt, "BankName", "BankCode", "Select Bank");

    }
    protected void bindsubscheme()
    {
        DataTable dt = new DataTable();
        nfsmobj = new NFSM_Members();

        if (ddlyear.SelectedValue != "")
        {
            nfsmobj.yearcd = ddlyear.SelectedValue;
        }
        if (ddlscheme.SelectedValue != "")
        {
            nfsmobj.schemecode = ddlscheme.SelectedValue;
        }
        nfsmobj.Flag = "R";
        dt = NfsmMaster.insert_subScheme_IURD(nfsmobj, Session["constr"].ToString());
        objCommon.BindDropDownLists(ddlsubcheme, dt, "Component_name", "Component_code", "Select SubScheme");
        //objCommon.BindDropDownLists(ddlsubcheme, dt, "subscheme_name", "subscheme_Code", "Select SubScheme");
    }
    protected void BindYear()
    {
        int years;
        string yearcd = "";
        if (DateTime.Today.Month >= 4)
            years = DateTime.Today.Year;
        else
            years = DateTime.Today.Year - 1;

        yearcd = years.ToString().Substring(2, 2);
        DataTable dt = new DataTable();
        dt = NfsmMaster.GetFInYear(Session["constr"].ToString());
        if (dt.Rows.Count > 0)
        {
            objCommon.BindDropDownLists(ddlyear, dt, "year_desc", "year_code", "Select Fin Year");
            ddlyear.SelectedValue = yearcd.ToString();
            ddlyear.Enabled = true;
        }
    }
    protected void BindScheme()
    {
        DataTable dt = new DataTable();
        if (ddlyear.SelectedValue != "")
        {
            nfsmobj.yearcd = ddlyear.SelectedValue;
        }
        nfsmobj.Flag = "R";
        dt = NfsmMaster.insert_Scheme_IURD(nfsmobj, Session["constr"].ToString());

        objCommon.BindDropDownLists(ddlscheme, dt, "scheme_name", "scheme_code", "Select Scheme");
        ddlcroptype.Items.Clear();
        ddlintervention.Items.Clear();
        ddlitem.Items.Clear();
        ddlsubcheme.Items.Clear();
        ddlsubcheme.Items.Insert(0, new ListItem("Select SubScheme", ""));
        ddlcroptype.Items.Insert(0, new ListItem("Select Crop", ""));
        ddlintervention.Items.Insert(0, new ListItem("Select Intervensions", ""));
        ddlitem.Items.Insert(0, new ListItem("Select Items", ""));
        ddlsubitem.Items.Clear();
        ddlsubitem.Items.Insert(0, new ListItem("Select SubItem", ""));
    }
    protected void BindCrop()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.Get_Crop_IURD(ddlyear.SelectedValue, ddlscheme.SelectedValue, ddlsubcheme.SelectedValue, Session["constr"].ToString());
        objCommon.BindDropDownLists(ddlcroptype, dt, "crop_name", "crop_code", "Select Crop");
    }
    protected void Bindintervensions()
    {
        DataTable dtt = new DataTable();
        dtt = NfsmMaster.GetIntervension_Details(ddlyear.SelectedValue, ddlscheme.SelectedValue, ddlsubcheme.SelectedValue, ddlcroptype.SelectedValue, Session["constr"].ToString());
        objCommon.BindDropDownLists(ddlintervention, dtt, "interven_name", "interven_code", "Select Intervension");
    }
    protected void BindItems()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.GetItems_Details(ddlyear.SelectedValue, ddlscheme.SelectedValue, ddlsubcheme.SelectedValue, ddlcroptype.SelectedValue, ddlintervention.SelectedValue, Session["constr"].ToString());
        objCommon.BindDropDownLists(ddlitem, dt, "item_name", "item_code", "Select Items");
    }
    protected void BindCaste()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.GetCasteDetails(Session["constr"].ToString());
        objCommon.BindDropDownLists_withZero(ddlcategory, dt, "CasteName", "CasteCode", "Select Caste");
    }

    //protected void BindAgency()
    //{
    //    DataTable dt = new DataTable();
    //    string subitemcd = null;
    //    if (ddlsubitem.SelectedValue != "")
    //    { subitemcd = ddlsubitem.SelectedValue; }
    //    dt = NfsmMaster.GetAgency_Details(ddlyear.SelectedValue, ddlscheme.SelectedValue, ddlsubcheme.SelectedValue, ddlcroptype.SelectedValue, ddlintervention.SelectedValue, ddlitem.SelectedValue, subitemcd, Session["distCode"].ToString(), Session["constr"].ToString());
    //    objCommon.BindDropDownLists(ddlagency, dt, "agency_name", "agency_code", "Select Agency");
    //}   
    protected void BindAgency()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.GetAgency_Details(Session["constr"].ToString());
        objCommon.BindDropDownLists_withZero(ddlagency, dt, "agency_name", "agency_code", "Select Agency");
        ddlfirmname.Items.Clear();
        ddlfirmname.Items.Insert(0, new ListItem("Select Firm Name", "0"));
    }
    protected void BindSubsidydetails()
    {
        DataTable dt = new DataTable();
        string subitemcd = null;
        if (ddlsubitem.SelectedValue != "")
        { subitemcd = ddlsubitem.SelectedValue; }
        // dt = NfsmMaster.GetAgencyitemsubsidy_Details(ddlyear.SelectedValue, ddlscheme.SelectedValue, ddlsubcheme.SelectedValue, ddlcroptype.SelectedValue, "01", ddlitem.SelectedValue, subitemcd, ddlfirmname.SelectedValue, ddlagency.SelectedValue, Session["constr"].ToString());
        dt = NfsmMaster.GetAgencyitemsubsidyCrop_Details(ddlyear.SelectedValue, ddlscheme.SelectedValue, ddlsubcheme.SelectedValue, ddlcroptype.SelectedValue, "01", ddlitem.SelectedValue, subitemcd, ddlfirmname.SelectedValue, ddlagency.SelectedValue, Session["constr"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtitemfullcost.Text = dt.Rows[0]["UnitCostPercentage"].ToString();
            //txtitemfullcost.Text = dt.Rows[0]["itemFull_cost"].ToString();
            //txtnonSubsidyAmount.Text = (Convert.ToDecimal(dt.Rows[0]["UnitCostPercentage"].ToString()) - Convert.ToDecimal(dt.Rows[0]["subsidy_cost"].ToString())).ToString();// dt.Rows[0]["non_subsidy_cost"].ToString();

            txtsubsidyamt.Text = dt.Rows[0]["subsidy_cost"].ToString();
            if (Convert.ToDecimal(dt.Rows[0]["UnitCostPercentage"].ToString()) > Convert.ToDecimal(dt.Rows[0]["subsidy_cost"].ToString()))
            {
                txtnonSubsidyAmount.Text = (Convert.ToDecimal(dt.Rows[0]["UnitCostPercentage"].ToString()) - Convert.ToDecimal(dt.Rows[0]["subsidy_cost"].ToString())).ToString();
            }
            if (Convert.ToDecimal(dt.Rows[0]["UnitCostPercentage"].ToString()) < Convert.ToDecimal(dt.Rows[0]["subsidy_cost"].ToString()))
            {
                txtnonSubsidyAmount.Text = dt.Rows[0]["subsidy_cost"].ToString();
            }
            if (Convert.ToDecimal(dt.Rows[0]["UnitCostPercentage"].ToString()) == Convert.ToDecimal(dt.Rows[0]["subsidy_cost"].ToString()))
            {
                lblMaxLenght.Text = dt.Rows[0]["UnitCostPercentage"].ToString();
            }
        }
    }
    protected void ddlschemes_OnSelectedIndexChanged(object sender, EventArgs e)
    {

        pnlstateschemdetails.Visible = true;
        ddlscheme.SelectedValue = ddlscheme.SelectedValue;
        ddlscheme.Enabled = false;
        BindCrop();

        ddlintervention.Items.Clear();
        ddlitem.Items.Clear();

        ddlintervention.Items.Insert(0, new ListItem("Select Intervensions", ""));
        ddlitem.Items.Insert(0, new ListItem("Select Items", ""));
        ddlsubitem.Items.Clear();
        ddlsubitem.Items.Insert(0, new ListItem("Select SubItem", ""));

    }
    protected void ddlcroptype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcroptype.SelectedValue != "")
        {
            Bindintervensions();
            ddlitem.Items.Clear();
            ddlitem.Items.Insert(0, new ListItem("Select Items", ""));
            ddlagency.Items.Clear();
            ddlagency.Items.Insert(0, new ListItem("Select Agency", ""));
            ddlsubitem.Items.Clear();
            ddlsubitem.Items.Insert(0, new ListItem("Select SubItem", ""));
            txtsubsidyamt.Text = "";
            txtnonSubsidyAmount.Text = "";
            txtitemfullcost.Text = "";
        }
    }
    protected void ddlintervention_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlintervention.SelectedValue != "")
        {
            BindItems();
            ddlagency.Items.Clear();
            ddlagency.Items.Insert(0, new ListItem("Select Agency", ""));
            ddlsubitem.Items.Clear();
            ddlsubitem.Items.Insert(0, new ListItem("Select SubItem", ""));
            txtsubsidyamt.Text = "";
            txtnonSubsidyAmount.Text = "";
            txtitemfullcost.Text = "";
        }
    }
    protected void ddlscheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlscheme.SelectedValue != "")
        {
            bindsubscheme();
            ddlagency.Items.Clear();
            ddlagency.Items.Insert(0, new ListItem("Select Agency", ""));
            txtsubsidyamt.Text = "";
            txtnonSubsidyAmount.Text = "";
            txtitemfullcost.Text = "";
        }
    }
    protected void ddlitem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlitem.SelectedValue != "")
        {
            BindAgency();

            txtsubsidyamt.Text = "";
            txtnonSubsidyAmount.Text = "";
            txtitemfullcost.Text = "";
        }
        BindsubItems();
    }
    protected void ddlagency_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlagency.SelectedValue != "")
        {
            BindSubsidydetails();
            bindFIrm();
        }
    }
    protected void ddlsubcheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCrop();
        ddlintervention.Items.Clear();
        ddlitem.Items.Clear();
        ddlintervention.Items.Insert(0, new ListItem("Select Intervensions", ""));
        ddlitem.Items.Insert(0, new ListItem("Select Items", ""));
        ddlagency.Items.Clear();
        ddlagency.Items.Insert(0, new ListItem("Select Agency", ""));
        txtsubsidyamt.Text = "";
        txtnonSubsidyAmount.Text = "";
        txtitemfullcost.Text = "";
    }
    protected void BindsubItems()
    {
        DataTable dt = new DataTable();
        nfsmobj = new NFSM_Members();

        if (ddlyear.SelectedValue != "")
        {
            nfsmobj.yearcd = ddlyear.SelectedValue;
        }
        if (ddlsubcheme.SelectedValue != "")
        {
            nfsmobj.subschemecode = ddlsubcheme.SelectedValue;
        }
        if (ddlscheme.SelectedValue != "")
        {
            nfsmobj.schemecode = ddlscheme.SelectedValue;
        }
        if (ddlcroptype.SelectedValue != "")
        {
            nfsmobj.cropcd = ddlcroptype.SelectedValue;
        }
        if (ddlintervention.SelectedValue != "")
        {
            nfsmobj.intervensioncd = ddlintervention.SelectedValue;
        }
        if (ddlitem.SelectedValue != "")
        {
            nfsmobj.itemcd = ddlitem.SelectedValue;
        }
        nfsmobj.Flag = "R";
        dt = NfsmMaster.insert_SubItem_IURD(nfsmobj, Session["constr"].ToString());
        if (dt.Rows.Count > 0)
        {
            objCommon.BindDropDownLists(ddlsubitem, dt, "subitem_name", "subitem_code", "Select SubItems");

        }



    }
    protected void ddlsubitem_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindAgency();
    }
    protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void bindFIrm()
    {
        DataTable dt = new DataTable();
        nfsmobj = new NFSM_Members();

        if (ddlfirmname.SelectedValue != "")
        {
            nfsmobj.yearcd = ddlfirmname.SelectedValue;
        }
        if (ddlagency.SelectedValue != "")
        {
            nfsmobj.agencycd = ddlagency.SelectedValue;
        }
        nfsmobj.Flag = "R";
        dt = NfsmMaster.insert_MFGFirm_IURD(nfsmobj, Session["constr"].ToString());
        if (dt.Rows.Count > 0)
        {
            objCommon.BindDropDownLists_withZero(ddlfirmname, dt, "Firm_name", "Firm_code", "Select Firm Name");
        }
        else
        {
            ddlfirmname.ClearSelection();
        }
    }
    protected void ddlfirmname_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubsidydetails();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            nfsmobj.farmerid = Session["farmerid"].ToString();
            nfsmobj.distcd = Session["distcd"].ToString();
            nfsmobj.schemecode = ddlscheme.SelectedValue;
            nfsmobj.subschemecode = ddlsubcheme.SelectedValue;
            nfsmobj.cropcd = ddlcroptype.SelectedValue;
            nfsmobj.intervensioncd = ddlintervention.SelectedValue;

            nfsmobj.itemcd = ddlitem.SelectedValue;
            nfsmobj.agencycd = ddlagency.SelectedValue;
            nfsmobj.yearcd = ddlyear.SelectedValue;
            nfsmobj.schemetype = "S"; //rblscheme.SelectedValue;
            nfsmobj.fullcost = Convert.ToDecimal(txtitemfullcost.Text);
            nfsmobj.subsidyamt = Convert.ToDecimal(txtsubsidyamt.Text);
            nfsmobj.nonsubsidyamt = Convert.ToDecimal(txtnonSubsidyAmount.Text);
            nfsmobj.ipaddress = HttpContext.Current.Request.UserHostAddress;
            nfsmobj.userid = Session["UsrName"].ToString();
            nfsmobj.pattadharno = txtpattano.Text;
            nfsmobj.landextent = txtlandextent.Text;
            nfsmobj.LandType = ddllandtype.SelectedValue;
            nfsmobj.bankcd = ddlbank.SelectedValue;
            nfsmobj.challanamount = txtchallanamt.Text;
            nfsmobj.challanno = txtChallanno.Text;
            nfsmobj.challandate = txtDatePicker.Text;
            if (ddlsubitem.SelectedValue != "")
            {
                nfsmobj.subitemcode = ddlsubitem.SelectedValue;
            }
            else
            { nfsmobj.subitemcode = "0"; }
            nfsmobj.categorycd = ddlcategory.SelectedValue;
            nfsmobj.Firm_code = ddlfirmname.SelectedValue;
            nfsmobj.MaxLength = lblMaxLenght.Text;
            nfsmobj.Flag = "I";
            DataTable dt = new DataTable();
            dt = obj.InsertandupdateSchemeDetails(nfsmobj, Session["constr"].ToString());
            if (dt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                txtsubsidyamt.Text = "";
                txtnonSubsidyAmount.Text = "";
                txtitemfullcost.Text = "";
                BindYear();
                BindScheme();
                ddlcroptype.Items.Clear();
                ddlintervention.Items.Clear();
                ddlitem.Items.Clear();
                ddlcroptype.Items.Insert(0, new ListItem("Select Crop", ""));
                ddlintervention.Items.Insert(0, new ListItem("Select Intervensions", ""));
                ddlitem.Items.Insert(0, new ListItem("Select Items", ""));

                pnlstateschemdetails.Visible = true;
                ddlscheme.SelectedValue = ddlscheme.SelectedValue;
                ddlscheme.Enabled = false;
                BindCrop();

                ddlintervention.Items.Clear();
                ddlitem.Items.Clear();

                ddlintervention.Items.Insert(0, new ListItem("Select Intervensions", ""));
                ddlitem.Items.Insert(0, new ListItem("Select Items", ""));
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            //Response.Redirect("~/nfsm/Error.aspx");
        }
    }
}