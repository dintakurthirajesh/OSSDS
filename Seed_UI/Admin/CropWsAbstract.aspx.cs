using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Seed_BL;
using Microsoft.Reporting.WebForms;

public partial class Admin_CropWsAbstract : System.Web.UI.Page
{
    CommonFuncs cf = new CommonFuncs();
    ReportsBL ObjBL = new ReportsBL();
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
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        getReport();
    }
    protected void getReport()
    {
        dt = ObjBL.GetCropWsAbstract(ddlyear.SelectedValue, seasons.SelectedValue);
        if (dt.Rows.Count > 0)
        {
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            ReportViewer1.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/CropWsAbsrtact.rdlc");
            ReportViewer1.LocalReport.Refresh();
        }
        else
            cf.ShowAlertMessage("No data");
    }
}