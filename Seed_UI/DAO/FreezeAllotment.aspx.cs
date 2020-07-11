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


public partial class DAO_FreezeAllotment : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    SeedAllotBL seedObj = new SeedAllotBL();
    AOBAL objao = new AOBAL();
    CommonFuncs objCommon = new CommonFuncs();
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
        //clear Caching 
        PrevBrowCache.enforceNoCache();

        if (Session["UsrName"] == null)
        {
            Response.Redirect("~/Error.aspx");
        }

        if (!IsPostBack)
        {
            lblUsrName.Text = Session["Role"].ToString();
            lblDist.Text = Session["district"].ToString();
           
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            BindCrops();
            BindMandal();
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
       if (ddlyear.SelectedIndex == 0)
        {
            objCommon.ShowAlertMessage("Select year");
            ddlcropname.SelectedIndex = 0;
        } 
        else if (seasons.SelectedIndex == 0)
        {
            objCommon.ShowAlertMessage("Select Season");
            ddlcropname.SelectedIndex = 0;
        }
        //else if (rblcriteria.SelectedIndex == 0)
        //{
        //    objCommon.ShowAlertMessage("Select Criteria");
        //    ddlcropname.SelectedIndex = 0;
        //}
        else
        {
            dt = objao.GetSeedAllotmentCropWise(ddlyear.SelectedValue, seasons.SelectedValue, ddlcropname.SelectedValue, Session["distCode"].ToString());
            grdSeed.DataSource = dt;
            grdSeed.DataBind();

            DataTable dt1 = new DataTable();
            dt1 = objao.GetSeedAllotmentCropWiseFreezed(ddlyear.SelectedValue, seasons.SelectedValue, ddlcropname.SelectedValue, Session["distCode"].ToString());
            gvfreezed.DataSource = dt1;
            gvfreezed.DataBind();
        }
    }
    public void BindMandal()
    {
        dt = objDist.GetNewMandals(Session["distCode"].ToString());
        ddlMand.Items.Clear();
        objCommon.BindDropDownLists(ddlMand, dt, "MandName", "MandCode", "Select Mandal");
    }
    protected void rblcriteria_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblcriteria.SelectedValue == "crop")
        {
            ddlMand.Enabled = false;
            ddlcropname.Enabled = true;
            ddlMand.SelectedIndex = 0;
        }
        else
        {
            ddlMand.Enabled = true;
            ddlcropname.Enabled = false;
            ddlcropname.SelectedIndex = 0;
            //seeds.SelectedIndex = 0;           
        }
    }
  
    protected void ddlMand_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMand.SelectedIndex == 0)
            objCommon.ShowAlertMessage("Select Mandal");
        else
        {
            dt = objao.GetSeedAllotmentMandWise(ddlyear.SelectedValue, seasons.SelectedValue, Session["distCode"].ToString(), ddlMand.SelectedValue);
            grdSeed.DataSource = dt;
            grdSeed.DataBind();

            DataTable dt1 = new DataTable();
            dt1 = objao.GetSeedAllotmentMandWiseFrrezed(ddlyear.SelectedValue, seasons.SelectedValue, Session["distCode"].ToString(), ddlMand.SelectedValue);
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
        }
        dt = objao.FreezeAllotment(dtfreeze);
        if (dt.Rows.Count > 0)
            objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
    }
}