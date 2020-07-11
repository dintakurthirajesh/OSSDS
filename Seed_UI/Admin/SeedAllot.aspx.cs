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

public partial class Admin_SeedAllot : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    SeedAllotBL seedObj = new SeedAllotBL();
    DataTable ddt = new DataTable();
    CommonFuncs objCommon = new CommonFuncs();
    AOBAL objao = new AOBAL();
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
            BindDist();
            BindAgencies();
        }
    }
    public void BindAgencies()
    {
        ddt = objDist.getAgencies(Session["StateCode"].ToString());
        ddlAgency.Items.Clear();
        objCommon.BindDropDownLists(ddlAgency, ddt, "AgencyName", "AgencyCode", "Select Agency");
    }
    public void BindCrops()
    {
        ddt = objDist.GetCrops();
        ddlcropname.Items.Clear();
        objCommon.BindDropDownLists(ddlcropname, ddt, "CropName", "CropCode", "Select Crop Name");
    }
    public void BindDist()
    {
        ddt = objDist.GetNewDitricts(Session["StateCode"].ToString());
        objCommon.BindDropDownLists(ddl_dist_code,ddt,"DistName","DistCode","Select District");
    }
    protected bool validate()
    {
        if (ddlyear.SelectedIndex == 0)
        {
            objCommon.ShowAlertMessage("select year");
            return false;
        }
        if (seasons.SelectedIndex == 0)
        {
            objCommon.ShowAlertMessage("select season");
            return false;
        }
        if (ddlcropname.SelectedIndex == 0)
        {
            objCommon.ShowAlertMessage("select crop");
            return false;
        }
        if (ddlAgency.SelectedIndex == 0)
        {
            objCommon.ShowAlertMessage("select Agency");
            return false;
        }
        if (ddl_dist_code.SelectedIndex == 0)
        {
            objCommon.ShowAlertMessage("select District");
            return false;
        }
        return true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (validate())
        {
            ddlyear.Enabled = false;
            seasons.Enabled = false;
            ddlAgency.Enabled = false;
            ddlcropname.Enabled = false;
            
            DataTable dt = new DataTable();
            if (seeds.SelectedValue == "ALL")
            {
                dt = seedObj.InsertSeedAllotmentAll(ddlyear.SelectedValue, seasons.SelectedValue, ddlcropname.SelectedValue,
                ddl_dist_code.SelectedValue, txtalloted_qty.Text, Session["UsrName"].ToString(), ddlAgency.SelectedValue);
            }
            if (seeds.SelectedValue == "Any")
            {
                dt = seedObj.InsertSeedAllotmentAny(ddlyear.SelectedValue, seasons.SelectedValue, ddlcropname.SelectedValue,
                ddl_dist_code.SelectedValue, txtalloted_qty.Text, Session["UsrName"].ToString(), ddlAgency.SelectedValue);
            }
            else
            {
                dt = seedObj.InsertSeedAllotment(ddlyear.SelectedValue, seasons.SelectedValue, ddlcropname.SelectedValue, Convert.ToInt16(seeds.SelectedValue),
                ddl_dist_code.SelectedValue, txtalloted_qty.Text, Session["UsrName"].ToString(), ddlAgency.SelectedValue);
            }
            if (dt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                ddl_dist_code.SelectedIndex = 0;
                txtalloted_qty.Text = "";
                BindGrid();
            }
        }
    } 
   
    protected void BindGrid()
    {
        DataTable dt = new DataTable();
        dt = seedObj.GetSeedAllotmentCropWise(ddlyear.SelectedValue, seasons.SelectedValue,ddlcropname.SelectedValue);
        grdSeed.DataSource = dt;
        grdSeed.DataBind();
    } 

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edt")
        {
            GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            ddlAgency.SelectedValue = ((Label)gvrow.FindControl("lblagencycode")).Text;
            ddlcropname.SelectedValue = ((Label)gvrow.FindControl("lblcropcode")).Text;
            DataTable dt1 = new DataTable();
            dt1 = objDist.viewdCroplistBAL(ddlcropname.SelectedValue);
            objCommon.BindDropDownLists(seeds, dt1, "CropVnmTel", "CropVCode", "Select");
            seeds.SelectedValue = ((Label)gvrow.FindControl("lblcv")).Text;
            ddl_dist_code.SelectedValue = ((Label)gvrow.FindControl("lbldistcode")).Text;
            lblaid.Text = ((Label)gvrow.FindControl("lblallotid")).Text;
            ddlyear.Enabled = false;
            seasons.Enabled = false;
            ddlcropname.Enabled = false;
            ddlAgency.Enabled = false;
            seeds.Enabled = false;
            ddl_dist_code.Enabled = false;
            txtalloted_qty.Text = gvrow.Cells[6].Text.Trim();
            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }
        if (e.CommandName == "Dlt")
        {
            GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            ddt = seedObj.DeletSeedAllotment(((Label)gvrow.FindControl("lblallotid")).Text, gvrow.Cells[6].Text.Trim());
            if (ddt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage(ddt.Rows[0][0].ToString());
                BindGrid();
            }
            else
            {
                objCommon.ShowAlertMessage("Failed to Delete");
            }
        }
    }
    protected void btnUpdate_Click1(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = seedObj.UpdateSeedAllotment(lblaid.Text, txtalloted_qty.Text);
        if (dt.Rows.Count > 0)
        {
            objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
            /*ddlyear.SelectedIndex = 0;
            seasons.SelectedIndex = 0;
            ddlcropname.SelectedIndex = 0;
            seeds.SelectedIndex = 0;
            ddl_dist_code.SelectedIndex = 0;
            txtalloted_qty.Text = "";*/
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            BindGrid();
        }
        else
        {
            objCommon.ShowAlertMessage("Update Failed");
        }
    }
    
    protected void seeds_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlcropname.SelectedIndex==0)
            objCommon.ShowAlertMessage("Select Crop");
        else if (seeds.SelectedIndex == 0)
            objCommon.ShowAlertMessage("Select Crop Variety");
        else
        {
            DataTable dt = new DataTable();
            dt = objao.GetSeedAllotment(ddlyear.SelectedValue, seasons.SelectedValue,ddlcropname.SelectedValue,seeds.SelectedValue);
            grdSeed.DataSource = dt;
            grdSeed.DataBind();
        }
    }
    protected void ddlcropname_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlyear.SelectedIndex == 0)
            objCommon.ShowAlertMessage("Select Year");
        else if (seasons.SelectedIndex == 0)
            objCommon.ShowAlertMessage("Select Season");
        else
        {
            DataTable dt1 = new DataTable();
            dt1 = objDist.viewdCroplistBAL(ddlcropname.SelectedValue);
            //objCommon.BindDropDownLists_WithAllOption(seeds, dt1, "CropVnmTel", "CropVCode", "Select Crop");
            objCommon.BindDropDownLists_WithAnyOption(seeds, dt1, "CropVnmTel", "CropVCode", "Select Crop");
            BindGrid();
        }
    }
}