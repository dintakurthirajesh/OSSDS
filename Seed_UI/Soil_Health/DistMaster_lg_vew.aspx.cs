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
        if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
        {
            Response.Redirect("~/Soil_Health/Error.aspx");
        }
        else
        {
            string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
            string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
            int len = http_hos.Length;
            if (http_ref.IndexOf(http_hos, 0) < 0)
            {
                Response.Redirect("~/Soil_Health/Error.aspx");
            }
        }
        if (Session["Rolecode"].ToString() == null || Session["Rolecode"].ToString() != "0")
        {
            Response.Redirect("~/Soil_Health/Error.aspx");
        }
        lblUsrName.Text = Session["UsrName"].ToString();
        if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
        {
            Response.Redirect("~/Soil_Health/Error.aspx");
        }
        else
        {
            string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
            string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
            int len = http_hos.Length;
            if (http_ref.IndexOf(http_hos, 0) < 0)
            {
                Response.Redirect("~/Soil_Health/Error.aspx");
            }
        }
        if (Session["Rolecode"].ToString() == null || Session["Rolecode"].ToString() != "0")
        {
            Response.Redirect("~/Soil_Health/Error.aspx");
        }
        lblUsrName.Text = Session["UsrName"].ToString();
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
            dtDistricts = objDist.viewdataDALlg("36");
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/lg/District.rdlc");
            lgdistrict dsdistrict = new lgdistrict();
            dsdistrict.Tables.Add(dtDistricts);
            ReportDataSource datasource = new ReportDataSource("DataSet1", dsdistrict.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
        }
        catch { }
    }

   
   


  
}