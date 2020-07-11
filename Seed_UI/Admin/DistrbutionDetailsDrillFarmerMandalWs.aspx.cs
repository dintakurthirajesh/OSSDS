using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Seed_BL;
using Microsoft.Reporting.WebForms;
using System.IO;

public partial class Admin_DistrbutionDetails : System.Web.UI.Page
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
        if (Session["UsrName"] == null || Session["UsrName"].ToString() != "Admin")
        {
            Response.Redirect("~/Error.aspx");
        }
        if (!IsPostBack)
        {
            lblUsrName.Text = Session["Role"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            ddlyear.SelectedValue = Session["yearcd"].ToString();
            seasons.SelectedValue = Session["season"].ToString();
            Label4.Visible = false;
            ddlpagesize.Visible = false;
            BindCrops();
            ddlcrop.SelectedValue = Session["crop"].ToString();
            lblremarks.Visible = true;
            lblremarks.Text = "District Name:" + Session["districtname"].ToString() + ",MandalName:" + Session["mandalname"].ToString() + ",Category:" + Session["casttype"].ToString() + ",Season:" + seasons.SelectedValue + ",Crop Name:" + ddlcrop.SelectedItem.Text + "";
            GetReport();
        }
    }
    public void BindCrops()
    {
        dt = objcrop.GetCrops();
        cf.BindDropDownLists(ddlcrop, dt, "CropName", "CropCode", "Select Crop Name");
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
        if (ddlcrop.SelectedIndex == 0)
        {
            cf.ShowAlertMessage("Please select Crop");
            ddlcrop.Focus();
            return;
        }
        else
            GetReport();
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridviewdistrictwise.Visible = false;
    }
    protected void seasons_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridviewdistrictwise.Visible = false;
    }
    protected void gridviewdistrictwise_RowCreated(object sender, GridViewRowEventArgs e)
    {
       
    }
    protected void GetReport()
    {
        try
        {
            dt = new DataTable();

            dt = rprt.GetDistributionMandalWsFarmerDetails(ddlyear.SelectedValue, seasons.SelectedValue, ddlcrop.SelectedValue, Session["districtcd"].ToString(),Session["mandalcd"].ToString(), Session["casttype"].ToString(), Session["gender"].ToString());
            if (dt.Rows.Count > 0)
            {
                Label4.Visible = true;
                ddlpagesize.Visible = true;
                gridviewdistrictwise.Visible = true;
                Session["farmerdata"] = dt;
                gridviewdistrictwise.PageSize = Convert.ToInt32(ddlpagesize.SelectedValue);
                gridviewdistrictwise.DataSource = dt;
                gridviewdistrictwise.DataBind();
            }
            else
            {
                cf.ShowAlertMessage("No data found");
                Label4.Visible = false;
                ddlpagesize.Visible = false;
                gridviewdistrictwise.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
         //   Response.Redirect("~/Error.aspx");
        }
    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        DataTable dtpage = (DataTable)Session["farmerdata"];
        gridviewdistrictwise.PageIndex = e.NewPageIndex;
        gridviewdistrictwise.DataSource = dtpage;
        gridviewdistrictwise.PageSize = Convert.ToInt32(ddlpagesize.SelectedValue);
        gridviewdistrictwise.DataBind();
    }
    protected void gridviewdistrictwise_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            DataTable dtfootercount = (DataTable)Session["farmerdata"];
            Label lblfbagspurchased = (Label)e.Row.FindControl("lblfbagspurchased");
            Label lblfamountpaid = (Label)e.Row.FindControl("lblfamountpaid");
       
            if (dtfootercount.Rows.Count > 0)
            {
                int no_of_bags_purchased = 0;decimal Amount_paid = 0;
              //  decimal Amount_paid = Convert.ToDecimal(dtfootercount.Compute("SUM(Amount_paid)", string.Empty));
           
               for (int i = 0; i <= dtfootercount.Rows.Count - 1; i++)
               {
                   if (dtfootercount.Rows[i]["no_of_bags_purchased"].ToString() != "")
                   {
                       no_of_bags_purchased += Convert.ToInt32(dtfootercount.Rows[i]["no_of_bags_purchased"].ToString());
                     
                   }
                   if (dtfootercount.Rows[i]["Amount_paid"].ToString() != "")
                   {
                       Amount_paid += Convert.ToDecimal(dtfootercount.Rows[i]["Amount_paid"].ToString());
                   }
               }

                lblfbagspurchased.Text = no_of_bags_purchased.ToString();
                lblfamountpaid.Text = Amount_paid.ToString();
               
            }
        }
    }
    protected void btnexport_Click(object sender, EventArgs e)
    {

        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";

        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-disposition", "attachment;filename=SeedDistributionMandalDetails.xls");
        gridviewdistrictwise.GridLines = GridLines.Both;
        gridviewdistrictwise.HeaderStyle.Font.Bold = true;
        gridviewdistrictwise.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void btnhome_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/DistrbutionDetailsMandalwise.aspx");
    }
    protected void ddlpagesize_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtpage = (DataTable)Session["farmerdata"];
      
        gridviewdistrictwise.DataSource = dtpage;
        gridviewdistrictwise.PageSize = Convert.ToInt32(ddlpagesize.SelectedValue);
        gridviewdistrictwise.DataBind();
    }
}