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

public partial class MAO_ViewDistrbution : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    CommonFuncs cf = new CommonFuncs();
    SeedAllotBL seedObj = new SeedAllotBL();
    ReportsBL rprt = new ReportsBL();
    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
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
            lblMand.Text = Session["mandal"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            BindSP();
        }
    }
    protected void BindSP()
    {
        dt = seedObj.GetSalepoints(Session["StateCode"].ToString(), Session["distCode"].ToString(), Session["mandcode"].ToString());
        cf.BindDropDownLists(ddlsp, dt, "SalePtName", "SalePtCode", "select sale point");
    }
    protected void GetData(object sender, EventArgs e)
    {
        try
        {
            DateTime frmdt = DateTime.Parse(txtFrmdt.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            DateTime todt = DateTime.Parse(txtTodt.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            dt = rprt.GetDistributionDtWs(ddlsp.SelectedValue, frmdt, todt);
            if (dt.Rows.Count > 0)
            {
                Rept.Visible = true;
                Rept.LocalReport.DataSources.Clear();
                Rept.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                // OR Set Report Path  
                Rept.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/SeedDistribtion.rdlc");
                Rept.ShowPrintButton = true;
                // Refresh and Display Report  
                Rept.LocalReport.Refresh();
            }
            else
            {
                cf.ShowAlertMessage("No data found");
                Rept.LocalReport.Refresh();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
}