using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_DL;
using System.Data;
using Microsoft.Reporting.WebForms;



public partial class DistMaster : System.Web.UI.Page
{
    MasterDAL objDist = new MasterDAL();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            getDistrictDtls();
        }
    }
   
   
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        getDistrictDtls();
    }
   
   
    protected void getDistrictDtls()
    {
        try
        {
            DataTable dtDistricts = new DataTable();
            dtDistricts = objDist.viewRDLCLGConsolidatedReport("36");
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/lg/RDLC_LG_Consolidated_Report.rdlc");
            lgdistrict dsdistrict = new lgdistrict();
            dsdistrict.Tables.Add(dtDistricts);
            ReportDataSource datasource = new ReportDataSource("DataSet1", dsdistrict.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
        }
        catch { }
    }


    protected void ReportViewer1_Drillthrough(object sender, DrillthroughEventArgs e)
    {
        try
        {


            ReportViewer1.Visible = true;
            LocalReport report = (LocalReport)e.Report;
            IList<ReportParameter> list = report.OriginalParametersToDrillthrough;
            ReportParameterInfoCollection DrillThroughValues = report.GetParameters();
            string[] Params = new string[3];
            int i = 0;
            foreach (ReportParameterInfo d in DrillThroughValues)
            {
                Params[i] = d.Values[0].ToString().Trim();
                i += 1;
            }


            if (e.ReportPath.ToString() == "RDLC_MandalWsConsolidated")
            {
                DataTable dt = new DataTable();
                dt = objDist.viewRDLCLGConsolidatedMandalReport("36", Params[0], Params[1]);                
                ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
                report.DataSources.Clear();
                report.DataSources.Add(datasource);
                report.Refresh();
            }
            if (e.ReportPath.ToString() == "RDLC_LG_Cons_Villageview")
            {
                DataTable dt = new DataTable();
                dt = objDist.viewRDLCLGConsolidatedVillageReport("36", Params[0], Params[1]);
                ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
                report.DataSources.Clear();
                report.DataSources.Add(datasource);
                report.Refresh();
            }
            
            if (e.ReportPath.ToString() == "RDLC_LG_Cons_GPView")
            {
                DataTable dt = new DataTable();
                dt = objDist.viewRDLCLGConsolidatedGPReport("36", Params[0], Params[1]);
                ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
                report.DataSources.Clear();
                report.DataSources.Add(datasource);
                report.Refresh();
            }
            if (e.ReportPath.ToString() == "RDLC_LG_MandalWs_Villageview")
            {
                DataTable dt = new DataTable();
                dt = objDist.viewRDLCLGConsolidatedMandalVillageReport("36", Params[0], Params[1], Params[2]);               
                ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
                report.DataSources.Clear();
                report.DataSources.Add(datasource);
                report.Refresh();
            }
            if (e.ReportPath.ToString() == "RDLC_LG_mandal_GPView")
            {
                DataTable dt = new DataTable();
                dt = objDist.viewRDLCLGConsolidatedMandalWsGPReport("36", Params[0], Params[1], Params[2]);
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


  
}