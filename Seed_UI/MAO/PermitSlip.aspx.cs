using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_BL;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class MAO_PermitSlip : System.Web.UI.Page
{

    ReportsBL ObjBL = new ReportsBL();
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

        if (Session["UsrName"] == null )
        {
            Response.Redirect("~/Error.aspx");
        }

        if (!IsPostBack)
        {
            lblUsrName.Text = Session["UsrName"].ToString();
            lblDist.Text = Session["district"].ToString();
            lblMand.Text = Session["mandal"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            /*GENERATE PERMIT*/
            getReport();
        }
    }
    protected void getReport()
    {
        try
        {
            RptPermit.LocalReport.DataSources.Clear();
            // Set a DataSource to the report  
            // First Parameter - Report DataSet Name  
            // Second Parameter - DataSource Object i.e DataTable  
            RptPermit.LocalReport.DataSources.Add(new ReportDataSource("Ds_GeneratePermit", ObjBL.generatePermitBAL(Session["FarmerId"].ToString(), Session["FinYear"].ToString(), Session["SeasonName"].ToString(), Session["PermitCode"].ToString())));
            // OR Set Report Path  
            RptPermit.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_GeneratePermit.rdlc");
            // Refresh and Display Report  
            RptPermit.LocalReport.Refresh();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void lblBacktoRequest_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MAO/GeneratePermitAlternate.aspx");
    }
}