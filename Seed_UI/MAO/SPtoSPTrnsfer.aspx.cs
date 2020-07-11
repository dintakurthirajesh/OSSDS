using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_BL;
using System.Data;
using System.Web.Security;

public partial class MAO_SPtoSPTrnsfer : System.Web.UI.Page
{
    CommonFuncs cf = new CommonFuncs();   
    StockTransfer_BL st = new StockTransfer_BL();
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
            lblspnm.Text = Session["spnm"].ToString();
            lblcrop.Text = Session["cropnm"].ToString();
            lblqty.Text = Session["stkleft"].ToString();
            lblnob.Text = Session["bagsleft"].ToString();
            BindSP();
        }
    }
    protected void BindSP()
    {
        try
        {
            dt = new DataTable();
            dt = st.GetSps(Session["spcode"].ToString(), Session["distCode"].ToString(), Session["mandcode"].ToString());
            if (dt.Rows.Count > 0)
            {
                cf.BindDropDownLists(ddlsp, dt, "SalePtName", "SalePtCode", "Select Salepoint");
                txtqty.Enabled = true;
            }
            else
            {
                cf.ShowAlertMessage("There is no another SalePoint in the Mandal");
                txtqty.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        dt = new DataTable();
        dt = st.SptoSpTransfer(Session["spcode"].ToString(), Session["crop"].ToString(), Session["cropV"].ToString(), Session["year"].ToString(), Session["season"].ToString()
            , txtqty.Text.Trim(), Session["weight"].ToString(), ddlsp.SelectedValue, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        if (dt.Rows.Count > 0)
        {
            cf.ShowAlertMessage(dt.Rows[0][0].ToString());
            BindGrid();
        }
        else
        {
            cf.ShowAlertMessage("Transferred to Salepoint");
            BindGrid();
        }
    }
    protected void txtqty_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lblnob.Text) < Convert.ToInt32(txtqty.Text))
        {
            cf.ShowAlertMessage("Cannot Transfer more than available ");
            txtqty.Text = "";
        }
    }
    protected void BindGrid()
    {
        try
        {
            dt = new DataTable();
            dt = st.GetStockPosition(Session["year"].ToString(), Session["season"].ToString(), Session["distCode"].ToString(), Session["mandcode"].ToString(), Session["crop"].ToString(), Session["cropV"].ToString());
            if (dt.Rows.Count > 0)
            {
                StkGrid.DataSource = dt;
                StkGrid.DataBind();
            }
            else
            {
                StkGrid.DataSource = null;
                StkGrid.DataBind();
                cf.ShowAlertMessage("No Data");
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
}