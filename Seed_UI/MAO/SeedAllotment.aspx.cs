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


public partial class MAO_SeedAllotment : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    DataTable dt ;
    CommonFuncs objCommon = new CommonFuncs();
    SeedAllotBL seedObj = new SeedAllotBL();
    AOBAL objAO = new AOBAL();
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
            lblMand.Text = Session["mandal"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            lblCrop.Text = Session["cropNm"].ToString();
            lblqty.Text = Session["qty"].ToString();
            lblqtyAvail.Text = Session["qtyLeft"].ToString();
           // BindCV();
            BindSP();
            BindGrid();
        }
    }
    /*protected void BindCV()
    {
        dt = objDist.viewdCroplistBAL(Session["crop"].ToString());
        objCommon.BindDropDownLists_WithAllOption(ddlcv, dt, "CropVName", "CropVCode", "Select");
    }*/
    protected void BindSP()
    {
        dt = new DataTable();
        dt = seedObj.GetSalepoints(Session["StateCode"].ToString(), Session["distCode"].ToString(), Session["mandcode"].ToString());
        objCommon.BindDropDownLists(ddlsp, dt, "SalePtName", "SalePtCode", "select sale point");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlsp.SelectedIndex == 0)
            {
                objCommon.ShowAlertMessage("select sale point");
            }
            else if (txtqty.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Quantity to be allotted");
            }
            else
            {
                if (lblqtyAvail.Text == "0.00")
                {
                    objCommon.ShowAlertMessage("Quantity is finished. Can not be allotted more.");
                }
                else if (Convert.ToDecimal(txtqty.Text) > Convert.ToDecimal(lblqtyAvail.Text))
                {
                    objCommon.ShowAlertMessage("Can not Allot more than available");
                }
                else if (txtqty.Text == "0")
                {
                    objCommon.ShowAlertMessage("Can not Allot 0");
                    txtqty.Text = "";
                }
                else
                {
                    dt = new DataTable();
                    dt = objAO.InsertSeedAllotmentSP(Session["Aid"].ToString(), ddlsp.SelectedValue, txtqty.Text.Trim(), Session["UsrName"].ToString(),
                        Session["agency"].ToString(), Session["year"].ToString(), Session["season"].ToString(), Session["crop"].ToString(),
                        Session["distCode"].ToString(), Session["mandcode"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            objCommon.ShowAlertMessage("Qunatity is finished,Can not be allotted more");
                        }
                        else
                        {
                            lblqtyAvail.Text = (Convert.ToDecimal(lblqtyAvail.Text) - Convert.ToDecimal(txtqty.Text)).ToString();
                            objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                            BindGrid();
                        }
                    }
                    else
                    {
                        objCommon.ShowAlertMessage("Failed to Save");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void BindGrid()
    {
        try
        {
            dt = new DataTable();
            dt = objAO.GetSeedAllotmentSP(Session["year"].ToString(), Session["season"].ToString(), Session["distCode"].ToString(), Session["mandcode"].ToString());
            if (dt.Rows.Count > 0)
            {               
                grdSeed.DataSource = dt;
                this.grdSeed.EditIndex = -1;
                grdSeed.DataBind();
            }
            else
            {
                grdSeed.DataSource = null;
                grdSeed.DataBind();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void btnUpdate_Click1(object sender, EventArgs e)
    {
        try
        {
            dt = new DataTable();
            dt = objAO.UpdateSeedAllotmentSP(lbloldqty.Text, txtqty.Text.Trim(), lblspstkid.Text, lblallotid.Text);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    if (Convert.ToDecimal(txtqty.Text) > Convert.ToDecimal(lbloldqty.Text))
                        lblqtyAvail.Text = (Convert.ToDecimal(lblqtyAvail.Text) - ((Convert.ToDecimal(txtqty.Text) - Convert.ToDecimal(lbloldqty.Text)))).ToString();
                    else
                        lblqtyAvail.Text = (Convert.ToDecimal(lblqtyAvail.Text) + ((Convert.ToDecimal(lbloldqty.Text) - Convert.ToDecimal(txtqty.Text)))).ToString();
                    objCommon.ShowAlertMessage("Updated");
                    txtqty.Text = "";
                    ddlsp.Enabled = true;
                    ddlsp.SelectedIndex = 0;
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    BindGrid();
                }
                else
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
            }
            else
            {
                objCommon.ShowAlertMessage("Update Failed");
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edt")
        {
            GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            ddlsp.SelectedValue = ((Label)gvrow.FindControl("lblspcode")).Text;
            lblspstkid.Text = ((Label)gvrow.FindControl("lblspstkid")).Text;
            lblallotid.Text = ((Label)gvrow.FindControl("lblallotid")).Text;

            ddlsp.Enabled = false;
            txtqty.Text = gvrow.Cells[5].Text.Trim();
            lbloldqty.Text = gvrow.Cells[5].Text.Trim();
            ddlsp.Enabled = false;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }
        if (e.CommandName == "Dlt")
        {
            try
            {
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                lblspstkid.Text = ((Label)gvrow.FindControl("lblspstkid")).Text;
                lblallotid.Text = ((Label)gvrow.FindControl("lblallotid")).Text;
                txtqty.Text = gvrow.Cells[5].Text.Trim();
                dt = new DataTable();
                dt = objAO.DeleteSeedAllotmentSP(lblallotid.Text, txtqty.Text, lblspstkid.Text);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        lblqtyAvail.Text = (Convert.ToDouble(lblqtyAvail.Text) + Convert.ToInt32(txtqty.Text)).ToString();
                        BindGrid();
                        txtqty.Text = "";
                        ddlsp.SelectedIndex = 0;
                        objCommon.ShowAlertMessage("Deleted");
                    }
                     else
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                }
                else
                {
                    objCommon.ShowAlertMessage("Failed to Delete");
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
    }
    protected void txtqty_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToDouble(lblqtyAvail.Text) != 0)
            {
                if (Convert.ToDouble(lblqtyAvail.Text) < Convert.ToDouble(txtqty.Text))
                {
                    objCommon.ShowAlertMessage("You are alloting more than availble ");
                    txtqty.Text = "";
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
}