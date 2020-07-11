using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Seed_BL;
using Seed_BE;

public partial class Admin_ViewStockAllotted : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    SeedAllotBL seedObj = new SeedAllotBL();
    CommonFuncs objCommon = new CommonFuncs();
    AOBAL objao = new AOBAL();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
        {
            Response.Redirect("~/Error.aspx");
        }
        else
        {
            string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
            string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
            int len = http_hos.Length;
            if (http_ref.IndexOf(http_hos, 0) < 0)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
        if (Session["UsrName"] == null || Session["UsrName"].ToString() != "Admin")
        {
            Response.Redirect("~/Error.aspx");
        }
        Session["StateCode"] = "36";
        Session["UsrName"] = "Admin";

        if (!IsPostBack)
        {
            lblUsrName.Text = Session["Role"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            BindCrops();
            BindDist("36");
        }
    }
    public void BindCrops()
    {
        dt = objDist.GetCrops();
        ddlcropname.Items.Clear();
        objCommon.BindDropDownLists(ddlcropname, dt, "CropName", "CropCode", "Select Crop Name");
    }
    protected void ddlcropname_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcropname.SelectedIndex == 0)
            objCommon.ShowAlertMessage("select crop");
        else
            BindGrid();
    }
    protected void BindGrid()
    {
        dt = seedObj.GetSeedAllotmentCropWise(ddlyear.SelectedValue, seasons.SelectedValue, ddlcropname.SelectedValue);
        grdSeed.DataSource = dt;
        grdSeed.DataBind();

        DataTable dt1 = new DataTable();
        dt1 = objao.GetSeedAllotmentDistrictCropWsFreezed(ddlyear.SelectedValue, seasons.SelectedValue, ddlcropname.SelectedValue);
        gvfreezed.DataSource = dt1;
        gvfreezed.DataBind();
    }
    public void BindDist(string StateCode)
    {
        dt = objDist.GetNewDitricts(StateCode);
        ddl_dist_code.Items.Clear();
        objCommon.BindDropDownLists(ddl_dist_code, dt, "DistName", "DistCode", "Select District");       
    }
    protected void rblcriteria_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblcriteria.SelectedValue == "crop")
        {
            ddl_dist_code.Enabled = false;
            ddlcropname.Enabled = true; 
            ddl_dist_code.SelectedIndex = 0;
        }
        else
        {
            ddl_dist_code.Enabled = true;
            ddlcropname.Enabled = false;
            ddlcropname.SelectedIndex = 0;
            //seeds.SelectedIndex = 0;           
        }
    }
    
    protected void ddl_dist_code_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_dist_code.SelectedIndex == 0)
            objCommon.ShowAlertMessage("Select District");
        else
        {
            dt = seedObj.GetSeedAllotmentDistWise(ddlyear.SelectedValue, seasons.SelectedValue, ddl_dist_code.SelectedValue);
            grdSeed.DataSource = dt;
            grdSeed.DataBind();

            DataTable dt1 = new DataTable();
            dt1 = objao.GetSeedAllotmentDistrict(ddlyear.SelectedValue, seasons.SelectedValue, ddl_dist_code.SelectedValue);
            gvfreezed.DataSource = dt1;
            gvfreezed.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       DataTable dtfreeze = new DataTable();
       dtfreeze.Columns.Add("allotment_id", typeof(string));
       int j = 0;
        foreach (GridViewRow gr in grdSeed.Rows)
        {
            if (((CheckBox)gr.FindControl("chkSelct")).Checked == true)
            {
                dtfreeze.Rows.Add();
                dtfreeze.Rows[j]["allotment_id"] = ((Label)gr.FindControl("lblAllotid")).Text;
                j++;
            }
            if(j==0)
                objCommon.ShowAlertMessage("Select atleast one row to freeze");
        }
        dt = seedObj.FreezeAllotment(dtfreeze);
        if (dt.Rows.Count > 0)
        {
            objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
            BindGrid();
        }
    }
}