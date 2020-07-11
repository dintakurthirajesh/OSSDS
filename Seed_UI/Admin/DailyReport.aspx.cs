using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_BL;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class Admin_DailyReport : System.Web.UI.Page
{
    ReportsBL ObjBL = new ReportsBL();
    CommonFuncs cf = new CommonFuncs();
    DataTable ddt = new DataTable();
    MasterBAL objcrop = new MasterBAL();
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
        if (!IsPostBack)
        {
            lblUsrName.Text = Session["Role"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            BindCrop();
        }
    }
    private void BindCrop()
    {
        DataTable dt = new DataTable();
        dt = objcrop.GetCrops();
        cf.BindDropDownLists(ddlcrop, dt, "CropName", "CropCode", "Select Crop");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        getReport();
    }
    protected void getReport()
    {
        ddt = ObjBL.GetDailyReport(ddlyear.SelectedValue, seasons.SelectedValue,ddlcrop.SelectedValue,txtdt.Text.Trim());
        if (ddt.Rows.Count > 0)
        {
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1",ddt));
            ReportViewer1.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/DailyRprt.rdlc");
            ReportViewer1.LocalReport.Refresh();
        }
        else
            cf.ShowAlertMessage("No data");
    }
}