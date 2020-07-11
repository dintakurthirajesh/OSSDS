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
using System.Text;
public partial class NFSM_MAO_SchemeFilingSearch : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            lblUsrName.Text = Session["Role"].ToString();
            lblDist.Text = Session["district"].ToString();            
            BindYear();
            BindScheme();
            loadgridview();
           
        }
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
        objCommon.BindDropDownLists(ddlyear, dt, "year_desc", "year_code", "Select Fin Year");
        ddlyear.SelectedValue = yearcd.ToString();
        ddlyear.Enabled = false;
    }
    protected void BindScheme()
    {
        DataTable dt = new DataTable();
        nfsmobj = new NFSM_Members();

        if (ddlyear.SelectedValue != "")
        {
            nfsmobj.yearcd = ddlyear.SelectedValue;
        }
        nfsmobj.Flag = "R";
        dt = NfsmMaster.insert_Scheme_IURD(nfsmobj, Session["constr"].ToString());

        objCommon.BindDropDownLists(ddlscheme, dt, "scheme_name", "scheme_code", "Select Scheme");
        ddlCroptype.Items.Clear();
        ddlintervenstion.Items.Clear();
        ddlitem.Items.Clear();
        ddlsubcheme.Items.Clear();
        ddlsubcheme.Items.Insert(0, new ListItem("Select SubScheme", ""));
        ddlCroptype.Items.Insert(0, new ListItem("Select Crop", ""));
        ddlintervenstion.Items.Insert(0, new ListItem("Select Intervensions", ""));
        ddlitem.Items.Insert(0, new ListItem("Select Items", ""));
        ddlsubitem.Items.Clear();
        ddlsubitem.Items.Insert(0, new ListItem("Select SubItem", ""));
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
        objCommon.BindDropDownLists(ddlsubcheme, dt, "subscheme_name", "subscheme_Code", "Select SubScheme");


    }
    protected void BindCrop()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.Get_Crop_IURD(ddlyear.SelectedValue, ddlscheme.SelectedValue,ddlsubcheme.SelectedValue, Session["constr"].ToString());
        objCommon.BindDropDownLists(ddlCroptype, dt, "crop_name", "crop_code", "Select Crop");
        ddlsubitem.Items.Clear();
        ddlsubitem.Items.Insert(0, new ListItem("Select SubItem", ""));
    }
    protected void Bindintervensions()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.GetIntervension_Details(ddlyear.SelectedValue, ddlscheme.SelectedValue, ddlsubcheme.SelectedValue, ddlCroptype.SelectedValue, Session["constr"].ToString());
        objCommon.BindDropDownLists(ddlintervenstion, dt, "interven_name", "interven_code", "Select Intervension");
        ddlsubitem.Items.Clear();
        ddlsubitem.Items.Insert(0, new ListItem("Select SubItem", ""));
    }
    protected void BindItems()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.GetItems_Details(ddlyear.SelectedValue, ddlscheme.SelectedValue, ddlsubcheme.SelectedValue, ddlCroptype.SelectedValue, ddlintervenstion.SelectedValue, Session["constr"].ToString());
        objCommon.BindDropDownLists(ddlitem, dt, "item_name", "item_code", "Select Items");
    }
    protected void BindAgency()
    {
        DataTable dt = new DataTable();
        string subitemcd = null;
        dt = NfsmMaster.GetAgency_Details(ddlyear.SelectedValue, ddlscheme.SelectedValue, ddlsubcheme.SelectedValue, ddlCroptype.SelectedValue, ddlintervenstion.SelectedValue, ddlitem.SelectedValue, subitemcd, Session["distCode"].ToString(), Session["constr"].ToString());
        objCommon.BindDropDownLists(ddlagency, dt, "agency_name", "agency_code", "Select Agency");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        loadgridview();
    }

    private void loadgridview()
    {
        DataTable dt = new DataTable();

        nfsmobj = new NFSM_Members();
        if (Session["distCode"] != null)
        {
            if (Session["distCode"].ToString() != "")
            {
                nfsmobj.distcd = Session["distCode"].ToString();
            }
        }
        if (ddlscheme.SelectedValue != "")
        {
            nfsmobj.schemecode = ddlscheme.SelectedValue;
        }
        if (ddlsubcheme.SelectedValue != "")
        {
            nfsmobj.subschemecode = ddlsubcheme.SelectedValue;
        }
        if (ddlCroptype.SelectedValue != "")
        {
            nfsmobj.cropcd = ddlCroptype.SelectedValue;
        }
        if (ddlintervenstion.SelectedValue != "")
        {
            nfsmobj.intervensioncd = ddlintervenstion.SelectedValue;
        }
        if (ddlitem.SelectedValue != "")
        {
            nfsmobj.itemcd = ddlitem.SelectedValue;
        }
        if (ddlyear.SelectedValue != "")
        {
            nfsmobj.yearcd = ddlyear.SelectedValue;
        }
        if (ddlagency.SelectedValue != "")
        {
            nfsmobj.agencycd = ddlagency.SelectedValue;
        }
        if (ddlsubitem.SelectedValue != "")
        {
            nfsmobj.subitemcode = ddlsubitem.SelectedValue;
        }
        nfsmobj.Flag = "DAOS";
        dt = obj.Getutilization_certi_supply_order_details(nfsmobj, Session["constr"].ToString());
        if (dt.Rows.Count > 0)
        {

            gvschmefiling.DataSource = dt;
            gvschmefiling.DataBind();
            gvschmefiling.Visible = true;
            btnsubmit.Visible = true;
        }
        else
        {
            gvschmefiling.Visible = false;
            btnsubmit.Visible = false;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        BindYear();
        BindScheme();
        ddlCroptype.Items.Clear();
        ddlCroptype.Items.Insert(0, new ListItem("Select Crop Type", ""));
        ddlintervenstion.Items.Clear();
        ddlintervenstion.Items.Insert(0, new ListItem("Select Intervension", ""));
        ddlitem.Items.Clear();
        ddlitem.Items.Insert(0, new ListItem("Select Items", ""));
        ddlagency.Items.Clear();
        ddlagency.Items.Insert(0, new ListItem("Select Agency", ""));
        txtfarmerid.Text = "";
        gvschmefiling.Visible = false;
        btnsubmit.Visible = false;
    }
    protected void ddlscheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlscheme.SelectedValue != "")
        {
            bindsubscheme();
        }

    }
    protected void ddlCroptype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCroptype.SelectedValue != "")
        {
            Bindintervensions();
            ddlitem.Items.Clear();
            ddlitem.Items.Insert(0, new ListItem("Select Items", ""));
            ddlagency.Items.Clear();
            ddlagency.Items.Insert(0, new ListItem("Select Agency", ""));
            txtfarmerid.Text = "";
        }
    }
    protected void ddlintervenstion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlintervenstion.SelectedValue != "")
        {
            BindItems();

            ddlagency.Items.Clear();
            ddlagency.Items.Insert(0, new ListItem("Select Agency", ""));
            txtfarmerid.Text = "";
        }
    }
    protected void ddlitem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlitem.SelectedValue != "")
        {
            BindAgency();
            BindsubItems();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtforward = new DataTable();
            dtforward.Columns.Add("yearcd", typeof(string));
            dtforward.Columns.Add("farmer_id", typeof(string));
            dtforward.Columns.Add("schemecd", typeof(string));
            dtforward.Columns.Add("subschemecd", typeof(string));
            dtforward.Columns.Add("cropcd", typeof(string));
            dtforward.Columns.Add("intervencd", typeof(string));
            dtforward.Columns.Add("itemcd", typeof(string));
            dtforward.Columns.Add("subitemcd", typeof(string));
            dtforward.Columns.Add("refno", typeof(string));
            dtforward.Columns.Add("amount", typeof(string));
            dtforward.Columns.Add("refdate", typeof(DateTime));
            dtforward.Columns.Add("status_app", typeof(string));
            dtforward.Columns.Add("flag", typeof(string));
            int j = 0;
            foreach (GridViewRow gr in gvschmefiling.Rows)
            {
                if (((CheckBox)gr.FindControl("chkapprove")).Checked == true)
                {
                    dtforward.Rows.Add();
                    dtforward.Rows[j]["yearcd"] = ((Label)gr.FindControl("lblyearcd")).Text.Trim();
                    dtforward.Rows[j]["farmer_id"] = ((Label)gr.FindControl("lblfarmerid")).Text.Trim();
                    dtforward.Rows[j]["schemecd"] = ((Label)gr.FindControl("lblschemecode")).Text.Trim();
                    dtforward.Rows[j]["subschemecd"] = ((Label)gr.FindControl("lblsubschemecode")).Text.Trim();
                    dtforward.Rows[j]["cropcd"] = ((Label)gr.FindControl("lblcropcode")).Text.Trim();
                    dtforward.Rows[j]["intervencd"] = ((Label)gr.FindControl("lblintercode")).Text.Trim();
                    dtforward.Rows[j]["itemcd"] = ((Label)gr.FindControl("lblitemcode")).Text.Trim();
                    dtforward.Rows[j]["subitemcd"] = ((Label)gr.FindControl("lblsubitemcode")).Text.Trim();
                    dtforward.Rows[j]["refno"] = ((TextBox)gr.FindControl("txtrefno")).Text.Trim();
                    dtforward.Rows[j]["amount"] = ((TextBox)gr.FindControl("txtamount")).Text.Trim();
                    dtforward.Rows[j]["refdate"] = ((TextBox)gr.FindControl("txtrefdate")).Text.Trim();
                    dtforward.Rows[j]["status_app"] = "1";

                    dtforward.Rows[j]["flag"] = "DAOS";

                    j++;
                }
            }
            if (dtforward.Rows.Count > 0)
            {
                DataTable dt = new DataTable();

                dt = obj.Update_SubsidyReleaseStatus(dtforward, "DAOS", Session["constr"].ToString());
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage("Subsidy Release for selected Beneficiarys");
                    loadgridview();
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/nfsm/Error.aspx");

        }
    }
  
    

    protected void linkview_OnClick(object sender, EventArgs e)
    {
        GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;
        Label lbldistcode = (Label)gv.FindControl("lblDistCode");
        Label lblfarmerid = (Label)gv.FindControl("lblfarmerid");
        Label lbldistcd = (Label)gv.FindControl("lblDistCode");
        Label lblschemecd = (Label)gv.FindControl("lblschemecode");
        Label lblcropcd = (Label)gv.FindControl("lblcropcode");
        Label lblintervensioncd = (Label)gv.FindControl("lblintercode");
        Label lblitemcd = (Label)gv.FindControl("lblitemcode");
        Label lblyearcd = (Label)gv.FindControl("lblyearcd");
        Label lblagencycd = (Label)gv.FindControl("lblagencycd");


        nfsmobj = new NFSM_Members();
        nfsmobj.distcd = lbldistcode.Text;


        nfsmobj.schemecode = lblschemecd.Text.Trim();

        nfsmobj.subschemecode = ((Label)gv.FindControl("lblsubschemecode")).Text.Trim(); ;


        nfsmobj.cropcd = lblcropcd.Text;

        nfsmobj.intervensioncd = lblintervensioncd.Text;

        nfsmobj.itemcd = lblitemcd.Text;

        nfsmobj.yearcd = lblyearcd.Text;

        nfsmobj.agencycd = lblagencycd.Text;

        nfsmobj.Flag = "Far";
        DataTable dt = new DataTable();
        dt = obj.GetSchemefilingDetailstoApprove(nfsmobj, Session["constr"].ToString());
        if (dt.Rows.Count > 0)
        {
            try
            {
                txtname.Text = dt.Rows[0]["Farmer_Name"].ToString();
                txtfathername.Text = dt.Rows[0]["Father_Name"].ToString();
                txtmobileno.Text = dt.Rows[0]["mobile"].ToString();
                txtpaadharno.Text = dt.Rows[0]["AadharNo"].ToString();
                txtaddress.Text = dt.Rows[0]["address"].ToString();
                txtemailid.Text = dt.Rows[0]["emailid"].ToString();
                txtifsccode.Text = dt.Rows[0]["ifsc"].ToString();
                txtbankaccount.Text = dt.Rows[0]["acno"].ToString();
                txtperdisal.Text = dt.Rows[0]["perDisability"].ToString();
                rbldiff.SelectedValue = dt.Rows[0]["DiffAbled"].ToString();
                BindGender();
                ddlgender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                BindCaste();
                ddlCaste.SelectedValue = dt.Rows[0]["Caste"].ToString();
                BindCategory();
                ddlcategory.SelectedValue = dt.Rows[0]["categorycd"].ToString();
                BindStates();
                ddlstate.SelectedValue = Session["StateCode"].ToString();
                getDistrictDtls();
                try
                {
                    ddldistrict.SelectedValue = dt.Rows[0]["DistCode"].ToString();
                }
                catch { }
                getMandalDtls();
                try
                {
                    ddlmandal.SelectedValue = dt.Rows[0]["MandCode"].ToString();
                }
                catch { }
                getVillageDtls();
                try
                {
                    ddlvillage.SelectedValue = dt.Rows[0]["VillCode"].ToString();
                }
                catch { }
                BindBanks();
                ddlbank.SelectedValue = dt.Rows[0]["bank"].ToString();
                Popup(true);
            }
            catch { }
        }
        else { Popup(false); }
    }
    protected void btnclose1_Click(object sender, EventArgs e)
    {
        Popup(false);
    }
    protected void BindCaste()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.GetCasteDetails(Session["constr"].ToString());
        objCommon.BindDropDownLists(ddlCaste, dt, "CasteName", "CasteCode", "Select Caste");

    }
    protected void BindCategory()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.GetCategoryDetails(Session["constr"].ToString());
        objCommon.BindDropDownLists(ddlcategory, dt, "Category_Name", "Category_Code", "Select Category");

    }
    protected void BindBanks()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.GetBanks(Session["constr"].ToString());
        objCommon.BindDropDownLists(ddlbank, dt, "BankName", "BankCode", "Select Bank");

    }
    protected void BindGender()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.GetGender(Session["constr"].ToString());
        objCommon.BindDropDownLists(ddlgender, dt, "GenderName", "GenderCode", "Select Gender");

    }
    protected void BindStates()
    {
        DataTable dt = new DataTable();
        dt = objDist.getStates();
        objCommon.BindDropDownLists(ddlstate, dt, "StateName", "StateCode", "Select State");
        ddlstate.Enabled = false;
        ddlstate.SelectedValue = "36";
    }
    protected void getDistrictDtls()
    {
        DataTable dtDistricts = new DataTable();
        objinsert.Flage = "Dis";
        objinsert.statecd = ddlstate.SelectedValue;
        dtDistricts = NfsmMaster.Getlocationdet(objinsert, Session["constr"].ToString());
        dtDistricts.DefaultView.Sort = " DistName Asc ";
        objCommon.BindDropDownLists(ddldistrict, dtDistricts, "DistName", "DistCode_Lg", "Select District");

    }
    protected void getMandalDtls()
    {
        DataTable dtDistricts = new DataTable();
        objinsert.Flage = "Man";
        objinsert.statecd = ddlstate.SelectedValue;
        objinsert.distlgcd = ddldistrict.SelectedValue;
        dtDistricts = NfsmMaster.Getlocationdet(objinsert, Session["constr"].ToString());
        dtDistricts.DefaultView.Sort = " MandName Asc ";
        objCommon.BindDropDownLists(ddlmandal, dtDistricts, "MandName", "MandCode_LG", "Select Mandal");
    }
    protected void getVillageDtls()
    {
        DataTable dtDistricts = new DataTable();
        objinsert.Flage = "Vil";
        objinsert.statecd = ddlstate.SelectedValue;
        objinsert.distlgcd = ddldistrict.SelectedValue;
        objinsert.mandallgcd = ddlmandal.SelectedValue;
        dtDistricts = NfsmMaster.Getlocationdet(objinsert, Session["constr"].ToString());
        dtDistricts.DefaultView.Sort = " Villname Asc ";
        objCommon.BindDropDownLists(ddlvillage, dtDistricts, "Villname", "VillCode_LG", "Select Village");

    }
    void Popup(bool isDisplay)
    {

        StringBuilder builder = new StringBuilder();

        if (isDisplay)
        {
            builder.Append("<script language=JavaScript> Showgrid(); </script>\n");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Showgrid", builder.ToString());
        }
        else
        {
            builder.Append("<script language=JavaScript> HidegridPopup(); </script>\n");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "HidegridPopup", builder.ToString());
        }

    }

    protected void GridViewData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowPopup")
        {
            //loadsessionnullvalues(); 
            //LinkButton btndetails = (LinkButton)e.CommandSource;
            //GridViewRow gv = (GridViewRow)btndetails.NamingContainer;
          
            //Label lbldistcode = (Label)gv.FindControl("lblDistCode");
            //Label lblfarmerid = (Label)gv.FindControl("lblfarmerid");
            //Label lbldistcd = (Label)gv.FindControl("lblDistCode");
            //Label lblschemecd = (Label)gv.FindControl("lblschemecode");
            //Label lblcropcd = (Label)gv.FindControl("lblcropcode");
            //Label lblintervensioncd = (Label)gv.FindControl("lblintercode");
            //Label lblitemcd = (Label)gv.FindControl("lblitemcode");
            //Label lblyearcd = (Label)gv.FindControl("lblyearcd");
            //Label lblagencycd = (Label)gv.FindControl("lblagencycd");
            //Label lbluc_uid = (Label)gv.FindControl("lbluc_uid");
            //Label lblbankcode = (Label)gv.FindControl("lblchallanbankcd");
            //Label lblchallanamount = (Label)gv.FindControl("lblchallanamount");
            //Label lblchallanno = (Label)gv.FindControl("lblchallanno");
            //Label lblchallandt = (Label)gv.FindControl("lblchallandt");
            //Session["farmerid"]   = lblfarmerid.Text;
            //Session["distcd"]     = lbldistcode.Text;
            //Session["schemecd"]   = lblschemecd.Text;
            //Session["cropcd"]     = lblcropcd.Text;
            //Session["intervencd"] = lblintervensioncd.Text;
            //Session["itemcd"]     = lblitemcd.Text;
            //Session["yearcd"]     = lblyearcd.Text;
            //Session["agencycd"]   = lblagencycd.Text;
            //Session["uc_uid"]     = lbluc_uid.Text;
          
        }
    }
    protected void gvUpload_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddldoc = (DropDownList)e.Row.FindControl("ddldocument");

            Label lbldoc = (Label)e.Row.FindControl("lbldocs");
            if (lbldoc.Text != "" && lbldoc.Text != null)
            {
                ddldoc.SelectedValue = lbldoc.Text.Trim();
            }
        }
    }
   
   
 
    
    protected void linkfarmerid_OnClick(object sender, EventArgs e)
    {
        //DAO View UC Generation
        loadsessionnullvalues();
        GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;
        Label lbldistcode = (Label)gv.FindControl("lblDistCode");
        Label lblfarmerid = (Label)gv.FindControl("lblfarmerid");
        Label lbldistcd = (Label)gv.FindControl("lblDistCode");
        Label lblschemecd = (Label)gv.FindControl("lblschemecode");
        Label lblcropcd = (Label)gv.FindControl("lblcropcode");
        Label lblintervensioncd = (Label)gv.FindControl("lblintercode");
        Label lblitemcd = (Label)gv.FindControl("lblitemcode");
        Label lblyearcd = (Label)gv.FindControl("lblyearcd");
        Label lblagencycd = (Label)gv.FindControl("lblagencycd");
        Label lbluc_uid = (Label)gv.FindControl("lbluc_uid");
        Session["subschemecd"] = ((Label)gv.FindControl("lblsubschemecode")).Text.Trim();
        Session["farmerid"] = lblfarmerid.Text;
        Session["distcd"] = lbldistcode.Text;
        Session["schemecd"] = lblschemecd.Text;
        Session["cropcd"] = lblcropcd.Text;
        Session["intervencd"] = lblintervensioncd.Text;
        Session["itemcd"] = lblitemcd.Text;
        Session["yearcd"] = lblyearcd.Text;
       Session["agencycd"] = lblagencycd.Text;
       Session["uc_uid"] = lbluc_uid.Text;
       Response.Redirect("~/nfsm/DAO/GenerateUC.aspx");

    }
    protected void linkso_OnClick(object sender, EventArgs e)
    {
        //DAO Supply order generate
        loadsessionnullvalues();
        GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;
        Label lbldistcode = (Label)gv.FindControl("lblDistCode");
        Label lblfarmerid = (Label)gv.FindControl("lblfarmerid");
        Label lbldistcd = (Label)gv.FindControl("lblDistCode");
        Label lblschemecd = (Label)gv.FindControl("lblschemecode");
        Label lblcropcd = (Label)gv.FindControl("lblcropcode");
        Label lblintervensioncd = (Label)gv.FindControl("lblintercode");
        Label lblitemcd = (Label)gv.FindControl("lblitemcode");
        Label lblyearcd = (Label)gv.FindControl("lblyearcd");
        Label lblagencycd = (Label)gv.FindControl("lblagencycd");
        Label lbluc_uid = (Label)gv.FindControl("lbluc_uid");
        Session["subschemecd"] = ((Label)gv.FindControl("lblsubschemecode")).Text.Trim();
        Session["farmerid"] = lblfarmerid.Text;
        Session["distcd"] = lbldistcode.Text;
        Session["schemecd"] = lblschemecd.Text;
        Session["cropcd"] = lblcropcd.Text;
        Session["intervencd"] = lblintervensioncd.Text;
        Session["itemcd"] = lblitemcd.Text;
        Session["yearcd"] = lblyearcd.Text;
        Session["agencycd"] = lblagencycd.Text;
        Session["uc_uid"] = lbluc_uid.Text;
        //Response.Redirect("~/nfsm/DAO/SO_Generate.aspx");
        Response.Redirect("~/nfsm/DAO/DAOGenerateUC.aspx");
       

    }
    private void loadsessionnullvalues()
    {
        Session["farmerid"] = null;
        Session["distcd"] = null;
        Session["schemecd"] = null;
        Session["cropcd"] = null;
        Session["intervencd"] = null;
        Session["itemcd"] = null;
        Session["yearcd"] = null;
        Session["agencycd"] = null;
        Session["uc_uid"] = null;
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
        if (ddlCroptype.SelectedValue != "")
        {
            nfsmobj.cropcd = ddlCroptype.SelectedValue;
        }
        if (ddlintervenstion.SelectedValue != "")
        {
            nfsmobj.intervensioncd = ddlintervenstion.SelectedValue;
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
    protected void ddlsubcheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCrop();
    }
}