using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Seed_BL;
using Seed_BE;
using Seed_DL;
using System.Data;
using System.Web.UI.WebControls;


public partial class CropMaster : System.Web.UI.Page
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
        //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        if (!IsPostBack)
        {
            //lblUsrName.Text = Session["Role"].ToString();
            //lblDist.Text = Session["district"].ToString();
            //lblMand.Text = Session["mandal"].ToString();
            BindCaste();
            BindYear();
            BindScheme();
            ddlCroptype.Items.Clear();
            ddlCroptype.Items.Insert(0, new ListItem("Select Intervension", ""));
            ddlintervenstion.Items.Clear();
            ddlintervenstion.Items.Insert(0, new ListItem("Select Sub Intervension", "0"));
            ddlitem.Items.Clear();
            ddlitem.Items.Insert(0, new ListItem("Select Items", "0"));
            ddlsubitem.Items.Clear();
            ddlsubitem.Items.Insert(0, new ListItem("Select Specification Desc", "0"));
            bindgridview();
        }
    }
    protected void BindCaste()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.GetCasteDetails(Session["constr"].ToString());
        objCommon.BindDropDownLists_withZero(ddlcategory, dt, "CasteName", "CasteCode", "Select Caste");
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
        objCommon.BindDropDownLists_withZero(ddlyear, dt, "year_desc", "year_code", "Select Fin Year");
        ddlyear.SelectedValue = yearcd.ToString();
        ddlyear.Enabled = true;
    }

    protected void bindgridview()
    {
        DataTable dt = new DataTable();
        nfsmobj = new NFSM_Members();
        if (ddlscheme.SelectedValue != "" && ddlscheme.SelectedValue != "0")
        {
            nfsmobj.schemecode = ddlscheme.SelectedValue;
        }
        if (ddlsubcheme.SelectedValue != "" && ddlsubcheme.SelectedValue != "0")
        {
            nfsmobj.Componentcode = ddlsubcheme.SelectedValue;
        }
        if (ddlCroptype.SelectedValue != "" && ddlCroptype.SelectedValue != "0")
        {
            nfsmobj.intervensioncd = ddlCroptype.SelectedValue;
        }
        if (ddlintervenstion.SelectedValue != "" && ddlintervenstion.SelectedValue != "0")
        {
            nfsmobj.subintervensioncd = ddlintervenstion.SelectedValue;
        }
        if (ddlitem.SelectedValue != "" && ddlitem.SelectedValue != "0")
        {
            nfsmobj.itemcd = ddlitem.SelectedValue;
        }
        if (ddlyear.SelectedValue != "" && ddlyear.SelectedValue != "0")
        {
            nfsmobj.yearcd = ddlyear.SelectedValue;
        }

        nfsmobj.Flag = "R";
        dt = obj.NFSM_ItemWise_subsidyDetails(nfsmobj, Session["constr"].ToString());
        if (dt.Rows.Count > 0)
        {

            gvitemsubsidy.DataSource = dt;
            gvitemsubsidy.DataBind();
            gvitemsubsidy.Visible = true;
            btnsubmit.Visible = true;
        }
        else
        {
            gvitemsubsidy.Visible = false;
          
        }


    }
    protected void BindScheme()
    {
        DataTable dt = new DataTable();
        //if (ddlyear.SelectedValue != "")
        //{
        //    nfsmobj.yearcd = ddlyear.SelectedValue;
        //}
        //nfsmobj.Flag = "R";
        //dt = ddlyear.get_NFSMSchemeDetails(Session["constr"].ToString());
        if (ddlyear.SelectedValue != "")
        {
            nfsmobj.yearcd = ddlyear.SelectedValue;
        }
        nfsmobj.Flag = "R";
        dt = NfsmMaster.insert_Scheme_IURD(nfsmobj, Session["constr"].ToString());
        objCommon.BindDropDownLists_withZero(ddlscheme, dt, "scheme_name", "scheme_code", "Select Scheme");
        ddlsubcheme.Items.Clear();
        ddlsubcheme.Items.Insert(0, new ListItem("Select Component ", "0"));
        ddlCroptype.Items.Clear();
        ddlCroptype.Items.Insert(0, new ListItem("Select Intervension", "0"));
        ddlintervenstion.Items.Clear();
        ddlintervenstion.Items.Insert(0, new ListItem("Select Sub Intervension", "0"));
        ddlitem.Items.Clear();
        ddlitem.Items.Insert(0, new ListItem("Select Items", "0"));
        ddlsubitem.Items.Clear();
        ddlsubitem.Items.Insert(0, new ListItem("Select Specification Desc", "0"));
      
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
        objCommon.BindDropDownLists_withZero(ddlsubcheme, dt, "Component_name", "Component_code", "Select Component");
       

    }
   
    protected void bindcrop()
    {
        DataTable dt = new DataTable();
        nfsmobj = new NFSM_Members();


        if (ddlscheme.SelectedValue != "")
        {
            nfsmobj.schemecode = ddlscheme.SelectedValue;
        }
        if (ddlsubcheme.SelectedValue != "" && ddlsubcheme.SelectedValue != "")
        {
            nfsmobj.Componentcode = ddlsubcheme.SelectedValue;
        }


        nfsmobj.Flag = "R";
        dt = NfsmMaster.insert_crop_IURD(nfsmobj, Session["constr"].ToString());
        objCommon.BindDropDownLists_withZero(ddlCroptype, dt, "interven_Name", "interven_code", "Select Intervension");
        ddlintervenstion.Items.Clear();
        ddlintervenstion.Items.Insert(0, new ListItem("Select Select sub Intervension", "0"));

    }
    //protected void bindintervensions()
    //{
    //    datatable dt = new datatable();
    //    dt = nfsmmaster.getintervension_details(ddlyear.selectedvalue, ddlscheme.selectedvalue, ddlsubcheme.selectedvalue, ddlcroptype.selectedvalue, session["constr"].tostring());
    //    objcommon.binddropdownlists_withzero(ddlintervenstion, dt, "interven_name", "interven_code", "select sub intervension");
    //}

    protected void bindintervensions()
    {
        DataTable dt = new DataTable();
        nfsmobj = new NFSM_Members();

        if (ddlscheme.SelectedValue != "")
        {
            nfsmobj.schemecode = ddlscheme.SelectedValue;
        }
        if (ddlsubcheme.SelectedValue != "")
        {
            nfsmobj.Componentcode = ddlsubcheme.SelectedValue;
        }

        if (ddlCroptype.SelectedValue != "")
        {
            nfsmobj.intervensioncd = ddlCroptype.SelectedValue;
        }
        nfsmobj.Flag = "R";
        dt = NfsmMaster.insert_SubIntervention_IURD(nfsmobj, Session["constr"].ToString());
        objCommon.BindDropDownLists_withZero(ddlintervenstion, dt, "Subinterven_name", "SUbinterven_code", "Select Sub Intervension");
        ddlitem.Items.Clear();
        ddlitem.Items.Insert(0, new ListItem("Select  Item", "0"));

    }
    protected void binditemcode()
    {
        DataTable dt = new DataTable();
        nfsmobj = new NFSM_Members();
        if (ddlscheme.SelectedValue != "")
        {
            nfsmobj.schemecode = ddlscheme.SelectedValue;
        }

        if (ddlsubcheme.SelectedValue != "")
        {
            nfsmobj.Componentcode = ddlsubcheme.SelectedValue;
        }

        if (ddlCroptype.SelectedValue != "")
        {
            nfsmobj.intervensioncd = ddlCroptype.SelectedValue;
        }
        if (ddlintervenstion.SelectedValue != "")
        {
            nfsmobj.subintervensioncd = ddlintervenstion.SelectedValue;
        }
        nfsmobj.Flag = "R";
        dt = NfsmMaster.insert_Item_IURD(nfsmobj, Session["constr"].ToString());
        if (dt.Rows.Count > 0)
        {

            objCommon.BindDropDownLists_withZero(ddlitem, dt, "item_name", "item_Code", "Select Item");

        }



    }
    //protected void BindItems()
    //{
    //    DataTable dt = new DataTable();
    //    dt = NfsmMaster.GetItems_Details(ddlyear.SelectedValue, ddlscheme.SelectedValue,ddlsubcheme.SelectedValue, ddlCroptype.SelectedValue, ddlintervenstion.SelectedValue, Session["constr"].ToString());
    //    objCommon.BindDropDownLists_withZero(ddlitem, dt, "item_name", "item_code", "Select Items");
    //    ddlsubitem.Items.Clear();
    //    ddlsubitem.Items.Insert(0, new ListItem("Select Specification Desc", "0"));
    //}
    //protected void BindsubItems()
    //{
    //    DataTable dt = new DataTable();
    //    dt = NfsmMaster.GetItems_Details(ddlyear.SelectedValue, ddlscheme.SelectedValue, ddlsubcheme.SelectedValue, ddlCroptype.SelectedValue, ddlintervenstion.SelectedValue, Session["constr"].ToString());
    //    objCommon.BindDropDownLists(ddlitem, dt, "item_name", "item_code", "Select Items");
    //}
    protected void BindsubItems()
    {
        DataTable dt = new DataTable();
        nfsmobj = new NFSM_Members();


        //if (ddlsubcheme.SelectedValue != "0")
        //{
        //    nfsmobj.subschemecode = ddlsubcheme.SelectedValue;
        //}
        //if (ddlscheme.SelectedValue != "0")
        //{
        //    nfsmobj.schemecode = ddlscheme.SelectedValue;
        //}
        //if (ddlCroptype.SelectedValue != "0")
        //{
        //    nfsmobj.cropcd = ddlCroptype.SelectedValue;
        //}
        //if (ddlintervenstion.SelectedValue != "0")
        //{
        //    nfsmobj.intervensioncd = ddlintervenstion.SelectedValue;
        //}
        //if (ddlitem.SelectedValue != "0")
        //{
        //    nfsmobj.itemcd = ddlitem.SelectedValue;
        //}
        nfsmobj.schemecode = ddlsubcheme.SelectedValue;
        nfsmobj.Componentcode = ddlsubcheme.SelectedValue;
        nfsmobj.intervensioncd = ddlCroptype.SelectedValue;
        nfsmobj.subintervensioncd = ddlintervenstion.SelectedValue;
        nfsmobj.itemcd = ddlitem.SelectedValue;

        nfsmobj.Flag = "R";
        dt = NfsmMaster.insert_SubItem_IURD(nfsmobj, Session["constr"].ToString());
        if (dt.Rows.Count > 0)
        {
            objCommon.BindDropDownLists_withZero(ddlsubitem, dt, "subitem_name", "subitem_code", "Select  Specification Desc");

        }     
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlyear.SelectedValue == "0")
            {
                objCommon.ShowAlertMessage("Please Select Year");
                return;
            }
            if (ddlscheme.SelectedValue == "0")
            {
                objCommon.ShowAlertMessage("Please Select Scheme");
                return;
            }
            if (ddlsubcheme.SelectedValue == "0")
            {
                objCommon.ShowAlertMessage("Please Select Component");
                return;
            }
          
            if (ddlCroptype.SelectedValue == "0")
            {
                objCommon.ShowAlertMessage("Please Select intervenstion");
                return;
            }
            if (ddlintervenstion.SelectedValue == "0")
            {
                objCommon.ShowAlertMessage("Please Select Sub intervenstion");
                return;
            }
            if (ddlitem.SelectedValue == "0")
            {
                objCommon.ShowAlertMessage("Please Select Item");
                return;
            }

            if (ddlsubitem.SelectedValue == "0")
            {
                objCommon.ShowAlertMessage("Please Select Specification Desc");
                return;
            }
            if (ddlcategory.SelectedValue == "0")
            {
                objCommon.ShowAlertMessage("Please Select category");
                return;
            }
            if (txtitemfullcost.Text =="" )
            {
                objCommon.ShowAlertMessage("Please Ente Full Cost");
                txtitemfullcost.Focus();
                return;
            }
            if (txtnonsubsidyamt.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter non subsidy Amount");
                txtnonsubsidyamt.Focus();
                return;
            }

            if (txtsubsidyamt.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter subsidy Amount");
                txtnonsubsidyamt.Focus();
                return;
            }
            if (txtnounits.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter No of units");
                txtnonsubsidyamt.Focus();
                return;
            }
            nfsmobj = new NFSM_Members();
            nfsmobj.yearcd = ddlyear.SelectedValue;
            nfsmobj.categorycd = ddlcategory.SelectedValue;
            nfsmobj.schemecode = ddlscheme.SelectedValue;
            nfsmobj.Componentcode = ddlsubcheme.SelectedValue;
            nfsmobj.intervensioncd = ddlCroptype.SelectedValue;
            nfsmobj.subintervensioncd = ddlintervenstion.SelectedValue;
            nfsmobj.itemcd = ddlitem.SelectedValue;
            nfsmobj.fullcost = Convert.ToDecimal(txtitemfullcost.Text);
            nfsmobj.subsidyamt = Convert.ToDecimal(txtsubsidyamt.Text);
            nfsmobj.nonsubsidyamt = Convert.ToDecimal(txtnonsubsidyamt.Text);
            if (ddlsubitem.SelectedValue != "")
            {
                nfsmobj.subitemcode = ddlsubitem.SelectedValue;
            }
            else
            { nfsmobj.subitemcode = "0"; }
            nfsmobj.item_nos = txtnounits.Text;
            if (btnsubmit.Text != "Update")
            {
                nfsmobj.Flag = "I";
            }
            else
            {
                nfsmobj.Flag = "U";
            }
            DataTable dt = new DataTable();
            dt = obj.NFSM_ItemWise_subsidyDetails(nfsmobj, Session["constr"].ToString());

            if (dt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                Cleardata();
            }
            else
            {
                objCommon.ShowAlertMessage("Component Details Not " + btnsubmit.Text + " Successfully");
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
           // Response.Redirect("~/nfsm/Error.aspx");

        }
    }
    protected void ddlscheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlscheme.SelectedValue != "")
        {
            bindsubscheme();
           
            ddlCroptype.Items.Clear();
            ddlCroptype.Items.Insert(0, new ListItem("Select Intervension", "0"));
            ddlintervenstion.Items.Clear();
            ddlintervenstion.Items.Insert(0, new ListItem("Select Sub Intervension", "0"));
            ddlitem.Items.Clear();
            ddlitem.Items.Insert(0, new ListItem("Select Items", "0"));
            ddlsubitem.Items.Clear();
            ddlsubitem.Items.Insert(0, new ListItem("Select SubItem", "0"));
            bindgridview();
        }

    }
    protected void ddlCroptype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCroptype.SelectedValue != "")
        {
            bindintervensions();

            ddlitem.Items.Clear();
            ddlitem.Items.Insert(0, new ListItem("Select Items", ""));
            bindgridview();

        }
    }
    protected void ddlintervenstion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlintervenstion.SelectedValue != "")
        {
            binditemcode();
            bindgridview();

        }
    }

    protected void linklinkedit_OnClick(object sender, EventArgs e)
    {

        GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;
        Label lblschemecd = (Label)gv.FindControl("lblschemecode");
        Label lblcropcd = (Label)gv.FindControl("lblcropcode");
        Label lblintervensioncd = (Label)gv.FindControl("lblintercode");
        Label lblitemcd = (Label)gv.FindControl("lblitemcode");
        Label lblyearcd = (Label)gv.FindControl("lblyearcd");
        Label lblfullcost = (Label)gv.FindControl("lblfullcost");
        Label lblsubsidycost = (Label)gv.FindControl("lblsubsidyamt");
        Label lblnonsubsidy = (Label)gv.FindControl("lblnonsubsidy");
        Label lblunitsnos = (Label)gv.FindControl("lblnounits");
        Label lblsubschemecode = (Label)gv.FindControl("lblsubschemecode");
        Label lblsubitemcd = (Label)gv.FindControl("lblsubitemcode");
        Label lblcategory_cd = (Label)gv.FindControl("lblcategory_cd");
        ddlscheme.SelectedValue = lblschemecd.Text.Trim();
        bindsubscheme();
        ddlsubcheme.SelectedValue = lblsubschemecode.Text.Trim();
        bindcrop();
        ddlCroptype.SelectedValue = lblcropcd.Text.Trim();
        bindintervensions();
        ddlintervenstion.SelectedValue = lblintervensioncd.Text.Trim();
        binditemcode();
        ddlitem.SelectedValue = lblitemcd.Text.Trim();
        BindsubItems();
        if (lblsubitemcd.Text != "0")
        { ddlsubitem.SelectedValue = lblsubitemcd.Text.Trim(); }
        txtitemfullcost.Text = lblfullcost.Text;
        txtsubsidyamt.Text = lblsubsidycost.Text;
        txtnonsubsidyamt.Text = lblnonsubsidy.Text;
        txtnounits.Text = lblunitsnos.Text;
        BindCaste();
        ddlcategory.SelectedValue = lblcategory_cd.Text;
        ddlcategory.Enabled = false;
        ddlCroptype.Enabled = false;
        ddlyear.Enabled = false;
        ddlsubitem.Enabled = false;
        ddlscheme.Enabled = false;
        ddlsubcheme.Enabled = false;
        ddlitem.Enabled = false;
        ddlintervenstion.Enabled = false;

        btnsubmit.Text = "Update";
    }
    protected void linkDelete_OnClick(object sender, EventArgs e)
    {
        GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;
        nfsmobj = new NFSM_Members();
        Label lblschemecd = (Label)gv.FindControl("lblschemecode");
        Label lblcropcd = (Label)gv.FindControl("lblcropcode");
        Label lblintervensioncd = (Label)gv.FindControl("lblintercode");
        Label lblitemcd = (Label)gv.FindControl("lblitemcode");
        Label lblyearcd = (Label)gv.FindControl("lblyearcd");
        Label lblsubschemecode = (Label)gv.FindControl("lblsubschemecode");
        Label lblsubitemcd = (Label)gv.FindControl("lblsubitemcode");
        nfsmobj = new NFSM_Members();
        nfsmobj.schemecode = lblschemecd.Text;
        nfsmobj.subschemecode = lblsubschemecode.Text;
        nfsmobj.cropcd = lblcropcd.Text;
        nfsmobj.intervensioncd = lblintervensioncd.Text;
        nfsmobj.itemcd = lblitemcd.Text;
        nfsmobj.yearcd = lblyearcd.Text;
        nfsmobj.subitemcode = lblsubitemcd.Text;
        nfsmobj.Flag = "D";
        DataTable dt = new DataTable();
        dt = obj.NFSM_ItemWise_subsidyDetails(nfsmobj, Session["constr"].ToString());
        if (dt.Rows.Count > 0)
        {
            objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
            Cleardata();
        }
        bindgridview();

    }


    protected void btnreset_Click(object sender, EventArgs e)
    {
        Cleardata();
    }

    private void Cleardata()
    {
        txtsubsidyamt.Text = "";
        txtnounits.Text = "";
        txtnonsubsidyamt.Text = "";
        txtitemfullcost.Text = "";
        btnsubmit.Text = "Submit";
        BindYear();
        BindCaste();
        BindScheme();
        ddlCroptype.Items.Clear();
        ddlCroptype.Items.Insert(0, new ListItem("Select Crop Type", ""));
        ddlintervenstion.Items.Clear();
        ddlintervenstion.Items.Insert(0, new ListItem("Select Intervension", ""));
        ddlitem.Items.Clear();
        ddlitem.Items.Insert(0, new ListItem("Select Items", ""));
        bindgridview();
        ddlcategory.Enabled = true;
        ddlCroptype.Enabled = true;
        ddlyear.Enabled = true;
        ddlsubitem.Enabled = true;
        ddlscheme.Enabled = true;
        ddlsubcheme.Enabled = true;
        ddlitem.Enabled = true;
        ddlintervenstion.Enabled = true;
    }
    protected void ddlsubcheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindcrop();
        ddlintervenstion.Items.Clear();
        ddlintervenstion.Items.Insert(0, new ListItem("Select Intervension", ""));
        ddlitem.Items.Clear();
        ddlitem.Items.Insert(0, new ListItem("Select Items", ""));
        bindgridview();
    }
    
    protected void ddlitem_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindsubItems();
        bindgridview(); ;
    }
    protected void ddlsubitem_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgridview(); ;
    }
    protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgridview(); ;
    }
}
