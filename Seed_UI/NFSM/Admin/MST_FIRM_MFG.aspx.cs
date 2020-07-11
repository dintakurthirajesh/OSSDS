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

public partial class NFSM_Admin_AgencyMaster : System.Web.UI.Page
{
    MasterDAL objDist = new MasterDAL();
    CommonFuncs objCommon = new CommonFuncs();
    LocationBE objinsert = new LocationBE();
    Validate objValidate = new Validate();
    NFSM_MasterDL NfsmMaster = new NFSM_MasterDL();
    NFSM_Members nfsmobj = new NFSM_Members();
    NFSM_Farmer_Scheme_DL obj = new NFSM_Farmer_Scheme_DL();
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindYear();
            bindgridview();
            getDistrictDtls();
            getAgencyDtls();
            BindBanks();
        }
    }
    protected void BindBanks()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.GetBanks(Session["constr"].ToString());
        objCommon.BindDropDownLists_withZero(ddlbank, dt, "BankName", "BankCode", "Select Bank");

    }
    protected void getAgencyDtls()
    {
         dt = new DataTable();
       
        nfsmobj.Flag = "R";
        dt = NfsmMaster.insert_Agencymaster_IURD(nfsmobj, Session["constr"].ToString());
        dt.DefaultView.Sort = " agency_name Asc ";
        objCommon.BindDropDownLists_withZero(ddlAgency, dt, "agency_name", "agency_code", "Select Agency");

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
        objCommon.BindDropDownLists_withZero(ddlfinyear, dt, "year_desc", "year_code", "Select Fin Year");
        ddlfinyear.SelectedValue = yearcd.ToString();
        ddlfinyear.Enabled = true;
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (ddlAgency.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Please Select Agency Name");
            ddlAgency.Focus();
            return;
        }
        if (txtfirmname.Text == "")
        {
            objCommon.ShowAlertMessage("Please Enter Firm Name");
            txtfirmname.Focus();
            return;
        }
        nfsmobj.yearcd = ddlfinyear.SelectedValue;
        nfsmobj.distcd = ddldistrict.SelectedValue;
        nfsmobj.mobileno = txtmobileno.Text;
        nfsmobj.phoneNo = txtPhoneNo.Text;
        nfsmobj.address = txtaddress.Text;
        nfsmobj.FirmName = txtfirmname.Text;
        nfsmobj.agencycd =ddlAgency.SelectedValue;
        nfsmobj.pattadharno = txtPincode.Text;
        nfsmobj.bankcd = ddlbank.SelectedValue;
        nfsmobj.ifsccode = txtifsccode.Text;
        nfsmobj.accountno = txtAccountNumber.Text;
        nfsmobj.ipaddress = HttpContext.Current.Request.UserHostAddress;
        nfsmobj.userid = Session["UsrName"].ToString();
        if (btnsubmit.Text != "Update")
        {
            nfsmobj.Flag = "I";
        }
        else
        {
            nfsmobj.Flag = "U";
            nfsmobj.Firm_code = lblschemeid.Text;
        }
        DataTable dt = new DataTable();
        dt = NfsmMaster.insert_MFGFirm_IURD(nfsmobj, Session["constr"].ToString());
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
    private void Cleardata()
    {
        txtAccountNumber.Text = "";
        txtaddress.Text = "";
        BindBanks();
        txtifsccode.Text = "";
        txtmobileno.Text = "";
        txtPincode.Text = "";
        txtfirmname.Text = "";
        lblschemeid.Text = "";
        btnsubmit.Text = "Submit";
        BindYear();
        txtPhoneNo.Text = "";
        bindgridview();
        getDistrictDtls();
        getAgencyDtls();
    }
    protected void bindgridview()
    {
        DataTable dt = new DataTable();
        nfsmobj = new NFSM_Members();

        if (ddlfinyear.SelectedValue != "")
        {
            nfsmobj.yearcd = ddlfinyear.SelectedValue;
        }
        nfsmobj.Flag = "R";
        dt = NfsmMaster.insert_MFGFirm_IURD(nfsmobj, Session["constr"].ToString());
        if (dt.Rows.Count > 0)
        {

            gvitemsubsidy.DataSource = dt;
            gvitemsubsidy.DataBind();
            gvitemsubsidy.Visible = true;
         
        }
        else
        {
            gvitemsubsidy.Visible = false;
           
        }


    }
    protected void getDistrictDtls()
    {
        DataTable dtDistricts = new DataTable();
        objinsert.Flage = "Dis";
        objinsert.statecd = "36";
        dtDistricts = NfsmMaster.Getlocationdet(objinsert, Session["constr"].ToString());
        dtDistricts.DefaultView.Sort = " DistName Asc ";
        objCommon.BindDropDownLists_withZero(ddldistrict, dtDistricts, "DistName", "DistCode_Lg", "Select District");

    }
    protected void linklinkedit_OnClick(object sender, EventArgs e)
    {

        GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;
        Label lvlfinyear = (Label)gv.FindControl("lblyearcd");
        Label lblFirm_code = (Label)gv.FindControl("lblFirm_code");
        Label lblfirmname = (Label)gv.FindControl("lblfirmname");
        Label lblpincode = (Label)gv.FindControl("lblpincode");
        Label lblagency_code = (Label)gv.FindControl("lblagency_code");
        Label lbldistrictcode = (Label)gv.FindControl("lbldistrictcode");
        Label lblmobileno = (Label)gv.FindControl("lblmobileno");
        Label lblbankname = (Label)gv.FindControl("lblbank_code");
        Label lblifsccode = (Label)gv.FindControl("lblifsccode");
        Label lblaccountno = (Label)gv.FindControl("lblaccountno");
        Label lblAddress = (Label)gv.FindControl("lblAddress");
        Label lblphoneno = (Label)gv.FindControl("lblphoneno");
        getAgencyDtls();
        txtAccountNumber.Text = lblaccountno.Text;
        txtaddress.Text = lblAddress.Text;
      ddlbank.SelectedValue = lblbankname.Text;
        txtifsccode.Text = lblifsccode.Text;
        txtPincode.Text = lblpincode.Text;
        txtmobileno.Text = lblmobileno.Text;
        ddlAgency.SelectedValue = lblagency_code.Text;
        txtPhoneNo.Text = lblphoneno.Text;
        txtfirmname.Text = lblfirmname.Text;
        lblschemeid.Text = lblFirm_code.Text;
        btnsubmit.Text = "Update";
    }
    protected void linkDelete_OnClick(object sender, EventArgs e)
    {
        GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

        Label lvlfinyear = (Label)gv.FindControl("lblyearcd");
        Label lblagency_code = (Label)gv.FindControl("lblagency_code");
        Label lblschemename = (Label)gv.FindControl("lblfirmname");
        Label lblFirm_code = (Label)gv.FindControl("lblFirm_code");
        nfsmobj = new NFSM_Members();
        nfsmobj.agencycd = lblagency_code.Text;
        nfsmobj.FirmName = lblschemename.Text;
        nfsmobj.Firm_code = lblFirm_code.Text;
        
        nfsmobj.yearcd = lvlfinyear.Text;
        nfsmobj.Flag = "D";
        DataTable dt = new DataTable();
        dt = NfsmMaster.insert_MFGFirm_IURD(nfsmobj, Session["constr"].ToString());
        if (dt.Rows.Count > 0)
        {
            objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
            Cleardata();
        }
        bindgridview();

    }
    protected void btnreset_Click(object sender, EventArgs e)
    {

    }
    protected void ddlAgency_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgridview();
    }
    
}