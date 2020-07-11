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
using System.Text;

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
            BindYear();
            BindScheme();
            ddlCroptype.Items.Clear();
            ddlCroptype.Items.Insert(0, new ListItem("Select Intervention", "0"));
            ddlintervenstion.Items.Clear();
            ddlintervenstion.Items.Insert(0, new ListItem("Select Sub Intervention", "0"));
            ddlitem.Items.Clear();
            ddlitem.Items.Insert(0, new ListItem("Select Items", "0"));
            ddlsubitem.Items.Clear();
            ddlsubitem.Items.Insert(0, new ListItem("Select Specification", "0"));
            bindgridview();
          
            BindAgency();
        }
    }
  
    protected void BindAgency()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.GetAgency_Details(Session["constr"].ToString());
        objCommon.BindDropDownLists_withZero(ddlagency, dt, "agency_name", "agency_code", "Select Agency");
        ddlfirmname.Items.Clear();
        ddlfirmname.Items.Insert(0, new ListItem("Select Firm Name", "0"));
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
            nfsmobj.subschemecode = ddlsubcheme.SelectedValue;
        }
        if (ddlCroptype.SelectedValue != "" && ddlCroptype.SelectedValue != "0")
        {
            nfsmobj.cropcd = ddlCroptype.SelectedValue;
        }
        if (ddlintervenstion.SelectedValue != "" && ddlintervenstion.SelectedValue != "0")
        {
            nfsmobj.intervensioncd = ddlintervenstion.SelectedValue;
        }
        if (ddlitem.SelectedValue != "" && ddlitem.SelectedValue != "0")
        {
            nfsmobj.itemcd = ddlitem.SelectedValue;
        }
        if (ddlyear.SelectedValue != "" && ddlyear.SelectedValue != "0")
        {
            nfsmobj.yearcd = ddlyear.SelectedValue;
        }
        if (ddlagency.SelectedValue != "" && ddlagency.SelectedValue != "0")
        {
            nfsmobj.agencycd = ddlagency.SelectedValue;
        }
        if (ddlfirmname.SelectedValue != "" && ddlfirmname.SelectedValue != "0")
        {
            nfsmobj.Firm_code = ddlfirmname.SelectedValue;
        }
        nfsmobj.Flag = "R";
        dt = obj.NFSM_ItemWise_AgencysubsidyDetails(nfsmobj, Session["constr"].ToString());
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
        //dt = NfsmMaster.get_NFSMSchemeDetails(Session["constr"].ToString());
        if (ddlyear.SelectedValue != "")
        {
            nfsmobj.yearcd = ddlyear.SelectedValue;
        }
        nfsmobj.Flag = "R";
        dt = NfsmMaster.insert_Scheme_IURD(nfsmobj, Session["constr"].ToString());
        objCommon.BindDropDownLists(ddlscheme, dt, "scheme_name", "scheme_code", "Select Scheme");
        ddlCroptype.Items.Clear();
        ddlCroptype.Items.Insert(0, new ListItem("Select Crop Type", ""));
        ddlintervenstion.Items.Clear();
        ddlintervenstion.Items.Insert(0, new ListItem("Select Intervension", ""));
        ddlitem.Items.Clear();
        ddlitem.Items.Insert(0, new ListItem("Select Items", ""));
        ddlsubcheme.Items.Clear();
        ddlsubcheme.Items.Insert(0, new ListItem("Select SubScheme", ""));
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
    protected void BindCrop()
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
    protected void Bindintervensions()
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
    protected void BindItems()
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
            ddlsubitem.Items.Clear();
            ddlsubitem.Items.Insert(0, new ListItem("Select SubItem", ""));
            bindgridview();
        }

    }
    protected void ddlCroptype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCroptype.SelectedValue != "")
        {
            Bindintervensions();

            ddlitem.Items.Clear();
            ddlitem.Items.Insert(0, new ListItem("Select Items", ""));
            ddlsubitem.Items.Clear();
            ddlsubitem.Items.Insert(0, new ListItem("Select SubItem", ""));
            bindgridview();

        }
    }
    protected void ddlintervenstion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlintervenstion.SelectedValue != "")
        {
            BindItems();
            ddlsubitem.Items.Clear();
            ddlsubitem.Items.Insert(0, new ListItem("Select SubItem", ""));
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
        Label lblFirm_code = (Label)gv.FindControl("lblFirm_code");
        Label lblagencycd = (Label)gv.FindControl("lblagencycd");
        Label lblsubschemecode = (Label)gv.FindControl("lblsubschemecode");
        ddlscheme.SelectedValue = lblschemecd.Text.Trim();
        bindsubscheme();
        ddlsubcheme.SelectedValue = lblsubschemecode.Text.Trim();
        BindCrop();
        ddlCroptype.SelectedValue = lblcropcd.Text.Trim();
        Bindintervensions();
        ddlintervenstion.SelectedValue = lblintervensioncd.Text.Trim();
        BindItems();
        ddlitem.SelectedValue = lblitemcd.Text.Trim();
        txtitemfullcost.Text = lblfullcost.Text;
       
        ddlagency.SelectedValue = lblagencycd.Text.Trim();
        bindFIrm();
        ddlfirmname.SelectedValue = lblFirm_code.Text.Trim();
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
        nfsmobj = new NFSM_Members();
        nfsmobj.schemecode = lblschemecd.Text;
        nfsmobj.cropcd = lblcropcd.Text;
        nfsmobj.intervensioncd = lblintervensioncd.Text;
        nfsmobj.itemcd = lblitemcd.Text;
        DataTable dt = new DataTable();
        dt = obj.NFSM_ItemWise_AgencysubsidyDetails(nfsmobj, Session["constr"].ToString());
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

        txtitemfullcost.Text = "";
        btnsubmit.Text = "Submit";
        BindYear();
        BindScheme();
        ddlCroptype.Items.Clear();
        ddlCroptype.Items.Insert(0, new ListItem("Select Crop Type", ""));
        ddlintervenstion.Items.Clear();
        ddlintervenstion.Items.Insert(0, new ListItem("Select Intervension", ""));
        ddlitem.Items.Clear();
        ddlitem.Items.Insert(0, new ListItem("Select Items", ""));
        ddlsubitem.Items.Clear();
        ddlsubitem.Items.Insert(0, new ListItem("Select SubItem", ""));
       
        BindAgency();
        bindgridview();
    }
    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindAgency();
        bindgridview();
    }
    protected void ddlagency_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindFIrm();
        bindgridview();
    }
    protected void ddlsubcheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlsubcheme.SelectedValue!="")
        {
        BindCrop();
        ddlintervenstion.Items.Clear();
        ddlintervenstion.Items.Insert(0, new ListItem("Select Intervension", ""));
        ddlitem.Items.Clear();
        ddlitem.Items.Insert(0, new ListItem("Select Items", ""));
        ddlsubitem.Items.Clear();
        ddlsubitem.Items.Insert(0, new ListItem("Select SubItem", ""));
             bindgridview();
        }
    }
    protected void ddlitem_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindsubItems();
        bindgridview(); 
    }
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
    protected void ddlsubitem_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgridview(); ;
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            nfsmobj = new NFSM_Members();
            nfsmobj.yearcd = ddlyear.SelectedValue;
            nfsmobj.schemecode = ddlscheme.SelectedValue;
            nfsmobj.Componentcode = ddlsubcheme.SelectedValue;
            nfsmobj.intervensioncd = ddlCroptype.SelectedValue;
            nfsmobj.subintervensioncd = ddlintervenstion.SelectedValue;
            nfsmobj.itemcd = ddlitem.SelectedValue;
            //  nfsmobj.subitemcode = ddlsubitem.SelectedValue;
            nfsmobj.fullcost = Convert.ToDecimal(txtitemfullcost.Text);


            nfsmobj.Firm_code = ddlfirmname.SelectedValue;
            nfsmobj.agencycd = ddlagency.SelectedValue;
            if (btnsubmit.Text != "Update")
            {
                nfsmobj.Flag = "I";
            }
            else
            {
                nfsmobj.Flag = "U";
            }
            if (ddlsubitem.SelectedValue != "")
            {
                nfsmobj.subitemcode = ddlsubitem.SelectedValue;
            }
            else
            { nfsmobj.subitemcode = "0"; }
            DataTable dt = new DataTable();
            dt = obj.NFSM_ItemWise_AgencysubsidyDetails(nfsmobj, Session["constr"].ToString());

            if (dt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                Cleardata();
            }
            else
            {
                objCommon.ShowAlertMessage("Item Subsidy Details Not " + btnsubmit.Text + " Successfully");
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            //Response.Redirect("~/nfsm/Error.aspx");

        }
    }
}
