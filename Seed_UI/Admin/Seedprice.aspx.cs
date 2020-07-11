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

public partial class Seed_UI_Masters_Seedprice : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    SeedPriceBE seedbeobj = new SeedPriceBE();
    SeedPriceBL seedblobj = new SeedPriceBL();
    DataTable ddt = new DataTable();
    CommonFuncs objCommon = new CommonFuncs();
    string StateCode = "";
    string UserName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //Htpp Referer Check
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
        StateCode = Session["StateCode"].ToString();
        UserName = Session["UsrName"].ToString();
       
        if (!IsPostBack)
        {
            lblUsrName.Text = Session["Role"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            BindCrops();
            BindComapnies();
        }
    }

    protected void BindComapnies()
    {
        ddt = new DataTable();
        ddt = objDist.GetCompany();
        objCommon.BindDropDownLists(ddlcomapnies, ddt, "company_name", "company_code", "Select Company");
    }
    public void BindCrops()
    {
        ddt = objDist.GetCrops();
        objCommon.BindDropDownLists(ddlcropname,ddt,"CropName","CropCode","Select Crop Name");        
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {        
        if (e.CommandName == "Edt")
        {
            GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            DataTable dt1 = new DataTable();
            ddlcropname.SelectedValue = gvrow.Cells[3].Text.Trim();
            dt1 = objDist.viewdCroplistBAL(ddlcropname.SelectedValue);
            objCommon.BindDropDownLists(seeds, dt1, "CropVName", "CropVCode", "Select");
            seeds.SelectedValue= gvrow.Cells[5].Text.Trim();
            //seeds.Enabled = false;           
            txtmrp.Text =  gvrow.Cells[7].Text;
            txtprice.Text = gvrow.Cells[8].Text;
            txtsubsidy.Text = gvrow.Cells[9].Text; 
            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }
        if (e.CommandName == "Dlt") 
        {
            GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            HiddenField hdncropcode = (HiddenField)gvrow.FindControl("hdncropcode");
            seedbeobj.Year = gvrow.Cells[1].Text;
            seedbeobj.Season = gvrow.Cells[2].Text;
            string cv = gvrow.Cells[4].Text;
            seedbeobj.CropVCode = cv;
            seedbeobj.Action = "D";
            ddt = seedblobj.SeedPrice_IUDRBL(seedbeobj);
            if (ddt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage(ddt.Rows[0][0].ToString());
                txtmrp.Text = "";
                txtprice.Text = "";
                //txtseedvariety.Text = "";
                BindGrid();
            }
            else
            {
                objCommon.ShowAlertMessage("Failed to Delete");
            }
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        seedbeobj.Year = ddlyear.SelectedItem.Text;
        seedbeobj.Season = seasons.SelectedItem.Text;
        seedbeobj.CropCode = ddlcropname.SelectedValue.ToString();
        seedbeobj.CropVCode = seeds.SelectedValue.ToString();
        seedbeobj.Actual_Price = Convert.ToDouble(txtmrp.Text.Trim());
        seedbeobj.Subsidized_Price = Convert.ToDouble(txtprice.Text.Trim());
        seedbeobj.Company = ddlcomapnies.SelectedValue;
        seedbeobj.UserName = UserName;
        if (seeds.SelectedValue == "ALL")
            seedbeobj.Action = "A";
        else
            seedbeobj.Action = "I";
        ddt = seedblobj.SeedPrice_IUDRBL(seedbeobj);
        if (ddt.Rows.Count > 0)
        {
            objCommon.ShowAlertMessage(ddt.Rows[0][0].ToString());
            txtmrp.Text = "";
            txtprice.Text = "";
            txtsubsidy.Text = "";
            // txtseedvariety.Text = "";
            BindGrid();
        }
        else
        {
            objCommon.ShowAlertMessage("Failed to Insert");
        }       
    }
    protected void bindSeeds()
    {
        DataTable dt1 = new DataTable();
        dt1 = objDist.viewCroplistCompanyWise(ddlcropname.SelectedValue,ddlcomapnies.SelectedValue);
        objCommon.BindDropDownLists_WithAllOption(seeds, dt1, "CropVName", "CropVCode", "Select Crop Variety"); 
    }
    protected void seeds_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void ddlcropname_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlyear.SelectedIndex > 0 && ddlcropname.SelectedIndex > 0)
        {
            seeds.Items.Clear();
            bindSeeds();
            BindGrid();
            seeds.Enabled = true;
        }
        else
        {
            objCommon.ShowAlertMessage("Select Year");
            ddlcropname.SelectedIndex = 0;
        }
    }
    
    protected void btnUpdate_Click1(object sender, EventArgs e)
    {       
        seedbeobj.Actual_Price = Convert.ToDouble(txtmrp.Text.Trim());
        seedbeobj.Subsidized_Price = Convert.ToDouble(txtprice.Text.Trim());
        seedbeobj.Year = ddlyear.SelectedItem.Text;
        seedbeobj.Season = seasons.SelectedItem.Text;
        seedbeobj.CropCode = ddlcropname.SelectedValue.ToString();
        seedbeobj.CropVCode = seeds.SelectedValue.ToString();
        // seedbeobj.SeedVarietyName = txtseedvariety.Text.Trim();
        seedbeobj.UserName = UserName;
        seedbeobj.Action = "U";
        ddt = seedblobj.SeedPrice_IUDRBL(seedbeobj);
        if (ddt.Rows.Count > 0)
        {
            objCommon.ShowAlertMessage(ddt.Rows[0][0].ToString());
            txtmrp.Text = "";
            txtprice.Text = "";
            // txtseedvariety.Text = "";
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            seedbeobj.Year = ddlyear.SelectedItem.Text;
            seedbeobj.Season = seasons.SelectedItem.Text;
            seedbeobj.CropCode = ddlcropname.SelectedValue.ToString();
            seedbeobj.Action = "V";
            ddt = seedblobj.SeedPrice_IUDRBL(seedbeobj);
      
            if (ddt.Rows.Count > 0)
            {
                grdSeedPrice.Visible = true;
                grdSeedPrice.DataSource = ddt;
                grdSeedPrice.DataBind();
            }
        }
        else
        {
            objCommon.ShowAlertMessage("Update Failed");
        }       
    }

    public void BindGrid()
    {
        ddt.Clear();
        ddt.Columns.Clear();
        seedbeobj.Year = ddlyear.SelectedItem.Text;
        seedbeobj.Season = seasons.SelectedItem.Text;
        seedbeobj.CropCode = ddlcropname.SelectedValue.ToString();
        if (seeds.SelectedIndex != 0)
        {
            seedbeobj.CropVCode = seeds.SelectedValue.ToString();
            seedbeobj.Action = "R";
        }
       
        else
        {
            seedbeobj.Action = "V";
        }
        ddt = seedblobj.SeedPrice_IUDRBL(seedbeobj);
        if (ddt != null)
        {
            if (ddt.Rows.Count > 0)
            {
                grdSeedPrice.Visible = true;
                grdSeedPrice.DataSource = ddt;
                grdSeedPrice.DataBind();
            }
            else
            {
                objCommon.ShowAlertMessage("No Data Found");
                txtmrp.Text = "";
                txtprice.Text = "";
                //txtseedvariety.Text = "";
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                grdSeedPrice.Visible = false;
            }
        }
        else
        {
            objCommon.ShowAlertMessage("Price Not yet Entered for this seed");
        }
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlyear.SelectedIndex > 0 && ddlcropname.SelectedIndex > 0)
        {
            BindGrid();
        }
    }

    protected void txtsubsidy_TextChanged(object sender, EventArgs e)
    {
        if (ddlyear.SelectedIndex == 0)
        {
            objCommon.ShowAlertMessage("Select Year");
            txtmrp.Text = "";
            txtsubsidy.Text = "";
        }

        if (seasons.SelectedIndex == 0)
        {
            objCommon.ShowAlertMessage("Select season");
            txtmrp.Text = "";
            txtsubsidy.Text = "";
        }

        if (ddlcropname.SelectedIndex == 0)
        {
            objCommon.ShowAlertMessage("Select Crop");
            txtmrp.Text = "";
            txtsubsidy.Text = "";
        }

        if (txtmrp.Text == "")
            objCommon.ShowAlertMessage("Enter Actual MRP");

        if (txtsubsidy.Text == "")
            objCommon.ShowAlertMessage("Enter Subsidy");
        else
        {
            txtprice.Text = (Convert.ToDouble(txtmrp.Text) - Convert.ToDouble(txtsubsidy.Text)).ToString();
        }
    }
    protected void ddlcomapnies_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcomapnies.SelectedIndex != 0)
        {
            ddt=new DataTable();
            ddt = objDist.GetCropsCompanyWise(ddlcomapnies.SelectedValue);
            if (ddt.Rows.Count > 0)
            {
                ddlcropname.SelectedValue = ddt.Rows[0][0].ToString();
                //ddlcropname.Enabled = false;
                DataTable t = new DataTable();
                t = objDist.viewCroplistCompanyWise(ddt.Rows[0][0].ToString(),ddlcomapnies.SelectedValue);
                objCommon.BindDropDownLists(seeds, t, "CropVName", "CropVCode", "select");
               // seeds.SelectedValue = ddt.Rows[0][1].ToString();
                //seeds.Enabled = false;
                BindGrid();
            }           
        }
        else
        {
            ddlcropname.SelectedIndex = 0;
            ddlcropname.Enabled = true;
            seeds.Items.Clear();
            seeds.Enabled = true;
        }
    }
    protected void seasons_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            seedbeobj.Year = ddlyear.SelectedItem.Text;
            seedbeobj.Season = seasons.SelectedItem.Text;
            seedbeobj.Action = "S";
            ddt = seedblobj.SeedPrice_IUDRBL(seedbeobj);
            if (ddt.Rows.Count > 0)
            {
                grdSeedPrice.Visible = true;
                grdSeedPrice.DataSource = ddt;
                grdSeedPrice.DataBind();
            }
            else
            {
                objCommon.ShowAlertMessage("No Data Found");
                txtmrp.Text = "";
                txtprice.Text = "";
                //txtseedvariety.Text = "";
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                grdSeedPrice.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }   
    }
}