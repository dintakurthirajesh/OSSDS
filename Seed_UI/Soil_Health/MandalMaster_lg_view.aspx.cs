using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_DL;
using System.Data;
using System.Web.Security;
using Seed_BE;
using Microsoft.Reporting.WebForms;
public partial class MandalMaster : System.Web.UI.Page
{
    MasterDAL objDist = new MasterDAL();
    CommonFuncs objCommon = new CommonFuncs();  
 
    DataTable ddt;
   
    string Flag_IUP;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        try
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
                ddt = objDist.viewdataDALlg("36");
                objCommon.BindDropDownLists(ddl_dist_code, ddt, "DistName", "DistCode", "0");
                Viewdata();
            }
        }
        catch (Exception ex)
        {
           

        }
    }

    
   
    protected void ddl_dist_code_SelectedIndexChanged(object sender, EventArgs e)
    {
     
            Viewdata();
      

    }
    public void Viewdata()
    {
        try
        {
            DataTable dt1 = new DataTable();
            Flag_IUP = "R";
            string strdistcode = "";
            if (ddl_dist_code.SelectedValue == "")
            {
                strdistcode = "0";

            }
            else
            {
                strdistcode = ddl_dist_code.SelectedValue;
            }
            dt1 = objDist.viewDistdataDAL(strdistcode.ToString(), Flag_IUP);
            if (dt1.Rows.Count > 0)
            {
                
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/lg/lgmandalview.rdlc");
                lgmandalview dsmandalview = new lgmandalview();
                dsmandalview.Tables.Add(dt1);
                ReportDataSource datasource = new ReportDataSource("DataSet1", dsmandalview.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
            }
            else
            {
                objCommon.ShowAlertMessage("No data found");
               
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/lg/Error.aspx");

        }
    }

}
