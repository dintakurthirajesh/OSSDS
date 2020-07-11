using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Seed_BL;
using Microsoft.Reporting.WebForms;

public partial class SalesPoint_ViewStock : System.Web.UI.Page
{
    CommonFuncs cf = new CommonFuncs();
    DataTable dt = new DataTable();
    ReportsBL objbl = new ReportsBL();
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
            //BindCrop();
        }
    }
    //private void BindCrop()
    //{
    //    dt = objcrop.viewdCropBAL();
    //    cf.BindDropDownLists(ddl_crop, dt, "CropName", "CropCode", "Select Crop");      
    //}
    //private void BindCropVariety()
    //{
    //    dt = objcrop.viewdCroplistBAL(ddl_crop.SelectedValue);
    //    cf.BindDropDownLists(ddl_variety, dt, "CropVnm", "CropVCode", "Select Crop Variety");
    //}
    //protected void ddl_crop_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlyear.SelectedIndex == 0)
    //    {
    //        ddl_crop.SelectedIndex = 0;
    //        cf.ShowAlertMessage("Select Year First");
    //    }
    //    else if (seasons.SelectedIndex == 0)
    //    {
    //        ddl_crop.SelectedIndex = 0;
    //        cf.ShowAlertMessage("select season first");
    //    }
    //    else
    //    {
    //        BindCropVariety();
    //    }
    //}
    //protected void ddl_variety_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddl_crop.SelectedIndex == 0)
    //        cf.ShowAlertMessage("Select Crop First");
    //    //else
    //    //    BindGrid();
    //}
    protected void GetData(object sender, EventArgs e)
    {
        try
        {
            dt = objbl.GetSaleInfoBAL(ddlyear.SelectedValue, seasons.SelectedValue, Session["SpCode"].ToString());
            if (dt.Rows.Count > 0)
            {
                Rept.Visible = true;
                Rept.LocalReport.DataSources.Clear();
                Rept.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                // OR Set Report Path  
                Rept.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/StockReport.rdlc");
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
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
}