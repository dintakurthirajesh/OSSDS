using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_BL;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class SalesPoint_PurchaseReceipt : System.Web.UI.Page
{
    DistributedseedBL objbl = new DistributedseedBL();
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
        RptReceipt.LocalReport.DataSources.Clear();
        RptReceipt.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", objbl.GetPurchaseReceipt(Session["permit"].ToString(), Session["SpCode"].ToString(),"")));
        RptReceipt.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/SeedPurchaseReceipt.rdlc");
        RptReceipt.LocalReport.Refresh();
    }
    protected void lblBacktoRequest_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SalesPoint/Distributionseeds.aspx");
    }
}