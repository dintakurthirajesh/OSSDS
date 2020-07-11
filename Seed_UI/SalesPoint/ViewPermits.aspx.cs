﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Seed_BL;
using Microsoft.Reporting.WebForms;

public partial class SalesPoint_ViewPermits : System.Web.UI.Page
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
        dt = rprt.GetPermits_SPWiseBAL(ddlyear.SelectedValue, seasons.SelectedValue, Session["SpCode"].ToString());
        if (dt.Rows.Count > 0)
        {
            Rept.Visible = true;
            Rept.LocalReport.DataSources.Clear();
            Rept.LocalReport.DataSources.Add(new ReportDataSource("Dst_Permits_SPWise", dt));
            // OR Set Report Path  
            Rept.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Report_Permits_SPWise.rdlc");
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
}