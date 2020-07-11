using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_BL;
using System.Data;
using System.Web.Security;

public partial class MAO_AddRepresentative : System.Web.UI.Page
{
    AOBAL objao = new AOBAL();
    SeedAllotBL seedObj = new SeedAllotBL();
    CommonFuncs cf = new CommonFuncs();
    DataTable dt;
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
        if (Session["UsrName"] == null)
        {
            Response.Redirect("~/Error.aspx");
        }
        lblUsrName.Text = Session["Role"].ToString();
        lblDist.Text = Session["district"].ToString();
        lblMand.Text = Session["mandal"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        if (!IsPostBack)
        {
            BindGrid();
            BindSps();
        }
    }
    protected void BindSps()
    {
        DataTable dt = new DataTable();
        dt = seedObj.GetSalepoints(Session["StateCode"].ToString(), Session["distCode"].ToString(), Session["mandcode"].ToString());
        cf.BindDropDownLists(ddlsps, dt, "SalePtName", "SalePtCode", "select sale point");
    }
    protected void BindGrid()
    {
        dt = new DataTable();
        dt = objao.GetRep(Session["StateCode"].ToString(), Session["distCode"].ToString(), Session["mandcode"].ToString());
        RepGrid.DataSource = dt;
        RepGrid.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int active = Convert.ToInt32(rblActive.SelectedValue);
            dt = new DataTable();
            dt = objao.AddRep(Session["StateCode"].ToString(), Session["distCode"].ToString(), Session["mandcode"].ToString(), ddlsps.SelectedValue,
               txtusernm.Text.Trim(), active.ToString(), txtnm.Text.Trim(), txtdesig.Text.Trim(), txtmobile.Text.Trim(), Session["UsrName"].ToString());
            if (dt.Rows.Count > 0)
            {
                cf.ShowAlertMessage(dt.Rows[0][0].ToString());
                txtnm.Text = "";
                txtdesig.Text = "";
                txtmobile.Text = "";
                txtusernm.Text = "";
                BindGrid();
            }
            else
                cf.ShowAlertMessage("Not Saved");
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void RepGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
         if (e.CommandName == "Edt")
        {
            GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            txtnm.Text = gvrow.Cells[1].Text;
            txtdesig.Text = gvrow.Cells[2].Text;
            txtmobile.Text = gvrow.Cells[3].Text;
            ddlsps.SelectedValue=((Label)gvrow.FindControl("lblspcode")).Text;
            txtusernm.Text = ((Label)gvrow.FindControl("lblusernm")).Text;
            lblrepcode.Text = ((Label)gvrow.FindControl("lblrepid")).Text;
            Label lblactive = (Label)gvrow.FindControl("lblActive");
            if (lblactive.Text == "True")
            {
                rblActive.SelectedIndex = 0;
            }
            else
            {
                rblActive.SelectedIndex = 1;
            }
            
            btn_save.Visible = false;
            btn_update.Visible = true;
        }
        if (e.CommandName == "Dlt")
        {
            try
            {
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                lblrepcode.Text = ((Label)gvrow.FindControl("lblrepid")).Text;
                dt = objao.DeleteRep(lblrepcode.Text);
                if (dt.Rows.Count > 0)
                    cf.ShowAlertMessage(dt.Rows[0][0].ToString());
                else
                    cf.ShowAlertMessage("Delete Failed");
                BindGrid();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
    }
    protected void  Update_Click(object sender, EventArgs e)
    {
        try
        {
            int active = Convert.ToInt32(rblActive.SelectedValue);
            dt = new DataTable();
            dt = objao.UpdateRep(Session["StateCode"].ToString(), Session["distCode"].ToString(), Session["mandcode"].ToString(), active.ToString(), txtnm.Text.Trim(),
                txtdesig.Text.Trim(), txtmobile.Text.Trim(), ddlsps.SelectedValue, lblrepcode.Text, txtusernm.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                cf.ShowAlertMessage(dt.Rows[0][0].ToString());
                txtnm.Text = "";
                txtdesig.Text = "";
                txtmobile.Text = "";
                txtusernm.Text = "";
                BindGrid();
            }
            else
                cf.ShowAlertMessage("Update Failed");
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void RepGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        RepGrid.PageIndex = e.NewPageIndex;
        BindGrid();
    }
}