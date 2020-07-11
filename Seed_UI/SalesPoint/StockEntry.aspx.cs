using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using Seed_BL;
using Seed_BE;

public partial class SalesPoint_StockEntry : System.Web.UI.Page
{
    string strConnectionString = null;
    MasterBAL objcrop = new MasterBAL();
    SeedAllotBL seedObj = new SeedAllotBL();
    CommonFuncs cf = new CommonFuncs();
    AOBAL objao = new AOBAL();
    DataTable dt ;
    stockBE objbe = new stockBE();
    public SalesPoint_StockEntry()
    {
        //Used to get connection string by using KRCCClassLib dll file
        strConnectionString = ConfigurationManager.AppSettings["ConnectionString"];//ConfigurationManager.AppSettings["ConnectionString"];
    }
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
        if (Session["UsrName"] == null )
        {
            Response.Redirect("~/Error.aspx");
        }

        if (!IsPostBack)
        {
            lblUsrName.Text = Session["UsrName"].ToString();
            lblDist.Text = Session["district"].ToString();
            lblMand.Text = Session["mandal"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            BindCrop();
            Update.Visible = false;
            BindAgencies();
            BindComapnies();
        }
    }
    public void BindAgencies()
    {
        DataTable ddt = new DataTable();
        ddt = objcrop.getAgencies(Session["StateCode"].ToString());
        ddlagency.Items.Clear();
        cf.BindDropDownLists(ddlagency, ddt, "AgencyName", "AgencyCode", "Select Agency");
    }
    private void BindGrid()
    {
        try
        {
            dt = new DataTable();
            dt = seedObj.ViewStock(ddlyear.SelectedValue, seasons.SelectedValue, ddl_crop.SelectedValue, Session["SpCode"].ToString());

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    GridView1.EditIndex = -1;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            else
                cf.ShowAlertMessage("No Data");
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void BindComapnies()
    {
        dt = new DataTable();
        dt = objcrop.GetCompany();
        cf.BindDropDownLists(ddlcomapnies, dt, "company_name", "company_code", "Select Company");
    }
    private void BindCrop()
    {
        dt = objcrop.GetCrops();
        cf.BindDropDownLists(ddl_crop, dt, "CropName", "CropCode", "Select Crop");
    }
    private void BindCropVariety()
    {
        dt = objcrop.viewdCroplistBAL(ddl_crop.SelectedValue);
        cf.BindDropDownLists(ddl_variety, dt, "CropVName", "CropVCode", "Select Crop Variety");
    }
    protected void save_Click(object sender, EventArgs e)
    {      
        if (ValidatePage())
        {
            try
            {
                objbe.year = ddlyear.SelectedValue;
                objbe.season = seasons.SelectedValue;
                objbe.crop = ddl_crop.SelectedValue;
                objbe.cropV = Convert.ToInt16(ddl_variety.SelectedValue);
                objbe.rcvd = stkrecd.Text.Trim();
                objbe.lrdt = cf.Texttodateconverter(lrdt.Text.Trim());
                objbe.lrno = lrno.Text.Trim();
                objbe.salepoint = Session["SpCode"].ToString();
                objbe.nob = txtNo_bags.Text.Trim();
                objbe.weight = txtpcksize.Text;
                objbe.allot_id = lblaid.Text;
                objbe.agency = ddlagency.SelectedValue;
                dt = seedObj.InsertStock(objbe);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() == "1")
                        cf.ShowAlertMessage("Stock Alloted to you is finished, You can not have more stock than Allotted");
                    else
                    {
                        lblstkMax.Text = (Convert.ToDouble(lblstkMax.Text) - Convert.ToDouble(stkrecd.Text)).ToString();
                        cf.ShowAlertMessage(dt.Rows[0][0].ToString());
                        //ddl_crop.SelectedIndex = 0;
                        ddl_variety.SelectedIndex = 0;
                        lrno.Text = "";
                        lrdt.Text = "";
                        stkrecd.Text = "";
                        txtNo_bags.Text = "";
                    }
                }
                BindGrid();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }        
    }

    protected bool ValidatePage()
    {
        if (ddl_variety.SelectedIndex == 0)
        {
            cf.ShowAlertMessage("Select Crop Variety");
            ddl_variety.Focus();
            return false;
        }
        if (lrno.Text == "")
        {
            cf.ShowAlertMessage("Enter DC Number");
            lrno.Focus();
            return false;
        }
        if (lrdt.Text == "")
        {
            cf.ShowAlertMessage("Enter LR Date");
            lrdt.Focus();
            return false;
        }
        if (stkrecd.Text == "")
        {
            cf.ShowAlertMessage("Enter Stock Received in Qtls");
            stkrecd.Focus();
            return false;
        }
        if (txtNo_bags.Text == "")
        {
            cf.ShowAlertMessage("Enter Number of Bags Received");
            txtNo_bags.Focus();
            return false;
        }
        if (ddlagency.SelectedIndex==0)
        {
            cf.ShowAlertMessage("Select Agency");
            ddlagency.Focus();
            return false;
        }
        //if (decimal.Compare(Convert.ToDouble(stkrecd.Text), Convert.ToDouble(lblstkMax.Text)) == 1)
        if (Convert.ToDouble(stkrecd.Text).CompareTo(Convert.ToDouble(lblstkMax.Text)) == 1)
        {
            cf.ShowAlertMessage("Stock Allotted to you is " + lblstkMax.Text + "Qtls ,you can not have more stock than Allotted");
            return false;
        }
        //if ((Convert.ToDouble(stkrecd.Text) * 100).CompareTo(Convert.ToDouble(txtNo_bags.Text) * Convert.ToDouble(txtpcksize.Text)) != 0)
        //{
        //    cf.ShowAlertMessage(((Convert.ToDouble(stkrecd.Text) * 100)).CompareTo(Convert.ToDouble(txtNo_bags.Text) * Convert.ToDouble(txtpcksize.Text)).ToString());
        //    cf.ShowAlertMessage("Stock Received and no of bags received mis match");
        //    return false;
        //}
        return true;
    }
    private bool Check()
    {
        if (Convert.ToDouble(stkrecd.Text).CompareTo (Convert.ToDouble(lblstkMax.Text))==1)
        {
            cf.ShowAlertMessage("Stock Allotted to you is " + lblstkMax.Text + "Qtls ,you can not have more stock than Allotted");
            return false;
        }
        else
            return true;
    }
    private void CheckQty()
    {
        try
        {
            //double stkrecieved = Convert.ToDouble(stkrecd.Text);
            double nob = Convert.ToDouble(txtNo_bags.Text);
            double weight = Convert.ToDouble(txtpcksize.Text);
            stkrecd.Text = ((nob * weight) / 100).ToString();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
        //if (Double.Equals( nob * weight , stkrecieved * 100))
        //{
        //    //cf.ShowAlertMessage("nob*weight: " + nob * weight + "  stkrecieved * 100: " + stkrecieved * 100);
        //    cf.ShowAlertMessage("Stock Received and no of bags received mis match");
        //    stkrecd.Text = "";
        //    txtNo_bags.Text = "";
        //    return false;
        //}
        //else
        //    return true;
    }
    protected void ddl_crop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlyear.SelectedIndex == 0)
        {
            ddl_crop.SelectedIndex = 0;
            cf.ShowAlertMessage("Select Year First");
        }
        else if (seasons.SelectedIndex == 0)
        {
            ddl_crop.SelectedIndex = 0;
            cf.ShowAlertMessage("select season first");
        }
        else
        {
            try
            {
                dt = objcrop.getPackSize(ddl_crop.SelectedValue);
                txtpcksize.Text = dt.Rows[0][0].ToString();
                BindGrid();
                BindCropVariety();
                dt = new DataTable();
                dt = objao.GetMaxAllotemnt(ddlyear.SelectedValue, seasons.SelectedValue, ddl_crop.SelectedValue, Session["SpCode"].ToString());
                if (dt.Rows.Count > 0 && dt !=null)
                {
                    if (dt.Rows[0][1].ToString() != "")
                    {
                        Save.Visible = true;
                        lblstkMax.Text = dt.Rows[0][2].ToString();
                        lblaid.Text = dt.Rows[0][1].ToString();
                        DataTable dt1 = new DataTable();
                        dt1 = seedObj.GetSPStockID(ddlyear.SelectedValue, seasons.SelectedValue, ddl_crop.SelectedValue, Session["distCode"].ToString(), Session["mandcode"].ToString());
                        lblstkid.Text = dt1.Rows[0][0].ToString();
                    }
                    else
                    {
                        cf.ShowAlertMessage("Stock Not yet allotted for this seed");
                        Save.Visible = false;
                    }
                }
                else
                {
                    cf.ShowAlertMessage("Stock Not yet allotted for this seed");
                    Save.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
    }
    protected void ddl_variety_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_crop.SelectedValue == "25" && ddl_variety.SelectedValue == "18" || ddl_variety.SelectedValue=="22")
        {
            txtpcksize.Text = "25";
        }
        else
        {
            dt = objcrop.getPackSize(ddl_crop.SelectedValue);
            txtpcksize.Text = dt.Rows[0][0].ToString();
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edt")
        {
            GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            lblstkid.Text = ((Label)gvrow.FindControl("lblstkid")).Text;
            lrno.Text = gvrow.Cells[4].Text;
            stkrecd.Text = ((Label)gvrow.FindControl("lblrcvd")).Text;
            lbloldqty.Text = ((Label)gvrow.FindControl("lblrcvd")).Text;
            lblaid.Text = ((Label)gvrow.FindControl("lblallotid")).Text;
            txtpcksize.Text = gvrow.Cells[9].Text;
            lrdt.Text = gvrow.Cells[7].Text;
            BindCrop();
            ddl_crop.SelectedValue = ((Label)gvrow.FindControl("lblcrpcode")).Text;
            BindCropVariety();
            ddl_variety.SelectedValue = ((Label)gvrow.FindControl("lblcvcode")).Text; ;
            BindAgencies();
            ddlagency.SelectedValue = ((Label)gvrow.FindControl("lblagencycode")).Text;
            txtNo_bags.Text = gvrow.Cells[8].Text;
            ddlyear.Enabled = false;
            lrdt.Enabled = false;
            seasons.Enabled = false;
            ddl_crop.Enabled = false;
            ddl_variety.Enabled = false;
            Save.Visible = false;
            Update.Visible = true;
        }
        if (e.CommandName == "Dlt")
        {
            try
            {
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string stkid = ((Label)gvrow.FindControl("lblstkid")).Text;
                lbloldqty.Text = ((Label)gvrow.FindControl("lblrcvd")).Text;
                Label lblallotid = ((Label)gvrow.FindControl("lblallotid"));
                dt = seedObj.DeleteStock(stkid, lbloldqty.Text,lblallotid.Text);
                if (dt.Rows.Count > 0)
                {
                    lblstkMax.Text = (Convert.ToDouble(lblstkMax.Text) + Convert.ToDouble(lbloldqty.Text)).ToString();
                    cf.ShowAlertMessage(dt.Rows[0][0].ToString());
                    BindGrid();
                }
                else
                {
                    cf.ShowAlertMessage("Failed to Delete");
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }    
        }

    }
    protected void Update_Click(object sender, EventArgs e)
    {
       try
        {
            dt = seedObj.UpdateStock(stkrecd.Text.Trim(), lrno.Text.Trim(), lblstkid.Text, txtNo_bags.Text.Trim(), lblaid.Text,lbloldqty.Text);
            if (dt.Rows.Count > 0)
            {
                lblstkMax.Text = dt.Rows[0][0].ToString();
                cf.ShowAlertMessage("Updated");
                Save.Visible = true;
                Update.Visible = false;
             }
            else
            {
                string aa = "Update Failure";
                cf.ShowAlertMessage(aa);
            }
            BindGrid();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }        
    }
    protected void stkrecd_TextChanged(object sender, EventArgs e)
    {
        if (ddl_crop.SelectedIndex == 0)
        {
            cf.ShowAlertMessage("Please Select Crop & Crop Variety");
            stkrecd.Text = "";
        }
        else
        {
            if (Convert.ToDecimal(stkrecd.Text) > Convert.ToDecimal(lblstkMax.Text))
            {
                cf.ShowAlertMessage("Stock Allotted to you is " + lblstkMax.Text + "Qtls ,You can not have more stock than Allotted");
                stkrecd.Text = "";
            }
        }
       
    }

    protected void ddlcomapnies_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlyear.SelectedIndex == 0)
        {
            ddl_crop.SelectedIndex = 0;
            cf.ShowAlertMessage("Select Year First");
            stkrecd.Text = "";
        }
        else if (seasons.SelectedIndex == 0)
        {
            ddl_crop.SelectedIndex = 0;
            cf.ShowAlertMessage("select season first");
            stkrecd.Text = "";
        }
        else if (ddlcomapnies.SelectedIndex != 0)
        {
            dt = new DataTable();
            dt = objcrop.GetCropsCompanyWise(ddlcomapnies.SelectedValue);
            if (dt.Rows.Count > 0)
            {
                ddl_crop.SelectedValue = dt.Rows[0][0].ToString();
                ddl_crop.Enabled = false;
                DataTable t = new DataTable();
                t = objcrop.viewCroplistCompanyWise(dt.Rows[0][0].ToString(), ddlcomapnies.SelectedValue);
                cf.BindDropDownLists(ddl_variety, t, "CropVName", "CropVCode", "select");
                // seeds.SelectedValue = ddt.Rows[0][1].ToString();
                //seeds.Enabled = false;
                BindGrid();
                CheckCrop();
            }
            else
            {
                ddl_crop.SelectedIndex = 0;
                ddl_crop.Enabled = true;
                ddl_variety.Items.Clear();
                ddl_variety.Enabled = true;
            }
        }
        else
        {
            ddl_crop.SelectedIndex = 0;
            ddl_crop.Enabled = true;
            ddl_variety.Items.Clear();
            ddl_variety.Enabled = true;
        }
    }
    protected void CheckCrop()
    {
        try
        {
            dt = objcrop.getPackSize(ddl_crop.SelectedValue);
            txtpcksize.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = objao.GetMaxAllotemnt(ddlyear.SelectedValue, seasons.SelectedValue, ddl_crop.SelectedValue, Session["SpCode"].ToString());
            if (dt.Rows.Count > 0)
            {
                lblstkMax.Text = dt.Rows[0][2].ToString();
                lblaid.Text = dt.Rows[0][1].ToString();
                DataTable dt1 = new DataTable();
                dt1 = seedObj.GetSPStockID(ddlyear.SelectedValue, seasons.SelectedValue, ddl_crop.SelectedValue, Session["distCode"].ToString(), Session["mandcode"].ToString());
                lblstkid.Text = dt1.Rows[0][0].ToString();
            }
            else
            {
                cf.ShowAlertMessage("Stock Not yet allotted for this seed");
                Save.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void seasons_SelectedIndexChanged(object sender, EventArgs e)
    {
        dt = new DataTable();
        dt = seedObj.ViewStockSeasonWs(ddlyear.SelectedValue, seasons.SelectedValue, Session["SpCode"].ToString());

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        else
        {
            cf.ShowAlertMessage("Stock not yet entered for " + seasons.SelectedItem.Text);
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }
    protected void txtNo_bags_TextChanged(object sender, EventArgs e)
    {
        if (txtpcksize.Text != "")
            CheckQty();
        else
        {
            cf.ShowAlertMessage("Select Crop & Crop Variety");
            txtNo_bags.Text = "";
        }
    }
}