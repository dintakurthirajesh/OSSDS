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
        if (!IsPostBack)
        {

            bindscheme();
            bindgridview();
        }
    }

    protected void bindscheme()
    {
        DataTable dt = new DataTable();
        nfsmobj = new NFSM_Members();


        nfsmobj.Flag = "R";
        dt = NfsmMaster.insert_Scheme_IURD(nfsmobj, Session["constr"].ToString());
        objCommon.BindDropDownLists_withZero(ddlschemename, dt, "scheme_name", "scheme_code", "Select Scheme");

        ddlsubcheme.Items.Clear();
        ddlsubcheme.Items.Insert(0, new ListItem("Select Component", "0"));
    }
    protected void bindsubscheme()
    {
        DataTable dt = new DataTable();
        nfsmobj = new NFSM_Members();


        if (ddlschemename.SelectedValue != "")
        {
            nfsmobj.schemecode = ddlschemename.SelectedValue;
        }
        nfsmobj.Flag = "R";
        dt = NfsmMaster.insert_subScheme_IURD(nfsmobj, Session["constr"].ToString());
        objCommon.BindDropDownLists_withZero(ddlsubcheme, dt, "Component_name", "Component_code", "Select Component");


    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        nfsmobj.schemecode = ddlschemename.SelectedValue;
        nfsmobj.Componentcode = ddlsubcheme.SelectedValue;
        nfsmobj.intervensionname = txtcropname.Text;
        nfsmobj.ipaddress = HttpContext.Current.Request.UserHostAddress;
        nfsmobj.userid = Session["UsrName"].ToString();
        if (btnsubmit.Text != "Update")
        {
            nfsmobj.Flag = "I";
        }
        else
        {
            nfsmobj.Flag = "U";
            nfsmobj.intervensioncd = lblcropcode.Text;
        }
        DataTable dt = new DataTable();
        dt = NfsmMaster.insert_crop_IURD(nfsmobj, Session["constr"].ToString());
        if (dt.Rows.Count > 0)
        {
            objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
            Cleardata();
        }
        else
        {
            objCommon.ShowAlertMessage("Crop Details Not " + btnsubmit.Text + " Successfully");
        }
    }
    private void Cleardata()
    {

        lblcropcode.Text = "";
        btnsubmit.Text = "Submit";

        txtcropname.Text = "";
        bindgridview();
        bindscheme();
    }
    protected void bindgridview()
    {
        DataTable dt = new DataTable();
        nfsmobj = new NFSM_Members();


        if (ddlsubcheme.SelectedValue != "" && ddlsubcheme.SelectedValue != "0")
        {
            nfsmobj.Componentcode = ddlsubcheme.SelectedValue;
        }
        if (ddlschemename.SelectedValue != "" && ddlschemename.SelectedValue != "0")
        {
            nfsmobj.schemecode = ddlschemename.SelectedValue;
        }
        nfsmobj.Flag = "R";
        dt = NfsmMaster.insert_crop_IURD(nfsmobj, Session["constr"].ToString());
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

    protected void linklinkedit_OnClick(object sender, EventArgs e)
    {


        GridViewRow gv = (GridViewRow) ((LinkButton) sender).NamingContainer;
        Label lvlfinyear = (Label) gv.FindControl("lblyearcd");
        Label lblschemecd = (Label) gv.FindControl("lblschemecode");
        Label lblsubschemecode = (Label) gv.FindControl("lblsubschemecode");
        Label lblcropcd = (Label) gv.FindControl("lblcropcode");

        Label lblcropname = (Label) gv.FindControl("lblcropname");

        bindscheme();
        ddlschemename.SelectedValue = lblschemecd.Text.Trim();
        bindsubscheme();
        ddlsubcheme.SelectedValue = lblsubschemecode.Text.Trim();
        txtcropname.Text = lblcropname.Text;
        lblcropcode.Text = lblcropcd.Text;
        btnsubmit.Text = "Update";
    }
    protected void linkDelete_OnClick(object sender, EventArgs e)
    {
        GridViewRow gv = (GridViewRow) ((LinkButton) sender).NamingContainer;
        Label lvlfinyear = (Label) gv.FindControl("lblyearcd");
        Label lblschemecd = (Label) gv.FindControl("lblschemecode");
        Label lblsubschemecode = (Label) gv.FindControl("lblsubschemecode");
        Label lblcropcode = (Label) gv.FindControl("lblcropcode");

        Label lblcropname = (Label) gv.FindControl("lblcropname");
        nfsmobj = new NFSM_Members();
        nfsmobj.schemecode = lblschemecd.Text;
        nfsmobj.intervensioncd = lblcropcode.Text;
        nfsmobj.intervensionname = lblcropname.Text;
        nfsmobj.Componentcode = lblsubschemecode.Text;

        nfsmobj.Flag = "D";
        DataTable dt = new DataTable();
        dt = NfsmMaster.insert_crop_IURD(nfsmobj, Session["constr"].ToString());
        if (dt.Rows.Count > 0)
        {
            objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
            Cleardata();
        }
        bindgridview();

    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Cleardata(); ;
    }
    protected void ddlschemename_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindsubscheme();
        bindgridview();
    }
    protected void ddlsubcheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgridview();
    }
}
