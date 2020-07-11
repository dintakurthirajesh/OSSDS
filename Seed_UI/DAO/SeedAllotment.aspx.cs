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

public partial class DAO_SeedAllotment : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    DataTable ddt = new DataTable();
    CommonFuncs objCommon = new CommonFuncs();
    AOBAL objAO = new AOBAL();
    SeedAllotBL seedobj = new SeedAllotBL();
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
        Session["StateCode"] = "36";
        lblCrop.Text = Session["cropNm"].ToString();
        //lblcv.Text = Session["cropvNm"].ToString();
        lblqty.Text = Session["qty"].ToString();
       
        if (!IsPostBack)
        {
            lblqtyAvail.Text = Session["qtyLeft"].ToString();
            lblUsrName.Text = Session["Role"].ToString();
            lblDist.Text = Session["district"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;           
            BindMandals();
            BindGrid();
        }
    }    

    protected void BindGrid()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objAO.GetSeedAllotmentMandal(Session["year"].ToString(), Session["season"].ToString(), Session["crop"].ToString(), Session["distCode"].ToString());
            grdSeed.DataSource = dt;
            grdSeed.DataBind();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    
    public void BindMandals()
    {
        ddt = objDist.GetNewMandals(Session["distCode"].ToString());
        objCommon.BindDropDownLists(ddlMand, ddt, "MandName", "MandCode", "Select Mandal");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (lblqtyAvail.Text == "0.00")
            {
                objCommon.ShowAlertMessage("Quantity is finished. Can not be allotted more.");
            }
            else if (Convert.ToDecimal(txtqty.Text) > Convert.ToDecimal(lblqtyAvail.Text))
            {
                objCommon.ShowAlertMessage("Can not Allot more than available");
                txtqty.Text = "";
            }
            else if (txtqty.Text == "0")
            {
                objCommon.ShowAlertMessage("Can not Allot 0");
                txtqty.Text = "";
            }
            else if (ddlMand.SelectedIndex == 0)
            {
                objCommon.ShowAlertMessage("Select Mandal");
                txtqty.Text = "";
            }
            else
            {
                ddt = new DataTable();
                ddt = objAO.InsertSeedAllotmentMandal(Session["year"].ToString(), Session["season"].ToString(), Session["crop"].ToString(), Convert.ToInt32(Session["cropv"]),
                    Session["distCode"].ToString(), ddlMand.SelectedValue, txtqty.Text, Session["UsrName"].ToString(), Convert.ToInt32(Session["Aid"]));
                if (ddt.Rows.Count > 0)
                {
                    if (ddt.Rows[0][0].ToString() == "1")
                    {
                        objCommon.ShowAlertMessage("Qunatity is finished,Can not be allotted more");
                    }
                    else
                    {
                        lblqtyAvail.Text = (Convert.ToDecimal(lblqtyAvail.Text) - Convert.ToDecimal(txtqty.Text)).ToString();
                        objCommon.ShowAlertMessage(ddt.Rows[0][0].ToString());
                        BindGrid();
                    }
                }
                else
                {
                    objCommon.ShowAlertMessage("Failed to Save");
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edt")
        {
            GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            ddlMand.SelectedValue = ((Label)gvrow.FindControl("lblmandcode")).Text;
            lblaid.Text = ((Label)gvrow.FindControl("lblallotid")).Text;
            lblspstkid.Text = ((Label)gvrow.FindControl("lblspstkid")).Text;
            ddlMand.Enabled = false;
            txtqty.Text = gvrow.Cells[5].Text.Trim();
            lbloldqty.Text = gvrow.Cells[5].Text.Trim();
            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }
        if (e.CommandName == "Dlt")        
        {
            try
            {
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                ddt = objAO.DeletSeedAllotmentMandal(((Label)gvrow.FindControl("lblspstkid")).Text, gvrow.Cells[5].Text.Trim(), ((Label)gvrow.FindControl("lblallotid")).Text);
                if (ddt.Rows.Count > 0)
                {
                    lblqtyAvail.Text = (Convert.ToDecimal(lblqtyAvail.Text) + Convert.ToDecimal(gvrow.Cells[5].Text)).ToString();
                    objCommon.ShowAlertMessage(ddt.Rows[0][0].ToString());
                    BindGrid();
                    txtqty.Text = "";
                    ddlMand.SelectedIndex = 0;
                }
                else
                {
                    objCommon.ShowAlertMessage("Failed to Delete");
                    txtqty.Text = "";
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
    }
    protected void btnUpdate_Click1(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objAO.UpdateSeedAllotmentMandal(lblaid.Text, lbloldqty.Text, txtqty.Text, lblspstkid.Text);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    objCommon.ShowAlertMessage("Can not allot more than availability ");
                    txtqty.Text = "";
                }
                else
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtqty.Text = "";
                }
            }
            else
            {
                if (Convert.ToDecimal(txtqty.Text) > Convert.ToDecimal(lbloldqty.Text))
                    lblqtyAvail.Text = (Convert.ToDecimal(lblqtyAvail.Text) - ((Convert.ToDecimal(txtqty.Text) - Convert.ToDecimal(lbloldqty.Text)))).ToString();
                else
                    lblqtyAvail.Text = (Convert.ToDecimal(lblqtyAvail.Text) + ((Convert.ToDecimal(lbloldqty.Text) - Convert.ToDecimal(txtqty.Text)))).ToString();

                btnSave.Visible = true;
                btnUpdate.Visible = false;
                BindGrid();
                txtqty.Text = "";
                objCommon.ShowAlertMessage("Updated");
                ddlMand.SelectedIndex = 0;
                ddlMand.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
}