using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Seed_BL;

public partial class SuperAdmin_ViewSP : System.Web.UI.Page
{
    ReportsBL rprt = new ReportsBL();
    DataTable dt = new DataTable();
    int t1 = 0;
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
        if (Session["UsrName"] == null || Session["UsrName"].ToString() != "SuperAdmin")
        {
            Response.Redirect("~/Error.aspx");
        }
        Session["StateCode"] = "36";
        Session["UsrName"] = "Admin";

        if (!IsPostBack)
        {
            lblUsrName.Text = Session["Role"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            BindGrid();
        }
    }


    protected void BindGrid()
    {
        dt = rprt.GetSalePoints();
        gvsp.DataSource = dt;
        gvsp.DataBind();
    }
    protected void gvsp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label total = (Label)e.Row.FindControl("nosp");
            int qty = Int32.Parse(total.Text);
            t1 = t1 + qty;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            LinkButton totalfooter = (LinkButton)e.Row.FindControl("totalsps");
            totalfooter.Text = t1.ToString();
        }

    }
    protected void nosp_Click(object sender, EventArgs e)
    {
        GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        Label distcode = (Label)clickedRow.FindControl("lbldistcode");
        LinkButton dist = (LinkButton)clickedRow.FindControl("lblDist");
        Session["dist"] = distcode.Text;
        Session["distNm"] = dist.Text;
        Response.Redirect("DistWiseSP.aspx");
    }
    protected void totalsps_Click(object sender, EventArgs e)
    {
        Response.Redirect("SalePointDetails.aspx");
    }
}