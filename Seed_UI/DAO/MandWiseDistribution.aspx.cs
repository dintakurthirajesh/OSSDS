using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Seed_BL;
using Microsoft.Reporting.WebForms;

public partial class DAO_MandWiseDistribution : System.Web.UI.Page
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

            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        }
    }
    protected void GetData(object sender, EventArgs e)
    {
        try
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
            dt = rprt.GetreportDistributionMandWise(ddlyear.SelectedValue, seasons.SelectedValue, Session["DistCode"].ToString());
            if (dt.Rows.Count > 0)
            {
                Rept.Visible = true;
                
                Rept.LocalReport.DataSources.Clear();
                ReportParameter rp = new ReportParameter("DistCode", Session["DistCode"].ToString());
               // ReportParameter rp = new ReportParameter("districtcode", Session["DistCode"].ToString());
                Rept.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                // OR Set Report Path  
                Rept.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Seeddistributionmandal.rdlc");
              //  Rept.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/seeddistributationmandalnew.rdlc");
                Rept.LocalReport.SetParameters(new ReportParameter[] { rp });

                Rept.ShowPrintButton = true;
              
               
  
                // Refresh and Display Report  
                Rept.LocalReport.Refresh();
            }
            else
            {
                cf.ShowAlertMessage("No data found");
            }
        }
        catch (Exception ex)
        {
         //   ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
           // Response.Redirect("~/Error.aspx");
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

           
            if (e.ReportPath.ToString() == "seeddistributionsubreport")
            {
                DataTable dt = new DataTable();
                dt = rprt.GetreportDistrbutionSPWise(ddlyear.SelectedValue, seasons.SelectedValue, Params[0], Params[1]);
                // dt = rprt.GetreportDistributionMandWise(ddlyear.SelectedValue, seasons.SelectedValue, Params[0]);
                ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
                report.DataSources.Clear();
                report.DataSources.Add(datasource);
                report.Refresh();
            }

            if (e.ReportPath.ToString() == "Salepointwisefarmerdetails")
            {
                DataTable dt = new DataTable();
                dt = rprt.Getreportsalepointwisefarmerdetails(Params[0], ddlyear.SelectedValue, seasons.SelectedValue);
                // dt = rprt.GetreportDistributionMandWise(ddlyear.SelectedValue, seasons.SelectedValue, Params[0]);
                ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
                report.DataSources.Clear();
                report.DataSources.Add(datasource);
                report.Refresh();
            }
        }
        catch (Exception ex)
        {
           // ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            //Response.Redirect("~/Error.aspx");
        }
    
    }
}