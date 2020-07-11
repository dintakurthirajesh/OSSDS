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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindYear();
            bindgridview();
            getDistrictDtls();
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
        objCommon.BindDropDownLists(ddlfinyear, dt, "year_desc", "year_code", "Select Fin Year");
        ddlfinyear.SelectedValue = yearcd.ToString();
        ddlfinyear.Enabled = false;
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        nfsmobj.yearcd = ddlfinyear.SelectedValue;
        nfsmobj.distcd = ddldistrict.SelectedValue;
        nfsmobj.mobileno = txtmobileno.Text;
        nfsmobj.address = txtaddress.Text;
        nfsmobj.agencyname = txtschemename.Text;
        nfsmobj.pattadharno = txtPincode.Text;
        nfsmobj.bankcd = txtbankname.Text;
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
            nfsmobj.agencycd = lblschemeid.Text;
        }
        DataTable dt = new DataTable();
        dt = NfsmMaster.insert_Agencymaster_IURD(nfsmobj, Session["constr"].ToString());
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
        txtbankname.Text = "";
        txtifsccode.Text = "";
        txtmobileno.Text = "";
        txtPincode.Text = "";
        txtschemename.Text = "";
        lblschemeid.Text = "";
        btnsubmit.Text = "Submit";
        BindYear();
        txtschemename.Text = "";
        bindgridview();
        getDistrictDtls();
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
        dt = NfsmMaster.insert_Agencymaster_IURD(nfsmobj, Session["constr"].ToString());
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
            btnsubmit.Visible = false;
        }


    }
    protected void getDistrictDtls()
    {
        DataTable dtDistricts = new DataTable();
        objinsert.Flage = "Dis";
        objinsert.statecd = "36";
        dtDistricts = NfsmMaster.Getlocationdet(objinsert, Session["constr"].ToString());
        dtDistricts.DefaultView.Sort = " DistName Asc ";
        objCommon.BindDropDownLists(ddldistrict, dtDistricts, "DistName", "DistCode_Lg", "Select District");

    }
    protected void linklinkedit_OnClick(object sender, EventArgs e)
    {

        GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;
        Label lvlfinyear = (Label)gv.FindControl("lblyearcd");
        Label lblschemecd = (Label)gv.FindControl("lblschemecode");
        Label lblschemename = (Label)gv.FindControl("lblschemename");

        Label lblpincode = (Label)gv.FindControl("lblpincode");
        Label lbldistrictcode = (Label)gv.FindControl("lbldistrictcode");
        Label lblmobileno = (Label)gv.FindControl("lblmobileno");
        Label lblbankname = (Label)gv.FindControl("lblbankname");
        Label lblifsccode = (Label)gv.FindControl("lblifsccode");
        Label lblaccountno = (Label)gv.FindControl("lblaccountno");
        Label lblAddress = (Label)gv.FindControl("lblAddress");
        txtAccountNumber.Text = lblaccountno.Text;
        txtaddress.Text = lblAddress.Text;
        txtbankname.Text = lblbankname.Text;
        txtifsccode.Text = lblifsccode.Text;
        txtPincode.Text = lblpincode.Text;
        txtmobileno.Text = lblmobileno.Text;


        txtschemename.Text = lblschemename.Text;
        lblschemeid.Text = lblschemecd.Text;
        btnsubmit.Text = "Update";
    }
    protected void linkDelete_OnClick(object sender, EventArgs e)
    {
        GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

        Label lvlfinyear = (Label)gv.FindControl("lblyearcd");
        Label lblschemecd = (Label)gv.FindControl("lblschemecode");
        Label lblschemename = (Label)gv.FindControl("lblschemename");
        nfsmobj = new NFSM_Members();
        nfsmobj.agencycd = lblschemecd.Text;
        nfsmobj.agencyname = lblschemename.Text;

        nfsmobj.yearcd = lvlfinyear.Text;
        nfsmobj.Flag = "D";
        DataTable dt = new DataTable();
        dt = NfsmMaster.insert_Agencymaster_IURD(nfsmobj, Session["constr"].ToString());
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
}