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
using System.Web.UI.WebControls;

public partial class NFSM_MAO_Schemefilingsearch : System.Web.UI.Page
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
        if (Session["Rolecode"].ToString() == null )
        {
            Response.Redirect("~/nfsm/Error.aspx");
        }

        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        if (!IsPostBack)
        {
            lblUsrName.Text = Session["Role"].ToString();
            lblDist.Text = Session["district"].ToString();
            lblMand.Text = Session["mandal"].ToString();
            BindStates();
          
            getDistrictDtls();
            ddldistrict.SelectedValue = Session["distCode"].ToString();
           
            getMandalDtls();
            ddlmandal.SelectedValue = Session["mandcode"].ToString();
            ddldistrict.Enabled = false;
            ddlmandal.Enabled = false;
            getVillageDtls();
            if (Session["Rolecode"] != null)
            {
                if (Session["Rolecode"].ToString() == "4")
                {
                    ddldistrict.SelectedValue = Session["distCode"].ToString();
                    ddldistrict.Enabled = false;
                    getMandalDtls();
                    ddlmandal.SelectedValue = Session["mandcode"].ToString();
                    //  ddlmandal.Enabled = false;
                    getVillageDtls();
                    lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                    lblUsrName.Text = Session["Role"].ToString();
                    lblDist.Text = Session["district"].ToString();
                    lblMand.Text = Session["mandal"].ToString();

                }
            }
        }
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
    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldistrict.SelectedValue != "")
        {
            getMandalDtls();

            ddlvillage.Items.Clear();

            ddlvillage.Items.Insert(0, new ListItem("Select Village", ""));
        }
    }
    protected void ddlmandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlmandal.SelectedValue != "")
        {
            getVillageDtls();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        loadgrid();
    }

    private void loadgrid()
    {
        try
        {
            DataTable dt = new DataTable();
            if (ddldistrict.SelectedValue != "")
            {
                nfsmobj.distcd = ddldistrict.SelectedValue;
            }
            if (ddlmandal.SelectedValue != "")
            {
                nfsmobj.mandalcd = ddlmandal.SelectedValue;
            }
            if (ddlvillage.SelectedValue != "")
            {
                nfsmobj.villagecd = ddlvillage.SelectedValue;
            }
            dt = obj.GetFarmerBasicDetails(nfsmobj, Session["constr"].ToString());
            if (dt.Rows.Count > 0)
            {
                gvschmefiling.Visible = true;
                gvschmefiling.DataSource = dt;
                gvschmefiling.DataBind();
            }
            else
            {
                gvschmefiling.Visible = false;
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
        BindStates();
        getDistrictDtls();
        ddlmandal.Items.Clear();
        ddlvillage.Items.Clear();
        ddlmandal.Items.Insert(0, new ListItem("Select Mandal", ""));
        ddlvillage.Items.Insert(0, new ListItem("Select Village", ""));
        txtfarmerid.Text = "";
        if (Session["Rolecode"] != null)
        {
            if (Session["Rolecode"].ToString() == "4")
            {
                ddldistrict.SelectedValue = Session["distCode"].ToString();
                ddldistrict.Enabled = false;
                getMandalDtls();
                ddlmandal.SelectedValue = Session["mandcode"].ToString();
                //  ddlmandal.Enabled = false;
                getVillageDtls();

            }
        }
    }

    protected void linkfarmerid_OnClick(object sender, EventArgs e)
    {
        GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;
        Label lbldistcode = (Label)gv.FindControl("lblDistCode");
        LinkButton lblfarmerid = (LinkButton)gv.FindControl("linkfarmerid");
        Session["farmerid"] = lblfarmerid.Text;
            Session["distcd"]=lbldistcode.Text;
            Response.Redirect("~/nfsm/mao/SchemeFiling.aspx");

    }
}