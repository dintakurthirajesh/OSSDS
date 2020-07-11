using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_BL;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class Admin_ViewSeedAllotment : System.Web.UI.Page
{
    ReportsBL ObjBL = new ReportsBL();
    CommonFuncs objCommon = new CommonFuncs();
    DataTable ddt = new DataTable();
    MasterBAL objDist = new MasterBAL();
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
            BindCrops();
        }
    }
    public void BindCrops()
    {
        ddt = objDist.GetCrops();
        objCommon.BindDropDownLists(ddlcropname, ddt, "CropName", "CropCode", "Select Crop Name");
    }
    protected void getReport()
    {
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ObjBL.GetAllotmentDistWise(ddlyear.SelectedValue, seasons.SelectedValue, ddlcropname.SelectedValue)));     
        ReportViewer1.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/SeedAllotmentDistWise.rdlc");
        ReportViewer1.LocalReport.Refresh();
    }
    protected void ReptSchme_Drillthrough(object sender, DrillthroughEventArgs e)
    {
        try
        {
            ReportViewer1.Visible = true;
            ReportParameterInfoCollection DrillThroughValues = e.Report.GetParameters();
            string[] Params = new string[2];
            int i = 0;
            foreach (ReportParameterInfo d in DrillThroughValues)
            {
                Params[i] = d.Values[0].ToString().Trim();
                i += 1;
            }
            LocalReport report = (LocalReport)e.Report;
            if (e.ReportPath.ToString() == "SeedAllotmentMandWise")
            {
                DataTable dt = new DataTable();
                dt = ObjBL.GetAllotmentMandWise(ddlyear.SelectedValue, seasons.SelectedValue, ddlcropname.SelectedValue, Params[0]);
                ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
                report.DataSources.Clear();
                report.DataSources.Add(datasource);
                report.Refresh();
            }
            if (e.ReportPath.ToString() == "SeedAllotmentSPWise")
            {
                DataTable dt = new DataTable();
                dt = ObjBL.GetAllotmentSPWise(ddlyear.SelectedValue, seasons.SelectedValue, ddlcropname.SelectedValue, Params[0], Params[1]);
                ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
                report.DataSources.Clear();
                report.DataSources.Add(datasource);
                report.Refresh();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void ddlcropname_SelectedIndexChanged(object sender, EventArgs e)
    {
        getReport();
    }
}