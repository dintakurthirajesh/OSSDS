using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Seed_BL;
using Microsoft.Reporting.WebForms;


public partial class SuperAdmin_ViewPermits : System.Web.UI.Page
{
    CommonFuncs cf = new CommonFuncs();
    DataTable dt = new DataTable();
    ReportsBL rprt = new ReportsBL();
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
        if (Session["UsrName"] == null || Session["UsrName"].ToString() != "SuperAdmin")
        {
            Response.Redirect("~/Error.aspx");
        }
        if (!IsPostBack)
        {
            lblUsrName.Text = Session["Role"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

        }
    }
    protected void GetData(object sender, EventArgs e)
    {
        if (ddlyear.SelectedIndex == 0)
        {
            cf.ShowAlertMessage("Please select Year");
            ddlyear.Focus();
            return;
        }
        if (seasons.SelectedIndex == 0)
        {
            cf.ShowAlertMessage("Please select Season");
            seasons.Focus();
            return;
        }
        dt = new DataTable();
        // dt = rprt.generatePermitBAL("", "", "");
        dt = rprt.GetPermits_All(ddlyear.SelectedValue, seasons.SelectedValue);
        if (dt.Rows.Count > 0)
        {
            Rept.Visible = true;
            Rept.LocalReport.DataSources.Clear();
            Rept.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            // OR Set Report Path  
            Rept.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rprt_Permits_DistWs.rdlc");
            Rept.ShowPrintButton = true;
            // Refresh and Display Report  
            Rept.LocalReport.Refresh();
        }
        else
        {
            cf.ShowAlertMessage("No data found");
        }
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        Rept.Visible = false;
    }
    protected void seasons_SelectedIndexChanged(object sender, EventArgs e)
    {
        Rept.Visible = false;
    }

    protected void Rept_Drillthrough(object sender, DrillthroughEventArgs e)
    {
        try
        {
            Rept.Visible = true;
            ReportParameterInfoCollection DrillThroughValues = e.Report.GetParameters();
            string[] Params = new string[3];
            int i = 0;
            foreach (ReportParameterInfo d in DrillThroughValues)
            {
                Params[i] = d.Values[0].ToString().Trim();
                i += 1;
            }
            LocalReport report = (LocalReport)e.Report;
            if (e.ReportPath.ToString() == "Report_Permits_MandWs")
            {
                DataTable dt = new DataTable();
                dt = rprt.GetPermits_MandWS(ddlyear.SelectedValue, seasons.SelectedValue, Params[0]);
                ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
                report.DataSources.Clear();
                report.DataSources.Add(datasource);
                report.Refresh();
            }
            if (e.ReportPath.ToString() == "RDLC_Permits_SpWs")
            {
                DataTable dt = new DataTable();
                dt = rprt.GetPermits_SpWs(ddlyear.SelectedValue, seasons.SelectedValue, Params[1], Params[0]);
                //dt =r (ddlyear.SelectedValue, seasons.SelectedValue, ddlcropname.SelectedValue, Params[0], Params[1]);
                ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
                report.DataSources.Clear();
                report.DataSources.Add(datasource);
                report.Refresh();
            }
            //if (e.ReportPath.ToString() == "Report_Permits_SPWise")
            //{
            //    DataTable dt = new DataTable();
            //    dt = rprt.GetPermits_SpWsAllBL(ddlyear.SelectedValue, seasons.SelectedValue, Params[0], Params[1], Params[2]);
            //    //dt =r (ddlyear.SelectedValue, seasons.SelectedValue, ddlcropname.SelectedValue, Params[0], Params[1]);
            //    ReportDataSource datasource = new ReportDataSource("Dst_Permits_SPWise", dt);
            //    report.DataSources.Clear();
            //    report.DataSources.Add(datasource);
            //    report.Refresh();
            //}
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }
}