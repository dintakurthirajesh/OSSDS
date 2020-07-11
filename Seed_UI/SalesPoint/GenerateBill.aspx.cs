using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_BL;
using System.Data;
using Microsoft.Reporting.WebForms;
public partial class SalesPoint_GenerateBill : System.Web.UI.Page
{
    DistributedseedBL objbl = new DistributedseedBL();
    CommonFuncs cf = new CommonFuncs();
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
           
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        getReport();
    }
    protected void getReport()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objbl.GetPurchaseReceipt(txtpermit.Text.Trim(), Session["SpCode"].ToString(), txtadhar.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                RptReceipt.LocalReport.DataSources.Clear();
                RptReceipt.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                RptReceipt.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/SeedPurchaseReceipt.rdlc");
                RptReceipt.LocalReport.Refresh();
            }
            else
            {
                cf.ShowAlertMessage("Seed is not distributed for this permit.");
            }
           
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
}