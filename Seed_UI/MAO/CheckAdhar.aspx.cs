using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Seed_BL;

public partial class MAO_CheckAdhar : System.Web.UI.Page
{
   
    DataTable dt;
    CommonFuncs objCommon = new CommonFuncs();
    Request_Issue_BL obj = new Request_Issue_BL();
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
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtAdhar1.Text == "" || txtAdhar2.Text == "" || txtAdhar3.Text == "")
            objCommon.ShowAlertMessage("Enter Adhar Number");
        BindGrid();
    }
    protected void BindGrid()
    {
        try
        {
            dt = new DataTable();
            dt = obj.CheckAdhar(txtAdhar1.Text + txtAdhar2.Text + txtAdhar3.Text);
            if (dt.Rows.Count > 0)
            {
                GVDetails.DataSource = dt;
                GVDetails.DataBind();
            }
            else
            {
                GVDetails.DataSource = null;
                GVDetails.DataBind();
                objCommon.ShowAlertMessage("No farmer found with given Adhar Number");
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GVDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVDetails.PageIndex = e.NewPageIndex;
        BindGrid();
    }
}