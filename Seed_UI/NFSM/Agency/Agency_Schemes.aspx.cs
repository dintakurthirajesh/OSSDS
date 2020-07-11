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
        if (Session["Rolecode"].ToString() == null)
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
            BindAgency();
            try
            {
                if (Session["Rolecode"] != null)
                {
                    if (Session["Rolecode"].ToString() == "2")
                    {
                        string agencycode = Session["agencycode"].ToString();
                        if (Convert.ToInt16(agencycode) > 9)
                        {
                            ddlagency.SelectedValue = (Session["agencycode"].ToString()).Trim();

                        }
                        else
                        {
                            ddlagency.SelectedValue = ("0" + Session["agencycode"].ToString()).Trim();
                        }
                        ddlagency.Enabled = false;
                    }
                }
            }
            catch { }

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
        dt = NfsmMaster.get_NFSMSchemeDetails(Session["constr"].ToString());

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
        ddlsubitem.Items.Clear();
        ddlsubitem.Items.Insert(0, new ListItem("Select SubItem", ""));


    }
    protected void BindCrop()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.Get_Crop_IURD(ddlyear.SelectedValue, ddlscheme.SelectedValue, ddlsubcheme.SelectedValue, Session["constr"].ToString());
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
        ddlsubitem.Items.Clear();
        ddlsubitem.Items.Insert(0, new ListItem("Select SubItem", ""));
    }
    protected void BindAgency()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.GetAgency_Details(Session["constr"].ToString());
        objCommon.BindDropDownLists(ddlagency, dt, "agency_name", "agency_code", "Select Agency");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        loadgridview();
    }

    private void loadgridview()
    {
        try
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
            nfsmobj.Flag = "AGC";
            dt = obj.GetSchemefilingDetailstoApprove(nfsmobj, Session["constr"].ToString());
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
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/nfsm/Error.aspx");

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

        txtfarmerid.Text = "";
        BindAgency();
        gvschmefiling.Visible = false;
        btnsubmit.Visible = false;
    }
    private void loadsessionnullvalues()
    {
        Session["farmerid"] = null;
        Session["distcd"] = null;
        Session["schemecd"] = null;
        Session["subschemecd"] = null;
        Session["cropcd"] = null;
        Session["intervencd"] = null;
        Session["itemcd"] = null;
        Session["yearcd"] = null;
        Session["agencycd"] = null;
        Session["uc_uid"] = null;
        Session["subitemcd"] = null;
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
        Session["subitemcd"]=((Label)gv.FindControl("lblsubitemcode")).Text.Trim(); 
        Session["yearcd"] = lblyearcd.Text;
        Session["agencycd"] = lblagencycd.Text;
        Session["uc_uid"] = lbluc_uid.Text;
        Response.Redirect("~/nfsm/agency/SO_Generate.aspx");

    }
    protected void ddlscheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlscheme.SelectedValue != "")
        {
            bindsubscheme();
            ddlCroptype.Items.Clear();
            ddlCroptype.Items.Insert(0, new ListItem("Select Crop Type", ""));
            ddlintervenstion.Items.Clear();
            ddlintervenstion.Items.Insert(0, new ListItem("Select Intervension", ""));
            ddlitem.Items.Clear();
            ddlitem.Items.Insert(0, new ListItem("Select Items", ""));

            txtfarmerid.Text = "";
        }


    }
    protected void ddlCroptype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCroptype.SelectedValue != "")
        {
            Bindintervensions();
            ddlitem.Items.Clear();
            ddlitem.Items.Insert(0, new ListItem("Select Items", ""));

            txtfarmerid.Text = "";
        }
    }
    protected void ddlintervenstion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlintervenstion.SelectedValue != "")
        {
            BindItems();


            txtfarmerid.Text = "";
        }
    }
    protected void ddlitem_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindsubItems();
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
            dtforward.Columns.Add("remarks", typeof(string));
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
                    dtforward.Rows[j]["remarks"] = "";
                    dtforward.Rows[j]["status_app"] = "1";

                    dtforward.Rows[j]["flag"] = "AGC";

                    j++;
                }
            }
            if (dtforward.Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = obj.Update_Status_Schemefiling(dtforward,"AGC", Session["constr"].ToString());
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage("Selected Application Forwarded to MAO");
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
    protected void linkfarmerid_OnClick(object sender, EventArgs e)
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
        Label lblsubitemcode = (Label)gv.FindControl("lblsubitemcode");
  
        Session["farmerid"] = lblfarmerid.Text;
        Session["distcd"] = lbldistcode.Text;
        Session["schemecd"] = lblschemecd.Text;
        Session["subschemecd"] = ((Label)gv.FindControl("lblsubschemecode")).Text.Trim();
        Session["cropcd"] = lblcropcd.Text;
        Session["intervencd"] = lblintervensioncd.Text;
        Session["itemcd"] = lblitemcd.Text;
        Session["subitemcd"] = lblsubitemcode.Text;
        Session["yearcd"] = lblyearcd.Text;

        Session["agencycd"] = lblagencycd.Text;

        Response.Redirect("~/nfsm/agency/Invoicedocumentupload.aspx");

    }
    protected void ddlsubcheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlsubcheme.SelectedValue != "")
        {
            BindCrop();
        }
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
}